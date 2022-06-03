Imports System.Data.SqlClient

Public Class Add_Exp

    Private Sub Add_Cat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearControls()
        txtOutProson.Focus()
    End Sub
    Public Sub ClearControls()
        Me.txtOutID.Text = Max_ID("OutGoings", "Out_ID") + 1
        Me.txtOutProson.Text = vbNullString
        Me.txtOutPostion.Text = vbNullString
        Me.txtOutNote.Text = vbNullString
        Me.txtOutDate.Value = Today
        Me.txtOutValue.Text = 0.0
    End Sub
    Public Sub Insert_Outgoings(ByVal outPerson As String, ByVal outposition As String, ByVal outvalue As Decimal, ByVal outDate As Date, ByVal outNote As String)
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into OutGoings ([Person],[Posistion],[Value],[Date],[Note])values(@Person,@Posistion,@Value,@Date,@Note)"
            .Parameters.Clear()
            .Parameters.AddWithValue("@Person", SqlDbType.NVarChar).Value = outPerson
            .Parameters.AddWithValue("@Posistion", SqlDbType.NVarChar).Value = outposition
            .Parameters.AddWithValue("@Value", SqlDbType.Decimal).Value = outvalue
            .Parameters.AddWithValue("@Date", SqlDbType.Date).Value = outDate
            .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = outNote
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم إضافة عملية الصرف بنجاح", MsgBoxStyle.Information, "حفظ")
        Cmd = Nothing
    End Sub


    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Try
            If txtOutID.Text = vbNullString Or txtOutProson.Text = vbNullString Or txtOutPostion.Text = vbNullString Or Not IsNumeric(txtOutValue.Text) Or Not IsDate(txtOutDate.Value) Then
                MessageBox.Show("عفواً ، قم بتعبئة كل الحقول مع مراعة ان قيمة الصرف رقم ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If
            Insert_Outgoings(txtOutProson.Text, txtOutPostion.Text, CDec(txtOutValue.Text), txtOutDate.Value, txtOutNote.Text)
            ClearControls()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class