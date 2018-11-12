Imports cSurveyPC.cSurvey

Public Class frmGrades
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Friend Event OnApply(ByVal Sender As frmGrades)

    Private Class cGradePlaceHolder
        Public ID As String
        Public Description As String

        Public DistanceEnabled As Boolean
        Public BearingEnabled As Boolean
        Public InclinationEnabled As Boolean

        Public Distance As Single
        Public Bearing As Single
        Public Inclination As Single

        Public BearingType As cSegment.BearingTypeEnum
        Public DistanceType As cSegment.DistanceTypeEnum
        Public InclinationType As cSegment.InclinationTypeEnum

        Public Created As Boolean
        Public Deleted As Boolean
    End Class

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey

        Call pload()
    End Sub

    Private Sub pLoad()
        Call pSetEnabled(False)
        Call tvGrades.Nodes.Clear()

        For Each oGrade As cGrade In oSurvey.Grades
            Dim oGP As cGradePlaceHolder = New cGradePlaceHolder
            With oGP
                .ID = oGrade.ID
                .Description = oGrade.Description

                .DistanceEnabled = oGrade.DistanceEnabled
                .BearingEnabled = oGrade.BearingEnabled
                .InclinationEnabled = oGrade.InclinationEnabled

                .Distance = oGrade.Distance
                .Bearing = oGrade.Bearing
                .Inclination = oGrade.Inclination

                .DistanceType = oGrade.DistanceType
                .BearingType = oGrade.BearingType
                .InclinationType = oGrade.InclinationType
            End With

            Dim sDescription As String = oGP.Description
            Dim oNode As TreeNode = tvGrades.Nodes.Add(oGP.ID, sDescription)
            oNode.ImageKey = "grade"
            oNode.SelectedImageKey = "grade"
            oNode.Tag = oGP
        Next

        If tvGrades.Nodes.Count > 0 Then
            tvGrades.SelectedNode = tvGrades.Nodes(0)
        End If
    End Sub

    Private Sub btnSessionsAddSession_Click(sender As System.Object, e As System.EventArgs) Handles btnAddSet.Click
        Dim oGP As cGradePlaceHolder = New cGradePlaceHolder
        With oGP
            .Created = True
        End With
        Dim sDescription As String = oGP.Description
        Dim oNode As TreeNode = tvGrades.Nodes.Add(oGP.ID, sDescription)
        oNode.ImageKey = "grade"
        oNode.SelectedImageKey = "grade"
        oNode.Tag = oGP
        tvGrades.SelectedNode = oNode
    End Sub

    Private Sub btnSessionsDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim oNode As TreeNode = tvGrades.SelectedNode
        If Not oNode Is Nothing Then
            If MsgBox(GetLocalizedString("grades.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("grades.warningtitle")) = MsgBoxResult.Yes Then
                Dim oGP As cGradePlaceHolder = oNode.Tag
                If oGP.Created Then
                    Call tvGrades.Nodes.Remove(oNode)
                Else
                    oGP.Deleted = True
                    oNode.ImageKey = "deleted"
                    oNode.SelectedImageKey = "deleted"
                End If

                oNode = tvGrades.SelectedNode
                If oNode Is Nothing Then
                    Call pSetEnabled(False)
                Else
                    Call pSetEnabled(True)
                End If
            End If
        End If
    End Sub

    Private Sub tvGrades_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvGrades.AfterSelect
        Dim oNode As TreeNode = tvGrades.SelectedNode
        If oNode Is Nothing Then
            Call pSetEnabled(False)
        Else
            Dim oGP As cGradePlaceHolder = oNode.Tag
            With oGP
                txtID.Text = .ID
                txtDescription.Text = .Description

                chkDistance.Checked = .DistanceEnabled
                chkBearing.Checked = .BearingEnabled
                chkInclination.Checked = .InclinationEnabled

                txtDistance.Value = .Distance
                txtBearing.Value = .Bearing
                txtInclination.Value = .Inclination

                cboDistanceType.SelectedIndex = .DistanceType
                cboBearingType.SelectedIndex = .BearingType
                cboInclinationType.SelectedIndex = .InclinationType
            End With
            Call pSetEnabled(True)
        End If
    End Sub

    Private Sub pSetEnabled(Enabled As Boolean)
        lblID.Enabled = Enabled
        txtID.Enabled = Enabled
        lblDescription.Enabled = Enabled
        txtDescription.Enabled = Enabled
        tabGrade.Enabled = Enabled

        btnDelete.Enabled = Enabled
        btnDeleteAll.Enabled = tvGrades.Nodes.Count > 0
    End Sub

    Private Sub tvGrades_BeforeSelect(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvGrades.BeforeSelect
        Dim oNode As TreeNode = tvGrades.SelectedNode
        If Not oNode Is Nothing Then
            Dim oGP As cGradePlaceHolder = oNode.Tag
            With oGP
                .Description = txtDescription.Text
                oNode.Text = .Description

                .DistanceEnabled = chkDistance.Checked
                .BearingEnabled = chkBearing.Checked
                .InclinationEnabled = chkInclination.Checked

                .Distance = txtDistance.Value
                .Bearing = txtBearing.Value
                .Inclination = txtInclination.Value

                .DistanceType = cboDistanceType.SelectedIndex
                .BearingType = cboBearingType.SelectedIndex
                .InclinationType = cboInclinationType.SelectedIndex
            End With
        End If
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call tvGrades_BeforeSelect(Nothing, Nothing)
        Call pSave()
        DialogResult = Windows.Forms.DialogResult.OK
        Call Close()
    End Sub

    Private Sub pSave()
        For Each oNode As TreeNode In tvGrades.Nodes
            Dim oGP As cGradePlaceHolder = oNode.Tag
            With oGP
                If .Deleted Then
                    Call oSurvey.Grades.Remove(.ID)
                Else
                    If .Created Then
                        Dim oGrade As cGrade = oSurvey.Grades.Add()
                        .ID = oGrade.ID
                        oGrade.Description = .Description

                        oGrade.DistanceEnabled = .DistanceEnabled
                        oGrade.BearingEnabled = .BearingEnabled
                        oGrade.InclinationEnabled = .InclinationEnabled

                        oGrade.Distance = .Distance
                        oGrade.Bearing = .Bearing
                        oGrade.Inclination = .Inclination

                        oGrade.DistanceType = .DistanceType
                        oGrade.BearingType = .BearingType
                        oGrade.InclinationType = .InclinationType

                        .Created = False
                    Else
                        Dim oGrade As cGrade = oSurvey.Grades(.ID)
                        oGrade.Description = .Description

                        oGrade.DistanceEnabled = .DistanceEnabled
                        oGrade.BearingEnabled = .BearingEnabled
                        oGrade.InclinationEnabled = .InclinationEnabled

                        oGrade.Distance = .Distance
                        oGrade.Bearing = .Bearing
                        oGrade.Inclination = .Inclination

                        oGrade.DistanceType = .DistanceType
                        oGrade.BearingType = .BearingType
                        oGrade.InclinationType = .InclinationType
                    End If
                End If
            End With
        Next
    End Sub

    Private Sub chkDistance_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDistance.CheckedChanged
        Dim bEnabled As Boolean = chkDistance.Checked
        txtDistance.Enabled = benabled
        cboDistanceType.Enabled = benabled
    End Sub

    Private Sub chkBearing_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBearing.CheckedChanged
        Dim bEnabled As Boolean = chkBearing.Checked
        txtBearing.Enabled = bEnabled
        cboBearingType.Enabled = bEnabled
    End Sub

    Private Sub chkInclination_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkInclination.CheckedChanged
        Dim bEnabled As Boolean = chkInclination.Checked
        txtInclination.Enabled = bEnabled
        cboInclinationType.Enabled = bEnabled
    End Sub

    Private Sub btnDeleteAll_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteAll.Click
        If MsgBox(GetLocalizedString("grades.warning2"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("grades.warningtitle")) = MsgBoxResult.Yes Then
            Dim oNode As TreeNode
            For Each oNode In tvGrades.Nodes
                Dim oGP As cGradePlaceHolder = oNode.Tag
                If oGP.Created Then
                    Call tvGrades.Nodes.Remove(oNode)
                Else
                    oGP.Deleted = True
                    oNode.ImageKey = "deleted"
                    oNode.SelectedImageKey = "deleted"
                End If
            Next
            oNode = tvGrades.SelectedNode
            If oNode Is Nothing Then
                Call pSetEnabled(False)
            Else
                Call pSetEnabled(True)
            End If
        End If
    End Sub

    Private Sub cmdApply_Click(sender As System.Object, e As System.EventArgs) Handles cmdApply.Click
        Call tvGrades_BeforeSelect(Nothing, Nothing)
        Call pSave()
        RaiseEvent OnApply(Me)
        Call pLoad()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Call Close()
    End Sub
End Class