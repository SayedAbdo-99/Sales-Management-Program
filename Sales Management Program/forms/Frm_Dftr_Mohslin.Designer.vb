<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dftr_Mohslin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblData = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblDateDay = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnShowAll = New System.Windows.Forms.Button()
        Me.BtnToday = New System.Windows.Forms.Button()
        Me.InvoiceCount = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalThsil = New System.Windows.Forms.TextBox()
        Me.TxtTotalLateded = New System.Windows.Forms.TextBox()
        Me.txtTotalLated = New System.Windows.Forms.Label()
        Me.BtnSearchDate = New System.Windows.Forms.Button()
        Me.ComboBox_mand_Name = New System.Windows.Forms.ComboBox()
        Me.Date2 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Date1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGV_Mand = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DGV_Mand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.LblData)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.LblDateDay)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.BtnShowAll)
        Me.Panel1.Controls.Add(Me.BtnToday)
        Me.Panel1.Controls.Add(Me.InvoiceCount)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1454, 71)
        Me.Panel1.TabIndex = 0
        '
        'LblData
        '
        Me.LblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblData.AutoSize = True
        Me.LblData.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblData.ForeColor = System.Drawing.Color.Yellow
        Me.LblData.Location = New System.Drawing.Point(285, 22)
        Me.LblData.Name = "LblData"
        Me.LblData.Size = New System.Drawing.Size(91, 23)
        Me.LblData.TabIndex = 13
        Me.LblData.Text = "تاريخ اليوم :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(379, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 23)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "التاريخ :"
        '
        'LblDateDay
        '
        Me.LblDateDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblDateDay.AutoSize = True
        Me.LblDateDay.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDateDay.ForeColor = System.Drawing.Color.Yellow
        Me.LblDateDay.Location = New System.Drawing.Point(468, 22)
        Me.LblDateDay.Name = "LblDateDay"
        Me.LblDateDay.Size = New System.Drawing.Size(42, 23)
        Me.LblDateDay.TabIndex = 15
        Me.LblDateDay.Text = "اليوم"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(512, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 23)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = " اليوم :"
        '
        'BtnShowAll
        '
        Me.BtnShowAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnShowAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnShowAll.FlatAppearance.BorderSize = 2
        Me.BtnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnShowAll.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShowAll.ForeColor = System.Drawing.Color.White
        Me.BtnShowAll.Image = Global.Sales_Management_Program.My.Resources.Resources._1420853324_Look
        Me.BtnShowAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnShowAll.Location = New System.Drawing.Point(788, 15)
        Me.BtnShowAll.Name = "BtnShowAll"
        Me.BtnShowAll.Size = New System.Drawing.Size(232, 41)
        Me.BtnShowAll.TabIndex = 11
        Me.BtnShowAll.Text = "عرض جميع التحصيلات"
        Me.BtnShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnShowAll.UseVisualStyleBackColor = False
        '
        'BtnToday
        '
        Me.BtnToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnToday.BackColor = System.Drawing.Color.Maroon
        Me.BtnToday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnToday.FlatAppearance.BorderSize = 2
        Me.BtnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnToday.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.Color.White
        Me.BtnToday.Image = Global.Sales_Management_Program.My.Resources.Resources._1420853324_Look
        Me.BtnToday.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnToday.Location = New System.Drawing.Point(1026, 15)
        Me.BtnToday.Name = "BtnToday"
        Me.BtnToday.Size = New System.Drawing.Size(216, 41)
        Me.BtnToday.TabIndex = 12
        Me.BtnToday.Text = "عرض تحصيلات اليوم"
        Me.BtnToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnToday.UseVisualStyleBackColor = False
        '
        'InvoiceCount
        '
        Me.InvoiceCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InvoiceCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.InvoiceCount.Location = New System.Drawing.Point(605, 27)
        Me.InvoiceCount.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.InvoiceCount.Name = "InvoiceCount"
        Me.InvoiceCount.ReadOnly = True
        Me.InvoiceCount.Size = New System.Drawing.Size(153, 27)
        Me.InvoiceCount.TabIndex = 76
        Me.InvoiceCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(610, 6)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 19)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "عدد العمليات فى الشاشة"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1245, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 36)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "دفتر المحصلين"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = Global.Sales_Management_Program.My.Resources.Resources.x_mark_3_32
        Me.PictureBox1.Location = New System.Drawing.Point(1413, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtTotalThsil)
        Me.Panel2.Controls.Add(Me.TxtTotalLateded)
        Me.Panel2.Controls.Add(Me.txtTotalLated)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 71)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1454, 41)
        Me.Panel2.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(1244, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 23)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "اجمالى التحصيل:"
        '
        'txtTotalThsil
        '
        Me.txtTotalThsil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalThsil.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotalThsil.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalThsil.ForeColor = System.Drawing.Color.Black
        Me.txtTotalThsil.Location = New System.Drawing.Point(1025, 5)
        Me.txtTotalThsil.Multiline = True
        Me.txtTotalThsil.Name = "txtTotalThsil"
        Me.txtTotalThsil.ReadOnly = True
        Me.txtTotalThsil.Size = New System.Drawing.Size(216, 30)
        Me.txtTotalThsil.TabIndex = 11
        Me.txtTotalThsil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTotalLateded
        '
        Me.TxtTotalLateded.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalLateded.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalLateded.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalLateded.ForeColor = System.Drawing.Color.Black
        Me.TxtTotalLateded.Location = New System.Drawing.Point(665, 5)
        Me.TxtTotalLateded.Multiline = True
        Me.TxtTotalLateded.Name = "TxtTotalLateded"
        Me.TxtTotalLateded.ReadOnly = True
        Me.TxtTotalLateded.Size = New System.Drawing.Size(218, 30)
        Me.TxtTotalLateded.TabIndex = 11
        Me.TxtTotalLateded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalLated
        '
        Me.txtTotalLated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalLated.AutoSize = True
        Me.txtTotalLated.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLated.ForeColor = System.Drawing.Color.Black
        Me.txtTotalLated.Location = New System.Drawing.Point(888, 9)
        Me.txtTotalLated.Name = "txtTotalLated"
        Me.txtTotalLated.Size = New System.Drawing.Size(130, 23)
        Me.txtTotalLated.TabIndex = 12
        Me.txtTotalLated.Text = "اجمالى المتاخرات :"
        '
        'BtnSearchDate
        '
        Me.BtnSearchDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearchDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnSearchDate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnSearchDate.FlatAppearance.BorderSize = 3
        Me.BtnSearchDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearchDate.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchDate.ForeColor = System.Drawing.Color.White
        Me.BtnSearchDate.Image = Global.Sales_Management_Program.My.Resources.Resources.Find_32x32
        Me.BtnSearchDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSearchDate.Location = New System.Drawing.Point(454, 15)
        Me.BtnSearchDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnSearchDate.Name = "BtnSearchDate"
        Me.BtnSearchDate.Size = New System.Drawing.Size(170, 33)
        Me.BtnSearchDate.TabIndex = 77
        Me.BtnSearchDate.Text = "البحث بالتاريخ"
        Me.BtnSearchDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSearchDate.UseVisualStyleBackColor = False
        '
        'ComboBox_mand_Name
        '
        Me.ComboBox_mand_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_mand_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_mand_Name.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_mand_Name.FormattingEnabled = True
        Me.ComboBox_mand_Name.Location = New System.Drawing.Point(284, 68)
        Me.ComboBox_mand_Name.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ComboBox_mand_Name.Name = "ComboBox_mand_Name"
        Me.ComboBox_mand_Name.Size = New System.Drawing.Size(163, 27)
        Me.ComboBox_mand_Name.TabIndex = 74
        '
        'Date2
        '
        Me.Date2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Date2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date2.Location = New System.Drawing.Point(284, 32)
        Me.Date2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(137, 27)
        Me.Date2.TabIndex = 70
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.Sales_Management_Program.My.Resources.Resources.search_6_32
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(453, 64)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 32)
        Me.Button1.TabIndex = 72
        Me.Button1.Text = "البحث باسم المحصل"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(420, 32)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 19)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "الـــى :"
        '
        'Date1
        '
        Me.Date1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Date1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date1.Location = New System.Drawing.Point(284, 6)
        Me.Date1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(137, 27)
        Me.Date1.TabIndex = 71
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(420, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 19)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "مــن :"
        '
        'DGV_Mand
        '
        Me.DGV_Mand.AllowUserToAddRows = False
        Me.DGV_Mand.AllowUserToDeleteRows = False
        Me.DGV_Mand.BackgroundColor = System.Drawing.Color.Gray
        Me.DGV_Mand.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Mand.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Mand.ColumnHeadersHeight = 60
        Me.DGV_Mand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV_Mand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column8, Me.Column9, Me.Column10})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Mand.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_Mand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Mand.EnableHeadersVisualStyles = False
        Me.DGV_Mand.Location = New System.Drawing.Point(0, 0)
        Me.DGV_Mand.Name = "DGV_Mand"
        Me.DGV_Mand.RowHeadersVisible = False
        Me.DGV_Mand.RowTemplate.Height = 35
        Me.DGV_Mand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_Mand.Size = New System.Drawing.Size(1454, 300)
        Me.DGV_Mand.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "رقم العملية"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "اسم المحصل"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 400
        '
        'Column8
        '
        Me.Column8.HeaderText = "اجمالى التحصيل"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 400
        '
        'Column9
        '
        Me.Column9.HeaderText = "التاريخ"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 300
        '
        'Column10
        '
        Me.Column10.HeaderText = "ملحوظة"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 500
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Controls.Add(Me.BtnSearchDate)
        Me.Panel5.Controls.Add(Me.Date2)
        Me.Panel5.Controls.Add(Me.BtnPrint)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.ComboBox_mand_Name)
        Me.Panel5.Controls.Add(Me.Date1)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.Button2)
        Me.Panel5.Controls.Add(Me.BtnDelete)
        Me.Panel5.Controls.Add(Me.BtnEdit)
        Me.Panel5.Controls.Add(Me.BtnNew)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.ForeColor = System.Drawing.Color.Yellow
        Me.Panel5.Location = New System.Drawing.Point(0, 112)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1454, 152)
        Me.Panel5.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 3
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = Global.Sales_Management_Program.My.Resources.Resources.Find_32x32
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(338, 105)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(221, 36)
        Me.Button3.TabIndex = 78
        Me.Button3.Text = "البحث بالتاريخ واسم المحصل"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.BackColor = System.Drawing.Color.Black
        Me.BtnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnPrint.FlatAppearance.BorderSize = 3
        Me.BtnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.ForeColor = System.Drawing.Color.White
        Me.BtnPrint.Image = Global.Sales_Management_Program.My.Resources.Resources.printer_32
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.Location = New System.Drawing.Point(788, 93)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(279, 50)
        Me.BtnPrint.TabIndex = 25
        Me.BtnPrint.Text = "طباعة تقرير عن التحصيلات لهذا  الشهر"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.Button2.FlatAppearance.BorderSize = 3
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.Image = Global.Sales_Management_Program.My.Resources.Resources.edit_11_321
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(1073, 93)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 50)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "تعديل جميع العمليات"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnDelete.FlatAppearance.BorderSize = 3
        Me.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.ForeColor = System.Drawing.Color.White
        Me.BtnDelete.Image = Global.Sales_Management_Program.My.Resources.Resources.delete_32
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.Location = New System.Drawing.Point(1263, 93)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(181, 50)
        Me.BtnDelete.TabIndex = 19
        Me.BtnDelete.Text = "حذف العملية المحددة"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnEdit.FlatAppearance.BorderSize = 3
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnEdit.Image = Global.Sales_Management_Program.My.Resources.Resources.edit_11_321
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEdit.Location = New System.Drawing.Point(1072, 36)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(184, 50)
        Me.BtnEdit.TabIndex = 18
        Me.BtnEdit.Text = "تعديل العملية المحددة"
        Me.BtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnNew.FlatAppearance.BorderSize = 3
        Me.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.ForeColor = System.Drawing.Color.White
        Me.BtnNew.Image = Global.Sales_Management_Program.My.Resources.Resources.plus_5_32
        Me.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNew.Location = New System.Drawing.Point(1263, 36)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(181, 50)
        Me.BtnNew.TabIndex = 17
        Me.BtnNew.Text = "اضافة عملية جديدة"
        Me.BtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.DGV_Mand)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 264)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1454, 300)
        Me.Panel3.TabIndex = 5
        '
        'Frm_Dftr_Mohslin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1454, 564)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Frm_Dftr_Mohslin"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGV_Mand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnPrint As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnNew As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotalLated As Label
    Friend WithEvents txtTotalThsil As TextBox
    Friend WithEvents TxtTotalLateded As TextBox
    Friend WithEvents LblData As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblDateDay As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnShowAll As Button
    Friend WithEvents BtnToday As Button
    Friend WithEvents DGV_Mand As DataGridView
    Friend WithEvents BtnSearchDate As Button
    Friend WithEvents ComboBox_mand_Name As ComboBox
    Friend WithEvents Date2 As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Date1 As DateTimePicker
    Friend WithEvents InvoiceCount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
End Class
