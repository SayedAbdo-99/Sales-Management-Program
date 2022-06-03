Imports System.Data.SqlClient

Imports MSwordDllFiles

Public Class Frm_Dftr_Mohslin
    Public Sub Load_Mohslin_Names()
        ComboBox_mand_Name.Items.Clear()

        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Name from Mohslin", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox_mand_Name.Items.Add(dr("Name").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Public Sub Total()

        Dim Total3 As Decimal = "0.00"
        For Each row As DataGridViewRow In DGV_Mand.Rows
            Total3 += CDec(row.Cells(2).Value)
        Next

        txtTotalThsil.Text = Total3
        TxtTotalLateded.Text = Get_Total_Lated()

        InvoiceCount.Text = DGV_Mand.Rows.Count
    End Sub

    Public Function Get_Total_Lated()
        Dim Num As Integer
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Dim cmd As New SqlCommand("Select COALESCE(Sum(Modin),0) From Mohslin", Con)
        Num = cmd.ExecuteScalar
        Con.Close()
        Return Num
    End Function

    Private Sub Frm_Dftr_Mohslin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Mohslin_Names()
        Load_ALL_Data()
        LblDateDay.Text = Date.Now.ToString("dddd")
        LblData.Text = Date.Now.ToString("dd/MM/yyyy")
        Total()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        Try
            Load_ALL_Data_ToDay()
            Total()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Load_ALL_Data_ToDay()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("SELECT Th.[Th_ID] ,M.[Name] , Th.[Total] , Th.[Date]  ,Th.[Note]	  
                                       FROM [dbo].[Thsil] As Th , [dbo].[Mohslin] As M
                                       Where Th.[Mhsl_ID]=M.[Mhsl_ID] And Th.[Date] Like @Date", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = "%" & Year(Now) & "-" & Month(Now) & "-" & Now.Day & "%"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Th_ID").ToString, dr("Name").ToString, dr("Total").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        Load_ALL_Data()
        Total()
    End Sub
    Public Sub Load_ALL_Data()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("SELECT Th.[Th_ID] ,M.[Name] , Th.[Total] , Th.[Date]  ,Th.[Note]	  
                                       FROM [dbo].[Thsil] As Th , [dbo].[Mohslin] As M
                                       Where Th.[Mhsl_ID]=M.[Mhsl_ID]", Con)
            'cmd.Parameters.Clear()
            'cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = "%-" & Month(Now) & "-%"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Th_ID").ToString, dr("Name").ToString, dr("Total").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Try
            Add_Thsil.ShowDialog()
            Load_ALL_Data()
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Delete_Thsil_Proce(DGV_Mand)
            End If
            Load_ALL_Data()
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Delete_Thsil_Proce(ByVal DGV_Imp As DataGridView)
        Try

            Dim Position As Integer = DGV_Imp.CurrentRow.Index
            Dim ID_Position As Integer = DGV_Imp.Rows(Position).Cells(0).Value
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Delete  From [dbo].[Thsil] Where Th_ID = @Th_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Th_ID", SqlDbType.Int).Value = ID_Position
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم حذف عملية التحصيل بنجاح.", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing

        Catch ex As Exception
            MsgBox("عفواً لا يمكن حذف هذا العمليه نظراً لانه توجد عمليات اخرى متعلقه بها يجب حذفها اولاً", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "خطأ نوع الخطأ")
            If Con.State = 1 Then Con.Close()
        End Try
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Try
            If DGV_Mand.Rows.Count < 1 Then
                Exit Sub
            End If
            Dim Position As Integer = DGV_Mand.CurrentRow.Index
            If Position >= 0 Then
                If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات العملية المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    Update_Thsil_Proc(Position)
                End If
                MsgBox("تم تعديل بيانات العملية المحددة بنجاح", MsgBoxStyle.Information, "تعديل")
                Load_ALL_Data()
            Else
                MessageBox.Show("يجب تحديد الصف المراد تعديله")
                Exit Sub
            End If
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Update_Thsil_Proc(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Thsil]
                                SET [Total] = @Total, [Date] = @Date , [Note] = @Note
                                WHERE Th_ID=@Th_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Th_ID", SqlDbType.Int).Value = CInt(DGV_Mand.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(2).Value)
                .Parameters.AddWithValue("@Date", SqlDbType.Date).Value = CDate(DGV_Mand.Rows(pos).Cells(3).Value)
                .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = DGV_Mand.Rows(pos).Cells(4).Value.ToString
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If DGV_Mand.Rows.Count < 1 Then
                Exit Sub
            End If
            Dim count As Integer = DGV_Mand.Rows.Count
            If count > 0 Then
                If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع العملاء؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    For i = 0 To count - 1
                        Update_Thsil_Proc(i)
                    Next
                End If
                MsgBox("تم تعديل بيانات جميع العمليات بنجاح", MsgBoxStyle.Information, "تعديل")
                Load_ALL_Data()
            Else
                MessageBox.Show("لا توجد بيانات لتعديلها")
            End If
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSearchDate_Click(sender As Object, e As EventArgs) Handles BtnSearchDate.Click
        Try
            Search_By_2Date(CDate(Date1.Value), CDate(Date2.Value))
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Search_By_2Date(ByVal Date1 As Date, ByVal Date2 As Date)
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT Th.[Th_ID] ,M.[Name] , Th.[Total] , Th.[Date]  ,Th.[Note]	  
                                       FROM [dbo].[Thsil] As Th , [dbo].[Mohslin] As M
                                       Where Th.[Mhsl_ID]=M.[Mhsl_ID] AND Th.[Date] >= @Date1 And Th.[Date] <= @Date2", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Date1", SqlDbType.Date).Value = "#" & Date1.ToShortDateString & "#"
            cmd.Parameters.Add("@Date2", SqlDbType.Date).Value = "#" & Date2.ToShortDateString & "#"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Th_ID").ToString, dr("Name").ToString, dr("Total").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not ComboBox_mand_Name.Text = vbNullString Then
            Load_ALL_Date_ByMohsil()
        Else
            MsgBox("يجب تحديد المحصل اولاً", MsgBoxStyle.Critical, "خطأ")
            ComboBox_mand_Name.Focus()
        End If
        Total()
    End Sub
    Public Sub Load_ALL_Date_ByMohsil()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("SELECT Th.[Th_ID] ,M.[Name]  , Th.[Total] , Th.[Date]  ,Th.[Note]	  
                                       FROM [dbo].[Thsil] As Th , [dbo].[Mohslin] As M
                                       Where Th.[Mhsl_ID]=M.[Mhsl_ID] And M.[Name] Like @Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = "%" & ComboBox_mand_Name.Text & "%"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Th_ID").ToString, dr("Name").ToString, dr("Total").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not ComboBox_mand_Name.Text = vbNullString Then
            Load_ALL_Date_ByMohsil_And_Date(CDate(Date1.Value), CDate(Date2.Value))
        Else
            MsgBox("يجب تحديد المحصل اولاً", MsgBoxStyle.Critical, "خطأ")
            ComboBox_mand_Name.Focus()
        End If
        Total()
    End Sub
    Public Sub Load_ALL_Date_ByMohsil_And_Date(ByVal Date1 As Date, ByVal Date2 As Date)
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("SELECT Th.[Th_ID] ,M.[Name] , Th.[Total] , Th.[Date]  ,Th.[Note]	  
                                       FROM [dbo].[Thsil] As Th , [dbo].[Mohslin] As M
                                       Where Th.[Mhsl_ID]=M.[Mhsl_ID] And M.[Name] Like @Name AND Th.[Date] >= @Date1 And Th.[Date] <= @Date2", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = "%" & ComboBox_mand_Name.Text & "%"
            cmd.Parameters.Add("@Date1", SqlDbType.Date).Value = "#" & Date1.ToShortDateString & "#"
            cmd.Parameters.Add("@Date2", SqlDbType.Date).Value = "#" & Date2.ToShortDateString & "#"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Th_ID").ToString, dr("Name").ToString, dr("Total").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            Search_By_2Date(CDate(New DateTime(Year(Now), Month(Now), CInt(1))), CDate(Now))
            Total()
            Print()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
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
            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Thsil.dotx"
            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " تقرير عن جميع عمليات التحصيل لهذا الشهر  "
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
            .AddText(txtTotalThsil.Text, "TotalThsil")
            .AddText(TxtTotalLateded.Text, "Lateds")
            .AddText(CStr(Now.ToShortDateString), "DateM")
            'إضافة الجدول الثاني

            '---------------------  Table 2 That Exist In Word Document ------------------
            With .AddTable()
                .DataTable = Get_All_Proces()
                '-------------------------------------
                '.MinimumRowsAtTheBeginningOfTable = 3
                .IsFirstColumnAutoNumber = False
                .TableHeadBookMarkName = "TableHead_1"
                .FirstRowBookMarkName = "TableFirstRow_1"
                .DeleteTableIfNoData = False
                '-------------------------------------

                .AddTextColumn("Th_ID")
                .AddTextColumn("Name")
                .AddTextColumn("Total")
                .AddTextColumn("Date")
                .AddTextColumn("Note")
            End With
            '####################################################################################
        End With
        Return PrintJob
    End Function
    Public Function Get_All_Proces()
        Dim dt1 As New DataTable
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Dim cmd As New SqlCommand("SELECT Th.[Th_ID] ,M.[Name] , Th.[Total] , Th.[Date]  ,Th.[Note]	  
                                       FROM [dbo].[Thsil] As Th , [dbo].[Mohslin] As M
                                       Where Th.[Mhsl_ID]=M.[Mhsl_ID] And Th.[Date] Like @Date", Con)
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = "%" & Year(Now) & "-" & Month(Now) & "-%"
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1

    End Function

End Class