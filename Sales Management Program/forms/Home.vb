Public Class Home


    Private Sub اضافةمنتججديدToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles اضافةمنتججديدToolStripMenuItem.Click
        Add_Product.ShowDialog()
    End Sub

    Private Sub ادارةالمنتجاتToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ادارةالمنتجاتToolStripMenuItem.Click
        Dim frm As New Frm_Products
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

  
    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim frm As New Frm_Customer
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim frm As New Frm_Mohslin
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub



    Private Sub اضافةعميلجديدToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اضافةعميلجديدToolStripMenuItem.Click
        'Me.Hide()
        Buy_Inv.ShowDialog()
    End Sub

    Private Sub اضافةموردجديدToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اضافةموردجديدToolStripMenuItem.Click
        Add_Mohsil.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Load_Toktok.ShowDialog()
    End Sub


    Private Sub طباعةوصلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طباعةوصلToolStripMenuItem.Click
        Dim frm As New Prn_Customer
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub اضافةمندوبToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اضافةمندوبToolStripMenuItem.Click
        Load_Toktok.ShowDialog()
    End Sub

    Private Sub ادارةالتكاتكToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ادارةالتكاتكToolStripMenuItem.Click
        Dim frm As New Frm_Load
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        Add_Mand.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        Dim frm As New Frm_Mand
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        Add_Twrid.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        Dim frm As New Frm_Dftr_Mandobin
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem34_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem34.Click
        Add_Thsil.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem35_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem35.Click
        Dim frm As New Frm_Dftr_Mohslin
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem27.Click
        Add_Exp.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem28_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem28.Click
        Dim frm As New Frm_OutGoings
        frm.TopLevel = False
        HomePanel.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub طباعةتقريرعنالمخزنToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles طباعةتقريرعنالمخزنToolStripMenuItem.Click
        Frm_Products.Print()
    End Sub

    Private Sub طباعةتقريرعنالعملاءToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طباعةتقريرعنالعملاءToolStripMenuItem.Click
        Frm_Customer.Print()
    End Sub

    Private Sub طباعةتقريرعنعملياتاليومToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طباعةتقريرعنعملياتاليومToolStripMenuItem.Click
        Frm_Load.Print()
    End Sub

    Private Sub طباعةتقريرعنالمندوبينفىالشهرالحالىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طباعةتقريرعنالمندوبينفىالشهرالحالىToolStripMenuItem.Click
        Frm_Mand.Print()
    End Sub

    Private Sub طباعةتقريرعنالتوريداتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طباعةتقريرعنالتوريداتToolStripMenuItem.Click
        Frm_Dftr_Mandobin.Print()
    End Sub

    Private Sub طباعةتقريرعنعملياتالتحصيلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طباعةتقريرعنعملياتالتحصيلToolStripMenuItem.Click
        Frm_Dftr_Mohslin.Print()
    End Sub

    Private Sub طباعةتقريرعنالمصروفاتلهذاالشهرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طباعةتقريرعنالمصروفاتلهذاالشهرToolStripMenuItem.Click
        Frm_OutGoings.Print()
    End Sub

    Private Sub اضافةمستخدمToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اضافةمستخدمToolStripMenuItem.Click
        Add_User.ShowDialog()
    End Sub

    Private Sub ادارةالمستخدمينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ادارةالمستخدمينToolStripMenuItem.Click
        Frm_Users.ShowDialog()
    End Sub

    Private Sub ضبطاعدادتالاتصالToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ضبطاعدادتالاتصالToolStripMenuItem.Click
        Edit_Connection.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click

    End Sub

    Private Sub تسجيلخروجToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تسجيلخروجToolStripMenuItem.Click
        If Con.State = 1 Then Con.Close()
        Application.Exit()
    End Sub

    Private Sub انشاءنسخةاحتياطيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles انشاءنسخةاحتياطيةToolStripMenuItem.Click
        BackUP.ShowDialog()
    End Sub

    Private Sub استرجاعنسخةاحتياطيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles استرجاعنسخةاحتياطيةToolStripMenuItem.Click
        Restor.ShowDialog()
    End Sub

    Private Sub الاعداداتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الاعداداتToolStripMenuItem.Click
        Edit_Connection.ShowDialog()
    End Sub

    Private Sub Home_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Con.State = 1 Then Con.Close()
        Application.Exit()
    End Sub
End Class
