#Disable Warning BC42328

Imports System.IO
Imports System.Xml

Public Class Form1

    Dim ds As New DataTable()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Application.ApplicationExit, AddressOf Form1_ApplicationExit

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

        ' Read XML data file
        Dim fileLocation As String = Application.StartupPath & "\taskList.xml", data As New DataSet()

        'data.Tables.Add()
        'data.Tables(0).Columns.Add("taskName", GetType(String))
        'data.Tables(0).Columns.Add("isCompleted", GetType(Boolean))
        'data.Tables(0).Columns.Add("isDeleted", GetType(Boolean))
        'data.Tables(0).Columns.Add("locationIndex", GetType(Integer))

        data = readXML(fileLocation)

        '' Write new data
        'writeXML(data, fileLocation)

        For Each i In data.Tables(0).Rows
            Dim taskElement As New Task(i.Item(0), Integer.Parse(i.Item(1)), Boolean.Parse(i.Item(2)), Boolean.Parse(i.Item(3)), activePanel, completedPanel)
            If Not taskElement.isComplete Then
                activePanel.Controls.Add(taskElement)
            ElseIf taskElement.isComplete Then
                completedPanel.Controls.Add(taskElement)
            End If
        Next

        Me.Width = activePanel.Width = 385
    End Sub

    Public Function readXML(FileLocation As String)
        Dim dataset As New DataSet(),
            datatable As DataTable,
            response As String = File.ReadAllText(FileLocation)

        dataset.ReadXml(New StringReader(response))
        datatable = dataset.Tables(0)

        Return dataset
    End Function

    Public Sub writeXML(Data As DataSet, FileLocation As String)

        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        settings.IndentChars = "    "

        Dim writer As XmlWriter = XmlWriter.Create(FileLocation, settings)

        writer.WriteStartDocument()
        writer.WriteStartElement("tasks")
        Dim tasksTable = Data.Tables(0)
        For Each d In tasksTable.Rows
            writer.WriteStartElement("task")
            writer.WriteElementString("taskText", d.Item(0))
            writer.WriteElementString("isDeleted", d.Item(1))
            writer.WriteElementString("isCompleted", d.Item(2))
            writer.WriteElementString("positionIndex", d.Item(3))
            writer.WriteEndElement()
        Next
        writer.WriteEndElement()
        writer.WriteEndDocument()

        writer.Close()
    End Sub

    Private Sub Form1_ApplicationExit()
        '' Add 4 tasks to data
        'Data.Tables(0).Rows.Add("task 0", False, False, 0)
        'Data.Tables(0).Rows.Add("task 1", False, False, 1)
        'Data.Tables(0).Rows.Add("task 2", False, False, 2)
        'Data.Tables(0).Rows.Add("task 3", False, False, 3)
        'Data.Tables(0).Rows.Add("task 4", False, False, 3)
        'Data.Tables(0).Rows.Add("task 5", False, False, 3)
    End Sub

End Class

Public Class Colours
    Public Property thebestcolour As Color = ColorTranslator.FromHtml("#0077cc")
    Public Property white As Color = ColorTranslator.FromHtml("#ffffff")
    Public Property lightGray As Color = ColorTranslator.FromHtml("#f5f5f5")
    Public Property midGray As Color = ColorTranslator.FromHtml("#dbdbdb")
    Public Property darkGray As Color = ColorTranslator.FromHtml("#3d3d3d")
    Public Property VdarkGray As Color = ColorTranslator.FromHtml("#181818")
    Public Property black As Color = ColorTranslator.FromHtml("#000000")
    Public Property green As Color = ColorTranslator.FromHtml("#23d160")
    Public Property yellow As Color = ColorTranslator.FromHtml("#ffdd57")
    Public Property red As Color = ColorTranslator.FromHtml("#ff3860")
End Class

