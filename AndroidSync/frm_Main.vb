Imports SharpAdbClient

Public Class frm_Main
    Public ADBserver As AdbServer
    Public ADBclient As AdbClient

    Public availableDevices As IEnumerable(Of DeviceData)
    Public selectedDevice As DeviceData

    Public bs_Devices As New BindingSource()

    Private Sub PoC_btn_getListOfMP3_Click(sender As Object, e As EventArgs) Handles PoC_btn_getListOfMP3.Click
        str_Status_Label.Text = "Starte ADB-Server..."
        Dim ADBserver As SharpAdbClient.AdbServer = New SharpAdbClient.AdbServer()
        Dim result = ADBserver.StartServer("C:\adb\adb.exe", True)
        Select Case result
            Case StartServerResult.AlreadyRunning
                str_Status_Label.Text = "ADB-Server lief bereits"
            Case StartServerResult.Started
                str_Status_Label.Text = "ADB-Server gestartet"
            Case StartServerResult.RestartedOutdatedDaemon
                str_Status_Label.Text = "Veralteten ADB-Server neu gestartet"
        End Select


        Dim ADBclient = New AdbClient()
        Dim AndroidDevices = ADBclient.GetDevices()

        Dim start As DateTime
        Dim stopp As DateTime

        Dim device = AndroidDevices.First()
        Dim receiver = New SharpAdbClient.ConsoleOutputReceiver()

        str_Status_Label.Text = "Ermittle Dateien (StreamWriter)..."
        start = Now()
        ADBclient.ExecuteRemoteCommand("find /sdcard/Music/ -type f -name *.mp3 -printf ""%p|%s\n""", device, receiver)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("D:\adb.txt", False, System.Text.Encoding.GetEncoding("iso-8859-1"))
        file.Write(receiver.ToString)
        file.Close()
        stopp = Now()

        MsgBox("fertig: " & (stopp - start).ToString)


        str_Status_Label.Text = "Ermittle Dateien (direkt auf Gerät)..."
        start = Now()
        ADBclient.ExecuteRemoteCommand("find /sdcard/Music/ -type f -name *.mp3 -printf ""%p|%s\n"" > /sdcard/direct.txt", device, receiver)

        str_Status_Label.Text = "Übertrage Datei..."
        Dim syncService As New SyncService(ADBclient, device)
        Dim stream = System.IO.File.OpenWrite("D:\direct.txt")
        syncService.Pull("/sdcard/direct.txt", stream, Nothing, Threading.CancellationToken.None)
        stream.Close()
        stopp = Now()

        MsgBox("fertig: " & (stopp - start).ToString)

        ADBclient.ExecuteRemoteCommand("rm /sdcard/direct.txt", device, receiver)
    End Sub

    Private Sub prepareForm()
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

        str_Status_Device.Text = "no device selected"
    End Sub

    Private Sub startADBserver()
        str_Status_Label.Text = "Starte ADB-Server..."

        ADBserver = New AdbServer()
        Dim result = ADBserver.StartServer("C:\adb\adb.exe", True)

        Select Case result
            Case StartServerResult.AlreadyRunning
                str_Status_Label.Text = "ADB-Server gestartet"
            Case StartServerResult.Started
                str_Status_Label.Text = "ADB-Server gestartet"
            Case StartServerResult.RestartedOutdatedDaemon
                str_Status_Label.Text = "ADB-Server gestartet"
            Case Else
                str_Status_Label.Text = "FEHLER"
        End Select
    End Sub

    Private Sub refreshDevices()
        availableDevices = ADBclient.GetDevices()

        bs_Devices.DataSource = availableDevices
        dgv_Devices.DataSource = bs_Devices
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        prepareForm()
        startADBserver()
        ADBclient = New AdbClient()
        refreshDevices()
    End Sub

    Private Sub btn_selectDevice_Click(sender As Object, e As EventArgs) Handles btn_selectDevice.Click
        selectedDevice = dgv_Devices.SelectedRows(0).DataBoundItem
        str_Status_Device.Text = selectedDevice.Model
    End Sub

    Private Sub btn_refreshDevices_Click(sender As Object, e As EventArgs) Handles btn_refreshDevices.Click
        refreshDevices()
    End Sub
End Class
