Imports System.Data.SqlClient
Imports System.IO
Imports MSwordDllFiles

Public Class Frm_Products
    Private Sub Frm_Products_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPrd()
    End Sub
    Public Sub LoadPrd()
        Try
            DGV_prd.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" Select * from Store", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_prd.Rows.Add(dr("pro_Id").ToString, dr("Code").ToString, dr("Pro_Name").ToString, dr("Qunt").ToString, dr("BuyPrice").ToString, dr("CashPrice").ToString, dr("Profit").ToString, dr("TotalBuy").ToString, dr("QstPrice").ToString, dr("QstPrice5").ToString, dr("Bonas").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        Add_Product.ShowDialog()
    End Sub
    Private Sub BtnExcel_Click(sender As System.Object, e As System.EventArgs) Handles BtnExcel.Click
        dgv_ExportDataToExcelFile(DGV_prd)
    End Sub
    Private Sub BtnWord_Click(sender As System.Object, e As System.EventArgs) Handles BtnWord.Click
        ExportToWord(DGV_prd, "قائمة المنتجات")
    End Sub
    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If DGV_prd.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim Position As Integer = DGV_prd.CurrentRow.Index
        If Position >= 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات المنتج المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Update_Pro(Position)
            End If
            MsgBox("تم تعديل بيانات المنتج المحدد بنجاح", MsgBoxStyle.Information, "تعديل")
            LoadPrd()
        Else
            MessageBox.Show("يجب تحديد الصف المراد تعديله")
            Exit Sub
        End If
    End Sub

    Public Sub Update_Pro(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Store]   SET [Code] = @Code , [Pro_Name] =@Pro_Name, [Qunt]=@Qunt ,[BuyPrice] =@BuyPrice  ,[CashPrice] = @CashPrice
                               ,[Profit] = @Profit ,[TotalBuy] = @TotalBuy ,[QstPrice] = @QstPrice  ,[QstPrice5] = @QstPrice5 ,[Bonas] = @Bonas WHERE pro_Id=@pro_Id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@pro_Id", SqlDbType.Int).Value = CInt(DGV_prd.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@Code", SqlDbType.Int).Value = CInt(DGV_prd.Rows(pos).Cells(1).Value)
                .Parameters.AddWithValue("@Pro_Name", SqlDbType.NVarChar).Value = DGV_prd.Rows(pos).Cells(2).Value.ToString
                .Parameters.AddWithValue("@Qunt", SqlDbType.Int).Value = CInt(DGV_prd.Rows(pos).Cells(3).Value)
                .Parameters.AddWithValue("@BuyPrice", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(4).Value)
                .Parameters.AddWithValue("@CashPrice", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(5).Value)
                .Parameters.AddWithValue("@Profit", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(5).Value) - CDec(DGV_prd.Rows(pos).Cells(4).Value)
                .Parameters.AddWithValue("@TotalBuy", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(3).Value) * CDec(DGV_prd.Rows(pos).Cells(4).Value)
                .Parameters.AddWithValue("@QstPrice", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(8).Value)
                .Parameters.AddWithValue("@QstPrice5", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(5).Value) + CDec((CDec(DGV_prd.Rows(pos).Cells(8).Value) - CDec(DGV_prd.Rows(pos).Cells(5).Value)) / 2.0)
                .Parameters.AddWithValue("@Bonas", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(10).Value)
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("خطأ فى البيانات المراد تعديلها", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
            Con.Close()
            Exit Sub
        End Try
    End Sub


    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Delete_Product_Tbl(DGV_prd)
            LoadPrd()
        End If

    End Sub
    Public Sub Delete_Product_Tbl(ByVal Dgv_prd As DataGridView)
        Try

            Dim Position As Integer = Dgv_prd.CurrentRow.Index
            Dim ID_Position As Integer = CInt(Dgv_prd.Rows(Position).Cells(0).Value)
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Delete  From Store Where pro_Id = @pro_Id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@pro_Id", SqlDbType.Int).Value = ID_Position
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم حذف بيانات المنتج بنجاح .", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing

        Catch ex As Exception
            MsgBox("عفواً ... لا يمكن حذف هذا المنتج لانه من الممكن ان يسبب مشاكل فى السيستم  .", MsgBoxStyle.Critical, "خطأ")
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DGV_prd_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    '*************  المنتجات طباعة  ***********
    Public Sub Print()
        Try
            '--------------------------------------------------------------
            ' مهم جداً أن تستدعي هذا الأمر قبل كتابة أي سطر برمجي يخص الطباعة
            MSO.SetDllFiles()
            '--------------------------------------------------------------
            Dim MyWord As MSO.MSWord
            MyWord = New MSO.MSWord(Me)
            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\product.dotx"
            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " قائمة  المنتجات"
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
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    '************* دالة خاصة بالطباعة ***********
    Private Function GetPrintableJob() As MSO.Printing.PrintJob

        Dim PrintJob As New MSO.Printing.PrintJob
        With PrintJob

            'إضافة الجدول الثاني

            '---------------------  Table 2 That Exist In Word Document ------------------
            With .AddTable()
                .DataTable = Get_All_Prd()
                '-------------------------------------
                '.MinimumRowsAtTheBeginningOfTable = 3
                .IsFirstColumnAutoNumber = False
                .TableHeadBookMarkName = "TableHead_1"
                .FirstRowBookMarkName = "TableFirstRow_1"
                .DeleteTableIfNoData = False
                '-------------------------------------
                .AddTextColumn("pro_Id")
                .AddTextColumn("Code")
                .AddTextColumn("Pro_Name")
                .AddTextColumn("Qunt")
                .AddTextColumn("BuyPrice")
                .AddTextColumn("CashPrice")
                .AddTextColumn("QstPrice")
                .AddTextColumn("QstPrice5")
                .AddTextColumn("Bonas")
            End With
            '####################################################################################
        End With
        Return PrintJob
    End Function
    Public Function Get_All_Prd()
        Con.Open()
        Dim dt1 As New DataTable
        Dim cmd As New SqlCommand("Select * From Store ", Con)
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1
    End Function

    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click
        Print()
    End Sub
    Public Sub GetProduct()

        For i As Integer = 0 To Load_Toktok.dgv_buy.Rows.Count - 1
            If Load_Toktok.dgv_buy.Rows(i).Cells(0).Value = DGV_prd.CurrentRow.Cells(0).Value Then
                MsgBox(" المنتج المراد ادخاله تم اضافته للفاتورة مسبقا")
                Exit Sub
            End If
        Next
        Dim x As Integer
        Load_Toktok.dgv_buy.Rows.Add()
        x = Load_Toktok.dgv_buy.Rows.Count - 1
        Load_Toktok.dgv_buy(0, x).Value = DGV_prd.CurrentRow.Cells(0).Value
        Load_Toktok.dgv_buy(1, x).Value = DGV_prd.CurrentRow.Cells(1).Value
        Load_Toktok.dgv_buy(2, x).Value = DGV_prd.CurrentRow.Cells(2).Value
        Load_Toktok.dgv_buy(3, x).Value = DGV_prd.CurrentRow.Cells(4).Value

        Me.Close()


    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        If Not TxtSearch.Text = vbNullString Then
            Search_By_Name()
        End If
    End Sub
    Public Sub Search_By_Name()
        Try
            DGV_prd.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select * from Store  where Pro_Name LIKE'%" & TxtSearch.Text & "%'", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_prd.Rows.Add(dr("pro_Id").ToString, dr("Code").ToString, dr("Pro_Name").ToString, dr("Qunt").ToString, dr("BuyPrice").ToString, dr("CashPrice").ToString, dr("Profit").ToString, dr("TotalBuy").ToString, dr("QstPrice").ToString, dr("QstPrice5").ToString, dr("Bonas").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Search_By_id()
        Try
            DGV_prd.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select * from Store  where Code LIKE'" & txtSearchcCode.Text & "%'", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_prd.Rows.Add(dr("pro_Id").ToString, dr("Code").ToString, dr("Pro_Name").ToString, dr("Qunt").ToString, dr("BuyPrice").ToString, dr("CashPrice").ToString, dr("Profit").ToString, dr("TotalBuy").ToString, dr("QstPrice").ToString, dr("QstPrice5").ToString, dr("Bonas").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSearchcCode.TextChanged
        If IsNumeric(txtSearchcCode.Text) Then
            Search_By_id()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DGV_prd.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim count As Integer = DGV_prd.Rows.Count
        If count > 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع العملاء؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                For i = 0 To count - 1
                    Update_Pro(i)
                Next
            End If
            MsgBox("تم تعديل بيانات المنتجات بنجاح", MsgBoxStyle.Information, "تعديل")
            LoadPrd()
        Else
            MessageBox.Show("يجب تحديد الصف المراد تعديله")
        End If
    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        LoadPrd()
        TxtSearch.Text = vbNullString
        txtSearchcCode.Text = vbNullString
    End Sub
End Class