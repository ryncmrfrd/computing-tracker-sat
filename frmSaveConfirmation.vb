Public Class frmSaveConfirmation

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Dim taskForm = viewTasksForm
        taskForm.closeConfired = False
        Me.Hide()
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Dim taskForm = viewTasksForm
        taskForm.closeConfired = True
        Me.Hide()
    End Sub

End Class