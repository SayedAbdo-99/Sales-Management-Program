Imports System.IO
Imports System.Data.SqlClient


Public Class Edit_Connection
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Btnsave_Click(sender As Object, e As EventArgs) Handles Btnsave.Click
        If Not txt_New_Database.Text = vbNullString And Not txt_New_Ser.Text = vbNullString Then
            EditFile()
            Dim data = GetconectionData()
            txt_Def_Ser.Text = data.D_source
            txt_Def_Database.Text = data.D_Basc
        Else
            MsgBox("يجب ادخال بيانات التوصيل الجديدة")
        End If
    End Sub

    Public Sub EditFile()
        Dim FILE_NAME As String = My.Application.Info.DirectoryPath & "\Conection.txt"
        Dim i As Integer
        Dim aryText(4) As String

        aryText(0) = txt_New_Ser.Text
        aryText(1) = txt_New_Database.Text
        System.IO.File.Delete(FILE_NAME)
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)

        For i = 0 To 4
            objWriter.WriteLine(aryText(i))

        Next

        objWriter.Close()
    End Sub

    Private Sub Edit_Connection_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Public Function GetconectionData() As (D_source As String, D_Basc As String)
        Dim fileReader(2) As String
        fileReader = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\Conection.txt")

        Dim DataSource As String
        DataSource = fileReader(0)

        Dim DataBase As String
        DataBase = fileReader(1)


        Return (DataSource, DataBase)
    End Function
End Class