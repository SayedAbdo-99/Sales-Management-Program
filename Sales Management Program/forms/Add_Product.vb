Imports System.IO
Imports System.Data.SqlClient

Public Class Add_Product

    Private Sub Add_Product_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearControls()
        txtPrd_ID.Text = Max_ID("Store", "pro_Id") + 1
        txtPrd_Code.Focus()
    End Sub
    Public Sub ClearControls()
        Me.txtPrd_ID.Text = vbNullString
        Me.txtPrd_Code.Text = vbNullString
        Me.txtPrd_Name.Text = vbNullString
        Me.txtPrd_Qunt.Text = 1
        Me.txtPrd_BuyPrice.Text = 0.0
        Me.txtPrd_cashPrice.Text = 0.0
        Me.txtPrd_Profit.Text = 0.0
        Me.txtPrd_TotalBuy.Text = 0.0
        Me.txtPrd_QstSellPrice.Text = 0.0
        Me.txtPrd_QstSellPrice5.Text = 0.0
        Me.txtPrd_Bonas.Text = 0.0
    End Sub
    Public Sub Insert_Product_Tbl(ByVal Prd_code As Integer, ByVal Prd_Name As String, ByVal Prd_Qunt As Integer, ByVal Prd_BuyPrice As Decimal, ByVal Prd_cashPrice As Decimal, ByVal Prd_profit As Decimal, ByVal Prd_totalBuy As Decimal, ByVal Prd_QstPrice As Decimal, ByVal Prd_QstPrice5 As Decimal, ByVal Prd_Bonas As Decimal)
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into Store (Code,Pro_Name,Qunt,BuyPrice,CashPrice,Profit,TotalBuy,QstPrice,QstPrice5,Bonas)values(@Code,@Pro_Name,@Qunt,@BuyPrice,@CashPrice,@Profit,@TotalBuy,@QstPrice,@QstPrice5,@Bonas)"
            .Parameters.Clear()
            .Parameters.AddWithValue("@Code", SqlDbType.Int).Value = Prd_code
            .Parameters.AddWithValue("@Pro_Name", SqlDbType.NVarChar).Value = Prd_Name
            .Parameters.AddWithValue("@Qunt", SqlDbType.Int).Value = Prd_Qunt
            .Parameters.AddWithValue("@BuyPrice", SqlDbType.Decimal).Value = Prd_BuyPrice
            .Parameters.AddWithValue("@CashPrice", SqlDbType.Decimal).Value = Prd_cashPrice
            .Parameters.AddWithValue("@Profit", SqlDbType.Decimal).Value = Prd_profit
            .Parameters.AddWithValue("@TotalBuy", SqlDbType.Decimal).Value = Prd_totalBuy
            .Parameters.AddWithValue("@QstPrice", SqlDbType.Decimal).Value = Prd_QstPrice
            .Parameters.AddWithValue("@QstPrice5", SqlDbType.Decimal).Value = Prd_QstPrice5
            .Parameters.AddWithValue("@Bonas", SqlDbType.Decimal).Value = Prd_Bonas
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم إضافة بيانات المنتج بنجاح", MsgBoxStyle.Information, "حفظ")
        Cmd = Nothing
    End Sub

    Private Sub Btnsave_Click(sender As System.Object, e As System.EventArgs) Handles Btnsave.Click
        Try

            If txtPrd_ID.Text = vbNullString Or Not IsNumeric(txtPrd_Code.Text) Or txtPrd_Name.Text = vbNullString Or Not IsNumeric(txtPrd_Qunt.Text) Or Not IsNumeric(txtPrd_BuyPrice.Text) Or Not IsNumeric(txtPrd_cashPrice.Text) Or Not IsNumeric(txtPrd_Profit.Text) Or Not IsNumeric(txtPrd_TotalBuy.Text) Or Not IsNumeric(txtPrd_QstSellPrice.Text) Or Not IsNumeric(txtPrd_QstSellPrice5.Text) Or Not IsNumeric(txtPrd_Bonas.Text) Then
                MessageBox.Show("عفواً ، قم بتعبئة كل البينات مع مراعة البيانات الرقمية", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If



            Insert_Product_Tbl(CInt(txtPrd_Code.Text), txtPrd_Name.Text, CInt(txtPrd_Qunt.Text), CDec(txtPrd_BuyPrice.Text), CDec(txtPrd_cashPrice.Text), CDec(txtPrd_Profit.Text), CDec(txtPrd_TotalBuy.Text), CDec(txtPrd_QstSellPrice.Text), CDec(txtPrd_QstSellPrice5.Text), CDec(txtPrd_Bonas.Text))

            ClearControls()
            txtPrd_ID.Text = Max_ID("Store", "pro_Id") + 1
            txtPrd_Code.Focus()
        Catch ex As Exception

            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub txtPrd_BuyPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrd_BuyPrice.TextChanged
        If IsNumeric(txtPrd_Qunt.Text) And IsNumeric(txtPrd_BuyPrice.Text) Then
            txtPrd_TotalBuy.Text = CDec(txtPrd_BuyPrice.Text) * CInt(txtPrd_Qunt.Text)
        ElseIf IsNumeric(txtPrd_Qunt.Text) = False Then
            txtPrd_Qunt.Text = 1
        ElseIf IsNumeric(txtPrd_BuyPrice.Text) = False Then
            txtPrd_TotalBuy.Text = CDec(0.00)
        End If

    End Sub
    Private Sub txtPrd_sellPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrd_cashPrice.TextChanged
        If IsNumeric(txtPrd_BuyPrice.Text) And IsNumeric(txtPrd_cashPrice.Text) Then
            txtPrd_Profit.Text = CDec(txtPrd_cashPrice.Text) - CDec(txtPrd_BuyPrice.Text)
        ElseIf IsNumeric(txtPrd_BuyPrice.Text) = False Then
            MsgBox("يجب ان تكون قيمه سعر الشراء رقم ", MsgBoxStyle.Critical, "خطأ")
            txtPrd_BuyPrice.Focus()
        ElseIf IsNumeric(txtPrd_cashPrice.Text) = False Then
            txtPrd_Profit.Text = 0.00
        End If

    End Sub
    Private Sub txtPrd_QstSellPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrd_QstSellPrice.TextChanged
        If IsNumeric(txtPrd_cashPrice.Text) And IsNumeric(txtPrd_QstSellPrice.Text) Then
            txtPrd_QstSellPrice5.Text = CDec(txtPrd_cashPrice.Text) + ((CDec(txtPrd_QstSellPrice.Text) - CDec(txtPrd_cashPrice.Text)) / 2)
        ElseIf IsNumeric(txtPrd_cashPrice.Text) = False Then
            MsgBox("يجب ان تكون قيمه سعر البيع رقم ", MsgBoxStyle.Critical, "خطأ")
            txtPrd_cashPrice.Focus()
        ElseIf IsNumeric(txtPrd_QstSellPrice.Text) = False Then
            txtPrd_QstSellPrice5.Text = 0.00
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class