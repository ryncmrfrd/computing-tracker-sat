<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewTasksForm
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlActive = New System.Windows.Forms.Panel()
        Me.lblTasks = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlCompleted = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblActiveTasks = New System.Windows.Forms.Label()
        Me.lblCompletedTasks = New System.Windows.Forms.Label()
        Me.pnlActiveBackground = New System.Windows.Forms.Panel()
        Me.pnlCompletedBackground = New System.Windows.Forms.Panel()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActiveBackground.SuspendLayout()
        Me.pnlCompletedBackground.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlActive
        '
        Me.pnlActive.AutoScroll = True
        Me.pnlActive.BackColor = System.Drawing.SystemColors.Control
        Me.pnlActive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlActive.Location = New System.Drawing.Point(0, 10)
        Me.pnlActive.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlActive.Name = "pnlActive"
        Me.pnlActive.Size = New System.Drawing.Size(374, 288)
        Me.pnlActive.TabIndex = 0
        '
        'lblTasks
        '
        Me.lblTasks.AutoSize = True
        Me.lblTasks.Font = New System.Drawing.Font("SF Pro Display", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTasks.ForeColor = System.Drawing.Color.Black
        Me.lblTasks.Location = New System.Drawing.Point(10, 9)
        Me.lblTasks.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTasks.Name = "lblTasks"
        Me.lblTasks.Size = New System.Drawing.Size(193, 44)
        Me.lblTasks.TabIndex = 1
        Me.lblTasks.Text = "Tasks App"
        '
        'pnlCompleted
        '
        Me.pnlCompleted.AutoScroll = True
        Me.pnlCompleted.Location = New System.Drawing.Point(0, 10)
        Me.pnlCompleted.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCompleted.Name = "pnlCompleted"
        Me.pnlCompleted.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.pnlCompleted.Size = New System.Drawing.Size(374, 288)
        Me.pnlCompleted.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(325, 22)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(67, 26)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "+ Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lblActiveTasks
        '
        Me.lblActiveTasks.AutoSize = True
        Me.lblActiveTasks.Font = New System.Drawing.Font("SF Pro Text", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveTasks.ForeColor = System.Drawing.Color.Black
        Me.lblActiveTasks.Location = New System.Drawing.Point(15, 66)
        Me.lblActiveTasks.Name = "lblActiveTasks"
        Me.lblActiveTasks.Size = New System.Drawing.Size(85, 16)
        Me.lblActiveTasks.TabIndex = 8
        Me.lblActiveTasks.Text = "Active Tasks"
        '
        'lblCompletedTasks
        '
        Me.lblCompletedTasks.AutoSize = True
        Me.lblCompletedTasks.Font = New System.Drawing.Font("SF Pro Text", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletedTasks.ForeColor = System.Drawing.Color.Black
        Me.lblCompletedTasks.Location = New System.Drawing.Point(15, 399)
        Me.lblCompletedTasks.Name = "lblCompletedTasks"
        Me.lblCompletedTasks.Size = New System.Drawing.Size(113, 16)
        Me.lblCompletedTasks.TabIndex = 9
        Me.lblCompletedTasks.Text = "Completed Tasks"
        '
        'pnlActiveBackground
        '
        Me.pnlActiveBackground.Controls.Add(Me.pnlActive)
        Me.pnlActiveBackground.Location = New System.Drawing.Point(18, 88)
        Me.pnlActiveBackground.Name = "pnlActiveBackground"
        Me.pnlActiveBackground.Size = New System.Drawing.Size(374, 308)
        Me.pnlActiveBackground.TabIndex = 10
        '
        'pnlCompletedBackground
        '
        Me.pnlCompletedBackground.Controls.Add(Me.pnlCompleted)
        Me.pnlCompletedBackground.Location = New System.Drawing.Point(18, 418)
        Me.pnlCompletedBackground.Name = "pnlCompletedBackground"
        Me.pnlCompletedBackground.Size = New System.Drawing.Size(374, 308)
        Me.pnlCompletedBackground.TabIndex = 11
        '
        'viewTasksForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(412, 745)
        Me.Controls.Add(Me.pnlCompletedBackground)
        Me.Controls.Add(Me.pnlActiveBackground)
        Me.Controls.Add(Me.lblCompletedTasks)
        Me.Controls.Add(Me.lblActiveTasks)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblTasks)
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "viewTasksForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Tasks"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActiveBackground.ResumeLayout(False)
        Me.pnlCompletedBackground.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlActive As Panel
    Friend WithEvents lblTasks As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlCompleted As Panel
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblActiveTasks As Label
    Friend WithEvents lblCompletedTasks As Label
    Friend WithEvents pnlActiveBackground As Panel
    Friend WithEvents pnlCompletedBackground As Panel
End Class
