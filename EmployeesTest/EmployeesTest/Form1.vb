Imports Npgsql
Public Class Form1
    Public Sub ConnectToDatabase()
        Dim connectionString As String = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=postgres"
        Dim query As String = "SELECT * FROM public.employees"

        Using conn As New NpgsqlConnection(connectionString)
            Try
                conn.Open()
                MessageBox.Show("Connected")

                Dim dataAdapter As New NpgsqlDataAdapter(query, conn)
                Dim dataTable As New DataTable()
                dataAdapter.Fill(dataTable)

                DataGridView1.DataSource = dataTable
            Catch ex As Exception
                MessageBox.Show("Not Connected")
            End Try
        End Using
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeesToolStripMenuItem.Click
        ConnectToDatabase()
    End Sub
End Class