Public Class Task
    Inherits Panel

    Public Property defaultWidth As Integer = 62
    Public Property defaultHeight As Integer = 62
    Public Property defaultFontsize As Integer = 20

    Public Property isDeleted As Boolean = Nothing
    Public Property isComplete As Boolean = Nothing

    Public Property completedPanel As Panel = Nothing
    Public Property activePanel As Panel = Nothing

    Public Property positionIndex As Integer = 0

    Public Property colours As New Colours

    Public Sub New(taskText As String, taskPositionIndex As Integer, isCompleteBool As Boolean, isDeletedBool As Boolean, activePanelElem As Panel, completedPanelElem As Panel)

        ' Add Complete Button
        Dim taskCompleteButton As New Button
        taskCompleteButton.Dock = DockStyle.Left
        taskCompleteButton.Width = defaultWidth
        taskCompleteButton.Height = defaultHeight
        taskCompleteButton.Text = "✔"
        taskCompleteButton.ForeColor = colours.VdarkGray
        taskCompleteButton.BackColor = colours.green
        taskCompleteButton.FlatStyle = FlatStyle.Flat
        taskCompleteButton.FlatAppearance.BorderSize = 0
        taskCompleteButton.Font = New Font(taskCompleteButton.Font.FontFamily, defaultFontsize, taskCompleteButton.Font.Style)
        AddHandler taskCompleteButton.Click, AddressOf Me.complete

        ' Add TextBox
        Dim taskTextBox As New TextBox
        taskTextBox.Top = ((taskCompleteButton.Height) / 2) - (taskTextBox.Height / 2) + 2.5
        taskTextBox.Left = taskCompleteButton.Location.X + taskCompleteButton.Size.Width + 10
        taskTextBox.Width = defaultWidth * 3
        taskTextBox.Height = defaultHeight - 2
        taskTextBox.Text = taskText
        taskTextBox.BackColor = colours.lightGray
        taskTextBox.ForeColor = colours.black
        taskTextBox.BorderStyle = BorderStyle.None

        ' Add Delete Button
        Dim taskDeleteButton As New Button
        taskDeleteButton.Dock = DockStyle.Right
        taskDeleteButton.Width = defaultWidth
        taskDeleteButton.Height = defaultHeight
        taskDeleteButton.Text = "✖"
        taskDeleteButton.ForeColor = colours.VdarkGray
        taskDeleteButton.BackColor = colours.red
        taskDeleteButton.FlatStyle = FlatStyle.Flat
        taskDeleteButton.FlatAppearance.BorderSize = 0
        taskDeleteButton.Font = New Font(taskDeleteButton.Font.FontFamily, defaultFontsize, taskDeleteButton.Font.Style)
        AddHandler taskDeleteButton.Click, AddressOf Me.delete

        ' Set GroupBox Properties + Add Elements
        Me.BackColor = colours.lightGray
        Me.Height = defaultHeight
        Me.Width = taskCompleteButton.Width + taskTextBox.Width + taskDeleteButton.Width + 6 + (10 * 2)
        Me.Controls.Add(taskDeleteButton)
        Me.Controls.Add(taskTextBox)
        Me.Controls.Add(taskCompleteButton)
        changePositionIndex(taskPositionIndex)

        ' Set Class Properties
        activePanel = activePanelElem
        completedPanel = completedPanelElem
        isComplete = isCompleteBool
        isDeleted = isDeletedBool
    End Sub

    Public Function changePositionIndex(newIndex As Integer)
        Me.Location = New Point(10, 75 * newIndex)
        positionIndex = newIndex
        Return newIndex
    End Function

    Public Function complete(sender As Button, e As EventArgs)
        If isComplete Then
            Me.undo(sender, e)
            Return True
        End If

        isComplete = True
        For Each i In Me.Parent.Controls
            If i.positionIndex > Me.positionIndex Then
                i.changePositionIndex(i.positionIndex - 1)
            End If
        Next

        changePositionIndex(completedPanel.Controls.Count)
        sender.BackColor = colours.yellow
        sender.Text = "⬅"

        activePanel.Controls.Remove(sender.Parent)
        completedPanel.Controls.Add(sender.Parent)

        Return True
    End Function

    Public Function delete(sender As Object, e As EventArgs)
        Dim confirmed = MsgBox("Are you sure you want to delete this task?" & vbCrLf & "This action CANNOT BE UNDONE.", vbYesNo)

        If confirmed = vbYes And Not isDeleted Then
            isDeleted = True
            For Each i In Me.Parent.Controls
                If i.positionIndex > Me.positionIndex Then
                    i.changePositionIndex(i.positionIndex - 1)
                End If
            Next
            sender.Parent.Parent.Controls.Remove(sender.Parent)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function undo(sender As Button, e As EventArgs)
        Me.isComplete = False

        For Each i In Me.Parent.Controls
            If i.positionIndex > Me.positionIndex Then
                i.changePositionIndex(i.positionIndex - 1)
            End If
        Next

        MsgBox(activePanel.Controls.Count)
        Me.changePositionIndex(activePanel.Controls.Count)
        sender.BackColor = colours.green
        sender.Text = "✔"

        completedPanel.Controls.Remove(sender.Parent)
        activePanel.Controls.Add(sender.Parent)

        Return True
    End Function

End Class