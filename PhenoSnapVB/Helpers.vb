Option Strict Off
Option Explicit On

Imports VB = Microsoft.VisualBasic
Imports System.Drawing.Imaging 'For jpeg resizing and compressiong

Module Helpers

    Public gIntTraceLevel As Integer

    Public Const TRACE_ERROR_SERIOUS As Short = 1
    Public Const TRACE_ERROR_MINOR As Short = 2
    Public Const TRACE_FUNCTION As Short = 3
    Public Const TRACE_PROBLEM_MINOR As Short = 4
    Public Const TRACE_STEP As Short = 5
    Public Const TRACE_BULK As Short = 6

    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    'For image resizing:
    Dim gBitmap As Bitmap
    ' For jpeg compression: [these can be modified ahead of time by the calling form]
    Public gDblJPEGCompression As Double = 90
    Public gInterpolationMode As Drawing2D.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic


    'Write a statement to the trace log if the trace msg has a higher level then the configured tracelevel
    Public Sub DoTrace(ByVal strMsg As Object, ByVal intTraceLevel As Object)

        Dim strString As String
        Dim strTraceLevel As String

        'If tps.intTraceLevel >= intTraceLevel Then
        If gIntTraceLevel >= intTraceLevel Then

            Select Case intTraceLevel
                Case 1
                    strTraceLevel = "ERROR_SERIOUS"
                Case 2
                    strTraceLevel = "ERROR_MINOR"
                Case 3
                    strTraceLevel = "FUNCTION"
                Case 4
                    strTraceLevel = "PROBLEM_MINOR"
                Case 5
                    strTraceLevel = "STEP    "
                Case 6
                    strTraceLevel = "BULK    "
            End Select

            strString = TimeString & " - " & GetTickCount() & " - " & strTraceLevel & " - " & strMsg
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\tracelog.txt", strString & Chr(13) & Chr(10), True)

        End If
    End Sub
    ''' <summary>
    ''' Returns drive type
    ''' </summary>
    ''' <param name="driveLetter">Format: "C:\"</param>
    ''' <returns>Either text of drive type or NULL if it fails</returns>
    ''' <remarks></remarks>
    Public Function GetDriveType(driveLetter As String) As String
        Try
            Return My.Computer.FileSystem.GetDriveInfo(driveLetter).DriveType.ToString

        Catch ex As Exception
            Return "Null"
        End Try

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' blnFileExists
    ' CLZ
    '   Returns true if a file or folder already exists
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function blnFileExists(ByRef filename As String) As Boolean
        DoTrace("blnFileExists(" & filename & ")", TRACE_FUNCTION)

        blnFileExists = My.Computer.FileSystem.FileExists(filename)
    End Function

    Public Function blnFileExistsAndLargerThanK(ByRef filename As String, ByRef intMinSizeKB As Integer) As Boolean
        DoTrace("blnFileLargerThanK(" & filename & "," & intMinSizeKB & ")", TRACE_FUNCTION)
        Dim intKB As Long
        blnFileExistsAndLargerThanK = False

        If (My.Computer.FileSystem.FileExists(filename)) Then
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo(filename)
            intKB = infoReader.Length / 1024
            If intKB > intMinSizeKB Then
                blnFileExistsAndLargerThanK = True
            End If
        End If

    End Function



    Public Function FileExists(ByRef filename As Object) As Boolean
        '    DoTrace("FileExists(" & filename & ")", TRACE_FUNCTION)

        FileExists = (Dir(filename) <> "")
    End Function




    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' WriteToLog
    ' CLZ
    '  Write to a log file.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub WriteToLog(ByVal strString As Object, ByVal intTraceLevel As Object)
        Dim TRACE_ERR As Integer
        TRACE_ERR = 0
        Dim intCurrentTraceLevel As Object
        intCurrentTraceLevel = TRACE_ERR

        Dim fs As Object
        fs = CreateObject("Scripting.FileSystemObject")
        Dim A As Object

        Const ForAppending As Short = 8
        If intCurrentTraceLevel >= intTraceLevel Then
            'If True Then

            A = fs.OpenTextFile("0 log.txt", ForAppending, True)
            A.writeline(Now & " - " & strString)
            A.Close()

        End If
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' UBoundZero
    ' CLZ
    '  Fixes problem with UBound.
    '  If array is uninitialized, then it returns 0 as the length of the array.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function UBoundZero(ByRef aArray As Object) As Integer
        If IsNothing(aArray(0)) Then
            UBoundZero = 0
        Else
            UBoundZero = UBound(aArray(0))
        End If
    End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' sPad
    ' CLZ
    ' Pads a number with zeros. Important for writing those dates!
    ' for example, give 34 and 4, and you recieve "0034"
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Friend Function sPad(ByRef iNum As Integer, ByRef iTimes As Integer) As String
        'DoTrace("SaveBookmark()", TRACE_FUNCTION)
        'Make sure iNum isn't longer than iTimes
        If iTimes - Len(CStr(iNum)) < 1 Then
            iTimes = Len(CStr(iNum))
        End If
        sPad = New String("0", iTimes - Len(CStr(iNum))) & CStr(iNum)
    End Function

    Friend Function sPadText(ByRef sNum As String, ByRef iTimes As Integer) As String
        'DoTrace("SaveBookmark()", TRACE_FUNCTION)

        Return New String("0", iTimes - Len(sNum)) & sNum
    End Function


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' iMakeInt
    ' TB
    ' Strips the letters out of an alphnumeric string and returns an int
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Friend Function iMakeInt(ByVal myString As String) As Integer


        Dim outputnum As String
        Dim curLetter As String
        Dim i As Integer

        For i = 1 To VB.Len(myString)
            curLetter = Mid(myString, i, 1)
            If IsNumeric(curLetter) Then outputnum = outputnum & curLetter
        Next

        iMakeInt = outputnum

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' TB
    '' Functions added to make the QuickTime export work
    ''''''''''''''''''''''''''''''''''''''''''''''''''''

    Friend Function GetFileSize(ByVal filename As String) As Integer
        Try
            Dim intKB As Integer 'Filesize in kb

            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo(filename)
            intKB = infoReader.Length / 1024

            Return intKB

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Friend Function GetFilenameFromPath(ByVal fileNamePath As String) As String
        Dim slashPos As Integer = VB.InStrRev(fileNamePath, "\")
        Dim stringLen As Integer = VB.Len(fileNamePath)
        Return VB.Right(fileNamePath, stringLen - slashPos)
    End Function
    Friend Function GetIndexOf(colNameText As String, DataGridView As DataGridView) As Integer
        Try
            For i = 0 To (DataGridView.Columns.Count - 1)
                If UCase(DataGridView.Columns(i).Name) = UCase(colNameText) Then 'Forcing to uppercase means the comparison isn't case sensitive
                    Return i
                End If
            Next

            'If we haven't returned then the columnIndex value wasn't found so return 0
            Return 0 'i.e we failed to find the column index

        Catch ex As Exception
            Beep()
            'txtOutput.Text = "Couldn't find column named " & colNameText & vbCrLf & "Error: " & ex.Message
            Return 0

        End Try
    End Function

    Friend Function GetPathFromFileNamePath(ByVal fileNamePath As String) As String
        Dim slashPos As Integer = VB.InStrRev(fileNamePath, "\")
        Dim stringLen = VB.Len(fileNamePath)
        Dim result As String = VB.Left(fileNamePath, slashPos)
        Return result
    End Function

    '' [tb] Add text to a bitmap, returns a bitmap
    Friend Function AddWatermark(ByVal WatermarkText As String, ByVal textColor As String, ByVal backColor As String, ByVal alignText As String, ByVal textYPos As Integer, ByVal txtFontSize As Single, ByVal imageBM As Bitmap) As Bitmap

        'NOTE: For the moment there is no option for the image X position because this is set by the text alignment
        '      In practice this means that the text will either  left, center, or right justified

        Try
            Dim grfx As Graphics = Graphics.FromImage(imageBM)

            Dim textXPosition As Integer
            Dim brushColor As New SolidBrush(Color.White) 'Color.LightGray

            Dim rectHeight As Integer = txtFontSize * 2
            ' Dim rectColor As New Pen(Color.Transparent, rectHeight)  'This sets the edges of the rectangle to not be colored

            If textColor = "Black" Then
                brushColor = New SolidBrush(Color.Black)
            ElseIf textColor = "Gray" Then
                brushColor = New SolidBrush(Color.Gray)
            End If

            Dim drawFont As New Font("", txtFontSize, FontStyle.Bold, GraphicsUnit.Pixel)

            '' Set text alignment:
            Dim textAlign As New StringFormat(StringFormatFlags.NoClip)

            If alignText = "Middle" Then
                textAlign.Alignment = StringAlignment.Center
                textXPosition = imageBM.Width / 2
            ElseIf alignText = "Right" Then
                textAlign.Alignment = StringAlignment.Far
                textXPosition = imageBM.Width - 5
            Else 'Default is left alignment
                textAlign.Alignment = StringAlignment.Near
                textXPosition = 5
            End If

            ' Create background rectangle for text box and draw rect to image
            ' Values can be "White" "Black" "None"
            Dim backRect As New Rectangle(0, textYPos, imageBM.Width, rectHeight)

            'grfx.DrawRectangle(rectColor, 0, textYPos - 3, imageBM.Width, rectHeight)

            'Default rectangle color is translucent White:
            Dim backRectColor As Color = Color.FromArgb(85, 255, 255, 255) 'For ARGB values, the first value is transparecny the other three are RGB)
            If backColor = "Black" Then
                'rectColor = New Pen(Color.Black, rectHeight)
                backRectColor = Color.FromArgb(80, 0, 0, 0)
            ElseIf backColor = "None" Then
                backRectColor = Color.Transparent
            End If

            grfx.FillRectangle(New SolidBrush(backRectColor), backRect)

            grfx.DrawString(WatermarkText, drawFont, brushColor, backRect, textAlign)
            'System.Drawing.StringFormat.GenericTypographic)

            grfx.Dispose()

            Return imageBM


        Catch ex As Exception
            DoTrace("Error adding watermark. Exception Message: """ & ex.Message & "", 1)

        End Try

    End Function

    Friend Function CreateFolder(ByRef folderName As String) As Integer

        ' [tb] I need some way to skip this function if the second filepath = "" because it was unused.
        '     This acts as a switch so if there is no secondary filepath being saved this function doesn't get called
        '     I don't know if this is the best solution but it works for now.
        If folderName = "" Then Exit Function

        On Error GoTo ErrorHandler
        If Not (My.Computer.FileSystem.DirectoryExists(folderName)) Then
            My.Computer.FileSystem.CreateDirectory(folderName)
        End If

        CreateFolder = 1

        Exit Function

ErrorHandler:  ' Error-handling routine.
        Select Case Err.Number ' Evaluate error number.
            Case 70 ' "File already open" error.
                MsgBox("Folder: " & folderName & " could not be created.")
            Case Else
                ' Handle other situations here...
        End Select
        CreateFolder = 0
        Exit Function ' Resume execution at same line
        ' that caused the error.
    End Function
    '=======================================================================================
    '
    ' TB
    ' This code takes a date and calculates the full filepath and filename
    '  This was modified from "GetSavePathAndMakeDirs" and  "StrGetImageFileName"
    '  It was written to provide a filelist for QT to make movies out of
    ' --> 
    ' Known Limitations:
    '  * Does not handle subSecond naming (This wouldn't matter unless you were making
    '     long movies or movies of shorter times (i.e. where you would want all the frames)
    '
    '  * Does not Handle MultiCam
    '
    '  * If the filelist generated is not Frame Accurate, all the seconds values will be
    '    off and no images will be found(!)
    '
    '=======================================================================================
    Friend Function GetFullFilePath(ByVal savePath As String, ByVal datDate As DateTime, ByVal strTimeStreamName As String, ByVal intSecsPerCapFrame As Integer) As String

        Dim sFilePath As String

        ' Variables for calculating folder name for current image:
        Dim sY As Short
        Dim sH, sM, sD, sN As String

        ' Determine Path Name and Create new DIR if necessary
        sY = datDate.Year
        sM = sPad(datDate.Month, 2)
        sD = sPad(datDate.Day, 2)
        sH = sPad(datDate.Hour, 2)
        sN = sPad(datDate.Minute, 2)

        sFilePath = savePath & "\" & sY & "\" & sY & "_" & sM & "\" & sY & "_" & sM & "_" & sD & "\" & sY & "_" & sM & "_" & sD & "_" & sH & "\"

        'Now do the filename:
        Dim strName As String

        strName = strTimeStreamName & "_" & datDate.Year & "_"
        strName = strName & sPad(datDate.Month, 2) & "_"
        strName = strName & sPad(datDate.Day, 2) & "_"
        strName = strName & sPad(datDate.Hour, 2) & "_"
        strName = strName & sPad(datDate.Minute, 2) & "_"

        ' For seconds, we have to correct for the stepsize not matching the actual recorded step size
        '  (i.e. if SecsToSkip = 8 but images were recorded every 5 seconds...)
        Dim dblCurrentSecondClosest As Double

        dblCurrentSecondClosest = Math.Floor(datDate.Second / intSecsPerCapFrame) * intSecsPerCapFrame 'Whole number

        strName = strName & sPad(dblCurrentSecondClosest, 2) & "_"

        ' [tb] --> NOTE: This is not written to handle sub second naming
        strName = strName & "00"

        GetFullFilePath = sFilePath & strName & ".jpg"

    End Function

    Friend Function ResizeBitmap(ByVal bmToResize As Bitmap, ByVal newWid As Integer, ByVal newHgt As Integer) As Bitmap

        Try
            Dim scale_wid As Single = newWid / bmToResize.Width
            Dim scale_hgt As Single = newHgt / bmToResize.Height

            If Not (gBitmap Is Nothing) Then gBitmap.Dispose()

            '  Dim bm As New Bitmap(file_name)
            ' gBitmap = New Bitmap(bmToResize.Width, bmToResize.Height)
            gBitmap = New Bitmap(bmToResize.Width, bmToResize.Height, Imaging.PixelFormat.Format24bppRgb)
            Dim gr As Graphics = Graphics.FromImage(gBitmap)
            gr.InterpolationMode = gInterpolationMode

            gr.DrawImage(bmToResize, 0, 0)

            '' Make a bitmap for the result.
            Dim bm_dest As New Bitmap(CInt(bmToResize.Width * scale_wid), CInt(bmToResize.Height * scale_hgt), Imaging.PixelFormat.Format24bppRgb)
            ' Dim bm_dest As New Bitmap(CInt(bmToResize.Width * scale_wid), CInt(bmToResize.Height * scale_hgt))

            '' Make a Graphics object for the result Bitmap.
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
            gr_dest.DrawImage(bmToResize, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

            Return bm_dest

            bmToResize.Dispose()

        Catch ex As Exception
            DoTrace("Error resizing bitmap. Exception: " & ex.Message, 1)
        End Try

    End Function

    Friend Function ParseWatermarkText(ByVal WatermarkTxt As String, ByVal curFileName As String) As String
        ' Takes Watermark text and pulls out any formatting characters and replaces them with the appropriate text
        ' For now we are just do FILETIME, FILETIME with current FRAME and FILENAME

        Dim dateParts() As String = curFileName.Split("_")

        WatermarkTxt = WatermarkTxt.Replace("Filename", curFileName)

        ' Make Time and Date strings
        Dim curTime As String = dateParts(4) & ":" & dateParts(5) & ":" & dateParts(6)
        Dim curTimeSubSec As String = dateParts(4) & ":" & dateParts(5) & ":" & dateParts(6) & "(" & VB.Left(dateParts(7), 2) & ")"
        Dim curDate As String = dateParts(1) & "/" & dateParts(2) & "/" & dateParts(3)

        WatermarkTxt = WatermarkTxt.Replace("DDDD", curDate)
        WatermarkTxt = WatermarkTxt.Replace("TTTT", curTime)
        WatermarkTxt = WatermarkTxt.Replace("TFTF", curTimeSubSec)

        Return WatermarkTxt

    End Function

    ''-------------------------------------------------------------------------------
    '' [TB]
    ''  JPEG saving and resizing compression settings:
    ''  From here: http://www.vb-helper.com/howto_net_optimize_jpg.html
    ''      and from CZ original image mover resizer program (April '07)
    '-------------------------------------------------------------------------------


    Friend Sub SaveJPGWithCompressionSetting(ByVal strFileDest As String, ByVal image As Image, ByVal lCompression As Long)
        DoTrace("SaveJPGWithCompressionSetting(szFileName=" & strFileDest & ", lCompression=" & lCompression & ")", TRACE_FUNCTION)

        Dim eps As EncoderParameters = New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, lCompression)
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        image.Save(strFileDest, ici, eps)
    End Sub

    Private Function GetEncoderInfo(ByVal mimeType As String) As Imaging.ImageCodecInfo
        DoTrace("GetEncoderInfo(mimeType=" & mimeType & ")", TRACE_FUNCTION)
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function


    Friend Function LoadAndCloneImage(ByVal fileName As String, ByVal myBitmap As Bitmap) As Bitmap
        If Not (myBitmap Is Nothing) Then myBitmap.Dispose()

        Dim bm As New Bitmap(fileName)
        myBitmap = New Bitmap(bm.Width, bm.Height)

        Dim gr As Graphics = Graphics.FromImage(myBitmap)
        gr.DrawImage(bm, 0, 0, bm.Width, bm.Height)
        bm.Dispose()
        Return myBitmap
    End Function
    'Friend Function FormatTime(ByVal timeInSecs As Long) As String
    '    Dim hrs As String
    '    Dim mins As String
    '    Dim secs As String

    '    hrs = Math.Floor(timeInSecs / 3600)
    '    mins = Math.Floor(((timeInSecs / 3600) - hrs) * 3600)
    '    secs = timeInSecs - Math.Floor(((timeInSecs / 3600) - hrs) * 3600)

    '    If hrs > 0 Then
    '        Return hrs & "Hrs, " & mins & "min, " & secs & "sec."
    '    Else 'No need to format, less than a minute
    '        Return timeInSecs & " secs."
    '    End If
    'End Function

    Function FormatTime(ByVal TimeInMs As Integer) As String
        Dim result As String = ""
        Dim secs As Long = TimeInMs / 1000
        Dim tempTime As Double
        Dim roundTime As Integer

        'Return Math.Round(secs / 60) & " min"

        If secs <= 1 Then
            '  units = " milliseconds"
            result = secs & " sec"
        ElseIf secs > 1 And secs < 60 Then
            result = Math.Floor(secs) & " sec"
        ElseIf secs >= 60 And secs < 3600 Then
            tempTime = (secs / 60)
            roundTime = Math.Floor(tempTime)
            result = roundTime & " min " & Math.Round((tempTime - roundTime) * 60) & " sec"
        ElseIf secs >= 3600 Then
            tempTime = (secs / (60 * 60))
            roundTime = Math.Floor(tempTime)
            result = roundTime & " hr " & Math.Round((tempTime - roundTime) * 60) & " min"
        End If
        Return result
    End Function

    Friend Function GetAspect(ByVal wid As String, ByVal hgt As String) As String
        Try
            If Not (IsNumeric(wid)) Or Not (IsNumeric(hgt)) Then Return "N/A"
            Select Case Math.Round((wid / hgt) * 10)
                Case 13
                    Return "4:3"
                Case 15
                    Return "3:2"
                Case 18
                    Return "16:9"
                Case Else
                    Return Math.Round((wid / hgt) * 10) / 10
            End Select
        Catch ex As Exception
            Return "Could not calculate aspect ratio. Error: " & ex.Message
        End Try
    End Function


End Module
