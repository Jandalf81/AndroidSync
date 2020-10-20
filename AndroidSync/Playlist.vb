Public Class Playlist
    Private _filename As String

    Public Property Filename As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(filename As String)
        Me.Filename = filename
    End Sub
End Class
