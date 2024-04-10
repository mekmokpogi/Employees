Imports Npgsql

Public Class Form1
    Private connectionString As String = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=postgres"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
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
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                Dim sql As String = "SELECT * FROM public.employees"

                Using cmd As New NpgsqlCommand(sql, connection)
                    Using adapter As New NpgsqlDataAdapter(cmd)
                        Dim dataSet As New DataSet()

                        adapter.Fill(dataSet)

                        employeesDVG.DataSource = dataSet.Tables(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PerformSearch()
        Dim lastName As String = lastnameTB.Text.Trim()
        Dim firstName As String = firstnameTB.Text.Trim()
        Dim fromDate As DateTime = fromDTP.Value
        Dim toDate As DateTime = toDTP.Value
        Dim position As String = ""
        Dim department As String = departmentCB.SelectedItem?.ToString() ' Get the selected department

        ' Determine the selected position filter
        If deptheadRB.Checked Then
            position = "Department Head"
        ElseIf staffRB.Checked Then
            position = "Staff"
        ElseIf oicRB.Checked Then
            position = "Officer in Charge"
        End If

        ' Determine the selected employment status filter
        Dim employmentStatus As String = ""
        If regularRB.Checked Then
            employmentStatus = "Regular"
        ElseIf probationaryRB.Checked Then
            employmentStatus = "Probationary"
        End If

        ' Construct the SQL query with conditions based on the entered values and filters
        Dim sql As String = "SELECT * FROM public.employees WHERE 1=1"
        If Not String.IsNullOrEmpty(lastName) Then
            sql &= " AND lastname ILIKE @LastName"
        End If
        If Not String.IsNullOrEmpty(firstName) Then
            sql &= " AND firstname ILIKE @FirstName"
        End If
        If fromDate <= toDate Then
            sql &= " AND hired_date BETWEEN @FromDate AND @ToDate"
        End If
        If Not String.IsNullOrEmpty(position) Then
            sql &= " AND position ILIKE @Position"
        End If
        If Not String.IsNullOrEmpty(department) Then ' Check if department filter is selected
            sql &= " AND department ILIKE @Department"
        End If
        If Not String.IsNullOrEmpty(employmentStatus) Then
            sql &= " AND emp_status ILIKE @EmploymentStatus"
        End If

        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                Using cmd As New NpgsqlCommand(sql, connection)
                    If Not String.IsNullOrEmpty(lastName) Then
                        cmd.Parameters.AddWithValue("@LastName", "%" & lastName & "%")
                    End If
                    If Not String.IsNullOrEmpty(firstName) Then
                        cmd.Parameters.AddWithValue("@FirstName", "%" & firstName & "%")
                    End If
                    If fromDate <= toDate Then
                        cmd.Parameters.AddWithValue("@FromDate", fromDate)
                        cmd.Parameters.AddWithValue("@ToDate", toDate)
                    End If
                    If Not String.IsNullOrEmpty(position) Then
                        cmd.Parameters.AddWithValue("@Position", "%" & position & "%")
                    End If
                    If Not String.IsNullOrEmpty(department) Then
                        cmd.Parameters.AddWithValue("@Department", "%" & department & "%")
                    End If
                    If Not String.IsNullOrEmpty(employmentStatus) Then
                        cmd.Parameters.AddWithValue("@EmploymentStatus", "%" & employmentStatus & "%")
                    End If

                    Using adapter As New NpgsqlDataAdapter(cmd)
                        Dim dataSet As New DataSet()

                        adapter.Fill(dataSet)

                        employeesDVG.DataSource = dataSet.Tables(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lastnameTB_TextChanged(sender As Object, e As EventArgs) Handles lastnameTB.TextChanged
        PerformSearch()
    End Sub

    Private Sub firstnameTB_TextChanged(sender As Object, e As EventArgs) Handles firstnameTB.TextChanged
        PerformSearch()
    End Sub

    Private Sub fromDTP_ValueChanged(sender As Object, e As EventArgs) Handles fromDTP.ValueChanged
        PerformSearch()
    End Sub

    Private Sub toDTP_ValueChanged(sender As Object, e As EventArgs) Handles toDTP.ValueChanged
        PerformSearch()
    End Sub

    Private Sub deptheadRB_CheckedChanged(sender As Object, e As EventArgs) Handles deptheadRB.CheckedChanged
        PerformSearch()
    End Sub

    Private Sub staffRB_CheckedChanged(sender As Object, e As EventArgs) Handles staffRB.CheckedChanged
        PerformSearch()
    End Sub

    Private Sub oicRB_CheckedChanged(sender As Object, e As EventArgs) Handles oicRB.CheckedChanged
        PerformSearch()
    End Sub
    Private Sub departmentCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles departmentCB.SelectedIndexChanged
        ' Set the selected department from the combo box
        Dim selectedDepartment As String = departmentCB.SelectedItem?.ToString()

        ' Call the PerformSearch method to apply all filters
        PerformSearch()


    End Sub


    Private Sub regularRB_CheckedChanged(sender As Object, e As EventArgs) Handles regularRB.CheckedChanged
        PerformSearch()
    End Sub

    Private Sub probationaryRB_CheckedChanged(sender As Object, e As EventArgs) Handles probationaryRB.CheckedChanged
        PerformSearch()
    End Sub

    Private Sub allRB_CheckedChanged(sender As Object, e As EventArgs) Handles allRB.CheckedChanged
        PerformSearch()
    End Sub

    Private Sub allRB2_CheckedChanged(sender As Object, e As EventArgs) Handles allRB2.CheckedChanged
        PerformSearch()
    End Sub
End Class
