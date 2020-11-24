Imports System.Xml.Serialization

Public Class Playlist
    Private _filename As String
    Private _tracks As New List(Of Track)

    Public Property Filename As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    <XmlIgnore()> Public ReadOnly Property NumberOfTracks As Integer
        Get
            Return Me._tracks.Count
        End Get
    End Property

    <XmlIgnore()> Public ReadOnly Property Tracks As List(Of Track)
        Get
            Return _tracks
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub New(filename As String)
        Me.Filename = filename
    End Sub


    Public Sub Read()
        If (My.Computer.FileSystem.FileExists(Me.Filename) = False) Then
            MsgBox("File not found: " & Me.Filename, MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Me._tracks.Clear()

        Select Case IO.Path.GetExtension(Me._filename)
            Case ".m3u"
                Read_m3u8()
            Case ".m3u8"
                Read_m3u8()
        End Select
    End Sub

    Private Sub Read_m3u8()
        Dim streamReader As System.IO.StreamReader
        Dim line As String

        streamReader = My.Computer.FileSystem.OpenTextFileReader(Me.Filename)

        Do
            line = streamReader.ReadLine()

            Select Case line
                Case Nothing
                    Exit Do
                Case "#"
                    Continue Do
                Case ""
                    Continue Do
                Case Else
                    Me._tracks.Add(New Track(line))
            End Select
        Loop
    End Sub

    Public Sub write_m3u8()
        Dim content As String = ""

        For Each track In Me._tracks
            content += track.PathLocal & vbCrLf
        Next

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Me._filename, False)
        file.Write(content)

        file.Close()
        file.Dispose()
    End Sub

    Public Enum compareMode
        pathLocal = 0
        pathRemote = 1
    End Enum

    Public Sub combineWith(otherPlaylist As Playlist, mode As compareMode)
        If (mode = compareMode.pathLocal) Then
            For Each track In otherPlaylist.Tracks
                If (Me.contains(path:=track.PathLocal, mode:=compareMode.pathLocal) = False) Then
                    Me.Tracks.Add(track)
                End If
            Next
        End If
    End Sub

    Public Function contains(path As String, mode As compareMode) As Boolean
        Dim retval As Boolean = False
        Dim list As IEnumerable(Of Track)

        Select Case mode
            Case compareMode.pathLocal
                list = From track In _tracks Where track.PathLocal = path Select track
            Case compareMode.pathRemote
                list = From track In _tracks Where track.PathRemote = path Select track
        End Select

        If list.Count > 0 Then retval = True

        Return retval
    End Function

    Public Function getMissing(otherPlaylist As Playlist) As Playlist
        Dim retval As New Playlist()

        For Each track In otherPlaylist.Tracks
            If (Me.contains(track.PathLocal, Playlist.compareMode.pathLocal) = False) Then
                retval.Tracks.Add(track)
            End If
        Next

        Return retval
    End Function

    Public Sub generateRemotePath(preset As Preset)
        For Each track In _tracks
            track.generateRemotePath(preset)
        Next
    End Sub

    Public Sub generateLocalPath(preset As Preset)
        For Each track In _tracks
            track.generateLocalPath(preset)
        Next
    End Sub
End Class
