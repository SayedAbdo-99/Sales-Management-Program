Imports System.Data.SqlClient
Imports MSwordDllFiles

Public Class Frm_Load

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


    Private Sub Frm_Unit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_Mandobin()
        Load_Procs()
        CheckBox1.Location = Label5.Location - New Size(30, -5)

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
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        'Me.Close()
        Load_Toktok.ShowDialog()
        Load_Procs()
    End Sub


    Public Sub Get_Data_To_Edit()
        Try

            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" Select * from Unit_Tbl where Unit_ID =@Unit_ID", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("Unit_ID", SqlDbType.Int).Value = DGV_Unit.CurrentRow.Cells(0).Value.ToString
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Add_User.txtID.Text = dr("Unit_ID").ToString
                Add_User.txtUserName.Text = dr("UnitName").ToString

            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
        Me.Close()
        Add_User.ShowDialog()
    End Sub

    Public Sub Delete_Load_Poc(ByVal DGV_Unit As DataGridView)
        Try

            Dim Position As Integer = DGV_Unit.CurrentRow.Index
        Dim ID_Position As Integer = DGV_Unit.Rows(Position).Cells(0).Value
        Dim Cmd As New SqlCommand
        With Cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandText = "Delete  From Load Where Load_ID = @Load_ID"
            .Parameters.Clear()
            .Parameters.AddWithValue("@Load_ID", SqlDbType.Int).Value = ID_Position
        End With
        If Con.State = 1 Then Con.Close()
        Con.Open()
        Cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("تم حذف بيانات السجل بنجاح.", MsgBoxStyle.Information, "حذف")
            Cmd = Nothing

        Catch ex As Exception
            MsgBox("عفواً لا يمكن حذف هذة العملية لانها ترتبط بالجداول الاخرى.", MsgBoxStyle.Information, "حذف")
            If Con.State = 1 Then Con.Close()

        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("هل أنت متأكد من انك تريد مواصلة عملية الحذف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Delete_Load_Poc(DGV_Unit)
        End If
        Load_Procs()
    End Sub

    Private Sub BtnExcel_Click(sender As System.Object, e As System.EventArgs) Handles BtnExcel.Click
        dgv_ExportDataToExcelFile(DGV_Unit)
    End Sub

    Private Sub BtnWord_Click(sender As System.Object, e As System.EventArgs) Handles BtnWord.Click
        ExportToWord(DGV_Unit, " تقرير عن جميع عمليات التحميل والاسترجاع للتكــــــاتك ")
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
            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Load.dotx"
            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = " تقرير عن عمليات التحميل والاسترجاع للتكــــــاتك  "
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
                .DataTable = Get_All_Proces()
                '-------------------------------------
                '.MinimumRowsAtTheBeginningOfTable = 3
                .IsFirstColumnAutoNumber = False
                .TableHeadBookMarkName = "TableHead_1"
                .FirstRowBookMarkName = "TableFirstRow_1"
                .DeleteTableIfNoData = False
                '-------------------------------------

                .AddTextColumn("Load_ID")
                .AddTextColumn("Tokt_ID")
                .AddTextColumn("Mand_Name")
                .AddTextColumn("Type")
                .AddTextColumn("Pro_Name")
                .AddTextColumn("Date")
                .AddTextColumn("Qunt")
                .AddTextColumn("TotalBuy")
                .AddTextColumn("TotalSell")

            End With
            '####################################################################################
        End With
        Return PrintJob
    End Function
    Public Function Get_All_Proces()
        Try
            Dim dt1 As New DataTable
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT L.Load_ID ,L.Tokt_ID ,M.Mand_Name ,REPLACE(REPLACE(L.Type, '1', 'تحميل'),'0','استرجاع') AS Type, S.Pro_Name, convert(varchar,L.Date,111) As Date, L.Qunt, L.Qunt* S.BuyPrice AS TotalBuy,L.Qunt* S.CashPrice  AS TotalSell
                                        FROM [dbo].[Load] As L ,[dbo].[Store] As S, [dbo].[Mandobin] As M where L.Mand_ID=M.Mand_ID And L.Prod_ID=S.pro_Id AND L.Date >= @Date1 And L.Date <= @Date2", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Date1", SqlDbType.Date).Value = "#" & Date1.Value & "#"
            cmd.Parameters.Add("@Date2", SqlDbType.Date).Value = "#" & Date2.Value & "#"
            Dim adp As New SqlDataAdapter(cmd)

            adp.Fill(dt1)
            Con.Close()
            Return dt1
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click
        Print()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch_Tokto.Click

        Load_Search1()

    End Sub
    Public Sub Load_Search1()
        Try
            Dim Type As String
            Type = ""
            If ComboBox1.Text = "تحميل" Then
                Type = "1"
                'MsgBox("يجب ادخال عدد الاقساط ", vbCritical, "خطأ")
                'Qst_Number.Focus()
                'Exit Sub
            ElseIf ComboBox1.Text = "استرجاع" Then
                Type = "0"
            End If
            Dim serDate As String
            serDate = ""
            If CheckBox1.Checked = True Then
                serDate = Year(combox_Data.Value).ToString & "-" & Month(combox_Data.Value).ToString & "-" & combox_Data.Value.Day.ToString
            End If

            DGV_Unit.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT L.Load_ID ,L.Tokt_ID ,M.Mand_Name ,L.Type, S.Pro_Name, L.Date, L.Qunt, L.Qunt* S.BuyPrice AS TotalBuy,L.Qunt* S.CashPrice  AS TotalSell
                                        FROM [dbo].[Load] As L ,[dbo].[Store] As S, [dbo].[Mandobin] As M 
                                        where L.Mand_ID=M.Mand_ID And L.Prod_ID=S.pro_Id 
                                        AND L.Tokt_ID Like '%" & ComboBox_Toktok_Number.Text & "'
                                        AND M.Mand_Name Like '%" & ComboBox_mand_Name.Text & "'
                                        And L.Type Like '%" & Type & "'
                                        AND L.Date Like '%" & serDate & "%' ", Con)
            'cmd.Parameters.Clear()
            'cmd.Parameters.Add("@Date", SqlDbType.Date).Value = "'%" & serDate & "%' " ' "#" & combox_Data.Value.ToString("dd/MM/yyyy") & "#"

            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Unit.Rows.Add(dr("Load_ID").ToString, dr("Tokt_ID").ToString, dr("Mand_Name").ToString, dr("Type").ToString.Replace("0", "استرجاع").Replace("1", "تحميل"), dr("Pro_Name").ToString, FormatDateTime(dr("Date"), DateFormat.ShortDate), dr("Qunt").ToString, dr("TotalBuy").ToString, dr("TotalSell").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Con.Close()
        End Try

    End Sub
    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        Load_Procs()
    End Sub
    Public Sub Load_Procs()
        Try
            DGV_Unit.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT L.Load_ID ,L.Tokt_ID ,M.Mand_Name ,L.Type, S.Pro_Name, L.Date, L.Qunt, L.Qunt* S.BuyPrice AS TotalBuy,L.Qunt* S.CashPrice  AS TotalSell
                                        FROM [dbo].[Load] As L ,[dbo].[Store] As S, [dbo].[Mandobin] As M where L.Mand_ID=M.Mand_ID And L.Prod_ID=S.pro_Id", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Unit.Rows.Add(dr("Load_ID").ToString, dr("Tokt_ID").ToString, dr("Mand_Name").ToString, dr("Type").ToString.Replace("0", "استرجاع").Replace("1", "تحميل"), dr("Pro_Name").ToString, FormatDateTime(dr("Date"), DateFormat.ShortDate), dr("Qunt").ToString, dr("TotalBuy").ToString, dr("TotalSell").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "خطأ")
            If Con.State = 1 Then Con.Close()

        End Try

    End Sub


    Private Sub BtnSearchDate_Click(sender As Object, e As EventArgs) Handles BtnSearchDate.Click
        Search_By_Sale_2Date(Date1.Value, Date2.Value)
    End Sub
    Public Sub Search_By_Sale_2Date(ByVal Date1 As Date, ByVal Date2 As Date)
        Try
            DGV_Unit.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" SELECT L.Load_ID ,L.Tokt_ID ,M.Mand_Name ,L.Type, S.Pro_Name, L.Date, L.Qunt, L.Qunt* S.BuyPrice AS TotalBuy,L.Qunt* S.CashPrice  AS TotalSell
                                        FROM [dbo].[Load] As L ,[dbo].[Store] As S, [dbo].[Mandobin] As M where L.Mand_ID=M.Mand_ID And L.Prod_ID=S.pro_Id AND L.Date >= @Date1 And L.Date <= @Date2", Con)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Date1", SqlDbType.Date).Value = "#" & Date1 & "#"
            cmd.Parameters.Add("@Date2", SqlDbType.Date).Value = "#" & Date2 & "#"
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Unit.Rows.Add(dr("Load_ID").ToString, dr("Tokt_ID").ToString, dr("Mand_Name").ToString, dr("Type").ToString.Replace("0", "استرجاع").Replace("1", "تحميل"), dr("Pro_Name").ToString, FormatDateTime(dr("Date"), DateFormat.ShortDate), dr("Qunt").ToString, dr("TotalBuy").ToString, dr("TotalSell").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Con.Close()
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox_mand_Name.Text = vbNullString
        ComboBox_Toktok_Number.Text = vbNullString
        ComboBox1.Text = vbNullString
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Try
            If DGV_Unit.Rows.Count < 1 Then
                Exit Sub
            End If
            Dim Position As Integer = DGV_Unit.CurrentRow.Index
            If Position >= 0 Then
                If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل البيانات المحددة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    Update_Load(Position)
                End If
                MsgBox("تم تعديل بيانات العملية المحددة بنجاح", MsgBoxStyle.Information, "تعديل")
                Load_Search1()

            Else
                MessageBox.Show("يجب تحديد الصف المراد تعديله")
                Exit Sub
            End If
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Update_Load(ByVal pos As Integer)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Load]
                                SET [Tokt_ID] = @Tokt_ID, [Date] = @Date, [Qunt] = @Qunt
                                WHERE [Load_ID]=@Load_ID"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Load_ID", SqlDbType.Int).Value = CInt(DGV_Unit.Rows(pos).Cells(0).Value)
                .Parameters.AddWithValue("@Tokt_ID", SqlDbType.Int).Value = CInt(DGV_Unit.Rows(pos).Cells(1).Value)
                .Parameters.AddWithValue("@Date", SqlDbType.Date).Value = CDate(DGV_Unit.Rows(pos).Cells(5).Value)
                .Parameters.AddWithValue("@Qunt", SqlDbType.Int).Value = CInt(DGV_Unit.Rows(pos).Cells(6).Value)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If DGV_Unit.Rows.Count < 1 Then
                Exit Sub
            End If
            Dim count As Integer = DGV_Unit.Rows.Count
            If count > 0 Then
                If MessageBox.Show("هل أنت متأكد من مواصلة عملية تعديل بيانات جميع العملاء؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                Else
                    For i = 0 To count - 1
                        Update_Load(i)
                    Next
                End If
                MsgBox("تم تعديل بيانات جميع العملاء بنجاح", MsgBoxStyle.Information, "تعديل")
                Load_Search1()

            Else
                MessageBox.Show("يجب تحديد الصف المراد تعديله")
            End If
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class