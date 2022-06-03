Imports System.Data.SqlClient
Public Class BackUP
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            txtPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Btnsave_Click(sender As Object, e As EventArgs) Handles Btnsave.Click
        Try
            Dim fileName As String

            fileName = txtPath.Text & "\\SMSDB" + DateTime.Now.ToShortDateString().Replace("/", "-") _
                            & " - " + DateTime.Now.ToLongTimeString().Replace(":", "-")
            Dim strQuery As String
            strQuery = "Backup Database SMSDB to Disk='" + fileName + ".bak'"
            Dim Cmd As New SqlCommand
            Cmd = New SqlCommand(strQuery, Con)
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MessageBox.Show("تم إنشاء النسخة الاحتياطية بنجاح", "إنشاء النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            If Con.State = 1 Then Con.Close()
        End Try
    End Sub
End Class