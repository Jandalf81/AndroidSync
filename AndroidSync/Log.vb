Public Class Log
    Private _logStarted As DateTime
    Private _file As System.IO.StreamWriter

    Private WithEvents _logEntries As New ObjectModel.ObservableCollection(Of LogEntry)

    Public Property LogEntries As ObjectModel.ObservableCollection(Of LogEntry)
        Get
            Return _logEntries
        End Get
        Set(value As ObjectModel.ObservableCollection(Of LogEntry))
            _logEntries = value
        End Set
    End Property


    Public Sub New(logPath As String)
        If (Not My.Computer.FileSystem.DirectoryExists(logPath)) Then
            My.Computer.FileSystem.CreateDirectory(logPath)
        End If

        Me._logStarted = DateTime.Now
        Me._file = My.Computer.FileSystem.OpenTextFileWriter(logPath & "\" & _logStarted.ToString("yyyy-MM-dd_HH-mm-ss") & ".log", True, System.Text.Encoding.UTF8)
    End Sub

    Public Sub Close()
        _file.Close()
        _file.Dispose()
    End Sub

    Private Sub handleNewEntries(sender As Object, e As Specialized.NotifyCollectionChangedEventArgs) Handles _logEntries.CollectionChanged
        If (e.NewItems Is Nothing) Then Exit Sub

        For Each item In e.NewItems
            Dim logEntry = CType(item, LogEntry)

            writeEntryToFile(logEntry)
        Next
    End Sub

    Private Sub writeEntryToFile(logEntry As LogEntry)
        _file.WriteLine(logEntry.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") & "|" & logEntry.Type.ToString() & "|" & logEntry.Message & "|" & logEntry.FromFile & "|" & logEntry.ToFile & "|" & logEntry.FromSize & "|" & logEntry.Tosize & "|" & logEntry.FromRating & "|" & logEntry.ToRating)
    End Sub
End Class
