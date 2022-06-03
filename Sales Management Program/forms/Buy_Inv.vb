Imports System.Data.SqlClient
Imports MSwordDllFiles

Public Class Buy_Inv
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        AddProduct()
        InvoiceTotal()
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
    Public Sub InvoiceTotal()
        Dim Products_Name As String = ""
        Dim Total_Buy As Decimal = "0.00"
        Dim Total_Sell As Decimal = "0.00"
        Dim Total_Bonas As Decimal = "0.00"

        If ComboBox_sellType.Text = "" Then
            MsgBox("يجب اختبار نوع البيع ", vbCritical, "خطأ")
            ComboBox_sellType.Focus()
            Exit Sub
        End If

        For Each row As DataGridViewRow In dgv_buy.Rows
            Products_Name &= row.Cells(2).Value & " ( " & row.Cells(3).Value & " ) " & " + "
            Total_Buy += (CInt(row.Cells(3).Value) * CDec(row.Cells(4).Value))
            Total_Bonas += CDec(row.Cells(3).Value) * CDec(row.Cells(8).Value)

            If ComboBox_sellType.Text = "كاش" Then
                Total_Sell += CDec(row.Cells(5).Value) * CInt(row.Cells(3).Value)
            ElseIf ComboBox_sellType.Text = "قسط" Then
                Total_Sell += CDec(row.Cells(6).Value) * CInt(row.Cells(3).Value)
            ElseIf ComboBox_sellType.Text = "قسط 5 شهور" Then
                Total_Sell += CDec(row.Cells(7).Value) * CInt(row.Cells(3).Value)
            Else
                MsgBox("خطا فى نوع البيع ", vbCritical, "خطأ")
                ComboBox_sellType.Focus()
                Exit Sub
            End If

        Next
        If Products_Name.Length > 0 Then
            AllProducts.Text = Products_Name.Remove(Products_Name.Length - 3)
        End If
        SellPrice.Text = Total_Sell
        TotalBuy.Text = Total_Buy
        TotalBonas.Text = Total_Bonas
    End Sub
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
    Public Sub reset()
        dgv_buy.Rows.Clear()
        Me.cust_Name.Text = vbNullString
        Me.cust_Phone.Text = vbNullString
        Me.cust_City.Text = vbNullString
        Me.cust_Area.Text = vbNullString
        Me.DateBuy.Value = Today
        Me.DateFristQst.Value = DateAdd("m", 1, Today)
        Me.Qst_Number.Text = 1
        Me.SellPrice.Text = 0
        Me.TotalRest.Text = 0
        Me.Paid.Text = 0
        Me.AllProducts.Text = vbNullString
        Me.TotalBuy.Text = 0
        Me.TotalBonas.Text = 0
        Item_Count.Text = 0
        'Get_Tax()
        'Id.Text = Max_ID("Buy_Tbl", "Buy_ID") + 1
    End Sub
    Public Sub Print()

        Try
            '--------------------------------------------------------------
            ' مهم جداً أن تستدعي هذا الأمر قبل كتابة أي سطر برمجي يخص الطباعة
            MSO.SetDllFiles()
            '--------------------------------------------------------------
            Dim MyWord As MSO.MSWord
            MyWord = New MSO.MSWord(Me)

            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Buy_Inv.dotx"

            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " فاتورة مشتريات"
                .PrintJob = GetPrintableJob()
                With .ViewOptions
                    '-------------------------------------
                    .ShowBookmarks = False
                    .ShowTableGridlines = False
                    .ArabicNumeral = MSO.Enums.MSArabicNumeral.NumeralContext
                    .DisplayPageBoundaries = True
                    .NormalViewDisplayRulers = True
                    .ViewType = MSO.Enums.MSViewType.PrintPreview
                    .WindowState = MSO.Enums.MSWindowState.Maximize
                    .NormalViewZoomPageFit = MSO.Enums.MSPageFit.PageFitBestFit
                    .NormalViewZoomPercentage = Nothing
                    '------------------------
                    .PrintPreviewDisplayRulers = True
                    .PrintPreviewPageFitness = New MSO.PrintPreviewPageFitness(0, 0)
                    .PrintPreviewZoomPageFit = MSO.Enums.MSPageFit.PageFitBestFit
                    .PrintPreviewZoomPercentage = Nothing
                    '-------------------------------------
                End With
            End With
            MyWord.AddNewTemplateInfo(TemplateInfo)
            '---------------------------------------
            'MyWord.PrintOut()
            MyWord.PrintPreview()
        Catch ex As Exception
            MSO.PrintingProcess.ShowErrorMsgAndClose(ex.Message)
        End Try
    End Sub

    Public Sub Insert_Buy_Tbl(ByVal cust_Name As String, ByVal cust_Phone As String, ByVal cust_City As String, ByVal cust_Area As String, ByVal cust_Products As String, ByVal cust_State As String, ByVal cust_Mandob_Name As String, ByVal cust_NumberQst As Integer, ByVal cust_DateBuy As Date, ByVal Cust_DateFirstQst As Date, ByVal cust_BuyPrice As Decimal, ByVal cust_SellPrice As Decimal, ByVal Cust_Paid As Decimal, ByVal cust_Rest As Decimal, ByVal cust_Qst_value As Decimal, ByVal Mohsil_ID As Integer, ByVal Toktok_ID As Integer)
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "INSERT INTO Customers([cust_Name],[Phone],[City],[Area] ,[Products],[State] ,[mnd_Name],[NumQst],[NumQstFinal]
                                    ,[DateBuy],[DateFirstQst],[BuyPrice],[SellPrice] ,[Profit] ,[Paid]  ,[Rest] ,[Qst]   ,[TotalQst] ,[TotalRest],[Mohsil_ID],[Toktok_ID])
                            VALUES
                            (@cust_Name,@Phone,@City,@Area,@Products,@State,@mnd_Name,@NumQst, @NumQstFinal
	                        ,@DateBuy,@DateFirstQst,@BuyPrice,@SellPrice,@Profit,@Paid,@Rest,@Qst,@TotalQst,@TotalRest,@Mohsil_ID,@Toktok_ID)"
            .Parameters.Clear()
            .Parameters.AddWithValue("@cust_Name", SqlDbType.NVarChar).Value = cust_Name
            .Parameters.AddWithValue("@Phone", SqlDbType.NChar).Value = cust_Phone
            .Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = cust_City
            .Parameters.AddWithValue("@Area", SqlDbType.NVarChar).Value = cust_Area
            .Parameters.AddWithValue("@Products", SqlDbType.NVarChar).Value = cust_Products
            .Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = cust_State
            .Parameters.AddWithValue("@mnd_Name", SqlDbType.NVarChar).Value = cust_Mandob_Name

            .Parameters.AddWithValue("@NumQst", SqlDbType.Int).Value = cust_NumberQst
            .Parameters.AddWithValue("@NumQstFinal", SqlDbType.Int).Value = cust_NumberQst
            .Parameters.AddWithValue("@DateBuy", SqlDbType.Date).Value = cust_DateBuy
            .Parameters.AddWithValue("@DateFirstQst", SqlDbType.Date).Value = Cust_DateFirstQst

            .Parameters.AddWithValue("@BuyPrice", SqlDbType.Decimal).Value = cust_BuyPrice
            .Parameters.AddWithValue("@SellPrice", SqlDbType.Decimal).Value = cust_SellPrice
            .Parameters.AddWithValue("@Profit", SqlDbType.Decimal).Value = cust_SellPrice - cust_BuyPrice
            .Parameters.AddWithValue("@Paid", SqlDbType.Decimal).Value = Cust_Paid
            .Parameters.AddWithValue("@Rest", SqlDbType.Decimal).Value = cust_Rest
            .Parameters.AddWithValue("@Qst", SqlDbType.Decimal).Value = cust_Qst_value
            .Parameters.AddWithValue("@TotalQst", SqlDbType.Decimal).Value = 0.0
            .Parameters.AddWithValue("@TotalRest", SqlDbType.Decimal).Value = cust_Rest
            .Parameters.AddWithValue("@Mohsil_ID", SqlDbType.Int).Value = Mohsil_ID
            .Parameters.AddWithValue("@Toktok_ID", SqlDbType.Int).Value = Toktok_ID
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        Cmd = Nothing
    End Sub
    Private Function GetPrintableJob() As MSO.Printing.PrintJob

        Dim PrintJob As New MSO.Printing.PrintJob

        With PrintJob
            '####################################################################################
            .AddText(cust_Name.Text, "cust_Name")
            .AddText(cust_Phone.Text, "Phone")
            .AddText(cust_City.Text, "City")
            .AddText(cust_Area.Text, "Area")
            .AddText(AllProducts.Text, "AllProdects")
            .AddText(ComboBox_mand_Name.Text, "mnd_Name")
            .AddText(Qst_Number.Text, "NumQst")
            .AddText(DateBuy.Value.Date, "DateBuy")
            .AddText(DateFristQst.Value.Date, "DateFirstQst")
            .AddText(TotalBuy.Text, "BuyPrice")
            .AddText(SellPrice.Text, "SellPrice")
            .AddText(Paid.Text, "Paid")
            .AddText(TotalRest.Text, "Rest")

            'With .AddTable()
            '    '.DataTable = Get_All_Prd()
            '    '-------------------------------------
            '    '.MinimumRowsAtTheBeginningOfTable = 3
            '    .IsFirstColumnAutoNumber = False
            '    .TableHeadBookMarkName = "TableHead_1"
            '    .FirstRowBookMarkName = "TableFirstRow_1"
            '    .DeleteTableIfNoData = False
            '    '-------------------------------------
            '    For Each row As DataGridViewRow In dgv_buy.Rows
            '        .AddTextColumn("cust_Name")
            '        .AddTextColumn("Phone")
            '        .AddTextColumn("City")
            '        .AddTextColumn("Area")
            '        .AddTextColumn("Products")
            '        .AddTextColumn("mnd_Name")
            '        .AddTextColumn("NumQst")
            '        .AddTextColumn("DateBuy")
            '        .AddTextColumn("DateFirstQst")
            '        .AddTextColumn("BuyPrice")
            '        .AddTextColumn("SellPrice")
            '        .AddTextColumn("Paid")
            '        .AddTextColumn("Rest")
            '    Next

            'End With
        End With

        Return PrintJob
    End Function
    Public Function Get_All_Prd()
        Con.Open()
        Dim dt1 As New DataTable
        Dim cmd As New SqlCommand("Select * From Customers where cust_Name=@cust_Name", Con)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@cust_Name", SqlDbType.NVarChar).Value = cust_Name.Text
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1
    End Function
    Public Sub Update_Store_Qunt(ByVal ProductName As String, ByVal QuntValue As Integer, ByVal processType As Integer)
        Try
            Dim sign As String
            If processType = 1 Then
                sign = "-"
            ElseIf processType = 0 Then
                sign = "+"
            Else
                MsgBox("يجب تحديد نوع العملية", vbCritical, "خطأ")
                Exit Sub
            End If

            Dim Cmd2 As New SqlCommand
            With Cmd2
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Update Store Set Qunt = Qunt " & sign & CStr(QuntValue) & " Where Pro_Name = @Pro_Name"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Pro_Name", SqlDbType.NVarChar).Value = ProductName
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd2.ExecuteNonQuery()
            Con.Close()
            Cmd2 = Nothing
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Con.Close()
        End Try
    End Sub
    Public Function Last_ID(ByVal Prod_ID As Integer, ByVal Tok_Num As Integer)

        Dim Number As Integer
        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Max(Load_ID) From  Load  Where Prod_ID=@Value And Tokt_ID = @Tokt_ID And Type=1", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Value", SqlDbType.Int).Value = Prod_ID
            cmd.Parameters.AddWithValue("@Tokt_ID", SqlDbType.Int).Value = Tok_Num
            Number = cmd.ExecuteScalar
            Con.Close()
        Catch ex As Exception
            Number = 0
            'MsgBox("يوجد منتج لم يتم تحميله من قبل على التكتوك")
            'MsgBox(ex.Message.ToString)
            Con.Close()
        End Try
        Return Number
    End Function
    Public Sub Decrease_Toktok_Qunt(ByVal toKtokNumber As Integer, ByVal ProductID As Integer, ByVal QuntValue As Integer, ByVal Mand_ID As Integer, ByVal TotalBuy As Decimal, ByVal totalSell As Decimal)

        Dim load_ID As Integer
        load_ID = Last_ID(ProductID, toKtokNumber)
        If load_ID = 0 Then
            Load_Toktok.Insert_Load(toKtokNumber, ProductID, Mand_ID, Now, QuntValue * (-1), 1, TotalBuy, totalSell)
        Else
            Dim Cmd2 As New SqlCommand
            With Cmd2
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Update Load Set Qunt = Qunt - " & CStr(QuntValue) & " Where Prod_ID = @Prod_ID AND Tokt_ID = @Tokt_ID AND Load_ID=@Load_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Prod_ID", SqlDbType.Int).Value = ProductID
                .Parameters.AddWithValue("@Tokt_ID", SqlDbType.Int).Value = toKtokNumber
                .Parameters.AddWithValue("@Load_ID", SqlDbType.Int).Value = load_ID
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd2.ExecuteNonQuery()
            Con.Close()
            Cmd2 = Nothing
        End If

    End Sub
    Public Sub Add_Mandob_Bonas(ByVal MandName As String, ByVal BonasVal As Decimal)

        Dim Cmd2 As New SqlCommand
        With Cmd2
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Update Mandobin Set Bonas = Bonas + " & CStr(BonasVal) & " Where Mand_Name = @Mand_Name"
            .Parameters.Clear()
            .Parameters.AddWithValue("@Mand_Name", SqlDbType.NVarChar).Value = MandName
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd2.ExecuteNonQuery()
        Con.Close()
        Cmd2 = Nothing
    End Sub

    Private Sub dgv_buy_CellLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_buy.CellLeave

    End Sub
    Private Sub dgv_buy_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgv_buy.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{left}")
        End If
    End Sub
    Private Sub dgv_buy_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_buy.CellEndEdit
        SendKeys.Send("{left}")
        InvoiceTotal()
    End Sub
    Private Sub Buy_Inv_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Load_Products()
        Load_Mandobin()

        Load_Mohslin()

        DateBuy.Value = Today
        DateFristQst.Value = DateAdd("m", 1, Today)
        'Id.Text = Max_ID("Buy_Tbl", "Buy_ID") + 1
        cust_Name.Focus()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    Private Sub Paid_TextChanged(sender As System.Object, e As System.EventArgs) Handles Paid.TextChanged
        If IsNumeric(Paid.Text) Then
            TotalRest.Text = CDec(SellPrice.Text) - CDec(Paid.Text)
        End If

    End Sub

    Public Function GetMohsil_ID(ByVal Mohsil As String)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Mhsl_ID From  Mohslin  where Name=@Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Mohsil
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
    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        Try
            If cust_Name.Text = "" Or cust_Phone.Text = "" Or cust_City.Text = "" Or cust_City.Text = "" Then
                MsgBox("يجب ادخال جميع بيانات العميل اولاً ", vbCritical, "خطأ")
                Exit Sub
            End If
            If ComboBox_mand_Name.Text = "" Or ComboBox_Source.Text = "" Or ComboBox_Mohasl_Name.Text = "" Then
                MsgBox("يجب ادخال اسم المحصل واسم المندوب ومكان البيع ", vbCritical, "خطأ")
                ComboBox_Source.Focus()
                Exit Sub
            End If
            If ComboBox_Source.Text = "توكتوك" And ComboBox_Toktok_Number.Text = "" Then
                MsgBox("يجب ادخال رقم التوكتوك ", vbCritical, "خطأ")
                ComboBox_Toktok_Number.Focus()
                Exit Sub
            End If

            Dim finalNumberOfQst As Integer
            finalNumberOfQst = 1
            If ComboBox_sellType.Text = "قسط" And Qst_Number.Text = "" Then
                MsgBox("يجب ادخال عدد الاقساط ", vbCritical, "خطأ")
                Qst_Number.Focus()
                Exit Sub
            ElseIf ComboBox_sellType.Text = "قسط" And IsNumeric(Qst_Number.Text) Then
                finalNumberOfQst = CInt(Qst_Number.Text)

            ElseIf ComboBox_sellType.Text = "كاش" Then
                finalNumberOfQst = 1

            ElseIf ComboBox_sellType.Text = "قسط 5 شهور" Then
                finalNumberOfQst = 5
            End If

            If dgv_buy.RowCount = 0 Then
                MsgBox("يجب ادخال منتجات اولاً", vbCritical, "خطأ")
                Exit Sub
            End If

            TotalRest.Text = CDec(SellPrice.Text) - CDec(Paid.Text)

            Dim State As String
            If CDec(TotalRest.Text) > 0 Then
                State = "مستمر"
            Else
                State = "خالص"

            End If

            Dim qstValue As Decimal
            qstValue = CDec(TotalRest.Text) / finalNumberOfQst

            Dim Toktok_ID As Integer
            Toktok_ID = 0
            If ComboBox_Source.Text = "توكتوك" Then
                Toktok_ID = CInt(ComboBox_Toktok_Number.Text)
            End If


            Insert_Buy_Tbl(cust_Name.Text, cust_Phone.Text, cust_City.Text, cust_Area.Text, AllProducts.Text, State, ComboBox_mand_Name.Text, finalNumberOfQst, DateBuy.Value, DateFristQst.Value, TotalBuy.Text, SellPrice.Text, Paid.Text, TotalRest.Text, qstValue, GetMohsil_ID(ComboBox_Mohasl_Name.Text), Toktok_ID)

            For Each row As DataGridViewRow In dgv_buy.Rows
                If ComboBox_Source.Text = "مخزن" Then
                    Update_Store_Qunt(CStr(row.Cells(2).Value), CInt(row.Cells(3).Value), 1)
                ElseIf ComboBox_Source.Text = "توكتوك" Then
                    Decrease_Toktok_Qunt(CInt(ComboBox_Toktok_Number.Text), CInt(row.Cells(0).Value), CInt(row.Cells(3).Value), Load_Toktok.GetPrd_ID(ComboBox_mand_Name.Text), CDec(TotalBuy.Text), CDec(SellPrice.Text))
                End If
            Next

            Add_Mandob_Bonas(ComboBox_mand_Name.Text, CDec(TotalBonas.Text))

            MsgBox("تم الاضافة بنجاح ", vbInformation, "OK")
            reset()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        reset()
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Print()
    End Sub
    Private Sub BtnRemove_Click(sender As System.Object, e As System.EventArgs) Handles BtnRemove.Click
        If dgv_buy.SelectedRows.Count > 0 Then

            If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else

                dgv_buy.Rows.Remove(dgv_buy.SelectedRows(0))
                Item_Count.Text = dgv_buy.RowCount
                InvoiceTotal()
            End If
        Else
            MessageBox.Show("يجب ان تختار مادة لازالتها من الفاتورة")
        End If

    End Sub
    Private Sub dgv_buy_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_buy.CellValueChanged
        Item_Count.Text = dgv_buy.RowCount
    End Sub
    Private Sub ComboBox_Source_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_Source.TextChanged
        If ComboBox_Source.Text = "توكتوك" Then
            ComboBox_Toktok_Number.Visible = True
        Else
            ComboBox_Toktok_Number.Visible = False

        End If
    End Sub
    Private Sub ComboBox_sellType_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_sellType.TextChanged
        If ComboBox_sellType.Text = "قسط" Then
            Qst_Number.Visible = True
        Else
            Qst_Number.Visible = False
        End If
        InvoiceTotal()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

End Class