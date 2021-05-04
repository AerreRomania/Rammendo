namespace Rammendo.Views.Dialogs
{
    partial class ScheduleOrganizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTargetQty = new System.Windows.Forms.Label();
            this.lblProdQty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDiff = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblNorm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvCaricoLavoro = new Rammendo.Controls.CGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCommessa = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblArticle = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblQtyPack = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblReadedDate = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblWorkStart = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblAlert = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblProgrammedDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCaricoLavoro)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(215, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Delete task";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(307, 25);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkCyan;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(18, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 43);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAlert);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(15, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 189);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Target qty:";
            // 
            // lblTargetQty
            // 
            this.lblTargetQty.AutoSize = true;
            this.lblTargetQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetQty.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetQty.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTargetQty.Location = new System.Drawing.Point(135, 60);
            this.lblTargetQty.Name = "lblTargetQty";
            this.lblTargetQty.Size = new System.Drawing.Size(2, 32);
            this.lblTargetQty.TabIndex = 30;
            // 
            // lblProdQty
            // 
            this.lblProdQty.AutoSize = true;
            this.lblProdQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProdQty.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdQty.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblProdQty.Location = new System.Drawing.Point(135, 106);
            this.lblProdQty.Name = "lblProdQty";
            this.lblProdQty.Size = new System.Drawing.Size(2, 32);
            this.lblProdQty.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Produced Qty:";
            // 
            // lblDiff
            // 
            this.lblDiff.AutoSize = true;
            this.lblDiff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDiff.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiff.ForeColor = System.Drawing.Color.Crimson;
            this.lblDiff.Location = new System.Drawing.Point(135, 152);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(2, 32);
            this.lblDiff.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(12, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "Diff:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(12, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "Current operator:";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOperator.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOperator.Location = new System.Drawing.Point(135, 22);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(2, 23);
            this.lblOperator.TabIndex = 36;
            // 
            // lblNorm
            // 
            this.lblNorm.AutoSize = true;
            this.lblNorm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNorm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorm.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNorm.Location = new System.Drawing.Point(135, 60);
            this.lblNorm.Name = "lblNorm";
            this.lblNorm.Size = new System.Drawing.Size(2, 32);
            this.lblNorm.TabIndex = 38;
            this.lblNorm.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Norm:";
            this.label3.Visible = false;
            // 
            // DgvCaricoLavoro
            // 
            this.DgvCaricoLavoro.AllowUserToAddRows = false;
            this.DgvCaricoLavoro.AllowUserToDeleteRows = false;
            this.DgvCaricoLavoro.AllowUserToResizeColumns = false;
            this.DgvCaricoLavoro.AllowUserToResizeRows = false;
            this.DgvCaricoLavoro.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DgvCaricoLavoro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvCaricoLavoro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCaricoLavoro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvCaricoLavoro.ColumnHeadersHeight = 50;
            this.DgvCaricoLavoro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCaricoLavoro.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvCaricoLavoro.EnableHeadersVisualStyles = false;
            this.DgvCaricoLavoro.GridColor = System.Drawing.Color.Gainsboro;
            this.DgvCaricoLavoro.Location = new System.Drawing.Point(400, 24);
            this.DgvCaricoLavoro.Margin = new System.Windows.Forms.Padding(2);
            this.DgvCaricoLavoro.MultiSelect = false;
            this.DgvCaricoLavoro.Name = "DgvCaricoLavoro";
            this.DgvCaricoLavoro.ReadOnly = true;
            this.DgvCaricoLavoro.RowHeadersVisible = false;
            this.DgvCaricoLavoro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCaricoLavoro.Size = new System.Drawing.Size(731, 214);
            this.DgvCaricoLavoro.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblWorkStart);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblQtyPack);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblReadedDate);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblTotalQty);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblArticle);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblCommessa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(400, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(731, 189);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commesa details";
            // 
            // lblCommessa
            // 
            this.lblCommessa.AutoSize = true;
            this.lblCommessa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCommessa.ForeColor = System.Drawing.Color.Black;
            this.lblCommessa.Location = new System.Drawing.Point(113, 36);
            this.lblCommessa.Name = "lblCommessa";
            this.lblCommessa.Size = new System.Drawing.Size(0, 21);
            this.lblCommessa.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(29, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Commessa:";
            // 
            // lblArticle
            // 
            this.lblArticle.AutoSize = true;
            this.lblArticle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArticle.ForeColor = System.Drawing.Color.Black;
            this.lblArticle.Location = new System.Drawing.Point(113, 65);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(0, 21);
            this.lblArticle.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(29, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 41;
            this.label9.Text = "Total qty:";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalQty.ForeColor = System.Drawing.Color.Black;
            this.lblTotalQty.Location = new System.Drawing.Point(113, 95);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(0, 21);
            this.lblTotalQty.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Location = new System.Drawing.Point(29, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 43;
            this.label11.Text = "Article:";
            // 
            // lblQtyPack
            // 
            this.lblQtyPack.AutoSize = true;
            this.lblQtyPack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQtyPack.ForeColor = System.Drawing.Color.Black;
            this.lblQtyPack.Location = new System.Drawing.Point(113, 126);
            this.lblQtyPack.Name = "lblQtyPack";
            this.lblQtyPack.Size = new System.Drawing.Size(0, 21);
            this.lblQtyPack.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label15.Location = new System.Drawing.Point(29, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 17);
            this.label15.TabIndex = 47;
            this.label15.Text = "Qty pack:";
            // 
            // lblReadedDate
            // 
            this.lblReadedDate.AutoSize = true;
            this.lblReadedDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblReadedDate.ForeColor = System.Drawing.Color.Black;
            this.lblReadedDate.Location = new System.Drawing.Point(495, 36);
            this.lblReadedDate.Name = "lblReadedDate";
            this.lblReadedDate.Size = new System.Drawing.Size(0, 21);
            this.lblReadedDate.TabIndex = 46;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label17.Location = new System.Drawing.Point(401, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 17);
            this.label17.TabIndex = 45;
            this.label17.Text = "Readed date:";
            // 
            // lblWorkStart
            // 
            this.lblWorkStart.AutoSize = true;
            this.lblWorkStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWorkStart.ForeColor = System.Drawing.Color.Black;
            this.lblWorkStart.Location = new System.Drawing.Point(495, 65);
            this.lblWorkStart.Name = "lblWorkStart";
            this.lblWorkStart.Size = new System.Drawing.Size(0, 21);
            this.lblWorkStart.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label13.Location = new System.Drawing.Point(401, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 17);
            this.label13.TabIndex = 49;
            this.label13.Text = "Work start:";
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAlert.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAlert.Location = new System.Drawing.Point(15, 161);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(332, 13);
            this.lblAlert.TabIndex = 25;
            this.lblAlert.Text = "! Cannot operate with this task because it has production";
            this.lblAlert.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(307, 25);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // lblProgrammedDate
            // 
            this.lblProgrammedDate.AutoSize = true;
            this.lblProgrammedDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgrammedDate.ForeColor = System.Drawing.Color.Black;
            this.lblProgrammedDate.Location = new System.Drawing.Point(14, 230);
            this.lblProgrammedDate.Name = "lblProgrammedDate";
            this.lblProgrammedDate.Size = new System.Drawing.Size(0, 17);
            this.lblProgrammedDate.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Programmed time";
            // 
            // ScheduleOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 476);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProgrammedDate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblNorm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDiff);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblProdQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTargetQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DgvCaricoLavoro);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleOrganizer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScheduleOrganizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCaricoLavoro)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.CGridView DgvCaricoLavoro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTargetQty;
        private System.Windows.Forms.Label lblProdQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblNorm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblQtyPack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblReadedDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCommessa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblWorkStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAlert;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblProgrammedDate;
        private System.Windows.Forms.Label label1;
    }
}