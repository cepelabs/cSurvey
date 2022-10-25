﻿Imports System.ComponentModel
Imports cSurveyPC
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.XtraRichEdit.Model
Imports ScintillaNET

Public Class cItemPropertyControl
    Implements cUIControlPropertyInteractions

    Private oItem As cItem

    Public Overridable ReadOnly Property Item As cItem
        Get
            Return oItem
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
    End Sub

    Private oVisibleParent As cCollapsablePropertyControlContainer

    Public Sub SetVisibleParent(Control As cCollapsablePropertyControlContainer)
        oVisibleParent = Control
    End Sub

    Private bIsVisible As Boolean = True

    Public ReadOnly Property IsVisible() As Boolean
        Get
            Return bIsVisible
        End Get
    End Property

    Public Shadows Property Visible As Boolean
        Get
            Return bIsVisible
        End Get
        Set(value As Boolean)
            bIsVisible = value
            If oVisibleParent IsNot Nothing Then oVisibleParent.Visible = bIsVisible
            MyBase.Visible = value
            If MyBase.Parent IsNot Nothing Then
                If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
                    DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me).Visibility = If(bIsVisible, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
                End If
            End If
        End Set
    End Property

    Public Shadows Property Height As Integer
        Get
            Return MyBase.Height
        End Get
        Set(value As Integer)
            If MyBase.Height <> value Then
                If MyBase.Height < value Then
                    If MyBase.Parent IsNot Nothing Then
                        If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
                            With DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me)
                                .ControlMaxSize = New Size(0, value)
                                .ControlMinSize = New Size(0, value)
                            End With
                        End If
                    End If
                Else
                    If MyBase.Parent IsNot Nothing Then
                        If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
                            With DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me)
                                .ControlMinSize = New Size(0, value)
                                .ControlMaxSize = New Size(0, value)
                            End With
                        End If
                    End If
                End If
                MyBase.Height = value
            End If
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DisabledObjectProperty() As Boolean
        Get
            If oItem Is Nothing Then
                Return True
            Else
                Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent)
                RaiseEvent OnGetFlags(Me, oArgs)
                Return oArgs.Value
            End If
        End Get
        Set(value As Boolean)
            If Not oItem Is Nothing Then
                Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent, value)
                RaiseEvent OnSetFlags(Me, oArgs)
            End If
        End Set
    End Property
    Public Event OnGetFlags(Sender As Object, e As FlagEventArgs) Implements cUIControlPropertyInteractions.OnGetFlags
    Public Event OnSetFlags(Sender As Object, e As FlagEventArgs) Implements cUIControlPropertyInteractions.OnSetFlags

    Public Event OnDrawInvalidate(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnDrawInvalidate
    Public Event OnSurveyInvalidate(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnSurveyInvalidate
    Public Event OnObjectPropertyLoad(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnObjectPropertyLoad
    Public Event OnDoCommand(Sender As Object, e As DoCommandEventArgs) Implements cUIControlPropertyInteractions.OnDoCommand

    Public Event OnMapInvalidate(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnMapInvalidate
    Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cUIControlPropertyInteractions.OnPropertyChanged

    Public Event OnTakeUndoSnapshot(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnTakeUndoSnapshot
    Public Event OnCreateUndoSnapshot(Sender As Object, e As CreateUndoSnapshotEventArgs) Implements cUIControlPropertyInteractions.OnCreateUndoSnapshot
    Public Event OnBeginUndoSnapshot(Sender As Object, e As BeginUndoSnapshotEventArgs) Implements cUIControlPropertyInteractions.OnBeginUndoSnapshot
    Public Event OnCommitUndoSnapshot(Sender As Object, e As CommitUndoSnapshotEventArgs) Implements cUIControlPropertyInteractions.OnCommitUndoSnapshot
    Public Event OnCancelUndoSnapshot(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnCancelUndoSnapshot

    Public Sub CreateUndoSnapshot(Description As String, PropertyName As String)
        RaiseEvent OnCreateUndoSnapshot(Me, New CreateUndoSnapshotEventArgs(Description, PropertyName))
    End Sub

    Public Sub CreateUndoSnapshot(Description As String, BackupDelegate As cUndoItemBackupValueDelegate, RestoreDelegate As cUndoItemRestoreValueDelegate)
        RaiseEvent OnCreateUndoSnapshot(Me, New CreateUndoSnapshotEventArgs(Description, BackupDelegate, RestoreDelegate))
    End Sub

    Public Sub BeginUndoSnapshot(Description As String)
        RaiseEvent OnBeginUndoSnapshot(Me, New BeginUndoSnapshotEventArgs(Description))
    End Sub

    Public Sub CancelUndoSnapshot()
        RaiseEvent OnCancelUndoSnapshot(Me, EventArgs.Empty)
    End Sub

    Public Sub CommitUndoSnapshot(Optional SkipIfNotBeginned As Boolean = False)
        RaiseEvent OnCommitUndoSnapshot(Me, New CommitUndoSnapshotEventArgs(SkipIfNotBeginned))
    End Sub

    Public Sub TakeUndoSnapshot()
        RaiseEvent OnTakeUndoSnapshot(Me, EventArgs.Empty)
    End Sub

    Public Sub DrawInvalidate()
        RaiseEvent OnDrawInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub SurveyInvalidate()
        RaiseEvent OnSurveyInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub MapInvalidate() Implements cIUIInteractions.MapInvalidate
        RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub DoCommand(Command As String, ParamArray Args As Object())
        RaiseEvent OnDoCommand(Me, New DoCommandEventArgs(Command, Args))
    End Sub

    Public Sub ObjectPropertyLoad()
        RaiseEvent OnObjectPropertyLoad(Me, EventArgs.Empty)
    End Sub

    Public Sub PropertyChanged(Name As String) Implements cIUIInteractions.PropertyChanged
        RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
    End Sub

    Public Overridable Sub Rebind(Item As cItem)
        oItem = Item
    End Sub
End Class
