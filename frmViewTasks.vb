#Disable Warning BC42328

Imports System.IO
Imports System.Xml

Public Class viewTasksForm

    Dim fileLocation As String = Application.StartupPath & "\taskList.xml"

    Public closeForm As New frmSaveConfirmation,
        deleteForm As New deleteConfirmation

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set colours
        Dim colours As New Colours

        Me.BackColor = colours.midgray
        pnlActive.BackColor = colours.lightgray
        pnlCompleted.BackColor = colours.lightgray

        btnAdd.BackColor = colours.blue
        btnAdd.Font = New Font(New FontFamily("SF Pro Text"), 10, btnAdd.Font.Style)

        pnlActiveBackground.BackColor = colours.lightgray
        pnlCompletedBackground.BackColor = colours.lightgray

        ' Read XML data file
        Dim data As New DataSet()
        data = readXML(fileLocation)

        Dim activeTasksList As New List(Of Task),
            completedTasksList As New List(Of Task)

        If data.Tables.Count > 0 Then
            For Each taskData In data.Tables(0).Rows
                Dim taskElement As New Task(taskData.Item(0), Integer.Parse(taskData.Item(3)), pnlActive, pnlCompleted),
                    isCompleted = Boolean.Parse(taskData.Item(1)),
                    isDeleted = Boolean.Parse(taskData.Item(2))

                If Not isCompleted And Not isDeleted Then
                    activeTasksList.Add(taskElement)
                ElseIf isCompleted And Not isDeleted Then
                    completedTasksList.Add(taskElement)
                End If
            Next

            Dim i As Integer = 0
            For Each task In activeTasksList
                task.changePositionIndex(i)
                pnlActive.Controls.Add(task)
                i += 1
            Next

            Dim ii As Integer = 0
            For Each task In completedTasksList
                task.changePositionIndex(ii)
                pnlCompleted.Controls.Add(task)
                task.complete(task.Controls.Find("taskCompleteButton", True)(0), Nothing, False)
                ii += 1
            Next
        End If

        Me.Width = (pnlActiveBackground.Location.X * 2) + Point.Add(pnlActiveBackground.Location, New Size(pnlActiveBackground.Width, pnlActiveBackground.Height)).X

    End Sub

    Public Function readXML(FileLocation As String)
        Dim dataset As New DataSet(),
            response As String = File.ReadAllText(FileLocation)

        dataset.ReadXml(New StringReader(response))

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
            writer.WriteElementString("isCompleted", d.Item(1))
            writer.WriteElementString("isDeleted", d.Item(2))
            writer.WriteElementString("positionIndex", d.Item(3))
            writer.WriteEndElement()
        Next
        writer.WriteEndElement()
        writer.WriteEndDocument()

        writer.Close()
    End Sub

    Private Sub Form1_Closing(Source As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.Closing

        If confirmClose() Then
            Dim ds As New DataSet()

            ds.Tables.Add("tasks")
            ds.Tables(0).Columns.Add("taskName", GetType(String))
            ds.Tables(0).Columns.Add("isCompleted", GetType(Boolean))
            ds.Tables(0).Columns.Add("isDeleted", GetType(Boolean))
            ds.Tables(0).Columns.Add("locationIndex", GetType(Integer))

            For Each task In pnlActive.Controls
                ds.Tables(0).Rows.Add(task.Controls.Find("taskTextBox", True)(0).Text, False, False, pnlActive.Controls.IndexOf(task))
            Next
            For Each task In pnlCompleted.Controls
                ds.Tables(0).Rows.Add(task.Controls.Find("taskTextBox", True)(0).Text, True, False, pnlCompleted.Controls.IndexOf(task))
            Next

            writeXML(ds, fileLocation)
        End If

    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addTaskForm As New frmAddTask

        addTaskForm.tasksForm = Me
        addTaskForm.Reset()
        addTaskForm.ShowDialog()
    End Sub

    ' Called by _addTaskForm
    Public Sub addTask(taskName As String)
        Dim addTaskForm As New frmAddTask
        Dim taskPositionIndex As Integer = pnlActive.Controls.Count,
            newTask As New Task(taskName, taskPositionIndex, pnlActive, pnlCompleted)
        pnlActive.Controls.Add(newTask)
    End Sub

    ' Called by _addTaskForm
    Public deleteConfirmed As Boolean
    Public Function confirmDelete()
        deleteConfirmation.ShowDialog()
        Return deleteConfirmed
    End Function

    ' Called by _closeConfirmationForm
    Public closeConfired As Boolean
    Public Function confirmClose()
        closeForm.ShowDialog()
        Return closeConfired
    End Function

End Class

Public Class Colours

    Public Property white As Color = hexConvert("#FFFFFF")
    Public Property lightgray As Color = hexConvert("#F5F5F5")
    Public Property midgray As Color = hexConvert("#E3E3E3")
    Public Property darkgray As Color = hexConvert("#B6B6B6")
    Public Property darkestgray As Color = hexConvert("#8C8C8C")
    Public Property black As Color = hexConvert("#000000")
    Public Property blue As Color = hexConvert("#0077CC")
    Public Property green As Color = hexConvert("#23D160")
    Public Property yellow As Color = hexConvert("#FFDD57")

    Public Function hexConvert(hex)
        Return ColorTranslator.FromHtml(hex)
    End Function

End Class

Public Class Task
    Inherits Panel

    Dim colours As New Colours

    Public Property defaultWidth As Integer = 62
    Public Property defaultHeight As Integer = 62
    Public Property defaultFontsize As Integer = 20

    Public Property isDeleted As Boolean = False
    Public Property isComplete As Boolean = False

    Public Property completedPanel As Panel = Nothing
    Public Property activePanel As Panel = Nothing

    Public Property positionIndex As Integer = 0


    Public Sub New(taskText As String, taskPositionIndex As Integer, activePanelElem As Panel, completedPanelElem As Panel)

        ' Add Complete Button
        Dim taskCompleteButton As New Button
        taskCompleteButton.Name = "taskCompleteButton"
        taskCompleteButton.Dock = DockStyle.Left
        taskCompleteButton.Width = defaultWidth
        taskCompleteButton.Height = defaultHeight
        taskCompleteButton.Text = "✔"
        taskCompleteButton.ForeColor = colours.white
        taskCompleteButton.BackColor = colours.green
        taskCompleteButton.FlatStyle = FlatStyle.Flat
        taskCompleteButton.FlatAppearance.BorderSize = 0
        taskCompleteButton.Font = New Font(taskCompleteButton.Font.FontFamily, defaultFontsize, taskCompleteButton.Font.Style)
        AddHandler taskCompleteButton.Click, AddressOf Me.complete

        ' Add TextBox
        Dim taskTextBox As New TextBox
        taskTextBox.Name = "taskTextBox"
        taskTextBox.Width = (defaultWidth * 3) + 6 + (10 * 2)
        taskTextBox.Height = defaultHeight - 2
        taskTextBox.Top = ((taskCompleteButton.Height) / 2) - (taskTextBox.Height / 2)
        taskTextBox.Left = taskCompleteButton.Location.X + taskCompleteButton.Size.Width + 10
        taskTextBox.Text = taskText
        taskTextBox.ForeColor = colours.black
        taskTextBox.BorderStyle = BorderStyle.None
        taskTextBox.Font = New Font(New FontFamily("SF Pro Text"), defaultFontsize - 7, taskTextBox.Font.Style)

        ' Add Delete Button
        Dim taskDeleteButton As New Button
        taskDeleteButton.Name = "taskDeleteButton"
        taskDeleteButton.Location = New Point(0, defaultWidth / 4)
        taskDeleteButton.Width = defaultWidth / 2
        taskDeleteButton.Height = defaultHeight / 2
        taskDeleteButton.Text = "✖"
        taskDeleteButton.ForeColor = colours.white
        taskDeleteButton.BackColor = colours.darkestgray
        taskDeleteButton.FlatStyle = FlatStyle.Flat
        taskDeleteButton.FlatAppearance.BorderSize = 0
        taskDeleteButton.Font = New Font(taskDeleteButton.Font.FontFamily, defaultFontsize - 10, taskDeleteButton.Font.Style)
        AddHandler taskDeleteButton.Click, AddressOf Me.delete

        ' Add Delete Button Padding Object
        Dim taskDeleteButtonPadding As New Panel
        taskDeleteButtonPadding.Dock = DockStyle.Right
        taskDeleteButtonPadding.Width = defaultWidth - (defaultWidth / 4)
        taskDeleteButtonPadding.Height = defaultHeight
        taskDeleteButtonPadding.Controls.Add(taskDeleteButton)

        ' Set GroupBox Properties + Add Elements
        Me.BackColor = colours.white
        Me.Height = defaultHeight
        Me.Width = taskCompleteButton.Width + taskTextBox.Width + (taskDeleteButton.Width * 2)
        Me.Controls.Add(taskDeleteButtonPadding)
        Me.Controls.Add(taskTextBox)
        Me.Controls.Add(taskCompleteButton)
        changePositionIndex(taskPositionIndex)

        ' Set Class Properties
        activePanel = activePanelElem
        completedPanel = completedPanelElem
    End Sub

    Public Function changePositionIndex(newIndex As Integer)
        Dim Location As New Point(10, 75 * newIndex)
        Me.Location = validateTaskLocation(Location, newIndex)
        positionIndex = newIndex
        Return newIndex
    End Function

    Public Function validateTaskLocation(location As Point, positionIndex As Integer)
        Dim newLocation As Point = location
        If Not (location.Y / positionIndex = 75) Then
            newLocation.Y = positionIndex * 75
        End If
        If Not location.X = 10 Then
            newLocation.X = 10
        End If
        Return newLocation
    End Function

    Public Function complete(sender As Button, e As EventArgs, Optional changePosition As Boolean = True)
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

        If changePosition Then
            changePositionIndex(completedPanel.Controls.Count)
        End If
        sender.BackColor = colours.yellow
        sender.Text = "⬅"

        activePanel.Controls.Remove(sender.Parent)
        completedPanel.Controls.Add(sender.Parent)

        Return True
    End Function

    Public Function delete(sender As Button, e As EventArgs)

        Dim confirmed As Boolean = True

        If Not Me.isComplete Then
            confirmed = viewTasksForm.confirmDelete()
        End If

        If confirmed And Not isDeleted Then
            isDeleted = True
            For Each i In Me.Parent.Controls
                If i.positionIndex > Me.positionIndex Then
                    i.changePositionIndex(i.positionIndex - 1)
                End If
            Next
            sender.Parent.Parent.Parent.Controls.Remove(sender.Parent.Parent)
            Return True
        Else
            Return False
        End If

        confirmed = True
    End Function

    Public Function undo(sender As Button, e As EventArgs)
        Me.isComplete = False

        For Each i In Me.Parent.Controls
            If i.positionIndex > Me.positionIndex Then
                i.changePositionIndex(i.positionIndex - 1)
            End If
        Next

        Me.changePositionIndex(activePanel.Controls.Count)
        sender.BackColor = colours.green
        sender.Text = "✔"

        completedPanel.Controls.Remove(sender.Parent)
        activePanel.Controls.Add(sender.Parent)

        Return True
    End Function

End Class