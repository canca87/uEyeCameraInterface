<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainCaptureWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainCaptureWindow))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssl_runningState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_FPS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_Aval = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_Bval = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.LiveFeedPB = New System.Windows.Forms.PictureBox()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.lblRatio = New System.Windows.Forms.Label()
        Me.tlbCBoptions = New System.Windows.Forms.TableLayoutPanel()
        Me.cbAutoGain = New System.Windows.Forms.CheckBox()
        Me.cbAutoExpose = New System.Windows.Forms.CheckBox()
        Me.lblExposureTime = New System.Windows.Forms.Label()
        Me.tbExposureValue = New System.Windows.Forms.TrackBar()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        CType(Me.LiveFeedPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbCBoptions.SuspendLayout()
        CType(Me.tbExposureValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1005, 28)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(108, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.StopToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(56, 24)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Enabled = False
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_runningState, Me.tssl_FPS, Me.tssl_Aval, Me.tssl_Bval, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 629)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 13, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1005, 25)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssl_runningState
        '
        Me.tssl_runningState.Name = "tssl_runningState"
        Me.tssl_runningState.Size = New System.Drawing.Size(92, 20)
        Me.tssl_runningState.Text = "Not Running"
        '
        'tssl_FPS
        '
        Me.tssl_FPS.Name = "tssl_FPS"
        Me.tssl_FPS.Size = New System.Drawing.Size(295, 20)
        Me.tssl_FPS.Spring = True
        Me.tssl_FPS.Text = "Frames Per Second: 0"
        '
        'tssl_Aval
        '
        Me.tssl_Aval.Name = "tssl_Aval"
        Me.tssl_Aval.Size = New System.Drawing.Size(295, 20)
        Me.tssl_Aval.Spring = True
        Me.tssl_Aval.Text = "Intensity at A: 0"
        '
        'tssl_Bval
        '
        Me.tssl_Bval.Name = "tssl_Bval"
        Me.tssl_Bval.Size = New System.Drawing.Size(295, 20)
        Me.tssl_Bval.Spring = True
        Me.tssl_Bval.Text = "Intensity at B: 0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(13, 20)
        Me.ToolStripStatusLabel1.Text = " "
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211.0!))
        Me.tlpMain.Controls.Add(Me.LiveFeedPB, 1, 3)
        Me.tlpMain.Controls.Add(Me.picCapture, 0, 0)
        Me.tlpMain.Controls.Add(Me.btnStart, 1, 0)
        Me.tlpMain.Controls.Add(Me.btnStop, 1, 1)
        Me.tlpMain.Controls.Add(Me.lblRatio, 1, 2)
        Me.tlpMain.Controls.Add(Me.tlbCBoptions, 0, 4)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 28)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(3, 2, 3, 44)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 5
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1005, 601)
        Me.tlpMain.TabIndex = 12
        '
        'LiveFeedPB
        '
        Me.LiveFeedPB.Location = New System.Drawing.Point(798, 327)
        Me.LiveFeedPB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LiveFeedPB.Name = "LiveFeedPB"
        Me.LiveFeedPB.Size = New System.Drawing.Size(203, 128)
        Me.LiveFeedPB.TabIndex = 13
        Me.LiveFeedPB.TabStop = False
        '
        'picCapture
        '
        Me.picCapture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picCapture.Location = New System.Drawing.Point(3, 2)
        Me.picCapture.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picCapture.Name = "picCapture"
        Me.tlpMain.SetRowSpan(Me.picCapture, 4)
        Me.picCapture.Size = New System.Drawing.Size(788, 550)
        Me.picCapture.TabIndex = 2
        Me.picCapture.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(801, 7)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(197, 61)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStop.Enabled = False
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(801, 82)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(197, 61)
        Me.btnStop.TabIndex = 0
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'lblRatio
        '
        Me.lblRatio.AutoSize = True
        Me.lblRatio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRatio.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatio.Location = New System.Drawing.Point(801, 157)
        Me.lblRatio.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
        Me.lblRatio.Name = "lblRatio"
        Me.lblRatio.Size = New System.Drawing.Size(197, 159)
        Me.lblRatio.TabIndex = 5
        Me.lblRatio.Text = "Ratio: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.lblRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tlbCBoptions
        '
        Me.tlbCBoptions.ColumnCount = 4
        Me.tlbCBoptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.tlbCBoptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193.0!))
        Me.tlbCBoptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlbCBoptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171.0!))
        Me.tlbCBoptions.Controls.Add(Me.cbAutoGain, 0, 0)
        Me.tlbCBoptions.Controls.Add(Me.cbAutoExpose, 1, 0)
        Me.tlbCBoptions.Controls.Add(Me.lblExposureTime, 3, 0)
        Me.tlbCBoptions.Controls.Add(Me.tbExposureValue, 2, 0)
        Me.tlbCBoptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlbCBoptions.Location = New System.Drawing.Point(4, 558)
        Me.tlbCBoptions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tlbCBoptions.Name = "tlbCBoptions"
        Me.tlbCBoptions.RowCount = 1
        Me.tlbCBoptions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlbCBoptions.Size = New System.Drawing.Size(786, 39)
        Me.tlbCBoptions.TabIndex = 6
        '
        'cbAutoGain
        '
        Me.cbAutoGain.AutoSize = True
        Me.cbAutoGain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbAutoGain.Enabled = False
        Me.cbAutoGain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAutoGain.Location = New System.Drawing.Point(4, 4)
        Me.cbAutoGain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbAutoGain.Name = "cbAutoGain"
        Me.cbAutoGain.Size = New System.Drawing.Size(137, 31)
        Me.cbAutoGain.TabIndex = 0
        Me.cbAutoGain.Text = "Auto Gain"
        Me.cbAutoGain.UseVisualStyleBackColor = True
        Me.cbAutoGain.Visible = False
        '
        'cbAutoExpose
        '
        Me.cbAutoExpose.AutoSize = True
        Me.cbAutoExpose.Checked = True
        Me.cbAutoExpose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAutoExpose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbAutoExpose.Enabled = False
        Me.cbAutoExpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAutoExpose.Location = New System.Drawing.Point(149, 4)
        Me.cbAutoExpose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbAutoExpose.Name = "cbAutoExpose"
        Me.cbAutoExpose.Size = New System.Drawing.Size(185, 31)
        Me.cbAutoExpose.TabIndex = 0
        Me.cbAutoExpose.Text = "Auto Exposure"
        Me.cbAutoExpose.UseVisualStyleBackColor = True
        '
        'lblExposureTime
        '
        Me.lblExposureTime.AutoSize = True
        Me.lblExposureTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblExposureTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExposureTime.Location = New System.Drawing.Point(622, 7)
        Me.lblExposureTime.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
        Me.lblExposureTime.Name = "lblExposureTime"
        Me.lblExposureTime.Size = New System.Drawing.Size(157, 25)
        Me.lblExposureTime.TabIndex = 5
        Me.lblExposureTime.Text = "-"
        Me.lblExposureTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbExposureValue
        '
        Me.tbExposureValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbExposureValue.Enabled = False
        Me.tbExposureValue.Location = New System.Drawing.Point(341, 2)
        Me.tbExposureValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbExposureValue.Name = "tbExposureValue"
        Me.tbExposureValue.Size = New System.Drawing.Size(271, 35)
        Me.tbExposureValue.TabIndex = 6
        '
        'MainCaptureWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 654)
        Me.Controls.Add(Me.tlpMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "MainCaptureWindow"
        Me.Text = "Intensity Analysis"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.LiveFeedPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbCBoptions.ResumeLayout(False)
        Me.tlbCBoptions.PerformLayout()
        CType(Me.tbExposureValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssl_runningState As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_FPS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_Aval As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssl_Bval As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picCapture As System.Windows.Forms.PictureBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents lblRatio As System.Windows.Forms.Label
    Friend WithEvents tlbCBoptions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbAutoGain As System.Windows.Forms.CheckBox
    Friend WithEvents LiveFeedPB As System.Windows.Forms.PictureBox
    Friend WithEvents cbAutoExpose As System.Windows.Forms.CheckBox
    Friend WithEvents lblExposureTime As System.Windows.Forms.Label
    Friend WithEvents tbExposureValue As System.Windows.Forms.TrackBar

End Class
