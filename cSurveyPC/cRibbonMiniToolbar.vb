Imports System.ComponentModel
Imports DevExpress.XtraBars.Ribbon

Public Class cRibbonMiniToolbar
    Inherits RibbonMiniToolbar

    Public Sub New(Container As System.ComponentModel.IContainer)
        MyBase.New(Container)
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Location As Point
        Get
            Return MyBase.ShowPoint
        End Get
        Set(value As Point)
            If Not Me.Ribbon.FindForm Is Nothing Then
                MyBase.ShowPoint = Me.Ribbon.FindForm.PointToClient(value)
            End If
        End Set
    End Property

    Public ReadOnly Property Visible() As Boolean
        Get
            If MyBase.Form Is Nothing Then
                Return False
            Else
                Return MyBase.Form.Visible
            End If
        End Get
    End Property

    Public Sub Refresh()
        If Not MyBase.Form Is Nothing Then
            Call MyBase.Form.Refresh()
        End If
    End Sub
End Class
