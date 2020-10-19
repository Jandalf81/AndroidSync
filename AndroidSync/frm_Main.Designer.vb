<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
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
        Me.PoC_btn_getListOfMP3 = New System.Windows.Forms.Button()
        Me.str_Status = New System.Windows.Forms.StatusStrip()
        Me.str_Status_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grp_Devices = New System.Windows.Forms.GroupBox()
        Me.btn_selectDevice = New System.Windows.Forms.Button()
        Me.dgv_Devices = New System.Windows.Forms.DataGridView()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.str_Status_Device = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btn_refreshDevices = New System.Windows.Forms.Button()
        Me.str_Status.SuspendLayout()
        Me.grp_Devices.SuspendLayout()
        CType(Me.dgv_Devices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PoC_btn_getListOfMP3
        '
        Me.PoC_btn_getListOfMP3.Location = New System.Drawing.Point(12, 12)
        Me.PoC_btn_getListOfMP3.Name = "PoC_btn_getListOfMP3"
        Me.PoC_btn_getListOfMP3.Size = New System.Drawing.Size(193, 44)
        Me.PoC_btn_getListOfMP3.TabIndex = 0
        Me.PoC_btn_getListOfMP3.Text = "PoC_btn_getListOfMP3"
        Me.PoC_btn_getListOfMP3.UseVisualStyleBackColor = True
        '
        'str_Status
        '
        Me.str_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.str_Status_Label, Me.ToolStripStatusLabel2, Me.str_Status_Device})
        Me.str_Status.Location = New System.Drawing.Point(0, 605)
        Me.str_Status.Name = "str_Status"
        Me.str_Status.Size = New System.Drawing.Size(829, 24)
        Me.str_Status.TabIndex = 1
        Me.str_Status.Text = "StatusStrip1"
        '
        'str_Status_Label
        '
        Me.str_Status_Label.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.str_Status_Label.Name = "str_Status_Label"
        Me.str_Status_Label.Size = New System.Drawing.Size(94, 19)
        Me.str_Status_Label.Text = "str_Status_Label"
        '
        'grp_Devices
        '
        Me.grp_Devices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_Devices.Controls.Add(Me.btn_refreshDevices)
        Me.grp_Devices.Controls.Add(Me.btn_selectDevice)
        Me.grp_Devices.Controls.Add(Me.dgv_Devices)
        Me.grp_Devices.Location = New System.Drawing.Point(12, 62)
        Me.grp_Devices.Name = "grp_Devices"
        Me.grp_Devices.Size = New System.Drawing.Size(807, 228)
        Me.grp_Devices.TabIndex = 2
        Me.grp_Devices.TabStop = False
        Me.grp_Devices.Text = "Devices"
        '
        'btn_selectDevice
        '
        Me.btn_selectDevice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_selectDevice.Location = New System.Drawing.Point(6, 175)
        Me.btn_selectDevice.Name = "btn_selectDevice"
        Me.btn_selectDevice.Size = New System.Drawing.Size(614, 47)
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
        Me.dgv_Devices.Size = New System.Drawing.Size(795, 150)
        Me.dgv_Devices.TabIndex = 0
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 19)
        Me.ToolStripStatusLabel1.Text = "Status:"
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
        'btn_refreshDevices
        '
        Me.btn_refreshDevices.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refreshDevices.Location = New System.Drawing.Point(626, 175)
        Me.btn_refreshDevices.Name = "btn_refreshDevices"
        Me.btn_refreshDevices.Size = New System.Drawing.Size(175, 47)
        Me.btn_refreshDevices.TabIndex = 2
        Me.btn_refreshDevices.Text = "refresh Devices"
        Me.btn_refreshDevices.UseVisualStyleBackColor = True
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 629)
        Me.Controls.Add(Me.grp_Devices)
        Me.Controls.Add(Me.str_Status)
        Me.Controls.Add(Me.PoC_btn_getListOfMP3)
        Me.Name = "frm_Main"
        Me.Text = "Form1"
        Me.str_Status.ResumeLayout(False)
        Me.str_Status.PerformLayout()
        Me.grp_Devices.ResumeLayout(False)
        CType(Me.dgv_Devices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PoC_btn_getListOfMP3 As Button
    Friend WithEvents str_Status As StatusStrip
    Friend WithEvents str_Status_Label As ToolStripStatusLabel
    Friend WithEvents grp_Devices As GroupBox
    Friend WithEvents dgv_Devices As DataGridView
    Friend WithEvents btn_selectDevice As Button
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents str_Status_Device As ToolStripStatusLabel
    Friend WithEvents btn_refreshDevices As Button
End Class
