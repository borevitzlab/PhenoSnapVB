﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhenoSnap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhenoSnap))
        Me.txtBarcodeValue = New System.Windows.Forms.TextBox()
        Me.txtURL1 = New System.Windows.Forms.TextBox()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.txtExpID = New System.Windows.Forms.TextBox()
        Me.lblExpID = New System.Windows.Forms.Label()
        Me.lblBarcodeValue = New System.Windows.Forms.Label()
        Me.lblCam1URL = New System.Windows.Forms.Label()
        Me.lblIDNote = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLastImageName = New System.Windows.Forms.Label()
        Me.lblLastPlant = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFileSavePath = New System.Windows.Forms.TextBox()
        Me.btnOpenImFolder = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintGraphicControl = New System.Drawing.Printing.PrintDocument()
        Me.pctQR = New System.Windows.Forms.PictureBox()
        Me.btnGetQR = New System.Windows.Forms.Button()
        Me.btnListPrinters = New System.Windows.Forms.Button()
        Me.btnPrintLabel = New System.Windows.Forms.Button()
        Me.panPrintButtons = New System.Windows.Forms.Panel()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnCheckCam = New System.Windows.Forms.Button()
        Me.lblCurBarcode = New System.Windows.Forms.Label()
        Me.chkAutoPrint = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPathToDB = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSelectSaveFolder = New System.Windows.Forms.Button()
        Me.btnSelectDB = New System.Windows.Forms.Button()
        Me.txtURL2 = New System.Windows.Forms.TextBox()
        Me.pctCam2LastIm = New System.Windows.Forms.PictureBox()
        Me.chkUseCam2 = New System.Windows.Forms.CheckBox()
        Me.tmrCapTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblLastPlantScanned = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblCam2LastImage = New System.Windows.Forms.Label()
        Me.pnlQRCodes = New System.Windows.Forms.Panel()
        Me.btnReloadDB = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbCam1CamType = New System.Windows.Forms.ComboBox()
        Me.cmbCam2CamType = New System.Windows.Forms.ComboBox()
        Me.lblCamType = New System.Windows.Forms.Label()
        Me.lblWebCam1Info = New System.Windows.Forms.Label()
        Me.pctCam1LastImage = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblUnused = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.txtBrightness = New System.Windows.Forms.TextBox()
        Me.btnICCapture = New System.Windows.Forms.Button()
        Me.btnICSet = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnICOptions = New System.Windows.Forms.Button()
        Me.lblICLocation = New System.Windows.Forms.Label()
        Me.txtCountDownTimeSecs = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.VideoSourcePlayer1 = New AForge.Controls.VideoSourcePlayer()
        Me.cmbVideoModes = New System.Windows.Forms.ComboBox()
        Me.cmbVideoSource = New System.Windows.Forms.ComboBox()
        Me.pctImageLiveImage = New System.Windows.Forms.PictureBox()
        Me.btnReloadWebcam = New System.Windows.Forms.Button()
        Me.trkFocus = New System.Windows.Forms.TrackBar()
        Me.lblFocus = New System.Windows.Forms.Label()
        Me.lblWebCamFocus = New System.Windows.Forms.Label()
        Me.lblWebCamResolution = New System.Windows.Forms.Label()
        Me.pnlWebCamControls = New System.Windows.Forms.Panel()
        Me.chkBeepOnCapture = New System.Windows.Forms.CheckBox()
        Me.tmrSetVideoSize = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pctQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panPrintButtons.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctCam2LastIm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlQRCodes.SuspendLayout()
        CType(Me.pctCam1LastImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pctImageLiveImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkFocus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWebCamControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBarcodeValue
        '
        Me.txtBarcodeValue.CausesValidation = False
        Me.txtBarcodeValue.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcodeValue.Location = New System.Drawing.Point(11, 6)
        Me.txtBarcodeValue.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBarcodeValue.Name = "txtBarcodeValue"
        Me.txtBarcodeValue.Size = New System.Drawing.Size(81, 26)
        Me.txtBarcodeValue.TabIndex = 0
        Me.txtBarcodeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtURL1
        '
        Me.txtURL1.AcceptsReturn = True
        Me.txtURL1.Font = New System.Drawing.Font("Trebuchet MS", 10.0!)
        Me.txtURL1.Location = New System.Drawing.Point(113, 186)
        Me.txtURL1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtURL1.Name = "txtURL1"
        Me.txtURL1.Size = New System.Drawing.Size(395, 23)
        Me.txtURL1.TabIndex = 1
        Me.txtURL1.Text = "http://150.203.36.26/axis-cgi/jpg/image.cgi"
        '
        'txtOutput
        '
        Me.txtOutput.AcceptsReturn = True
        Me.txtOutput.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(11, 374)
        Me.txtOutput.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(620, 44)
        Me.txtOutput.TabIndex = 4
        '
        'txtExpID
        '
        Me.txtExpID.AcceptsReturn = True
        Me.txtExpID.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpID.Location = New System.Drawing.Point(111, 42)
        Me.txtExpID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtExpID.Name = "txtExpID"
        Me.txtExpID.Size = New System.Drawing.Size(99, 26)
        Me.txtExpID.TabIndex = 5
        Me.txtExpID.Text = "BVZ0047"
        '
        'lblExpID
        '
        Me.lblExpID.AutoSize = True
        Me.lblExpID.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpID.Location = New System.Drawing.Point(51, 44)
        Me.lblExpID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpID.Name = "lblExpID"
        Me.lblExpID.Size = New System.Drawing.Size(56, 22)
        Me.lblExpID.TabIndex = 6
        Me.lblExpID.Text = "EXP ID"
        Me.lblExpID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBarcodeValue
        '
        Me.lblBarcodeValue.AutoSize = True
        Me.lblBarcodeValue.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarcodeValue.Location = New System.Drawing.Point(34, 329)
        Me.lblBarcodeValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBarcodeValue.Name = "lblBarcodeValue"
        Me.lblBarcodeValue.Size = New System.Drawing.Size(68, 22)
        Me.lblBarcodeValue.TabIndex = 7
        Me.lblBarcodeValue.Text = "Barcode"
        Me.lblBarcodeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCam1URL
        '
        Me.lblCam1URL.AutoSize = True
        Me.lblCam1URL.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCam1URL.Location = New System.Drawing.Point(33, 186)
        Me.lblCam1URL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCam1URL.Name = "lblCam1URL"
        Me.lblCam1URL.Size = New System.Drawing.Size(79, 22)
        Me.lblCam1URL.TabIndex = 8
        Me.lblCam1URL.Text = "Cam URL:"
        Me.lblCam1URL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIDNote
        '
        Me.lblIDNote.AutoSize = True
        Me.lblIDNote.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDNote.Location = New System.Drawing.Point(96, 8)
        Me.lblIDNote.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIDNote.Name = "lblIDNote"
        Me.lblIDNote.Size = New System.Drawing.Size(314, 22)
        Me.lblIDNote.TabIndex = 9
        Me.lblIDNote.Text = "<-- Place cursor in box and scan plant label"
        Me.lblIDNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 351)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 22)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Messages"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastImageName
        '
        Me.lblLastImageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastImageName.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastImageName.Location = New System.Drawing.Point(88, 303)
        Me.lblLastImageName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLastImageName.Name = "lblLastImageName"
        Me.lblLastImageName.Size = New System.Drawing.Size(462, 30)
        Me.lblLastImageName.TabIndex = 11
        Me.lblLastImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLastPlant
        '
        Me.lblLastPlant.AutoSize = True
        Me.lblLastPlant.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastPlant.Location = New System.Drawing.Point(119, 329)
        Me.lblLastPlant.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLastPlant.Name = "lblLastPlant"
        Me.lblLastPlant.Size = New System.Drawing.Size(130, 22)
        Me.lblLastPlant.TabIndex = 12
        Me.lblLastPlant.Text = "Last Image Name"
        Me.lblLastPlant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 22)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Save Folder:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFileSavePath
        '
        Me.txtFileSavePath.AcceptsReturn = True
        Me.txtFileSavePath.Font = New System.Drawing.Font("Trebuchet MS", 10.0!)
        Me.txtFileSavePath.Location = New System.Drawing.Point(112, 71)
        Me.txtFileSavePath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFileSavePath.Name = "txtFileSavePath"
        Me.txtFileSavePath.Size = New System.Drawing.Size(357, 23)
        Me.txtFileSavePath.TabIndex = 13
        Me.txtFileSavePath.Text = "C:\a_data\TimeStreams\Atkins\BVZ0047"
        '
        'btnOpenImFolder
        '
        Me.btnOpenImFolder.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenImFolder.Location = New System.Drawing.Point(508, 70)
        Me.btnOpenImFolder.Margin = New System.Windows.Forms.Padding(0)
        Me.btnOpenImFolder.Name = "btnOpenImFolder"
        Me.btnOpenImFolder.Size = New System.Drawing.Size(108, 28)
        Me.btnOpenImFolder.TabIndex = 15
        Me.btnOpenImFolder.Text = "Open Folder"
        Me.btnOpenImFolder.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'pctQR
        '
        Me.pctQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctQR.Location = New System.Drawing.Point(4, 7)
        Me.pctQR.Margin = New System.Windows.Forms.Padding(2)
        Me.pctQR.Name = "pctQR"
        Me.pctQR.Size = New System.Drawing.Size(90, 102)
        Me.pctQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctQR.TabIndex = 16
        Me.pctQR.TabStop = False
        '
        'btnGetQR
        '
        Me.btnGetQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnGetQR.Location = New System.Drawing.Point(5, 3)
        Me.btnGetQR.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGetQR.Name = "btnGetQR"
        Me.btnGetQR.Size = New System.Drawing.Size(53, 20)
        Me.btnGetQR.TabIndex = 17
        Me.btnGetQR.Text = "GetQR"
        Me.btnGetQR.UseVisualStyleBackColor = True
        '
        'btnListPrinters
        '
        Me.btnListPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnListPrinters.Location = New System.Drawing.Point(5, 24)
        Me.btnListPrinters.Margin = New System.Windows.Forms.Padding(0)
        Me.btnListPrinters.Name = "btnListPrinters"
        Me.btnListPrinters.Size = New System.Drawing.Size(53, 20)
        Me.btnListPrinters.TabIndex = 18
        Me.btnListPrinters.Text = "List Printers"
        Me.btnListPrinters.UseVisualStyleBackColor = True
        '
        'btnPrintLabel
        '
        Me.btnPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnPrintLabel.Location = New System.Drawing.Point(5, 44)
        Me.btnPrintLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPrintLabel.Name = "btnPrintLabel"
        Me.btnPrintLabel.Size = New System.Drawing.Size(53, 20)
        Me.btnPrintLabel.TabIndex = 19
        Me.btnPrintLabel.Text = "Print Label"
        Me.btnPrintLabel.UseVisualStyleBackColor = True
        '
        'panPrintButtons
        '
        Me.panPrintButtons.Controls.Add(Me.btnImport)
        Me.panPrintButtons.Controls.Add(Me.btnGetQR)
        Me.panPrintButtons.Controls.Add(Me.btnPrintLabel)
        Me.panPrintButtons.Controls.Add(Me.btnListPrinters)
        Me.panPrintButtons.Location = New System.Drawing.Point(98, 6)
        Me.panPrintButtons.Margin = New System.Windows.Forms.Padding(2)
        Me.panPrintButtons.Name = "panPrintButtons"
        Me.panPrintButtons.Size = New System.Drawing.Size(65, 102)
        Me.panPrintButtons.TabIndex = 20
        '
        'btnImport
        '
        Me.btnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnImport.Location = New System.Drawing.Point(5, 74)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(0)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(53, 20)
        Me.btnImport.TabIndex = 20
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnCheckCam
        '
        Me.btnCheckCam.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckCam.Location = New System.Drawing.Point(508, 155)
        Me.btnCheckCam.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCheckCam.Name = "btnCheckCam"
        Me.btnCheckCam.Size = New System.Drawing.Size(108, 28)
        Me.btnCheckCam.TabIndex = 21
        Me.btnCheckCam.Text = "Take Picture"
        Me.btnCheckCam.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCheckCam.UseVisualStyleBackColor = True
        '
        'lblCurBarcode
        '
        Me.lblCurBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurBarcode.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurBarcode.Location = New System.Drawing.Point(18, 303)
        Me.lblCurBarcode.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCurBarcode.Name = "lblCurBarcode"
        Me.lblCurBarcode.Size = New System.Drawing.Size(103, 30)
        Me.lblCurBarcode.TabIndex = 22
        Me.lblCurBarcode.Text = "111"
        Me.lblCurBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkAutoPrint
        '
        Me.chkAutoPrint.AutoSize = True
        Me.chkAutoPrint.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoPrint.Location = New System.Drawing.Point(120, 6)
        Me.chkAutoPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.chkAutoPrint.Name = "chkAutoPrint"
        Me.chkAutoPrint.Size = New System.Drawing.Size(148, 26)
        Me.chkAutoPrint.TabIndex = 23
        Me.chkAutoPrint.Text = "Auto Print Label?"
        Me.chkAutoPrint.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(10, 423)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(817, 122)
        Me.DataGridView1.TabIndex = 24
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(248, 44)
        Me.lblUser.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(41, 22)
        Me.lblUser.TabIndex = 26
        Me.lblUser.Text = "User"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserName
        '
        Me.txtUserName.AcceptsReturn = True
        Me.txtUserName.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(291, 42)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(178, 26)
        Me.txtUserName.TabIndex = 25
        Me.txtUserName.Text = "Nur"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 107)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 22)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "DB Path:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPathToDB
        '
        Me.txtPathToDB.AcceptsReturn = True
        Me.txtPathToDB.Font = New System.Drawing.Font("Trebuchet MS", 10.0!)
        Me.txtPathToDB.Location = New System.Drawing.Point(112, 105)
        Me.txtPathToDB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPathToDB.Multiline = True
        Me.txtPathToDB.Name = "txtPathToDB"
        Me.txtPathToDB.Size = New System.Drawing.Size(357, 46)
        Me.txtPathToDB.TabIndex = 27
        Me.txtPathToDB.Text = "C:\a_data\TimeStreams\Atkins\BVZ0047\_data\Plant ID for barcode-LinglingTest.csv"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSelectSaveFolder
        '
        Me.btnSelectSaveFolder.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectSaveFolder.Location = New System.Drawing.Point(471, 71)
        Me.btnSelectSaveFolder.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSelectSaveFolder.Name = "btnSelectSaveFolder"
        Me.btnSelectSaveFolder.Size = New System.Drawing.Size(37, 26)
        Me.btnSelectSaveFolder.TabIndex = 29
        Me.btnSelectSaveFolder.Text = "..."
        Me.btnSelectSaveFolder.UseVisualStyleBackColor = True
        '
        'btnSelectDB
        '
        Me.btnSelectDB.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectDB.Location = New System.Drawing.Point(471, 105)
        Me.btnSelectDB.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSelectDB.Name = "btnSelectDB"
        Me.btnSelectDB.Size = New System.Drawing.Size(37, 26)
        Me.btnSelectDB.TabIndex = 31
        Me.btnSelectDB.Text = "..."
        Me.btnSelectDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSelectDB.UseVisualStyleBackColor = True
        '
        'txtURL2
        '
        Me.txtURL2.AcceptsReturn = True
        Me.txtURL2.Location = New System.Drawing.Point(82, 310)
        Me.txtURL2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtURL2.Name = "txtURL2"
        Me.txtURL2.Size = New System.Drawing.Size(315, 20)
        Me.txtURL2.TabIndex = 33
        Me.txtURL2.Text = "http://150.203.71.26/image.jpg"
        '
        'pctCam2LastIm
        '
        Me.pctCam2LastIm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctCam2LastIm.Location = New System.Drawing.Point(21, 117)
        Me.pctCam2LastIm.Margin = New System.Windows.Forms.Padding(2)
        Me.pctCam2LastIm.Name = "pctCam2LastIm"
        Me.pctCam2LastIm.Size = New System.Drawing.Size(210, 140)
        Me.pctCam2LastIm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctCam2LastIm.TabIndex = 34
        Me.pctCam2LastIm.TabStop = False
        '
        'chkUseCam2
        '
        Me.chkUseCam2.AutoSize = True
        Me.chkUseCam2.Location = New System.Drawing.Point(18, 310)
        Me.chkUseCam2.Margin = New System.Windows.Forms.Padding(2)
        Me.chkUseCam2.Name = "chkUseCam2"
        Me.chkUseCam2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkUseCam2.Size = New System.Drawing.Size(56, 17)
        Me.chkUseCam2.TabIndex = 36
        Me.chkUseCam2.Text = "Cam 2"
        Me.chkUseCam2.UseVisualStyleBackColor = True
        '
        'tmrCapTimer
        '
        Me.tmrCapTimer.Interval = 1000
        '
        'lblProgress
        '
        Me.lblProgress.AutoEllipsis = True
        Me.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProgress.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblProgress.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(635, 348)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(192, 70)
        Me.lblProgress.TabIndex = 37
        Me.lblProgress.Text = "Ready"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLastPlantScanned
        '
        Me.lblLastPlantScanned.AutoSize = True
        Me.lblLastPlantScanned.BackColor = System.Drawing.Color.White
        Me.lblLastPlantScanned.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastPlantScanned.Location = New System.Drawing.Point(244, 144)
        Me.lblLastPlantScanned.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLastPlantScanned.Name = "lblLastPlantScanned"
        Me.lblLastPlantScanned.Size = New System.Drawing.Size(210, 25)
        Me.lblLastPlantScanned.TabIndex = 39
        Me.lblLastPlantScanned.Text = "lblLastPlantScanned"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.Button1.Location = New System.Drawing.Point(21, 48)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 20)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "Load Cam"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'lblCam2LastImage
        '
        Me.lblCam2LastImage.AutoSize = True
        Me.lblCam2LastImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCam2LastImage.Location = New System.Drawing.Point(37, 240)
        Me.lblCam2LastImage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCam2LastImage.Name = "lblCam2LastImage"
        Me.lblCam2LastImage.Size = New System.Drawing.Size(137, 17)
        Me.lblCam2LastImage.TabIndex = 42
        Me.lblCam2LastImage.Text = "Cam 2 Last Image"
        '
        'pnlQRCodes
        '
        Me.pnlQRCodes.Controls.Add(Me.pctQR)
        Me.pnlQRCodes.Controls.Add(Me.panPrintButtons)
        Me.pnlQRCodes.Location = New System.Drawing.Point(291, 6)
        Me.pnlQRCodes.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlQRCodes.Name = "pnlQRCodes"
        Me.pnlQRCodes.Size = New System.Drawing.Size(171, 117)
        Me.pnlQRCodes.TabIndex = 43
        '
        'btnReloadDB
        '
        Me.btnReloadDB.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReloadDB.Location = New System.Drawing.Point(508, 104)
        Me.btnReloadDB.Margin = New System.Windows.Forms.Padding(0)
        Me.btnReloadDB.Name = "btnReloadDB"
        Me.btnReloadDB.Size = New System.Drawing.Size(108, 28)
        Me.btnReloadDB.TabIndex = 44
        Me.btnReloadDB.Text = "ReloadDB"
        Me.btnReloadDB.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.Button2.Location = New System.Drawing.Point(21, 20)
        Me.Button2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(74, 20)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "Save Picture"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cmbCam1CamType
        '
        Me.cmbCam1CamType.Font = New System.Drawing.Font("Trebuchet MS", 11.0!)
        Me.cmbCam1CamType.FormattingEnabled = True
        Me.cmbCam1CamType.Items.AddRange(New Object() {"URL (IP Cam)", "WebCam"})
        Me.cmbCam1CamType.Location = New System.Drawing.Point(112, 155)
        Me.cmbCam1CamType.Name = "cmbCam1CamType"
        Me.cmbCam1CamType.Size = New System.Drawing.Size(109, 28)
        Me.cmbCam1CamType.TabIndex = 50
        '
        'cmbCam2CamType
        '
        Me.cmbCam2CamType.FormattingEnabled = True
        Me.cmbCam2CamType.Items.AddRange(New Object() {"URL (IP Cam)", "WebCam"})
        Me.cmbCam2CamType.Location = New System.Drawing.Point(431, 310)
        Me.cmbCam2CamType.Name = "cmbCam2CamType"
        Me.cmbCam2CamType.Size = New System.Drawing.Size(91, 21)
        Me.cmbCam2CamType.TabIndex = 51
        '
        'lblCamType
        '
        Me.lblCamType.AutoSize = True
        Me.lblCamType.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamType.Location = New System.Drawing.Point(23, 158)
        Me.lblCamType.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCamType.Name = "lblCamType"
        Me.lblCamType.Size = New System.Drawing.Size(85, 22)
        Me.lblCamType.TabIndex = 52
        Me.lblCamType.Text = "Cam Type:"
        Me.lblCamType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWebCam1Info
        '
        Me.lblWebCam1Info.AutoSize = True
        Me.lblWebCam1Info.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebCam1Info.Location = New System.Drawing.Point(16, 4)
        Me.lblWebCam1Info.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWebCam1Info.Name = "lblWebCam1Info"
        Me.lblWebCam1Info.Size = New System.Drawing.Size(79, 22)
        Me.lblWebCam1Info.TabIndex = 53
        Me.lblWebCam1Info.Text = "WebCam:"
        Me.lblWebCam1Info.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pctCam1LastImage
        '
        Me.pctCam1LastImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctCam1LastImage.Location = New System.Drawing.Point(831, 347)
        Me.pctCam1LastImage.Margin = New System.Windows.Forms.Padding(2)
        Me.pctCam1LastImage.Name = "pctCam1LastImage"
        Me.pctCam1LastImage.Size = New System.Drawing.Size(300, 198)
        Me.pctCam1LastImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctCam1LastImage.TabIndex = 54
        Me.pctCam1LastImage.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(581, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Live View"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(834, 351)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Last Image"
        '
        'lblUnused
        '
        Me.lblUnused.AutoSize = True
        Me.lblUnused.Location = New System.Drawing.Point(8, 6)
        Me.lblUnused.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUnused.Name = "lblUnused"
        Me.lblUnused.Size = New System.Drawing.Size(44, 13)
        Me.lblUnused.TabIndex = 57
        Me.lblUnused.Text = "Unused"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.lblUnused)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnTest)
        Me.Panel1.Controls.Add(Me.pnlQRCodes)
        Me.Panel1.Controls.Add(Me.txtBrightness)
        Me.Panel1.Controls.Add(Me.pctCam2LastIm)
        Me.Panel1.Controls.Add(Me.lblCam2LastImage)
        Me.Panel1.Controls.Add(Me.btnICCapture)
        Me.Panel1.Controls.Add(Me.btnICSet)
        Me.Panel1.Controls.Add(Me.btnDisconnect)
        Me.Panel1.Controls.Add(Me.btnICOptions)
        Me.Panel1.Controls.Add(Me.lblICLocation)
        Me.Panel1.Controls.Add(Me.txtURL2)
        Me.Panel1.Controls.Add(Me.chkUseCam2)
        Me.Panel1.Controls.Add(Me.cmbCam2CamType)
        Me.Panel1.Controls.Add(Me.lblLastPlantScanned)
        Me.Panel1.Controls.Add(Me.chkAutoPrint)
        Me.Panel1.Location = New System.Drawing.Point(1075, 531)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(473, 373)
        Me.Panel1.TabIndex = 58
        Me.Panel1.Visible = False
        '
        'btnTest
        '
        Me.btnTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnTest.Location = New System.Drawing.Point(21, 84)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(0)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(209, 31)
        Me.btnTest.TabIndex = 75
        Me.btnTest.Text = "Brightness"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'txtBrightness
        '
        Me.txtBrightness.AcceptsReturn = True
        Me.txtBrightness.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtBrightness.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrightness.Location = New System.Drawing.Point(193, 2)
        Me.txtBrightness.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBrightness.Name = "txtBrightness"
        Me.txtBrightness.Size = New System.Drawing.Size(53, 26)
        Me.txtBrightness.TabIndex = 76
        Me.txtBrightness.Text = "5"
        Me.txtBrightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtBrightness, "Capture Delay (Set Blank or Zero for NONE)")
        '
        'btnICCapture
        '
        Me.btnICCapture.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnICCapture.Location = New System.Drawing.Point(226, 92)
        Me.btnICCapture.Margin = New System.Windows.Forms.Padding(0)
        Me.btnICCapture.Name = "btnICCapture"
        Me.btnICCapture.Size = New System.Drawing.Size(67, 31)
        Me.btnICCapture.TabIndex = 72
        Me.btnICCapture.Text = "btnICCapture"
        Me.btnICCapture.UseVisualStyleBackColor = True
        '
        'btnICSet
        '
        Me.btnICSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnICSet.Location = New System.Drawing.Point(226, 55)
        Me.btnICSet.Margin = New System.Windows.Forms.Padding(0)
        Me.btnICSet.Name = "btnICSet"
        Me.btnICSet.Size = New System.Drawing.Size(72, 31)
        Me.btnICSet.TabIndex = 71
        Me.btnICSet.Text = "btnICSet"
        Me.btnICSet.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnDisconnect.Location = New System.Drawing.Point(273, 187)
        Me.btnDisconnect.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(67, 31)
        Me.btnDisconnect.TabIndex = 68
        Me.btnDisconnect.Text = "btnDisconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnICOptions
        '
        Me.btnICOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.btnICOptions.Location = New System.Drawing.Point(226, 21)
        Me.btnICOptions.Margin = New System.Windows.Forms.Padding(0)
        Me.btnICOptions.Name = "btnICOptions"
        Me.btnICOptions.Size = New System.Drawing.Size(72, 31)
        Me.btnICOptions.TabIndex = 70
        Me.btnICOptions.Text = "btnICOptions"
        Me.btnICOptions.UseVisualStyleBackColor = True
        '
        'lblICLocation
        '
        Me.lblICLocation.AutoSize = True
        Me.lblICLocation.Location = New System.Drawing.Point(273, 222)
        Me.lblICLocation.Name = "lblICLocation"
        Me.lblICLocation.Size = New System.Drawing.Size(39, 13)
        Me.lblICLocation.TabIndex = 69
        Me.lblICLocation.Text = "Label7"
        '
        'txtCountDownTimeSecs
        '
        Me.txtCountDownTimeSecs.AcceptsReturn = True
        Me.txtCountDownTimeSecs.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtCountDownTimeSecs.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountDownTimeSecs.Location = New System.Drawing.Point(377, 156)
        Me.txtCountDownTimeSecs.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCountDownTimeSecs.Name = "txtCountDownTimeSecs"
        Me.txtCountDownTimeSecs.Size = New System.Drawing.Size(53, 26)
        Me.txtCountDownTimeSecs.TabIndex = 62
        Me.txtCountDownTimeSecs.Text = "5"
        Me.txtCountDownTimeSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtCountDownTimeSecs, "Capture Delay (Set Blank or Zero for NONE)")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(224, 158)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(156, 22)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Capture Delay (sec):"
        '
        'VideoSourcePlayer1
        '
        Me.VideoSourcePlayer1.Location = New System.Drawing.Point(639, 18)
        Me.VideoSourcePlayer1.Name = "VideoSourcePlayer1"
        Me.VideoSourcePlayer1.Size = New System.Drawing.Size(200, 126)
        Me.VideoSourcePlayer1.TabIndex = 64
        Me.VideoSourcePlayer1.Text = "VideoSourcePlayer1"
        Me.VideoSourcePlayer1.VideoSource = Nothing
        '
        'cmbVideoModes
        '
        Me.cmbVideoModes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cmbVideoModes.FormattingEnabled = True
        Me.cmbVideoModes.Location = New System.Drawing.Point(96, 33)
        Me.cmbVideoModes.Name = "cmbVideoModes"
        Me.cmbVideoModes.Size = New System.Drawing.Size(209, 26)
        Me.cmbVideoModes.TabIndex = 65
        '
        'cmbVideoSource
        '
        Me.cmbVideoSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cmbVideoSource.FormattingEnabled = True
        Me.cmbVideoSource.Location = New System.Drawing.Point(96, 2)
        Me.cmbVideoSource.Name = "cmbVideoSource"
        Me.cmbVideoSource.Size = New System.Drawing.Size(210, 26)
        Me.cmbVideoSource.TabIndex = 66
        '
        'pctImageLiveImage
        '
        Me.pctImageLiveImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctImageLiveImage.Location = New System.Drawing.Point(635, 6)
        Me.pctImageLiveImage.Margin = New System.Windows.Forms.Padding(2)
        Me.pctImageLiveImage.Name = "pctImageLiveImage"
        Me.pctImageLiveImage.Size = New System.Drawing.Size(496, 333)
        Me.pctImageLiveImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctImageLiveImage.TabIndex = 2
        Me.pctImageLiveImage.TabStop = False
        '
        'btnReloadWebcam
        '
        Me.btnReloadWebcam.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReloadWebcam.Location = New System.Drawing.Point(313, 0)
        Me.btnReloadWebcam.Margin = New System.Windows.Forms.Padding(0)
        Me.btnReloadWebcam.Name = "btnReloadWebcam"
        Me.btnReloadWebcam.Size = New System.Drawing.Size(180, 31)
        Me.btnReloadWebcam.TabIndex = 73
        Me.btnReloadWebcam.Text = "Reload webcams"
        Me.btnReloadWebcam.UseVisualStyleBackColor = True
        '
        'trkFocus
        '
        Me.trkFocus.AutoSize = False
        Me.trkFocus.Location = New System.Drawing.Point(88, 63)
        Me.trkFocus.Margin = New System.Windows.Forms.Padding(0)
        Me.trkFocus.Maximum = 255
        Me.trkFocus.Name = "trkFocus"
        Me.trkFocus.Size = New System.Drawing.Size(350, 25)
        Me.trkFocus.TabIndex = 74
        '
        'lblFocus
        '
        Me.lblFocus.BackColor = System.Drawing.Color.White
        Me.lblFocus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblFocus.Location = New System.Drawing.Point(440, 68)
        Me.lblFocus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFocus.Name = "lblFocus"
        Me.lblFocus.Size = New System.Drawing.Size(44, 28)
        Me.lblFocus.TabIndex = 77
        Me.lblFocus.Text = "100"
        Me.lblFocus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWebCamFocus
        '
        Me.lblWebCamFocus.AutoSize = True
        Me.lblWebCamFocus.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebCamFocus.Location = New System.Drawing.Point(12, 64)
        Me.lblWebCamFocus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWebCamFocus.Name = "lblWebCamFocus"
        Me.lblWebCamFocus.Size = New System.Drawing.Size(83, 22)
        Me.lblWebCamFocus.TabIndex = 78
        Me.lblWebCamFocus.Text = "Set Focus:"
        Me.lblWebCamFocus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWebCamResolution
        '
        Me.lblWebCamResolution.AutoSize = True
        Me.lblWebCamResolution.BackColor = System.Drawing.SystemColors.Control
        Me.lblWebCamResolution.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebCamResolution.Location = New System.Drawing.Point(7, 35)
        Me.lblWebCamResolution.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWebCamResolution.Name = "lblWebCamResolution"
        Me.lblWebCamResolution.Size = New System.Drawing.Size(88, 22)
        Me.lblWebCamResolution.TabIndex = 79
        Me.lblWebCamResolution.Text = "Resolution:"
        Me.lblWebCamResolution.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlWebCamControls
        '
        Me.pnlWebCamControls.Controls.Add(Me.cmbVideoSource)
        Me.pnlWebCamControls.Controls.Add(Me.lblWebCamFocus)
        Me.pnlWebCamControls.Controls.Add(Me.lblWebCamResolution)
        Me.pnlWebCamControls.Controls.Add(Me.lblFocus)
        Me.pnlWebCamControls.Controls.Add(Me.lblWebCam1Info)
        Me.pnlWebCamControls.Controls.Add(Me.cmbVideoModes)
        Me.pnlWebCamControls.Controls.Add(Me.btnReloadWebcam)
        Me.pnlWebCamControls.Controls.Add(Me.trkFocus)
        Me.pnlWebCamControls.Location = New System.Drawing.Point(15, 195)
        Me.pnlWebCamControls.Name = "pnlWebCamControls"
        Me.pnlWebCamControls.Size = New System.Drawing.Size(497, 103)
        Me.pnlWebCamControls.TabIndex = 80
        '
        'chkBeepOnCapture
        '
        Me.chkBeepOnCapture.AutoSize = True
        Me.chkBeepOnCapture.Font = New System.Drawing.Font("Trebuchet MS", 12.0!)
        Me.chkBeepOnCapture.Location = New System.Drawing.Point(436, 156)
        Me.chkBeepOnCapture.Name = "chkBeepOnCapture"
        Me.chkBeepOnCapture.Size = New System.Drawing.Size(65, 26)
        Me.chkBeepOnCapture.TabIndex = 81
        Me.chkBeepOnCapture.Text = "Beep"
        Me.chkBeepOnCapture.UseVisualStyleBackColor = True
        '
        'tmrSetVideoSize
        '
        Me.tmrSetVideoSize.Interval = 1000
        '
        'frmPhenoSnap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 554)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlWebCamControls)
        Me.Controls.Add(Me.VideoSourcePlayer1)
        Me.Controls.Add(Me.pctImageLiveImage)
        Me.Controls.Add(Me.txtCountDownTimeSecs)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pctCam1LastImage)
        Me.Controls.Add(Me.lblCamType)
        Me.Controls.Add(Me.cmbCam1CamType)
        Me.Controls.Add(Me.btnReloadDB)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnSelectDB)
        Me.Controls.Add(Me.btnSelectSaveFolder)
        Me.Controls.Add(Me.txtPathToDB)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblCurBarcode)
        Me.Controls.Add(Me.btnCheckCam)
        Me.Controls.Add(Me.btnOpenImFolder)
        Me.Controls.Add(Me.txtFileSavePath)
        Me.Controls.Add(Me.lblLastImageName)
        Me.Controls.Add(Me.txtExpID)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.txtURL1)
        Me.Controls.Add(Me.txtBarcodeValue)
        Me.Controls.Add(Me.lblIDNote)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblBarcodeValue)
        Me.Controls.Add(Me.lblExpID)
        Me.Controls.Add(Me.lblLastPlant)
        Me.Controls.Add(Me.lblCam1URL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkBeepOnCapture)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmPhenoSnap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PhenoSnap"
        CType(Me.pctQR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panPrintButtons.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctCam2LastIm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlQRCodes.ResumeLayout(False)
        CType(Me.pctCam1LastImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pctImageLiveImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkFocus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWebCamControls.ResumeLayout(False)
        Me.pnlWebCamControls.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBarcodeValue As System.Windows.Forms.TextBox
    Friend WithEvents txtURL1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents txtExpID As System.Windows.Forms.TextBox
    Friend WithEvents lblExpID As System.Windows.Forms.Label
    Friend WithEvents lblBarcodeValue As System.Windows.Forms.Label
    Friend WithEvents lblCam1URL As System.Windows.Forms.Label
    Friend WithEvents lblIDNote As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLastImageName As System.Windows.Forms.Label
    Friend WithEvents lblLastPlant As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFileSavePath As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenImFolder As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintGraphicControl As System.Drawing.Printing.PrintDocument
    Friend WithEvents pctQR As System.Windows.Forms.PictureBox
    Friend WithEvents btnGetQR As System.Windows.Forms.Button
    Friend WithEvents btnListPrinters As System.Windows.Forms.Button
    Friend WithEvents btnPrintLabel As System.Windows.Forms.Button
    Friend WithEvents panPrintButtons As System.Windows.Forms.Panel
    Friend WithEvents btnCheckCam As System.Windows.Forms.Button
    Friend WithEvents lblCurBarcode As System.Windows.Forms.Label
    Friend WithEvents chkAutoPrint As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPathToDB As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSelectSaveFolder As System.Windows.Forms.Button
    Friend WithEvents btnSelectDB As System.Windows.Forms.Button
    Friend WithEvents txtURL2 As System.Windows.Forms.TextBox
    Friend WithEvents pctCam2LastIm As System.Windows.Forms.PictureBox
    Friend WithEvents chkUseCam2 As System.Windows.Forms.CheckBox
    Friend WithEvents tmrCapTimer As System.Windows.Forms.Timer
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents lblLastPlantScanned As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblCam2LastImage As System.Windows.Forms.Label
    Friend WithEvents pnlQRCodes As System.Windows.Forms.Panel
    Friend WithEvents btnReloadDB As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmbCam1CamType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCam2CamType As System.Windows.Forms.ComboBox
    Friend WithEvents lblCamType As System.Windows.Forms.Label
    Friend WithEvents lblWebCam1Info As System.Windows.Forms.Label
    Friend WithEvents pctCam1LastImage As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblUnused As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCountDownTimeSecs As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbVideoModes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVideoSource As System.Windows.Forms.ComboBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents lblICLocation As System.Windows.Forms.Label
    Friend WithEvents btnICOptions As System.Windows.Forms.Button
    Friend WithEvents btnICSet As System.Windows.Forms.Button
    Friend WithEvents btnICCapture As System.Windows.Forms.Button
    Friend WithEvents pctImageLiveImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnReloadWebcam As System.Windows.Forms.Button
    Friend WithEvents trkFocus As System.Windows.Forms.TrackBar
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents txtBrightness As System.Windows.Forms.TextBox
    Friend WithEvents lblFocus As System.Windows.Forms.Label
    Friend WithEvents lblWebCamFocus As System.Windows.Forms.Label
    Friend WithEvents lblWebCamResolution As System.Windows.Forms.Label
    Friend WithEvents pnlWebCamControls As System.Windows.Forms.Panel
    Friend WithEvents chkBeepOnCapture As System.Windows.Forms.CheckBox
    Friend WithEvents VideoSourcePlayer1 As AForge.Controls.VideoSourcePlayer
    Friend WithEvents tmrSetVideoSize As System.Windows.Forms.Timer

End Class
