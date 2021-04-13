Imports System.Configuration
Imports System.Data
Imports System.Data.SqlDbType
Imports System.Configuration.ConfigurationErrorsException
Imports System.Data.SqlClient

Public Class Form1

    'Below is where I initialize the finding of the customer list'
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustomerDataGridView.DataSource = findcustomerlist()

    End Sub

    Private Function findcustomerlist() As DataTable
        'Defines the datatablecustomerlist as a datatable data type'
        Dim datatablecustomerlist As New DataTable
        'Below is where I define the connection to the database, this line of code causes a problem and I am not sure how to fix
        Dim connstring As String = ConfigurationManager.ConnectionStrings("custpull").ConnectionString

        'connection to db'
        Using conn As New SqlConnection(connstring)

            Using cmd As New SqlCommand("SELECT * FROM dbo.customers", conn)

                ' open the connection'
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                datatablecustomerlist.Load(reader)
            End Using
        End Using
        'Return the database list to the DGV'
        Return datatablecustomerlist
    End Function

End Class
