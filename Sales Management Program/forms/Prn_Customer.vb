Imports System.Data.SqlClient
Imports System.IO
Imports MSwordDllFiles

Public Class Prn_Customer
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
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Load_city()
        ComboBox_City.Items.Clear()

        Try
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select DISTINCT City From Customers", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox_City.Items.Add(dr("City").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Edit_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Mohslin()
        Load_city()
        LoadCustomers()
        CheckBox1.Location = Label7.Location + New Size(35, 15)
        Total()
    End Sub

    Public Function GetLated(ByVal MohasilName As String)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand(" SELECT  COALESCE(Sum(Modin),0) As Modin  FROM [dbo].[Mohslin] where Name Like '%" & MohasilName & "'", Con)
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

    Public Sub Total()

        Dim Total1 As Decimal = "0.00"
        If Not ComboBox_Mohasl_Name.Text = vbNullString Then
            Total1 = CDec(GetLated(ComboBox_Mohasl_Name.Text))
        Else
            Total1 = CDec(GetLated(""))
        End If

        Dim Total2 As Decimal = "0.00"
        Dim Total3 As Decimal = "0.00"
        Dim Total4 As Decimal = "0.00"
        Dim Total5 As Decimal = "0.00"
        Dim Total6 As Decimal = "0.00"

        For Each row As DataGridViewRow In DGV_Cus.Rows
            Total2 += CDec(row.Cells(11).Value)
            Total3 += CDec(row.Cells(12).Value)
            Total4 += CDec(row.Cells(15).Value)
            Total5 += CDec(row.Cells(16).Value)
            Total6 += CDec(row.Cells(14).Value)

        Next
        txtLated.Text = Total1
        txtSell.Text = Total2
        txtPaid.Text = Total3
        txtQstPaid.Text = Total4
        txtRest.Text = Total5
        txtQst.Text = Total6

        txtCount.Text = DGV_Cus.Rows.Count
    End Sub

    Public Sub reset()
        DGV_Cus.Rows.Clear()
        Me.ComboBox_City.Text = vbNullString
        Me.ComboBox_Mohasl_Name.Text = vbNullString
        Me.TxtSearch_Name.Text = vbNullString
    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        TxtSearch_Name.Clear()
        TxtSearch_ID.Clear()
        LoadCustomers()
        Total()
    End Sub
    Public Sub LoadCustomers()
        Try
            DGV_Cus.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand(" Select * from Customers", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Cus.Rows.Add(dr("cust_Id").ToString, dr("cust_Name").ToString, dr("Phone").ToString, dr("City").ToString, dr("Area").ToString, dr("Products").ToString, dr("mnd_Name").ToString, dr("NumQst").ToString, dr("NumQstFinal").ToString, FormatDateTime(dr("DateBuy"), DateFormat.ShortDate), FormatDateTime(dr("DateFirstQst"), DateFormat.ShortDate), dr("SellPrice").ToString, dr("Paid").ToString, dr("Rest").ToString, dr("Qst").ToString, dr("TotalQst").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("هل أنت متأكد من حذف العميل من عملية الطباعة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            DGV_Cus.Rows.Remove(DGV_Cus.CurrentRow)
        End If
        Total()
    End Sub

    Public Sub Search_By_Name()
        Try
            DGV_Cus.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select * from Customers  where cust_Name LIKE'%" & TxtSearch_Name.Text & "%'", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Cus.Rows.Add(dr("cust_Id").ToString, dr("cust_Name").ToString, dr("Phone").ToString, dr("City").ToString, dr("Area").ToString, dr("Products").ToString, dr("mnd_Name").ToString, dr("NumQst").ToString, dr("NumQstFinal").ToString, FormatDateTime(dr("DateBuy"), DateFormat.ShortDate), FormatDateTime(dr("DateFirstQst"), DateFormat.ShortDate), dr("SellPrice").ToString, dr("Paid").ToString, dr("Rest").ToString, dr("Qst").ToString, dr("TotalQst").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            Con.Close()
        End Try

    End Sub
    Public Sub Search_By_City()
        Try
            DGV_Cus.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select * from Customers  where City LIKE'%" & ComboBox_City.Text & "%'", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Cus.Rows.Add(dr("cust_Id").ToString, dr("cust_Name").ToString, dr("Phone").ToString, dr("City").ToString, dr("Area").ToString, dr("Products").ToString, dr("mnd_Name").ToString, dr("NumQst").ToString, dr("NumQstFinal").ToString, FormatDateTime(dr("DateBuy"), DateFormat.ShortDate), FormatDateTime(dr("DateFirstQst"), DateFormat.ShortDate), dr("SellPrice").ToString, dr("Paid").ToString, dr("Rest").ToString, dr("Qst").ToString, dr("TotalQst").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch_Name.TextChanged
        If Not TxtSearch_Name.Text = vbNullString Then
            ComboBox_City.Text = vbNullString
            TxtSearch_ID.Text = vbNullString
            Search_By_Name()
            Total()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Print(0, 0)
    End Sub
    Public Sub Print(ByVal count As Integer, ByVal index As Integer)

        Try
            '--------------------------------------------------------------
            ' مهم جداً أن تستدعي هذا الأمر قبل كتابة أي سطر برمجي يخص الطباعة
            MSO.SetDllFiles()
            '--------------------------------------------------------------
            Dim MyWord As MSO.MSWord
            MyWord = New MSO.MSWord(Me)

            Dim TemplatePath As String = My.Application.Info.DirectoryPath & "\Qst.dotx"

            Dim TemplateInfo As New MSO.TemplateInfo(TemplatePath)
            With TemplateInfo
                '-------------------------------------
                .Caption = "طباعة وصل "
                .PrintJob = GetPrintableJob(count, index)
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

    Private Function GetPrintableJob(ByVal count As Integer, ByVal index As Integer) As MSO.Printing.PrintJob

        Dim PrintJob As New MSO.Printing.PrintJob
        With PrintJob
            If count = 0 And index = 0 Then
                .AddText("", "cust_Name1")
            ElseIf count = 1 And index = -1 Then
                If CInt(DGV_Cus.CurrentRow.Cells(16).Value) <= 0 Then
                    index += 1
                    MsgBox("هذا العميل (" & DGV_Cus.CurrentRow.Cells(1).Value & "  )قد انهى جميع الاقساط والمبالغ عليه", MsgBoxStyle.Information, "خطأ")
                    .AddText("", "cust_Name1")

                Else

                    Dim totalRest As Decimal
                    Dim NextQstValue As Decimal
                    Dim QstRest As Integer
                    QstRest = CInt(DGV_Cus.CurrentRow.Cells(8).Value) - 1
                    totalRest = CDec(DGV_Cus.CurrentRow.Cells(16).Value) - CDec(DGV_Cus.CurrentRow.Cells(14).Value)
                    .AddText(DGV_Cus.CurrentRow.Cells(0).Value, "Id1")
                    .AddText(DGV_Cus.CurrentRow.Cells(1).Value, "cust_Name1")
                    .AddText(DGV_Cus.CurrentRow.Cells(2).Value, "Phone1")
                    .AddText(DGV_Cus.CurrentRow.Cells(3).Value, "City11")
                    .AddText(DGV_Cus.CurrentRow.Cells(4).Value, "Area11")
                    .AddText(DGV_Cus.CurrentRow.Cells(5).Value, "Products1")
                    .AddText(DGV_Cus.CurrentRow.Cells(6).Value, "mnd_Name1")
                    .AddText(DGV_Cus.CurrentRow.Cells(7).Value, "NumQst1") 'NumRestQst1
                    .AddText(QstRest, "NumRestQst1") 'NumQstFinal1
                    .AddText(CStr(CInt(DGV_Cus.CurrentRow.Cells(7).Value) - QstRest), "NumQstFinal1") 'NumQst1
                    '.AddText(DGV_Cus.CurrentRow.Cells(9).Value, "DateBuy")
                    '.AddText(DGV_Cus.CurrentRow.Cells(10).Value, "DateFirstQst")
                    '.AddText(DGV_Cus.CurrentRow.Cells(11).Value, "SellPrice")
                    .AddText(DGV_Cus.CurrentRow.Cells(12).Value, "Paid1")
                    .AddText(DGV_Cus.CurrentRow.Cells(14).Value, "Qst1")
                    .AddText(totalRest, "TotalRest1")
                    .AddText("بموجب هذة الكمبيالة اتعهد بدفع مبلغ { " & CStr(DGV_Cus.CurrentRow.Cells(14).Value) & "} جنية فقط لا غير فى تاريخ {" & CStr(DGV_Cus.CurrentRow.Cells(10).Value) & "} علما بان القيمة وصلتنا بضاعة والدفع والتقاضى وفقا لادارة الدائن وللدائن الحق فى تحويل هذة الكمبيالة لمن يشاء دون التوقف على رضائى تحرير فى يوم {" & CStr(DGV_Cus.CurrentRow.Cells(9).Value) & "}.", "Mesg1")
                    .AddText(ComboBox_Mohasl_Name.Text, "Mohasl_Name1")

                    Dim cashValue As Decimal
                    cashValue = 0
                    Dim QstVal As Decimal
                    QstVal = 0
                    Dim Mohasil_Bonas As Decimal
                    Mohasil_Bonas = 0
                    If CInt(DGV_Cus.CurrentRow.Cells(7).Value) > 5 Then
                        Mohasil_Bonas = 0.1 * CDec(DGV_Cus.CurrentRow.Cells(14).Value)
                        QstVal = CDec(DGV_Cus.CurrentRow.Cells(14).Value)

                    Else
                        Mohasil_Bonas = 0.04 * CDec(DGV_Cus.CurrentRow.Cells(14).Value)
                        cashValue = CDec(DGV_Cus.CurrentRow.Cells(14).Value)
                    End If

                    Dim sta As String
                    sta = "مستمر"
                    If totalRest <= 0 Then
                        sta = "خالص"
                        QstRest = 0
                        NextQstValue = 0
                    Else
                        sta = "مستمر"
                        NextQstValue = totalRest / QstRest
                    End If

                    Update_cust_Qst(CInt(DGV_Cus.CurrentRow.Cells(0).Value), sta, QstRest, DateAdd("m", 1, CDate(DGV_Cus.CurrentRow.Cells(10).Value)), NextQstValue, CDec(DGV_Cus.CurrentRow.Cells(15).Value) + CDec(DGV_Cus.CurrentRow.Cells(14).Value), totalRest)

                    Update_Mohsil_Bounas(ComboBox_Mohasl_Name.Text, Mohasil_Bonas, cashValue, QstVal)
                End If
            ElseIf count >= 1 Then
                For i As Integer = 1 To count
                    If CInt(DGV_Cus.Rows(index).Cells(16).Value) <= 0 Then
                        index += 1
                        MsgBox("هذا العميل (" & DGV_Cus.Rows(index).Cells(1).Value & "  )قد انهى جميع الاقساط والمبالغ عليه", MsgBoxStyle.Information, "خطأ")
                        Continue For
                    End If
                    Dim totalRest As Decimal
                    Dim NextQstValue As Decimal
                    Dim QstRest As Integer
                    QstRest = CInt(DGV_Cus.Rows(index).Cells(8).Value) - 1
                    totalRest = CDec(DGV_Cus.Rows(index).Cells(16).Value) - CDec(DGV_Cus.Rows(index).Cells(14).Value)
                    .AddText(DGV_Cus.Rows(index).Cells(0).Value, "Id" & i)
                    .AddText(DGV_Cus.Rows(index).Cells(1).Value, "cust_Name" & i)
                    .AddText(DGV_Cus.Rows(index).Cells(2).Value, "Phone" & i)
                    .AddText(DGV_Cus.Rows(index).Cells(3).Value, "City" & i & i)
                    .AddText(DGV_Cus.Rows(index).Cells(4).Value, "Area" & i & i)
                    .AddText(DGV_Cus.Rows(index).Cells(5).Value, "Products" & i)
                    .AddText(DGV_Cus.Rows(index).Cells(6).Value, "mnd_Name" & i)
                    .AddText(DGV_Cus.Rows(index).Cells(7).Value, "NumQst" & i) 'NumRestQst
                    .AddText(QstRest, "NumRestQst" & (i)) 'NumQstFinal
                    .AddText(CStr(CInt(DGV_Cus.Rows(index).Cells(7).Value) - QstRest), "NumQstFinal" & (i)) 'NumQst
                    '.AddText(DGV_Cus.CurrentRow.Cells(9).Value, "DateBuy")
                    '.AddText(DGV_Cus.CurrentRow.Cells(10).Value, "DateFirstQst")
                    '.AddText(DGV_Cus.CurrentRow.Cells(11).Value, "SellPrice")
                    .AddText(DGV_Cus.Rows(index).Cells(12).Value, "Paid" & (i))
                    .AddText(DGV_Cus.Rows(index).Cells(14).Value, "Qst" & (i))
                    .AddText(totalRest, "TotalRest" & (i))
                    .AddText("بموجب هذة الكمبيالة اتعهد بدفع مبلغ { " & CStr(DGV_Cus.Rows(index).Cells(14).Value) & "} جنية فقط لا غير فى تاريخ {" & CStr(DGV_Cus.Rows(index).Cells(10).Value) & "} علما بان القيمة وصلتنا بضاعة والدفع والتقاضى وفقا لادارة الدائن وللدائن الحق فى تحويل هذة الكمبيالة لمن يشاء دون التوقف على رضائى تحرير فى يوم {" & CStr(DGV_Cus.Rows(index).Cells(9).Value) & "}.", "Mesg" & (i))
                    .AddText(ComboBox_Mohasl_Name.Text, "Mohasl_Name" & (i))

                    Dim cashValue As Decimal
                    cashValue = 0
                    Dim QstVal As Decimal
                    QstVal = 0
                    Dim Mohasil_Bonas As Decimal
                    Mohasil_Bonas = 0
                    If CInt(DGV_Cus.Rows(index).Cells(7).Value) > 5 Then
                        Mohasil_Bonas = 0.1 * CDec(DGV_Cus.Rows(index).Cells(14).Value)
                        QstVal = CDec(DGV_Cus.Rows(index).Cells(14).Value)

                    Else
                        Mohasil_Bonas = 0.04 * CDec(DGV_Cus.Rows(index).Cells(14).Value)
                        cashValue = CDec(DGV_Cus.Rows(index).Cells(14).Value)
                    End If

                    Dim sta As String
                    sta = "مستمر"
                    If totalRest <= 0 Then
                        sta = "خالص"
                        QstRest = 0
                        NextQstValue = 0
                    Else
                        sta = "مستمر"
                        NextQstValue = totalRest / QstRest
                    End If


                    Update_cust_Qst(CInt(DGV_Cus.Rows(index).Cells(0).Value), sta, QstRest, DateAdd("m", 1, CDate(DGV_Cus.Rows(index).Cells(10).Value)), NextQstValue, CDec(DGV_Cus.Rows(index).Cells(15).Value) + CDec(DGV_Cus.Rows(index).Cells(14).Value), totalRest)

                    Update_Mohsil_Bounas(ComboBox_Mohasl_Name.Text, Mohasil_Bonas, cashValue, QstVal)
                    index += 1
                Next
            End If
        End With
        Return PrintJob
    End Function

    Public Sub Update_cust_Qst(ByVal id As Integer, ByVal state As String, ByVal NumRestQst As Integer, ByVal DateNext As Date, ByVal QstValue As Decimal, ByVal TotalQst As Decimal, ByVal TotalRest As Decimal)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "Update Customers SET 
                                            [State] = @State, [NumQstFinal] = @NumQstFinal, [DateFirstQst] = @DateFirstQst, [Qst] = @Qst, [TotalQst] = @TotalQst, [TotalRest] = @TotalRest
                              Where cust_Id = @cust_Id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@cust_Id", SqlDbType.Int).Value = id
                .Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = state

                .Parameters.AddWithValue("@NumQstFinal", SqlDbType.Int).Value = NumRestQst
                .Parameters.AddWithValue("@DateFirstQst", SqlDbType.Date).Value = DateNext
                .Parameters.AddWithValue("@Qst", SqlDbType.Decimal).Value = QstValue
                .Parameters.AddWithValue("@TotalQst", SqlDbType.Decimal).Value = TotalQst
                .Parameters.AddWithValue("@TotalRest", SqlDbType.Decimal).Value = TotalRest
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("حدث خطأ فى تعديل بيانات العميل الخاصة بالوصل يرجى طباعة الوصل مرة ثانية.", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End Try
    End Sub

    Public Sub Update_Mohsil_Bounas(ByVal MohslName As String, ByVal Bounas As Decimal, ByVal cash As Decimal, ByVal qst As Decimal)
        Try
            Dim Cmd As New SqlCommand
            With Cmd
                .Connection = Con
                .CommandType = CommandType.Text
                .CommandText = "UPDATE [dbo].[Mohslin]
                                SET [Daen]=[Daen]+@Bounas, [Modin] = [Modin] + @Modin , [ThsilCash]= [ThsilCash] + @ThsilCash, [ThsilQst]=[ThsilQst] + @ThsilQst ,[ThsilTotal] = [ThsilTotal]+@ThsilTotal 
                                WHERE [Name] = @Name "
                .Parameters.Clear()
                .Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = MohslName
                .Parameters.AddWithValue("@Bounas", SqlDbType.Decimal).Value = Bounas
                .Parameters.AddWithValue("@Modin", SqlDbType.Decimal).Value = qst + cash
                .Parameters.AddWithValue("@ThsilCash", SqlDbType.Decimal).Value = cash
                .Parameters.AddWithValue("@ThsilQst", SqlDbType.Decimal).Value = qst
                .Parameters.AddWithValue("@ThsilTotal", SqlDbType.Decimal).Value = qst + cash
            End With
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Cmd.ExecuteNonQuery()
            Con.Close()
            Cmd = Nothing
        Catch ex As Exception
            MsgBox("حدث خطأ فى عمليه اضافة قيمة القسط على متاخرات المحصل... يجب عليك اضافتها يدوياً .", MsgBoxStyle.Critical, "خطأ")
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ")
            If Con.State = 1 Then Con.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If ComboBox_Mohasl_Name.Text = vbNullString Then
            MsgBox("يجب اختيار محصل اولاً", MsgBoxStyle.Critical, "خطأ")
            ComboBox_Mohasl_Name.Focus()
            Exit Sub
        End If

        If DGV_Cus.SelectedRows.Count = 1 Then
            Print(1, -1)


        Else
            MsgBox("يجب تحديد عميل واحد اولاً", MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ComboBox_Mohasl_Name.Text = vbNullString Then
            MsgBox("يجب اختيار محصل اولاً", MsgBoxStyle.Critical, "خطأ")
            ComboBox_Mohasl_Name.Focus()
            Exit Sub
        End If
        Dim counter As Integer
        Dim index As Integer
        counter = DGV_Cus.Rows.Count
        index = 0
        If counter > 0 Then
            While counter <> 0
                If counter < 3 Then
                    Print(counter, index)
                    counter = 0
                    Exit Sub
                End If
                If counter >= 3 Then
                    Print(3, index)
                    counter -= 3
                    index += 3
                End If


            End While

        Else
            MsgBox("لا توجد بيانات للطباعة !!!!!!", MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End If

    End Sub

    Private Sub TxtSearch_ID_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch_ID.TextChanged
        If IsNumeric(TxtSearch_ID.Text) Then
            ComboBox_City.Text = vbNullString
            TxtSearch_Name.Text = vbNullString
            Search_By_ID()
            Total()
        End If
    End Sub

    Public Sub Search_By_ID()
        Try
            DGV_Cus.Rows.Clear()
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim cmd As New SqlCommand("Select * from Customers  where cust_Id = " & TxtSearch_ID.Text & "", Con)
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Cus.Rows.Add(dr("cust_Id").ToString, dr("cust_Name").ToString, dr("Phone").ToString, dr("City").ToString, dr("Area").ToString, dr("Products").ToString, dr("mnd_Name").ToString, dr("NumQst").ToString, dr("NumQstFinal").ToString, FormatDateTime(dr("DateBuy"), DateFormat.ShortDate), FormatDateTime(dr("DateFirstQst"), DateFormat.ShortDate), dr("SellPrice").ToString, dr("Paid").ToString, dr("Rest").ToString, dr("Qst").ToString, dr("TotalQst").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub


    Private Sub BtnSearchDate_Click(sender As Object, e As EventArgs) Handles BtnSearchDate.Click
        Search_ALL()
        Total()
    End Sub
    Public Sub Search_ALL()
        Try
            Dim serDate1 As String
            serDate1 = ""
            Dim serDate2 As String
            serDate2 = ""
            If CheckBox1.Checked = True Then
                serDate1 = Year(Date1.Value).ToString & "-" & Month(Date1.Value).ToString & "-" & Date1.Value.Day.ToString
                serDate1 = "AND ( DateBuy >= '" & serDate1 & "'"

                serDate2 = Year(Date2.Value).ToString & "-" & Month(Date2.Value).ToString & "-" & Date2.Value.Day.ToString
                serDate2 = "AND DateBuy <= '" & serDate2 & "')"
            End If

            DGV_Cus.Rows.Clear()

            Dim cmd As New SqlCommand("Select * from Customers  where Mohsil_ID = " & Buy_Inv.GetMohsil_ID(ComboBox_Mohasl_Name.Text) & " AND City LIKE'%" & ComboBox_City.Text & "'" & serDate1 & serDate2, Con)
            If Con.State = 1 Then Con.Close()
            Con.Open()
            Dim adp As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DGV_Cus.Rows.Add(dr("cust_Id").ToString, dr("cust_Name").ToString, dr("Phone").ToString, dr("City").ToString, dr("Area").ToString, dr("Products").ToString, dr("mnd_Name").ToString, dr("NumQst").ToString, dr("NumQstFinal").ToString, FormatDateTime(dr("DateBuy"), DateFormat.ShortDate), FormatDateTime(dr("DateFirstQst"), DateFormat.ShortDate), dr("SellPrice").ToString, dr("Paid").ToString, dr("Rest").ToString, dr("Qst").ToString, dr("TotalQst").ToString, dr("TotalRest").ToString)
            End While
            dr.Close()
            Con.Close()
        Catch ex As Exception
            If Con.State = 1 Then Con.Close()
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ComboBox_Mohasl_Name.Text = vbNullString
        ComboBox_City.Text = vbNullString
        CheckBox1.Checked = False
        txtSell.Text = vbNullString
        txtRest.Text = vbNullString
        LoadCustomers()
        Total()
    End Sub

End Class