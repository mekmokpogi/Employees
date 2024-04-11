Imports Npgsql
Public Class Form2
    Private connectionString As String = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=postgres"
    ' Method to display employee details

    Public Sub DisplayEmployeeDetails(emp_id As Integer, lastName As String, firstName As String, middleName As String, age As Integer, dateofbirth As Date, gender As String, department As String, position As String, hired_date As Date, emp_status As String)
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
    End Sub
End Class
