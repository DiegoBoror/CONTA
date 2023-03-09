Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class Form1

    Private conexion As New MySqlConnection("server=localhost;database=CONTA;user=root;password=Guatemala502")

    Dim Sentencia, mensaje As String

    Private Sub EjecutarMySql(ByVal sql As String, ByVal msg As String)
        Try
            Dim cmd As New MySqlCommand(sql, conexion)
            conexion.Open()
            cmd.ExecuteNonQuery()
            conexion.Close()
            MsgBox(msg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        conexion.Open()
        Dim query = "DROP TABLE DATOS"
        Dim comando = New MySqlCommand(query, conexion)
        Dim reader = comando.ExecuteReader()
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Sentencia = "CREATE TABLE DATOS(
id_datos int not null,
datos varchar(25)
);"

        EjecutarMySql(Sentencia, mensaje)
        Try
            Dim da As New MySqlDataAdapter("select * from DATOS", conexion)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.Datos.DataSource = ds.Tables(0)
        Catch ex As Exception
        End Try
        frm_datos.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim da As New MySqlDataAdapter("select * from DATOS", conexion)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.Datos.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
