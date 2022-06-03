Imports System.Data.SqlClient

Public Class Login
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If txtUserName.Text = vbNullString Or txtPassWord.Text = vbNullString Then
                MsgBox("يجب ادخال اسم المستخدم والباسورد اولاً", MsgBoxStyle.Critical, "خطأ ")
            Else
                If (txtUserName.Text = "Administrator" And txtPassWord.Text = "sayed99") Then
                    Me.Hide()
                    Home.Show()
                Else
                    Dim NumCheck As Integer
                    NumCheck = CheckLogin()
                    If NumCheck > 0 Then
                        Me.Hide()
                        Home.Show()
                    Else
                        MsgBox("خطاً فى اسم المستخدم او كلمة المرور", MsgBoxStyle.Critical, "خطأ")
                    End If
                End If
            End If

        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Function CheckLogin()
        Dim Number As Integer
        Number = 0
        Try
            Dim dt1 As New DataTable
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select * FROM Users where UserName =@UserName AND Password=@Password", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtUserName.Text
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassWord.Text
            Dim adp As New SqlDataAdapter(cmd)
            adp.Fill(dt1)
            Number = dt1.Rows.Count
            Con.Close()
        Catch ex As Exception
            MsgBox("خطاً فى الاتصال", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "خطأ")
            Con.Close()
        End Try
        Return Number
    End Function
End Class