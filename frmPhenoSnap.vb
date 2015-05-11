'TODO
'* Cut cover the size of box
'* Get color checker code working
'* Add Timer box
'* Get better lighting
'* Other cross calibration methods (scanning leaf with color checker, etc)

Imports AForge.Controls
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports AForge.Video.VFW
Imports System.IO



'TODO
'Capture:
'-Images saved per day in timestamped
'- If TOD is the same then images will over write but if minute has changed new images will be captured
'- Goal is just two image (top and side) per day per pot, extras will be ignored/deleted

'Naming:
'EXPD-PlantID-Acess-Condition-PotNum-TopORSide
'BVZ0038-17007-RAC875-IRG-TOP_07_2014_07_24_09_40_00.jpg
'BVZ0038-17007-RAC875-IRG-SID_07_2014_07_24_09_40_00.jpg

'To Fix:
'Top camera (bad image)
'Side view Color checker needs to be fixed

'Do full round of images on Tuesday
'-- Need to mark front position on each pot so it fits in locked notches
'-- Need to fix front color checker and position so it is easy to swap pots and not hit it


Imports System
Imports System.Net
Imports IO = System.IO
Imports System.Data.OleDb
Imports System.Environment

Imports VB = Microsoft.VisualBasic

' Get the path to the Application Data folder

Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms


'Imports Emgu.CV
'Imports Emgu.CV.Structure
'Imports Emgu.Util
'Imports System.Runtime.InteropServices




