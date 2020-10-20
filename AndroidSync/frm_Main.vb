Imports SharpAdbClient

Public Class frm_Main
    Public ADBserver As AdbServer
    Public ADBclient As New AdbClient()

    Public availableDevices As IEnumerable(Of DeviceData)
    Public selectedDevice As DeviceData

    Public bs_Devices As New BindingSource()
    Public bs_Playlists As New BindingSource()

    Public preset As New Preset()

    Private Sub PoC_btn_getListOfMP3_Click(sender As Object, e As EventArgs)
        str_Status_ADBserver.Text = "Starte ADB-Server..."
        Dim ADBserver As SharpAdbClient.AdbServer = New SharpAdbClient.AdbServer()
        Dim result = ADBserver.StartServer("C:\adb\adb.exe", True)
        Select Case result
            Case StartServerResult.AlreadyRunning
                str_Status_ADBserver.Text = "ADB-Server lief bereits"
            Case StartServerResult.Started
                str_Status_ADBserver.Text = "ADB-Server gestartet"
            Case StartServerResult.RestartedOutdatedDaemon
                str_Status_ADBserver.Text = "Veralteten ADB-Server neu gestartet"
        End Select


        Dim ADBclient = New AdbClient()
        Dim AndroidDevices = ADBclient.GetDevices()

        Dim start As DateTime
        Dim stopp As DateTime

        Dim device = AndroidDevices.First()
        Dim receiver = New SharpAdbClient.ConsoleOutputReceiver()

        str_Status_ADBserver.Text = "Ermittle Dateien (StreamWriter)..."
        start = Now()
        ADBclient.ExecuteRemoteCommand("find /sdcard/Music/ -type f -name *.mp3 -printf ""%p|%s\n""", device, receiver)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("D:\adb.txt", False, System.Text.Encoding.GetEncoding("iso-8859-1"))
        file.Write(receiver.ToString)
        file.Close()
        stopp = Now()

        MsgBox("fertig: " & (stopp - start).ToString)


        str_Status_ADBserver.Text = "Ermittle Dateien (direkt auf Gerät)..."
        start = Now()
        ADBclient.ExecuteRemoteCommand("find /sdcard/Music/ -type f -name *.mp3 -printf ""%p|%s\n"" > /sdcard/direct.txt", device, receiver)

        str_Status_ADBserver.Text = "Übertrage Datei..."
        Dim syncService As New SyncService(ADBclient, device)
        Dim stream = System.IO.File.OpenWrite("D:\direct.txt")
        syncService.Pull("/sdcard/direct.txt", stream, Nothing, Threading.CancellationToken.None)
        stream.Close()
        stopp = Now()

        MsgBox("fertig: " & (stopp - start).ToString)

        ADBclient.ExecuteRemoteCommand("rm /sdcard/direct.txt", device, receiver)
    End Sub

    Private Sub prepareDirectories()
        If (Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath + "\presets\")) Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath + "\presets\")
        End If
    End Sub

    Private Sub prepareForm()
        ' dgv_Devices
        Dim col_Model As New DataGridViewTextBoxColumn()
        col_Model.DataPropertyName = "Model"
        col_Model.Name = "Modell"

        Dim col_Product As New DataGridViewTextBoxColumn()
        col_Product.DataPropertyName = "Product"
        col_Product.Name = "Produkt"

        Dim col_Name As New DataGridViewTextBoxColumn()
        col_Name.DataPropertyName = "Name"
        col_Name.Name = "Name"

        Dim col_Serial As New DataGridViewTextBoxColumn()
        col_Serial.DataPropertyName = "Serial"
        col_Serial.Name = "Serial"

        Dim col_TransportId As New DataGridViewTextBoxColumn()
        col_TransportId.DataPropertyName = "TransportId"
        col_TransportId.Name = "TransportId"

        ' add prepared columns to DataGridView
        With dgv_Devices
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False

            .Columns.Add(col_Model)
            .Columns.Add(col_Name)
            .Columns.Add(col_Product)
            .Columns.Add(col_Serial)
            .Columns.Add(col_TransportId)
        End With

        ' dgv_Playlists
        Dim col_Playlist As New DataGridViewTextBoxColumn()
        col_Playlist.DataPropertyName = "Filename"
        col_Playlist.Name = "File name"

        With dgv_Playlists
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False

            .Columns.Add(col_Playlist)

            .DataSource = bs_Playlists
        End With

        bs_Playlists.DataSource = preset.Playlists

        ' Status Strip
        str_Status_ADBserver.Text = "waiting..."
        str_Status_Device.Text = "no device selected"
    End Sub

    Private Sub startADBserver()
        str_Status_ADBserver.Text = "Starting..."

        ADBserver = New AdbServer()
        Dim result = ADBserver.StartServer("C:\adb\adb.exe", True)

        Select Case result
            Case StartServerResult.AlreadyRunning
                str_Status_ADBserver.Text = "Running (" & ADBclient.GetAdbVersion & ")"
            Case StartServerResult.Started
                str_Status_ADBserver.Text = "Running (" & ADBclient.GetAdbVersion & ")"
            Case StartServerResult.RestartedOutdatedDaemon
                str_Status_ADBserver.Text = "Running (" & ADBclient.GetAdbVersion & ")"
            Case Else
                str_Status_ADBserver.Text = "ERROR"
        End Select
    End Sub

    Private Sub refreshDevices()
        availableDevices = ADBclient.GetDevices()

        bs_Devices.DataSource = availableDevices
        dgv_Devices.DataSource = bs_Devices
    End Sub

    Private Sub refreshDiskspaceOfSelectedDevice()
        Dim receiver As New ConsoleOutputReceiver()
        Dim output As String
        ADBclient.ExecuteRemoteCommand("df -k /data", selectedDevice, receiver)
        output = receiver.ToString

        Dim lines As String() = output.Split(vbLf)
        lines(1) = System.Text.RegularExpressions.Regex.Replace(lines(1), "\s+", "|")
        Dim fields As String() = lines(1).Split("|")

        Dim devCapacity As Single = fields(1)
        Dim devUsed As Single = fields(2)
        Dim devFree As Single = fields(3)

        MyProgressBar1.myText = String.Format("{0} GiB used of {1} GiB ({2} GiB / {3}% free)", Math.Round(devUsed / 1024 / 1024, 2), Math.Round(devCapacity / 1024 / 1024, 2), Math.Round(devFree / 1024 / 1024, 2), Math.Round(devFree * 100 / devCapacity, 2))
        MyProgressBar1.myValue = Math.Round(devUsed * 100 / devCapacity, 0)
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prepareDirectories()
        prepareForm()

        tab_Control.Enabled = False
    End Sub
    Private Sub frm_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Application.DoEvents()

        Me.Cursor() = Cursors.AppStarting
        startADBserver()
        refreshDevices()
        Me.Cursor() = Cursors.Default
    End Sub

    Private Sub btn_selectDevice_Click(sender As Object, e As EventArgs) Handles btn_selectDevice.Click
        ' save preset of currently selected device
        If (Not selectedDevice Is Nothing) Then
            preset.Save(selectedDevice.Model + "_" + selectedDevice.Serial)
        End If

        ' get newly selected device
        selectedDevice = dgv_Devices.SelectedRows(0).DataBoundItem

        ' load preset of newly selected device
        preset.Load(selectedDevice.Model + "_" + selectedDevice.Serial)
        txt_syncFiles_basePath_Local.Text = preset.BasePath_Local
        txt_syncFiles_basePathRemote.Text = preset.BasePath_Remote
        chk_syncFiles_Convert.Checked = preset.ConvertFlag
        txt_syncFiles_LAMEOptions.Text = preset.ConvertString
        bs_Playlists.DataSource = preset.Playlists

        ' refresh other control elements
        txt_ModelNameProductSerial.Text = selectedDevice.Model & " / " & selectedDevice.Name & " / " & selectedDevice.Product & " / " & selectedDevice.Serial
        refreshDiskspaceOfSelectedDevice()

        tab_Control.Enabled = True
        str_Status_Device.Text = selectedDevice.Model
    End Sub

    Private Sub btn_refreshDevices_Click(sender As Object, e As EventArgs) Handles btn_refreshDevices.Click
        refreshDevices()
    End Sub

    Private Sub txt_syncFiles_basePathRemote_TextChanged(sender As Object, e As EventArgs) Handles txt_syncFiles_basePathRemote.TextChanged
        preset.BasePath_Remote = txt_syncFiles_basePathRemote.Text
    End Sub

    Private Sub txt_syncFiles_basePath_Local_TextChanged(sender As Object, e As EventArgs) Handles txt_syncFiles_basePath_Local.TextChanged
        preset.BasePath_Local = txt_syncFiles_basePath_Local.Text
    End Sub

    Private Sub chk_syncFiles_Convert_CheckedChanged(sender As Object, e As EventArgs) Handles chk_syncFiles_Convert.CheckedChanged
        preset.ConvertFlag = chk_syncFiles_Convert.CheckState
    End Sub

    Private Sub txt_syncFiles_LAMEOptions_TextChanged(sender As Object, e As EventArgs) Handles txt_syncFiles_LAMEOptions.TextChanged
        preset.ConvertString = txt_syncFiles_LAMEOptions.Text
    End Sub

    Private Sub btn_syncFiles_Playlists_Add_Click(sender As Object, e As EventArgs) Handles btn_syncFiles_Playlists_Add.Click
        Dim ofd As New OpenFileDialog()

        With ofd
            .Filter = "playlist files (*.m3u, *.m3u8)|*.m3u;*.m3u8"
            .Multiselect = False
            .Title = "Add Playlist File"
        End With

        If (ofd.ShowDialog() = DialogResult.OK) Then
            Dim pl As New Playlist(ofd.FileName)

            bs_Playlists.Add(pl)
        End If
    End Sub

    Private Sub btn_syncFiles_Playlists_Remove_Click(sender As Object, e As EventArgs) Handles btn_syncFiles_Playlists_Remove.Click
        Dim selectedPlaylist As Playlist = dgv_Playlists.SelectedRows(0).DataBoundItem
        bs_Playlists.Remove(selectedPlaylist)
    End Sub

    Private Sub btn_syncFiles_basePath_Local_Click(sender As Object, e As EventArgs) Handles btn_syncFiles_basePath_Local.Click
        Dim fbd As New FolderBrowserDialog()

        With fbd
            .Description = "Select the base path for your local files"
            .ShowNewFolderButton = False
            If (preset.BasePath_Local <> "") Then
                .SelectedPath = preset.BasePath_Local
            Else
                .SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyMusic
            End If
        End With

        If (fbd.ShowDialog() = DialogResult.OK) Then
            txt_syncFiles_basePath_Local.Text = fbd.SelectedPath
        End If
    End Sub
End Class
