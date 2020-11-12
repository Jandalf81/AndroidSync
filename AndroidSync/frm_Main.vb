Imports System.ComponentModel
Imports SharpAdbClient

Public Class frm_Main
    Public ADBserver As AdbServer
    Public ADBclient As New AdbClient()

    Public availableDevices As New List(Of AndroidDevice)
    Public selectedDevice As New AndroidDevice()

    Public bs_Devices As New BindingSource()
    Public bs_Playlists As New BindingSource()
    Public bs_syncFiles_Log As New BindingSource()

    Public preset As New Preset()

    Public log As Log

    Public WithEvents bgw_syncSingleTrack As New System.ComponentModel.BackgroundWorker() With {
        .WorkerReportsProgress = True,
        .WorkerSupportsCancellation = True
        }

    Public WithEvents bgw_readPreset As New System.ComponentModel.BackgroundWorker() With {
        .WorkerReportsProgress = True,
        .WorkerSupportsCancellation = False
    }

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

    Private Sub PoC_btn_uploadFile_Click(sender As Object, e As EventArgs) Handles PoC_btn_uploadFile.Click
        Dim ofd As New OpenFileDialog()
        ofd.Multiselect = True
        Dim fromFiles() As String

        log = New Log(My.Application.Info.DirectoryPath & "\logs\" & selectedDevice.Model & "_" & selectedDevice.Serial)
        bs_syncFiles_Log.DataSource = log.LogEntries

        If (ofd.ShowDialog = DialogResult.OK) Then
            fromFiles = ofd.FileNames

            bgw_syncSingleTrack.RunWorkerAsync(fromFiles)
        End If
    End Sub

    Private Sub TEST_maxFilenameLength_Click(sender As Object, e As EventArgs)
        Dim currentLength_Filename As Integer = 1
        Dim currentlength_Directory As Integer

        Dim newFilename As String = "a.txt"

        Do While True
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("E:\www.github.com\AndroidSync\AndroidSync\bin\Debug\tmp\a.txt", False, System.Text.Encoding.GetEncoding("iso-8859-1"))
            file.Write(currentLength_Filename.ToString)
            file.Close()

            selectedDevice.upload("E:\www.github.com\AndroidSync\AndroidSync\bin\Debug\tmp\a.txt", "/sdcard/temp/" & newFilename)

            newFilename = "a" & newFilename
            currentLength_Filename += 1
        Loop
    End Sub

#Region "general FUNCTIONs and SUBs"
    Private Sub prepareDirectories()
        If (Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath + "\presets\")) Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath + "\presets\")
        End If

        If (Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath + "\tmp\")) Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath + "\tmp\")
        End If

        If (Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath + "\logs\")) Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath + "\logs\")
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
        Dim col_Playlist_Filename As New DataGridViewTextBoxColumn()
        col_Playlist_Filename.DataPropertyName = "Filename"
        col_Playlist_Filename.Name = "File name"

        Dim col_Playlists_NumberOfTracks As New DataGridViewTextBoxColumn()
        col_Playlists_NumberOfTracks.DataPropertyName = "NumberOfTracks"
        col_Playlists_NumberOfTracks.Name = "Tracks"

        With dgv_Playlists
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False

            .Columns.Add(col_Playlist_Filename)
            .Columns.Add(col_Playlists_NumberOfTracks)

            .DataSource = bs_Playlists
        End With

        bs_Playlists.DataSource = preset.Playlists

        ' dgv_syncFiles_Log
        Dim col_syncFiles_Log_Timestamp As New DataGridViewTextBoxColumn()
        col_syncFiles_Log_Timestamp.DataPropertyName = "Timestamp"
        col_syncFiles_Log_Timestamp.Name = "Timestamp"

        Dim col_syncFiles_Log_Type As New DataGridViewTextBoxColumn()
        col_syncFiles_Log_Type.DataPropertyName = "Type"
        col_syncFiles_Log_Type.Name = "Type"

        Dim col_syncFiles_Log_Message As New DataGridViewTextBoxColumn()
        col_syncFiles_Log_Message.DataPropertyName = "Message"
        col_syncFiles_Log_Message.Name = "Message"

        Dim col_syncFiles_Log_fromFile As New DataGridViewTextBoxColumn()
        col_syncFiles_Log_fromFile.DataPropertyName = "fromFile"
        col_syncFiles_Log_fromFile.Name = "from File"

        Dim col_syncFiles_Log_toFile As New DataGridViewTextBoxColumn()
        col_syncFiles_Log_toFile.DataPropertyName = "toFile"
        col_syncFiles_Log_toFile.Name = "to File"

        With dgv_syncFiles_Log
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToResizeColumns = True
            .AutoGenerateColumns = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns.Add(col_syncFiles_Log_Timestamp)
            .Columns.Add(col_syncFiles_Log_Type)
            .Columns.Add(col_syncFiles_Log_Message)
            .Columns.Add(col_syncFiles_Log_fromFile)
            .Columns.Add(col_syncFiles_Log_toFile)

            .DataSource = bs_syncFiles_Log
        End With

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
        Dim devices As List(Of DeviceData)

        devices = ADBclient.GetDevices()

        For Each device In devices
            availableDevices.Add(New AndroidDevice(device.Serial, device.State, device.Model, device.Product, device.Name, device.Features, device.Usb, device.TransportId))
        Next

        bs_Devices.DataSource = availableDevices
        dgv_Devices.DataSource = bs_Devices
    End Sub
#End Region

#Region "Load and Show form"
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

    Private Sub frm_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If (selectedDevice IsNot Nothing And selectedDevice.Serial <> "") Then
            preset.Save(selectedDevice.Model + "_" + selectedDevice.Serial)
        End If
    End Sub
#End Region

#Region "frm_Main / grp_Devices"
    Private Sub btn_selectDevice_Click(sender As Object, e As EventArgs) Handles btn_selectDevice.Click
        Me.Cursor = Cursors.AppStarting

        ' save preset of currently selected device
        If (selectedDevice IsNot Nothing And selectedDevice.Serial <> "") Then
            preset.Save(selectedDevice.Model + "_" + selectedDevice.Serial)
        End If

        ' get newly selected device
        selectedDevice = dgv_Devices.SelectedRows(0).DataBoundItem

        ' load preset of newly selected device
        preset.Load(selectedDevice.Model + "_" + selectedDevice.Serial)
        txt_syncFiles_basePath_Local.Text = preset.BasePath_Local
        txt_syncFiles_basePath_Remote.Text = preset.BasePath_Remote
        chk_syncFiles_Convert.Checked = preset.ConvertFlag
        txt_syncFiles_LAMEOptions.Text = preset.ConvertString
        bs_Playlists.DataSource = preset.Playlists

        ' refresh other control elements
        txt_ModelNameProductSerial.Text = selectedDevice.Model & " / " & selectedDevice.Name & " / " & selectedDevice.Product & " / " & selectedDevice.Serial

        selectedDevice.refreshCapacity()
        MyProgressBar1.myText = String.Format("{0} GiB used of {1} GiB ({2} GiB / {3}% free)", Math.Round(selectedDevice.CapacityUsed / 1024 / 1024, 2), Math.Round(selectedDevice.Capacity / 1024 / 1024, 2), Math.Round(selectedDevice.CapacityFree / 1024 / 1024, 2), Math.Round(selectedDevice.CapacityFree * 100 / selectedDevice.Capacity, 2))
        MyProgressBar1.myValue = Math.Round(selectedDevice.CapacityUsed * 100 / selectedDevice.Capacity, 0)

        str_Status_Device.Text = selectedDevice.Model

        bgw_readPreset.RunWorkerAsync(preset.Playlists)
    End Sub

    Private Sub btn_refreshDevices_Click(sender As Object, e As EventArgs) Handles btn_refreshDevices.Click
        refreshDevices()
    End Sub
#End Region

#Region "frm_Main / tab_syncFiles"

#Region "frm_Main / tab_syncFiles / grp_Settings"
    Private Sub btn_syncFiles_basePath_Remote_Click(sender As Object, e As EventArgs) Handles btn_syncFiles_basePath_Remote.Click
        Dim frm_AndroidTree = New frm_AndroidTree(selectedDevice)

        If (frm_AndroidTree.ShowDialog() = DialogResult.OK) Then
            txt_syncFiles_basePath_Remote.Text = frm_AndroidTree.selectedPath
            preset.BasePath_Remote = frm_AndroidTree.selectedPath
        End If
    End Sub

    Private Sub txt_syncFiles_basePathRemote_TextChanged(sender As Object, e As EventArgs) Handles txt_syncFiles_basePath_Remote.TextChanged
        preset.BasePath_Remote = txt_syncFiles_basePath_Remote.Text
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

    Private Sub txt_syncFiles_basePath_Local_TextChanged(sender As Object, e As EventArgs) Handles txt_syncFiles_basePath_Local.TextChanged
        preset.BasePath_Local = txt_syncFiles_basePath_Local.Text
    End Sub

    Private Sub chk_syncFiles_Convert_CheckedChanged(sender As Object, e As EventArgs) Handles chk_syncFiles_Convert.CheckedChanged
        preset.ConvertFlag = chk_syncFiles_Convert.CheckState
    End Sub

    Private Sub txt_syncFiles_LAMEOptions_TextChanged(sender As Object, e As EventArgs) Handles txt_syncFiles_LAMEOptions.TextChanged
        preset.ConvertString = txt_syncFiles_LAMEOptions.Text
    End Sub
#End Region

#Region "frm_Main / tab_syncFiles / grp_Playlists"
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
#End Region

#End Region

#Region "Background Workers"

#Region "bgw_syncSingleTrack"
    Private Sub bgw_syncSingleTrack_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_syncSingleTrack.DoWork
        Dim currentProgress As Integer = 0
        Dim progressPercentage As Integer = 0
        Dim fromFiles() As String = e.Argument
        Dim count As Integer = fromFiles.Count

        bgw_syncSingleTrack.ReportProgress(progressPercentage, New LogEntry(LogEntry.LogEntryType.Message, "Sync started"))

        For Each fromFile As String In fromFiles
            currentProgress += 1

            bgw_syncSingleTrack.ReportProgress(progressPercentage, "Uploading " & fromFile & "...")

            Dim toFile As String = fromFile.Replace(preset.BasePath_Local, preset.BasePath_Remote)
            toFile = toFile.Replace("\", "/")

            selectedDevice.upload(fromFile, toFile)

            progressPercentage = currentProgress * 100 / count
            bgw_syncSingleTrack.ReportProgress(progressPercentage, New LogEntry(LogEntry.LogEntryType.SyncFiles, "File uploaded", fromFile, toFile))
        Next
    End Sub

    Private Sub bgw_syncSingleTrack_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw_syncSingleTrack.ProgressChanged
        str_Status_Progress.Text = e.ProgressPercentage & "%"

        Select Case e.UserState.GetType()
            Case GetType(LogEntry)
                bs_syncFiles_Log.Add(e.UserState)
            Case GetType(String)
                str_Status_Task.Text = e.UserState
        End Select
    End Sub

    Private Sub bgw_syncSingleTrack_Completed() Handles bgw_syncSingleTrack.RunWorkerCompleted
        str_Status_Task.Text = "Done"

        bs_syncFiles_Log.Add(New LogEntry(LogEntry.LogEntryType.Message, "Sync finished"))
        log.Close()
    End Sub
#End Region

#Region "bgw_readPreset"
    Private Sub bgw_readPreset_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_readPreset.DoWork
        Dim currentProgress As Integer = 0
        Dim progressPercentage As Integer = 0
        Dim playlists As List(Of Playlist) = e.Argument

        For Each playlist In playlists
            bgw_readPreset.ReportProgress(progressPercentage, "Reading " & playlist.Filename & "...")
            playlist.Read()

            currentProgress += 1
            progressPercentage = currentProgress * 100 / playlists.Count
        Next

        bgw_readPreset.ReportProgress(progressPercentage, "Done")
    End Sub

    Private Sub bgw_readPreset_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw_readPreset.ProgressChanged
        str_Status_Progress.Text = e.ProgressPercentage & "%"
        str_Status_Task.Text = e.UserState

        Application.DoEvents()
    End Sub

    Private Sub bgw_readPreset_Completed() Handles bgw_readPreset.RunWorkerCompleted
        tab_Control.Enabled = True
        btn_syncFiles_CancelSync.Enabled = False

        Me.Cursor = Cursors.Default
    End Sub
#End Region
#End Region
End Class
