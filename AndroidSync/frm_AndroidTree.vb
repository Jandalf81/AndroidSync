Public Class frm_AndroidTree
    Private device As AndroidDevice
    Public rootNode As TreeNode
    Public selectedPath As String

    Public imageList As New ImageList()

    Public cancelOrder As Boolean = False

    Public Sub New(device As AndroidDevice)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.device = device
    End Sub

    Private Sub frm_AndroidTree_Load(sender As Object, e As EventArgs) Handles Me.Load
        imageList.Images.Add(My.Resources.ipod)
        imageList.Images.Add(My.Resources.drive)
        imageList.Images.Add(My.Resources.folder)

        trv_AndroidTree.ImageList = imageList

        trv_AndroidTree.PathSeparator = "/"
        trv_AndroidTree.ImageKey = 1
        trv_AndroidTree.SelectedImageIndex = 1
    End Sub

    Private Sub frm_AndroidTree_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Cursor = Cursors.AppStarting

        rootNode = New TreeNode(device.Model)
        rootNode.Name = device.Model
        rootNode.ImageIndex = 0
        rootNode.SelectedImageIndex = 0

        trv_AndroidTree.Nodes.Add(rootNode)

        str_Task.Text = "Populating TreeView..."
        Application.DoEvents()

        populateTreeView()

        str_Task.Text = "Done"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub populateTreeView()
        ' ToDo: can this be moved into a backgroundworker to keep the UI responsive?
        str_Task.Text = "Getting directory listing from device..."
        Dim lines() As String = device.executeCommand("find /sdcard*/ -type d | sort").Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        str_Task.Text = "Populating TreeView..."
        For Each line In lines
            If (cancelOrder = True) Then Exit Sub

            line = System.Text.RegularExpressions.Regex.Replace(line, "/$", "")

            Dim directories() As String = line.Split({"/"}, StringSplitOptions.RemoveEmptyEntries)

            Select Case UBound(directories)
                Case = 0
                    ' create new node
                    Dim newNode As New TreeNode(directories(0))
                    newNode.Name = line
                    newNode.ImageIndex = 1
                    newNode.SelectedImageIndex = 1

                    ' add new node to ROOTNODE
                    rootNode.Nodes.Add(newNode)
                    rootNode.Expand()
                    newNode.Expand()
                Case Else
                    ' create new node
                    Dim newNode As New TreeNode(directories.Last)
                    newNode.Name = line
                    newNode.ImageIndex = 2
                    newNode.SelectedImageIndex = 2

                    ' get PARENTNODE to newly created node
                    ' replace special REGEX chars in directory names
                    Dim toBeReplaced As String = replaceSpecialChars(directories.Last)
                    toBeReplaced = "/" & toBeReplaced & "$"
                    Dim fullPathParent = System.Text.RegularExpressions.Regex.Replace(line, toBeReplaced, "")
                    Dim parentNode As TreeNode = trv_AndroidTree.Nodes.Find(fullPathParent, True).First

                    ' add new node to PARENTNODE
                    parentNode.Nodes.Add(newNode)
            End Select

            Application.DoEvents()
        Next
    End Sub

    Private Function replaceSpecialChars(input As String) As String
        Dim specialCharacters As String = "()[].?^$+"

        For Each c In specialCharacters
            input = input.Replace(c, "\" & c)
        Next

        Return input
    End Function

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Me.selectedPath = trv_AndroidTree.SelectedNode.FullPath.Replace(device.Model, "")

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