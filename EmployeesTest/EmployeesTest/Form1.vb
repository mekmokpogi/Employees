Imports Npgsql

Public Class Form1
    Private connectionString As String = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=postgres"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Dim sql As String = "SELECT * FROM public.employees WHERE 1=1"
        If Not String.IsNullOrEmpty(lastName) Then
            sql &= " AND lastname ILIKE @LastName"
        End If
        If Not String.IsNullOrEmpty(firstName) Then
            sql &= " AND firstname ILIKE @FirstName"
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
End Class
