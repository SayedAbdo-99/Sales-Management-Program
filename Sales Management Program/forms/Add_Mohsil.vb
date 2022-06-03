Imports System.IO
Imports System.Data.SqlClient

Public Class Add_Mohsil
    Private Sub Add_Customer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.txtMhslID.Text = Max_ID("Mohslin", "Mhsl_ID") + 1
        txtMhslName.Focus()

    End Sub

    Public Sub ClearControls()
        Me.txtMhslID.Text = Max_ID("Mohslin", "Mhsl_ID") + 1
        Me.txtMhslName.Text = vbNullString
        Me.txtMhslPhone.Text = vbNullString
        Me.txtMohslNote.Text = vbNullString

    End Sub
    Public Sub Insert_Mohsil(ByVal mName As String, ByVal mPhone As String, ByVal mNote As String)
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into Mohslin  ([Name],[Phone],[Note])values(@Name,@Phone,@Note)"
            .Parameters.Clear()
            .Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = mName
            .Parameters.AddWithValue("@Phone", SqlDbType.NChar).Value = mPhone
            .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = mNote
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم إضافة بيانات المحصل بنجاح", MsgBoxStyle.Information, "حفظ")
        Cmd = Nothing
    End Sub




    Private Sub BtnNew_Click_1(sender As Object, e As EventArgs) Handles BtnNew.Click
        Try
            If txtMhslID.Text = vbNullString Or txtMhslName.Text = vbNullString Or txtMhslPhone.Text = vbNullString Then
                MessageBox.Show("عفواً ، قم بتعبئة كل اول 5 حقول", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If

            Insert_Mohsil(txtMhslName.Text, txtMhslPhone.Text, txtMohslNote.Text)
            ClearControls()
        Catch ex As Exception

            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class