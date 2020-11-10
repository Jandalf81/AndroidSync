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

    <XmlIgnore()> Public ReadOnly Property NumberOfTracks
        Get
            Return Me._tracks.Count
        End Get
    End Property

    <XmlIgnore()> Public ReadOnly Property Tracks
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
End Class
