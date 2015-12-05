Public Class RatioValueSelectionDialog
    Dim Settings As ColorsForDisplay

    Public Overloads Sub ShowDialog(ByRef colors As ColorsForDisplay)
        If Not IsNothing(colors) Then
            Settings = colors
            Me.ShowDialog()
        End If
    End Sub



    Private Sub RatioValueSelectionDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(Settings) Then
            UpdateImageDisplay()
            UpdateSettings()
        End If

    End Sub

    Private Sub UpdateImageDisplay()
        'Create a blank cavas for drawing the information on to, this must be the same size as the picture box.
        Dim OverlayBitmap As New Bitmap(pbRatioDisplay.Width, pbRatioDisplay.Height)
        Dim myGraphics As Graphics = Graphics.FromImage(OverlayBitmap)

        'some objects for the drawing process:
        Dim _rect As Rectangle
        Dim _brush As New SolidBrush(Color.Black)
        Dim _height As Integer = pbRatioDisplay.Height
        Dim _width As Integer = 0
        Dim _startHeight As Integer = 0
        Dim _startWidth As Integer = 0

        'make the background red square first
        _width = pbRatioDisplay.Width
        _rect = New Rectangle(_startWidth, _startHeight, _width, _height)
        _brush.Color = Settings.RatioBadcolor
        myGraphics.FillRectangle(_brush, _rect)

        'need to know the OK location now (as a linear %):
        Dim _locOK_pc As Double = tbOKvalue.Value / tbOKvalue.Maximum
        Dim _locOK_pb As Integer = _locOK_pc * pbRatioDisplay.Width
        'determine the close % as a +/- value from OK
        Dim _locCLOSE_pc = tbCloseWidth.Value
        Dim _locCLOSE_pb = (_locCLOSE_pc / 100) * pbRatioDisplay.Width / 2
        'translate that to a starting location
        If (_locOK_pb - _locCLOSE_pb) >= 0 Then
            _startWidth = _locOK_pb - _locCLOSE_pb
        Else
            _startWidth = 0
        End If
        If (_locCLOSE_pb * 2) < pbRatioDisplay.Width Then
            _width = (_locCLOSE_pb * 2)
        Else
            _width = pbRatioDisplay.Width
        End If
        'make the CLOSE square
        _rect = New Rectangle(_startWidth, _startHeight, _width, _height)
        _brush.Color = Settings.RatioClosecolor
        myGraphics.FillRectangle(_brush, _rect)

        'determine the OK % as a +/- value from OK
        Dim _locOKwidth_pc = tbOKwidth.Value
        Dim _locOKwidth_pb = (_locOKwidth_pc / 100) * pbRatioDisplay.Width / 2
        'translate that to a starting location
        If (_locOK_pb - _locOKwidth_pb) >= 0 Then
            _startWidth = _locOK_pb - _locOKwidth_pb
        Else
            _startWidth = 0
        End If
        If (_locOKwidth_pb * 2) < pbRatioDisplay.Width Then
            _width = (_locOKwidth_pb * 2)
        Else
            _width = _locOKwidth_pb * 2
        End If
        'make the OK square
        _rect = New Rectangle(_startWidth, _startHeight, _width, _height)
        _brush.Color = Settings.RatioOKcolor
        myGraphics.FillRectangle(_brush, _rect)

        'put the graphic back on to the picture box
        pbRatioDisplay.Image = OverlayBitmap

        'numerical outputs:
        Settings.OKval = CalculateOKvalue()
        Settings.OKrange_max = CalculateMaxMinOkValues()(0)
        Settings.OKrange_min = CalculateMaxMinOkValues()(1)
        Settings.Close_max = CalculateMaxMinCloseValues()(0)
        Settings.Close_min = CalculateMaxMinCloseValues()(1)

        'check the settings:
        'orange cannot be inside green
        If (Settings.Close_max < Settings.OKrange_max) Or (Settings.Close_min > Settings.OKrange_min) Then
            Settings.Close_max = Settings.OKrange_max
            Settings.Close_min = Settings.OKrange_min
        End If
        'green cannot be outside orange 


        Label1.Text = Settings.OKval.ToString
        lblOkRangeValue.Text = Settings.OKrange_min.ToString & ", " & Settings.OKrange_max.ToString
        lblCloseRangeValue.Text = Settings.Close_min.ToString & ", " & Settings.Close_max.ToString

    End Sub

    Private Function CalculateOKvalue() As Double
        Return tbOKvalue.Value / tbOKvalue.Maximum 'ConvertPCtoVal(tbOKvalue.Value / tbOKvalue.Maximum)
    End Function
    Private Function CalculateMaxMinCloseValues() As Double()
        Dim _max As Double
        Dim _min As Double

        '_min = ConvertPCtoVal((tbOKvalue.Value / tbOKvalue.Maximum) - (tbCloseWidth.Value / 200))
        '_max = ConvertPCtoVal((tbOKvalue.Value / tbOKvalue.Maximum) + (tbCloseWidth.Value / 200))
        _min = (tbOKvalue.Value / tbOKvalue.Maximum) - (tbCloseWidth.Value / 200)
        _max = (tbOKvalue.Value / tbOKvalue.Maximum) + (tbCloseWidth.Value / 200)


        Return {_max, _min}
    End Function
    Private Function CalculateMaxMinOkValues() As Double()
        Dim _max As Double
        Dim _min As Double

        '_min = ConvertPCtoVal((tbOKvalue.Value / tbOKvalue.Maximum) - (tbOKwidth.Value / 200))
        '_max = ConvertPCtoVal((tbOKvalue.Value / tbOKvalue.Maximum) + (tbOKwidth.Value / 200))
        _min = (tbOKvalue.Value / tbOKvalue.Maximum) - (tbOKwidth.Value / 200)
        _max = (tbOKvalue.Value / tbOKvalue.Maximum) + (tbOKwidth.Value / 200)

        Return {_max, _min}
    End Function

    Private Function ConvertPCtoVal(ByVal PC As Double) As Double
        Dim _locOK As Double
        Dim _tLoc As Double = PC
        If (_tLoc < 0.5) Then
            _locOK = _tLoc * 2
        ElseIf (_tLoc > 0.5) Then
            _locOK = ((_tLoc * 2) - 1) * 100
        Else
            _locOK = 1
        End If
        'apply some hard limitations:
        If _locOK > 100 Then
            _locOK = 100
        ElseIf _locOK < 0 Then
            _locOK = 0
        End If
        'return the answer
        Return _locOK
    End Function

    Private Sub tbOKvalue_Scroll(sender As Object, e As EventArgs) Handles tbOKvalue.Scroll
        If Not IsNothing(Settings) Then
            UpdateImageDisplay()
        End If
    End Sub

    Private Sub tbCloseWidth_Scroll(sender As Object, e As EventArgs) Handles tbCloseWidth.Scroll
        If Not IsNothing(Settings) Then
            UpdateImageDisplay()
        End If
    End Sub

    Private Sub tbOKwidth_Scroll(sender As Object, e As EventArgs) Handles tbOKwidth.Scroll
        If Not IsNothing(Settings) Then
            UpdateImageDisplay()
        End If
    End Sub

    Private Sub btnChangeOKcolor_Click(sender As Object, e As EventArgs) Handles btnChangeOKcolor.Click
        ColorDialog.Color = Settings.RatioOKcolor
        Dim results As DialogResult = ColorDialog.ShowDialog
        If results = Windows.Forms.DialogResult.OK Then
            Settings.RatioOKcolor = ColorDialog.Color
        End If
        UpdateSettings()
    End Sub

    Private Sub btnCLOSEchange_Click(sender As Object, e As EventArgs) Handles btnCLOSEchange.Click
        ColorDialog.Color = Settings.RatioClosecolor
        Dim results As DialogResult = ColorDialog.ShowDialog
        If results = Windows.Forms.DialogResult.OK Then
            Settings.RatioClosecolor = ColorDialog.Color
        End If
        UpdateSettings()
    End Sub

    Private Sub btnBADchange_Click(sender As Object, e As EventArgs) Handles btnBADchange.Click
        ColorDialog.Color = Settings.RatioBadcolor
        Dim results As DialogResult = ColorDialog.ShowDialog
        If results = Windows.Forms.DialogResult.OK Then
            Settings.RatioBadcolor = ColorDialog.Color
        End If
        UpdateSettings()
    End Sub

    Private Sub UpdateSettings()

        lblBADcolor.BackColor = Settings.RatioBadcolor
        lblCLOSEcolor.BackColor = Settings.RatioClosecolor
        lblOKcolor.BackColor = Settings.RatioOKcolor

    End Sub

End Class