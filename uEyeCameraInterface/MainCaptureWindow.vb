'Project parameters: (long term)
'---Public parameters:
' - 
'---Engineering parameters:
' - Axis, crosshair and ratio number colors
' - Threshold settings for the ratio
' - Measurement filtering length (moving average over X samples)
' - Camera ID code (for connecting to specific camera, not just the first one!)

Option Explicit On
Option Strict On

Public Class MainCaptureWindow

    '------------------------------------------
    'IO specific objects:

    Dim Logs As New SettingsManager.LogsMangaer("Event Logs")
    Dim WithEvents cam As New uEye.Camera() 'the camera interface object
    Dim WithEvents WebCam As New WebcamCapture() 'the camera interface for the webcam system
    Dim DisplayHandle As IntPtr 'stores the pointer to the picture handle window
    Dim MemId As Int32 'stores the memory ID of the camera
    Dim bLive As Boolean 'stores the state of the live video feed
    Dim uCamActive As Boolean 'tells the system if there is a ucam active
    Private Event NoUeyeFound() 'event fired in the case of no uEye camera connected (allows for other options)
    Private Event UeyeStartStop(ByVal ActiveFeed As Boolean) 'for controlling the avaliability of form buttons/options/timers, etc

    '---------------------------------------
    'form specific objects

    Private ImageZoom As Integer = 100 'the display's zoom value (adjusted using mouse scroll wheel!)
    Private Apoint As Point = New Point(2, 2) 'the storage of point A for the ratio calculations
    Private Bpoint As Point = New Point(1, 1) 'the storege of point B for the ratio calculations
    Private ColorScheme As New ColorsForDisplay 'stores the display colors in a special class
    Private Aval As New Values 'the value at point A (for the status bar display)
    Private Bval As New Values 'the value at point B (for the status bar display)
    Private FPS As New Values 'FPS value for the status bar display
    Dim CurrentImage As Bitmap 'Storage bitmap for the current image
    Dim WithEvents tmrUpdateDisplay As New Windows.Forms.Timer 'Timer for updating the display
    'Calculate the top left corner location of the video image. The position of everything else is based on this location
    Dim ImageTopLeftX As Integer 'as name says, corner of the video feed section
    Dim ImageTopLeftY As Integer 'corner of the video feed section

    '------------------------------------------

    Delegate Sub SetExposureTimeValues(ByVal TimeMS As Double)

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Logs.WriteToEventLog("The form is closing: settings are being saved and camera connections closed.")
        'Close the Camera
        cam.Exit()
        'clear the clipboard
        Clipboard.Clear()
        If bLive Then
            WebCam.ClosePreviewWindow(0)
            Logs.WriteToEventLog("A webcam was active in this session. Camera now closed.")
        End If
        My.Settings.Alocation = Apoint
        My.Settings.Blocation = Bpoint
        Logs.WriteToEventLog("Saving Apoint as (" & Apoint.X.ToString & "," & Apoint.Y.ToString & ") and Bpoint as (" & Bpoint.X.ToString & "," & Bpoint.Y.ToString & ").")
        ColorScheme.SaveColors()
        Logs.WriteToEventLog("The program is closed. Goodbye.....")
        Logs.WriteToEventLog("---------------------------" & vbCrLf)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Logs.WriteToEventLog("The program has been started.")
        Clipboard.Clear() 'clear any old data from the clipboard
        Aval.FilterSmoothing = My.Settings.DataFilterWindow 'Aval filtering value (read from settings)
        Bval.FilterSmoothing = My.Settings.DataFilterWindow 'Bval filtering value (read from settings)
        FPS.FilterSmoothing = My.Settings.DataFilterWindow 'FPS filtering value (read from settings)
        'load colors and points from settings
        Apoint = My.Settings.Alocation
        Bpoint = My.Settings.Blocation
        Logs.WriteToEventLog("Loading locations values: Apoint as (" & Apoint.X.ToString & "," & Apoint.Y.ToString & ") and Bpoint as (" & Bpoint.X.ToString & "," & Bpoint.Y.ToString & ").")

        ColorScheme.LoadColors()

        DisplayHandle = LiveFeedPB.Handle 'assign a handle to display the video (like the webcam)

        CameraInit() 'start the initilistation of the camera
        Logs.WriteToEventLog("Camera initilised. Program is ready for user input(s).")
    End Sub

    Private Sub CameraInit()
        Logs.WriteToEventLog("Beginning the initialisation of the camera.")
        Dim statusRet As uEye.Defines.Status 'A store for the camera status output

        'open the camera:
        statusRet = cam.Init()
        If (statusRet <> uEye.Defines.Status.Success) Then
            Logs.WriteToEventLog("Could not find a uEye camera.")
            Logs.WriteToErrorLog(cam.ToString, "uEye status returned value '" & statusRet.ToString & "'. A successfull camera connection should return value '" & uEye.Defines.Status.Success & "'.", "uEye Camera not found")
            RaiseEvent NoUeyeFound()
            Exit Sub
        End If

        'Allocate Memory
        statusRet = cam.Memory.Allocate(MemId, True)
        If (statusRet <> uEye.Defines.Status.Success) Then
            Logs.WriteToErrorLog(cam.ToString, "uEye status returned value '" & statusRet.ToString & "'. A successfull memory allocation should return value '" & uEye.Defines.Status.Success &
                                 vbCrLf & "'. Attempted to run the function 'cam.Memory.Allocate(" & MemId.ToString & ",True) but failed.", "uEye Camera memory initalisation error")
            MessageBox.Show("Allocation of camera memory buffer failed")
            RaiseEvent NoUeyeFound()
            Exit Sub
        End If
        uCamActive = True

        'Set up the max/min exposures and increments for this
        Dim Emax, Emin, Einc As Double
        cam.Timing.Exposure.GetRange(Emin, Emax, Einc)
        'Put these on to the TB * 1000
        tbExposureValue.Maximum = CInt(Emax * 1000)
        tbExposureValue.Value = CInt((Emax - Emin) * 1000 / 2)
        tbExposureValue.Minimum = CInt(Emin * 1000)
        tbExposureValue.TickFrequency = CInt((Emax - Emin) * 1000 / 20)

        'Turn on autogain and autoexposure
        'cam.AutoFeatures.Software.Gain.SetEnable(cbAutoGain.Checked)
        cam.Timing.Exposure.Set(CDbl(tbExposureValue.Value / 1000))
        cam.AutoFeatures.Software.PeakWhite.SetEnable(cbAutoExpose.Checked)
        Logs.WriteToEventLog("uEye camera OKAY. Memory buffer at address: 0x" & Hex(MemId))
    End Sub

    Private Sub Form1_NoUeyeFound() Handles Me.NoUeyeFound
        'if no uEye camera is found, the program ends up here. Gives the user an option to try a web cam (for fun??)
        uCamActive = False
        Logs.WriteToEventLog("Error setting uEye camera. Offering webcam services to the user...")
        'if the connection was not successfull: display a message (maybe there is no camera??)
        Dim result = MessageBox.Show("uEye camera initialisation falied." & vbCrLf & "Try to look for a webcam?", "No Camera Found", MessageBoxButtons.YesNo)
        If result = Windows.Forms.DialogResult.Yes Then
            'connect to a web cam!
            'no pre-initialisations needed
            Logs.WriteToEventLog("The user has selected to use the webcam interface. No further initialisations needed.")
        Else
            Logs.WriteToEventLog("The user has selected to not use the webcam interface. Beginning shutdown processes.")
            EndSoftware()
        End If

    End Sub

    Private Sub EndSoftware()
        'shutdown the software. But tell the user first!
        MessageBox.Show("No usable cameras were found." & vbCrLf & "Please connect a camera and try to run the software again.", "No Camera Found", MessageBoxButtons.OK)
        Logs.WriteToEventLog("The software has been shutdown from the EndSoftware interface (no cameras detected).")
        Me.Close()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click, StartToolStripMenuItem.Click
        If uCamActive Then
            Logs.WriteToEventLog("Starting the video stream from the uEye camera.")
            StartUeyeLiveFeed()
        Else
            Logs.WriteToEventLog("Starting the video stream from the webcam.")
            StartWebCamLiveFeed()
        End If
    End Sub

    Private Sub StartUeyeLiveFeed()
        Dim statusRet As uEye.Defines.Status 'A store for the camera status output
        'Start Live
        statusRet = cam.Acquisition.Capture()
        If (statusRet <> uEye.Defines.Status.Success) Then
            Logs.WriteToEventLog("Could not start the camera feed. See error log for details.")
            Logs.WriteToErrorLog(cam.ToString, "uEye capture returned value '" & statusRet.ToString & "'. A successfull aquisition should return value '" & uEye.Defines.Status.Success &
                                 vbCrLf & "'. Attempted to run the function 'cam.Aquisition.Capture() but failed.", "uEye Camera aquisition error")
            MessageBox.Show("Start Live Video failed")
            RaiseEvent UeyeStartStop(False)

        Else
            Logs.WriteToEventLog("uEye camera stream started")
            bLive = True
            RaiseEvent UeyeStartStop(True)

        End If

        'cam.AutoFeatures.Software.Gain.SetEnable(cbAutoGain.Checked)
        'cam.Timing.Exposure.Set(CDbl(tbExposureValue.Value / 1000))
        cam.AutoFeatures.Software.PeakWhite.SetEnable(cbAutoExpose.Checked)

    End Sub

    Private Sub StartWebCamLiveFeed()
        Try

            bLive = WebCam.OpenPreviewWindow(LiveFeedPB, 0, 20)
            Logs.WriteToEventLog("The webcam feed has started successfully.")
        Catch ex As Exception
            'something went wrong. no web cam avaliable??
            Logs.WriteToErrorLog(ex.Message, ex.StackTrace, "Webcam starting exception.")
            Logs.WriteToEventLog("Exception occured when starting the webcam. See error log for details.")
            EndSoftware()
        End Try
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click, StopToolStripMenuItem.Click
        If uCamActive Then
            StopUeyeLiveFeed()
        Else
            StopWebCamLiveFeed()
        End If
        Logs.WriteToEventLog("Live stream has been stopped.")
    End Sub

    Private Sub StopUeyeLiveFeed()
        'Stop Live Video
        If (cam.Acquisition.Stop() = uEye.Defines.Status.Success) Then

            bLive = False
            RaiseEvent UeyeStartStop(False)

        End If
    End Sub

    Private Sub StopWebCamLiveFeed()
        If bLive = True Then
            WebCam.ClosePreviewWindow(0)
        End If
    End Sub

    Private Sub Form1_UeyeStartStop(ActiveFeed As Boolean) Handles Me.UeyeStartStop
        'use the input parameter to deremine if the feed has been started or stoped
        If ActiveFeed Then
            'the feed has been started!
            tmrUpdateDisplay.Interval = 50
            tmrUpdateDisplay.Start()
            ''disable this next one:
            'bLive = False
            '''' .
            btnStart.Enabled = False
            btnStop.Enabled = True
            cbAutoGain.Enabled = True
            cbAutoExpose.Enabled = True
            StartToolStripMenuItem.Enabled = False
            StopToolStripMenuItem.Enabled = True
            tssl_runningState.Text = "Running"
        Else
            'the feed has been stopped
            tmrUpdateDisplay.Stop()
            btnStop.Enabled = False
            btnStart.Enabled = True
            cbAutoGain.Enabled = False
            cbAutoExpose.Enabled = False
            StartToolStripMenuItem.Enabled = True
            StopToolStripMenuItem.Enabled = False
            tssl_runningState.Text = "Not Running"
            lblExposureTime.Text = "-"
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub WebCam_PreviewWindowStatus(Message As String) Handles WebCam.PreviewWindowStatus
        Select Case Message
            Case "Preview Window Active"
                tmrUpdateDisplay.Interval = 50
                tmrUpdateDisplay.Start()
                StartToolStripMenuItem.Enabled = False
                StopToolStripMenuItem.Enabled = True
                btnStart.Enabled = False
                btnStop.Enabled = True
                bLive = True
                tssl_runningState.Text = "Running"
            Case "Preview Window Closed"
                tmrUpdateDisplay.Stop()
                StartToolStripMenuItem.Enabled = True
                StopToolStripMenuItem.Enabled = False
                btnStart.Enabled = True
                btnStop.Enabled = False
                bLive = False
                tssl_runningState.Text = "Not Running"
        End Select
    End Sub

    Private Sub tmrUpdateDisplay_Tick(sender As Object, e As EventArgs) Handles tmrUpdateDisplay.Tick
        tmrUpdateDisplay.Stop() 'stop the timer while this happens
        Dim sw As New Stopwatch 'this is for timing the operation (image manipulation takes a lot of time, i want to know how long!)
        sw.Start() 'star the stopwatch
        Dim IntesityWindowCoveragePercent As Double = My.Settings.IntensityBarPercent 'takes up xxx% of the window : values stored in settings

        'load up the image from the camera
        Dim _tempImage As Bitmap = GetImage()

        'Get the scaled version of the image to fit the display box (aspect ratio remains fixed!)
        CurrentImage = CType(ScaleImage(_tempImage, CInt(picCapture.Height * (1 - IntesityWindowCoveragePercent)), CInt(picCapture.Width * (1 - IntesityWindowCoveragePercent))), Bitmap)
        'Create a blank cavas for drawing the information on to, this must be the same size as the picture box.
        Dim OverlayBitmap As New Bitmap(picCapture.Width, picCapture.Height)
        Dim myGraphics As Graphics = Graphics.FromImage(OverlayBitmap)

        'Calculate the top left corner location of the video image. The position of everything else is based on this location
        ImageTopLeftX = CInt((picCapture.Width * IntesityWindowCoveragePercent))
        ImageTopLeftY = CInt((((1 - IntesityWindowCoveragePercent) * picCapture.Height) - CurrentImage.Height))

        'Draw the background image onto the canvas first. this is the video feedimage:
        myGraphics.DrawImageUnscaled(CurrentImage, ImageTopLeftX, ImageTopLeftY)

        'generate the vertical scales:
        'create a few vertical scale lines in yellow 
        Dim mypen As New Pen(ColorScheme.AxisColor)
        mypen.DashStyle = Drawing2D.DashStyle.Solid 'solid lines used for all but the middle line
        Dim pointAB(1) As Point 'this is the point array used for storing the lines start (0) and end(1) points
        pointAB(0) = New Point(CInt(picCapture.Width * IntesityWindowCoveragePercent), ImageTopLeftY)
        pointAB(1) = New Point(CInt(picCapture.Width * IntesityWindowCoveragePercent), ImageTopLeftY + CurrentImage.Height)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1))
        pointAB(0) = New Point(CInt(picCapture.Width * (IntesityWindowCoveragePercent / 2)), ImageTopLeftY)
        pointAB(1) = New Point(CInt(picCapture.Width * (IntesityWindowCoveragePercent / 2)), ImageTopLeftY + CurrentImage.Height)
        mypen.DashStyle = Drawing2D.DashStyle.DashDot
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1))
        mypen.DashStyle = Drawing2D.DashStyle.Solid
        pointAB(0) = New Point(0, ImageTopLeftY)
        pointAB(1) = New Point(0, ImageTopLeftY + CurrentImage.Height)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1))
        pointAB(0) = New Point(0, ImageTopLeftY)
        pointAB(1) = New Point(CInt(picCapture.Width * IntesityWindowCoveragePercent), ImageTopLeftY)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1))
        pointAB(0) = New Point(0, ImageTopLeftY + CurrentImage.Height)
        pointAB(1) = New Point(CInt(picCapture.Width * IntesityWindowCoveragePercent), ImageTopLeftY + CurrentImage.Height)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1))


        'create a few horizontal scale lines in yellow 
        mypen.DashStyle = Drawing2D.DashStyle.Solid 'solid lines used for all but the middle line
        pointAB(0) = New Point(ImageTopLeftX, ImageTopLeftY + CurrentImage.Height)
        pointAB(1) = New Point(ImageTopLeftX + CurrentImage.Width, ImageTopLeftY + CurrentImage.Height)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1)) 'draws the top line
        pointAB(0) = New Point(ImageTopLeftX, CInt((ImageTopLeftY + CurrentImage.Height) + (picCapture.Height * (IntesityWindowCoveragePercent / 2))))
        pointAB(1) = New Point(ImageTopLeftX + CurrentImage.Width, CInt((ImageTopLeftY + CurrentImage.Height) + (picCapture.Height * (IntesityWindowCoveragePercent / 2))))
        mypen.DashStyle = Drawing2D.DashStyle.DashDot
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1)) 'draws the middle line
        mypen.DashStyle = Drawing2D.DashStyle.Solid
        pointAB(0) = New Point(ImageTopLeftX, CInt((ImageTopLeftY + CurrentImage.Height) + (picCapture.Height * IntesityWindowCoveragePercent)))
        pointAB(1) = New Point(ImageTopLeftX + CurrentImage.Width, CInt((ImageTopLeftY + CurrentImage.Height) + (picCapture.Height * IntesityWindowCoveragePercent)))
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1)) 'draws the bottom line.
        pointAB(0) = New Point(ImageTopLeftX, ImageTopLeftY + CurrentImage.Height)
        pointAB(1) = New Point(ImageTopLeftX, CInt((ImageTopLeftY + CurrentImage.Height) + (picCapture.Height * IntesityWindowCoveragePercent)))
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1))
        pointAB(0) = New Point(ImageTopLeftX + CurrentImage.Width, ImageTopLeftY + CurrentImage.Height)
        pointAB(1) = New Point(ImageTopLeftX + CurrentImage.Width, CInt((ImageTopLeftY + CurrentImage.Height) + (picCapture.Height * IntesityWindowCoveragePercent)))
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1))

        'Check that the crosshair locations are valid. If not, return them to default positions
        If (Apoint.X < 0) Or (Apoint.X > ImageTopLeftX + CurrentImage.Width) Then
            Apoint.X = 0
        End If
        If (Apoint.Y < ImageTopLeftY) Or (Apoint.Y > (ImageTopLeftY + CurrentImage.Height)) Then
            Apoint.Y = 0
        End If

        If (Bpoint.X < 0) Or (Bpoint.X > ImageTopLeftX + CurrentImage.Width) Then
            Bpoint.X = 0
        End If
        If (Bpoint.Y < ImageTopLeftY) Or (Bpoint.Y > (ImageTopLeftY + CurrentImage.Height)) Then
            Bpoint.Y = 0
        End If

        'Putting the crosshair for point A on to the image now
        mypen.Color = ColorScheme.Acolor 'using a different color. Mayby I will the user set this in some options menu somewhere! :)
        mypen.DashStyle = Drawing2D.DashStyle.Solid 'solid lines used for the main crosshair lines
        pointAB(0) = New Point(ImageTopLeftX, ImageTopLeftY + Apoint.Y)
        pointAB(1) = New Point(ImageTopLeftX + CurrentImage.Width, ImageTopLeftY + Apoint.Y)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1)) 'horizontal crosshair
        pointAB(0) = New Point(ImageTopLeftX + Apoint.X, ImageTopLeftY)
        pointAB(1) = New Point(ImageTopLeftX + Apoint.X, ImageTopLeftY + CurrentImage.Height)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1)) 'vertical crosshair

        'Putting the crosshair for point B on to the image now
        mypen.Color = ColorScheme.Bcolor 'using a different color. Mayby I will the user set this in some options menu somewhere! :)
        mypen.DashStyle = Drawing2D.DashStyle.Solid 'solid lines used for the main crosshair lines
        pointAB(0) = New Point(ImageTopLeftX, ImageTopLeftY + Bpoint.Y)
        pointAB(1) = New Point(ImageTopLeftX + CurrentImage.Width, ImageTopLeftY + Bpoint.Y)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1)) 'horizontal crosshair
        pointAB(0) = New Point(ImageTopLeftX + Bpoint.X, ImageTopLeftY)
        pointAB(1) = New Point(ImageTopLeftX + Bpoint.X, ImageTopLeftY + CurrentImage.Height)
        myGraphics.DrawLine(mypen, pointAB(0), pointAB(1)) 'vertical crosshair


        'Now, calculate the intensity vector for the vertical axis of Apoint
        mypen.Color = ColorScheme.Acolor
        mypen.DashStyle = Drawing2D.DashStyle.Solid
        Dim pointArrayYA(0 To _tempImage.Size.Height - 1) As Point
        Dim MidX As Integer = CInt((Apoint.X * (_tempImage.Width / CurrentImage.Width))) 'scale
        'loop through each location to measure the brightness
        For i As Integer = 0 To _tempImage.Size.Height - 1
            Dim thiscolor As Color = _tempImage.GetPixel(MidX, i)
            pointArrayYA(i) = New Point(CInt(thiscolor.GetBrightness() * (CurrentImage.Width * IntesityWindowCoveragePercent)), CInt(ImageTopLeftY + (i / (_tempImage.Size.Height - 1)) * CurrentImage.Height))
        Next
        'drawing the vector on to the canvas in red
        myGraphics.DrawCurve(mypen, pointArrayYA)
        'Now, calculate the intensity vector for the horizontal axis
        Dim pointArrayXA(0 To _tempImage.Size.Width - 1) As Point
        Dim MidY As Integer = CInt(ImageTopLeftY + (Apoint.Y * (_tempImage.Height / CurrentImage.Height))) 'scale
        'loop through each location to measure the brightness
        For i As Integer = 0 To _tempImage.Size.Width - 1
            Dim thiscolor As Color = _tempImage.GetPixel(i, MidY)
            pointArrayXA(i) = New Point(CInt(ImageTopLeftX + (i / (_tempImage.Size.Width - 1)) * CurrentImage.Width), CInt(picCapture.Height - (thiscolor.GetBrightness() * (CurrentImage.Height * IntesityWindowCoveragePercent))))
        Next
        'drawing the vector on to the canvas in red
        myGraphics.DrawCurve(mypen, pointArrayXA)
        Aval.AddValue(CDbl(_tempImage.GetPixel(MidX, MidY).GetBrightness))

        'Now, calculate the intensity vector for the vertical axis of Apoint
        mypen.Color = ColorScheme.Bcolor
        mypen.DashStyle = Drawing2D.DashStyle.Solid
        Dim pointArrayYB(0 To _tempImage.Size.Height - 1) As Point
        MidX = CInt((Bpoint.X * (_tempImage.Width / CurrentImage.Width))) 'scale
        'loop through each location to measure the brightness
        For i As Integer = 0 To _tempImage.Size.Height - 1
            Dim thiscolor As Color = _tempImage.GetPixel(MidX, i)
            pointArrayYB(i) = New Point(CInt(thiscolor.GetBrightness() * (CurrentImage.Width * IntesityWindowCoveragePercent)), CInt(ImageTopLeftY + (i / (_tempImage.Size.Height - 1)) * CurrentImage.Height))
        Next
        'drawing the vector on to the canvas in red
        myGraphics.DrawCurve(mypen, pointArrayYB)
        'Now, calculate the intensity vector for the horizontal axis
        Dim pointArrayXB(0 To _tempImage.Size.Width - 1) As Point
        MidY = CInt(ImageTopLeftY + (Bpoint.Y * (_tempImage.Height / CurrentImage.Height))) 'scale
        'loop through each location to measure the brightness
        For i As Integer = 0 To _tempImage.Size.Width - 1
            Dim thiscolor As Color = _tempImage.GetPixel(i, MidY)
            pointArrayXB(i) = New Point(CInt(ImageTopLeftX + (i / (_tempImage.Size.Width - 1)) * CurrentImage.Width), CInt(picCapture.Height - (thiscolor.GetBrightness() * (CurrentImage.Height * IntesityWindowCoveragePercent))))
        Next
        'drawing the vector on to the canvas in red
        myGraphics.DrawCurve(mypen, pointArrayXB)
        Bval.AddValue(CDbl(_tempImage.GetPixel(MidX, MidY).GetBrightness))

        'putting the image on to the picCapture box
        picCapture.BackColor = Color.Black
        picCapture.Image = OverlayBitmap

        tssl_Aval.Text = "Intensity at A: " & Math.Round(Aval.FilteredValue * 100, 2).ToString
        tssl_Bval.Text = "Intensity at B: " & Math.Round(Bval.FilteredValue * 100, 2).ToString
        'Want to automatically invert the ratio if its > 100%
        If (Aval.FilteredValue > Bval.FilteredValue) Then
            DisplayRatioValues(Math.Round(((Bval.FilteredValue) / Aval.FilteredValue), 2))
        Else
            DisplayRatioValues(Math.Round(((Aval.FilteredValue) / Bval.FilteredValue), 2))
        End If


        sw.Stop()
        FPS.AddValue(1000 / sw.Elapsed.Milliseconds)
        tssl_FPS.Text = "Frames Per Second: " & Math.Round(FPS.FilteredValue, 2).ToString

        tmrUpdateDisplay.Interval = 10
        tmrUpdateDisplay.Start()

    End Sub

    Private Sub DisplayRatioValues(value As Double)


        lblRatio.Text = "Ratio:" & vbCrLf & Math.Round(value * 100, 1).ToString
        If ColorScheme.RatioColorsOnOff Then
            'using a custom scheme with a specific input
            If (value > ColorScheme.Close_max) Or (value < ColorScheme.Close_min) Then
                lblRatio.BackColor = ColorScheme.RatioBadcolor
            ElseIf (value > ColorScheme.OKrange_max) Or (value < ColorScheme.OKrange_min) Then
                lblRatio.BackColor = ColorScheme.RatioClosecolor
            Else
                lblRatio.BackColor = ColorScheme.RatioOKcolor
            End If
        Else
            lblRatio.BackColor = DefaultBackColor()
        End If
    End Sub

    Private Function GetImage() As Bitmap
        Dim CurrentImageUnscaled As Bitmap = Nothing 'a place to store the incoming bitmap for this frame.

        ' Copy image to the buffer bitmap
        If uCamActive Then
            'Using a uEye camera:
            'determine the size of the incoming image
            Dim Height, Width As Integer
            cam.Memory.GetHeight(MemId, Height)
            cam.Memory.GetWidth(MemId, Width)
            'make a bitmap that is the correct size
            CurrentImageUnscaled = New Bitmap(Width, Height)
            'get the bitmap from the camera:
            cam.Memory.ToBitmap(MemId, CurrentImageUnscaled)
        Else
            'initate a copy of the current frame to the clipboard:
            WebCam.capEditCopy(CLng(WebCam.GethHwnd))
            ' Get image from clipboard and convert it to a bitmap
            Dim data As IDataObject = Clipboard.GetDataObject()
            'If there is a valid picture in the clipboard, then lets process it! (remember, the clipboard must be cleared on exit/start of the software).
            If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                'Grab the raw image from the clipboard
                CurrentImageUnscaled = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap)
            End If
        End If

        If Not IsNothing(CurrentImageUnscaled) Then
            Return CurrentImageUnscaled
        Else
            Return New Bitmap(10, 10)
        End If

    End Function

    Public Function ScaleImage(ByRef OldImage As Bitmap, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer) As System.Drawing.Image
        If IsNothing(OldImage) Then
            Return New Bitmap(100, 100)
        End If

        'determine the zoom values
        Dim scale As Double = ImageZoom / 100
        Dim newWidth As Integer = CInt(OldImage.Width * scale)
        Dim newHeight As Integer = CInt(OldImage.Height * scale)
        Dim topX As Integer = CInt((OldImage.Width - newWidth) / 2)
        Dim topY As Integer = CInt((OldImage.Height - newHeight) / 2)
        OldImage = CropBitmap(OldImage, topX, topY, newWidth, newHeight)

        newHeight = TargetHeight
        newWidth = CInt(newHeight / OldImage.Height * OldImage.Width)

        If NewWidth > TargetWidth Then
            NewWidth = TargetWidth
            NewHeight = CInt(NewWidth / OldImage.Width * OldImage.Height)
        End If

        Return New Bitmap(OldImage, NewWidth, NewHeight)

    End Function

    Private Function CropBitmap(ByRef bmp As Bitmap, ByVal cropX As Integer, ByVal cropY As Integer, ByVal cropWidth As Integer, ByVal cropHeight As Integer) As Bitmap
        Dim rect As New Rectangle(cropX, cropY, cropWidth, cropHeight)
        Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
        Return cropped
    End Function


    Private Sub picCapture_MouseUp(sender As Object, e As MouseEventArgs) Handles picCapture.MouseUp
        'The user has clicked on the display. Measure where the cursor is relative to the image, if its on the image then lets save it!
        If IsNothing(picCapture.Image) Or bLive = False Then
            Exit Sub
        End If
        Dim Tpoint As New Point(0, 0)
        Dim validpoint As Boolean = True

        'Working with X axis first. Check if it is within the image boundaries
        If (e.X) > ImageTopLeftX And e.X < (ImageTopLeftX + CurrentImage.Width) Then
            Tpoint.X = (e.X - ImageTopLeftX)
        Else
            validpoint = False
        End If
        'Working with Y axis . Check if it is within the image boundaries
        If (e.Y) > ImageTopLeftY And e.Y < (ImageTopLeftY + CurrentImage.Height) Then
            Tpoint.Y = (e.Y - ImageTopLeftY)
        Else
            validpoint = False
        End If
        'if it was a valid locations, save it
        If validpoint Then
            'left click sets A
            'right click sets B
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Apoint = Tpoint
                Aval.Reset()
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                Bpoint = Tpoint
                Bval.Reset()
            End If

        End If
    End Sub

    Private Sub picCapture_MouseWheel(sender As Object, e As MouseEventArgs) Handles picCapture.MouseWheel
        If IsNothing(picCapture.Image) Or bLive = False Then
            Exit Sub
        End If
        Dim Tpercent As Integer = ImageZoom + CInt(e.Delta / -120)
        If Tpercent < 20 Then
            ImageZoom = 20
        ElseIf Tpercent > 100 Then
            ImageZoom = 100
        Else
            ImageZoom = Tpercent
        End If

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim _window As New SettingsDialog
        _window.ShowDialog(ColorScheme)
        ColorScheme.SaveColors()
    End Sub

    Private Sub cam_EventFrame(sender As Object, e As EventArgs) Handles cam.EventFrame
        'Camera frames are passed to the program using this event.
        cam.Display.Render(MemId, DisplayHandle, uEye.Defines.DisplayRenderMode.FitToWindow)
        'At the same time, get the value for the exposure time to send it to the label
        Dim TimeMS As Double = 0
        cam.Timing.Exposure.Get(TimeMS)
        UpdateExposureTime(TimeMS)
    End Sub

    Private Sub cbAutoGain_CheckedChanged(sender As Object, e As EventArgs) Handles cbAutoGain.CheckedChanged
        'CheckBox Auto Gain Balance
        'cam.AutoFeatures.Software.Gain.SetEnable(cbAutoGain.Checked)

    End Sub

    Private Sub cbAutoExpose_CheckedChanged(sender As Object, e As EventArgs) Handles cbAutoExpose.CheckedChanged
        cam.AutoFeatures.Software.PeakWhite.SetEnable(cbAutoExpose.Checked)
        If cbAutoExpose.Checked Then
            tbExposureValue.Enabled = False
        Else
            tbExposureValue.Enabled = True
        End If
    End Sub

    Private Sub UpdateExposureTime(ByVal ValueMS As Double)
        If lblExposureTime.InvokeRequired Then
            Dim x As New SetExposureTimeValues(AddressOf UpdateExposureTime)
            Me.Invoke(x, New Object() {ValueMS})
        Else
            lblExposureTime.Text = Math.Round(ValueMS, 2).ToString & " ms"
            tbExposureValue.Value = CInt(ValueMS * 1000)
        End If
    End Sub

    Private Sub tbExposureValue_Scroll(sender As Object, e As EventArgs) Handles tbExposureValue.Scroll
        cam.Timing.Exposure.Set(CDbl(tbExposureValue.Value / 1000))
    End Sub
End Class



Public Class ColorsForDisplay
    Public Acolor As Color = Color.Red
    Public Bcolor As Color = Color.Green
    Public AxisColor As Color = Color.Yellow
    Public RatioColorsOnOff As Boolean = False
    Public RatioOKcolor As Color = Color.Green
    Public RatioBadcolor As Color = Color.Red
    Public RatioClosecolor As Color = Color.Orange
    Public FilterWidth As Integer = 10
    Public AxisWidth As Double = 10
    '----------------------------- ratio stuff ----------------
    Public OKval As Double = 1
    Public OKrange_min As Double = 1
    Public OKrange_max As Double = 1
    Public Close_min As Double = 1
    Public Close_max As Double = 1

    Public Sub LoadColors()
        Acolor = My.Settings.Acolor
        Bcolor = My.Settings.Bcolor
        AxisColor = My.Settings.AxisColor
        RatioOKcolor = My.Settings.RatioOKcolor
        RatioBadcolor = My.Settings.RatioBadColor
        RatioClosecolor = My.Settings.RatioCloseColor
        FilterWidth = My.Settings.DataFilterWindow
        AxisWidth = My.Settings.IntensityBarPercent * 100
        RatioColorsOnOff = My.Settings.RatioColorActive
        OKval = My.Settings.OKval
        OKrange_max = My.Settings.OKval_max
        OKrange_min = My.Settings.OKval_min
        Close_max = My.Settings.Close_max
        Close_min = My.Settings.Close_min
    End Sub

    Public Sub SaveColors()
        My.Settings.Acolor = Acolor
        My.Settings.Bcolor = Bcolor
        My.Settings.AxisColor = AxisColor
        My.Settings.RatioOKcolor = RatioOKcolor
        My.Settings.RatioBadColor = RatioBadcolor
        My.Settings.RatioCloseColor = RatioClosecolor
        My.Settings.DataFilterWindow = FilterWidth
        My.Settings.IntensityBarPercent = AxisWidth / 100
        My.Settings.RatioColorActive = RatioColorsOnOff
        My.Settings.OKval = OKval
        My.Settings.OKval_max = OKrange_max
        My.Settings.OKval_min = OKrange_min
        My.Settings.Close_max = Close_max
        My.Settings.Close_min = Close_min
    End Sub
End Class

Public Class Values
    Private _collection As New ArrayList
    Private _currentIndex As Integer = 0
    Private _maxIndex As Integer = 10

    Public Sub Reset()
        While _collection.Count <> 0
            _collection.RemoveAt(0)
        End While
        _currentIndex = 0
    End Sub

    Public Property FilterSmoothing As Integer
        Get
            Return _maxIndex
        End Get
        Set(value As Integer)
            If value > 0 Then
                _maxIndex = value
                While _collection.Count > value
                    _collection.RemoveAt(0)
                    _currentIndex -= 1
                End While
            End If
        End Set
    End Property

    Public ReadOnly Property FilteredValue As Double
        Get
            Dim Tvalue As Double = 0
            If _collection.Count > 0 Then
                Tvalue = CInt(_collection.Item(0))
            End If
            For Each e As Double In _collection
                Tvalue = (Tvalue + e) / 2
            Next
            Return Tvalue
        End Get
    End Property

    Public Sub AddValue(ByVal item As Double)
        If item > 10000 Then
            Exit Sub
        End If
        _collection.Add(item)
        _currentIndex += 1
        If _currentIndex > _maxIndex Then
            _collection.RemoveAt(0)
        End If
    End Sub
End Class