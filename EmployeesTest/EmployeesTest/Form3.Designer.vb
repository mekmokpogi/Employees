<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.hired_dateDTP = New System.Windows.Forms.DateTimePicker()
        Me.dateofbirthDTP = New System.Windows.Forms.DateTimePicker()
        Me.cancelBTN = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.saveBTN = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.emp_statusCB = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.positionTB = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.departmentTB = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ageTB = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.middlenameTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.firstnameTB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lastnameTB = New System.Windows.Forms.TextBox()
        Me.genderCB = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.hired_dateDTP)
        Me.GroupBox1.Controls.Add(Me.dateofbirthDTP)
        Me.GroupBox1.Controls.Add(Me.cancelBTN)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.saveBTN)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.positionTB)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.departmentTB)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ageTB)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.middlenameTB)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.firstnameTB)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lastnameTB)
        Me.GroupBox1.Controls.Add(Me.genderCB)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(888, 255)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee Information"
        '
        'hired_dateDTP
        '
        Me.hired_dateDTP.CustomFormat = "dd/mm/yyyy"
        Me.hired_dateDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.hired_dateDTP.Location = New System.Drawing.Point(724, 119)
        Me.hired_dateDTP.Name = "hired_dateDTP"
        Me.hired_dateDTP.Size = New System.Drawing.Size(144, 22)
        Me.hired_dateDTP.TabIndex = 22
        '
        'dateofbirthDTP
        '
        Me.dateofbirthDTP.CustomFormat = "dd/mm/yyyy"
        Me.dateofbirthDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateofbirthDTP.Location = New System.Drawing.Point(422, 37)
        Me.dateofbirthDTP.Name = "dateofbirthDTP"
        Me.dateofbirthDTP.Size = New System.Drawing.Size(144, 22)
        Me.dateofbirthDTP.TabIndex = 21
        '
        'cancelBTN
        '
        Me.cancelBTN.Location = New System.Drawing.Point(773, 199)
        Me.cancelBTN.Name = "cancelBTN"
        Me.cancelBTN.Size = New System.Drawing.Size(96, 37)
        Me.cancelBTN.TabIndex = 20
        Me.cancelBTN.Text = "Cancel"
        Me.cancelBTN.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(624, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Date Hired:"
        '
        'saveBTN
        '
        Me.saveBTN.Location = New System.Drawing.Point(671, 199)
        Me.saveBTN.Name = "saveBTN"
        Me.saveBTN.Size = New System.Drawing.Size(96, 37)
        Me.saveBTN.TabIndex = 19
        Me.saveBTN.Text = "Save"
        Me.saveBTN.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.emp_statusCB)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(158, 73)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Employment Status"
        '
        'emp_statusCB
        '
        Me.emp_statusCB.FormattingEnabled = True
        Me.emp_statusCB.Items.AddRange(New Object() {"probationary", "regular"})
        Me.emp_statusCB.Location = New System.Drawing.Point(16, 32)
        Me.emp_statusCB.Name = "emp_statusCB"
        Me.emp_statusCB.Size = New System.Drawing.Size(121, 24)
        Me.emp_statusCB.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(624, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Position"
        '
        'positionTB
        '
        Me.positionTB.Location = New System.Drawing.Point(724, 75)
        Me.positionTB.Name = "positionTB"
        Me.positionTB.Size = New System.Drawing.Size(145, 22)
        Me.positionTB.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(624, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 17)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Department:"
        '
        'departmentTB
        '
        Me.departmentTB.Location = New System.Drawing.Point(724, 37)
        Me.departmentTB.Name = "departmentTB"
        Me.departmentTB.Size = New System.Drawing.Size(145, 22)
        Me.departmentTB.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(324, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Date of Birth:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(324, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Gender:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Age:"
        '
        'ageTB
        '
        Me.ageTB.Enabled = False
        Me.ageTB.Location = New System.Drawing.Point(421, 75)
        Me.ageTB.Name = "ageTB"
        Me.ageTB.Size = New System.Drawing.Size(145, 22)
        Me.ageTB.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Middle Name:"
        '
        'middlenameTB
        '
        Me.middlenameTB.Location = New System.Drawing.Point(127, 117)
        Me.middlenameTB.Name = "middlenameTB"
        Me.middlenameTB.Size = New System.Drawing.Size(145, 22)
        Me.middlenameTB.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "First Name:"
        '
        'firstnameTB
        '
        Me.firstnameTB.Location = New System.Drawing.Point(127, 75)
        Me.firstnameTB.Name = "firstnameTB"
        Me.firstnameTB.Size = New System.Drawing.Size(145, 22)
        Me.firstnameTB.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Last Name:"
        '
        'lastnameTB
        '
        Me.lastnameTB.Location = New System.Drawing.Point(127, 37)
        Me.lastnameTB.Name = "lastnameTB"
        Me.lastnameTB.Size = New System.Drawing.Size(145, 22)
        Me.lastnameTB.TabIndex = 0
        '
        'genderCB
        '
        Me.genderCB.FormattingEnabled = True
        Me.genderCB.Items.AddRange(New Object() {"Male", "Female"})
        Me.genderCB.Location = New System.Drawing.Point(421, 119)
        Me.genderCB.Name = "genderCB"
        Me.genderCB.Size = New System.Drawing.Size(145, 24)
        Me.genderCB.TabIndex = 20
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 286)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form3"
        Me.Text = "Add"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dateofbirthDTP As DateTimePicker
    Friend WithEvents cancelBTN As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents saveBTN As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents emp_statusCB As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents positionTB As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents departmentTB As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ageTB As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents middlenameTB As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents firstnameTB As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lastnameTB As TextBox
    Friend WithEvents genderCB As ComboBox
    Friend WithEvents hired_dateDTP As DateTimePicker
End Class
