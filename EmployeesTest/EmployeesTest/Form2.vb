Imports Npgsql

Public Class Form2
    Private parentForm1 As Form1

    Private connectionString As String = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=postgres"

    Private employeeID As Integer
    Private originalLastName As String
    Private originalFirstName As String
    Private originalMiddleName As String
    Private originalAge As Integer
    Private originalDateOfBirth As Date
    Private originalGender As String
    Private originalDepartment As String
    Private originalPosition As String
    Private originalHiredDate As Date
    Private originalEmpStatus As String

    Public Sub New(parentForm As Form1)
        InitializeComponent()
        parentForm1 = parentForm
    End Sub

    Public Sub DisplayEmployeeDetails(emp_id As Integer, lastName As String, firstName As String, middleName As String, age As Integer, dateofbirth As Date, gender As String, department As String, position As String, hired_date As Date, emp_status As String)
        employeeID = emp_id
        originalEmpStatus = emp_status
        lastnameTB.Text = lastName
        firstnameTB.Text = firstName
        middlenameTB.Text = middleName
        ageTB.Text = age.ToString()
        dateofbirthTB.Text = dateofbirth.ToString("dd/MM/yyyy")
        genderTB.Text = gender
        departmentTB.Text = department
        positionTB.Text = position
        hired_dateTB.Text = hired_date.ToString("dd/MM/yyyy")

        originalLastName = lastName
        originalFirstName = firstName
        originalMiddleName = middleName
        originalAge = age
        originalDateOfBirth = dateofbirth
        originalGender = gender
        originalDepartment = department
        originalPosition = position
        originalHiredDate = hired_date
        If Not String.IsNullOrEmpty(originalEmpStatus) Then
            emp_statusCB.Text = originalEmpStatus
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                Dim sql As String = "SELECT DISTINCT emp_status FROM public.employees"

                Using cmd As New NpgsqlCommand(sql, connection)
                    Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            emp_statusCB.Items.Add(reader("emp_status").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading employment status options: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveBTN_Click(sender As Object, e As EventArgs) Handles saveBTN.Click
        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                Dim sql As String = "UPDATE public.employees SET emp_status = @EmpStatus WHERE emp_id = @EmployeeID"

                Using cmd As New NpgsqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@EmpStatus", emp_statusCB.Text)
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Employee information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Close Form2
            Me.Close()

            ' Refresh the table in Form1
            parentForm1.LoadData()
        Catch ex As Exception
            MessageBox.Show("Error updating employee information: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cancelBTN_Click(sender As Object, e As EventArgs) Handles cancelBTN.Click
        lastnameTB.Text = originalLastName
        firstnameTB.Text = originalFirstName
        middlenameTB.Text = originalMiddleName
        ageTB.Text = originalAge.ToString()
        dateofbirthTB.Text = originalDateOfBirth.ToString("dd/MM/yyyy")
        genderTB.Text = originalGender
        departmentTB.Text = originalDepartment
        positionTB.Text = originalPosition
        hired_dateTB.Text = originalHiredDate.ToString("dd/MM/yyyy")
        If Not String.IsNullOrEmpty(originalEmpStatus) Then
            emp_statusCB.Text = originalEmpStatus
        End If

        Me.Close()
    End Sub
End Class
