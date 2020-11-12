Public Class frm_AndroidTree
    Private device As AndroidDevice
    Public rootNode As TreeNode
    Public selectedPath As String

    Public cancelOrder As Boolean = False

    Public Sub New(device As AndroidDevice)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.device = device
    End Sub

    Private Sub frm_AndroidTree_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Cursor = Cursors.AppStarting

        rootNode = New TreeNode(device.Model)
        trv_AndroidTree.Nodes.Add(rootNode)

        str_Task.Text = "Populating TreeView..."
        Application.DoEvents()

        ' getting root nodes
        Dim sdcards() As String = device.executeCommand("ls -1d /sdcard*").Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        For Each sdcard In sdcards
            sdcard = sdcard.Replace("/", "")

            Dim newNode As New TreeNode(sdcard)
            rootNode.Nodes.Add(newNode)

            addSubNodes(newNode.FullPath.Replace(device.Model, "").Replace("\", "/"), newNode)
        Next

        str_Task.Text = "Done"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub addSubNodes(path As String, parentNode As TreeNode)
        If (cancelOrder = True) Then Exit Sub

        Dim subdirs As List(Of String) = device.getSubdirectories(path)

        Application.DoEvents()

        For Each subdir In subdirs
            subdir = subdir.Replace("\", "")
            Dim newNode As New TreeNode(subdir)
            parentNode.Nodes.Add(newNode)

            addSubNodes(parentNode.FullPath.Replace(device.Model, "").Replace("\", "/") & "/" & subdir, newNode)
        Next
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        ' ToDo: return selected path from TreeView
        Me.selectedPath = trv_AndroidTree.SelectedNode.FullPath.Replace(device.Model, "").Replace("\", "/")

        If (Me.selectedPath = "") Then
            MsgBox("Fehler", vbOKOnly)
            Exit Sub
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        cancelOrder = True

        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class