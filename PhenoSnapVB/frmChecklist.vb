Public Class frmChecklist

    Private Sub Checklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim checklist As String
        checklist = "Have you:" & vbCrLf & "* Selected the camera resolution (1920x1080)" & vbCrLf & _
            "* Checked the camera focus (probably about 118-124)" & vbCrLf & _
            "* Loaded the correct lighting profile from the HP webcam center"
        txtChecklist.Text = checklist
        'Unselect text (not sure why we have to do this but otherwise the text is all selected
        'Set Start position on right side of main form
        Me.Top = frmPhenoSnap.Top + 50
        Me.Left = frmPhenoSnap.Left + frmPhenoSnap.Left / 3
        txtChecklist.SelectionLength = 0
        Application.DoEvents()
        txtChecklist.Refresh()

    End Sub
End Class