Imports System.Data.SqlClient

Public Class Add_Twrid


    Public Sub Load_Mandobin()
        ComboBox_Mand_Name.Items.Clear()

        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Mand_Name from Mandobin", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox_Mand_Name.Items.Add(dr("Mand_Name").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Cop_Total()

        If IsNumeric(txtTwCash.Text) And IsNumeric(txtTwQst.Text) And IsNumeric(txtTwLated.Text) And IsNumeric(txtTwOutgoings.Text) Then
            txtTwTotalRest.Text = (CDec(txtTwCash.Text) + CDec(txtTwQst.Text)) - (CDec(txtTwLated.Text) + CDec(txtTwOutgoings.Text))
        End If
    End Sub


    Private Sub Edit_Cat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_Mandobin()


        ClearControls()
        txtTwCash.Focus()
    End Sub
    Public Sub ClearControls()
        Me.txtTwID.Text = Max_ID("Twrid", "Tw_ID") + 1
        Me.txtTwCash.Text = 0.0
        Me.txtTwQst.Text = 0.0
        Me.txtTwOutgoings.Text = 0.0
        Me.txtTwLated.Text = 0.0
        Me.txtTwTotalRest.Text = 0.0
        Me.txtTwDate.Value = Today
        Me.ComboBox_Mand_Name.Text = vbNullString
        Me.txtTwNote.Text = vbNullString

    End Sub


    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtTwCash_TextChanged(sender As Object, e As EventArgs) Handles txtTwCash.TextChanged
        Cop_Total()
    End Sub

    Private Sub txtTwQst_TextChanged(sender As Object, e As EventArgs) Handles txtTwQst.TextChanged
        Cop_Total()
    End Sub

    Private Sub txtTwOutgoings_TextChanged(sender As Object, e As EventArgs) Handles txtTwOutgoings.TextChanged
        Cop_Total()
    End Sub

    Private Sub txtTwLated_TextChanged(sender As Object, e As EventArgs) Handles txtTwLated.TextChanged
        Cop_Total()
    End Sub
    Public Sub Insert_Tawrid_Proc(ByVal cash As Decimal, ByVal qst As Decimal, ByVal Lated As Decimal, ByVal out As Decimal, ByVal total As Decimal, ByVal pro_date As Date, ByVal Mamd_ID As Integer, ByVal Note As String)
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into Twrid ([Cash],[Qst],[Outgoings],[Lateds],[TotalRest],[Date],[Mand_ID],[Note])values(@Cash,@Qst,@Outgoings,@Lateds,@TotalRest,@Date,@Mand_ID,@Note)"
            .Parameters.Clear()
            .Parameters.AddWithValue("@Cash", SqlDbType.Decimal).Value = cash
            .Parameters.AddWithValue("@Qst", SqlDbType.Decimal).Value = qst
            .Parameters.AddWithValue("@Outgoings", SqlDbType.Decimal).Value = out
            .Parameters.AddWithValue("@Lateds", SqlDbType.Decimal).Value = Lated
            .Parameters.AddWithValue("@TotalRest", SqlDbType.Decimal).Value = total
            .Parameters.AddWithValue("@Date", SqlDbType.Date).Value = pro_date
            .Parameters.AddWithValue("@Mand_ID", SqlDbType.Int).Value = Mamd_ID
            .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = Note
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم إضافة عملية التوريد بنجاح", MsgBoxStyle.Information, "حفظ")
        Cmd = Nothing
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Try
            If Not IsNumeric(txtTwID.Text) Or Not IsNumeric(txtTwCash.Text) Or Not IsNumeric(txtTwQst.Text) Or Not IsNumeric(txtTwOutgoings.Text) Or Not IsNumeric(txtTwLated.Text) Or Not IsNumeric(txtTwTotalRest.Text) Or Not IsDate(txtTwDate.Value) Then
                MessageBox.Show("عفواً ، قم بتعبئة كل الحقول مع مراعة القيم العددية ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If

            Dim mandlID As Integer
            If ComboBox_Mand_Name.Text <> vbNullString Then
                mandlID = Load_Toktok.GetPrd_ID(ComboBox_Mand_Name.Text)
            Else
                mandlID = vbNull
            End If
            Insert_Tawrid_Proc(CDec(txtTwCash.Text), CDec(txtTwQst.Text), CDec(txtTwLated.Text), CDec(txtTwOutgoings.Text), CDec(txtTwTotalRest.Text), txtTwDate.Value, mandlID, txtTwNote.Text)
            ClearControls()
        Catch ex As Exception

            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class