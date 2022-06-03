Imports System.Data.SqlClient

Module Main_Mod
    Public TempFileNames2 As String
    Public Function Max_ID(TableName As String, ColumnName As String)

        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Max(" & ColumnName & ") From " & TableName & " ", Con)
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

    Public Sub fillcmb_Cat_Tbl(ByVal cmb As ComboBox)
        Dim DT As New DataTable
        Dim DA As New SqlDataAdapter
        DT.Clear()
        DA = New SqlDataAdapter("Select * FROM Cat_Tbl ", Con)
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            cmb.DataSource = DT
            cmb.DisplayMember = "CatName"
            cmb.ValueMember = "Cat_ID"
        Else
            cmb.DataSource = Nothing
        End If
    End Sub
    Public Sub fillcmb_Unit_Tbl(ByVal cmb As ComboBox)
        Dim DT As New DataTable
        Dim DA As New SqlDataAdapter
        DT.Clear()
        DA = New SqlDataAdapter("Select * FROM Unit_Tbl ", Con)
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            cmb.DataSource = DT
            cmb.DisplayMember = "UnitName"
            cmb.ValueMember = "Unit_ID"
        Else
            cmb.DataSource = Nothing
        End If
    End Sub
    Public Sub ChoosePicture(Pbox As PictureBox)
        Dim a As New OpenFileDialog
        With a
            .AddExtension = True
            .CheckPathExists = True
            .CheckFileExists = True
            .Title = "Choose Image"
            .Filter = "Choose Image (*.PNG; *.JPG; *.GIF; *.JPEG)| *.PNG; *.JPG; *.GIF; *.JPEG | All Files (*.*)|*.*"
            If .ShowDialog = DialogResult.OK Then
                Pbox.Image = Image.FromFile(.FileName)
            End If
        End With
    End Sub

End Module
