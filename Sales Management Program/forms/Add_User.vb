Imports System.Data.SqlClient

Public Class Add_User

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub



    Private Sub Edit_Unit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearControls()
    End Sub
    Public Sub ClearControls()
        Me.txtID.Text = Max_ID("Users", "ID") + 1
        Me.txtUserName.Text = vbNullString
        Me.txtPass.Text = vbNullString
        Me.ComboBox_Type.Text = vbNullString

    End Sub

    Private Sub Btnsave_Click(sender As Object, e As EventArgs) Handles Btnsave.Click
        Try
            If txtID.Text = vbNullString Or txtUserName.Text = vbNullString Or txtPass.Text = vbNullString Or ComboBox_Type.Text = vbNullString Then
                MessageBox.Show("عفواً ، قم بتعبئة كل الحقول ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If
            Insert_User(txtUserName.Text, txtPass.Text, ComboBox_Type.Text)
            ClearControls()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Insert_User(ByVal UserName As String, ByVal Pass As String, ByVal Type As String)
        Try

            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO [dbo].[Users]  ([UserName]  ,[Password] ,[Type]) VALUES(@UserName, @Password, @Type)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = UserName
                .Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Pass
                .Parameters.AddWithValue("@Type", SqlDbType.Decimal).Value = Type
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم إضافى المستخدم بنجاح", MsgBoxStyle.Information, "حفظ")
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("توجد مشكلة بالبيانات يجب اعادة العملية او اعادة تحميل البرنامج \n " & ex.Message.ToString, MsgBoxStyle.Critical, "خطأ")
            Con.Close()
        End Try
    End Sub
End Class