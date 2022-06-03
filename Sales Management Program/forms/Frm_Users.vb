Imports System.IO
Imports System.Data.SqlClient

Public Class Frm_Users


    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Delete_User(DGV_Mand)
        End If
        Load_users()

    End Sub
    Public Sub Delete_User(ByVal DGV_Imp As DataGridView)
        Try

            Dim Position As Integer = DGV_Imp.CurrentRow.Index
            Dim ID_Position As Integer = DGV_Imp.Rows(Position).Cells(0).Value
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Delete  From [dbo].[Users] Where ID = @ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID_Position
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم حذف عملية التحصيل بنجاح.", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing

        Catch ex As Exception
            MsgBox("عفواً لا يمكن حذف هذا المستخدم نظراً لانه توجد عمليات اخرى متعلقه بها يجب حذفها اولاً", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "خطأ نوع الخطأ")
            If Con.State = 1 Then Con.Close()
        End Try
    End Sub

    Public Sub Load_users()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("SELECT *  FROM [dbo].[Users]", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("ID").ToString, dr("UserName").ToString, dr("Password").ToString, dr("Type").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Add_User.ShowDialog()
        Load_users()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    Private Sub Edit_Mand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_users()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If DGV_Mand.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim Position As Integer = DGV_Mand.CurrentRow.Index
        If Position >= 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات المستخدم المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Update_user(Position)
            End If
            MsgBox("تم تعديل البيانات المحددة بنجاح", MsgBoxStyle.Information, "تعديل")
            Load_users()
        Else
            MessageBox.Show("يجب تحديد الصف المراد تعديله")
            Exit Sub
        End If

    End Sub
    Public Sub Update_user(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Users]   SET [UserName] = @UserName,[Password] = @Password, [Type] = @Type WHERE ID=@ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@ID", SqlDbType.Int).Value = CInt(DGV_Mand.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = DGV_Mand.Rows(pos).Cells(1).Value.ToString
                .Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = DGV_Mand.Rows(pos).Cells(2).Value.ToString
                .Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = DGV_Mand.Rows(pos).Cells(3).Value.ToString

            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("خطأ فى البيانات المراد تعديلها", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DGV_Mand.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim count As Integer = DGV_Mand.Rows.Count
        If count > 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع المستخدمين؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                For i = 0 To count - 1
                    Update_user(i)
                Next
            End If
            MsgBox("تم تعديل البيانات بنجاح", MsgBoxStyle.Information, "تعديل")
            Load_users()
        Else
            MessageBox.Show("لا توجد بيانات لتعديلها")
        End If
    End Sub
End Class