Public Class frm_SyncRating
    Public Enum syncRatingResult
        thisDoesNotWork
        toSync
        useLocalRating
        useRemoteRating
        skip
    End Enum

    Private _track As Track

    Public Property Track As Track
        Get
            Return _track
        End Get
        Set(value As Track)
            _track = value

            ' TODO get and show mp3 Tags

            Dim coverPath As String
            coverPath = _track.PathLocal.Remove(_track.PathLocal.LastIndexOf("\")) & "\folder.jpg"
            If (My.Computer.FileSystem.FileExists(coverPath)) Then
                pic_Cover.Image = Image.FromFile(coverPath)
            Else
                'TODO set default image here
            End If

            lbl_Track_PathLocal.Text = _track.PathLocal
            lbl_Track_PathRemote.Text = _track.PathRemote

            btn_useLocalRating.Image = _track.RatingLocalImage.Clone()
            btn_useRemoteRating.Image = _track.RatingRemoteImage.Clone()
        End Set
    End Property

    Private Sub frm_SyncRating_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Me.DialogResult = syncRatingResult.skip
        End If
    End Sub

    Private Sub btn_useLocalRating_Click(sender As Object, e As EventArgs) Handles btn_useLocalRating.Click
        Me.DialogResult = syncRatingResult.useLocalRating
    End Sub

    Private Sub btn_useRemoteRating_Click(sender As Object, e As EventArgs) Handles btn_useRemoteRating.Click
        Me.DialogResult = syncRatingResult.useRemoteRating
    End Sub

    Private Sub btn_Skip_Click(sender As Object, e As EventArgs) Handles btn_Skip.Click
        Me.DialogResult = syncRatingResult.skip
    End Sub
End Class