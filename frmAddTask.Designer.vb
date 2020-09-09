<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddTask
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
        Me.tbxTaskName = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTasks = New System.Windows.Forms.Label()
        Me.lblTaskTitle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbxTaskName
        '
        Me.tbxTaskName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTaskName.Location = New System.Drawing.Point(18, 88)
        Me.tbxTaskName.Margin = New System.Windows.Forms.Padding(1)
        Me.tbxTaskName.Name = "tbxTaskName"
        Me.tbxTaskName.Size = New System.Drawing.Size(374, 29)
        Me.tbxTaskName.TabIndex = 0
        '
        'btnSubmit
        '
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("SF Pro Display", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(18, 125)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(1)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(374, 52)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Add Task"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(366, 18)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(26, 26)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "✕"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblTasks
        '
        Me.lblTasks.AutoSize = True
        Me.lblTasks.Font = New System.Drawing.Font("SF Pro Display", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTasks.ForeColor = System.Drawing.Color.Black
        Me.lblTasks.Location = New System.Drawing.Point(10, 9)
        Me.lblTasks.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTasks.Name = "lblTasks"
        Me.lblTasks.Size = New System.Drawing.Size(173, 44)
        Me.lblTasks.TabIndex = 8
        Me.lblTasks.Text = "Add Task"
        '
        'lblTaskTitle
        '
        Me.lblTaskTitle.AutoSize = True
        Me.lblTaskTitle.Font = New System.Drawing.Font("SF Pro Text", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTaskTitle.Location = New System.Drawing.Point(15, 66)
        Me.lblTaskTitle.Name = "lblTaskTitle"
        Me.lblTaskTitle.Size = New System.Drawing.Size(66, 16)
        Me.lblTaskTitle.TabIndex = 10
        Me.lblTaskTitle.Text = "Task Title"
        '
        'frmAddTask
        '
        Me.AcceptButton = Me.btnSubmit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTaskTitle)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTasks)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.tbxTaskName)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmAddTask"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Task"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbxTaskName As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTasks As Label
    Friend WithEvents lblTaskTitle As Label
End Class
