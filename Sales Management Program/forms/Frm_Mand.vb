Imports System.Data.SqlClient
Imports System.IO
Imports MSwordDllFiles

Public Class Frm_Mand

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        'Me.Close()
        Add_Mand.ShowDialog()
    End Sub
    Public Sub Load_Mandobin()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT M.[Mand_ID] ,M.[Mand_Name] ,M.[Phone] ,M.[Salary]  ,M.[Bonas]
                                                , COALESCE(Sum(Tw.Cash),0) As Cash  ,COALESCE(Sum(Qst),0) As Qst  ,COALESCE(Sum(Outgoings),0) As Outgoings  ,COALESCE(Sum(Lateds),0) As Lateds  ,COALESCE(Sum(TotalRest),0) As TotalRest
                                        FROM [dbo].[Mandobin] As M Left JOIN [dbo].[Twrid] As Tw 
                                        ON M.Mand_ID = Tw.Mand_ID AND Tw.Date like '%-" & Month(Now) & "-%'
                                        GROUP BY M.[Mand_ID],M.[Mand_Name], M.[Phone], M.[Salary], M.[Bonas]", Con)

            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Mand_ID").ToString, dr("Mand_Name").ToString, dr("Phone").ToString, dr("Salary").ToString, dr("Bonas").ToString, dr("Cash").ToString, dr("Qst").ToString, (CDec(dr("Cash")) + CDec(dr("Qst"))).ToString, dr("Outgoings").ToString, dr("Lateds").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

    Private Sub Frm_Importers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_Mandobin()
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If DGV_Mand.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim Position As Integer = DGV_Mand.CurrentRow.Index
        If Position >= 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات العميل المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Update_Mand(Position)
            End If
            MsgBox("تم تعديل بيانات العميل المحدد بنجاح", MsgBoxStyle.Information, "تعديل")
            Load_Mandobin()
        Else
            MessageBox.Show("يجب تحديد الصف المراد تعديله")
            Exit Sub
        End If
    End Sub
    Public Sub Update_Mand(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Mandobin]  SET [Mand_Name] = @Mand_Name ,[Phone] = @Phone, [Salary] = @Salary,[Bonas] = @Bonas
                                WHERE [Mand_ID]=@Mand_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Mand_ID", SqlDbType.Int).Value = CInt(DGV_Mand.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@Mand_Name", SqlDbType.NVarChar).Value = DGV_Mand.Rows(pos).Cells(1).Value.ToString
                .Parameters.AddWithValue("@Phone", SqlDbType.NChar).Value = DGV_Mand.Rows(pos).Cells(2).Value.ToString
                .Parameters.AddWithValue("@Salary", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(3).Value)
                .Parameters.AddWithValue("@Bonas", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(4).Value)
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("خطأ فى البيانات المراد تعديلها", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
            If Con.State = 1 Then Con.Close()
            Exit Sub
        End Try
    End Sub


    Private Sub DGV_Imp_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Public Sub Delete_Imporets_Tbl(ByVal DGV_Imp As DataGridView)
        Try

            Dim Position As Integer = DGV_Imp.CurrentRow.Index
            Dim ID_Position As Integer = DGV_Imp.Rows(Position).Cells(0).Value
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Delete  From Mandobin Where Mand_ID = @Mand_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Mand_ID", SqlDbType.Int).Value = ID_Position
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم حذف بيانات  المندوب بنجاح.", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing

        Catch ex As Exception
            MsgBox("عفواً لا يمكن حذف هذا المندوب نظراً لانه توجد عمليات اخرى متعلقه به يجب حذفها اولاً", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "نوع الخطأ")
            If Con.State = 1 Then Con.Close()
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Delete_Imporets_Tbl(DGV_Mand)
        End If
        Load_Mandobin()
    End Sub

    Private Sub BtnExcel_Click(sender As System.Object, e As System.EventArgs) Handles BtnExcel.Click
        dgv_ExportDataToExcelFile(DGV_Mand)
    End Sub

    Private Sub BtnWord_Click(sender As System.Object, e As System.EventArgs) Handles BtnWord.Click
        ExportToWord(DGV_Mand, "قائمة الموردين ")
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
            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Mand.dotx"
            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " قائمة  المندوبين"
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
                .DataTable = Get_All_Imp()
                '-------------------------------------
                '.MinimumRowsAtTheBeginningOfTable = 3
                .IsFirstColumnAutoNumber = False
                .TableHeadBookMarkName = "TableHead_1"
                .FirstRowBookMarkName = "TableFirstRow_1"
                .DeleteTableIfNoData = False
                '-------------------------------------
                .AddTextColumn("Mand_ID")
                .AddTextColumn("Mand_Name")
                .AddTextColumn("Phone")
                .AddTextColumn("Salary")
                .AddTextColumn("Bonas")
                .AddTextColumn("Cash")
                .AddTextColumn("Qst")
                .AddTextColumn("Outgoings")
                .AddTextColumn("Lateds")
                .AddTextColumn("TotalRest")
            End With
            '####################################################################################
        End With
        Return PrintJob
    End Function
    Public Function Get_All_Imp()
        Con.Open()
        Dim dt1 As New DataTable
        Dim cmd As New SqlCommand(" SELECT M.[Mand_ID] ,M.[Mand_Name] ,M.[Phone] ,M.[Salary]  ,M.[Bonas] 
                                         , COALESCE(Sum(Tw.Cash),0) As Cash  ,COALESCE(Sum(Qst),0) As Qst  ,COALESCE(Sum(Outgoings),0) As Outgoings  ,COALESCE(Sum(Lateds),0) As Lateds  ,COALESCE(Sum(TotalRest),0) As TotalRest
                                        FROM [dbo].[Mandobin] As M  JOIN [dbo].[Twrid] As Tw 
                                        ON M.Mand_ID = Tw.Mand_ID AND Tw.Date like @Date 
                                        GROUP BY M.[Mand_ID],M.[Mand_Name],M.[Phone]   ,M.[Salary]  ,M.[Bonas]", Con)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = "%-" & Month(Now) & "-%"

        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1
    End Function

    Public Sub Search_By_Phone()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT M.[Mand_ID] ,M.[Mand_Name] ,M.[Phone] ,M.[Salary]  ,M.[Bonas] 
                                       , COALESCE(Sum(Tw.Cash),0) As Cash  ,COALESCE(Sum(Qst),0) As Qst  ,COALESCE(Sum(Outgoings),0) As Outgoings  ,COALESCE(Sum(Lateds),0) As Lateds  ,COALESCE(Sum(TotalRest),0) As TotalRest
                                       FROM [dbo].[Mandobin] As M  JOIN [dbo].[Twrid] As Tw 
                                        ON M.Mand_ID = Tw.Mand_ID And M.[Mand_Name] Like @MandName AND Tw.Date like @Date 
                                        GROUP BY M.[Mand_ID],M.[Mand_Name],M.[Phone]   ,M.[Salary]    ,M.[Bonas]", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = "%-" & Month(Now) & "-%"
            cmd.Parameters.AddWithValue("@MandName", SqlDbType.NVarChar).Value = "%" & TxtSearch.Text & "%"

            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Mand_ID").ToString, dr("Mand_Name").ToString, dr("Phone").ToString, dr("Salary").ToString, dr("Bonas").ToString, dr("Cash").ToString, dr("Qst").ToString, (CDec(dr("Cash")) + CDec(dr("Qst"))).ToString, dr("Outgoings").ToString, dr("Lateds").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs)
        If Not TxtSearch.Text = vbNullString Then
            Search_By_Phone()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click
        Print()
    End Sub

    Private Sub BtnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles BtnShowAll.Click
        Load_Mandobin()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        If Not TxtSearch.Text = vbNullString Then
            Search_By_Phone()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DGV_Mand.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim count As Integer = DGV_Mand.Rows.Count
        If count > 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع العملاء؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                For i = 0 To count - 1
                    Update_Mand(i)
                Next
            End If
            MsgBox("تم تعديل بيانات جميع المندوبين بنجاح", MsgBoxStyle.Information, "تعديل")
            Load_Mandobin()
        Else
            MessageBox.Show("لا توجد بيانات للتعديل")
        End If
    End Sub
End Class