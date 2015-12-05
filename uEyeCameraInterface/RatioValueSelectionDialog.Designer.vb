<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RatioValueSelectionDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RatioValueSelectionDialog))
        Me.pbRatioDisplay = New System.Windows.Forms.PictureBox()
        Me.tbOKvalue = New System.Windows.Forms.TrackBar()
        Me.tbOKwidth = New System.Windows.Forms.TrackBar()
        Me.tbCloseWidth = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblOkRangeValue = New System.Windows.Forms.Label()
        Me.lblCloseRangeValue = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblBADcolor = New System.Windows.Forms.Label()
        Me.lblCloseRangeName = New System.Windows.Forms.Label()
        Me.lblOKrangeName = New System.Windows.Forms.Label()
        Me.lblCLOSEcolor = New System.Windows.Forms.Label()
        Me.lblOKcolor = New System.Windows.Forms.Label()
        Me.btnChangeOKcolor = New System.Windows.Forms.Button()
        Me.btnCLOSEchange = New System.Windows.Forms.Button()
        Me.btnBADchange = New System.Windows.Forms.Button()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.lblRatioName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.pbRatioDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbOKvalue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbOKwidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCloseWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbRatioDisplay
        '
        Me.pbRatioDisplay.Location = New System.Drawing.Point(16, 351)
        Me.pbRatioDisplay.Margin = New System.Windows.Forms.Padding(4)
        Me.pbRatioDisplay.Name = "pbRatioDisplay"
        Me.pbRatioDisplay.Size = New System.Drawing.Size(1067, 50)
        Me.pbRatioDisplay.TabIndex = 0
        Me.pbRatioDisplay.TabStop = False
        '
        'tbOKvalue
        '
        Me.tbOKvalue.LargeChange = 100
        Me.tbOKvalue.Location = New System.Drawing.Point(16, 288)
        Me.tbOKvalue.Margin = New System.Windows.Forms.Padding(4)
        Me.tbOKvalue.Maximum = 1000
        Me.tbOKvalue.Minimum = 1
        Me.tbOKvalue.Name = "tbOKvalue"
        Me.tbOKvalue.Size = New System.Drawing.Size(1067, 56)
        Me.tbOKvalue.SmallChange = 10
        Me.tbOKvalue.TabIndex = 1
        Me.tbOKvalue.TickFrequency = 20
        Me.tbOKvalue.Value = 271
        '
        'tbOKwidth
        '
        Me.tbOKwidth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbOKwidth.Location = New System.Drawing.Point(714, 4)
        Me.tbOKwidth.Margin = New System.Windows.Forms.Padding(4)
        Me.tbOKwidth.Maximum = 100
        Me.tbOKwidth.Name = "tbOKwidth"
        Me.tbOKwidth.Size = New System.Drawing.Size(349, 50)
        Me.tbOKwidth.TabIndex = 2
        Me.tbOKwidth.TickFrequency = 2
        Me.tbOKwidth.Value = 10
        '
        'tbCloseWidth
        '
        Me.tbCloseWidth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbCloseWidth.Location = New System.Drawing.Point(714, 62)
        Me.tbCloseWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.tbCloseWidth.Maximum = 100
        Me.tbCloseWidth.Name = "tbCloseWidth"
        Me.tbCloseWidth.Size = New System.Drawing.Size(349, 50)
        Me.tbCloseWidth.TabIndex = 3
        Me.tbCloseWidth.TickFrequency = 2
        Me.tbCloseWidth.Value = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(552, 246)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOkRangeValue
        '
        Me.lblOkRangeValue.AutoSize = True
        Me.lblOkRangeValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOkRangeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOkRangeValue.Location = New System.Drawing.Point(536, 0)
        Me.lblOkRangeValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOkRangeValue.Name = "lblOkRangeValue"
        Me.lblOkRangeValue.Size = New System.Drawing.Size(170, 58)
        Me.lblOkRangeValue.TabIndex = 5
        Me.lblOkRangeValue.Text = "Label2"
        Me.lblOkRangeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCloseRangeValue
        '
        Me.lblCloseRangeValue.AutoSize = True
        Me.lblCloseRangeValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCloseRangeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCloseRangeValue.Location = New System.Drawing.Point(536, 58)
        Me.lblCloseRangeValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCloseRangeValue.Name = "lblCloseRangeValue"
        Me.lblCloseRangeValue.Size = New System.Drawing.Size(170, 58)
        Me.lblCloseRangeValue.TabIndex = 6
        Me.lblCloseRangeValue.Text = "Label3"
        Me.lblCloseRangeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.875!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.75!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.25!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblBADcolor, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCloseRangeName, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblOKrangeName, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCloseRangeValue, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.tbCloseWidth, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCLOSEcolor, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.tbOKwidth, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblOkRangeValue, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblOKcolor, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnChangeOKcolor, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCLOSEchange, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnBADchange, 0, 2)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(16, 14)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1067, 176)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'lblBADcolor
        '
        Me.lblBADcolor.AutoSize = True
        Me.lblBADcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBADcolor.Location = New System.Drawing.Point(255, 126)
        Me.lblBADcolor.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.lblBADcolor.Name = "lblBADcolor"
        Me.lblBADcolor.Size = New System.Drawing.Size(39, 40)
        Me.lblBADcolor.TabIndex = 5
        '
        'lblCloseRangeName
        '
        Me.lblCloseRangeName.AutoSize = True
        Me.lblCloseRangeName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCloseRangeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCloseRangeName.Location = New System.Drawing.Point(309, 58)
        Me.lblCloseRangeName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCloseRangeName.Name = "lblCloseRangeName"
        Me.lblCloseRangeName.Size = New System.Drawing.Size(219, 58)
        Me.lblCloseRangeName.TabIndex = 4
        Me.lblCloseRangeName.Text = "Range of color (%): "
        Me.lblCloseRangeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOKrangeName
        '
        Me.lblOKrangeName.AutoSize = True
        Me.lblOKrangeName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOKrangeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOKrangeName.Location = New System.Drawing.Point(309, 0)
        Me.lblOKrangeName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOKrangeName.Name = "lblOKrangeName"
        Me.lblOKrangeName.Size = New System.Drawing.Size(219, 58)
        Me.lblOKrangeName.TabIndex = 4
        Me.lblOKrangeName.Text = "Range of color (%): "
        Me.lblOKrangeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCLOSEcolor
        '
        Me.lblCLOSEcolor.AutoSize = True
        Me.lblCLOSEcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCLOSEcolor.Location = New System.Drawing.Point(255, 68)
        Me.lblCLOSEcolor.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.lblCLOSEcolor.Name = "lblCLOSEcolor"
        Me.lblCLOSEcolor.Size = New System.Drawing.Size(39, 38)
        Me.lblCLOSEcolor.TabIndex = 4
        '
        'lblOKcolor
        '
        Me.lblOKcolor.AutoSize = True
        Me.lblOKcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOKcolor.Location = New System.Drawing.Point(255, 10)
        Me.lblOKcolor.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.lblOKcolor.Name = "lblOKcolor"
        Me.lblOKcolor.Size = New System.Drawing.Size(39, 38)
        Me.lblOKcolor.TabIndex = 3
        '
        'btnChangeOKcolor
        '
        Me.btnChangeOKcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChangeOKcolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeOKcolor.Location = New System.Drawing.Point(3, 2)
        Me.btnChangeOKcolor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnChangeOKcolor.Name = "btnChangeOKcolor"
        Me.btnChangeOKcolor.Size = New System.Drawing.Size(238, 54)
        Me.btnChangeOKcolor.TabIndex = 1
        Me.btnChangeOKcolor.Text = "Change OK color"
        Me.btnChangeOKcolor.UseVisualStyleBackColor = True
        '
        'btnCLOSEchange
        '
        Me.btnCLOSEchange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCLOSEchange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLOSEchange.Location = New System.Drawing.Point(3, 60)
        Me.btnCLOSEchange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCLOSEchange.Name = "btnCLOSEchange"
        Me.btnCLOSEchange.Size = New System.Drawing.Size(238, 54)
        Me.btnCLOSEchange.TabIndex = 1
        Me.btnCLOSEchange.Text = "Change CLOSE color"
        Me.btnCLOSEchange.UseVisualStyleBackColor = True
        '
        'btnBADchange
        '
        Me.btnBADchange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBADchange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBADchange.Location = New System.Drawing.Point(3, 118)
        Me.btnBADchange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBADchange.Name = "btnBADchange"
        Me.btnBADchange.Size = New System.Drawing.Size(238, 56)
        Me.btnBADchange.TabIndex = 1
        Me.btnBADchange.Text = "Change BAD color"
        Me.btnBADchange.UseVisualStyleBackColor = True
        '
        'lblRatioName
        '
        Me.lblRatioName.AutoSize = True
        Me.lblRatioName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatioName.Location = New System.Drawing.Point(357, 246)
        Me.lblRatioName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRatioName.Name = "lblRatioName"
        Me.lblRatioName.Size = New System.Drawing.Size(170, 25)
        Me.lblRatioName.TabIndex = 8
        Me.lblRatioName.Text = "Ideal Ratio Value: "
        Me.lblRatioName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(16, 351)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(3, 101)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.Location = New System.Drawing.Point(1080, 351)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(3, 101)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Black
        Me.PictureBox3.Location = New System.Drawing.Point(551, 350)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(3, 101)
        Me.PictureBox3.TabIndex = 11
        Me.PictureBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 410)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 25)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "0%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(301, 405)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 25)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "25%"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Black
        Me.PictureBox4.Location = New System.Drawing.Point(290, 350)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(3, 80)
        Me.PictureBox4.TabIndex = 14
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Black
        Me.PictureBox5.Location = New System.Drawing.Point(807, 351)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(3, 80)
        Me.PictureBox5.TabIndex = 15
        Me.PictureBox5.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(571, 410)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 25)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "50%"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(818, 410)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 25)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "75%"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1016, 410)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 25)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "100%"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RatioValueSelectionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 444)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblRatioName)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbOKvalue)
        Me.Controls.Add(Me.pbRatioDisplay)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(1115, 491)
        Me.MinimumSize = New System.Drawing.Size(1115, 491)
        Me.Name = "RatioValueSelectionDialog"
        Me.Text = "RatioValueSelectionDialog"
        CType(Me.pbRatioDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbOKvalue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbOKwidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCloseWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbRatioDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents tbOKvalue As System.Windows.Forms.TrackBar
    Friend WithEvents tbOKwidth As System.Windows.Forms.TrackBar
    Friend WithEvents tbCloseWidth As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOkRangeValue As System.Windows.Forms.Label
    Friend WithEvents lblCloseRangeValue As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBADcolor As System.Windows.Forms.Label
    Friend WithEvents lblCLOSEcolor As System.Windows.Forms.Label
    Friend WithEvents lblOKcolor As System.Windows.Forms.Label
    Friend WithEvents btnChangeOKcolor As System.Windows.Forms.Button
    Friend WithEvents btnCLOSEchange As System.Windows.Forms.Button
    Friend WithEvents btnBADchange As System.Windows.Forms.Button
    Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents lblCloseRangeName As System.Windows.Forms.Label
    Friend WithEvents lblOKrangeName As System.Windows.Forms.Label
    Friend WithEvents lblRatioName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
