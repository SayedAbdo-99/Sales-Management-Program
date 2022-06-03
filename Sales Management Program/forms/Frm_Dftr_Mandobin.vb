Imports System.Data.SqlClient
Imports MSwordDllFiles

Public Class Frm_Dftr_Mandobin
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
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Private Sub Frm_Manage_Buy_Inv_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Load_Mandobin()

        Load_ALL_Data()
        LblDateDay.Text = Date.Now.ToString("dddd")
        LblData.Text = Date.Now.ToString("dd/MM/yyyy")
        Total()
    End Sub
    Public Sub Total()

        Dim Total1 As Decimal = "0.00"
        Dim Total2 As Decimal = "0.00"
        Dim Total3 As Decimal = "0.00"
        Dim Total4 As Decimal = "0.00"
        Dim Total5 As Decimal = "0.00"
        Dim Total6 As Decimal = "0.00"
        For Each row As DataGridViewRow In DGV_Mand.Rows
            Total1 += CDec(row.Cells(2).Value)
            Total2 += CDec(row.Cells(3).Value)
            Total3 += CDec(row.Cells(4).Value)
            Total4 += CDec(row.Cells(5).Value)
            Total5 += CDec(row.Cells(6).Value)
            Total6 += CDec(row.Cells(7).Value)

        Next
        txtTotalCash.Text = Total1
        txtTotalQst.Text = Total2
        txtTotalTwrid.Text = Total3
        txtTotalOutgoings.Text = Total4
        TxtTotalLateded.Text = Total5
        txtTotalRest.Text = Total6

        InvoiceCount.Text = DGV_Mand.Rows.Count
    End Sub


    Public Sub Load_ALL_Data()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Tw.[Tw_ID] , M.[Mand_Name], Tw.[Cash], Tw.[Qst], Tw.[Outgoings], Tw.[Lateds], Tw.[TotalRest], Tw.[Date], Tw.[Note]
                                      From [dbo].[Twrid] As Tw , [dbo].[Mandobin] As M
                                      Where Tw.Mand_ID = M.Mand_ID", Con)
            'cmd.Parameters.Clear()
            'cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = "%-" & Month(Now) & "-%"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Tw_ID").ToString, dr("Mand_Name").ToString, dr("Cash").ToString, dr("Qst").ToString, (CDec(dr("Cash")) + CDec(dr("Qst"))).ToString, dr("Outgoings").ToString, dr("Lateds").ToString, dr("TotalRest").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Not ComboBox_mand_Name.Text = vbNullString Then
                Load_ALL_Date_ByMand()
            Else
                MsgBox("يجب تحديد المندوب اولاً", MsgBoxStyle.Critical, "خطأ")
                ComboBox_mand_Name.Focus()
            End If
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Load_ALL_Date_ByMand()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Tw.[Tw_ID] , M.[Mand_Name], Tw.[Cash], Tw.[Qst], Tw.[Outgoings], Tw.[Lateds], Tw.[TotalRest], Tw.[Date], Tw.[Note]
                                      From [dbo].[Twrid] As Tw , [dbo].[Mandobin] As M
                                      Where Tw.Mand_ID = M.Mand_ID And M.[Mand_Name] Like @Mand_Name", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Mand_Name", SqlDbType.NVarChar).Value = "%" & ComboBox_mand_Name.Text & "%"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Tw_ID").ToString, dr("Mand_Name").ToString, dr("Cash").ToString, dr("Qst").ToString, (CDec(dr("Cash")) + CDec(dr("Qst"))).ToString, dr("Outgoings").ToString, dr("Lateds").ToString, dr("TotalRest").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Sub Load_ALL_Data_ToDay()
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select Tw.[Tw_ID] , M.[Mand_Name], Tw.[Cash], Tw.[Qst], Tw.[Outgoings], Tw.[Lateds], Tw.[TotalRest], Tw.[Date], Tw.[Note]
                                      From [dbo].[Twrid] As Tw , [dbo].[Mandobin] As M
                                      Where Tw.Mand_ID = M.Mand_ID And Tw.[Date] Like @Date", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = "%" & Year(Now) & "-" & Month(Now) & "-" & Now.Day & "%"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Tw_ID").ToString, dr("Mand_Name").ToString, dr("Cash").ToString, dr("Qst").ToString, (CDec(dr("Cash")) + CDec(dr("Qst"))).ToString, dr("Outgoings").ToString, dr("Lateds").ToString, dr("TotalRest").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnToday_Click(sender As System.Object, e As System.EventArgs) Handles BtnToday.Click
        Try
            Load_ALL_Data_ToDay()
            Total()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles BtnShowAll.Click
        Try
            ComboBox_mand_Name.SelectedIndex = -1
            Load_ALL_Data()
            LblDateDay.Text = Date.Now.ToString("dddd")
            LblData.Text = Date.Now.ToString("dd/MM/yyyy")
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub




    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Add_Twrid.ShowDialog()
        Load_ALL_Data()
        Total()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            If MessageBox.Show("هل أنت متأكد من مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Delete_Twrid_Proce(DGV_Mand)
            End If
            Load_ALL_Data()
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Delete_Twrid_Proce(ByVal DGV_Imp As DataGridView)
        Try

            Dim Position As Integer = DGV_Imp.CurrentRow.Index
            Dim ID_Position As Integer = DGV_Imp.Rows(Position).Cells(0).Value
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Delete  From [dbo].[Twrid] Where Tw_ID = @Tw_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Tw_ID", SqlDbType.Int).Value = ID_Position
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("تم حذف عملية التوريد بنجاح.", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing

        Catch ex As Exception
            MsgBox("عفواً لا يمكن حذف هذا العمليه نظراً لانه توجد عمليات اخرى متعلقه بها يجب حذفها اولاً", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, " نوع الخطأ")
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
                    Update_Twrid_Proc(Position)
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
    Public Sub Update_Twrid_Proc(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Twrid]
                                SET [Cash] = @Cash, [Qst] = @Qst, [Outgoings] = @Outgoings, [Lateds] = @Lateds, [TotalRest] = @TotalRest, [Date] = @Date, [Note] = @Note
                                WHERE Tw_ID=@Tw_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Tw_ID", SqlDbType.Int).Value = CInt(DGV_Mand.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@Cash", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(2).Value)
                .Parameters.AddWithValue("@Qst", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(3).Value)
                .Parameters.AddWithValue("@Outgoings", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(5).Value)
                .Parameters.AddWithValue("@Lateds", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(6).Value)
                .Parameters.AddWithValue("@TotalRest", SqlDbType.Decimal).Value = CDec(DGV_Mand.Rows(pos).Cells(7).Value)
                .Parameters.AddWithValue("@Date", SqlDbType.Date).Value = CDate(DGV_Mand.Rows(pos).Cells(8).Value)
                .Parameters.AddWithValue("@Note", SqlDbType.NVarChar).Value = DGV_Mand.Rows(pos).Cells(9).Value.ToString
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
                        Update_Twrid_Proc(i)
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

    Public Sub Search_By_2Date(ByVal Date1 As Date, ByVal Date2 As Date)
        Try
            DGV_Mand.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" Select Tw.[Tw_ID] , M.[Mand_Name], Tw.[Cash], Tw.[Qst], Tw.[Outgoings], Tw.[Lateds], Tw.[TotalRest], Tw.[Date], Tw.[Note]
                                      From [dbo].[Twrid] As Tw , [dbo].[Mandobin] As M
                                      Where Tw.Mand_ID = M.Mand_ID AND Tw.Date >= @Date1 And Tw.Date <= @Date2", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Date1", SqlDbType.Date).Value = "#" & Date1.ToShortDateString & "#"
            cmd.Parameters.Add("@Date2", SqlDbType.Date).Value = "#" & Date2.ToShortDateString & "#"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Mand.Rows.Add(dr("Tw_ID").ToString, dr("Mand_Name").ToString, dr("Cash").ToString, dr("Qst").ToString, (CDec(dr("Cash")) + CDec(dr("Qst"))).ToString, dr("Outgoings").ToString, dr("Lateds").ToString, dr("TotalRest").ToString, CDate(dr("Date")).ToShortDateString, dr("Note").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub BtnSearchDate_Click_1(sender As Object, e As EventArgs) Handles BtnSearchDate.Click
        Try
            Search_By_2Date(CDate(Date1.Value), CDate(Date2.Value))
            Total()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Search_By_2Date(CDate(New DateTime(Year(Now), Month(Now), CInt(1))), CDate(Now))
        Total()
        Print()
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
            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Twrid.dotx"
            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " تقرير عن جميع عمليات التوريد لهذا الشهر  "
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
            .AddText(txtTotalCash.Text, "Cash")
            .AddText(txtTotalQst.Text, "Qst")
            .AddText(txtTotalTwrid.Text, "TotalTwrid")
            .AddText(txtTotalOutgoings.Text, "OutGoings")
            .AddText(TxtTotalLateded.Text, "Lateds")
            .AddText(txtTotalRest.Text, "TotalRest")
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

                .AddTextColumn("Tw_ID")
                .AddTextColumn("Mand_Name")
                .AddTextColumn("Cash")
                .AddTextColumn("Qst")
                .AddTextColumn("Outgoings")
                .AddTextColumn("Lateds")
                .AddTextColumn("TotalRest")
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
        Dim cmd As New SqlCommand("Select Tw.[Tw_ID] , M.[Mand_Name], Tw.[Cash], Tw.[Qst], Tw.[Outgoings], Tw.[Lateds], Tw.[TotalRest], Tw.[Date], Tw.[Note]
                                      From [dbo].[Twrid] As Tw , [dbo].[Mandobin] As M
                                      Where Tw.Mand_ID = M.Mand_ID And Tw.[Date] Like @Date", Con)
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = "%" & Year(Now) & "-" & Month(Now) & "-%"
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(dt1)
        Con.Close()
        Return dt1

    End Function

End Class