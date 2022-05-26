Public Class Track
    Private _pathLocal As String
    Private _pathLocalTemp As String
    Private _sizeLocal As Integer
    Private _ratingLocal As Integer
    Private _ratingLocalImage As Image

    Private _pathRemote As String
    Private _sizeRemote As Integer
    Private _ratingRemote As Integer
    Private _ratingRemoteImage As Image

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

            Select Case value
                Case 0
                    Me._ratingLocalImage = My.Resources.star_0
                Case 1
                    Me._ratingLocalImage = My.Resources.star_1
                Case 2
                    Me._ratingLocalImage = My.Resources.star_2
                Case 3
                    Me._ratingLocalImage = My.Resources.star_3
                Case 4
                    Me._ratingLocalImage = My.Resources.star_4
                Case 5
                    Me._ratingLocalImage = My.Resources.star_5
            End Select
        End Set
    End Property

    Public Property RatingLocalImage As Image
        Get
            Return _ratingLocalImage
        End Get
        Set(value As Image)
            _ratingLocalImage = value
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

            Select Case value
                Case 0
                    Me._ratingRemoteImage = My.Resources.star_0
                Case 1
                    Me._ratingRemoteImage = My.Resources.star_1
                Case 2
                    Me._ratingRemoteImage = My.Resources.star_2
                Case 3
                    Me._ratingRemoteImage = My.Resources.star_3
                Case 4
                    Me._ratingRemoteImage = My.Resources.star_4
                Case 5
                    Me._ratingRemoteImage = My.Resources.star_5
            End Select
        End Set
    End Property

    Public Property RatingRemoteImage As Image
        Get
            Return _ratingRemoteImage
        End Get
        Set(value As Image)
            Me._ratingRemoteImage = value
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

    Public Sub readLocalRating()
        TagLib.Id3v2.Tag.DefaultVersion = 3
        TagLib.Id3v2.Tag.ForceDefaultVersion = True

        If (My.Computer.FileSystem.FileExists(Me._pathLocal) = True) Then
            If (IO.Path.GetExtension(Me._pathLocal) = ".mp3") Then
                Dim mp3 As TagLib.File = TagLib.File.Create(Me._pathLocal)
                Dim tag As TagLib.Tag = mp3.GetTag(TagLib.TagTypes.Id3v2)
                Dim popm As TagLib.Id3v2.PopularimeterFrame = TagLib.Id3v2.PopularimeterFrame.Get(tag, "Windows Media Player 9 Series", True)

                Select Case popm.Rating
                    Case 0
                        Me.RatingLocal = 0
                    Case 1
                        Me.RatingLocal = 1
                    Case 64
                        Me.RatingLocal = 2
                    Case 128
                        Me.RatingLocal = 3
                    Case 196
                        Me.RatingLocal = 4
                    Case 255
                        Me.RatingLocal = 5
                End Select

                mp3.Dispose()
            End If
        End If
    End Sub

    Public Sub writeLocalRating(newRating As Integer)
        TagLib.Id3v2.Tag.DefaultVersion = 3
        TagLib.Id3v2.Tag.ForceDefaultVersion = True

        If (My.Computer.FileSystem.FileExists(Me._pathLocal) = True) Then
            If (IO.Path.GetExtension(Me._pathLocal) = ".mp3") Then
                Dim mp3 As TagLib.File = TagLib.File.Create(Me._pathLocal)
                Dim tag As TagLib.Tag = mp3.GetTag(TagLib.TagTypes.Id3v2)
                Dim popm As TagLib.Id3v2.PopularimeterFrame = TagLib.Id3v2.PopularimeterFrame.Get(tag, "Windows Media Player 9 Series", True)

                Select Case newRating
                    Case 0
                        popm.Rating = 0
                    Case 1
                        popm.Rating = 1
                    Case 2
                        popm.Rating = 64
                    Case 3
                        popm.Rating = 128
                    Case 4
                        popm.Rating = 196
                    Case 5
                        popm.Rating = 255
                End Select

                mp3.Save()
                mp3.Dispose()
            End If
        End If
    End Sub
End Class
