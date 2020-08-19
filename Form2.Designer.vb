<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class addTaskForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tasknameTextBox = New System.Windows.Forms.TextBox()
        Me.submitButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tasknameTextBox
        '
        Me.tasknameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tasknameTextBox.Location = New System.Drawing.Point(20, 117)
        Me.tasknameTextBox.Name = "tasknameTextBox"
        Me.tasknameTextBox.Size = New System.Drawing.Size(420, 55)
        Me.tasknameTextBox.TabIndex = 0
        '
        'submitButton
        '
        Me.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitButton.Location = New System.Drawing.Point(81, 195)
        Me.submitButton.Name = "submitButton"
        Me.submitButton.Size = New System.Drawing.Size(274, 60)
        Me.submitButton.TabIndex = 2
        Me.submitButton.Text = "Submit"
        Me.submitButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 48)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Add New Task"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 29)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Task Name"
        '
        'addTaskForm
        '
        Me.AcceptButton = Me.submitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 288)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.submitButton)
        Me.Controls.Add(Me.tasknameTextBox)
        Me.Name = "addTaskForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Task"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tasknameTextBox As TextBox
    Friend WithEvents submitButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