Public Class frmPhenoSnap
#Region "Globals"
    'For leaf images
    '    Friend camURL As String
    'Dim dbFilePath As String 'Path to CSV file

    Friend imName01 As String
    Friend imName02 As String
    Friend curIm As Bitmap
    Friend tempIm As Bitmap 'Placeholder bitmap to load images w/o locking them
    Friend rootSavePath As String
    Friend fullSavePath(2) As String
    Friend rootTempSavePath As String
    Friend rootTempFullSavePath(2) As String

    'Friend curPlantID As String 'Holds plant id from barcode (Is String in case barcode is alphanumeric)

    Private Structure ConfigInfo
        Public expID As String
        Public user As String
        Public dbPath As String
        Public camURL1 As String
        Public camURL2 As String
        Public secondCam As Boolean
    End Structure


    Private Structure PlantInfo
        Public accession As String
        Public accessionID As String
        Public plantName As String
        Public plantNumber As String
        Public treatment As String
        Public cabinet As String
        Public potLoc As String
        Public potNum As String
        Public plantPos As String
        Public plantID As String
        Public expID As String
        Public user As String
        Public leafID As String

        Public Sub Clear()
            accession = String.Empty
            accessionID = String.Empty
            plantName = String.Empty
            plantNumber = String.Empty
            treatment = String.Empty
            cabinet = String.Empty
            potLoc = String.Empty
            potNum = String.Empty
            plantPos = String.Empty
            plantID = String.Empty
            expID = String.Empty
            user = String.Empty
            leafID = String.Empty
        End Sub

    End Structure

    Dim curPlant As PlantInfo
    Dim config As ConfigInfo

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' For printing
    Dim qrURL As Uri
    Dim appDataPath As String 'Path to "apddata/roaming" to save software config info

    ' Dim stExpID As String
    ' Dim stANID As String
    ' Dim sAccession As String
    ' Dim stStartDate As String
    ' Dim stpotLocation As String

    'Get accurate sizing for printing
    Dim dpiX As Long
    Dim dpiY As Long

    'Label and QR size for scaling from dots per inch (dpi)
    Dim labelWIn As Long = 2.04724409
    Dim labelHIn As Long = 1.1023622
    Dim labelWPx As Long 'These will hold the scaled size in pixels for the labels
    Dim labelHPx As Long

    '    Dim QRWIn As String = 0.590551181 '15mm
    '   Dim QRHIn As String = 0.590551181 '15mm

    ' QR width in inches (doesn't print to scale)
    Dim QRWIn As String = 1.2
    Dim QRHIn As String = 1.2 '15mm

    Dim QRWPx As Long
    Dim QRHPx As Long


    ''''''Label data fromcsv file'''

    'Labels for plants:
    Dim stLabelData() As String 'The label file csv gets loaded into this
    Dim numLabels As Integer 'Number of labels (lines) in loaded csv file
    Dim curLine As Integer 'Which line of data we are currently on
    Dim stFilePath As String 'Path to csv file

    'Labels for Trays:
    Dim stTrayNum As String
    Dim stUser As String 'This is who is running the experiment

    Dim labelType As String 'Can be either TRAY or PLANT
    Const PLANT As Integer = 1
    Const TRAY As Integer = 2
    Const SEED As Integer = 3

    'Holds screenshot of image panel for label
    Private labelImage As Bitmap

    Dim stPrinterToUse As String = "ZDesigner GK420t"


    'For iterating to print all
    Dim quit As Boolean = True 'Global to toggle if user wants to quit
    Dim gQuitSleep As Boolean = False 'Let the user quit if they enteredsome huge value by accident

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Public Shared Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, _
                                  ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, _
                                  ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Integer) As Long
    End Function


    'WEBCAM CODE
    Dim camType As Integer 'Currently either "IP" or "Webcam" (se Const delcaration below)
    Const IPCAM As Integer = 0
    Const WEBCAM As Integer = 1

    Dim cWnd As IntPtr = IntPtr.Zero
    Dim devId As Integer = 0 '0 will be the first capture device found
    Dim picnumber As Integer = 0
    Dim tmppic As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Temp.dib")

    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const WM_USER As Integer = &H400
    Private Const WM_CAP_DRIVER_CONNECT As Integer = WM_USER + 10
    Private Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_USER + 11
    Private Const WM_CAP_SET_PREVIEW As Integer = WM_USER + 50
    Private Const WM_CAP_SET_PREVIEWRATE As Integer = WM_USER + 52
    Private Const WM_CAP_SET_SCALE As Integer = WM_USER + 53
    Private Const WM_CAP_SAVEDIB As Integer = WM_USER + 25
    Private Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_USER + 41
    Private Const WM_CAP_DLG_VIDEODISPLAY = WM_USER + 43

    '' [TB NOTE] - moved the dll and interop code to just above the capture code for ease of debugging

    Dim formLoaded As Boolean = False 'Prevent form events from firing until form is loaded
    Dim gSelectedWebCamName ' Need to hold this from the config field so we can load it after the form loads (otherwise cobo box doesn't register update)
    Dim gWebCamVideoSize ' Need to hold this from the config field so we can load it after the form loads (otherwise cobo box doesn't register update)
    Dim gCamFocus As Integer 'Camera focus value (not currently specific to camera type i.e. it will just load whatevetr the last focus setting is
    Dim bCamAutoFocus As Boolean = True 'Is camera autofocus or manual
    ' AspectRatios
    Dim camAspectRatio As Double

    Dim bBeepOnCapture As Boolean = False

    Dim gSetSizeTimer As Integer = 0 ' For auto setting the webcam image size, we need to run the "set size" timer on form load until the webcam is actually available. This count how long it has been run for so we can cancel the timer if the webcam takes to long to load

    Private Const FOURTHREE = 4 / 3
    Private Const THREETWO = (3 / 2)
    Private Const ONEONE = 1
    Private Const SIXTEENNINE = 16 / 9



    '''''''''''''''''''''''''''''''''''''''''
    Const DO_QR As Boolean = False
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If DO_QR = False Then
            pnlQRCodes.Visible = False
            GetDPI() 'Required for printing
            ' txtOutput.Width = DataGridView1.Width
        End If

        'Get path to save system variable config file. For now we'll just save the full filepath with name
        appDataPath = Application.UserAppDataPath + "\PhenoSnapConfig.csv"

        ' Display the path
        ' txtOutput.Text = "App Data Folder Path: " & appDataPath

        lblLastPlantScanned.Visible = False
        lblLastPlantScanned.Text = ""

        'Image type will be BMP until we set up that ability to change it
        My.Settings.ICType = "JPG"



        'Enumerate the video devices before we load the user date so the camera can be selected (if it exists)
        loadConfig()

        btnDisconnect.Enabled = False

        'strICFileRootName = My.Settings.ICRootName
        'strICLocation = System.Windows.Forms.Application.StartupPath & "\" ' "C:\" 'My.Settings.ICSet
        lblICLocation.Text = strICLocation
        updateSettings()

        ImportData()

        formLoaded = True

        tmrSetVideoSize.Enabled = True



    End Sub
    Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        updateSettings()
        saveConfig(appDataPath)
    End Sub
    Private Sub updateSettings()
        '   If Not (formLoaded) Then Exit Sub
        bBeepOnCapture = chkBeepOnCapture.Checked

        rootSavePath = IO.Path.Combine(txtFileSavePath.Text & txtExpID.Text)

        lblCurBarcode.Text = curPlant.plantID

        config.secondCam = chkUseCam2.Checked

        Dim imtype As String = My.Settings.ICType


        curPlant.expID = txtExpID.Text
        curPlant.user = txtUserName.Text

        rootSavePath = IO.Path.Combine(txtFileSavePath.Text, txtExpID.Text & "-PhenotypeData\" & Now.Year & "_" & sPad(Now.Month, 2) & "_" & sPad(Now.Day, 2))
        rootTempSavePath = IO.Path.Combine(rootSavePath, "temp")
        rootTempFullSavePath(1) = IO.Path.Combine(rootTempSavePath, "temp1." & imtype)
        rootTempFullSavePath(2) = IO.Path.Combine(rootTempSavePath, "temp2." & imtype)
        'FULSAVEPATH now gets set in "GetImagePathName"

        ''Need to create root temp file path b/c webcam save fails if path doesn't exist:
        Try
            IO.Directory.CreateDirectory(rootTempSavePath)

        Catch ex As Exception
            Beep()
            txtOutput.Text = "Could not create root save directory here:" & vbCrLf & rootTempSavePath & vbCrLf & "Exception was " & ex.Message
        End Try

        '''''''''''''''''''''''''''''
        'Filename:
        '''''''''''''''''''''''''''''
        ' expID_Cabinet_Tray_NumericID.jpg
        '' For BVZ0022 pelli leafsnap:
        ''        imName01 = curPlant.expID & "_" & sPad(curPlant.cabinet, 2) & "_" & curPlant.potLoc & "_" & curPlant.plantID & ".jpg"




        ''Old way with just filename:
        '        fullSavePath(1) = IO.Path.Combine(rootSavePath, imName01)
        '       fullSavePath(2) = IO.Path.Combine(rootSavePath, imName02)


        config.secondCam = chkUseCam2.Checked
        config.camURL1 = txtURL1.Text
        If config.secondCam Then config.camURL2 = txtURL2.Text Else config.camURL2 = ""
        config.dbPath = txtPathToDB.Text
        config.user = txtUserName.Text
        config.expID = txtExpID.Text

        'Show/Hide boxes for cam 2
        ShowHideCam2(chkUseCam2.Checked)

        setCamType()


        GoToScanBox()
    End Sub
    Private Function GetImageNamePath(expID) As String

        Select Case expID
            Case "BVZ0038"
                ''For BVZ0038 - Wheat trial dual camera:
                imName01 = curPlant.expID & "-" & curPlant.plantID & "-" & curPlant.accession & "-" & curPlant.treatment & "-TOP"
                imName02 = curPlant.expID & "-" & curPlant.plantID & "-" & curPlant.accession & "-" & curPlant.treatment & "-SIDE"
                'EXPD-PlantID-Acess-Condition-PotNum-TopORSide

            Case "BVZ0047"

                ''For BVZ0047 - Euc LeafScan with webcam:
                ' imName01 = curPlant.expID & "-" & "P" & curPlant.plantNumber & "-" & "L" & sPad(curPlant.leafID, 3) & "-" & curPlant.accessionID
                imName01 = curPlant.expID & "-" & curPlant.plantID & "-" & curPlant.accessionID
                'EXPD-PlantID-Acess-Condition-PotNum-TopORSide

            Case "BVZ0042"

                ''For BVZ0042 - PIP Brachy scan:
                imName01 = curPlant.expID & "-" & curPlant.plantName
            Case Else
                Beep()
                MsgBox("Output filename not yet configured for current experiment ID")
                Return "FAIL-OutputNotConfiguredForCurrentExpID"
        End Select

        'Create save path for image (temp path gets set in "update settings"
        'New way that gives TimeStream file name (but we just use one folder per day, not the full timestream folders)
        fullSavePath(1) = IO.Path.Combine(rootSavePath, GetFilenameFromPath(GetFullFilePath(rootTempSavePath, Date.Now, imName01, 60)))
        fullSavePath(2) = IO.Path.Combine(rootSavePath, GetFilenameFromPath(GetFullFilePath(rootTempSavePath, Date.Now, imName02, 60)))



    End Function
    Private Sub setCamType()
        Select Case VB.Left(cmbCam1CamType.Text, 3) 'Grab the first 3 letters to make it easer 
            Case "URL"
                camType = IPCAM
                lblCam1URL.Visible = True
                txtURL1.Visible = True
            Case "Web"
                camType = WEBCAM
                lblWebCam1Info.Top = lblCam1URL.Top
                lblWebCam1Info.Left = lblCam1URL.Left - 20
                lblCam1URL.Visible = False
                txtURL1.Visible = False
                ' lstWebCamSelect.Top = txtURL1.Top
                ' lstWebCamSelect.Left = txtURL1.Left
        End Select
        Dim a As String = VB.Left(cmbCam1CamType.Text, 3)

    End Sub
    Private Sub DoProcess()
        updateSettings()

        labelType = SEED

        If LoadCurrentPlantInfo() = 0 Then
            'Quit if we can't get label
            txtBarcodeValue.Text = ""
            Return
        End If
        updateSettings()

        If CheckDir(rootSavePath) = False Then
            MsgBox("Could not create save directory. Can't continue.")
            Return
        End If

        Dim result

        'Get filename
        GetImageNamePath(config.expID)

        'CAPTURE THE IMAGE
        If Not (config.secondCam) Then
            result = CaptureImage(imName01, rootTempFullSavePath(1), config.camURL1, pctCam1LastImage, camType)
        Else
            Beep()
            MsgBox("NO SECOND CAM CAPTURE CONFIGURED")
            '[TB NOTE] This requires that both images be captured successfully. Should be written for better error reporting
            ''   result = CaptureImage(imName01, rootTempFullSavePath(1), config.camURL1, pctImage1)
            ''   If result = 1 Then result = CaptureImage(imName02, rootTempFullSavePath(2), config.camURL2, pctImage2)

        End If

        'SAVE THE IMAGE
        If result = 1 Then
            Try
                pctCam1LastImage.Image.Save(fullSavePath(1))
                If config.secondCam Then pctCam2LastIm.Image.Save(fullSavePath(2))
                '
                Dim LastImName() As String = Split(fullSavePath(1), "\")
                LastImName = Split(LastImName(LastImName.Length - 1), "_")

                lblLastImageName.Text = LastImName(0).ToString
                '  "Pot: " & curPlant.potNum & " | Plant: " & curPlant.accession & " | Trtmnt: " & curPlant.treatment
                txtBarcodeValue.Text = ""
                If chkAutoPrint.Checked = True Then
                    PrintLabel()
                End If
                txtOutput.Clear()
            Catch ex As Exception
                Beep()
                txtOutput.Text = "Error saving image. " & vbCrLf & ex.Message
            End Try

        ElseIf result = 0 Then
            Beep()
            txtOutput.Text = "Error capturing image. Check camera and URL."
            'Have to clear this or it messes up the next try:
            txtBarcodeValue.Text = ""
        End If

    End Sub

    Private Function LoadCurrentPlantInfo()
        '        [TB] Need to auto detect plant ID column (see the cam tracker code for how to detect this when loading the csv)
        'Clear current data
        curPlant.Clear()

        curPlant.plantID = txtBarcodeValue.Text.TrimStart("0"c) 'Trim leading zeros so the search matches if the barcode has extra zeros

        Dim plantIDCol As Integer = GetIndexOf("PlantID", DataGridView1)

        Dim plantRow As DataGridViewRow
        Try
            For Each dr As DataGridViewRow In DataGridView1.Rows

                If dr.Cells(plantIDCol).Value.ToString.Contains(curPlant.plantID) Then

                    plantRow = dr
                    Exit For
                End If
            Next
        Catch ex As Exception
            '            Beep()
            '           MsgBox("Can't find plantID: " & curPlant.plantID & vbCrLf & "Try scanning again.")
            '          GoToScanBox()
        End Try

        If Not IsNothing(plantRow) Then
            Try

                curPlant.plantID = plantRow.Cells(GetIndexOf("PlantID", DataGridView1)).Value.ToString()
                curPlant.expID = txtExpID.Text
                curPlant.user = txtUserName.Text
                curPlant.leafID = plantRow.Cells(GetIndexOf("LeafID", DataGridView1)).Value.ToString()
                '          curPlant.plantName = plantRow.Cells(GetIndexOf("PlantID", DataGridView1)).Value.ToString()
                curPlant.accessionID = plantRow.Cells(GetIndexOf("AccessionID", DataGridView1)).Value.ToString()
                curPlant.plantNumber = sPad(plantRow.Cells(GetIndexOf("PlantNumber", DataGridView1)).Value.ToString(), 3)
                curPlant.plantName = plantRow.Cells(GetIndexOf("PlantName", DataGridView1)).Value.ToString()
                curPlant.plantName = VB.Replace(curPlant.plantName, "_", "-")
                '            curPlant.accession = plantRow.Cells(GetIndexOf("Accession", DataGridView1)).Value.ToString()
                '           curPlant.accession = plantRow.Cells(GetIndexOf("Accession", DataGridView1)).Value.ToString()
                'curPlant.expID = plantRow.Cells(3).Value.ToString()
                'curPlant.user = plantRow.Cells(4).Value.ToString()
                'curPlant.treatment = plantRow.Cells(5).Value.ToString()
                'curPlant.potNum = plantRow.Cells(6).Value.ToString()
                Return 1
            Catch ex As Exception
                txtOutput.Text = ex.Message
                Beep()
                Return 0
            End Try

        Else

            Beep()
            Beep()

            txtOutput.Text = "Plant ID """ & curPlant.plantID & """ not found."
            Return 0
        End If

    End Function


    Private Function CheckDir(dirPath) As Boolean

        Try
            If Not IO.Directory.Exists(dirPath) Then
                IO.Directory.CreateDirectory(dirPath)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)

    Private Sub sleep(sleepTimeSecs As Long)
        For i As Integer = 1 To sleepTimeSecs
            lblProgress.Text = "Capturing in " & sleepTimeSecs + 1 - i
            Me.Sleep(1000)
            If gQuitSleep = True Then Exit Sub
            Application.DoEvents()
        Next


    End Sub
    ''' <summary>
    ''' 
    ''' 
    ''' </summary>
    ''' <param name="imName"></param>
    ''' <param name="temppath"></param>
    ''' <param name="URL"></param>
    ''' <param name="picbox"></param>
    ''' <param name="capType">Passes a consts of either IP or WEBCAM to determine how capture is handeled</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CaptureImage(imName As String, temppath As String, URL As String, picbox As System.Windows.Forms.PictureBox, capType As Integer) As Integer


        Application.DoEvents()

        Try

            If IsNumeric(txtCountDownTimeSecs.Text) Then
                If txtCountDownTimeSecs.Text > 60 Then
                    Dim result As Integer = MsgBox("CountDown time is very large, are you sure you meant to do that? " & vbCrLf & "Click 'OK' to continue or 'Cancel' to stop." & vbCrLf & "Don't forget to click back in the curser box after you enter the delay seconds value.", MsgBoxStyle.OkCancel)
                    If result = 2 Then Exit Function
                End If
                Sleep(CLng(txtCountDownTimeSecs.Text))
            End If
        Catch ex As Exception

        End Try

        Application.DoEvents()
        Me.Update()
        'Clear pictbox and delete temp image

        If IsNothing(picbox.Image) Then

        Else
            Dim im As Image = picbox.Image
            picbox.Image = Nothing
            im.Dispose()
        End If

        Try
            If IO.File.Exists(temppath) Then
                Try
                    My.Computer.FileSystem.DeleteFile(temppath)
                Catch ex As Exception
                    txtOutput.Text = "Could not delete temp image file here: " & vbCrLf & temppath

                End Try

            End If
        Catch ex As Exception
            Beep()
            MsgBox("No temp file at " & temppath)
        End Try

        Try
            Select Case capType

                Case IPCAM
                    My.Computer.Network.DownloadFile(address:=URL, destinationFileName:=temppath, userName:=String.Empty, _
                                                             password:=String.Empty, showUI:=False, connectionTimeout:=30000, overwrite:=True)
                    pctCam1LastImage.Image = LoadAndCloneImage(temppath, tempIm) ' Load temp image for viewing and saving
                    '                    pctCam1LastImage.Image = Image.FromFile(temppath)
                Case WEBCAM
                    'pctCam1LastImage.Image =
                    WebCamTakePicture()

            End Select
            'txtOutput.Text = "Image1 downloaded"


            If bBeepOnCapture Then
                Beep()
                ''    My.Computer.Audio.Play(My.Resources.Beep_Ping_SoundBible_com_217088958, AudioPlayMode.Background)
            End If

            Return 1
        Catch ex As Exception
            txtOutput.Text = ex.Message
            Return 0

        End Try


    End Function

    Private Function cropImage(curIm As Image, topLeft As Point, widHgt As Point) As Bitmap


        Using croppedIm = New Bitmap(widHgt.X, widHgt.Y)
            Using grp = Graphics.FromImage(croppedIm)
                grp.DrawImage(
                    curIm, topLeft.X, topLeft.Y, widHgt.X, widHgt.Y)
            End Using
            Return croppedIm
        End Using

    End Function


    Private Sub OpenFolder(sPath As String, Optional Minimized As Boolean = False)
        Try
            Dim curProcess As Process = New Process()
            With curProcess
                With .StartInfo
                    .FileName = "explorer.exe"
                    .Arguments = sPath
                    If Minimized = True Then
                        .WindowStyle = ProcessWindowStyle.Minimized 'ProcessWindowStyle.Hidden
                    End If
                End With
                .Start()
            End With
            '            Process.Start("explorer.exe", sPath, )

        Catch ex As Exception
            Beep()
            txtOutput.Text = "Could not open folder."
        End Try

    End Sub

    'Private Sub DownloadImage(url1, Optional url2 = "")

    '    Dim request As Net.HttpWebRequest = DirectCast(Net.HttpWebRequest.Create(config.camURL1), Net.HttpWebRequest)
    '    request.KeepAlive = False
    '    Try

    '        Dim response As Net.HttpWebResponse = DirectCast(request.GetResponse, Net.HttpWebResponse)
    '        Dim img As Image = Image.FromStream(response.GetResponseStream())
    '        img.Save(rootTempFullSavePath1)
    '        img.Dispose()

    '        response.Close()
    '        request.Abort()

    '        response = Nothing
    '        request = Nothing
    '    Catch ex As Exception
    '        Beep()
    '        txtOutput.Text = "Couldn't download QR. Error message was: " & vbCrLf & ex.Message
    '    End Try
    'End Sub
    ''' <summary>
    ''' The screen is sizex in pixels but we need to print in real lengths so we scale the 
    ''' box sizes to match the desired size in inches for the print output
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetDPI()
        Dim dspGraphics As Graphics
        dspGraphics = Me.CreateGraphics ' Graphics for user's display
        dpiX = dspGraphics.DpiX
        dpiY = dspGraphics.DpiY
        dspGraphics.Dispose()

        labelWPx = dpiY * labelWIn
        labelHPx = dpiX * labelHIn

        QRWPx = dpiY * QRWIn
        QRHPx = dpiY * QRHIn


        ' txtOutput.Text = "X: " & dpiX & " | Y: " & dpiY & "LabelW = " & labelWPx & " | LabelH = " & labelHPx

        ''Might be needed:
        '  Panel1.Width = labelWPx
        '  Panel1.Height = labelHPx

        'Resize QR box to be standard correct size:
        pctQR.Width = QRWPx
        pctQR.Height = QRHPx
        panPrintButtons.Left = pctQR.Right

        'While we are at it set pctQR to be higher quality


    End Sub
    Private Function ShowHideCam2(show As Boolean) 'If show is false then we hide cam 2 fields

        'Show/hide controls
        cmbCam2CamType.Visible = show
        txtURL2.Visible = show
        lblCam2LastImage.Visible = show
        pctCam2LastIm.Visible = show

        'Resize form:
        If show = False Then
            ' Me.Width = pctImageLiveImage.Location.X + pctImageLiveImage.Width + 20
        End If

    End Function

    Private Function SelectFile() As String
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Return fd.FileName
        Else
            Return ""
        End If

    End Function

    Private Sub ImportData()
        ''Uncomment to have user select the file when this is run:"
        'Dim OpenFileDialog As New OpenFileDialog
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'OpenFileDialog.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"

        'If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

        'Dim fi As New FileInfo(OpenFileDialog.FileName)
        'Dim FileName As String = OpenFileDialog.FileName

        updateSettings() 'Make sure dbFilePath is set to current value
        'If computer just turned on, often a mapped drive won't exist so we have to open the folder first
        'Check if drive is Network and if it is, open it in the background and notify user
        Dim dbpth As String = GetPathFromFileNamePath(config.dbPath)
        If GetDriveType(VB.Left(dbpth, 3)) = "Network" Then
            'Check if we can load the path because we we don't need to open it again if it is already opened:
            If Not (My.Computer.FileSystem.DirectoryExists(dbpth)) Then
                Beep()
                txtOutput.Text = "Path to DB was detected as a network path that was not available." & vbCrLf &
                    "Folder is being opened in the background to assure windows can access it. If the program hangs or something doesn't work right,  " & _
                    " close this program then open the folder manually. Then restart this program." & vbCrLf & "DB path is: " _
                    & vbCrLf & dbpth
                OpenFolder(dbpth, True)
                Me.Focus()
                GoToScanBox()
            End If
        End If

        Try 'Catch if DB file doesn't exist
            Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(config.dbPath)
            TextFileReader.TextFieldType = FileIO.FieldType.Delimited
            TextFileReader.SetDelimiters(",")

            Dim TextFileTable As DataTable = Nothing

            Dim Column As DataColumn
            Dim Row As DataRow
            Dim UpperBound As Int32
            Dim ColumnCount As Int32
            Dim CurrentRow As String()

            While Not TextFileReader.EndOfData
                Try
                    CurrentRow = TextFileReader.ReadFields()
                    If Not CurrentRow Is Nothing Then
                        ''# Check if DataTable has been created
                        If TextFileTable Is Nothing Then
                            TextFileTable = New DataTable("TextFileTable")

                            ''# Get number of columns
                            UpperBound = CurrentRow.GetUpperBound(0)
                            ''# Create new DataTable
                            For ColumnCount = 0 To UpperBound
                                Column = New DataColumn()
                                Column.DataType = System.Type.GetType("System.String")
                                Column.ColumnName = "Column" & ColumnCount
                                Column.Caption = "Column" & ColumnCount
                                Column.ReadOnly = True
                                Column.Unique = False
                                Column.ColumnName = CurrentRow(ColumnCount)

                                TextFileTable.Columns.Add(Column)
                            Next
                        Else
                            'After we have created the header row then add the data to the rest of the table 
                            '  one row at a time
                            '                        If TextFileReader.LineNumber > 2 Then 'Not sure why first line number is 2 but it is
                            Row = TextFileTable.NewRow

                            For curCol = 0 To UpperBound 'Index from 1 to skip headers
                                Row(curCol) = CurrentRow(curCol).ToString
                            Next
                            TextFileTable.Rows.Add(Row)

                        End If

                    End If

                Catch ex As  _
                Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & _
                    "is not valid and will be skipped.")
                End Try
            End While

            TextFileReader.Dispose()

            DataGridView1.DataSource = TextFileTable
            DataGridView1.AutoResizeColumns()
        Catch ex As Exception
            Beep()
            txtOutput.Text = "Error loading db file from file path:" & vbCrLf & config.dbPath & vbCrLf & "Error message: " & ex.Message
        End Try


        'End If

        GoToScanBox()

    End Sub

#Region "Load and save config file"

    '''''''''''''''''''''''''
    Private Sub loadConfig()
        ''First check that file exists, if it doesn't create a file with the default config values, if it does, load it
        'Dim configFilePath As String = "C:\a_data\TimeStreams\Borevitz\_data\leafscan\LeafScanVB\BVZ0022_config.csv"
        'If Not (IO.File.Exists(configFilePath)) Then ' Create the file
        '    makeConfig() '[TB NOTE] -this doesn't do anything right now - do I need this?
        '    Return
        'End If
        ''Dim userData As IO.FileStream

        ''Try
        ''    ' Create a file that the application will store user specific data in.
        ''    userData = New IO.FileStream(appDataPath, IO.FileMode.OpenOrCreate)
        ''    userData.Close() 'After it is created it needs to be closed
        ''Catch e As IO.IOException
        ''    ' Inform the user that an error occurred.
        ''    MessageBox.Show("An error occurred while attempting to show the application." + _
        ''                    "The error is:" + e.ToString())

        ''    ' Exit the current thread instead of showing the windows.
        ''    'ExitThread()
        ''End Try
        On Error Resume Next
        ''If path to config doean't exist, create it
        Dim config As System.IO.FileInfo
        config = My.Computer.FileSystem.GetFileInfo(appDataPath)

        If (Not System.IO.Directory.Exists(config.DirectoryName)) Then
            System.IO.Directory.CreateDirectory(config.DirectoryName)
        End If

        Using MyReader As New Microsoft.VisualBasic.
                            FileIO.TextFieldParser(appDataPath)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters("=")
            Dim currentData() As String
            While Not MyReader.EndOfData

                ' currentData = Split(MyReader.ReadLine, "= ")
                currentData = MyReader.ReadFields()
                '      Beep()
                Select Case currentData(0)
                    Case "expID"
                        txtExpID.Text = currentData(1)
                    Case "user"
                        txtUserName.Text = currentData(1)
                    Case "txtFileSavePath"
                        txtFileSavePath.Text = currentData(1)
                    Case "dbPath"
                        txtPathToDB.Text = currentData(1)
                    Case "camURL1"
                        txtURL1.Text = currentData(1)
                    Case "camURL2"
                        txtURL2.Text = currentData(1)
                    Case "UseCam2"
                        chkUseCam2.Checked = currentData(1)
                    Case "Cam1Type"
                        cmbCam1CamType.Text = currentData(1)
                    Case "Cam2Type"
                        cmbCam2CamType.Text = currentData(1)
                    Case " AutoPrintLabel"
                        chkAutoPrint.Checked = currentData(1)
                    Case "txtCountDownTimeSecs"
                        txtCountDownTimeSecs.Text = currentData(1)
                    Case "cmbVideoSource"
                        gSelectedWebCamName = currentData(1)
                        Dim camIndexNum = cmbVideoSource.FindStringExact(currentData(1))
                        ' If camIndexNum > 0 Then cmbVideoSource.SelectedIndex = camIndexNum
                    Case "cmbVideoSize"
                        gWebCamVideoSize = currentData(1)
                        Dim vidSize = cmbVideoModes.FindStringExact(currentData(1))
                        '   If vidSize > 0 Then cmbVideoModes.SelectedIndex = vidSize
                    Case "gCamFocus"
                        gCamFocus = currentData(1)
                    Case "bCamAutoFocus"
                        bCamAutoFocus = currentData(1)
                    Case "bBeepOnCapture"
                        chkBeepOnCapture.Checked = currentData(1)

                End Select

                updateSettings()
                '[TB] Can'te use try catch if we want to only skip the lines that didn't load right
                ''Catch ex As Microsoft.VisualBasic.
                ''            FileIO.MalformedLineException
                ''    MsgBox("Line " & ex.Message &
                ''    "is not valid and will be skipped.")
                ''End Try
            End While
        End Using


    End Sub

    Private Sub saveConfig(configPath)


        My.Settings.Save()

        'We just overwrite the config file every time we save it. If there is no file it will get written with the default data
        Dim TRACE_ERR As Integer
        TRACE_ERR = 0
        Dim intCurrentTraceLevel As Object
        intCurrentTraceLevel = TRACE_ERR

        Dim fs As Object
        fs = CreateObject("Scripting.FileSystemObject")
        Dim A As Object

        Const Overwrite As Boolean = True
        Try

            A = fs.CreateTextFile(configPath, Overwrite, True)
            A.writeline("expID=" & config.expID)
            A.writeline("user =" & config.user)
            A.writeline("dbPath =" & config.dbPath)
            A.writeline("camURL1 =" & config.camURL1)
            A.writeline("camURL2 =" & config.camURL2)
            A.writeline("UseCam2 =" & chkUseCam2.Checked)
            A.writeline("Cam1Type =" & cmbCam1CamType.Text)
            A.writeline("Cam2Type =" & cmbCam2CamType.Text)
            A.writeline("AutoPrintLabel =" & chkAutoPrint.Checked)
            A.writeline("txtFileSavePath =" & txtFileSavePath.Text)
            A.writeline("txtCountDownTimeSecs =" & txtCountDownTimeSecs.Text)
            A.writeline("cmbVideoSource =" & cmbVideoSource.Text) 'We store the text rather than the index which makes it easier to find the camera if it exists
            A.writeline("cmbVideoSize =" & cmbVideoModes.Text) 'We store the text rather than the index which makes it easier to find the camera if it exists
            A.writeline("gCamFocus =" & gCamFocus) 'Current camera focus setting
            A.writeline("bCamAutoFocus =" & bCamAutoFocus) 'Current camera focus setting
            A.writeline("bBeepOnCapture =" & bBeepOnCapture) 'does program beep before and after capture (annoying if capture is instant, needed if capture is delayed')

            A.Close()
        Catch ex As Exception
            txtOutput.Text = ex.Message
        End Try



    End Sub

#End Region 'Config files


#Region "QR codes"

    Private Sub BuildQR()
        BuildQRURL()
        If txtURL1.Text <> "" Then
            btnGetQR.BackColor = Color.Red

            DownloadQRImage()
            btnGetQR.BackColor = Color.LightGray
        End If
    End Sub
    Private Sub DownloadQRImage()

        Dim request As Net.HttpWebRequest = DirectCast(Net.HttpWebRequest.Create(qrURL), Net.HttpWebRequest)
        request.KeepAlive = False

        Dim response As Net.HttpWebResponse = DirectCast(request.GetResponse, Net.HttpWebResponse)
        Dim img As Image = Image.FromStream(response.GetResponseStream())

        If Not pctQR Is Nothing Then
            Dim pctq As Graphics = pctQR.CreateGraphics()
            pctq.InterpolationMode = Drawing2D.InterpolationMode.Bicubic
            pctQR.SizeMode = PictureBoxSizeMode.StretchImage
            pctQR.Image = img
            '            pctQR.Image.Save("C:\qr.jpg")
        End If

        response.Close()
        request.Abort()

        response = Nothing
        request = Nothing
    End Sub

    Private Sub BuildQRURL()
        Dim googleQuery As String = "http://chart.apis.google.com/chart?cht=qr&choe=UTF-8&cld=H%7C0&chs=100x100&chl="
        '' Use this code when building a longer QR code and working with a DB:
        ''If labelType = PLANT Then
        ''    txtPlantID.Text = googleQuery & stExpID & "_" & stANID & "_" & stAccession & "_TR" & stpotLocation & "_" & stStartDate
        ''ElseIf labelType = TRAY Then
        ''    txtPlantID.Text = googleQuery & stExpID & "_" & stUser & "_TR" & stTrayNum & "_" & stStartDate
        ''End If
        qrURL = New Uri(googleQuery & txtBarcodeValue.Text)

        Try

        Catch ex As Exception
            qrURL = New Uri(txtBarcodeValue.Text)

        End Try

    End Sub
#End Region 'QR Codes


#Region "Printing"

    Private Sub ListPrinters()
        Dim printerList As String = ""
        Dim numPrinters As Integer = PrinterSettings.InstalledPrinters.Count

        'Add first printer
        printerList = PrinterSettings.InstalledPrinters.Item(0)
        'Add the rest
        For i = 1 To numPrinters - 1
            printerList = printerList & vbCrLf & PrinterSettings.InstalledPrinters.Item(i)
        Next
        txtOutput.Text = printerList

    End Sub

    Private Sub SetPrinter()
        Try
            PrintDocument1.PrinterSettings.PrinterName = stPrinterToUse

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'This Sub is gets called by the PrintDocument1.print call. This is where we add the text
    Private Sub printDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ''Uncomment this to print a QR code along with the text
        'e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        'e.Graphics.DrawImage(pctQR.Image, 25, -20, QRWPx, QRHPx)
        'e.HasMorePages = False

        'Declare the fonts to use:
        Dim fnt1 As New Font("Arial Narrow", 8.0F, FontStyle.Regular)
        Dim fnt3 As New Font("Arial Narrow", 10.0F, FontStyle.Regular)
        Dim fnt2 As New Font("Arial Narrow", 10.0F, FontStyle.Bold)
        Dim fntBarCode As New Font("Free 3 of 9", 30.0F, FontStyle.Regular)

        'Text Location:
        '        Dim location As PointF = New PointF(85.0F, 20)
        Dim location As PointF = New PointF(70.0F, 8)
        Dim stepSize As Integer = 15

        If labelType = SEED Then
            e.Graphics.DrawString("*" & curPlant.plantID & "*", fntBarCode, Brushes.Black, location.X, location.Y)
            e.Graphics.DrawString("Plant Name: " & curPlant.plantName, fnt1, Brushes.Black, location.X, location.Y + 2 * stepSize)
            e.Graphics.DrawString("Chamber: " & sPad(curPlant.cabinet, 2) & "  |  PotLoc: " & curPlant.potLoc, fnt1, Brushes.Black, location.X, location.Y + (3 * stepSize))
            e.Graphics.DrawString("Position: " & curPlant.plantPos & "  |  PlantID: " & curPlant.plantID, fnt1, Brushes.Black, location.X, location.Y + (4 * stepSize))
            e.Graphics.DrawString("expID: " & curPlant.expID & "  |  User: " & curPlant.user, fnt1, Brushes.Black, location.X, location.Y + (5 * stepSize))

        ElseIf labelType = TRAY Then
            'Draw the text next to the bar code
            location.X = location.X + 5 'Bar code is bigger with less info so text needs to shift right
            ' e.Graphics.DrawString("TRAY #: " & curPlant.potLoc, fnt2, Brushes.Black, location.X, location.Y)
            e.Graphics.DrawString("USR: " & curPlant.user, fnt2, Brushes.Black, location.X, location.Y + stepSize)
            e.Graphics.DrawString("EXP: " & curPlant.expID, fnt1, Brushes.Black, location.X, location.Y + (2 * stepSize))
            'e.Graphics.DrawString("STD: " & curPlant.StartDate, fnt1, Brushes.Black, location.X, location.Y + (3 * stepSize))
        ElseIf labelType = PLANT Then
            'Draw the text next to the bar code
            e.Graphics.DrawString("TRL: " & curPlant.potLoc, fnt2, Brushes.Black, location.X, location.Y)
            e.Graphics.DrawString("ACL: " & curPlant.accession, fnt2, Brushes.Black, location.X, location.Y + stepSize)
            e.Graphics.DrawString("EXP: " & curPlant.expID, fnt1, Brushes.Black, location.X, location.Y + (2 * stepSize))
            e.Graphics.DrawString("AND: " & curPlant.plantID, fnt1, Brushes.Black, location.X, location.Y + (3 * stepSize))
            'e.Graphics.DrawString("STD: " & stStartDate, fnt1, Brushes.Black, location.X, location.Y + (4 * stepSize))
        End If

        'Dispose of the font objects
        fnt1.Dispose()
        fnt2.Dispose()

    End Sub
    Private Sub PrintLabel()

        'BuildQR() - Disabled since we won't be using QR codes for now

        SetPrinter()
        ' TB This was how it was working:
        PrintDocument1.Print()
        GoToScanBox()
    End Sub

#End Region 'Printing

#Region "Buttons and clicks"

    'What we do when barcode has been entered and ENTER is hit:
    Private Sub txtPlantID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcodeValue.KeyDown
        
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            My.Application.DoEvents()
            txtOutput.Text = "Downloading image"
            txtOutput.Update()
            lblProgress.BackColor = Color.Red
            lblLastImageName.Text = ""
            '    lblLastPlantScanned.Text = ""
            lblProgress.Text = "Capturing"
            ' 
            DoProcess() 'Do the actual capture and save of images
            lblProgress.BackColor = Color.Green
            lblProgress.Text = "Ready"
            '   lblLastPlantScanned.Text = "Pot: " & curPlant.potNum & "  ID: " & curPlant.plantID
        End If
    End Sub

    Private Sub btnOpenImFolder_Click(sender As Object, e As EventArgs) Handles btnOpenImFolder.Click
        updateSettings()
        OpenFolder(rootSavePath)
        GoToScanBox()

    End Sub


    Private Sub btnListPrinters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListPrinters.Click
        ListPrinters()
        GoToScanBox()
    End Sub

    Private Sub btnGetQR_Click(sender As Object, e As EventArgs) Handles btnGetQR.Click
        BuildQR()
        GoToScanBox()
    End Sub

    Private Sub btnPrintLabel_Click(sender As Object, e As EventArgs) Handles btnPrintLabel.Click
        PrintLabel()
        GoToScanBox()
    End Sub

    Private Sub btnCheckCam_Click(sender As Object, e As EventArgs) Handles btnCheckCam.Click
        updateSettings()
        CaptureImage(imName01, rootTempFullSavePath(1), config.camURL1, pctCam1LastImage, camType)
        '' CaptureImage(imName02, rootTempFullSavePath(2), config.camURL2, pctImage2)
        GoToScanBox()
    End Sub

    'Import Excel

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ImportData()
        GoToScanBox()
    End Sub
    Private Sub GoToScanBox()
        'Moves the cursor back to the scanner box to catch next text input
        'txtBarcodeValue.Text = ""
        txtBarcodeValue.Focus()
    End Sub

    Private Sub chkAutoPrint_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoPrint.CheckedChanged
        GoToScanBox()
    End Sub
    Private Sub btnSelectSaveFolder_Click(sender As Object, e As EventArgs) Handles btnSelectSaveFolder.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFileSavePath.Text = FolderBrowserDialog1.SelectedPath
            updateSettings()
            GoToScanBox()
        Else
            GoToScanBox()
            Exit Sub
        End If
    End Sub

    Private Sub btnSelectDB_Click(sender As Object, e As EventArgs) Handles btnSelectDB.Click
        GoToScanBox()
        txtOutput.Text = ""
        Dim dbfile As String = SelectFile()
        If IO.File.Exists(dbfile) Then
            txtPathToDB.Text = dbfile
            ImportData()
            updateSettings()
        End If
    End Sub

    Private Sub tmrCapTimer_Tick(sender As Object, e As EventArgs) Handles tmrCapTimer.Tick
        'Wait a few seconds for the user to 
        Beep()
        tmrCapTimer.Enabled = False
    End Sub

    Private Sub chkUseCam2_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseCam2.CheckedChanged
        If chkUseCam2.Checked = True Then
            ShowHideCam2(True)
        Else
            ShowHideCam2(False)
        End If
        updateSettings()
    End Sub




    Private Sub btnReloadDB_Click(sender As Object, e As EventArgs) Handles btnReloadDB.Click
        ImportData()
        GoToScanBox()
    End Sub

#End Region

    Private Sub txtURL1_TextChanged(sender As Object, e As EventArgs) Handles txtURL1.TextChanged

    End Sub



    ' Private Sub lst1_SelectedIndexChanged(sender As Object, e As EventArgs)
    '     txtOutput.Text = lstWebCamSelect.SelectedItem
    '  End Sub

#Region "Webcam Code"

    '' ''<System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As String) As IntPtr
    '' ''End Function

    ''<System.Runtime.InteropServices.DllImport("avicap32.dll", SetLastError:=True)> Private Shared Function capCreateCaptureWindowA(ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hWndParent As IntPtr, ByVal nID As Integer) As IntPtr
    ''End Function

    '' ''<System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> Private Shared Function DestroyWindow(ByVal hwnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    '' ''End Function

    ''Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriverIndex As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean

    ''Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWnd As Integer, ByVal nID As Integer) As Integer

    ''Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriverIndex As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean

    ''Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWnd As Integer, ByVal nID As Integer) As Integer

    '' '''[TIM TEMP] Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    ''Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    ''Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean



    ''Private DriverVersion As Integer



    ''Private Function ReturnDriver() As Integer
    ''    Dim DriverName As String = Space(100)
    ''    Dim DriverVersion As String = Space(100)
    ''    Dim DriverIndex As Integer = Nothing
    ''    For i As Integer = 0 To 9
    ''        If capGetDriverDescriptionA(i, DriverName, 80, DriverVersion, 80) Then
    ''            DriverIndex = i
    ''            Exit For
    ''        End If
    ''    Next
    ''    Return DriverIndex
    ''End Function


#End Region



    ''Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    ''    Dim data As IDataObject
    ''    Dim bmap As Image

    ''    '
    ''    ' Copy image to clipboard
    ''    Try


    ''        '
    ''        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

    ''        '
    ''        ' Get image from clipboard and convert it to a bitmap
    ''        '
    ''        data = Clipboard.GetDataObject()

    ''        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
    ''            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
    ''            Dim gr As Graphics = Graphics.FromImage(bmap)
    ''            gr.DrawLine(Pens.Red, 0, 0, 50, 50)
    ''            ClosePreviewWindow()

    ''            pctImage2.Image = bmap
    ''            pctImage2.Refresh()
    ''            '                pctImage2.Image = bmap.Clone
    ''            pctImage2.Image.Save("C:\test2.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
    ''        End If

    ''        bmap = Nothing
    ''    Catch ex As Exception
    ''        Beep()

    ''    End Try
    ''End Sub

    '' Goes in form load
    ' ''    cWnd = capCreateCaptureWindowA(devId.ToString, WS_VISIBLE Or WS_CHILD, 0, 0, PictureBox1.Width, PictureBox1.Height, PictureBox1.Handle, 0)
    ' ''If Not SendMessage(cWnd, WM_CAP_DRIVER_CONNECT, devId, Nothing) = IntPtr.Zero Then
    ' ''    SendMessage(cWnd, WM_CAP_SET_SCALE, 1, Nothing)
    ' ''    SendMessage(cWnd, WM_CAP_SET_PREVIEWRATE, 66, Nothing)
    ' ''    SendMessage(cWnd, WM_CAP_SET_PREVIEW, 1, Nothing)
    ' ''Else
    ' ''    MessageBox.Show("Error connecting to capture device. Make sure your WebCam is connected and try again.")
    ' ''    cWnd = IntPtr.Zero
    ' ''    Me.Close()
    ' ''End If

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gQuitSleep = True 'make sure sleep loop actually quits
        'kill webcam
        WebCamStopVideo()

        If Not cWnd.Equals(IntPtr.Zero) Then
            SendMessage(cWnd, WM_CAP_DRIVER_DISCONNECT, devId, Nothing)

            DestroyWindow(cWnd)
        End If
        If System.IO.File.Exists(tmppic) Then System.IO.File.Delete(tmppic)
    End Sub




    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCam1CamType.SelectedIndexChanged
        If cmbCam1CamType.Text = "WebCam" Then
            Try
                VideoSourcePlayer1.Visible = True
                VideoSourcePlayer1.Top = pctImageLiveImage.Top
                VideoSourcePlayer1.Width = pctImageLiveImage.Width
                VideoSourcePlayer1.Left = pctImageLiveImage.Left
                VideoSourcePlayer1.Height = pctImageLiveImage.Height
                pctImageLiveImage.Visible = False
                lblWebCam1Info.Visible = True
                '   lstWebCamSelect.Visible = True
                EnumerateVideoDevices()
                WebCamStartVideo()
                pnlWebCamControls.Visible = True
                pnlWebCamControls.Top = txtURL1.Top

            Catch ex As Exception
                Beep()
                txtOutput.Text = (ex.Message)

            End Try
        Else
            WebCamStopVideo()
            lblWebCam1Info.Visible = False
            ' lstWebCamSelect.Visible = False
            pctImageLiveImage.Visible = True
            VideoSourcePlayer1.Visible = False
            pnlWebCamControls.Visible = False

        End If
        updateSettings()
    End Sub

    Private Function WebCamTakePicture()
        Dim sFileName As String
        Dim appPath As String = My.Application.Info.DirectoryPath
        Try
            '     VideoCaptureSource.VideoResolution = VideoCaptureSource.VideoCapabilities(cmbVideoModes.SelectedIndex) 'VideoCaptureDevice(VideoDevices(cmbVideoSource.SelectedIndex).MonikerString).

        Catch ex As Exception

        End Try
        Try

            'Image type is hard coded for now as bmp



            '[TB NOTE' This method currently works but you have to run the app as administrator due to some weird permissions 
            '              issues with copying the temp file out of the appdata/Loca/Temp/ folder

            If VideoSourcePlayer1.IsRunning = True Then
                If My.Settings.ICType = "PNG" Then
                    VideoSourcePlayer1.GetCurrentVideoFrame.Save(rootTempFullSavePath(1), System.Drawing.Imaging.ImageFormat.Png)
                ElseIf My.Settings.ICType = "JPG" Then
                    VideoSourcePlayer1.GetCurrentVideoFrame.Save(rootTempFullSavePath(1), System.Drawing.Imaging.ImageFormat.Jpeg)
                Else
                    VideoSourcePlayer1.GetCurrentVideoFrame.Save(rootTempFullSavePath(1), System.Drawing.Imaging.ImageFormat.Bmp)
                End If
                'Load image to viewer
                pctCam1LastImage.Image = LoadAndCloneImage(rootTempFullSavePath(1), tempIm) ' Load temp image for viewing and saving
            End If
        Catch ex As Exception
            Beep()
            txtOutput.Text = ("Capture Failed." & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Try taking snapshot again when video image is visible." & vbCrLf & "Temp file save path: " & rootTempFullSavePath(1))

        End Try


    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            pctCam1LastImage.Image = WebCamTakePicture()
            pctCam1LastImage.Image.Save(fullSavePath(1))
        Catch ex As Exception
            Beep()

        End Try

    End Sub

    Private Sub txtCountDownTimeSecs_TextChanged(sender As Object, e As EventArgs) Handles txtCountDownTimeSecs.TextChanged
        Try
            If IsNumeric(txtCountDownTimeSecs.Text) Then
                If txtCountDownTimeSecs.Text < 0 Then
                    txtCountDownTimeSecs.Text = 0
                End If
            Else
                txtCountDownTimeSecs.Text = 0
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private WithEvents timer As New Timer
    'Stores the file path, e.g.: "F:\Temp"
    Friend Shared strICLocation As String = My.Settings.ICSet
    'Stores the common name for the file, such as "Capture" (Screenshot, whatever you want)
    Friend Shared strICFileRootName As String = My.Settings.ICRootName
    'Stores the image format to save in a 3 char string: PNG, JPG, BMP
    Friend Shared strICType As String = My.Settings.ICType

    Dim VideoCaptureSource As VideoCaptureDevice
    Dim VideoDevices As New FilterInfoCollection(FilterCategory.VideoInputDevice)
    Private Property VideoCapabilities As VideoCapabilities()
    Dim frame As System.Drawing.Bitmap
    Dim filename As String

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnumerateVideoDevices()

    End Sub

    Private Sub EnumerateVideoDevices()
        ' enumerate video devices
        VideoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        Try
            cmbVideoSource.Items.Clear()
        Catch ex As Exception

        End Try

        If VideoDevices.Count <> 0 Then
            ' add all devices to combo
            For Each device As FilterInfo In VideoDevices
                cmbVideoSource.Items.Add(device.Name)
                cmbVideoSource.SelectedIndex = 0
                VideoCaptureSource = New VideoCaptureDevice(VideoDevices(cmbVideoSource.SelectedIndex).MonikerString)
                EnumerateVideoModes(VideoCaptureSource)
            Next
        Else
            cmbVideoSource.Items.Add("No DirectShow devices found")
        End If
        cmbVideoSource.SelectedIndex = 0
    End Sub

    Private Sub EnumerateVideoModes(device As VideoCaptureDevice)
        ' Exit Sub
        ' get resolutions for selected video source
        Me.Cursor = Cursors.WaitCursor
        cmbVideoModes.Items.Clear()
        Try
            VideoCapabilities = device.VideoCapabilities
            For i = 0 To VideoCapabilities.Count - 1
                If Not cmbVideoModes.Items.Contains(VideoCapabilities(i).FrameSize) Then
                    cmbVideoModes.Items.Add(VideoCapabilities(i).FrameSize)
                End If
            Next
            If VideoCapabilities.Length = 0 Then
                cmbVideoModes.Items.Add("Not supported")
            End If
            cmbVideoModes.SelectedIndex = 0
        Finally
            Me.Cursor = Cursors.[Default]



        End Try
    End Sub

#Region "IC (Image Capture)"


    Private Sub btnICSet_Click(sender As Object, e As EventArgs) Handles btnICSet.Click
        'Make a button called btnICSet to set the save path
        Dim dialog As New FolderBrowserDialog()
        dialog.Description = "Select Image Capture save path"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strICLocation = dialog.SelectedPath
            lblICLocation.Text = strICLocation
        End If
    End Sub

    Private Sub ICCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnICCapture.Click
        'Need a button called btnICCapture.  This is what will initiate the screen cap.
        Dim strFilename As String = strICFileRootName & " " & Format(Now, "yyyy-MMM-dd HH.mm.ss.fff") & "." & My.Settings.ICType
        Try
            txtOutput.Text = strFilename
            If VideoSourcePlayer1.IsRunning = True Then
                If My.Settings.ICType = "PNG" Then
                    filename = filename & ".png"
                    VideoSourcePlayer1.GetCurrentVideoFrame.Save(strFilename, System.Drawing.Imaging.ImageFormat.Png)
                ElseIf My.Settings.ICType = "JPG" Then
                    VideoSourcePlayer1.GetCurrentVideoFrame.Save(strFilename, System.Drawing.Imaging.ImageFormat.Jpeg)
                Else
                    VideoSourcePlayer1.GetCurrentVideoFrame.Save(strFilename, System.Drawing.Imaging.ImageFormat.Bmp)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(strFilename & vbCrLf & "Try taking snapshot again when video image is visible.", "Cannot Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub WebCamStartVideo()
        Try

            If cmbVideoSource.SelectedItem <> "No Video Devices" Then
                If VideoSourcePlayer1.IsRunning = True Then
                    VideoSourcePlayer1.SignalToStop()
                    VideoSourcePlayer1.WaitForStop()
                End If

                VideoCaptureSource = New VideoCaptureDevice(VideoDevices(cmbVideoSource.SelectedIndex).MonikerString)
                Try
                    VideoCaptureSource.VideoResolution = VideoCaptureSource.VideoCapabilities(cmbVideoModes.SelectedIndex)

                    ' VideoCaptureSource.VideoResolution = VideoCaptureSource.VideoCapabilities(18)
                    '  Dim result1 As Boolean = VideoCaptureSource.SetCameraProperty(CameraControlProperty.Exposure, txtBrightness.Text, CameraControlFlags.Manual)
                Catch ex As Exception
                    Beep()
                    txtOutput.Text = "Error loading webcam. Error message: " & ex.Message
                End Try
                Try
                    ' VideoCaptureSource.VideoResolution = VideoCaptureSource.VideoCapabilities(18) 'VideoCaptureDevice(VideoDevices(cmbVideoSource.SelectedIndex).MonikerString).
                    ' Beep()
                    '  VideoCaptureSource.VideoCapabilities(18).FrameSize()

                Catch ex As Exception

                End Try
                VideoSourcePlayer1.VideoSource = VideoCaptureSource

                VideoSourcePlayer1.Start()
            End If
        Catch ex As Exception
            Beep()
            txtOutput.Text = (ex.Message)
        End Try

    End Sub

    Private Sub WebCamStopVideo()
        VideoSourcePlayer1.SignalToStop()
        VideoSourcePlayer1.WaitForStop()
        VideoDevices = Nothing
        VideoCaptureSource = Nothing
    End Sub


    Private Sub cmbVideoModes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVideoModes.SelectedIndexChanged
        If Not formLoaded Then Exit Sub
        If VideoSourcePlayer1.IsRunning = True Then
            Dim imSize() As String
            Try
                ' WebCamStopVideo()

                If Not IsNothing(VideoCaptureSource) Then
                    '                    VideoCaptureSource.VideoResolution = VideoCaptureSource.VideoCapabilities(cmbVideoModes.SelectedIndex)
                    WebCamStartVideo()
                    imSize = Split(Replace(cmbVideoModes.Text, " ", ""), ",")

                    camAspectRatio = GetCamAspectRatio(CInt(imSize(0)), CInt(imSize(1)))
                    Try
                        If IsNumeric(camAspectRatio) Then
                            ' If camAspectRatio > 0 Then VideoSourcePlayer1.Height = VideoSourcePlayer1.Width / camAspectRatio
                        End If

                    Catch ex As Exception

                    End Try
                End If
            Catch ex As Exception
                Beep()

            End Try
            '  VideoCaptureDevice()
        End If
    End Sub
    Private Function GetCamAspectRatio(width, height) As Double
        Dim camAspectRatio As Long = Math.Round((width / height) * 10)
        Select Case camAspectRatio
            Case Is = 43
                Return FOURTHREE
            Case 13
                Return THREETWO
            Case 18
                Return SIXTEENNINE

            Case 1
                Return 1
        End Select


    End Function
    Private Sub cmbVideoSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVideoSource.SelectedIndexChanged
        If Not formLoaded Then Exit Sub 'Prevent endless loop as combo box is populated


        WebCamStartVideo()
        EnumerateVideoModes(VideoCaptureSource)
        WebCamStartVideo()
        'SetFocusRange()
        ' updateSettings()
    End Sub

    Private Sub btnReloadWebcam_Click(sender As Object, e As EventArgs) Handles btnReloadWebcam.Click
        EnumerateVideoDevices()
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        SetFocusRange()

    End Sub
    Private Sub SetFocusRange()
        Dim min As Integer = 0
        Dim max As Integer = 0
        Dim current As Integer = 0
        '  Dim result2 As Boolean = VideoCaptureSource.SetCameraProperty(CameraControlProperty.Focus, txtBrightness.Text, CameraControlFlags.Manual)
        Dim result3 As Boolean = VideoCaptureSource.GetCameraPropertyRange(CameraControlProperty.Focus, min, max, 1, 255, CameraControlFlags.Manual)
        trkFocus.Minimum = min
        trkFocus.Maximum = max
        If gCamFocus > 0 And gCamFocus <= max Then
            trkFocus.Value = gCamFocus
        End If

    End Sub

    Private Sub trkBrightness_Scroll(sender As Object, e As EventArgs) Handles trkFocus.Scroll
        Dim min As Integer = 0
        Dim max As Integer = 0
        Dim current As Integer = 0
        '  Dim result2 As Boolean = VideoCaptureSource.SetCameraProperty(CameraControlProperty.Focus, txtBrightness.Text, CameraControlFlags.Manual)
        Dim result3 As Boolean = VideoCaptureSource.GetCameraPropertyRange(CameraControlProperty.Focus, min, max, 1, 100, CameraControlFlags.Manual)
        Try
            Dim result2 As Boolean = VideoCaptureSource.SetCameraProperty(CameraControlProperty.Focus, trkFocus.Value, CameraControlFlags.Manual)
            txtOutput.Text = min & "|" & max & "|" & current
            lblFocus.Text = trkFocus.Value
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnSetSize_Click(sender As Object, e As EventArgs)
        WebCamStartVideo()

    End Sub

    Private Sub pctCam1LastImage_Click(sender As Object, e As EventArgs) Handles pctCam1LastImage.Click
        Try
            Process.Start(rootTempFullSavePath(1))

        Catch ex As Exception
            Beep()
            txtOutput.Text = "Error loading last image from filepath: " & rootTempFullSavePath(1) & vbCrLf & "Error message: " & ex.Message
        End Try
    End Sub

    Private Sub tmrSetVideoSize_Tick(sender As Object, e As EventArgs) Handles tmrSetVideoSize.Tick
        '     WaitForChangedResult for the webcam to load and then try to set the video size 
        Application.DoEvents()
        Try
            If cmbCam1CamType.Text = "WebCam" Then
                If VideoSourcePlayer1.VideoSource.IsRunning Then
                    Dim vidSizeIndex = cmbVideoModes.FindStringExact(gWebCamVideoSize)
                    If vidSizeIndex > 0 Then cmbVideoModes.SelectedIndex = vidSizeIndex
                    tmrSetVideoSize.Enabled = False
                Else
                    gSetSizeTimer = gSetSizeTimer + 1
                End If
            End If

            If gSetSizeTimer > 10 Then Exit Sub 'Quit after five seconds of trying

        Catch ex As Exception
            tmrSetVideoSize.Enabled = False
        End Try

    End Sub
End Class
