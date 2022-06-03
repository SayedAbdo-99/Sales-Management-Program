Imports System.Data.SqlClient

Public Class Load_Toktok
    Public Sub Load_Products()
        ComboBox_Products.Items.Clear()

        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Pro_Name from Store", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox_Products.Items.Add(dr("Pro_Name").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Load_Mandobin()
        ComboBox_mand_Name.Items.Clear()
        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Mand_Name from Mandobin", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox_mand_Name.Items.Add(dr("Mand_Name").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub AddProduct()
        If ComboBox_Products.Text = "" Then
            MsgBox("يجب اختيار السلعة ", vbCritical, "خطأ")
            Exit Sub
        End If

        For i As Integer = 0 To dgv_buy.Rows.Count - 1
            If dgv_buy.Rows(i).Cells(2).Value = ComboBox_Products.Text Then
                MsgBox(" المنتج المراد ادخاله تم اضافته للفاتورة مسبقا")
                Exit Sub
            End If
        Next

        Dim x As Integer
        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" select  *  from Store  where  Pro_Name=@Pro_Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Pro_Name", SqlDbType.NVarChar).Value = ComboBox_Products.Text
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    dgv_buy.Rows.Add()
                    x = dgv_buy.Rows.Count - 1
                    dgv_buy(0, x).Value = dr("pro_Id").ToString
                    dgv_buy(1, x).Value = dr("Code").ToString
                    dgv_buy(2, x).Value = dr("Pro_Name").ToString
                    dgv_buy(3, x).Value = 1
                    dgv_buy(4, x).Value = dr("BuyPrice").ToString
                    dgv_buy(5, x).Value = dr("CashPrice").ToString
                    dgv_buy(6, x).Value = dr("QstPrice").ToString
                    dgv_buy(7, x).Value = dr("QstPrice5").ToString
                    dgv_buy(8, x).Value = dr("Bonas").ToString

                End While
                dr.Close()
                Con.Close()
                ComboBox_Products.Text = ""
            Else
                MsgBox("رقم المنتج الذي قمت بادخاله غير موجود")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "خطا")
            Con.Close()
        End Try
    End Sub
    Private Sub Re_Load()
        txtLoad_ID.Text = Max_ID("Load", "Load_ID") + 1
        dgv_buy.Rows.Clear()

        Load_Products()
        Load_Mandobin()
        txtDate.Value = Today
        ComboBox_Products.Focus()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        AddProduct()
        InvoiceTotal()
    End Sub
    Public Sub InvoiceTotal()
        Dim Total_Buy As Decimal = "0.00"
        Dim Total_Sell As Decimal = "0.00"
        'Dim Total_Bonas As Decimal = "0.00"


        For Each row As DataGridViewRow In dgv_buy.Rows
            Total_Buy += (CDec(row.Cells(3).Value) * CInt(row.Cells(4).Value))
            'Total_Bonas += CDec(row.Cells(8).Value)
            Total_Sell += (CDec(row.Cells(5).Value) * CInt(row.Cells(3).Value))
        Next
        txtTotalBuy.Text = Total_Buy
        txtTotalSell.Text = Total_Sell
    End Sub
    Private Sub Re_Buy_Inv_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Re_Load()
    End Sub
    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    Public Function GetPrd_ID(ByVal MandName As String)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Max(Mand_ID) From  Mandobin  where Mand_Name=@Mand_Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Mand_Name", SqlDbType.NVarChar).Value = MandName
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
    Public Function Last_Load_ID(ByVal Tokt_ID As Integer, ByVal Prod_ID As Integer, ByVal Type As Integer)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Max(Load_ID) From  Load  where Tokt_ID=@Tokt_ID And Prod_ID=@Prod_ID AND Type=@Type", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Tokt_ID", SqlDbType.Int).Value = Tokt_ID
            cmd.Parameters.AddWithValue("@Prod_ID", SqlDbType.Int).Value = Prod_ID
            cmd.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = Type
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


    Public Sub Insert_Load(ByVal Tokt_ID As Integer, ByVal Prod_ID As Integer, ByVal Mand_ID As Integer, ByVal Load_Date As Date, ByVal Qunt As Integer, ByVal Type As Integer, ByVal TotalBuy As Decimal, ByVal TotalSell As Decimal)
        Dim Load_ID As Integer

        Load_ID = Last_Load_ID(Tokt_ID, Prod_ID, Type)

        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            If Load_ID = 0 Then

                .CommandText = "INSERT INTO Load([Tokt_ID] ,[Prod_ID],[Mand_ID],[Date],[Qunt],[Type],[TotalBuy],[TotalSell])
                            VALUES(@Tokt_ID,@Prod_ID,@Mand_ID,@Date,@Qunt,@Type,@TotalBuy,@TotalSell)"
                .Parameters.Clear()
            Else
                .CommandText = "UPDATE [dbo].[Load] SET 
                                                       [Mand_ID]=@Mand_ID,[Date]=@Date, [Qunt]=[Qunt] + @Qunt,[TotalBuy]=@TotalBuy,[TotalSell]=@TotalSell
                                where Load_ID=@Load_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Load_ID", SqlDbType.Int).Value = Load_ID
            End If
            .Parameters.AddWithValue("@Tokt_ID", SqlDbType.Int).Value = Tokt_ID
            .Parameters.AddWithValue("@Prod_ID", SqlDbType.Int).Value = Prod_ID
            .Parameters.AddWithValue("@Mand_ID", SqlDbType.Int).Value = Mand_ID
            .Parameters.AddWithValue("@Date", SqlDbType.Int).Value = Load_Date
            .Parameters.AddWithValue("@Qunt", SqlDbType.Int).Value = Qunt
            .Parameters.AddWithValue("@Type", SqlDbType.Decimal).Value = Type
            .Parameters.AddWithValue("@TotalBuy", SqlDbType.Decimal).Value = TotalBuy
            .Parameters.AddWithValue("@TotalSell", SqlDbType.Decimal).Value = TotalSell

        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        Cmd = Nothing

    End Sub
    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        Try


            If txtLoad_ID.Text = "" Or ComboBox_mand_Name.Text = "" Or ComboBox_Toktok_Number.Text = "" Or ComboBox_Type.Text = "" Then
                MsgBox("يجب ادخال جميع البيانات اولاً ", vbCritical, "خطأ")
                Exit Sub
            End If
            If dgv_buy.RowCount = 0 Then
                MsgBox("يجب ادخال منتجات اولاً", vbCritical, "خطأ")
                Exit Sub
            End If

            Dim TypeNumber As Integer
            TypeNumber = 1
            If ComboBox_Type.Text = "تحميل" Then
                TypeNumber = 1
                'MsgBox("يجب ادخال عدد الاقساط ", vbCritical, "خطأ")
                'Qst_Number.Focus()
                'Exit Sub
            ElseIf ComboBox_Type.Text = "استرجاع" Then
                TypeNumber = 0
            End If

            Dim Mandob_ID As Integer
            Mandob_ID = GetPrd_ID(ComboBox_mand_Name.Text)

            For Each row As DataGridViewRow In dgv_buy.Rows
                Insert_Load(CInt(ComboBox_Toktok_Number.Text), row.Cells(0).Value, Mandob_ID, txtDate.Value, row.Cells(3).Value, TypeNumber, CInt(row.Cells(3).Value) * CDec(row.Cells(4).Value), CInt(row.Cells(3).Value) * CDec(row.Cells(5).Value))
                Buy_Inv.Update_Store_Qunt(row.Cells(2).Value, CInt(row.Cells(3).Value), TypeNumber)
            Next

            MsgBox(" تم اضافة البيانات بنجاح", vbInformation, "OK")
            txtLoad_ID.Text = Max_ID("Load", "Load_ID") + 1
            dgv_buy.Rows.Clear()
            txtDate.Value = Today
            ComboBox_Products.Focus()
            txtTotalBuy.Text = 0.0
            txtTotalSell.Text = 0.0
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub


    Private Sub dgv_buy_CellEndEdit_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_buy.CellEndEdit
        SendKeys.Send("{left}")
        InvoiceTotal()
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If dgv_buy.SelectedRows.Count > 0 Then

            If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else

                dgv_buy.Rows.Remove(dgv_buy.SelectedRows(0))
                InvoiceTotal()
            End If
        Else
            MessageBox.Show("يجب ان تختار مادة لازالتها من الفاتورة")
        End If

    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        txtLoad_ID.Text = Max_ID("Load", "Load_ID") + 1
        dgv_buy.Rows.Clear()
        txtDate.Value = Today
        ComboBox_Products.Focus()
        txtTotalBuy.Text = 0.0
        txtTotalSell.Text = 0.0
    End Sub


    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class