Imports System.Data.SqlClient
Imports MSwordDllFiles

Public Class Frm_Mohslin

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs)
        'Me.Close()
        Add_Exp.ShowDialog()
    End Sub

    Private Sub Frm_Cat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadMohslin(Year(Now) & "-" & Month(Now) & "-")
    End Sub

    Public Sub Delete_Mohsil(ByVal DGV_Cat As DataGridView)
        Try
            Dim Position As Integer = DGV_Cat.CurrentRow.Index
            Dim ID_Position As Integer = DGV_Cat.Rows(Position).Cells(0).Value
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Delete  From Mohslin Where Mhsl_ID = @Mhsl_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Mhsl_ID", SqlDbType.Int).Value = ID_Position
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم حذف بيانات المحصل بنجاح.", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("عفواً لا يمكن حذف هذا المحصل نظراً لانه توجد عمليات اخرى متعلقه به يجب حذفها اولاً", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "نوع الخطأ")
            If Con.State = 1 Then Con.Close()

        End Try
    End Sub




    '************* طباعة الاصناف ***********
    Public Sub Print()

        Try
            '--------------------------------------------------------------
            ' مهم جداً أن تستدعي هذا الأمر قبل كتابة أي سطر برمجي يخص الطباعة
            MSO.SetDllFiles()
            '--------------------------------------------------------------
            Dim MyWord As MSO.MSWord
            MyWord = New MSO.MSWord(Me)
            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Mohsil.dotx"
            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " قائمة  المحصلين"
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
            ' MyWord.PrintPreview()

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
                .DataTable = Get_All_Cat()
                '-------------------------------------
                '.MinimumRowsAtTheBeginningOfTable = 3
                .IsFirstColumnAutoNumber = False
                .TableHeadBookMarkName = "TableHead_1"
                .FirstRowBookMarkName = "TableFirstRow_1"
                .DeleteTableIfNoData = False
                '-------------------------------------
                .AddTextColumn("Mhsl_ID")
                .AddTextColumn("Name")
                .AddTextColumn("Phone")
                .AddTextColumn("Daen")
                .AddTextColumn("ThsilCash")
                .AddTextColumn("ThsilQst")
                .AddTextColumn("ThsilTotal")
                .AddTextColumn("Modin")
                .AddTextColumn("Total")
                .AddTextColumn("Note")


            End With
            '####################################################################################
        End With
        Return PrintJob
    End Function
    Public Function Get_All_Cat()
        Con.Open()
        Dim dt1 As New DataTable
        Dim cmd As New SqlCommand("SELECT M.[Mhsl_ID] ,M.[Name], M.[Phone] ,M.[Daen] ,M.[ThsilCash] ,M.[ThsilQst] ,M.[ThsilTotal] ,M.[Modin]  ,M.[Note]
                                    ,COALESCE(Sum(T.Total),0) As Total,COALESCE(Sum(C.TotalRest),0) As TotalRest
                                    FROM [dbo].[Mohslin] AS  M Left Join [dbo].[Thsil] As T
                                    On M.Mhsl_ID=T.Mhsl_ID  AND T.Date Like '%" & Year(Now) & "-" & Month(Now) & "-" & "%'
                                    Left Join [dbo].[Customers] As C
								    On M.Mhsl_ID=C.Mohsil_ID
                                    Group by M.Mhsl_ID ,M.Name  ,M.Phone  ,M.Daen, M.[ThsilCash] ,M.[ThsilQst] ,M.[ThsilTotal]  ,M.Modin ,M.Note ", Con)
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1
    End Function


    Private Sub BtnNew_Click_1(sender As Object, e As EventArgs) Handles BtnNew.Click
        Add_Mohsil.ShowDialog()
        LoadMohslin(Year(Now) & "-" & Month(Now) & "-")
    End Sub

    Private Sub BtnEdit_Click_1(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If DGV_Imp.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim Position As Integer = DGV_Imp.CurrentRow.Index
        If Position >= 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات المحصل المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Update_Mohsil(Position)
            End If
            MsgBox("تم تعديل بيانات المحصل المحدد بنجاح", MsgBoxStyle.Information, "تعديل")

            LoadMohslin(Year(Now) & "-" & Month(Now) & "-")
        Else
            MessageBox.Show("يجب تحديد الصف المراد تعديله")
            Exit Sub
        End If
    End Sub
    Public Sub Update_Mohsil(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Mohslin]
                                SET [Name] = @Name ,[Phone] = @Phone, [Daen] = @Daen,[ThsilCash]=@ThsilCash ,[ThsilQst]=@ThsilQst ,[ThsilTotal]=@ThsilTotal, [Modin] = @Modin, [Note] = @Note
                                WHERE Mhsl_ID=@Mhsl_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Mhsl_ID", SqlDbType.Int).Value = CInt(DGV_Imp.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = DGV_Imp.Rows(pos).Cells(1).Value
                .Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = DGV_Imp.Rows(pos).Cells(2).Value
                .Parameters.AddWithValue("@Daen", SqlDbType.Decimal).Value = CDec(DGV_Imp.Rows(pos).Cells(3).Value)
                .Parameters.AddWithValue("@ThsilCash", SqlDbType.Decimal).Value = CDec(DGV_Imp.Rows(pos).Cells(4).Value)
                .Parameters.AddWithValue("@ThsilQst", SqlDbType.Decimal).Value = CDec(DGV_Imp.Rows(pos).Cells(5).Value)
                .Parameters.AddWithValue("@ThsilTotal", SqlDbType.Decimal).Value = CDec(DGV_Imp.Rows(pos).Cells(6).Value)
                .Parameters.AddWithValue("@Modin", SqlDbType.Decimal).Value = CDec(DGV_Imp.Rows(pos).Cells(7).Value)
                .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = DGV_Imp.Rows(pos).Cells(8).Value
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


    Private Sub BtnDelete_Click_1(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Delete_Mohsil(DGV_Imp)
        End If
        LoadMohslin(Year(Now) & "-" & Month(Now) & "-")
    End Sub

    Public Sub LoadMohslin(ByVal dateSearch As String)
        Try
            DGV_Imp.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT M.[Mhsl_ID] ,M.[Name], M.[Phone] ,M.[Daen] ,M.[ThsilCash] ,M.[ThsilQst] ,M.[ThsilTotal] ,M.[Modin]  ,M.[Note]
                                       ,COALESCE(Sum(T.Total),0) As Total, COALESCE(Sum(C.TotalRest),0) As TotalRest
                                        FROM [dbo].[Mohslin] AS  M Left Join [dbo].[Thsil] As T
                                        On M.Mhsl_ID=T.Mhsl_ID  AND T.Date Like '%" & dateSearch & "%'
                                        Left Join [dbo].[Customers] As C
										On M.Mhsl_ID=C.Mohsil_ID
                                        Group by M.Mhsl_ID ,M.Name  ,M.Phone  ,M.Daen ,[ThsilCash] ,[ThsilQst] ,[ThsilTotal] ,M.Modin ,M.Note", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Imp.Rows.Add(dr("Mhsl_ID").ToString, dr("Name").ToString, dr("Phone").ToString, dr("Daen").ToString, dr("ThsilCash").ToString, dr("ThsilQst").ToString, dr("ThsilTotal").ToString, dr("Modin").ToString, dr("Note").ToString, dr("Total").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        LoadMohslin("")

    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        If Not TxtSearch.Text = vbNullString Then
            Search_Mohsil(TxtSearch.Text)
        Else
            LoadMohslin(Year(Now) & "-" & Month(Now) & "-")
        End If
    End Sub
    Public Sub Search_Mohsil(ByVal Mhsl_Name As String)
        Try
            DGV_Imp.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT M.[Mhsl_ID] ,M.[Name], M.[Phone] ,M.[Daen] ,M.[ThsilCash] ,M.[ThsilQst] ,M.[ThsilTotal] ,M.[Modin]  ,M.[Note]
                                       ,COALESCE(Sum(T.Total),0) As Total, COALESCE(Sum(C.TotalRest),0) As TotalRest
                                        FROM [dbo].[Mohslin] AS  M Join [dbo].[Thsil] As T
                                        On M.Mhsl_ID=T.Mhsl_ID  AND M.Name Like @MandName AND  T.Date Like '%" & Year(Now) & "-" & Month(Now) & "-%'
                                        Left Join [dbo].[Customers] As C
										On M.Mhsl_ID=C.Mohsil_ID
                                        Group by M.Mhsl_ID ,M.Name  ,M.Phone  ,M.Daen ,[ThsilCash] ,[ThsilQst] ,[ThsilTotal]  ,M.Modin ,M.Note", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@MandName", SqlDbType.NVarChar).Value = "%" & Mhsl_Name & "%"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Imp.Rows.Add(dr("Mhsl_ID").ToString, dr("Name").ToString, dr("Phone").ToString, dr("Daen").ToString, dr("ThsilCash").ToString, dr("ThsilQst").ToString, dr("ThsilTotal").ToString, dr("Modin").ToString, dr("Note").ToString, dr("Total").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadMohslin(Year(Now) & "-" & Month(Now) & "-")
        TxtSearch.Clear()
    End Sub

    Private Sub BtnSearchDate_Click(sender As Object, e As EventArgs) Handles BtnSearchDate.Click
        Search_By_2Date(Date1.Value, Date2.Value)
    End Sub

    Public Sub Search_By_2Date(ByVal date1 As Date, ByVal date2 As Date)
        Try
            DGV_Imp.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT M.[Mhsl_ID] ,M.[Name], M.[Phone] ,M.[Daen] ,M.[ThsilCash] ,M.[ThsilQst] ,M.[ThsilTotal] ,M.[Modin]  ,M.[Note]
                                       ,COALESCE(Sum(T.Total),0) As Total, COALESCE(Sum(C.TotalRest),0) As TotalRest
                                        FROM [dbo].[Mohslin] AS  M Join [dbo].[Thsil] As T
                                        On M.Mhsl_ID=T.Mhsl_ID  AND T.Date >= @Date1 And T.Date <= @Date2
										Left Join [dbo].[Customers] As C
										On M.Mhsl_ID=C.Mohsil_ID
                                        Group by M.Mhsl_ID ,M.Name  ,M.Phone  ,M.Daen ,[ThsilCash] ,[ThsilQst] ,[ThsilTotal] ,M.Modin ,M.Note", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Date1", SqlDbType.Date).Value = "#" & date1.ToShortDateString & "#"
            cmd.Parameters.Add("@Date2", SqlDbType.Date).Value = "#" & date2.ToShortDateString & "#"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Imp.Rows.Add(dr("Mhsl_ID").ToString, dr("Name").ToString, dr("Phone").ToString, dr("Daen").ToString, dr("ThsilCash").ToString, dr("ThsilQst").ToString, dr("ThsilTotal").ToString, dr("Modin").ToString, dr("Note").ToString, dr("Total").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DGV_Imp.Rows.Count < 1 Then
            Exit Sub
        End If
        Dim count As Integer = DGV_Imp.Rows.Count
        If count > 0 Then
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع المحصلين؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                For i = 0 To count - 1
                    Update_Mohsil(i)
                Next
            End If
            MsgBox("تم تعديل بيانات جميع العمليات بنجاح", MsgBoxStyle.Information, "تعديل")
            LoadMohslin(Year(Now) & "-" & Month(Now) & "-")
        Else
            MessageBox.Show("لا توجد بيانات لتعديلها")
        End If
    End Sub

    Private Sub BtnWord_Click_1(sender As Object, e As EventArgs) Handles BtnWord.Click
        ExportToWord(DGV_Imp, "قائمة المحصلين")
    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        dgv_ExportDataToExcelFile(DGV_Imp)
    End Sub

    Private Sub BtnPrint_Click_1(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Print()
    End Sub
End Class