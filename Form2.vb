Public Class addTaskForm
    Inherits System.Windows.Forms.Form

    Public tasksForm As viewTasksForm
    Private colours As New Colours

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.ForeColor = colours.thebestcolour
        Reset()
    End Sub

    Public Sub Reset()
        tasknameTextBox.Text = ""
        submitButton.BackColor = colours.yellow
        submitButton.Enabled = False
    End Sub

    Private Sub submitButton_Click(sender As Object, e As EventArgs) Handles submitButton.Click
        tasksForm.addTask(tasknameTextBox.Text)
    End Sub

    Private Sub tasknameTextBox_TextChanged(sender As Object, e As EventArgs) Handles tasknameTextBox.TextChanged
        If String.IsNullOrEmpty(sender.Text) Then
            submitButton.BackColor = colours.yellow
            submitButton.Enabled = False
        Else
            submitButton.BackColor = colours.green
            submitButton.Enabled = True
        End If
    End Sub

End Class