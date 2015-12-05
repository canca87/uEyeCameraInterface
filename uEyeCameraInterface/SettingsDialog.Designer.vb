<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblBcolor = New System.Windows.Forms.Label()
        Me.lblAcolor = New System.Windows.Forms.Label()
        Me.lblAxisColor = New System.Windows.Forms.Label()
        Me.btnSetAxisColor = New System.Windows.Forms.Button()
        Me.btnSetAcolor = New System.Windows.Forms.Button()
        Me.btnSetBcolor = New System.Windows.Forms.Button()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFilterStrengthName = New System.Windows.Forms.Label()
        Me.lblAxisSizeName = New System.Windows.Forms.Label()
        Me.lblRatioColoringName = New System.Windows.Forms.Label()
        Me.nudFilterWidth = New System.Windows.Forms.NumericUpDown()
        Me.nudAxisSize = New System.Windows.Forms.NumericUpDown()
        Me.cbRatioColoring = New System.Windows.Forms.CheckBox()
        Me.btnSetRatioValues = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.nudFilterWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAxisSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.20513!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.79487!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblBcolor, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcolor, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAxisColor, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSetAxisColor, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSetAcolor, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSetBcolor, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 14)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(312, 176)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblBcolor
        '
        Me.lblBcolor.AutoSize = True
        Me.lblBcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBcolor.Location = New System.Drawing.Point(255, 126)
        Me.lblBcolor.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.lblBcolor.Name = "lblBcolor"
        Me.lblBcolor.Size = New System.Drawing.Size(46, 40)
        Me.lblBcolor.TabIndex = 5
        '
        'lblAcolor
        '
        Me.lblAcolor.AutoSize = True
        Me.lblAcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAcolor.Location = New System.Drawing.Point(255, 68)
        Me.lblAcolor.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.lblAcolor.Name = "lblAcolor"
        Me.lblAcolor.Size = New System.Drawing.Size(46, 38)
        Me.lblAcolor.TabIndex = 4
        '
        'lblAxisColor
        '
        Me.lblAxisColor.AutoSize = True
        Me.lblAxisColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAxisColor.Location = New System.Drawing.Point(255, 10)
        Me.lblAxisColor.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.lblAxisColor.Name = "lblAxisColor"
        Me.lblAxisColor.Size = New System.Drawing.Size(46, 38)
        Me.lblAxisColor.TabIndex = 3
        '
        'btnSetAxisColor
        '
        Me.btnSetAxisColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSetAxisColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetAxisColor.Location = New System.Drawing.Point(3, 2)
        Me.btnSetAxisColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetAxisColor.Name = "btnSetAxisColor"
        Me.btnSetAxisColor.Size = New System.Drawing.Size(238, 54)
        Me.btnSetAxisColor.TabIndex = 1
        Me.btnSetAxisColor.Text = "Change axis color"
        Me.btnSetAxisColor.UseVisualStyleBackColor = True
        '
        'btnSetAcolor
        '
        Me.btnSetAcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSetAcolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetAcolor.Location = New System.Drawing.Point(3, 60)
        Me.btnSetAcolor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetAcolor.Name = "btnSetAcolor"
        Me.btnSetAcolor.Size = New System.Drawing.Size(238, 54)
        Me.btnSetAcolor.TabIndex = 1
        Me.btnSetAcolor.Text = "Change color A"
        Me.btnSetAcolor.UseVisualStyleBackColor = True
        '
        'btnSetBcolor
        '
        Me.btnSetBcolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSetBcolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetBcolor.Location = New System.Drawing.Point(3, 118)
        Me.btnSetBcolor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetBcolor.Name = "btnSetBcolor"
        Me.btnSetBcolor.Size = New System.Drawing.Size(238, 56)
        Me.btnSetBcolor.TabIndex = 1
        Me.btnSetBcolor.Text = "Change color B"
        Me.btnSetBcolor.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.70086!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.29914!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblFilterStrengthName, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblAxisSizeName, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblRatioColoringName, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.nudFilterWidth, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.nudAxisSize, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbRatioColoring, 1, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(15, 194)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(312, 176)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'lblFilterStrengthName
        '
        Me.lblFilterStrengthName.AutoSize = True
        Me.lblFilterStrengthName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFilterStrengthName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilterStrengthName.Location = New System.Drawing.Point(4, 0)
        Me.lblFilterStrengthName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilterStrengthName.Name = "lblFilterStrengthName"
        Me.lblFilterStrengthName.Size = New System.Drawing.Size(162, 58)
        Me.lblFilterStrengthName.TabIndex = 0
        Me.lblFilterStrengthName.Text = "Filter Width:"
        Me.lblFilterStrengthName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAxisSizeName
        '
        Me.lblAxisSizeName.AutoSize = True
        Me.lblAxisSizeName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAxisSizeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAxisSizeName.Location = New System.Drawing.Point(4, 58)
        Me.lblAxisSizeName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAxisSizeName.Name = "lblAxisSizeName"
        Me.lblAxisSizeName.Size = New System.Drawing.Size(162, 58)
        Me.lblAxisSizeName.TabIndex = 1
        Me.lblAxisSizeName.Text = "Axis Size (%):"
        Me.lblAxisSizeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRatioColoringName
        '
        Me.lblRatioColoringName.AutoSize = True
        Me.lblRatioColoringName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRatioColoringName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatioColoringName.Location = New System.Drawing.Point(4, 116)
        Me.lblRatioColoringName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRatioColoringName.Name = "lblRatioColoringName"
        Me.lblRatioColoringName.Size = New System.Drawing.Size(162, 60)
        Me.lblRatioColoringName.TabIndex = 2
        Me.lblRatioColoringName.Text = "Ratio Coloring?"
        Me.lblRatioColoringName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudFilterWidth
        '
        Me.nudFilterWidth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudFilterWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudFilterWidth.Location = New System.Drawing.Point(174, 12)
        Me.nudFilterWidth.Margin = New System.Windows.Forms.Padding(4, 12, 4, 4)
        Me.nudFilterWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFilterWidth.Name = "nudFilterWidth"
        Me.nudFilterWidth.Size = New System.Drawing.Size(134, 30)
        Me.nudFilterWidth.TabIndex = 3
        Me.nudFilterWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudAxisSize
        '
        Me.nudAxisSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudAxisSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudAxisSize.Location = New System.Drawing.Point(174, 70)
        Me.nudAxisSize.Margin = New System.Windows.Forms.Padding(4, 12, 4, 4)
        Me.nudAxisSize.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.nudAxisSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAxisSize.Name = "nudAxisSize"
        Me.nudAxisSize.Size = New System.Drawing.Size(134, 30)
        Me.nudAxisSize.TabIndex = 3
        Me.nudAxisSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cbRatioColoring
        '
        Me.cbRatioColoring.AutoSize = True
        Me.cbRatioColoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbRatioColoring.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRatioColoring.Location = New System.Drawing.Point(174, 120)
        Me.cbRatioColoring.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbRatioColoring.Name = "cbRatioColoring"
        Me.cbRatioColoring.Size = New System.Drawing.Size(134, 52)
        Me.cbRatioColoring.TabIndex = 4
        Me.cbRatioColoring.UseVisualStyleBackColor = True
        '
        'btnSetRatioValues
        '
        Me.btnSetRatioValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetRatioValues.Location = New System.Drawing.Point(15, 375)
        Me.btnSetRatioValues.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetRatioValues.Name = "btnSetRatioValues"
        Me.btnSetRatioValues.Size = New System.Drawing.Size(309, 55)
        Me.btnSetRatioValues.TabIndex = 1
        Me.btnSetRatioValues.Text = "Set Ratio Values"
        Me.btnSetRatioValues.UseVisualStyleBackColor = True
        '
        'SettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 431)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnSetRatioValues)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximumSize = New System.Drawing.Size(362, 478)
        Me.MinimumSize = New System.Drawing.Size(362, 478)
        Me.Name = "SettingsDialog"
        Me.Text = "Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.nudFilterWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAxisSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBcolor As System.Windows.Forms.Label
    Friend WithEvents lblAcolor As System.Windows.Forms.Label
    Friend WithEvents lblAxisColor As System.Windows.Forms.Label
    Friend WithEvents btnSetAxisColor As System.Windows.Forms.Button
    Friend WithEvents btnSetAcolor As System.Windows.Forms.Button
    Friend WithEvents btnSetBcolor As System.Windows.Forms.Button
    Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFilterStrengthName As System.Windows.Forms.Label
    Friend WithEvents lblAxisSizeName As System.Windows.Forms.Label
    Friend WithEvents lblRatioColoringName As System.Windows.Forms.Label
    Friend WithEvents nudFilterWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAxisSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbRatioColoring As System.Windows.Forms.CheckBox
    Friend WithEvents btnSetRatioValues As System.Windows.Forms.Button
End Class
