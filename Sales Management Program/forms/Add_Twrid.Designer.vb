<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Add_Twrid
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
        Me.ComboBox_Mand_Name = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTwDate = New System.Windows.Forms.DateTimePicker()
        Me.txtTwQst = New System.Windows.Forms.TextBox()
        Me.txtTwCash = New System.Windows.Forms.TextBox()
        Me.txtTwID = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtTwNote = New System.Windows.Forms.TextBox()
        Me.txtTwOutgoings = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTwLated = New System.Windows.Forms.TextBox()
        Me.txtTwTotalRest = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_Mand_Name
        '
        Me.ComboBox_Mand_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Mand_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Mand_Name.FormattingEnabled = True
        Me.ComboBox_Mand_Name.Location = New System.Drawing.Point(51, 128)
        Me.ComboBox_Mand_Name.Name = "ComboBox_Mand_Name"
        Me.ComboBox_Mand_Name.Size = New System.Drawing.Size(464, 31)
        Me.ComboBox_Mand_Name.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(520, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 23)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "اسم المندوب :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(519, 455)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 23)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "التاريخ :"
        '
        'txtTwDate
        '
        Me.txtTwDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTwDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtTwDate.Location = New System.Drawing.Point(50, 456)
        Me.txtTwDate.Name = "txtTwDate"
        Me.txtTwDate.ShowUpDown = True
        Me.txtTwDate.Size = New System.Drawing.Size(464, 31)
        Me.txtTwDate.TabIndex = 5
        '
        'txtTwQst
        '
        Me.txtTwQst.BackColor = System.Drawing.Color.White
        Me.txtTwQst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTwQst.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwQst.Location = New System.Drawing.Point(50, 231)
        Me.txtTwQst.Multiline = True
        Me.txtTwQst.Name = "txtTwQst"
        Me.txtTwQst.Size = New System.Drawing.Size(464, 40)
        Me.txtTwQst.TabIndex = 2
        Me.txtTwQst.Text = "0.0"
        Me.txtTwQst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTwCash
        '
        Me.txtTwCash.BackColor = System.Drawing.Color.White
        Me.txtTwCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTwCash.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwCash.Location = New System.Drawing.Point(50, 175)
        Me.txtTwCash.Multiline = True
        Me.txtTwCash.Name = "txtTwCash"
        Me.txtTwCash.Size = New System.Drawing.Size(464, 40)
        Me.txtTwCash.TabIndex = 1
        Me.txtTwCash.Text = "0.0"
        Me.txtTwCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTwID
        '
        Me.txtTwID.BackColor = System.Drawing.Color.Gray
        Me.txtTwID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTwID.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwID.Location = New System.Drawing.Point(50, 73)
        Me.txtTwID.Multiline = True
        Me.txtTwID.Name = "txtTwID"
        Me.txtTwID.ReadOnly = True
        Me.txtTwID.Size = New System.Drawing.Size(464, 40)
        Me.txtTwID.TabIndex = 85
        Me.txtTwID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 64)
        Me.Panel1.TabIndex = 91
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(303, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(166, 29)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "عملية توريد جديدة"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Sales_Management_Program.My.Resources.Resources.x_mark_3_32
        Me.PictureBox1.Location = New System.Drawing.Point(675, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'txtTwNote
        '
        Me.txtTwNote.BackColor = System.Drawing.Color.White
        Me.txtTwNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTwNote.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwNote.Location = New System.Drawing.Point(49, 503)
        Me.txtTwNote.Multiline = True
        Me.txtTwNote.Name = "txtTwNote"
        Me.txtTwNote.Size = New System.Drawing.Size(465, 67)
        Me.txtTwNote.TabIndex = 8
        '
        'txtTwOutgoings
        '
        Me.txtTwOutgoings.BackColor = System.Drawing.Color.White
        Me.txtTwOutgoings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTwOutgoings.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwOutgoings.Location = New System.Drawing.Point(50, 287)
        Me.txtTwOutgoings.Multiline = True
        Me.txtTwOutgoings.Name = "txtTwOutgoings"
        Me.txtTwOutgoings.Size = New System.Drawing.Size(464, 40)
        Me.txtTwOutgoings.TabIndex = 3
        Me.txtTwOutgoings.Text = "0.0"
        Me.txtTwOutgoings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(520, 291)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 23)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = " الخارج (مصروفات):"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 3
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Image = Global.Sales_Management_Program.My.Resources.Resources.exit_2_32
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(51, 601)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 48)
        Me.Button1.TabIndex = 96
        Me.Button1.Text = "اغلاق الشاشــــة"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderSize = 3
        Me.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnNew.Image = Global.Sales_Management_Program.My.Resources.Resources.save_32
        Me.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNew.Location = New System.Drawing.Point(334, 601)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(181, 48)
        Me.BtnNew.TabIndex = 8
        Me.BtnNew.Text = "حفظ البيانات"
        Me.BtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(519, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(186, 23)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "توريد مقدمات البيع قسط :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(519, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 23)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "توريد من البيع الكاش :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(519, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 23)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "رقم العملية :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 655)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(727, 52)
        Me.Panel2.TabIndex = 92
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(520, 507)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 23)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "ملحوظة :"
        '
        'txtTwLated
        '
        Me.txtTwLated.BackColor = System.Drawing.Color.White
        Me.txtTwLated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTwLated.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwLated.Location = New System.Drawing.Point(50, 343)
        Me.txtTwLated.Multiline = True
        Me.txtTwLated.Name = "txtTwLated"
        Me.txtTwLated.Size = New System.Drawing.Size(464, 40)
        Me.txtTwLated.TabIndex = 4
        Me.txtTwLated.Text = "0.0"
        Me.txtTwLated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTwTotalRest
        '
        Me.txtTwTotalRest.BackColor = System.Drawing.Color.Gray
        Me.txtTwTotalRest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTwTotalRest.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwTotalRest.Location = New System.Drawing.Point(50, 399)
        Me.txtTwTotalRest.Multiline = True
        Me.txtTwTotalRest.Name = "txtTwTotalRest"
        Me.txtTwTotalRest.ReadOnly = True
        Me.txtTwTotalRest.Size = New System.Drawing.Size(464, 40)
        Me.txtTwTotalRest.TabIndex = 104
        Me.txtTwTotalRest.Text = "0.0"
        Me.txtTwTotalRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(520, 403)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 23)
        Me.Label8.TabIndex = 106
        Me.Label8.Text = "الباقى (المستلم فعلياً) :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(520, 347)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 23)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "المتاخرات :"
        '
        'Add_Twrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(727, 707)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtTwLated)
        Me.Controls.Add(Me.txtTwTotalRest)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBox_Mand_Name)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTwDate)
        Me.Controls.Add(Me.txtTwQst)
        Me.Controls.Add(Me.txtTwCash)
        Me.Controls.Add(Me.txtTwID)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtTwNote)
        Me.Controls.Add(Me.txtTwOutgoings)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Add_Twrid"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox_Mand_Name As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTwDate As DateTimePicker
    Friend WithEvents txtTwQst As TextBox
    Friend WithEvents txtTwCash As TextBox
    Friend WithEvents txtTwID As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtTwNote As TextBox
    Friend WithEvents txtTwOutgoings As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents BtnNew As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTwLated As TextBox
    Friend WithEvents txtTwTotalRest As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class
