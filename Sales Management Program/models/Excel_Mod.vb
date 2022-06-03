Imports Microsoft.Office.Interop.Excel
Module Excel_Mod
    Public Sub dgv_ExportDataToExcelFile(ByVal dgv As DataGridView)
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("ar-SA")
        Dim SFD As New SaveFileDialog
        Dim exlapp As New Application
        Dim exlworkbook As Workbook
        Dim exlworksheet As Worksheet
        Dim misvalue As Object = System.Reflection.Missing.Value
        exlworkbook = exlapp.Workbooks.Add(misvalue)
        exlworksheet = exlworkbook.Sheets(1)
        exlworksheet.DisplayRightToLeft = True
        For colhead As Integer = 0 To dgv.ColumnCount - 1
            exlworksheet.Cells(1, colhead + 1) = dgv.Columns(colhead).HeaderText
        Next
        For i As Integer = 0 To dgv.RowCount - 1
            For j As Integer = 0 To dgv.ColumnCount - 1
                exlworksheet.Cells(i + 2, j + 1) = dgv.Rows(i).Cells(j).Value.ToString
            Next
        Next
        SFD.Filter = "Excel Files|*.xlsx|Excel 2003|*.xls"
        If SFD.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            exlworksheet.SaveAs(SFD.FileName)
        End If
        exlworkbook.Close()
        exlapp.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(exlapp)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(exlworkbook)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(exlworksheet)
        exlapp = Nothing : exlworkbook = Nothing : exlworksheet = Nothing
            If MessageBox.Show("هل تريد فتح الملف ؟", "فتح ملف الأكسل", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) = MsgBoxResult.Yes Then
                Process.Start(SFD.FileName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End Try
    End Sub
End Module
