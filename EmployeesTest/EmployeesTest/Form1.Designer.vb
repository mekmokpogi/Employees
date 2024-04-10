<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.regularRB = New System.Windows.Forms.RadioButton()
        Me.probationaryRB = New System.Windows.Forms.RadioButton()
        Me.staffRB = New System.Windows.Forms.RadioButton()
        Me.oicRB = New System.Windows.Forms.RadioButton()
        Me.deptheadRB = New System.Windows.Forms.RadioButton()
        Me.departmentCB = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.toDTP = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fromDTP = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.firstnameTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lastnameTB = New System.Windows.Forms.TextBox()
        Me.employeesDVG = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.employeesDVG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'regularRB
        '
        Me.regularRB.AutoSize = True
        Me.regularRB.Location = New System.Drawing.Point(22, 23)
        Me.regularRB.Name = "regularRB"
        Me.regularRB.Size = New System.Drawing.Size(79, 21)
        Me.regularRB.TabIndex = 15
        Me.regularRB.TabStop = True
        Me.regularRB.Text = "Regular"
        Me.regularRB.UseVisualStyleBackColor = True
        '
        'probationaryRB
        '
        Me.probationaryRB.AutoSize = True
        Me.probationaryRB.Location = New System.Drawing.Point(22, 47)
        Me.probationaryRB.Name = "probationaryRB"
        Me.probationaryRB.Size = New System.Drawing.Size(110, 21)
        Me.probationaryRB.TabIndex = 14
        Me.probationaryRB.TabStop = True
        Me.probationaryRB.Text = "Probationary"
        Me.probationaryRB.UseVisualStyleBackColor = True
        '
        'staffRB
        '
        Me.staffRB.AutoSize = True
        Me.staffRB.Location = New System.Drawing.Point(7, 49)
        Me.staffRB.Name = "staffRB"
        Me.staffRB.Size = New System.Drawing.Size(58, 21)
        Me.staffRB.TabIndex = 13
        Me.staffRB.TabStop = True
        Me.staffRB.Text = "Staff"
        Me.staffRB.UseVisualStyleBackColor = True
        '
        'oicRB
        '
        Me.oicRB.AutoSize = True
        Me.oicRB.Location = New System.Drawing.Point(114, 22)
        Me.oicRB.Name = "oicRB"
        Me.oicRB.Size = New System.Drawing.Size(136, 21)
        Me.oicRB.TabIndex = 12
        Me.oicRB.TabStop = True
        Me.oicRB.Text = "Officer In Charge"
        Me.oicRB.UseVisualStyleBackColor = True
        '
        'deptheadRB
        '
        Me.deptheadRB.AutoSize = True
        Me.deptheadRB.Location = New System.Drawing.Point(7, 21)
        Me.deptheadRB.Name = "deptheadRB"
        Me.deptheadRB.Size = New System.Drawing.Size(101, 21)
        Me.deptheadRB.TabIndex = 11
        Me.deptheadRB.TabStop = True
        Me.deptheadRB.Text = "Dept. Head"
        Me.deptheadRB.UseVisualStyleBackColor = True
        '
        'departmentCB
        '
        Me.departmentCB.FormattingEnabled = True
        Me.departmentCB.Items.AddRange(New Object() {"IT", "Personnel Managemen", "Billing", "Marketing", "Accounting", "Finance"})
        Me.departmentCB.Location = New System.Drawing.Point(82, 47)
        Me.departmentCB.Name = "departmentCB"
        Me.departmentCB.Size = New System.Drawing.Size(163, 24)
        Me.departmentCB.TabIndex = 10
        Me.departmentCB.Text = "Department"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "To:"
        '
        'toDTP
        '
        Me.toDTP.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.toDTP.CustomFormat = "mm/dd/yyyy"
        Me.toDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.toDTP.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.toDTP.Location = New System.Drawing.Point(72, 49)
        Me.toDTP.Name = "toDTP"
        Me.toDTP.Size = New System.Drawing.Size(115, 22)
        Me.toDTP.TabIndex = 11
        Me.toDTP.Value = New Date(2024, 1, 1, 0, 0, 0, 0)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.regularRB)
        Me.GroupBox3.Controls.Add(Me.probationaryRB)
        Me.GroupBox3.Location = New System.Drawing.Point(507, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(155, 82)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Employment Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "From:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.staffRB)
        Me.GroupBox2.Controls.Add(Me.oicRB)
        Me.GroupBox2.Controls.Add(Me.deptheadRB)
        Me.GroupBox2.Controls.Add(Me.departmentCB)
        Me.GroupBox2.Location = New System.Drawing.Point(232, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(251, 82)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Position - Department"
        '
        'fromDTP
        '
        Me.fromDTP.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.fromDTP.CustomFormat = "mm/dd/yyyy"
        Me.fromDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fromDTP.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.fromDTP.Location = New System.Drawing.Point(72, 21)
        Me.fromDTP.Name = "fromDTP"
        Me.fromDTP.Size = New System.Drawing.Size(115, 22)
        Me.fromDTP.TabIndex = 0
        Me.fromDTP.Value = New Date(2024, 1, 1, 0, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.toDTP)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.fromDTP)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 82)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Hired"
        '
        'firstnameTB
        '
        Me.firstnameTB.Location = New System.Drawing.Point(98, 54)
        Me.firstnameTB.Name = "firstnameTB"
        Me.firstnameTB.Size = New System.Drawing.Size(185, 22)
        Me.firstnameTB.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "First Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Last Name:"
        '
        'lastnameTB
        '
        Me.lastnameTB.Location = New System.Drawing.Point(98, 17)
        Me.lastnameTB.Name = "lastnameTB"
        Me.lastnameTB.Size = New System.Drawing.Size(185, 22)
        Me.lastnameTB.TabIndex = 14
        '
        'employeesDVG
        '
        Me.employeesDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.employeesDVG.Location = New System.Drawing.Point(12, 227)
        Me.employeesDVG.Name = "employeesDVG"
        Me.employeesDVG.RowTemplate.Height = 24
        Me.employeesDVG.Size = New System.Drawing.Size(758, 294)
        Me.employeesDVG.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 105)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(679, 116)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filter:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 533)
        Me.Controls.Add(Me.firstnameTB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lastnameTB)
        Me.Controls.Add(Me.employeesDVG)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "Form1"
        Me.Text = "Home"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.employeesDVG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents regularRB As RadioButton
    Friend WithEvents probationaryRB As RadioButton
    Friend WithEvents staffRB As RadioButton
    Friend WithEvents oicRB As RadioButton
    Friend WithEvents deptheadRB As RadioButton
    Friend WithEvents departmentCB As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents toDTP As DateTimePicker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents fromDTP As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents firstnameTB As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lastnameTB As TextBox
    Friend WithEvents employeesDVG As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
End Class
