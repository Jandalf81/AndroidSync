Imports SharpAdbClient

Public Class AndroidDevice
    Inherits SharpAdbClient.DeviceData

    ' Public Property Serial As String
    ' Public Property State As DeviceState
    ' Public Property Model As String
    ' Public Property Product As String
    ' Public Property Name As String
    ' Public Property Features As String
    ' Public Property Usb As String
    ' Public Property TransportId As String
    ' Public Property Message As String

    Public ADBclient As New AdbClient()

    Private _capacity As Single
    Public ReadOnly Property Capacity As Single
        Get
            Return _capacity
        End Get
    End Property

    Private _capacityUsed As Single
    Public ReadOnly Property CapacityUsed As Single
        Get
            Return _capacityUsed
        End Get
    End Property

    Private _capacityFree As Single
    Public ReadOnly Property CapacityFree As Single
        Get
            Return _capacityFree
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub New(
        Serial As String,
        State As SharpAdbClient.DeviceState,
        Model As String,
        Product As String,
        Name As String,
        Features As String,
        Usb As String,
        TransportId As String
    )
        Me.Serial = Serial
        Me.State = State
        Me.Model = Model
        Me.Product = Product
        Me.Name = Name
        Me.Features = Features
        Me.Usb = Usb
        Me.TransportId = TransportId
    End Sub

    Public Sub refreshCapacity()
        Dim output As String = Me.executeCommand("df -k /data")

        Dim lines As String() = output.Split(vbLf)
        lines(1) = System.Text.RegularExpressions.Regex.Replace(lines(1), "\s+", "|")
        Dim fields As String() = lines(1).Split("|")

        _capacity = fields(1)
        _capacityUsed = fields(2)
        _capacityFree = fields(3)
    End Sub

    Public Function executeCommand(command As String) As String
        Dim receiver As New ConsoleOutputReceiver()

        ADBclient.ExecuteRemoteCommand(command, Me, receiver, System.Text.Encoding.UTF8)
        Return receiver.ToString()
    End Function

    Public Function getSubdirectories(path As String) As List(Of String)
        Dim output As String = executeCommand("ls -L1p """ & path & """")
        Dim retval As New List(Of String)

        Dim lines() As String = output.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        For Each line In lines
            If (line.EndsWith("/")) Then
                retval.Add(line.Replace("/", ""))
            End If
        Next

        Return retval
    End Function

    Public Function getTracks(path As String) As Playlist
        Dim retval As New Playlist()
        Dim fields() As String
        Dim findReturnsSize As Boolean = True

        Dim output As String = executeCommand("find """ & path & "/"" -type f -iname *.mp3 -printf ""%p|%s\n""")

        If (output = "find: bad arg '-printf'" & vbCrLf) Then
            output = executeCommand("find """ & path & "/"" -type f -iname *.mp3")
            findReturnsSize = False
        End If

        Dim lines() As String = output.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        ' ToDo: read text file for files with too long original path
        If (findReturnsSize = True) Then
            For Each line In lines
                fields = line.Split({"|"}, StringSplitOptions.RemoveEmptyEntries)

                retval.Tracks.Add(New Track(PathRemote:=fields(0), SizeRemote:=fields(1)))
            Next
        Else
            For Each line In lines
                retval.Tracks.Add(New Track(PathRemote:=line, SizeRemote:=0))
            Next
        End If

        Return retval
    End Function

    Public Function getRatings() As Playlist
        Dim retVal As New Playlist()
        Dim output As String
        Dim lines() As String

        Dim _id As Integer
        Dim path As String
        Dim name As String
        Dim rating As Integer

        Dim tmp As String

        output = executeCommand("content query --uri content://com.maxmpz.audioplayer.data/files --projection folder_files._id:folders.path:folder_files.name:folder_files.rating")
        lines = output.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        For Each line In lines
            Dim newTrack As New Track()

            _id = CInt(System.Text.RegularExpressions.Regex.Match(line, "_id=(?'_id'\d*?), path=", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Groups("_id").Value)
            path = System.Text.RegularExpressions.Regex.Match(line, ", path=(?'path'.*?), name=", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Groups("path").Value
            name = System.Text.RegularExpressions.Regex.Match(line, ", name=(?'name'.*?), rating=", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Groups("name").Value
            rating = CInt(System.Text.RegularExpressions.Regex.Match(line, ", rating=(?'rating'\d)$", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Groups("rating").Value)

            newTrack.PathRemote = path + name
            newTrack.RatingRemote = rating

            retVal.Tracks.Add(newTrack)
        Next

        Return retVal
    End Function

    Public Function getFilesInPath(path As String, filename As String) As List(Of String)
        Dim retval As New List(Of String)

        Dim output As String = executeCommand("find """ & path & "/"" -type f -iname """ & filename & """ -maxdepth 1")
        retval = output.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList

        Return retval
    End Function

    Public Function getDirsInPath(path As String) As List(Of String)
        Dim retval As New List(Of String)

        Dim output As String = executeCommand("find """ & path & "/"" -type d -maxdepth 1")
        retval = output.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList

        Return retval
    End Function

    Public Function fileExists(fullpath As String) As Boolean
        Try
            ' TODO make this work with german umlauts or Unicode
            Dim retval As String = executeCommand("[ -f """ & fullpath & """ ] && echo ""1"" || echo ""0""") '.Replace(vbCrLf, "")
            Return retval
        Catch ex As System.InvalidCastException
            Return False
        End Try
    End Function

    Public Sub upload(fromFile As String, toFile As String)
        Dim syncService As New SyncService(Me)
        Dim stream = System.IO.File.OpenRead(fromFile)

        Try
            syncService.Push(stream, toFile, 744, DateTime.Now, Nothing, Threading.CancellationToken.None)
        Catch ex As Exception
            MsgBox("Dateiname zu lang!" & vbCrLf & toFile, MsgBoxStyle.OkOnly)

            ' upload file with short name
            Dim fileinfo As New IO.FileInfo(fromFile)
            Dim originalFilename As String = fileinfo.Name
            Dim originalExtension As String = fileinfo.Extension

            Dim toPath As String = My.Computer.FileSystem.GetParentPath(toFile)
            toPath = toPath.Replace("\", "/")

            upload(fromFile, toPath & "/FilenameTooLong.mp3")

            ' ToDo: implement check for other FilenameTooLong_xxxx.txt in directory

            ' create text file containing full (too long) file name
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\tmp\FilenameTooLong.txt", False, System.Text.Encoding.GetEncoding("iso-8859-1"))
            file.Write(toFile)
            file.Close()
            upload(My.Application.Info.DirectoryPath & "\tmp\FilenameTooLong.txt", toPath & "/FilenameTooLong.txt")
        End Try

        stream.Close()
        syncService.Dispose()
    End Sub

    Public Sub download(fromFile As String, toFile As String)
        Dim syncService As New SyncService(Me)
        Dim stream = System.IO.File.OpenWrite(toFile)

        syncService.Pull(fromFile, stream, Nothing, Threading.CancellationToken.None)
        stream.Close()
    End Sub

    Public Sub deleteFile(fullpath As String)
        ' ToDo: react to FilenameTooLong_xxxx.txt

        ' delete file itself
        executeCommand("rm -f """ & fullpath & """")

        deleteDirIfEmpty(My.Computer.FileSystem.GetParentPath(fullpath).Replace("\", "/"))
    End Sub

    Private Sub deleteDirIfEmpty(path As String)
        If (getFilesInPath(path, "*.mp3").Count = 0 AndAlso getDirsInPath(path).Count = 1) Then
            executeCommand("rm -fr """ & path & """")
            deleteDirIfEmpty(My.Computer.FileSystem.GetParentPath(path).Replace("\", "/"))
        End If
    End Sub
End Class
