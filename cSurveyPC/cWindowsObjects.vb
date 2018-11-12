﻿'Requires unmanaged code
'<Assembly: System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.RequestMinimum, System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode = True)> 
' Requires all clipboard access
'<Assembly: System.Security.Permissions.UIPermissionAttribute(System.Security.Permissions.SecurityAction.RequestMinimum, Clipboard = UIPermissionClipboard.AllClipboard)> 


''' <summary>
''' Provides a way to receive notifications of changes to the 
''' content of the clipboard using the Windows API.  
''' </summary>
''' <remarks>
''' To be a part of the change notification you need to register a 
''' window in the Clipboard Viewer Chain.  This provides
''' notification messages to the window whenever the 
''' clipboard changes, and also messages associated with managing
''' the chain.  This class manages the detail of keeping the
''' chain intact and ensuring that the application is removed
''' from the chain at the right point.
''' 
''' Use the <see cref="System.Windows.Forms.NativeWindow.AssignHandle"/> method 
''' to connect this class up to a form to begin receiving notifications.
''' Note that a Form can change its <see cref="System.Windows.Forms.Form.Handle"/>	
''' under certain circumstances; for example, if you change the 
''' <see cref="System.Windows.Forms.Form.ShowInTaskbar"/> property the Framework
''' must re-create the form from scratch since Windows ignores changes to 
''' that style unless they are in place when the Window is created.
''' (As a consequence, you should try to set as many high-level Window 
''' style details as possible prior to creating the Window, or at least,
''' prior to making it visible).  The <see cref="OnHandleChanged"/> 
''' method of this class is called when this happens.  You need to
''' re-assign the handle again whenever this occurs.  Unfortunately
''' <see cref="OnHandleChanged"/> is not a useful event in which to
''' do anything since the window handle at that point contains neither
''' a valid old window or a valid new one.  Therefore you need to
''' make the call to re-assign at a point when you know the window
''' is valid, for example, after styles have been changed, or 
''' by overriding <see cref="System.Windows.Forms.Form.OnHandleCreated"/>.
''' </remarks>		
Friend Class clipboardChangeNotifier
    Inherits NativeWindow
    Implements IDisposable

#Region "Unmanaged Code"
    Private Declare Function SetClipboardViewer Lib "user32" (
            ByVal hWnd As IntPtr
        ) As IntPtr

    Private Declare Function ChangeClipboardChain Lib "user32" (
            ByVal hWnd As IntPtr,
            ByVal hWndNext As IntPtr
        ) As Integer

    Private Declare Auto Function SendMessage Lib "user32" (
            ByVal hWnd As IntPtr,
            ByVal wMsg As Integer,
            ByVal wParam As IntPtr,
            ByVal lParam As IntPtr
        ) As Integer

    Private Const WM_DESTROY As Integer = &H2
    Private Const WM_DRAWCLIPBOARD As Integer = &H308
    Private Const WM_CHANGECBCHAIN As Integer = &H30D
#End Region

#Region "Member Variables"
    ''' <summary>
    ''' The next handle in the clipboard viewer chain when the 
    ''' clipboard notification is installed, otherwise <see cref="IntPtr.Zero"/>
    ''' </summary>
    Protected nextViewerHandle As IntPtr = IntPtr.Zero
    ''' <summary>
    ''' Whether this class has been disposed or not.
    ''' </summary>
    Protected disposed As Boolean = False
    ''' <summary>
    ''' The Window clipboard change notification was installed for.
    ''' </summary>
    Protected installedHandle As IntPtr = IntPtr.Zero
#End Region

