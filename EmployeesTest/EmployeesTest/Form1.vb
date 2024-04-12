Imports Npgsql

Public Class Form1
    Private currentPage As Integer = 1
    Private pageSize As Integer = 10 ' Number of rows per page
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
        employeesDVG.Sort(employeesDVG.Columns("emp_id"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Public Sub LoadData()
        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                ' Calculate the offset based on the current page and page size
                Dim offset As Integer = (currentPage - 1) * pageSize

                ' Construct the SQL query with pagination
                Dim sql As String = $"SELECT * FROM public.employees ORDER BY emp_id LIMIT {pageSize} OFFSET {offset}"

                Using cmd As New NpgsqlCommand(sql, connection)
                    Using adapter As New NpgsqlDataAdapter(cmd)
                        Dim dataSet As New DataSet()

                        adapter.Fill(dataSet)

                        employeesDVG.DataSource = dataSet.Tables(0)
                    End Using
                End Using
            End Using

            ' Sort the DataGridView by emp_id in ascending order
            employeesDVG.Sort(employeesDVG.Columns("emp_id"), System.ComponentModel.ListSortDirection.Ascending)

            ' Update the page number label
            pagenumTB.Text = $"{currentPage}"
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
        Dim selectedDepartment As String = departmentCB.SelectedItem?.ToString()
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

    Private Sub ViewEditDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewEditDetailsToolStripMenuItem.Click
        If employeesDVG.SelectedRows.Count > 0 OrElse (employeesDVG.SelectedCells.Count > 0 AndAlso employeesDVG.Columns(employeesDVG.SelectedCells(0).ColumnIndex).Name = "emp_id") Then
            ' Get the selected row or the row containing the selected cell
            Dim selectedRow As DataGridViewRow = If(employeesDVG.SelectedRows.Count > 0, employeesDVG.SelectedRows(0), employeesDVG.SelectedCells(0).OwningRow)

            Dim emp_id As Integer = Convert.ToInt32(selectedRow.Cells("emp_id").Value.ToString())
            Dim firstName As String = selectedRow.Cells("firstname").Value.ToString()
            Dim lastName As String = selectedRow.Cells("lastname").Value.ToString()
            Dim middleName As String = selectedRow.Cells("middlename").Value.ToString()
            Dim age As Integer = Convert.ToInt32(selectedRow.Cells("age").Value.ToString())
            Dim dateofbirth As Date = Convert.ToDateTime(selectedRow.Cells("dateofbirth").Value)
            Dim gender As String = selectedRow.Cells("gender").Value.ToString()
            Dim department As String = selectedRow.Cells("department").Value.ToString()
            Dim position As String = selectedRow.Cells("position").Value.ToString()
            Dim hired_date As Date = Convert.ToDateTime(selectedRow.Cells("hired_date").Value)
            Dim emp_status As String = selectedRow.Cells("emp_status").Value.ToString()

            Dim form2Open As Boolean = False
            For Each form As Form In Application.OpenForms
                If TypeOf form Is Form2 Then
                    Dim form2 As Form2 = CType(form, Form2)
                    form2.DisplayEmployeeDetails(emp_id, lastName, firstName, middleName, age, dateofbirth, gender, department, position, hired_date, emp_status)
                    form2Open = True
                    form2.BringToFront()
                    Exit For
                End If
            Next

            If Not form2Open Then
                Dim form2 As New Form2(Me)
                form2.DisplayEmployeeDetails(emp_id, lastName, firstName, middleName, age, dateofbirth, gender, department, position, hired_date, emp_status)
                form2.Show()
            End If
        Else
            MessageBox.Show("Please select a row in the DataGridView.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            ' Check if a row or cell is selected
            If employeesDVG.SelectedCells.Count > 0 OrElse employeesDVG.SelectedRows.Count > 0 Then
                Dim rowIndex As Integer
                Dim empID As Integer

                ' Check if a cell is selected
                If employeesDVG.SelectedCells.Count > 0 Then
                    ' Get the row index and the value of emp_id from the selected cell
                    rowIndex = employeesDVG.SelectedCells(0).RowIndex
                    empID = Convert.ToInt32(employeesDVG.Rows(rowIndex).Cells("emp_id").Value)
                Else
                    ' Get the row index and the value of emp_id from the selected row
                    rowIndex = employeesDVG.SelectedRows(0).Index
                    empID = Convert.ToInt32(employeesDVG.Rows(rowIndex).Cells("emp_id").Value)
                End If

                ' Ask for confirmation before deleting
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' Delete the record from the database
                    Using connection As New NpgsqlConnection(connectionString)
                        connection.Open()

                        Dim sql As String = "DELETE FROM public.employees WHERE emp_id = @EmpID"

                        Using cmd As New NpgsqlCommand(sql, connection)
                            cmd.Parameters.AddWithValue("@EmpID", empID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    ' Refresh the DataGridView
                    LoadData()
                End If
            Else
                MessageBox.Show("Please select a row or a cell in the 'emp_id' column to delete the record.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub addTS_Click(sender As Object, e As EventArgs) Handles addTS.Click
        Dim form3 As New Form3(Me)
        form3.Show()
    End Sub
    Private Sub prevBTN_Click(sender As Object, e As EventArgs) Handles prevBTN.Click
        ' Move to the previous page if not already on the first page
        If currentPage > 1 Then
            currentPage -= 1
            LoadData()
        End If
    End Sub

    Private Sub nxtBTN_Click(sender As Object, e As EventArgs) Handles nxtBTN.Click
        ' Move to the next page if not already on the last page
        If Not IsLastPage() Then
            currentPage += 1
            LoadData()
        End If
    End Sub

    Private Sub firstpageBTN_Click(sender As Object, e As EventArgs) Handles firstpageBTN.Click
        ' Go to the first page
        currentPage = 1
        LoadData()
    End Sub

    Private Sub lastpageBTN_Click(sender As Object, e As EventArgs) Handles lastpageBTN.Click
        ' Go to the last page
        currentPage = GetLastPage()
        LoadData()
    End Sub

    Private Function IsLastPage() As Boolean
        ' Check if the current page is the last page
        Return currentPage = GetLastPage()
    End Function

    Private Function GetLastPage() As Integer
        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()

                ' Get the total number of rows
                Dim totalRows As Integer
                Dim sqlCount As String = "SELECT COUNT(*) FROM public.employees"

                Using cmd As New NpgsqlCommand(sqlCount, connection)
                    totalRows = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Calculate the last page based on the total number of rows and page size
                Return Math.Ceiling(totalRows / pageSize)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting total number of pages: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1 ' Default to first page
        End Try
    End Function

    Private Sub pagenumTB_KeyDown(sender As Object, e As KeyEventArgs) Handles pagenumTB.KeyDown
        ' Check if the Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            JumpToPage()
        End If
    End Sub

    Private Sub pagenumTB_Leave(sender As Object, e As EventArgs) Handles pagenumTB.Leave
        ' Trigger page jump when leaving the textbox
        JumpToPage()
    End Sub

    Private Sub JumpToPage()
        ' Try to parse the page number from the TextBox
        If Integer.TryParse(pagenumTB.Text, currentPage) Then
            ' Ensure the page number is within the valid range
            If currentPage < 1 Then
                currentPage = 1
            ElseIf currentPage > GetLastPage() Then
                currentPage = GetLastPage()
            End If

            ' Load data for the specified page
            LoadData()
        Else
            ' Reset TextBox value if invalid page number is entered
            pagenumTB.Text = currentPage.ToString()
        End If
    End Sub

End Class