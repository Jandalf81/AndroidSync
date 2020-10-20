Public Class Preset
    Private _basePath_Local As String
    Private _basePath_Remote As String

    Private _convertFlag As Boolean
    Private _convertString As String

    Private _playlists As List(Of Playlist)

    Public Property BasePath_Local As String
        Get
            Return _basePath_Local
        End Get
        Set(value As String)
            _basePath_Local = value
        End Set
    End Property
    Public Property BasePath_Remote As String
        Get
            Return _basePath_Remote
        End Get
        Set(value As String)
            _basePath_Remote = value
        End Set
    End Property

    Public Property ConvertFlag As Boolean
        Get
            Return _convertFlag
        End Get
        Set(value As Boolean)
            _convertFlag = value
        End Set
    End Property
    Public Property ConvertString As String
        Get
            Return _convertString
        End Get
        Set(value As String)
            _convertString = value
        End Set
    End Property

    Public Property Playlists As List(Of Playlist)
        Get
            Return _playlists
        End Get
        Set(value As List(Of Playlist))
            _playlists = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub Save(toFile As String)
        Dim x As New Xml.Serialization.XmlSerializer(Me.GetType)
        Dim fileWriter As IO.StreamWriter

        fileWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath + "\presets\" + toFile + ".xml", False)
        x.Serialize(fileWriter, Me)
        fileWriter.Close()
    End Sub

    Public Sub Load(fromFile As String)
        Dim IPreset As New Preset()
        Dim x As New Xml.Serialization.XmlSerializer(Me.GetType)

        If (My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "\presets\" + fromFile + ".xml")) Then
            Using fs As New IO.FileStream(My.Application.Info.DirectoryPath + "\presets\" + fromFile + ".xml", IO.FileMode.Open)
                IPreset = x.Deserialize(fs)
            End Using

            Me.BasePath_Local = IPreset.BasePath_Local
            Me.BasePath_Remote = IPreset.BasePath_Remote
            Me.ConvertFlag = IPreset.ConvertFlag
            Me.ConvertString = IPreset.ConvertString
            Me.Playlists = IPreset.Playlists
        End If
    End Sub
End Class
