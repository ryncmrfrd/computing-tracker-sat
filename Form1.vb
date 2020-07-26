#Disable Warning BC42328
Public Class Form1

    Dim ds As New DataTable()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up ds
        'ds.Columns.Add("TaskName", GetType(String))
        'ds.Columns.Add("TaskName", GetType(String))
        'ds.Columns.Add("TaskName", GetType(String))

        activePanel.AutoScroll = True
        completedPanel.AutoScroll = True

        ' Set colours
        Dim colours As New Colours()
        Label1.ForeColor = colours.VdarkGray
        Me.BackColor = colours.white
        GroupBox1.ForeColor = colours.darkGray
        GroupBox2.ForeColor = colours.darkGray
        addButton.ForeColor = colours.white
        addButton.BackColor = colours.thebestcolour
        addButton.Font = New Font(addButton.Font.FontFamily, 12.5, addButton.Font.Style)
        addButton.FlatStyle = FlatStyle.Flat
        addButton.FlatAppearance.BorderSize = 0

        Dim int = 5
        Dim taskElement As TaskElement = Nothing
        For i As Integer = 0 To int - 1
            taskElement = New TaskElement()
            taskElement.Create(activePanel, completedPanel, "task name " & i & " test", "task text " & i & " test", New Point(10, 5 + 75 * i))
            activePanel.Controls.Add(taskElement.elem)
        Next
        activePanel.Width = taskElement.elem.Width + 50
        Me.Width = activePanel.Width

        ' Load XML

        'Dim xmlFile As XmlReader
        'xmlFile = XmlReader.Create("history.xml", New XmlReaderSettings())

        'Try
        '    ds.ReadXml(xmlFile)
        '    MsgBox(ds.Rows(0).Item(0))
        '    TextBox1.Text = ds.Rows(0).Item(0)
        '    xmlFile.Close()
        '    Return True
        'Catch ex As Exception
        '    xmlFile.Close()
        '    Return False
        'End Try
        MsgBox(GroupBox2.Size.ToString())
    End Sub

End Class

Public Class Colours
    Public Property thebestcolour As Color = System.Drawing.ColorTranslator.FromHtml("#07c")

    Public Property white As Color = System.Drawing.ColorTranslator.FromHtml("#fff")
    Public Property lightGray As Color = System.Drawing.ColorTranslator.FromHtml("#F5F5F5")
    Public Property midGray As Color = System.Drawing.ColorTranslator.FromHtml("#dbdbdb")
    Public Property darkGray As Color = System.Drawing.ColorTranslator.FromHtml("#3d3d3d")
    Public Property VdarkGray As Color = System.Drawing.ColorTranslator.FromHtml("#181818")
    Public Property black As Color = System.Drawing.ColorTranslator.FromHtml("#000")
    Public Property green As Color = System.Drawing.ColorTranslator.FromHtml("#23d160")
    Public Property yellow As Color = System.Drawing.ColorTranslator.FromHtml("#ffdd57")
    Public Property red As Color = System.Drawing.ColorTranslator.FromHtml("#ff3860")
End Class

