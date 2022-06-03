Imports System.Data.SqlClient

Public Class Add_Thsil

    Public Sub Insert_Thsil_Proc(ByVal total As Decimal, ByVal pro_date As Date, ByVal Mosl_ID As Integer, ByVal Note As String)
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into Thsil ([Total],[Date],[Mhsl_ID],[Note])values(@Total,@Date,@Mhsl_ID,@Note)"
            .Parameters.Clear()
            .Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = total
            .Parameters.AddWithValue("@Date", SqlDbType.Date).Value = pro_date
            .Parameters.AddWithValue("@Mhsl_ID", SqlDbType.Int).Value = Mosl_ID
            .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = Note
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم إضافة عملية التحصيل بنجاح", MsgBoxStyle.Information, "حفظ")
        Cmd = Nothing
    End Sub

    Public Sub Load_Mohslin()
        ComboBox_Mohasl_Name.Items.Clear()
        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Name from Mohslin", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox_Mohasl_Name.Items.Add(dr("Name").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Public Function GetMohsl_ID(ByVal Mohasl As String)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Max(Mhsl_ID) From  Mohslin  where Name=@Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Mohasl
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Number = cmd.ExecuteScalar
            Con.Close()
        Catch ex As Exception
            Number = 0
            Con.Close()
        End Try
        Return Number

    End Function
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Try
            If txtThslID.Text = vbNullString Or Not IsNumeric(txtThslTotal.Text) Or Not IsDate(txtThslDate.Value) Then
                MessageBox.Show("عفواً ، قم بتعبئة كل الحقول مع مراعة القيم العددية ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If
            Dim mohaslID As Integer
            If ComboBox_Mohasl_Name.Text <> vbNullString Then
                mohaslID = GetMohsl_ID(ComboBox_Mohasl_Name.Text)
            Else
                mohaslID = vbNull
            End If


            Insert_Thsil_Proc(CDec(txtThslTotal.Text), txtThslDate.Value, mohaslID, txtThslNote.Text)

            Update_Mohsil_Bounas(ComboBox_Mohasl_Name.Text, CDec(txtThslTotal.Text))


            ClearControls()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Update_Mohsil_Bounas(ByVal MohslName As String, ByVal Total_Thsil As Decimal)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Mohslin]
                                SET  [Modin] = [Modin] - @Total
                                WHERE [Name] = @Name "
                .Parameters.Clear()
                .Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = MohslName
                .Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = Total_Thsil
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("حدث خطأ فى عمليه اضافة البونس للمحصل ... يجب عليك اضافتها يدوياً .", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End Try
    End Sub

    Private Sub Add_Thsil_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_Mohslin()

        ClearControls()
        txtThslTotal.Focus()
    End Sub
    Public Sub ClearControls()
        Me.txtThslID.Text = Max_ID("Thsil", "Th_ID") + 1
        Me.txtThslTotal.Text = 0.0
        Me.txtThslDate.Value = Today
        Me.ComboBox_Mohasl_Name.Text = vbNullString
        Me.txtThslNote.Text = vbNullString

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

End Class