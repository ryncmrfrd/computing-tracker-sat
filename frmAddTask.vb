Public Class frmAddTask
    Inherits Form

    Public tasksForm As viewTasksForm

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim colours As New Colours

        ' Set colours
        btnClose.BackColor = colours.blue
        btnSubmit.ForeColor = colours.white
        btnSubmit.BackColor = colours.darkestgray

        Reset()
    End Sub

    Public Sub Reset()
        tbxTaskName.Text = ""
        btnSubmit.Enabled = False
    End Sub

    Private Sub submitButton_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        tasksForm.addTask(tbxTaskName.Text)
        Me.Hide()
    End Sub

    Private Sub tasknameTextBox_TextChanged(sender As Object, e As EventArgs) Handles tbxTaskName.TextChanged
        Dim colours As New Colours

        If String.IsNullOrEmpty(sender.Text) Then
            btnSubmit.BackColor = colours.darkestgray
            btnSubmit.Enabled = False
        Else
            btnSubmit.BackColor = colours.green
            btnSubmit.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

End Class