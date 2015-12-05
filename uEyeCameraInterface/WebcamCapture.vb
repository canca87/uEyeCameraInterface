Imports System.Runtime.InteropServices

Public Class WebcamCapture

#Region "Events"
    Event ErrorMsg(ByVal ErrorMessage As String)
    Event PreviewOpenClosed(ByVal Message As String)
    Event PreviewWindowStatus(ByVal Message As String)
#End Region
    Shared hHwnd As Integer
    Dim DeviceListReturn As Boolean

#Region "Constance"

    Public Const WM_USER = &H400

    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    '// Defines start of the message range
    Const WM_CAP_START = WM_USER

    Const WM_CAP_GET_CAPSTREAMPTR = WM_CAP_START + 1

    Const WM_CAP_SET_CALLBACK_ERROR = WM_CAP_START + 2
    Const WM_CAP_SET_CALLBACK_STATUS = WM_CAP_START + 3
    Const WM_CAP_SET_CALLBACK_YIELD = WM_CAP_START + 4
    Const WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5
    Const WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6
    Const WM_CAP_SET_CALLBACK_WAVESTREAM = WM_CAP_START + 7
    Const WM_CAP_GET_USER_DATA = WM_CAP_START + 8
    Const WM_CAP_SET_USER_DATA = WM_CAP_START + 9

    Const WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10
    Const WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11
    Const WM_CAP_DRIVER_GET_NAME = WM_CAP_START + 12
    Const WM_CAP_DRIVER_GET_VERSION = WM_CAP_START + 13
    Const WM_CAP_DRIVER_GET_CAPS = WM_CAP_START + 14

    Const WM_CAP_FILE_SET_CAPTURE_FILE = WM_CAP_START + 20
    Const WM_CAP_FILE_GET_CAPTURE_FILE = WM_CAP_START + 21
    Const WM_CAP_FILE_ALLOCATE = WM_CAP_START + 22
    Const WM_CAP_FILE_SAVEAS = WM_CAP_START + 23
    Const WM_CAP_FILE_SET_INFOCHUNK = WM_CAP_START + 24
    Const WM_CAP_FILE_SAVEDIB = WM_CAP_START + 25

    Public Const WM_CAP_EDIT_COPY = WM_CAP_START + 30

    Const WM_CAP_SET_AUDIOFORMAT = WM_CAP_START + 35
    Const WM_CAP_GET_AUDIOFORMAT = WM_CAP_START + 36

    Const WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41
    Const WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42
    Const WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43
    Const WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44
    Const WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45
    Const WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46

    Const WM_CAP_SET_PREVIEW = WM_CAP_START + 50
    Const WM_CAP_SET_OVERLAY = WM_CAP_START + 51
    Const WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52
    Const WM_CAP_SET_SCALE = WM_CAP_START + 53
    Const WM_CAP_GET_STATUS = WM_CAP_START + 54
    Const WM_CAP_SET_SCROLL = WM_CAP_START + 55

    Const WM_CAP_GRAB_FRAME = WM_CAP_START + 60
    Const WM_CAP_GRAB_FRAME_NOSTOP = WM_CAP_START + 61

    Const WM_CAP_SEQUENCE = WM_CAP_START + 62
    Const WM_CAP_SEQUENCE_NOFILE = WM_CAP_START + 63
    Const WM_CAP_SET_SEQUENCE_SETUP = WM_CAP_START + 64
    Const WM_CAP_GET_SEQUENCE_SETUP = WM_CAP_START + 65
    Const WM_CAP_SET_MCI_DEVICE = WM_CAP_START + 66
    Const WM_CAP_GET_MCI_DEVICE = WM_CAP_START + 67
    Const WM_CAP_STOP = WM_CAP_START + 68
    Const WM_CAP_ABORT = WM_CAP_START + 69

    Const WM_CAP_SINGLE_FRAME_OPEN = WM_CAP_START + 70
    Const WM_CAP_SINGLE_FRAME_CLOSE = WM_CAP_START + 71
    Const WM_CAP_SINGLE_FRAME = WM_CAP_START + 72

    Const WM_CAP_PAL_OPEN = WM_CAP_START + 80
    Const WM_CAP_PAL_SAVE = WM_CAP_START + 81
    Const WM_CAP_PAL_PASTE = WM_CAP_START + 82
    Const WM_CAP_PAL_AUTOCREATE = WM_CAP_START + 83
    Const WM_CAP_PAL_MANUALCREATE = WM_CAP_START + 84

    '// Following added post VFW 1.1
    Const WM_CAP_SET_CALLBACK_CAPCONTROL = WM_CAP_START + 85

    '// Defines end of the message range
    Const WM_CAP_END = WM_CAP_SET_CALLBACK_CAPCONTROL
    Public YOURCONSTANTMESSAGE As Integer

    '// ------------------------------------------------------------------
    '// String IDs from status and error callbacks
    '// ------------------------------------------------------------------

    Public Const IDS_CAP_BEGIN = 300              '/* "Capture Start" */
    Public Const IDS_CAP_END = 301                '/* "Capture End" */

    Public Const IDS_CAP_INFO = 401               '/* "%s" */
    Public Const IDS_CAP_OUTOFMEM = 402           '/* "Out of memory" */
    Public Const IDS_CAP_FILEEXISTS = 403         '/* "File '%s' exists -- overwrite it?" */
    Public Const IDS_CAP_ERRORPALOPEN = 404       '/* "Error opening palette '%s'" */
    Public Const IDS_CAP_ERRORPALSAVE = 405       '/* "Error saving palette '%s'" */
    Public Const IDS_CAP_ERRORDIBSAVE = 406       '/* "Error saving frame '%s'" */
    Public Const IDS_CAP_DEFAVIEXT = 407          '/* "avi" */
    Public Const IDS_CAP_DEFPALEXT = 408          '/* "pal" */
    Public Const IDS_CAP_CANTOPEN = 409           '/* "Cannot open '%s'" */
    Public Const IDS_CAP_SEQ_MSGSTART = 410       '/* "Select OK to start capture\nof video sequence\nto %s." */
    Public Const IDS_CAP_SEQ_MSGSTOP = 411        '/* "Hit ESCAPE or click to end capture" */

    Public Const IDS_CAP_VIDEDITERR = 412         '/* "An error occurred while trying to run VidEdit." */
    Public Const IDS_CAP_READONLYFILE = 413       '/* "The file '%s' is a read-only file." */
    Public Const IDS_CAP_WRITEERROR = 414         '/* "Unable to write to file '%s'.\nDisk may be full." */
    Public Const IDS_CAP_NODISKSPACE = 415        '/* "There is no space to create a capture file on the specified device." */
    Public Const IDS_CAP_SETFILESIZE = 416        '/* "Set File Size" */
    Public Const IDS_CAP_SAVEASPERCENT = 417      '/* "SaveAs: %2ld%%  Hit Escape to abort." */

    Public Const IDS_CAP_DRIVER_ERROR = 418       '/* Driver specific error message */

    Public Const IDS_CAP_WAVE_OPEN_ERROR = 419    '/* "Error: Cannot open the wave input device.\nCheck sample size, frequency, and channels." */
    Public Const IDS_CAP_WAVE_ALLOC_ERROR = 420   '/* "Error: Out of memory for wave buffers." */
    Public Const IDS_CAP_WAVE_PREPARE_ERROR = 421 '/* "Error: Cannot prepare wave buffers." */
    Public Const IDS_CAP_WAVE_ADD_ERROR = 422     '/* "Error: Cannot add wave buffers." */
    Public Const IDS_CAP_WAVE_SIZE_ERROR = 423    '/* "Error: Bad wave size." */

    Public Const IDS_CAP_VIDEO_OPEN_ERROR = 424   '/* "Error: Cannot open the video input device." */
    Public Const IDS_CAP_VIDEO_ALLOC_ERROR = 425  '/* "Error: Out of memory for video buffers." */
    Public Const IDS_CAP_VIDEO_PREPARE_ERROR = 426 '/* "Error: Cannot prepare video buffers." */
    Public Const IDS_CAP_VIDEO_ADD_ERROR = 427    '/* "Error: Cannot add video buffers." */
    Public Const IDS_CAP_VIDEO_SIZE_ERROR = 428   '/* "Error: Bad video size." */

    Public Const IDS_CAP_FILE_OPEN_ERROR = 429    '/* "Error: Cannot open capture file." */
    Public Const IDS_CAP_FILE_WRITE_ERROR = 430   '/* "Error: Cannot write to capture file.  Disk may be full." */
    Public Const IDS_CAP_RECORDING_ERROR = 431    '/* "Error: Cannot write to capture file.  Data rate too high or disk full." */
    Public Const IDS_CAP_RECORDING_ERROR2 = 432   '/* "Error while recording" */
    Public Const IDS_CAP_AVI_INIT_ERROR = 433     '/* "Error: Unable to initialize for capture." */
    Public Const IDS_CAP_NO_FRAME_CAP_ERROR = 434 '/* "Warning: No frames captured.\nConfirm that vertical sync interrupts\nare configured and enabled." */
    Public Const IDS_CAP_NO_PALETTE_WARN = 435    '/* "Warning: Using default palette." */
    Public Const IDS_CAP_MCI_CONTROL_ERROR = 436  '/* "Error: Unable to access MCI device." */
    Public Const IDS_CAP_MCI_CANT_STEP_ERROR = 437 '/* "Error: Unable to step MCI device." */
    Public Const IDS_CAP_NO_AUDIO_CAP_ERROR = 438 '/* "Error: No audio data captured.\nCheck audio card settings." */
    Public Const IDS_CAP_AVI_DRAWDIB_ERROR = 439  '/* "Error: Unable to draw this data format." */
    Public Const IDS_CAP_COMPRESSOR_ERROR = 440   '/* "Error: Unable to initialize compressor." */
    Public Const IDS_CAP_AUDIO_DROP_ERROR = 441   '/* "Error: Audio data was lost during capture, reduce capture rate." */

    '/* status string IDs */
    Public Const IDS_CAP_STAT_LIVE_MODE = 500      '/* "Live window" */
    Public Const IDS_CAP_STAT_OVERLAY_MODE = 501   '/* "Overlay window" */
    Public Const IDS_CAP_STAT_CAP_INIT = 502       '/* "Setting up for capture - Please wait" */
    Public Const IDS_CAP_STAT_CAP_FINI = 503       '/* "Finished capture, now writing frame %ld" */
    Public Const IDS_CAP_STAT_PALETTE_BUILD = 504  '/* "Building palette map" */
    Public Const IDS_CAP_STAT_OPTPAL_BUILD = 505   '/* "Computing optimal palette" */
    Public Const IDS_CAP_STAT_I_FRAMES = 506       '/* "%d frames" */
    Public Const IDS_CAP_STAT_L_FRAMES = 507       '/* "%ld frames" */
    Public Const IDS_CAP_STAT_CAP_L_FRAMES = 508   '/* "Captured %ld frames" */
    Public Const IDS_CAP_STAT_CAP_AUDIO = 509      '/* "Capturing audio" */
    Public Const IDS_CAP_STAT_VIDEOCURRENT = 510   '/* "Captured %ld frames (%ld dropped) %d.%03d sec." */
    Public Const IDS_CAP_STAT_VIDEOAUDIO = 511     '/* "Captured %d.%03d sec.  %ld frames (%ld dropped) (%d.%03d fps).  %ld audio bytes (%d,%03d sps)" */
    Public Const IDS_CAP_STAT_VIDEOONLY = 512      '/* "Captured %d.%03d sec.  %ld frames (%ld dropped) (%d.%03d fps)" */
