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

        ADBclient.ExecuteRemoteCommand(command, Me, receiver)
        Return receiver.ToString()
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
End Class
