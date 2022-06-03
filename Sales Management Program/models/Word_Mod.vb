Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Word
Module Word_Mod


    Public Sub ExportToWord(ByVal dgv As DataGridView, Heading As String)
        Try

            Dim oWord As Word.Application = DirectCast(CreateObject("Word.Application"), Word.Application)
        Dim oDoc As Word.Document = oWord.Documents.Add()
        'Insert a paragraph at the beginning of the document.
        Dim oPara1 As Word.Paragraph
        oPara1 = oDoc.Content.Paragraphs.Add
        oPara1.Range.Text = Heading
        oPara1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter
        oPara1.Range.InsertParagraphAfter()
        '-------------------------
        Dim headers = (From ch In dgv.Columns
                       Let header = DirectCast(DirectCast(ch, DataGridViewColumn).HeaderCell, DataGridViewColumnHeaderCell)
                       Select header.Value).ToArray()
        Dim headerText() As String = Array.ConvertAll(headers, Function(v) v.ToString)
        Dim items() = (From r In dgv.Rows Let row = DirectCast(r, DataGridViewRow) Where Not row.IsNewRow
                       Select (From cell In row.Cells Let c = DirectCast(cell, DataGridViewCell) Select c.Value).ToArray()).ToArray()
        Dim table As String = String.Join(vbTab, headerText) & Environment.NewLine
        For Each a In items
            Dim t() As String = Array.ConvertAll(a, Function(v) v.ToString)
            table &= String.Join(vbTab, t) & Environment.NewLine
        Next
        table = table.TrimEnd(CChar(Environment.NewLine))
        Clipboard.SetText(table)
        Dim oTable As Word.Table = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, items.Count + 1, headers.Count)
        oTable.Range.Paste()
        oTable.TableDirection = WdTableDirection.wdTableDirectionRtl
        'make the first row bold, fs 14 + change textcolor
        oTable.Rows.Item(1).Range.Font.Bold = &H98967E
        oTable.Rows.Item(1).Range.Font.Size = 14
        oTable.Rows.Item(1).Range.Font.Color = Word.WdColor.wdColorWhite
        'change backcolor of first row
        oTable.Rows.Item(1).Range.Shading.Texture = Word.WdTextureIndex.wdTextureNone
        oTable.Rows.Item(1).Range.Shading.ForegroundPatternColor = Word.WdColor.wdColorAutomatic
        oTable.Rows.Item(1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorPaleBlue
        oTable.Borders.OutsideColor = Word.WdColor.wdColorBlack
        oTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle
        oTable.Borders.InsideColor = Word.WdColor.wdColorBlack
        oTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle
            oWord.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "خطأ")
            Exit Sub
        End Try
    End Sub
End Module
