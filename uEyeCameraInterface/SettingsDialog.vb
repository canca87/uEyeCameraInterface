Public Class SettingsDialog
    Dim Settings As ColorsForDisplay

    Public Overloads Sub ShowDialog(ByRef colors As ColorsForDisplay)
        If Not IsNothing(colors) Then
            Settings = colors
            Me.ShowDialog()
        End If
    End Sub

    Private Sub UpdateSettings()
        lblAxisColor.BackColor = Settings.AxisColor
        lblAcolor.BackColor = Settings.Acolor
        lblBcolor.BackColor = Settings.Bcolor
        cbRatioColoring.Checked = Settings.RatioColorsOnOff
        nudAxisSize.Value = Settings.AxisWidth
        nudFilterWidth.Value = Settings.FilterWidth
    End Sub

    Private Sub SettingsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateSettings()
    End Sub

    Private Sub btnSetAxisColor_Click(sender As Object, e As EventArgs) Handles btnSetAxisColor.Click
        ColorDialog.Color = Settings.AxisColor
        Dim results As DialogResult = ColorDialog.ShowDialog
        If results = Windows.Forms.DialogResult.OK Then
            Settings.AxisColor = ColorDialog.Color
        End If
        UpdateSettings()
    End Sub

    Private Sub btnSetAcolor_Click(sender As Object, e As EventArgs) Handles btnSetAcolor.Click
        ColorDialog.Color = Settings.Acolor
        Dim results As DialogResult = ColorDialog.ShowDialog
        If results = Windows.Forms.DialogResult.OK Then
            Settings.Acolor = ColorDialog.Color
        End If
        UpdateSettings()
    End Sub

    Private Sub btnSetBcolor_Click(sender As Object, e As EventArgs) Handles btnSetBcolor.Click
        ColorDialog.Color = Settings.Bcolor
        Dim results As DialogResult = ColorDialog.ShowDialog
        If results = Windows.Forms.DialogResult.OK Then
            Settings.Bcolor = ColorDialog.Color
        End If
        UpdateSettings()
    End Sub

    Private Sub cbRatioColoring_CheckedChanged(sender As Object, e As EventArgs) Handles cbRatioColoring.CheckedChanged
        If Not IsNothing(Settings) Then
            Settings.RatioColorsOnOff = cbRatioColoring.Checked
            UpdateSettings()
        End If
    End Sub

    Private Sub nudAxisSize_ValueChanged(sender As Object, e As EventArgs) Handles nudAxisSize.ValueChanged
        If Not IsNothing(Settings) Then
            Settings.AxisWidth = nudAxisSize.Value
            UpdateSettings()
        End If
    End Sub

    Private Sub nudFilterWidth_ValueChanged(sender As Object, e As EventArgs) Handles nudFilterWidth.ValueChanged
        If Not IsNothing(Settings) Then
            Settings.FilterWidth = CInt(nudFilterWidth.Value)
            UpdateSettings()
        End If
    End Sub

    Private Sub btnSetRatioValues_Click(sender As Object, e As EventArgs) Handles btnSetRatioValues.Click
        Dim RatioWindow As New RatioValueSelectionDialog
        RatioWindow.ShowDialog(Settings)
    End Sub
End Class