#End Region

#Region "Structures"
    '// ------------------------------------------------------------------
    '//  Structures
    '// ------------------------------------------------------------------
    Structure CAPDRIVERCAPS
        Dim wDeviceIndex As Long '               // Driver index in system.ini
        Dim fHasOverlay As Long '                // Can device overlay?
        Dim fHasDlgVideoSource As Long '         // Has Video source dlg?
        Dim fHasDlgVideoFormat As Long '         // Has Format dlg?
        Dim fHasDlgVideoDisplay As Long '        // Has External out dlg?
        Dim fCaptureInitialized As Long '        // Driver ready to capture?
        Dim fDriverSuppliesPalettes As Long '    // Can driver make palettes?
        Dim hVideoIn As Long  '                   // Driver In channel
        Dim hVideoOut As Long  '                  // Driver Out channel
        Dim hVideoExtIn As Long  '                // Driver Ext In channel
        Dim hVideoExtOut As Long '               // Driver Ext Out channel
    End Structure

    Structure CAPSTATUS
        Dim uiImageWidth As Long                    '// Width of the image
        Dim uiImageHeight As Long                   '// Height of the image
        Dim fLiveWindow As Long                     '// Now Previewing video?
        Dim fOverlayWindow As Long                  '// Now Overlaying video?
        Dim fScale As Long                          '// Scale image to client?
        Dim ptScroll As POINTAPI                    '// Scroll position
        Dim fUsingDefaultPalette As Long            '// Using default driver palette?
        Dim fAudioHardware As Long                  '// Audio hardware present?
        Dim fCapFileExists As Long                  '// Does capture file exist?
        Dim dwCurrentVideoFrame As Long              '// # of video frames cap'td
        Dim dwCurrentVideoFramesDropped As Long      '// # of video frames dropped
        Dim dwCurrentWaveSamples As Long            '// # of wave samples cap'td
        Dim dwCurrentTimeElapsedMS As Long          '// Elapsed capture duration
        Dim hPalCurrent As Long                     '// Current palette in use
        Dim fCapturingNow As Long                   '// Capture in progress?
        Dim dwReturn As Long                        '// Error value after any operation
        Dim wNumVideoAllocated As Long              '// Actual number of video buffers
        Dim wNumAudioAllocated As Long              '// Actual number of audio buffers
    End Structure

    Structure CAPTUREPARMS
        Dim dwRequestMicroSecPerFrame As Long       '// Requested capture rate
        Dim fMakeUserHitOKToCapture As Long         '// Show "Hit OK to cap" dlg?
        Dim wPercentDropForError As Long            '// Give error msg if > (10%)
        Dim fYield As Long                           '// Capture via background task?
        Dim dwIndexSize As Long                     '// Max index size in frames (32K)
        Dim wChunkGranularity As Long               '// Junk chunk granularity (2K)
        Dim fUsingDOSMemory As Long                 '// Use DOS buffers?
        Dim wNumVideoRequested As Long               '// # video buffers, If 0, autocalc
        Dim fCaptureAudio As Long                    '// Capture audio?
        Dim wNumAudioRequested As Long              '// # audio buffers, If 0, autocalc
        Dim vKeyAbort As Long                       '// Virtual key causing abort
        Dim fAbortLeftMouse As Long                  '// Abort on left mouse?
        Dim fAbortRightMouse As Long                 '// Abort on right mouse?
        Dim fLimitEnabled As Long                    '// Use wTimeLimit?
        Dim wTimeLimit As Long                       '// Seconds to capture
        Dim fMCIControl As Long                     '// Use MCI video source?
        Dim fStepMCIDevice As Long                   '// Step MCI device?
        Dim dwMCIStartTime As Long                   '// Time to start in MS
        Dim dwMCIStopTime As Long                   '// Time to stop in MS
        Dim fStepCaptureAt2x As Long                 '// Perform spatial averaging 2x
        Dim wStepCaptureAverageFrames As Long       '// Temporal average n Frames
        Dim dwAudioBufferSize As Long               '// Size of audio bufs (0 = default)
        Dim fDisableWriteCache As Long              '// Attempt to disable write cache
    End Structure

    Structure CAPINFOCHUNK
        Dim fccInfoID As Long                       '// Chunk ID, "ICOP" for copyright
        Dim lpData As Long                           '// pointer to data
        Dim cbData As Long                          '// size of lpData
    End Structure

    Structure VIDEOHDR
        Dim lpData As Long '// address of video buffer
        Dim dwBufferLength As Long '// size, in bytes, of the Data buffer
        Dim dwBytesUsed As Long '// see below
        Dim dwTimeCaptured As Long '// see below
        Dim dwUser As Long '// user-specific data
        Dim dwFlags As Long '// see below
        Dim dwReserved() As Long '// reserved; do not use}
    End Structure

    Structure POINTAPI
        Dim x As Long
        Dim y As Long
    End Structure