#Region "Events"
    ''' <summary>
    ''' Notifies of a change to the clipboard's content.
    ''' </summary>
    Public Event ClipboardChanged As System.EventHandler
#End Region

    ''' <summary>
    ''' Provides default WndProc processing and responds to
    ''' clipboard change notifications.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub WndProc(ByRef e As System.Windows.Forms.Message)
        Try
            ' if the message is a clipboard change notification
            Select Case (e.Msg)
                Case WM_CHANGECBCHAIN
                    ' Store the changed handle of the next item 
                    ' in the clipboard chain:
                    Me.nextViewerHandle = e.LParam

                    If Not (Me.nextViewerHandle.Equals(IntPtr.Zero)) Then
                        ' pass the message on:
                        SendMessage(Me.nextViewerHandle, e.Msg, e.WParam, e.LParam)
                    End If

                    ' We have processed this message:
                    e.Result = IntPtr.Zero

                Case WM_DRAWCLIPBOARD
                    ' content of clipboard has changed:
                    Dim clipChange As EventArgs = New EventArgs()
                    OnClipboardChanged(clipChange)

                    ' pass the message on:
                    If Not (Me.nextViewerHandle.Equals(IntPtr.Zero)) Then
                        SendMessage(Me.nextViewerHandle, e.Msg, e.WParam, e.LParam)
                    End If

                    ' We have processed this message:
                    e.Result = IntPtr.Zero

                Case WM_DESTROY
                    ' Very important: ensure we are uninstalled.
                    Uninstall()
                    ' And call the superclass:
                    MyBase.WndProc(e)

                Case Else
                    ' call the superclass implementation:
                    MyBase.WndProc(e)

            End Select
        Catch
            MyBase.WndProc(e)
        End Try
    End Sub

    ''' <summary>
    ''' Responds to Window Handle change events and uninstalls
    ''' the clipboard change notification if it is installed.
    ''' </summary>
    Protected Overrides Sub OnHandleChange()
        ' If we did get to this point, and we're still
        ' installed then the chain will be broken.
        ' The response to the WM_TERMINATE message should
        ' prevent Me.
        Uninstall()
        MyBase.OnHandleChange()
    End Sub

    ''' <summary>
    ''' Installs clipboard change notification.  The
    ''' <see cref="AssignHandle"/> method of this class
    ''' must have been called first.
    ''' </summary>
    Public Sub Install()
        Me.Uninstall()
        If Not (Me.Handle.Equals(IntPtr.Zero)) Then
            Me.nextViewerHandle = SetClipboardViewer(Me.Handle)
            Me.installedHandle = Me.Handle
        End If
    End Sub

    ''' <summary>
    ''' Uninstalls clipboard change notification.
    ''' </summary>
    Public Sub Uninstall()
        If Not (Me.installedHandle.Equals(IntPtr.Zero)) Then
            ChangeClipboardChain(Me.installedHandle, Me.nextViewerHandle)
            Dim err As Integer = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            'Debug.Assert((err = 0), String.Format("{0} Failed to uninstall from Clipboard Chain", Me), Win32Error.ErrorMessage(err))
            Me.nextViewerHandle = IntPtr.Zero
            Me.installedHandle = IntPtr.Zero
        End If
    End Sub

    ''' <summary>
    ''' Raises the <c>ClipboardChanged</c> event.
    ''' </summary>
    ''' <param name="e">Blank event arguments.</param>
    Protected Sub OnClipboardChanged(ByVal e As EventArgs)
        RaiseEvent ClipboardChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Uninstalls clipboard event notifications if necessary
    ''' during dispose of this object.
    ''' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        If Not (Me.disposed) Then
            Uninstall()
            Me.disposed = True
        End If
    End Sub

    ''' <summary>
    ''' Constructs a new instance of this class.
    ''' </summary>
    Public Sub New()
        ' intentionally blank
        MyBase.New()
    End Sub

End Class

Friend Class Win32Error

    Private Const FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
    Private Const FORMAT_MESSAGE_ARGUMENT_ARRAY As Integer = &H2000
    Private Const FORMAT_MESSAGE_FROM_HMODULE As Integer = &H800
    Private Const FORMAT_MESSAGE_FROM_STRING As Integer = &H400
    Private Const FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000
    Private Const FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
    Private Const FORMAT_MESSAGE_MAX_WIDTH_MASK As Integer = &HFF

    Private Declare Auto Function FormatMessage Lib "kernel32" (
        ByVal dwFlags As Integer,
        ByVal lpSource As IntPtr,
        ByVal dwMessageId As Integer,
        ByVal dwLanguageId As Integer,
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)>
        ByVal lpBuffer As System.Text.StringBuilder,
        ByVal nSize As Integer,
        ByVal Arguments As IntPtr) As Integer

    ''' <summary>
    ''' Returns a string containing the error message for a Win32 API error code.
    ''' </summary>
    ''' <param name="lastWin32Error">Win32 Error</param>
    ''' <returns>Error Message associated with Win32 Error</returns>
    Public Shared Function ErrorMessage(
            ByVal lastWin32Error As Integer
        ) As String
        Dim msg As System.Text.StringBuilder = New System.Text.StringBuilder(256, 256)
        Dim size As Integer = FormatMessage(
         FORMAT_MESSAGE_FROM_SYSTEM Or FORMAT_MESSAGE_IGNORE_INSERTS,
         IntPtr.Zero, lastWin32Error, 0,
         msg, msg.MaxCapacity, IntPtr.Zero)
        Return msg.ToString()
    End Function

    ''' <summary>
    ''' Private constructor - static methods.
    ''' </summary>
    Private Sub New()
        ' intentionally blank
    End Sub
End Class