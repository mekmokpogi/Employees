Imports Npgsql
Public Class Form2
    Private connectionString As String = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=postgres"
    ' Method to display employee details
    Private emp_id As Integer
    Private lastName As String
    Private firstName As String
    Private middleName As String
    Private age As Integer
    Private dateofbirth As Date
    Private gender As String
    Private department As String
    Private position As String
    Private hired_date As Date
    Private emp_status As String

    Public Sub DisplayEmployeeDetails(emp_id As Integer, lastName As String, firstName As String, middleName As String, age As Integer, dateofbirth As Date, gender As String, department As String, position As String, hired_date As Date, emp_status As String)
        ' Set the data to the controls
        Me.emp_id = emp_id
        Me.lastName = lastName
        Me.firstName = firstName
        Me.middleName = middleName
        Me.age = age
        Me.dateofbirth = dateofbirth
        Me.gender = gender
        Me.department = department
        Me.position = position
        Me.hired_date = hired_date
        Me.emp_status = emp_status

        ' Set the data to the controls
        lastnameTB.Text = lastName
        firstnameTB.Text = firstName
        middlenameTB.Text = middleName
        ageTB.Text = age.ToString()
        dateofbirthTB.Text = dateofbirth.ToString("dd/MM/yyyy") ' Format the date as needed
        genderTB.Text = gender
        departmentTB.Text = department
        positionTB.Text = position
        hired_dateTB.Text = hired_date.ToString("dd/MM/yyyy") ' Format the date as needed

        ' Set the employment status combo box
        If Not String.IsNullOrEmpty(emp_status) Then
            emp_statusCB.Text = emp_status
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
        ' Call the method to update the database with the stored employee details
        UpdateEmployeeDetails()

    End Sub

    Private Sub saveBTN_Click(sender As Object, e As EventArgs) Handles saveBTN.Click
        ' Call the method to update the database with the stored employee details
        UpdateEmployeeDetails()
    End Sub

    Private Sub UpdateEmployeeDetails()
        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                Dim sql As String = "UPDATE public.employees SET lastname = @lastName, firstname = @firstName, middlename = @middleName, age = @age, dateofbirth = @dateofbirth, gender = @gender, department = @department, position = @position, hired_date = @hired_date, emp_status = @emp_status WHERE emp_id = @emp_id"

                Using cmd As New NpgsqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@emp_id", emp_id)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@middleName", middleName)
                    cmd.Parameters.AddWithValue("@age", age)
                    cmd.Parameters.AddWithValue("@dateofbirth", dateofbirth)
                    cmd.Parameters.AddWithValue("@gender", gender)
                    cmd.Parameters.AddWithValue("@department", department)
                    cmd.Parameters.AddWithValue("@position", position)
                    cmd.Parameters.AddWithValue("@hired_date", hired_date)
                    cmd.Parameters.AddWithValue("@emp_status", emp_status)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Employee details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error updating employee details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
