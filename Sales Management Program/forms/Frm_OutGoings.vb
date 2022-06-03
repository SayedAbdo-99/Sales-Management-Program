Imports System.Data.SqlClient
Imports MSwordDllFiles

Public Class Frm_OutGoings


    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        LoadOuts()
        Get_Total_Value()
        TxtSearch.Text = vbNullString
    End Sub
    Public Sub LoadOuts()
        Try
            DGV_prd.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT [Out_ID] ,[Person] ,[Posistion]   ,[Value]  ,[Date] ,[Note]  FROM [dbo].[OutGoings]", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_prd.Rows.Add(dr("Out_ID").ToString, dr("Person").ToString, dr("Posistion").ToString, dr("Value").ToString, dr("Date").ToString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    Private Sub Frm_OutGoings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOuts_Month()
        Get_Total_Value()
        LoadOuts_Month()
    End Sub
    Public Sub Get_Total_Value()
        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select COALESCE(Sum(Value),0) From OutGoings where [Date] Like '%" & Year(Now) & "-" & Month(Now) & "-%'", Con)
            txtTotalVal.Text = CStr(cmd.ExecuteScalar)
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ فى تجميع القيم")
            Con.Close()
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadOuts_Month()
        Get_Total_Value()
    End Sub


    Public Sub LoadOuts_Month()
        Try
            DGV_prd.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT [Out_ID] ,[Person] ,[Posistion]   ,[Value]  ,[Date] ,[Note]  
                                        FROM [dbo].[OutGoings]
                                        Where [Date] Like '%" & Year(Now) & "-" & Month(Now) & "-" & "%'", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_prd.Rows.Add(dr("Out_ID").ToString, dr("Person").ToString, dr("Posistion").ToString, dr("Value").ToString, dr("Date").ToString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Add_Exp.ShowDialog()
        Get_Total_Value()
        LoadOuts_Month()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Try
            If DGV_prd.Rows.Count < 1 Then
                Exit Sub
            End If
            Dim Position As Integer = DGV_prd.CurrentRow.Index
            If Position >= 0 Then
                If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات العملية المحددة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    Update_Out(Position)
                End If
                MsgBox("تم تعديل بيانات العميلة المحددة بنجاح", MsgBoxStyle.Information, "تعديل")

            Else
                MessageBox.Show("يجب تحديد الصف المراد تعديله")
                Exit Sub
            End If

            Get_Total_Value()
            LoadOuts_Month()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub Update_Out(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[OutGoings] SET [Person] = @Person, [Posistion] = @Posistion, [Value] = @Value, [Date] = @Date, [Note] = @Note
                                WHERE [Out_ID]=@Out_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Out_ID", SqlDbType.Int).Value = CInt(DGV_prd.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@Person", SqlDbType.NVarChar).Value = DGV_prd.Rows(pos).Cells(1).Value.ToString
                .Parameters.AddWithValue("@Posistion", SqlDbType.NVarChar).Value = DGV_prd.Rows(pos).Cells(2).Value.ToString
                .Parameters.AddWithValue("@Value", SqlDbType.Decimal).Value = CDec(DGV_prd.Rows(pos).Cells(3).Value)
                .Parameters.AddWithValue("@Date", SqlDbType.Date).Value = CDate(DGV_prd.Rows(pos).Cells(4).Value)
                .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = DGV_prd.Rows(pos).Cells(5).Value.ToString
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DGV_prd.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim count As Integer = DGV_prd.Rows.Count
        If count > 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع العمليات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                For i = 0 To count - 1
                    Update_Out(i)
                Next
            End If
            MsgBox("تم تعديل بيانات العمليات  بنجاح", MsgBoxStyle.Information, "تعديل")

            LoadOuts_Month()
            Get_Total_Value()
        Else
            MessageBox.Show("يجب تحديد الصف المراد تعديله")
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Delete_Out(DGV_prd)
            Get_Total_Value()
            LoadOuts_Month()
        End If

    End Sub

    Public Sub Delete_Out(ByVal Dgv_prd As DataGridView)
        Try

            Dim Position As Integer = Dgv_prd.CurrentRow.Index
            Dim ID_Position As Integer = CInt(Dgv_prd.Rows(Position).Cells(0).Value)
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Delete  From OutGoings Where Out_ID = @Out_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Out_ID", SqlDbType.Int).Value = ID_Position
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم حذف بيانات العملية بنجاح .", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing

        Catch ex As Exception
            MsgBox("عفواً ... لا يمكن حذف هذا العملية لانه من الممكن ان يسبب مشاكل فى السيستم  .", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnWord_Click(sender As Object, e As EventArgs) Handles BtnWord.Click
        ExportToWord(DGV_prd, "قائمة المصروفات")
    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        dgv_ExportDataToExcelFile(DGV_prd)
    End Sub

    Private Sub BtnSearchDate_Click(sender As Object, e As EventArgs) Handles BtnSearchDate.Click
        Search_2Date(Date1.Value, Date2.Value)
    End Sub

    Public Sub Search_2Date(ByVal date1 As Date, ByVal date2 As Date)
        Try
            DGV_prd.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT [Out_ID] ,[Person] ,[Posistion]   ,[Value]  ,[Date] ,[Note]  
                                        FROM [dbo].[OutGoings]
                                        Where [Date] >= @Date1 And [Date] <= @Date2 ", Con)

            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Date1", SqlDbType.Date).Value = "#" & date1.ToShortDateString & "#"
            cmd.Parameters.Add("@Date2", SqlDbType.Date).Value = "#" & date2.ToShortDateString & "#"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_prd.Rows.Add(dr("Out_ID").ToString, dr("Person").ToString, dr("Posistion").ToString, dr("Value").ToString, dr("Date").ToString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
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
            Dim cmd As New SqlCommand(" SELECT [Out_ID] ,[Person] ,[Posistion]   ,[Value]  ,[Date] ,[Note]  
                                        FROM [dbo].[OutGoings]
                                        Where [Person] Like '%" & TxtSearch.Text & "%'", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_prd.Rows.Add(dr("Out_ID").ToString, dr("Person").ToString, dr("Posistion").ToString, dr("Value").ToString, dr("Date").ToString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Print()
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
            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Outgoings.dotx"
            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " قائمة  المصروفات"
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
                .AddTextColumn("Out_ID")
                .AddTextColumn("Person")
                .AddTextColumn("Posistion")
                .AddTextColumn("Value")
                .AddTextColumn("Date")
                .AddTextColumn("Note")
            End With
            '####################################################################################
        End With
        Return PrintJob
    End Function
    Public Function Get_All_Prd()
        Con.Open()
        Dim dt1 As New DataTable
        Dim cmd As New SqlCommand("Select * From OutGoings Where [Date] Like '%" & Year(Now) & "-" & Month(Now) & "-" & "%' ", Con)
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1
    End Function

End Class