Public Class TaskElement

    Public Property elem As Panel = Nothing
    Public Property activePanel As Panel = Nothing
    Public Property completedPanel As Panel = Nothing
    Public Property isDeleted As Boolean = False
    Public Property isComplete As Boolean = False

    Public Sub Delete(sender As Object, e As EventArgs)
        Me.isDeleted = True
        Dim senderIndex As Integer = sender.Parent.Parent.Controls.IndexOf(sender.Parent)
        For Each i In sender.Parent.Parent.Controls
            If (sender.Parent.Parent.Controls.IndexOf(i) > senderIndex) Then
                i.Location -= New Point(0, 75)
            End If
        Next
        sender.Parent.Parent.Controls.Remove(sender.Parent)
    End Sub

    Public Sub Undo(sender As Button, e As EventArgs)

        Me.isComplete = False
        Dim colours As New Colours
        completedPanel.Controls.Remove(sender.Parent)
        activePanel.Controls.Add(sender.Parent)

        Dim senderIndex As Integer = sender.Parent.Parent.Controls.IndexOf(sender.Parent)
        For Each i In sender.Parent.Parent.Controls
            If (sender.Parent.Parent.Controls.IndexOf(i) > senderIndex) Then
                i.Location -= New Point(0, 75)
            End If
        Next

        sender.BackColor = colours.green
        sender.Text = "✔"
        sender.Parent.Location = New Point(10, 75 * (activePanel.Controls.Count - 1))

        AddHandler sender.Click, AddressOf Me.Complete
        RemoveHandler sender.Click, AddressOf Me.Undo
    End Sub

    Public Sub Complete(sender As Button, e As EventArgs)
        Me.isComplete = True
        Dim senderIndex As Integer = sender.Parent.Parent.Controls.IndexOf(sender.Parent)
        Dim colours As New Colours
        For Each i In activePanel.Controls
            If (sender.Parent.Parent.Controls.IndexOf(i) > senderIndex) Then
                i.Location -= New Point(0, 75)
            End If
        Next
        activePanel.Controls.Remove(sender.Parent)
        completedPanel.Controls.Add(sender.Parent)

        sender.BackColor = colours.yellow
        sender.Text = "⬅"
        sender.Parent.Location = New Point(10, 5 + 75 * (completedPanel.Controls.Count - 1))

        AddHandler sender.Click, AddressOf Me.Undo
        RemoveHandler sender.Click, AddressOf Me.Complete
    End Sub

    Public Sub Create(activePanelElem As Panel, completedPanelElem As Panel, taskName As String, taskText As String, taskPosition As Point)
        Dim colours As New Colours
        ' Set default values for controls
        Dim defaultWidth = 62
        Dim defaultHeight = 62
        Dim defaultFontSize = 20
        ' Create GroupBox
        Dim taskGroupBox As New Panel
        taskGroupBox.Location = taskPosition
        taskGroupBox.Height = defaultHeight
        taskGroupBox.BackColor = colours.lightGray
        ' Add complete Button to GroupBox
        Dim taskCompleteButton As New Button
        taskCompleteButton.Dock = DockStyle.Left
        taskCompleteButton.Width = defaultWidth
        taskCompleteButton.Height = defaultHeight
        taskCompleteButton.Text = "✔"
        taskCompleteButton.ForeColor = colours.VdarkGray
        taskCompleteButton.BackColor = colours.green
        taskCompleteButton.FlatStyle = FlatStyle.Flat
        taskCompleteButton.FlatAppearance.BorderSize = 0
        taskCompleteButton.Font = New Font(taskCompleteButton.Font.FontFamily, defaultFontSize, taskCompleteButton.Font.Style)
        AddHandler taskCompleteButton.Click, AddressOf Me.Complete
        taskGroupBox.Controls.Add(taskCompleteButton)
        ' Add new TextBox to GroupBox
        Dim taskTextBox As New TextBox
        taskTextBox.Top = ((taskCompleteButton.Height) / 2) - (taskTextBox.Height / 2) + 2.5
        taskTextBox.Left = taskCompleteButton.Location.X + taskCompleteButton.Size.Width + 10
        taskTextBox.Width = defaultWidth * 3
        'taskTextBox.Height = defaultHeight - 2
        taskTextBox.Text = taskText
        taskTextBox.BackColor = colours.lightGray
        taskTextBox.ForeColor = colours.black
        taskTextBox.BorderStyle = BorderStyle.None
        taskGroupBox.Controls.Add(taskTextBox)
        ' Add delete Button to GroupBox
        Dim taskDeleteButton As New Button
        taskDeleteButton.Dock = DockStyle.Right
        taskDeleteButton.Width = defaultWidth
        taskDeleteButton.Height = defaultHeight
        taskDeleteButton.Text = "✖"
        taskDeleteButton.ForeColor = colours.VdarkGray
        taskDeleteButton.BackColor = colours.red
        taskDeleteButton.FlatStyle = FlatStyle.Flat
        taskDeleteButton.FlatAppearance.BorderSize = 0
        taskDeleteButton.Font = New Font(taskDeleteButton.Font.FontFamily, defaultFontSize, taskDeleteButton.Font.Style)
        AddHandler taskDeleteButton.Click, AddressOf Me.Delete
        taskGroupBox.Controls.Add(taskDeleteButton)
        ' Add GroupBox to all controls
        taskGroupBox.Width = taskCompleteButton.Width + taskTextBox.Width + taskDeleteButton.Width + 6 + (10 * 2)
        ' Set elements
        activePanel = activePanelElem
        completedPanel = completedPanelElem
        activePanel.AutoScroll = True
        completedPanel.AutoScroll = True
        elem = taskGroupBox
    End Sub

End Class