Public Class Track
    Private _pathLocal As String
    Private _pathLocalTemp As String
    Private _sizeLocal As Integer
    Private _ratingLocal As Integer

    Private _pathRemote As String
    Private _sizeRemote As Integer
    Private _ratingRemote As Integer

    Private _coverFile As String

    ' fields for the local file
    Public ReadOnly Property PathLocal As String
        Get
            Return _pathLocal
        End Get
    End Property
    Public ReadOnly Property ParentDirLocal As String
        Get
            Return IO.Path.GetDirectoryName(Me._pathLocal)
        End Get
    End Property

    Public ReadOnly Property PathLocalTemp As String
        Get
            Return _pathLocalTemp
        End Get
    End Property

    Public ReadOnly Property PathLocalCurrent As String
        Get
            If (Me._pathLocalTemp IsNot Nothing) Then
                Return Me._pathLocalTemp
            Else
                Return Me._pathLocal
            End If
        End Get
    End Property

    Public ReadOnly Property SizeLocal As Integer
        Get
            Return _sizeLocal
        End Get
    End Property

    Public Property RatingLocal As Integer
        Get
            Return _ratingLocal
        End Get
        Set(value As Integer)
            Me._ratingLocal = value
        End Set
    End Property

    Public ReadOnly Property CoverFile As String
        Get
            Return _coverFile
        End Get
    End Property
    Public ReadOnly Property HasCover As Boolean
        Get
            If (Me._coverFile IsNot Nothing) Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    ' fields for the remote file
    Public Property PathRemote As String
        Get
            Return _pathRemote
        End Get
        Set(value As String)
            Me._pathRemote = value
        End Set
    End Property
    Public ReadOnly Property ParentDirRemote As String
        Get
            Return IO.Path.GetDirectoryName(Me._pathRemote)
        End Get
    End Property

    Public ReadOnly Property SizeRemote As Integer
        Get
            Return _sizeRemote
        End Get
    End Property

    Public Property RatingRemote As Integer
        Get
            Return _ratingRemote
        End Get
        Set(value As Integer)
            Me._ratingRemote = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(PathLocal As String)
        Me._pathLocal = PathLocal

        If (My.Computer.FileSystem.FileExists(Me._pathLocal) = True) Then
            Me._sizeLocal = New IO.FileInfo(Me._pathLocal).Length
        End If

        Select Case True
            Case My.Computer.FileSystem.FileExists(Me.ParentDirLocal & "\folder.jpg") = True
                Me._coverFile = Me.ParentDirLocal & "\folder.jpg"
            Case My.Computer.FileSystem.FileExists(Me.ParentDirLocal & "\folder.png") = True
                Me._coverFile = Me.ParentDirLocal & "\folder.png"
        End Select
    End Sub

    Public Sub New(PathRemote As String, SizeRemote As Integer)
        Me._pathRemote = PathRemote
        Me._sizeRemote = SizeRemote
    End Sub

    Public Sub generateRemotePath(preset As Preset)
        Me._pathRemote = Me._pathLocal.Replace(preset.BasePath_Local, preset.BasePath_Remote).Replace("\", "/")
    End Sub

    Public Sub generateLocalPath(preset As Preset)
        Me._pathLocal = Me._pathRemote.Replace(preset.BasePath_Remote, preset.BasePath_Local).Replace("/", "\")
    End Sub


    Public Function convert(preset As Preset) As Integer
        Dim retval As Integer = 0

        Me._pathLocalTemp = My.Application.Info.DirectoryPath + "\tmp\toConvert.mp3"
        FileCopy(Me._pathLocal, Me._pathLocalTemp)

        Dim lame As New Process()
        With lame.StartInfo
            .FileName = My.Application.Info.DirectoryPath + "\lame\lame.exe"
            .Arguments = preset.ConvertString + " """ + Me._pathLocalTemp + """ """ + My.Application.Info.DirectoryPath + "\tmp\converted.mp3"""
            .CreateNoWindow = True
            .UseShellExecute = False
        End With

        lame.Start()
        lame.WaitForExit()

        retval = lame.ExitCode
        lame.Dispose()

        Me._pathLocalTemp = My.Application.Info.DirectoryPath + "\tmp\converted.mp3"
        Me._sizeLocal = New IO.FileInfo(Me._pathLocal).Length
        Me._sizeRemote = New IO.FileInfo(Me._pathLocalTemp).Length

        Return retval
    End Function

    Public Sub generateLocalRatingPath(preset As Preset)
        Me._pathLocal = Me._pathRemote.Replace(preset.BasePathRating_Remote, preset.BasePath_Local).Replace("/", "\")
    End Sub
End Class