#End Region

#Region "Declared Functions"




    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" ( _
        ByVal wDriver As Integer, _
        ByVal lpszName As String, _
        ByVal cbName As Long, _
        ByVal lpszVer As String, _
        ByVal cbVer As Long) As Boolean

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
      ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
      ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
          (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
          <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Private Declare Function SendMessageAsString Lib "user32" Alias "SendMessageA" _
                                        (ByVal hWnd As Long, _
                                        ByVal wMsg As Long, _
                                        ByVal wParam As Long, _
                                        ByVal lParam As String) As Long

    Declare Function SendMessageS Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Integer, ByVal lParam As String) As Long

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

#End Region


    Private Declare Function GetTickCount Lib "kernel32" () As Long
    Function capSetCallbackOnError(ByVal lwnd As Long, ByVal lpProc As Long) As Boolean
        capSetCallbackOnError = SendMessage(lwnd, WM_CAP_SET_CALLBACK_ERROR, 0, lpProc)
    End Function
    Function capSetCallbackOnStatus(ByVal lwnd As Long, ByVal lpProc As Long) As Boolean
        capSetCallbackOnStatus = SendMessage(lwnd, WM_CAP_SET_CALLBACK_STATUS, 0, lpProc)
    End Function
    Function capSetCallbackOnYield(ByVal lwnd As Long, ByVal lpProc As Long) As Boolean
        capSetCallbackOnYield = SendMessage(lwnd, WM_CAP_SET_CALLBACK_YIELD, 0, lpProc)
    End Function
    Function capSetCallbackOnFrame(ByVal lwnd As Long, ByVal lpProc As Long) As Boolean
        capSetCallbackOnFrame = SendMessage(lwnd, WM_CAP_SET_CALLBACK_FRAME, 0, lpProc)
    End Function
    Function capSetCallbackOnVideoStream(ByVal lwnd As Long, ByVal lpProc As Long) As Boolean
        capSetCallbackOnVideoStream = SendMessage(lwnd, WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, lpProc)
    End Function
    Function capSetCallbackOnWaveStream(ByVal lwnd As Long, ByVal lpProc As Long) As Boolean
        capSetCallbackOnWaveStream = SendMessage(lwnd, WM_CAP_SET_CALLBACK_WAVESTREAM, 0, lpProc)
    End Function
    Function capSetCallbackOnCapControl(ByVal lwnd As Long, ByVal lpProc As Long) As Boolean
        capSetCallbackOnCapControl = SendMessage(lwnd, WM_CAP_SET_CALLBACK_CAPCONTROL, 0, lpProc)
    End Function
    Function capSetUserData(ByVal lwnd As Long, ByVal lUser As Long) As Boolean
        capSetUserData = SendMessage(lwnd, WM_CAP_SET_USER_DATA, 0, lUser)
    End Function
    Function capGetUserData(ByVal lwnd As Long) As Long
        capGetUserData = SendMessage(lwnd, WM_CAP_GET_USER_DATA, 0, 0)
    End Function
    Function capDriverConnect(ByVal lwnd As Long, ByVal i As Integer) As Boolean
        capDriverConnect = SendMessage(lwnd, WM_CAP_DRIVER_CONNECT, i, 0)
    End Function
    Function capDriverDisconnect(ByVal lwnd As Long) As Boolean
        capDriverDisconnect = SendMessage(lwnd, WM_CAP_DRIVER_DISCONNECT, 0, 0)
    End Function
    Function capDriverGetName(ByVal lwnd As Long, ByVal szName As Long, ByVal wSize As Integer) As Boolean
        capDriverGetName = SendMessage(lwnd, YOURCONSTANTMESSAGE, wSize, szName)
    End Function
    Function capDriverGetVersion(ByVal lwnd As Long, ByVal szVer As Long, ByVal wSize As Integer) As Boolean
        capDriverGetVersion = SendMessage(lwnd, WM_CAP_DRIVER_GET_VERSION, wSize, szVer)
    End Function
    Function capDriverGetCaps(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Boolean
        capDriverGetCaps = SendMessage(lwnd, WM_CAP_DRIVER_GET_CAPS, wSize, s)
    End Function
    Function capFileSetCaptureFile(ByVal lwnd As Long, ByVal szName As String) As Boolean
        capFileSetCaptureFile = SendMessageS(lwnd, WM_CAP_FILE_SET_CAPTURE_FILE, 0, szName)
    End Function
    Function capFileGetCaptureFile(ByVal lwnd As Long, ByVal szName As Long, ByVal wSize As String) As Boolean
        capFileGetCaptureFile = SendMessageS(lwnd, WM_CAP_FILE_SET_CAPTURE_FILE, wSize, szName)
    End Function
    Function capFileGetCaptureFile(ByVal hCapWnd As Long) As String
        'returns full path of capture file as VB string
        Dim szBuffer As String
        Dim retVal As Boolean

        szBuffer = 128
        retVal = SendMessageAsString(hCapWnd, WM_CAP_FILE_GET_CAPTURE_FILE, 128, szBuffer)
        If retVal Then
            Return Left$(szBuffer, InStr(szBuffer, vbNullChar) - 1)
        Else
            Return Nothing
        End If
    End Function
    Function capFileAlloc(ByVal lwnd As Long, ByVal dwSize As Long) As Boolean
        capFileAlloc = SendMessage(lwnd, WM_CAP_FILE_ALLOCATE, 0, dwSize)
    End Function

    Function capFileSaveAs(ByVal hCapWnd As Long, ByVal FilePath As String) As Boolean
        capFileSaveAs = SendMessageAsString(hCapWnd, WM_CAP_FILE_SAVEAS, 0&, FilePath)
    End Function
    'Function capFileSaveAs(ByVal lwnd As Long, ByVal szName As String) As Boolean
    '    capFileSaveAs = SendMessageS(lwnd, WM_CAP_FILE_SAVEAS, 0, szName)
    'End Function
    Function capFileSetInfoChunk(ByVal lwnd As Long, ByVal lpInfoChunk As Long) As Boolean
        capFileSetInfoChunk = SendMessage(lwnd, WM_CAP_FILE_SET_INFOCHUNK, 0, lpInfoChunk)
    End Function

    Function capFileSaveDIB(ByVal hCapWnd As Long, ByVal FilePath As String) As Boolean
        '==============================================================================
        capFileSaveDIB = SendMessageAsString(hCapWnd, WM_CAP_FILE_SAVEDIB, 0&, FilePath)
    End Function



    Function capEditCopy(ByVal lwnd As Long) As Boolean
        capEditCopy = SendMessage(lwnd, WM_CAP_EDIT_COPY, 0, 0)
    End Function
    Function capSetAudioFormat(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Boolean
        capSetAudioFormat = SendMessage(lwnd, WM_CAP_SET_AUDIOFORMAT, wSize, s)
    End Function
    Function capGetAudioFormat(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Long
        capGetAudioFormat = SendMessage(lwnd, WM_CAP_GET_AUDIOFORMAT, wSize, s)
    End Function
    Function capGetAudioFormatSize(ByVal lwnd As Long) As Long
        capGetAudioFormatSize = SendMessage(lwnd, WM_CAP_GET_AUDIOFORMAT, 0, 0)
    End Function
    Private Function capDlgVideoFormat(ByVal lwnd As Long) As Boolean
        capDlgVideoFormat = SendMessage(lwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0)
    End Function
    Private Function capDlgVideoSource(ByVal lwnd As Long) As Boolean
        capDlgVideoSource = SendMessage(lwnd, WM_CAP_DLG_VIDEOSOURCE, 0, 0)
    End Function
    Function capDlgVideoDisplay(ByVal lwnd As Long) As Boolean
        capDlgVideoDisplay = SendMessage(lwnd, WM_CAP_DLG_VIDEODISPLAY, 0, 0)
    End Function
    Private Function capDlgVideoCompression(ByVal lwnd As Long) As Boolean
        capDlgVideoCompression = SendMessage(lwnd, WM_CAP_DLG_VIDEOCOMPRESSION, 0, 0)
    End Function
    Function capGetVideoFormat(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Long
        capGetVideoFormat = SendMessage(lwnd, WM_CAP_GET_VIDEOFORMAT, wSize, s)
    End Function
    Function capGetVideoFormatSize(ByVal lwnd As Long) As Long
        capGetVideoFormatSize = SendMessage(lwnd, WM_CAP_GET_VIDEOFORMAT, 0, 0)
    End Function
    Function capSetVideoFormat(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Boolean
        capSetVideoFormat = SendMessage(lwnd, WM_CAP_SET_VIDEOFORMAT, wSize, s)
    End Function
    Private Function capPreview(ByVal lwnd As Long, ByVal f As Boolean) As Boolean
        capPreview = SendMessage(lwnd, WM_CAP_SET_PREVIEW, f, 0)
    End Function
    Function capPreviewRate(ByVal lwnd As Long, ByVal wMS As Integer) As Boolean
        capPreviewRate = SendMessage(lwnd, WM_CAP_SET_PREVIEWRATE, wMS, 0)
    End Function
    Function capOverlay(ByVal lwnd As Long, ByVal f As Boolean) As Boolean
        capOverlay = SendMessage(lwnd, WM_CAP_SET_OVERLAY, f, 0)
    End Function
    Function capPreviewScale(ByVal lwnd As Long, ByVal f As Boolean) As Boolean
        capPreviewScale = SendMessage(lwnd, WM_CAP_SET_SCALE, f, 0)
    End Function
    Function capGetStatus(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Boolean
        capGetStatus = SendMessage(lwnd, WM_CAP_GET_STATUS, wSize, s)
    End Function
    Function capSetScrollPos(ByVal lwnd As Long, ByVal lpP As Long) As Boolean
        capSetScrollPos = SendMessage(lwnd, WM_CAP_SET_SCROLL, 0, lpP)
    End Function
    Function capGrabFrame(ByVal lwnd As Long) As Boolean
        capGrabFrame = SendMessage(lwnd, WM_CAP_GRAB_FRAME, 0, 0)
    End Function
    Function capGrabFrameNoStop(ByVal lwnd As Long) As Boolean
        capGrabFrameNoStop = SendMessage(lwnd, WM_CAP_GRAB_FRAME_NOSTOP, 0, 0)
    End Function

    Private Function capCaptureSequence(ByVal lwnd As Long) As Boolean
        'Capture Full AVI stream to default directory C:\
        capCaptureSequence = SendMessage(lwnd, WM_CAP_SEQUENCE, 0, 0)
    End Function

    Function capCaptureSequenceNoFile(ByVal lwnd As Long) As Boolean
        capCaptureSequenceNoFile = SendMessage(lwnd, WM_CAP_SEQUENCE_NOFILE, 0, 0)
    End Function
    Function capCaptureStop(ByVal lwnd As Long) As Boolean
        capCaptureStop = SendMessage(lwnd, WM_CAP_STOP, 0, 0)
    End Function
    Function capCaptureAbort(ByVal lwnd As Long) As Boolean
        capCaptureAbort = SendMessage(lwnd, WM_CAP_ABORT, 0, 0)
    End Function
    Function capCaptureSingleFrameOpen(ByVal lwnd As Long) As Boolean
        capCaptureSingleFrameOpen = SendMessage(lwnd, WM_CAP_SINGLE_FRAME_OPEN, 0, 0)
    End Function
    Function capCaptureSingleFrameClose(ByVal lwnd As Long) As Boolean
        capCaptureSingleFrameClose = SendMessage(lwnd, WM_CAP_SINGLE_FRAME_CLOSE, 0, 0)
    End Function
    Function capCaptureSingleFrame(ByVal lwnd As Long) As Boolean
        capCaptureSingleFrame = SendMessage(lwnd, WM_CAP_SINGLE_FRAME, 0, 0)
    End Function
    Function capCaptureGetSetup(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Boolean
        capCaptureGetSetup = SendMessage(lwnd, WM_CAP_GET_SEQUENCE_SETUP, wSize, s)
    End Function
    Function capCaptureSetSetup(ByVal lwnd As Long, ByVal s As Long, ByVal wSize As Integer) As Boolean
        capCaptureSetSetup = SendMessage(lwnd, WM_CAP_SET_SEQUENCE_SETUP, wSize, s)
    End Function
    Function capSetMCIDeviceName(ByVal lwnd As Long, ByVal szName As Long) As Boolean
        capSetMCIDeviceName = SendMessage(lwnd, WM_CAP_SET_MCI_DEVICE, 0, szName)
    End Function
    Function capGetMCIDeviceName(ByVal lwnd As Long, ByVal szName As Long, ByVal wSize As Integer) As Boolean
        capGetMCIDeviceName = SendMessage(lwnd, WM_CAP_GET_MCI_DEVICE, wSize, szName)
    End Function
    Function capPaletteOpen(ByVal lwnd As Long, ByVal szName As Long) As Boolean
        capPaletteOpen = SendMessage(lwnd, WM_CAP_PAL_OPEN, 0, szName)
    End Function
    Function capPaletteSave(ByVal lwnd As Long, ByVal szName As Long) As Boolean
        capPaletteSave = SendMessage(lwnd, WM_CAP_PAL_SAVE, 0, szName)
    End Function
    Function capPalettePaste(ByVal lwnd As Long) As Boolean
        capPalettePaste = SendMessage(lwnd, WM_CAP_PAL_PASTE, 0, 0)
    End Function
    Function capPaletteAuto(ByVal lwnd As Long, ByVal iFrames As Integer, ByVal iColor As Long) As Boolean
        capPaletteAuto = SendMessage(lwnd, WM_CAP_PAL_AUTOCREATE, iFrames, iColor)
    End Function
    Function capPaletteManual(ByVal lwnd As Long, ByVal fGrab As Boolean, ByVal iColors As Long) As Boolean
        capPaletteManual = SendMessage(lwnd, WM_CAP_PAL_MANUALCREATE, fGrab, iColors)
    End Function

    ReadOnly Property GethHwnd()
        Get
            GethHwnd = hHwnd
        End Get

    End Property
    Public Function OpenPreviewWindow(ByVal Control As Windows.Forms.Control, ByVal iDevice As Integer, ByVal PreviewRateValue As Integer) As Boolean

        Dim iHeight As Integer = Control.Height
        Dim iWidth As Integer = Control.Width
        Try
            ' Open Preview window in picturebox
            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
                480, Control.Handle.ToInt32, 0)
            ' There is some processing time here on windows 7+ systems.
            Dim IniTime As Long = GetTickCount()
            While GetTickCount() < (IniTime + 1000)
                Application.DoEvents()
            End While
            Dim OKAnswer As Boolean = False
            For xretries As Integer = 1 To 10
                ' I'll give you Only 10 tries to connect, otherwise I AM LEAVING MICROSOFT!
                OKAnswer = SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
                If OKAnswer Then
                    Exit For
                End If
            Next
            If OKAnswer Then
                ' Connect to device
                'If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
                'Set the preview scale
                Call SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
                'Set the preview rate in milliseconds
                Call SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, PreviewRateValue, 0)
                'Start previewing the image from the camera
                Call SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
                ' Resize window to fit in picturebox
                Call SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, Control.Width, Control.Height, _
                        SWP_NOMOVE Or SWP_NOZORDER)
                RaiseEvent PreviewWindowStatus("Preview Window Active")
                Return True
            Else
                ' Error connecting to device close window
                DestroyWindow(hHwnd)
                RaiseEvent PreviewWindowStatus("Error connecting to device")
                Return False
            End If
        Catch ex As Exception
            RaiseEvent ErrorMsg(Err.Description & " " & Err.Source)
            Return False
        End Try

    End Function

    Public Function ClosePreviewWindow(ByVal iDevice As Integer) As Boolean
        ' Disconnect from device
        Try
            If iDevice = -1 Then
                RaiseEvent ErrorMsg("No Device value passed")
                Return False
                Exit Function
            Else
                Call SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)
                ' close window
                Call DestroyWindow(hHwnd)
                RaiseEvent PreviewWindowStatus("Preview Window Closed")
                Return True
            End If
        Catch ex As Exception
            RaiseEvent ErrorMsg(Err.Description & " " & Err.Source)
            Return False
        End Try

    End Function
    'Display the video format dialog box
    Public Sub DisplayVideoFormat()
        Call capDlgVideoFormat(hHwnd)
    End Sub
    'Display the video Source dialog box
    Public Sub DisplayVideoSource()
        Call capDlgVideoSource(hHwnd)
    End Sub
    'Display the video Compression dialog box
    Public Sub DisplayVideoCompression()
        Call capDlgVideoCompression(hHwnd)
    End Sub
    'Pause and restart the preview
    Public Function StartStopPreview(ByVal TF As Boolean) As Boolean
        Dim d As Boolean

        Try
            Call capPreview(hHwnd, TF)

            If TF = False Then
                RaiseEvent PreviewWindowStatus("Preview Window Paused")
            Else
                RaiseEvent PreviewWindowStatus("Preview Window Active")
            End If
            d = True
        Catch ex As Exception
            RaiseEvent ErrorMsg(Err.Description & " " & Err.Source)
            d = False
        End Try
        Return d
    End Function

    Public Sub CaptureSequence(ByVal hHwnd As Long)
        'Capture Full AVI stream to default directory C:\
        capCaptureSequence(hHwnd)
    End Sub

    Public Function GetClipboardImage(ByVal hHwnd As Integer) As Image
        Dim data As IDataObject
        Dim bmap As Image
        Try
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

            data = Clipboard.GetDataObject
            If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then

                bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
                'bmap.Save("c:\webimage.jpg", Imaging.ImageFormat.Jpeg())
                Return bmap
            End If
        Catch ex As Exception
            RaiseEvent ErrorMsg(Err.Description & " " & Err.Source)
            Return Nothing
        End Try
        Return Nothing
    End Function





End Class


