Imports System.Data.SqlClient
Imports System.IO
Imports MSwordDllFiles

Public Class Frm_Customer

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        Buy_Inv.ShowDialog()
        LoadCustomers()
    End Sub

    Public Sub LoadCustomers()
        Try
            DGV_Cus.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" Select [cust_Id] ,[cust_Name],[Phone],[City] ,[Area] ,[Products],[State],[mnd_Name],[NumQst],[NumQstFinal],[DateBuy],[DateFirstQst]
                                              ,[BuyPrice],[SellPrice],[Paid],[Rest] ,[Qst],[TotalQst],[TotalRest]
                                               from Customers", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Cus.Rows.Add(dr("cust_Id").ToString, dr("cust_Name").ToString, dr("Phone").ToString, dr("City").ToString, dr("Area").ToString, dr("Products").ToString, dr("State").ToString, dr("mnd_Name").ToString, dr("NumQst").ToString, dr("NumQstFinal").ToString, FormatDateTime(dr("DateBuy"), DateFormat.ShortDate), FormatDateTime(dr("DateFirstQst"), DateFormat.ShortDate),
                                 dr("BuyPrice").ToString, dr("SellPrice").ToString, dr("Paid").ToString, dr("Rest").ToString, dr("Qst").ToString, dr("TotalQst").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
        End Try

    End Sub

    Private Sub Frm_Customers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCustomers()
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        Try
            If DGV_Cus.Rows.Count < 1 Then
                Exit Sub
            End If
            Dim Position As Integer = DGV_Cus.CurrentRow.Index
            If Position >= 0 Then
                If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات العميل المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    Update_cust(Position)
                End If

                LoadCustomers()
            Else
                MessageBox.Show("يجب تحديد الصف المراد تعديله")
                Exit Sub
            End If
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If DGV_Cus.Rows.Count < 1 Then
                Exit Sub
            End If
            Dim count As Integer = DGV_Cus.Rows.Count
            If count > 0 Then
                If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع العملاء؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    For i = 0 To count - 1
                        Update_cust(i)
                    Next
                End If
                MsgBox("تم تعديل بيانات جميع العملاء بنجاح", MsgBoxStyle.Information, "تعديل")
                LoadCustomers()
            Else
                MessageBox.Show("يجب تحديد الصف المراد تعديله")
            End If
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Function ConvertStrToDate(ByVal strValue As String)
        Dim DateValue As String
        DateValue = strValue.Split("/")(2) & "-" & strValue.Split("/")(1) & "-" & strValue.Split("/")(0)
        Return DateValue
    End Function

    Public Sub Update_cust(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Update Customers SET 
                                            [cust_Name] = @cust_Name, [Phone] = @Phone, [City] = @City, [Area] = @Area, [Products] = @Products,
                                            [State] = @State,[mnd_Name] =@mnd_Name,[NumQst] = @NumQst, [NumQstFinal] = @NumQstFinal, [DateBuy] = @DateBuy,
	                                        [DateFirstQst] =@DateFirstQst , [BuyPrice] = @BuyPrice, [SellPrice] = @SellPrice, [Profit] = @Profit, [Paid] = @Paid, 
	                                        [Rest] = @Rest, [Qst] = @Qst, [TotalQst] = @TotalQst, [TotalRest] = @TotalRest
                              Where cust_Id = @cust_Id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@cust_Id", SqlDbType.Int).Value = CInt(DGV_Cus.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@cust_Name", SqlDbType.NVarChar).Value = DGV_Cus.Rows(pos).Cells(1).Value.ToString
                .Parameters.AddWithValue("@Phone", SqlDbType.NChar).Value = DGV_Cus.Rows(pos).Cells(2).Value.ToString
                .Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = DGV_Cus.Rows(pos).Cells(3).Value.ToString
                .Parameters.AddWithValue("@Area", SqlDbType.NVarChar).Value = DGV_Cus.Rows(pos).Cells(4).Value.ToString
                .Parameters.AddWithValue("@Products", SqlDbType.NVarChar).Value = DGV_Cus.Rows(pos).Cells(5).Value.ToString
                .Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = DGV_Cus.Rows(pos).Cells(6).Value.ToString
                .Parameters.AddWithValue("@mnd_Name", SqlDbType.NVarChar).Value = DGV_Cus.Rows(pos).Cells(7).Value.ToString
                .Parameters.AddWithValue("@NumQst", SqlDbType.Int).Value = CInt(DGV_Cus.Rows(pos).Cells(8).Value)
                .Parameters.AddWithValue("@NumQstFinal", SqlDbType.Int).Value = CInt(DGV_Cus.Rows(pos).Cells(9).Value)
                .Parameters.AddWithValue("@DateBuy", SqlDbType.Date).Value = CDate(ConvertStrToDate(DGV_Cus.Rows(pos).Cells(10).Value))
                .Parameters.AddWithValue("@DateFirstQst", SqlDbType.Date).Value = CDate(ConvertStrToDate(DGV_Cus.Rows(pos).Cells(11).Value))
                .Parameters.AddWithValue("@BuyPrice", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(12).Value)
                .Parameters.AddWithValue("@SellPrice", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(13).Value)
                .Parameters.AddWithValue("@Profit", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(13).Value) - CDec(DGV_Cus.Rows(pos).Cells(12).Value)
                .Parameters.AddWithValue("@Paid", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(14).Value)
                .Parameters.AddWithValue("@Rest", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(13).Value) - CDec(DGV_Cus.Rows(pos).Cells(14).Value)
                .Parameters.AddWithValue("@Qst", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(16).Value)
                .Parameters.AddWithValue("@TotalQst", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(17).Value)
                .Parameters.AddWithValue("@TotalRest", SqlDbType.Decimal).Value = CDec(DGV_Cus.Rows(pos).Cells(15).Value) - CDec(DGV_Cus.Rows(pos).Cells(17).Value)
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            Cmd = Nothing
            MsgBox("تم تعديل البيانات بنجاح", MsgBoxStyle.Information, "تعديل")
        Catch ex As Exception
            MsgBox("خطأ فى البيانات المراد تعديلها", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
            If Con.State = 1 Then Con.Close()
            Exit Sub
        End Try
    End Sub

    Public Sub Delete_Customer_Tbl(ByVal dgv_Cus As DataGridView)
        Dim Position As Integer = dgv_Cus.CurrentRow.Index
        Dim ID_Position As Integer = dgv_Cus.Rows(Position).Cells(0).Value
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Delete  From Customers Where cust_Id = @cust_Id"
            .Parameters.Clear()
            .Parameters.AddWithValue("@cust_Id", SqlDbType.Int).Value = ID_Position
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم حذف بيانات  العميل بنجاح.", MsgBoxStyle.Information, "حذف")
        Cmd = Nothing
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        Try
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Delete_Customer_Tbl(DGV_Cus)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            If Con.State = 1 Then Con.Close()
        End Try
        LoadCustomers()
    End Sub

    Private Sub BtnExcel_Click(sender As System.Object, e As System.EventArgs) Handles BtnExcel.Click
        dgv_ExportDataToExcelFile(DGV_Cus)
    End Sub

    Private Sub BtnWord_Click(sender As System.Object, e As System.EventArgs) Handles BtnWord.Click
        ExportToWord(DGV_Cus, "قائمة العملاء")
    End Sub
    '*************  العملاء طباعة  ***********
    Public Sub Print()

        Try
            '--------------------------------------------------------------
            ' مهم جداً أن تستدعي هذا الأمر قبل كتابة أي سطر برمجي يخص الطباعة
            MSO.SetDllFiles()
            '--------------------------------------------------------------
            Dim MyWord As MSO.MSWord
            MyWord = New MSO.MSWord(Me)

            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\cusNew1.dotx"

            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " قائمة  العملاء"
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
            MyWord.PrintOut()
            'MyWord.PrintPreview()
        Catch ex As Exception
            MSO.PrintingProcess.ShowErrorMsgAndClose(ex.Message)
            If Con.State = 1 Then Con.Close()
        End Try

    End Sub
    '************* دالة خاصة بالطباعة ***********
    Private Function GetPrintableJob() As MSO.Printing.PrintJob

        Dim PrintJob As New MSO.Printing.PrintJob
        With PrintJob

            'إضافة الجدول الثاني

            '---------------------  Table 2 That Exist In Word Document ------------------
            With .AddTable()
                .DataTable = Get_All_cus()
                '-------------------------------------
                '.MinimumRowsAtTheBeginningOfTable = 3
                .IsFirstColumnAutoNumber = False
                .TableHeadBookMarkName = "TableHead_1"
                .FirstRowBookMarkName = "TableFirstRow_1"
                .DeleteTableIfNoData = False
                '-------------------------------------
                .AddTextColumn("cust_Id")
                .AddTextColumn("cust_Name")
                .AddTextColumn("City")
                .AddTextColumn("Products")
                .AddTextColumn("DateBuy")
                .AddTextColumn("DateFirstQst")
                .AddTextColumn("State")
                .AddTextColumn("SellPrice")
                .AddTextColumn("Paid")
                .AddTextColumn("Qst")
                .AddTextColumn("TotalQst")
                .AddTextColumn("TotalRest")
            End With
            '####################################################################################
        End With
        Return PrintJob
    End Function
    Public Function Get_All_cus()
        Con.Open()
        Dim dt1 As New DataTable
        Dim cmd As New SqlCommand("Select * From Customers", Con)
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1
    End Function

    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click
        Try
            Print()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Public Sub Search_By_Phone()
        Try
            DGV_Cus.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select * from Customers  where cust_Name LIKE'%" & TxtSearch.Text & "%'", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Cus.Rows.Add(dr("cust_Id").ToString, dr("cust_Name").ToString, dr("Phone").ToString, dr("City").ToString, dr("Area").ToString, dr("Products").ToString, dr("State").ToString, dr("mnd_Name").ToString, dr("NumQst").ToString, dr("NumQstFinal").ToString, dr("DateBuy").ToString, dr("DateFirstQst").ToString, dr("BuyPrice").ToString, dr("SellPrice").ToString, dr("Profit").ToString, dr("Paid").ToString, dr("Rest").ToString, dr("Qst").ToString, dr("TotalQst").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
        End Try

    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click

        Search_By_Phone()

    End Sub

    Private Sub BtnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles BtnShowAll.Click
        LoadCustomers()
        TxtSearch.Clear()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim frm As New Prn_Customer
            frm.TopLevel = False
            Home.HomePanel.Controls.Add(frm)
            frm.BringToFront()
            frm.Show()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        If Not TxtSearch.Text = vbNullString Then
            Search_By_Phone()
        End If


    End Sub

    Public Function GetMohsil_ID(ByVal cust_Id As String)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Mohsil_ID From  Customers  where cust_Id=@cust_Id", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@cust_Id", SqlDbType.Int).Value = cust_Id
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

    Public Function GetToktok_ID(ByVal cust_Id As Integer)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Toktok_ID From  Customers  where cust_Id=@cust_Id", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@cust_Id", SqlDbType.Int).Value = cust_Id
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

    Public Function GetProd_ID(ByVal ProName As String)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select pro_Id From  Store  where Pro_Name=@Pro_Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Pro_Name", SqlDbType.NVarChar).Value = ProName
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

    Public Function GetProd_Bonas(ByVal ProName As String)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Max(Bonas) From  Store  where Pro_Name=@Pro_Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Pro_Name", SqlDbType.NVarChar).Value = ProName
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim toktok_ID As Integer
            toktok_ID = GetToktok_ID(CInt(DGV_Cus.CurrentRow.Cells(0).Value))
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Dim ALLProducts() As String = Split(DGV_Cus.CurrentRow.Cells(5).Value, " + ")
                For i = 0 To ALLProducts.Length - 1
                    Dim Product() As String = Split(ALLProducts(i), " ( ")
                    If toktok_ID > 0 Then
                        Dim Pro_ID As Integer
                        Pro_ID = GetProd_ID(Product(0).ToString)
                        ' Load_Toktok.Insert_Load(toktok_ID, Pro_ID, Load_Toktok.GetPrd_ID(DGV_Cus.CurrentRow.Cells(7).Value.ToString), Now, CInt(Product(1).Chars(0).ToString), 1, CDec(DGV_Cus.CurrentRow.Cells(7).Value), CDec(DGV_Cus.CurrentRow.Cells(7).Value))
                        Buy_Inv.Decrease_Toktok_Qunt(toktok_ID, Pro_ID, CInt(Product(1).Chars(0).ToString) * CInt(-1), Load_Toktok.GetPrd_ID(DGV_Cus.CurrentRow.Cells(7).Value), CDec(DGV_Cus.CurrentRow.Cells(12).Value), CDec(DGV_Cus.CurrentRow.Cells(13).Value))
                    Else
                        Buy_Inv.Update_Store_Qunt(Product(0), CInt(Product(1).Chars(0).ToString), 0)
                    End If
                    Buy_Inv.Add_Mandob_Bonas(DGV_Cus.CurrentRow.Cells(7).Value, GetProd_Bonas(Product(0).ToString) * (-1))
                Next

                Delete_Customer_BackProducts(DGV_Cus)
            End If
        Catch ex As Exception
            MsgBox("ربما اسماء هذة المنتجات لم تكن موجوده فى المخزن من قبل!!")
            MsgBox(ex.Message.ToString)
            If Con.State = 1 Then Con.Close()
        End Try
        LoadCustomers()
    End Sub

    Public Sub Delete_Customer_BackProducts(ByVal dgv_Cus As DataGridView)
        Dim Position As Integer = dgv_Cus.CurrentRow.Index
        Dim ID_Position As Integer = dgv_Cus.Rows(Position).Cells(0).Value
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Delete  From Customers Where cust_Id = @cust_Id"
            .Parameters.Clear()
            .Parameters.AddWithValue("@cust_Id", SqlDbType.Int).Value = ID_Position
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم حذف بيانات  العميل بنجاح.", MsgBoxStyle.Information, "حذف")
        Cmd = Nothing
    End Sub

End Class