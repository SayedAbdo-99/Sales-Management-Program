Imports System.Data.SqlClient
Public Class Restor
    Private Sub Btnsave_Click(sender As Object, e As EventArgs) Handles Btnsave.Click
        Try
            Dim strQuery As String
            strQuery = "ALTER Database SMSDB SET OFFLINE WITH ROLLBACK IMMEDIATE; Restore Database SMSDB From Disk='" & txtPath.Text + "'"
            Dim Cmd As New SqlCommand
            Cmd = New SqlCommand(strQuery, Con)
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح", "استعادة النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            If Con.State = 1 Then Con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class