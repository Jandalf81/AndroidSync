<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Stack29 As WindowsControlLibrary1.Stack = New WindowsControlLibrary1.Stack()
        Dim Stack30 As WindowsControlLibrary1.Stack = New WindowsControlLibrary1.Stack()
        Dim Stack31 As WindowsControlLibrary1.Stack = New WindowsControlLibrary1.Stack()
        Dim Stack32 As WindowsControlLibrary1.Stack = New WindowsControlLibrary1.Stack()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.str_Status = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.str_Status_ADBserver = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.str_Status_Device = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grp_Devices = New System.Windows.Forms.GroupBox()
        Me.btn_refreshDevices = New System.Windows.Forms.Button()
        Me.btn_selectDevice = New System.Windows.Forms.Button()
        Me.dgv_Devices = New System.Windows.Forms.DataGridView()
        Me.tab_Control = New System.Windows.Forms.TabControl()
        Me.tab_syncFiles_SettingsPlaylists = New System.Windows.Forms.TabPage()
        Me.tableSyncFiles_SettingsPlaylists = New System.Windows.Forms.TableLayoutPanel()
        Me.grp_syncFiles_Settings = New System.Windows.Forms.GroupBox()
        Me.txt_syncFiles_basePathRemote = New System.Windows.Forms.TextBox()
        Me.txt_syncFiles_basePath_Local = New System.Windows.Forms.TextBox()
        Me.lbl_syncFiles_bastPath_Remote = New System.Windows.Forms.Label()
        Me.lbl_syncFiles_basePath_Local = New System.Windows.Forms.Label()
        Me.tab_syncRatings = New System.Windows.Forms.TabPage()
        Me.grp_selectedDevice = New System.Windows.Forms.GroupBox()
        Me.chk_hasPreset = New System.Windows.Forms.CheckBox()
        Me.txt_ModelNameProductSerial = New System.Windows.Forms.TextBox()
        Me.lbl_ModelNameProductSerial = New System.Windows.Forms.Label()
        Me.MyProgressBar1 = New WindowsControlLibrary1.myProgressBar()
        Me.lbl_DiskSpace = New System.Windows.Forms.Label()
        Me.btn_syncFiles_basePath_Local = New System.Windows.Forms.Button()
        Me.chk_syncFiles_Convert = New System.Windows.Forms.CheckBox()
        Me.lbl_syncFiles_LAMEOptions = New System.Windows.Forms.Label()
        Me.txt_syncFiles_LAMEOptions = New System.Windows.Forms.TextBox()
        Me.dgv_Playlists = New System.Windows.Forms.DataGridView()
        Me.grp_syncFiles_Playlists = New System.Windows.Forms.GroupBox()
        Me.table_syncFiles_Playlists_Buttons = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_syncFiles_Playlists_Add = New System.Windows.Forms.Button()
        Me.btn_syncFiles_Playlists_Remove = New System.Windows.Forms.Button()
        Me.str_Status.SuspendLayout()
        Me.grp_Devices.SuspendLayout()
        CType(Me.dgv_Devices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_Control.SuspendLayout()
        Me.tab_syncFiles_SettingsPlaylists.SuspendLayout()
        Me.tableSyncFiles_SettingsPlaylists.SuspendLayout()
        Me.grp_syncFiles_Settings.SuspendLayout()
        Me.grp_selectedDevice.SuspendLayout()
        CType(Me.dgv_Playlists, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_syncFiles_Playlists.SuspendLayout()
        Me.table_syncFiles_Playlists_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'str_Status
        '
        Me.str_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.str_Status_ADBserver, Me.ToolStripStatusLabel2, Me.str_Status_Device})
        Me.str_Status.Location = New System.Drawing.Point(0, 734)
        Me.str_Status.Name = "str_Status"
        Me.str_Status.Size = New System.Drawing.Size(1162, 24)
        Me.str_Status.TabIndex = 1
        Me.str_Status.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(70, 19)
        Me.ToolStripStatusLabel1.Text = "ADB-Server:"
        '
        'str_Status_ADBserver
        '
        Me.str_Status_ADBserver.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.str_Status_ADBserver.Name = "str_Status_ADBserver"
        Me.str_Status_ADBserver.Size = New System.Drawing.Size(120, 19)
        Me.str_Status_ADBserver.Text = "str_Status_ADBserver"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(45, 19)
        Me.ToolStripStatusLabel2.Text = "Device:"
        '
        'str_Status_Device
        '
        Me.str_Status_Device.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.str_Status_Device.Name = "str_Status_Device"
        Me.str_Status_Device.Size = New System.Drawing.Size(101, 19)
        Me.str_Status_Device.Text = "str_Status_Device"
        '
        'grp_Devices
        '
        Me.grp_Devices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_Devices.Controls.Add(Me.btn_refreshDevices)
        Me.grp_Devices.Controls.Add(Me.btn_selectDevice)
        Me.grp_Devices.Controls.Add(Me.dgv_Devices)
        Me.grp_Devices.Location = New System.Drawing.Point(12, 12)
        Me.grp_Devices.Name = "grp_Devices"
        Me.grp_Devices.Size = New System.Drawing.Size(1140, 175)
        Me.grp_Devices.TabIndex = 2
        Me.grp_Devices.TabStop = False
        Me.grp_Devices.Text = "Devices"
        '
        'btn_refreshDevices
        '
        Me.btn_refreshDevices.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refreshDevices.Location = New System.Drawing.Point(959, 122)
        Me.btn_refreshDevices.Name = "btn_refreshDevices"
        Me.btn_refreshDevices.Size = New System.Drawing.Size(175, 47)
        Me.btn_refreshDevices.TabIndex = 2
        Me.btn_refreshDevices.Text = "refresh Devices"
        Me.btn_refreshDevices.UseVisualStyleBackColor = True
        '
        'btn_selectDevice
        '
        Me.btn_selectDevice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_selectDevice.Location = New System.Drawing.Point(6, 122)
        Me.btn_selectDevice.Name = "btn_selectDevice"
        Me.btn_selectDevice.Size = New System.Drawing.Size(947, 47)
        Me.btn_selectDevice.TabIndex = 1
        Me.btn_selectDevice.Text = "use selected Device"
        Me.btn_selectDevice.UseVisualStyleBackColor = True
        '
        'dgv_Devices
        '
        Me.dgv_Devices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Devices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Devices.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Devices.Name = "dgv_Devices"
        Me.dgv_Devices.Size = New System.Drawing.Size(1128, 97)
        Me.dgv_Devices.TabIndex = 0
        '
        'tab_Control
        '
        Me.tab_Control.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_Control.Controls.Add(Me.tab_syncFiles_SettingsPlaylists)
        Me.tab_Control.Controls.Add(Me.tab_syncRatings)
        Me.tab_Control.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_Control.ItemSize = New System.Drawing.Size(58, 18)
        Me.tab_Control.Location = New System.Drawing.Point(10, 330)
        Me.tab_Control.Name = "tab_Control"
        Me.tab_Control.SelectedIndex = 0
        Me.tab_Control.Size = New System.Drawing.Size(1140, 401)
        Me.tab_Control.TabIndex = 3
        '
        'tab_syncFiles_SettingsPlaylists
        '
        Me.tab_syncFiles_SettingsPlaylists.BackColor = System.Drawing.SystemColors.Control
        Me.tab_syncFiles_SettingsPlaylists.Controls.Add(Me.tableSyncFiles_SettingsPlaylists)
        Me.tab_syncFiles_SettingsPlaylists.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_syncFiles_SettingsPlaylists.Location = New System.Drawing.Point(4, 22)
        Me.tab_syncFiles_SettingsPlaylists.Name = "tab_syncFiles_SettingsPlaylists"
        Me.tab_syncFiles_SettingsPlaylists.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_syncFiles_SettingsPlaylists.Size = New System.Drawing.Size(1132, 375)
        Me.tab_syncFiles_SettingsPlaylists.TabIndex = 0
        Me.tab_syncFiles_SettingsPlaylists.Text = "sync Files"
        '
        'tableSyncFiles_SettingsPlaylists
        '
        Me.tableSyncFiles_SettingsPlaylists.ColumnCount = 2
        Me.tableSyncFiles_SettingsPlaylists.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableSyncFiles_SettingsPlaylists.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableSyncFiles_SettingsPlaylists.Controls.Add(Me.grp_syncFiles_Settings, 0, 0)
        Me.tableSyncFiles_SettingsPlaylists.Controls.Add(Me.grp_syncFiles_Playlists, 1, 0)
        Me.tableSyncFiles_SettingsPlaylists.Dock = System.Windows.Forms.DockStyle.Top
        Me.tableSyncFiles_SettingsPlaylists.Location = New System.Drawing.Point(3, 3)
        Me.tableSyncFiles_SettingsPlaylists.Margin = New System.Windows.Forms.Padding(0)
        Me.tableSyncFiles_SettingsPlaylists.Name = "tableSyncFiles_SettingsPlaylists"
        Me.tableSyncFiles_SettingsPlaylists.RowCount = 1
        Me.tableSyncFiles_SettingsPlaylists.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableSyncFiles_SettingsPlaylists.Size = New System.Drawing.Size(1126, 208)
        Me.tableSyncFiles_SettingsPlaylists.TabIndex = 0
        '
        'grp_syncFiles_Settings
        '
        Me.grp_syncFiles_Settings.Controls.Add(Me.txt_syncFiles_LAMEOptions)
        Me.grp_syncFiles_Settings.Controls.Add(Me.lbl_syncFiles_LAMEOptions)
        Me.grp_syncFiles_Settings.Controls.Add(Me.chk_syncFiles_Convert)
        Me.grp_syncFiles_Settings.Controls.Add(Me.btn_syncFiles_basePath_Local)
        Me.grp_syncFiles_Settings.Controls.Add(Me.txt_syncFiles_basePathRemote)
        Me.grp_syncFiles_Settings.Controls.Add(Me.txt_syncFiles_basePath_Local)
        Me.grp_syncFiles_Settings.Controls.Add(Me.lbl_syncFiles_bastPath_Remote)
        Me.grp_syncFiles_Settings.Controls.Add(Me.lbl_syncFiles_basePath_Local)
        Me.grp_syncFiles_Settings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grp_syncFiles_Settings.Location = New System.Drawing.Point(6, 6)
        Me.grp_syncFiles_Settings.Margin = New System.Windows.Forms.Padding(6, 6, 3, 3)
        Me.grp_syncFiles_Settings.Name = "grp_syncFiles_Settings"
        Me.grp_syncFiles_Settings.Size = New System.Drawing.Size(554, 199)
        Me.grp_syncFiles_Settings.TabIndex = 0
        Me.grp_syncFiles_Settings.TabStop = False
        Me.grp_syncFiles_Settings.Text = "Settings"
        '
        'txt_syncFiles_basePathRemote
        '
        Me.txt_syncFiles_basePathRemote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_syncFiles_basePathRemote.Location = New System.Drawing.Point(110, 42)
        Me.txt_syncFiles_basePathRemote.Name = "txt_syncFiles_basePathRemote"
        Me.txt_syncFiles_basePathRemote.Size = New System.Drawing.Size(375, 20)
        Me.txt_syncFiles_basePathRemote.TabIndex = 3
        '
        'txt_syncFiles_basePath_Local
        '
        Me.txt_syncFiles_basePath_Local.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_syncFiles_basePath_Local.Location = New System.Drawing.Point(110, 16)
        Me.txt_syncFiles_basePath_Local.Name = "txt_syncFiles_basePath_Local"
        Me.txt_syncFiles_basePath_Local.ReadOnly = True
        Me.txt_syncFiles_basePath_Local.Size = New System.Drawing.Size(375, 20)
        Me.txt_syncFiles_basePath_Local.TabIndex = 2
        '
        'lbl_syncFiles_bastPath_Remote
        '
        Me.lbl_syncFiles_bastPath_Remote.AutoSize = True
        Me.lbl_syncFiles_bastPath_Remote.Location = New System.Drawing.Point(6, 45)
        Me.lbl_syncFiles_bastPath_Remote.Name = "lbl_syncFiles_bastPath_Remote"
        Me.lbl_syncFiles_bastPath_Remote.Size = New System.Drawing.Size(98, 13)
        Me.lbl_syncFiles_bastPath_Remote.TabIndex = 1
        Me.lbl_syncFiles_bastPath_Remote.Text = "base Path Remote:"
        '
        'lbl_syncFiles_basePath_Local
        '
        Me.lbl_syncFiles_basePath_Local.AutoSize = True
        Me.lbl_syncFiles_basePath_Local.Location = New System.Drawing.Point(6, 19)
        Me.lbl_syncFiles_basePath_Local.Name = "lbl_syncFiles_basePath_Local"
        Me.lbl_syncFiles_basePath_Local.Size = New System.Drawing.Size(87, 13)
        Me.lbl_syncFiles_basePath_Local.TabIndex = 0
        Me.lbl_syncFiles_basePath_Local.Text = "base Path Local:"
        '
        'tab_syncRatings
        '
        Me.tab_syncRatings.BackColor = System.Drawing.SystemColors.Control
        Me.tab_syncRatings.Location = New System.Drawing.Point(4, 22)
        Me.tab_syncRatings.Name = "tab_syncRatings"
        Me.tab_syncRatings.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_syncRatings.Size = New System.Drawing.Size(1132, 375)
        Me.tab_syncRatings.TabIndex = 1
        Me.tab_syncRatings.Text = "sync Ratings"
        '
        'grp_selectedDevice
        '
        Me.grp_selectedDevice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_selectedDevice.Controls.Add(Me.chk_hasPreset)
        Me.grp_selectedDevice.Controls.Add(Me.txt_ModelNameProductSerial)
        Me.grp_selectedDevice.Controls.Add(Me.lbl_ModelNameProductSerial)
        Me.grp_selectedDevice.Controls.Add(Me.MyProgressBar1)
        Me.grp_selectedDevice.Controls.Add(Me.lbl_DiskSpace)
        Me.grp_selectedDevice.Location = New System.Drawing.Point(12, 193)
        Me.grp_selectedDevice.Name = "grp_selectedDevice"
        Me.grp_selectedDevice.Size = New System.Drawing.Size(1140, 110)
        Me.grp_selectedDevice.TabIndex = 4
        Me.grp_selectedDevice.TabStop = False
        Me.grp_selectedDevice.Text = "selected Device"
        '
        'chk_hasPreset
        '
        Me.chk_hasPreset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_hasPreset.AutoCheck = False
        Me.chk_hasPreset.AutoSize = True
        Me.chk_hasPreset.Location = New System.Drawing.Point(1055, 18)
        Me.chk_hasPreset.Name = "chk_hasPreset"
        Me.chk_hasPreset.Size = New System.Drawing.Size(76, 17)
        Me.chk_hasPreset.TabIndex = 8
        Me.chk_hasPreset.Text = "has Preset"
        Me.chk_hasPreset.UseVisualStyleBackColor = True
        '
        'txt_ModelNameProductSerial
        '
        Me.txt_ModelNameProductSerial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_ModelNameProductSerial.Location = New System.Drawing.Point(135, 16)
        Me.txt_ModelNameProductSerial.Name = "txt_ModelNameProductSerial"
        Me.txt_ModelNameProductSerial.ReadOnly = True
        Me.txt_ModelNameProductSerial.Size = New System.Drawing.Size(914, 20)
        Me.txt_ModelNameProductSerial.TabIndex = 7
        '
        'lbl_ModelNameProductSerial
        '
        Me.lbl_ModelNameProductSerial.AutoSize = True
        Me.lbl_ModelNameProductSerial.Location = New System.Drawing.Point(6, 19)
        Me.lbl_ModelNameProductSerial.Name = "lbl_ModelNameProductSerial"
        Me.lbl_ModelNameProductSerial.Size = New System.Drawing.Size(123, 13)
        Me.lbl_ModelNameProductSerial.TabIndex = 6
        Me.lbl_ModelNameProductSerial.Text = "Model / Name / Product"
        '
        'MyProgressBar1
        '
        Me.MyProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MyProgressBar1.BackColor = System.Drawing.SystemColors.Control
        Me.MyProgressBar1.Location = New System.Drawing.Point(135, 42)
        Me.MyProgressBar1.MinimumSize = New System.Drawing.Size(100, 20)
        Me.MyProgressBar1.Name = "MyProgressBar1"
        Me.MyProgressBar1.Size = New System.Drawing.Size(996, 20)
        Stack29.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Stack29.MaxValue = 80
        Stack30.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Stack30.MaxValue = 90
        Stack31.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Stack31.MaxValue = 95
        Stack32.Color = System.Drawing.Color.Red
        Stack32.MaxValue = 100
        Me.MyProgressBar1.stacks.Add(Stack29)
        Me.MyProgressBar1.stacks.Add(Stack30)
        Me.MyProgressBar1.stacks.Add(Stack31)
        Me.MyProgressBar1.stacks.Add(Stack32)
        Me.MyProgressBar1.TabIndex = 5
        '
        'lbl_DiskSpace
        '
        Me.lbl_DiskSpace.AutoSize = True
        Me.lbl_DiskSpace.Location = New System.Drawing.Point(6, 45)
        Me.lbl_DiskSpace.Name = "lbl_DiskSpace"
        Me.lbl_DiskSpace.Size = New System.Drawing.Size(65, 13)
        Me.lbl_DiskSpace.TabIndex = 4
        Me.lbl_DiskSpace.Text = "Disk Space:"
        '
        'btn_syncFiles_basePath_Local
        '
        Me.btn_syncFiles_basePath_Local.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_syncFiles_basePath_Local.Location = New System.Drawing.Point(491, 14)
        Me.btn_syncFiles_basePath_Local.Name = "btn_syncFiles_basePath_Local"
        Me.btn_syncFiles_basePath_Local.Size = New System.Drawing.Size(57, 23)
        Me.btn_syncFiles_basePath_Local.TabIndex = 4
        Me.btn_syncFiles_basePath_Local.Text = "Set"
        Me.btn_syncFiles_basePath_Local.UseVisualStyleBackColor = True
        '
        'chk_syncFiles_Convert
        '
        Me.chk_syncFiles_Convert.AutoSize = True
        Me.chk_syncFiles_Convert.Location = New System.Drawing.Point(110, 68)
        Me.chk_syncFiles_Convert.Name = "chk_syncFiles_Convert"
        Me.chk_syncFiles_Convert.Size = New System.Drawing.Size(138, 17)
        Me.chk_syncFiles_Convert.TabIndex = 5
        Me.chk_syncFiles_Convert.Text = "Convert files with LAME"
        Me.chk_syncFiles_Convert.UseVisualStyleBackColor = True
        '
        'lbl_syncFiles_LAMEOptions
        '
        Me.lbl_syncFiles_LAMEOptions.AutoSize = True
        Me.lbl_syncFiles_LAMEOptions.Location = New System.Drawing.Point(6, 94)
        Me.lbl_syncFiles_LAMEOptions.Name = "lbl_syncFiles_LAMEOptions"
        Me.lbl_syncFiles_LAMEOptions.Size = New System.Drawing.Size(76, 13)
        Me.lbl_syncFiles_LAMEOptions.TabIndex = 6
        Me.lbl_syncFiles_LAMEOptions.Text = "LAME options:"
        '
        'txt_syncFiles_LAMEOptions
        '
        Me.txt_syncFiles_LAMEOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_syncFiles_LAMEOptions.Location = New System.Drawing.Point(110, 91)
        Me.txt_syncFiles_LAMEOptions.Name = "txt_syncFiles_LAMEOptions"
        Me.txt_syncFiles_LAMEOptions.Size = New System.Drawing.Size(438, 20)
        Me.txt_syncFiles_LAMEOptions.TabIndex = 7
        '
        'dgv_Playlists
        '
        Me.dgv_Playlists.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Playlists.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgv_Playlists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Playlists.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgv_Playlists.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Playlists.Name = "dgv_Playlists"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Playlists.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgv_Playlists.Size = New System.Drawing.Size(542, 115)
        Me.dgv_Playlists.TabIndex = 0
        '
        'grp_syncFiles_Playlists
        '
        Me.grp_syncFiles_Playlists.Controls.Add(Me.table_syncFiles_Playlists_Buttons)
        Me.grp_syncFiles_Playlists.Controls.Add(Me.dgv_Playlists)
        Me.grp_syncFiles_Playlists.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grp_syncFiles_Playlists.Location = New System.Drawing.Point(569, 6)
        Me.grp_syncFiles_Playlists.Margin = New System.Windows.Forms.Padding(6, 6, 3, 3)
        Me.grp_syncFiles_Playlists.Name = "grp_syncFiles_Playlists"
        Me.grp_syncFiles_Playlists.Size = New System.Drawing.Size(554, 199)
        Me.grp_syncFiles_Playlists.TabIndex = 1
        Me.grp_syncFiles_Playlists.TabStop = False
        Me.grp_syncFiles_Playlists.Text = "Playlists"
        '
        'table_syncFiles_Playlists_Buttons
        '
        Me.table_syncFiles_Playlists_Buttons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.table_syncFiles_Playlists_Buttons.ColumnCount = 2
        Me.table_syncFiles_Playlists_Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.table_syncFiles_Playlists_Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.table_syncFiles_Playlists_Buttons.Controls.Add(Me.btn_syncFiles_Playlists_Add, 0, 0)
        Me.table_syncFiles_Playlists_Buttons.Controls.Add(Me.btn_syncFiles_Playlists_Remove, 1, 0)
        Me.table_syncFiles_Playlists_Buttons.Location = New System.Drawing.Point(6, 137)
        Me.table_syncFiles_Playlists_Buttons.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.table_syncFiles_Playlists_Buttons.Name = "table_syncFiles_Playlists_Buttons"
        Me.table_syncFiles_Playlists_Buttons.RowCount = 1
        Me.table_syncFiles_Playlists_Buttons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.table_syncFiles_Playlists_Buttons.Size = New System.Drawing.Size(542, 59)
        Me.table_syncFiles_Playlists_Buttons.TabIndex = 1
        '
        'btn_syncFiles_Playlists_Add
        '
        Me.btn_syncFiles_Playlists_Add.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_syncFiles_Playlists_Add.Location = New System.Drawing.Point(0, 0)
        Me.btn_syncFiles_Playlists_Add.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.btn_syncFiles_Playlists_Add.Name = "btn_syncFiles_Playlists_Add"
        Me.btn_syncFiles_Playlists_Add.Size = New System.Drawing.Size(268, 59)
        Me.btn_syncFiles_Playlists_Add.TabIndex = 0
        Me.btn_syncFiles_Playlists_Add.Text = "add Playlist"
        Me.btn_syncFiles_Playlists_Add.UseVisualStyleBackColor = True
        '
        'btn_syncFiles_Playlists_Remove
        '
        Me.btn_syncFiles_Playlists_Remove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_syncFiles_Playlists_Remove.Location = New System.Drawing.Point(274, 0)
        Me.btn_syncFiles_Playlists_Remove.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_syncFiles_Playlists_Remove.Name = "btn_syncFiles_Playlists_Remove"
        Me.btn_syncFiles_Playlists_Remove.Size = New System.Drawing.Size(268, 59)
        Me.btn_syncFiles_Playlists_Remove.TabIndex = 1
        Me.btn_syncFiles_Playlists_Remove.Text = "remove Playlist"
        Me.btn_syncFiles_Playlists_Remove.UseVisualStyleBackColor = True
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 758)
        Me.Controls.Add(Me.grp_selectedDevice)
        Me.Controls.Add(Me.tab_Control)
        Me.Controls.Add(Me.grp_Devices)
        Me.Controls.Add(Me.str_Status)
        Me.Name = "frm_Main"
        Me.Text = "AndroidSync"
        Me.str_Status.ResumeLayout(False)
        Me.str_Status.PerformLayout()
        Me.grp_Devices.ResumeLayout(False)
        CType(Me.dgv_Devices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_Control.ResumeLayout(False)
        Me.tab_syncFiles_SettingsPlaylists.ResumeLayout(False)
        Me.tableSyncFiles_SettingsPlaylists.ResumeLayout(False)
        Me.grp_syncFiles_Settings.ResumeLayout(False)
        Me.grp_syncFiles_Settings.PerformLayout()
        Me.grp_selectedDevice.ResumeLayout(False)
        Me.grp_selectedDevice.PerformLayout()
        CType(Me.dgv_Playlists, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_syncFiles_Playlists.ResumeLayout(False)
        Me.table_syncFiles_Playlists_Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents str_Status As StatusStrip
    Friend WithEvents str_Status_ADBserver As ToolStripStatusLabel
    Friend WithEvents grp_Devices As GroupBox
    Friend WithEvents dgv_Devices As DataGridView
    Friend WithEvents btn_selectDevice As Button
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents str_Status_Device As ToolStripStatusLabel
    Friend WithEvents btn_refreshDevices As Button
    Friend WithEvents tab_Control As TabControl
    Friend WithEvents tab_syncFiles_SettingsPlaylists As TabPage
    Friend WithEvents tab_syncRatings As TabPage
    Friend WithEvents grp_selectedDevice As GroupBox
    Friend WithEvents MyProgressBar1 As WindowsControlLibrary1.myProgressBar
    Friend WithEvents lbl_DiskSpace As Label
    Friend WithEvents chk_hasPreset As CheckBox
    Friend WithEvents txt_ModelNameProductSerial As TextBox
    Friend WithEvents lbl_ModelNameProductSerial As Label
    Friend WithEvents tableSyncFiles_SettingsPlaylists As TableLayoutPanel
    Friend WithEvents grp_syncFiles_Settings As GroupBox
    Friend WithEvents lbl_syncFiles_basePath_Local As Label
    Friend WithEvents txt_syncFiles_basePathRemote As TextBox
    Friend WithEvents txt_syncFiles_basePath_Local As TextBox
    Friend WithEvents lbl_syncFiles_bastPath_Remote As Label
    Friend WithEvents txt_syncFiles_LAMEOptions As TextBox
    Friend WithEvents lbl_syncFiles_LAMEOptions As Label
    Friend WithEvents chk_syncFiles_Convert As CheckBox
    Friend WithEvents btn_syncFiles_basePath_Local As Button
    Friend WithEvents grp_syncFiles_Playlists As GroupBox
    Friend WithEvents dgv_Playlists As DataGridView
    Friend WithEvents table_syncFiles_Playlists_Buttons As TableLayoutPanel
    Friend WithEvents btn_syncFiles_Playlists_Add As Button
    Friend WithEvents btn_syncFiles_Playlists_Remove As Button
End Class
