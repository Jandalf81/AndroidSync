<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SyncRating
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grp_Track = New System.Windows.Forms.GroupBox()
        Me.lbl_Track_Track = New System.Windows.Forms.Label()
        Me.lbl_Track_Title = New System.Windows.Forms.Label()
        Me.lbl_Track_PathLocal = New System.Windows.Forms.Label()
        Me.lbl_Track_PathRemote = New System.Windows.Forms.Label()
        Me.lbl_PathRemote = New System.Windows.Forms.Label()
        Me.lbl_PathLocal = New System.Windows.Forms.Label()
        Me.lbl_Track_Album = New System.Windows.Forms.Label()
        Me.lbl_Track_Artist = New System.Windows.Forms.Label()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.lbl_Track = New System.Windows.Forms.Label()
        Me.lbl_Album = New System.Windows.Forms.Label()
        Me.lbl_Artist = New System.Windows.Forms.Label()
        Me.pic_Cover = New System.Windows.Forms.PictureBox()
        Me.grp_Decision = New System.Windows.Forms.GroupBox()
        Me.btn_Skip = New System.Windows.Forms.Button()
        Me.btn_useRemoteRating = New System.Windows.Forms.Button()
        Me.btn_useLocalRating = New System.Windows.Forms.Button()
        Me.grp_Track.SuspendLayout()
        CType(Me.pic_Cover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Decision.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_Track
        '
        Me.grp_Track.Controls.Add(Me.lbl_Track_Track)
        Me.grp_Track.Controls.Add(Me.lbl_Track_Title)
        Me.grp_Track.Controls.Add(Me.lbl_Track_PathLocal)
        Me.grp_Track.Controls.Add(Me.lbl_Track_PathRemote)
        Me.grp_Track.Controls.Add(Me.lbl_PathRemote)
        Me.grp_Track.Controls.Add(Me.lbl_PathLocal)
        Me.grp_Track.Controls.Add(Me.lbl_Track_Album)
        Me.grp_Track.Controls.Add(Me.lbl_Track_Artist)
        Me.grp_Track.Controls.Add(Me.lbl_Title)
        Me.grp_Track.Controls.Add(Me.lbl_Track)
        Me.grp_Track.Controls.Add(Me.lbl_Album)
        Me.grp_Track.Controls.Add(Me.lbl_Artist)
        Me.grp_Track.Controls.Add(Me.pic_Cover)
        Me.grp_Track.Location = New System.Drawing.Point(12, 12)
        Me.grp_Track.Name = "grp_Track"
        Me.grp_Track.Size = New System.Drawing.Size(655, 250)
        Me.grp_Track.TabIndex = 0
        Me.grp_Track.TabStop = False
        Me.grp_Track.Text = "Track"
        '
        'lbl_Track_Track
        '
        Me.lbl_Track_Track.AutoSize = True
        Me.lbl_Track_Track.Location = New System.Drawing.Point(282, 71)
        Me.lbl_Track_Track.Name = "lbl_Track_Track"
        Me.lbl_Track_Track.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Track_Track.TabIndex = 14
        Me.lbl_Track_Track.Text = "Track"
        '
        'lbl_Track_Title
        '
        Me.lbl_Track_Title.AutoSize = True
        Me.lbl_Track_Title.Location = New System.Drawing.Point(282, 97)
        Me.lbl_Track_Title.Name = "lbl_Track_Title"
        Me.lbl_Track_Title.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Track_Title.TabIndex = 13
        Me.lbl_Track_Title.Text = "Title"
        '
        'lbl_Track_PathLocal
        '
        Me.lbl_Track_PathLocal.AutoSize = True
        Me.lbl_Track_PathLocal.Location = New System.Drawing.Point(96, 202)
        Me.lbl_Track_PathLocal.Name = "lbl_Track_PathLocal"
        Me.lbl_Track_PathLocal.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Track_PathLocal.TabIndex = 12
        Me.lbl_Track_PathLocal.Text = "Local Path"
        '
        'lbl_Track_PathRemote
        '
        Me.lbl_Track_PathRemote.AutoSize = True
        Me.lbl_Track_PathRemote.Location = New System.Drawing.Point(96, 228)
        Me.lbl_Track_PathRemote.Name = "lbl_Track_PathRemote"
        Me.lbl_Track_PathRemote.Size = New System.Drawing.Size(69, 13)
        Me.lbl_Track_PathRemote.TabIndex = 11
        Me.lbl_Track_PathRemote.Text = "Remote Path"
        '
        'lbl_PathRemote
        '
        Me.lbl_PathRemote.AutoSize = True
        Me.lbl_PathRemote.Location = New System.Drawing.Point(6, 228)
        Me.lbl_PathRemote.Name = "lbl_PathRemote"
        Me.lbl_PathRemote.Size = New System.Drawing.Size(72, 13)
        Me.lbl_PathRemote.TabIndex = 10
        Me.lbl_PathRemote.Text = "Remote Path:"
        '
        'lbl_PathLocal
        '
        Me.lbl_PathLocal.AutoSize = True
        Me.lbl_PathLocal.Location = New System.Drawing.Point(6, 202)
        Me.lbl_PathLocal.Name = "lbl_PathLocal"
        Me.lbl_PathLocal.Size = New System.Drawing.Size(64, 13)
        Me.lbl_PathLocal.TabIndex = 9
        Me.lbl_PathLocal.Text = "Local Path:,"
        '
        'lbl_Track_Album
        '
        Me.lbl_Track_Album.AutoSize = True
        Me.lbl_Track_Album.Location = New System.Drawing.Point(282, 45)
        Me.lbl_Track_Album.Name = "lbl_Track_Album"
        Me.lbl_Track_Album.Size = New System.Drawing.Size(36, 13)
        Me.lbl_Track_Album.TabIndex = 6
        Me.lbl_Track_Album.Text = "Album"
        '
        'lbl_Track_Artist
        '
        Me.lbl_Track_Artist.AutoSize = True
        Me.lbl_Track_Artist.Location = New System.Drawing.Point(282, 19)
        Me.lbl_Track_Artist.Name = "lbl_Track_Artist"
        Me.lbl_Track_Artist.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Track_Artist.TabIndex = 5
        Me.lbl_Track_Artist.Text = "Artist"
        '
        'lbl_Title
        '
        Me.lbl_Title.AutoSize = True
        Me.lbl_Title.Location = New System.Drawing.Point(192, 97)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Title.TabIndex = 4
        Me.lbl_Title.Text = "Title:"
        '
        'lbl_Track
        '
        Me.lbl_Track.AutoSize = True
        Me.lbl_Track.Location = New System.Drawing.Point(192, 71)
        Me.lbl_Track.Name = "lbl_Track"
        Me.lbl_Track.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Track.TabIndex = 3
        Me.lbl_Track.Text = "Track:"
        '
        'lbl_Album
        '
        Me.lbl_Album.AutoSize = True
        Me.lbl_Album.Location = New System.Drawing.Point(192, 45)
        Me.lbl_Album.Name = "lbl_Album"
        Me.lbl_Album.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Album.TabIndex = 2
        Me.lbl_Album.Text = "Album:"
        '
        'lbl_Artist
        '
        Me.lbl_Artist.AutoSize = True
        Me.lbl_Artist.Location = New System.Drawing.Point(192, 19)
        Me.lbl_Artist.Name = "lbl_Artist"
        Me.lbl_Artist.Size = New System.Drawing.Size(33, 13)
        Me.lbl_Artist.TabIndex = 1
        Me.lbl_Artist.Text = "Artist:"
        '
        'pic_Cover
        '
        Me.pic_Cover.Location = New System.Drawing.Point(6, 19)
        Me.pic_Cover.Name = "pic_Cover"
        Me.pic_Cover.Size = New System.Drawing.Size(180, 180)
        Me.pic_Cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Cover.TabIndex = 0
        Me.pic_Cover.TabStop = False
        '
        'grp_Decision
        '
        Me.grp_Decision.Controls.Add(Me.btn_Skip)
        Me.grp_Decision.Controls.Add(Me.btn_useRemoteRating)
        Me.grp_Decision.Controls.Add(Me.btn_useLocalRating)
        Me.grp_Decision.Location = New System.Drawing.Point(12, 268)
        Me.grp_Decision.Name = "grp_Decision"
        Me.grp_Decision.Size = New System.Drawing.Size(655, 128)
        Me.grp_Decision.TabIndex = 1
        Me.grp_Decision.TabStop = False
        Me.grp_Decision.Text = "Sync Decision"
        '
        'btn_Skip
        '
        Me.btn_Skip.Location = New System.Drawing.Point(6, 72)
        Me.btn_Skip.Name = "btn_Skip"
        Me.btn_Skip.Size = New System.Drawing.Size(643, 47)
        Me.btn_Skip.TabIndex = 2
        Me.btn_Skip.Text = "Skip" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(no change)"
        Me.btn_Skip.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btn_Skip.UseVisualStyleBackColor = True
        '
        'btn_useRemoteRating
        '
        Me.btn_useRemoteRating.Image = Global.AndroidSync.My.Resources.Resources.star_0
        Me.btn_useRemoteRating.Location = New System.Drawing.Point(346, 19)
        Me.btn_useRemoteRating.Name = "btn_useRemoteRating"
        Me.btn_useRemoteRating.Size = New System.Drawing.Size(303, 47)
        Me.btn_useRemoteRating.TabIndex = 1
        Me.btn_useRemoteRating.Text = "use Remote Rating"
        Me.btn_useRemoteRating.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btn_useRemoteRating.UseVisualStyleBackColor = True
        '
        'btn_useLocalRating
        '
        Me.btn_useLocalRating.Image = Global.AndroidSync.My.Resources.Resources.star_0
        Me.btn_useLocalRating.Location = New System.Drawing.Point(6, 19)
        Me.btn_useLocalRating.Name = "btn_useLocalRating"
        Me.btn_useLocalRating.Size = New System.Drawing.Size(303, 47)
        Me.btn_useLocalRating.TabIndex = 0
        Me.btn_useLocalRating.Text = "use Local Rating"
        Me.btn_useLocalRating.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btn_useLocalRating.UseVisualStyleBackColor = True
        '
        'frm_SyncRating
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 405)
        Me.Controls.Add(Me.grp_Decision)
        Me.Controls.Add(Me.grp_Track)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SyncRating"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_SyncRating"
        Me.TopMost = True
        Me.grp_Track.ResumeLayout(False)
        Me.grp_Track.PerformLayout()
        CType(Me.pic_Cover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Decision.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grp_Track As GroupBox
    Friend WithEvents lbl_Track_Track As Label
    Friend WithEvents lbl_Track_Title As Label
    Friend WithEvents lbl_Track_PathLocal As Label
    Friend WithEvents lbl_Track_PathRemote As Label
    Friend WithEvents lbl_PathRemote As Label
    Friend WithEvents lbl_PathLocal As Label
    Friend WithEvents lbl_Track_Album As Label
    Friend WithEvents lbl_Track_Artist As Label
    Friend WithEvents lbl_Title As Label
    Friend WithEvents lbl_Track As Label
    Friend WithEvents lbl_Album As Label
    Friend WithEvents lbl_Artist As Label
    Friend WithEvents pic_Cover As PictureBox
    Friend WithEvents grp_Decision As GroupBox
    Friend WithEvents btn_useLocalRating As Button
    Friend WithEvents btn_Skip As Button
    Friend WithEvents btn_useRemoteRating As Button
End Class
