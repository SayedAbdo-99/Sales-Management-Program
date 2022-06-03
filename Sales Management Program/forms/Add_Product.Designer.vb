<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Add_Product
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPrd_ID = New System.Windows.Forms.TextBox()
        Me.txtPrd_Code = New System.Windows.Forms.TextBox()
        Me.txtPrd_Name = New System.Windows.Forms.TextBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Btnsave = New System.Windows.Forms.Button()
        Me.txtPrd_BuyPrice = New System.Windows.Forms.TextBox()
        Me.txtPrd_Qunt = New System.Windows.Forms.TextBox()
        Me.txtPrd_Profit = New System.Windows.Forms.TextBox()
        Me.txtPrd_cashPrice = New System.Windows.Forms.TextBox()
        Me.txtPrd_QstSellPrice = New System.Windows.Forms.TextBox()
        Me.txtPrd_TotalBuy = New System.Windows.Forms.TextBox()
        Me.txtPrd_Bonas = New System.Windows.Forms.TextBox()
        Me.txtPrd_QstSellPrice5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(647, 54)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(235, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 29)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "اضافة منتج جديد"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Sales_Management_Program.My.Resources.Resources.x_mark_3_32
        Me.PictureBox1.Location = New System.Drawing.Point(604, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 647)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(647, 54)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "رقم المنتج :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "باركود المنتج :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(437, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 23)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "اسم المنتج :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(437, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 23)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "الكمية :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(437, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 23)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "سعر الشراء :"
        '
        'txtPrd_ID
        '
        Me.txtPrd_ID.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_ID.Location = New System.Drawing.Point(65, 71)
        Me.txtPrd_ID.Multiline = True
        Me.txtPrd_ID.Name = "txtPrd_ID"
        Me.txtPrd_ID.ReadOnly = True
        Me.txtPrd_ID.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_ID.TabIndex = 1
        Me.txtPrd_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_Code
        '
        Me.txtPrd_Code.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_Code.Location = New System.Drawing.Point(65, 115)
        Me.txtPrd_Code.Multiline = True
        Me.txtPrd_Code.Name = "txtPrd_Code"
        Me.txtPrd_Code.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_Code.TabIndex = 2
        Me.txtPrd_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_Name
        '
        Me.txtPrd_Name.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_Name.Location = New System.Drawing.Point(65, 159)
        Me.txtPrd_Name.Multiline = True
        Me.txtPrd_Name.Name = "txtPrd_Name"
        Me.txtPrd_Name.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_Name.TabIndex = 3
        Me.txtPrd_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.BtnClose.FlatAppearance.BorderSize = 3
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Image = Global.Sales_Management_Program.My.Resources.Resources.exit_2_32_blue
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnClose.Location = New System.Drawing.Point(65, 593)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(170, 48)
        Me.BtnClose.TabIndex = 13
        Me.BtnClose.Text = "اغلاق الشاشة"
        Me.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'Btnsave
        '
        Me.Btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btnsave.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btnsave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Btnsave.FlatAppearance.BorderSize = 3
        Me.Btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnsave.Image = Global.Sales_Management_Program.My.Resources.Resources.save_32_blue
        Me.Btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btnsave.Location = New System.Drawing.Point(262, 593)
        Me.Btnsave.Name = "Btnsave"
        Me.Btnsave.Size = New System.Drawing.Size(170, 48)
        Me.Btnsave.TabIndex = 12
        Me.Btnsave.Text = "حفظ البيانات"
        Me.Btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btnsave.UseVisualStyleBackColor = False
        '
        'txtPrd_BuyPrice
        '
        Me.txtPrd_BuyPrice.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_BuyPrice.Location = New System.Drawing.Point(65, 247)
        Me.txtPrd_BuyPrice.Multiline = True
        Me.txtPrd_BuyPrice.Name = "txtPrd_BuyPrice"
        Me.txtPrd_BuyPrice.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_BuyPrice.TabIndex = 5
        Me.txtPrd_BuyPrice.Text = "0.0"
        Me.txtPrd_BuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_Qunt
        '
        Me.txtPrd_Qunt.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_Qunt.Location = New System.Drawing.Point(65, 203)
        Me.txtPrd_Qunt.Multiline = True
        Me.txtPrd_Qunt.Name = "txtPrd_Qunt"
        Me.txtPrd_Qunt.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_Qunt.TabIndex = 4
        Me.txtPrd_Qunt.Text = "1"
        Me.txtPrd_Qunt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_Profit
        '
        Me.txtPrd_Profit.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_Profit.Location = New System.Drawing.Point(65, 335)
        Me.txtPrd_Profit.Multiline = True
        Me.txtPrd_Profit.Name = "txtPrd_Profit"
        Me.txtPrd_Profit.ReadOnly = True
        Me.txtPrd_Profit.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_Profit.TabIndex = 7
        Me.txtPrd_Profit.Text = "0.0"
        Me.txtPrd_Profit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_cashPrice
        '
        Me.txtPrd_cashPrice.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_cashPrice.Location = New System.Drawing.Point(65, 291)
        Me.txtPrd_cashPrice.Multiline = True
        Me.txtPrd_cashPrice.Name = "txtPrd_cashPrice"
        Me.txtPrd_cashPrice.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_cashPrice.TabIndex = 6
        Me.txtPrd_cashPrice.Text = "0.0"
        Me.txtPrd_cashPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_QstSellPrice
        '
        Me.txtPrd_QstSellPrice.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_QstSellPrice.Location = New System.Drawing.Point(65, 423)
        Me.txtPrd_QstSellPrice.Multiline = True
        Me.txtPrd_QstSellPrice.Name = "txtPrd_QstSellPrice"
        Me.txtPrd_QstSellPrice.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_QstSellPrice.TabIndex = 9
        Me.txtPrd_QstSellPrice.Text = "0.0"
        Me.txtPrd_QstSellPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_TotalBuy
        '
        Me.txtPrd_TotalBuy.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_TotalBuy.Location = New System.Drawing.Point(65, 379)
        Me.txtPrd_TotalBuy.Multiline = True
        Me.txtPrd_TotalBuy.Name = "txtPrd_TotalBuy"
        Me.txtPrd_TotalBuy.ReadOnly = True
        Me.txtPrd_TotalBuy.Size = New System.Drawing.Size(367, 35)
        Me.txtPrd_TotalBuy.TabIndex = 8
        Me.txtPrd_TotalBuy.Text = "0.0"
        Me.txtPrd_TotalBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_Bonas
        '
        Me.txtPrd_Bonas.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_Bonas.Location = New System.Drawing.Point(65, 516)
        Me.txtPrd_Bonas.Multiline = True
        Me.txtPrd_Bonas.Name = "txtPrd_Bonas"
        Me.txtPrd_Bonas.Size = New System.Drawing.Size(367, 40)
        Me.txtPrd_Bonas.TabIndex = 11
        Me.txtPrd_Bonas.Text = "0.0"
        Me.txtPrd_Bonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrd_QstSellPrice5
        '
        Me.txtPrd_QstSellPrice5.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrd_QstSellPrice5.Location = New System.Drawing.Point(65, 467)
        Me.txtPrd_QstSellPrice5.Multiline = True
        Me.txtPrd_QstSellPrice5.Name = "txtPrd_QstSellPrice5"
        Me.txtPrd_QstSellPrice5.Size = New System.Drawing.Size(367, 40)
        Me.txtPrd_QstSellPrice5.TabIndex = 10
        Me.txtPrd_QstSellPrice5.Text = "0.0"
        Me.txtPrd_QstSellPrice5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(437, 474)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 23)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "سعر البيع قسط 5 شهور :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(437, 430)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 23)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "سعر البيع قسط :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(437, 386)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 23)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "اجمالى سعر الشراء :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(437, 342)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 23)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "الربح للقطعة :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(437, 298)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 23)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "سعر الكاش :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(437, 518)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(158, 23)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "البونس لمندوب البيع :"
        '
        'Add_Product
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 701)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPrd_Bonas)
        Me.Controls.Add(Me.txtPrd_QstSellPrice5)
        Me.Controls.Add(Me.txtPrd_QstSellPrice)
        Me.Controls.Add(Me.txtPrd_TotalBuy)
        Me.Controls.Add(Me.txtPrd_Profit)
        Me.Controls.Add(Me.txtPrd_cashPrice)
        Me.Controls.Add(Me.txtPrd_BuyPrice)
        Me.Controls.Add(Me.txtPrd_Qunt)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Btnsave)
        Me.Controls.Add(Me.txtPrd_Name)
        Me.Controls.Add(Me.txtPrd_Code)
        Me.Controls.Add(Me.txtPrd_ID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Add_Product"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPrd_ID As System.Windows.Forms.TextBox
    Friend WithEvents txtPrd_Code As System.Windows.Forms.TextBox
    Friend WithEvents txtPrd_Name As System.Windows.Forms.TextBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Btnsave As System.Windows.Forms.Button
    Friend WithEvents txtPrd_BuyPrice As TextBox
    Friend WithEvents txtPrd_Qunt As TextBox
    Friend WithEvents txtPrd_Profit As TextBox
    Friend WithEvents txtPrd_cashPrice As TextBox
    Friend WithEvents txtPrd_QstSellPrice As TextBox
    Friend WithEvents txtPrd_TotalBuy As TextBox
    Friend WithEvents txtPrd_Bonas As TextBox
    Friend WithEvents txtPrd_QstSellPrice5 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
End Class
