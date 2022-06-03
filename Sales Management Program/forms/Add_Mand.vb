Imports System.IO
Imports System.Data.SqlClient

Public Class Add_Mand

    Public Sub Insert_Mandob(ByVal mandName As String, ByVal mandPhone As String, ByVal mandSalary As Decimal, ByVal mandBonas As Decimal)
        Try


            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Insert Into Mandobin ( Mand_Name,Phone,Salary,Bonas)values(@Mand_Name,@Phone,@Salary,@Bonas)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Mand_Name", SqlDbType.NVarChar).Value = mandName
                .Parameters.AddWithValue("@Phone", SqlDbType.NChar).Value = mandPhone
                .Parameters.AddWithValue("@Salary", SqlDbType.Decimal).Value = mandSalary
                .Parameters.AddWithValue("@Bonas", SqlDbType.Decimal).Value = mandBonas
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم إضافة بيانات المندوب بنجاح", MsgBoxStyle.Information, "حفظ")
            Cmd = Nothing
        Catch ex As Exception

            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        If txtMandID.Text = vbNullString Or txtMandName.Text = vbNullString Or txtMandPhone.Text = vbNullString Or Not IsNumeric(txtMandSalary.Text) Or Not IsNumeric(txtMandBonas.Text) Then
            MessageBox.Show("عفواً ، قم بتعبئة كل الحقول", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If

        Insert_Mandob(txtMandName.Text, txtMandPhone.Text, CDec(txtMandSalary.Text), CDec(txtMandBonas.Text))
        ClearControls()
    End Sub
    Public Sub ClearControls()
        Me.txtMandID.Text = Max_ID("Mandobin", "Mand_ID") + 1
        Me.txtMandName.Text = vbNullString
        Me.txtMandPhone.Text = vbNullString
        Me.txtMandSalary.Text = 400.0
        Me.txtMandBonas.Text = 0.0
    End Sub

    Private Sub Add_Importer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearControls()
        txtMandName.Focus()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class