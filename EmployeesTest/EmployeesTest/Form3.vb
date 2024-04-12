Imports Npgsql

Public Class Form3
    Private connectionString As String = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=postgres"
    Private parentForm1 As Form1

    Public Sub New(ByRef form1 As Form1)
        InitializeComponent()
        parentForm1 = form1 ' Store reference to Form1
        LoadDepartments() ' Load departments when the form is created
    End Sub

    Private Sub LoadDepartments()
        Try
            departmentCB.Items.Clear() ' Clear existing items
            departmentCB.DropDownStyle = ComboBoxStyle.DropDown ' Allow user input

            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                Dim sql As String = "SELECT DISTINCT department FROM public.employees"

                Using cmd As New NpgsqlCommand(sql, connection)
                    Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            departmentCB.Items.Add(reader("department").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dateofbirthDTP_ValueChanged(sender As Object, e As EventArgs) Handles dateofbirthDTP.ValueChanged
        ' Calculate age based on the selected date of birth
        Dim age As Integer = DateTime.Now.Year - dateofbirthDTP.Value.Year
        If DateTime.Now < dateofbirthDTP.Value.AddYears(age) Then
            age -= 1
        End If
        ' Set the age text box
        ageTB.Text = age.ToString()
    End Sub

    Private Sub saveBTN_Click(sender As Object, e As EventArgs) Handles saveBTN.Click
        Try
            ' Calculate age based on the selected date of birth
            Dim age As Integer = DateTime.Now.Year - dateofbirthDTP.Value.Year
            If DateTime.Now < dateofbirthDTP.Value.AddYears(age) Then
                age -= 1
            End If

            ' Extract the first character from the selected gender
            Dim gender As String = genderCB.SelectedItem.ToString().Substring(0, 1).ToUpper()

            ' Insert the employee information into the database
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                Dim sql As String = "INSERT INTO public.employees (lastname, firstname, middlename, age, dateofbirth, gender, department, position, hired_date, emp_status) " &
                                    "VALUES (@LastName, @FirstName, @MiddleName, @Age, @DateOfBirth, @Gender, @Department, @Position, @HiredDate, @EmpStatus)"

                Using cmd As New NpgsqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@LastName", lastnameTB.Text)
                    cmd.Parameters.AddWithValue("@FirstName", firstnameTB.Text)
                    cmd.Parameters.AddWithValue("@MiddleName", middlenameTB.Text)
                    cmd.Parameters.AddWithValue("@Age", age) ' Use the calculated age
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateofbirthDTP.Value)
                    cmd.Parameters.AddWithValue("@Gender", gender) ' Use the extracted gender
                    cmd.Parameters.AddWithValue("@Department", departmentCB.Text) ' Use the selected department
                    cmd.Parameters.AddWithValue("@Position", positionTB.Text)
                    cmd.Parameters.AddWithValue("@HiredDate", hired_dateDTP.Value)
                    cmd.Parameters.AddWithValue("@EmpStatus", emp_statusCB.SelectedItem.ToString())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Notify the user that the insertion was successful
            MessageBox.Show("Employee information added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Close the Form3
            Me.Close()

            ' Refresh the table in Form1
            parentForm1.LoadData()
        Catch ex As Exception
            MessageBox.Show("Error adding employee information: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cancelBTN_Click(sender As Object, e As EventArgs) Handles cancelBTN.Click
        Me.Close()
    End Sub
End Class
