namespace Rammendo.Views.Reports
{
    partial class ProduzioneGantt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.DgvCaricoLavoro = new Rammendo.Controls.CGridView();
            this.PnToolBar = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.CboFinezze = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbCommessa = new System.Windows.Forms.ComboBox();
            this.CbArticolo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ZoomIn = new System.Windows.Forms.Button();
            this.btn_ZoomOut = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCaricoLavoro)).BeginInit();
            this.PnToolBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 44);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vScrollBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvCaricoLavoro);
            this.splitContainer1.Panel2.Controls.Add(this.PnToolBar);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1066, 499);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 36;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(1045, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 499);
            this.vScrollBar1.TabIndex = 36;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCaricoLavoro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCaricoLavoro.ColumnHeadersHeight = 50;
            this.DgvCaricoLavoro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCaricoLavoro.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCaricoLavoro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCaricoLavoro.EnableHeadersVisualStyles = false;
            this.DgvCaricoLavoro.GridColor = System.Drawing.Color.Gainsboro;
            this.DgvCaricoLavoro.Location = new System.Drawing.Point(0, 44);
            this.DgvCaricoLavoro.Margin = new System.Windows.Forms.Padding(2);
            this.DgvCaricoLavoro.MultiSelect = false;
            this.DgvCaricoLavoro.Name = "DgvCaricoLavoro";
            this.DgvCaricoLavoro.ReadOnly = true;
            this.DgvCaricoLavoro.RowHeadersVisible = false;
            this.DgvCaricoLavoro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCaricoLavoro.Size = new System.Drawing.Size(1066, 227);
            this.DgvCaricoLavoro.TabIndex = 30;
            // 
            // PnToolBar
            // 
            this.PnToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnToolBar.Controls.Add(this.button2);
            this.PnToolBar.Controls.Add(this.CboFinezze);
            this.PnToolBar.Controls.Add(this.label4);
            this.PnToolBar.Controls.Add(this.label2);
            this.PnToolBar.Controls.Add(this.CbCommessa);
            this.PnToolBar.Controls.Add(this.CbArticolo);
            this.PnToolBar.Controls.Add(this.label1);
            this.PnToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnToolBar.Location = new System.Drawing.Point(0, 0);
            this.PnToolBar.Name = "PnToolBar";
            this.PnToolBar.Size = new System.Drawing.Size(1066, 44);
            this.PnToolBar.TabIndex = 31;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(715, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "Refresh list";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CboFinezze
            // 
            this.CboFinezze.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboFinezze.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboFinezze.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboFinezze.ForeColor = System.Drawing.Color.Black;
            this.CboFinezze.FormattingEnabled = true;
            this.CboFinezze.Items.AddRange(new object[] {
            "<Reset>"});
            this.CboFinezze.Location = new System.Drawing.Point(528, 10);
            this.CboFinezze.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CboFinezze.Name = "CboFinezze";
            this.CboFinezze.Size = new System.Drawing.Size(155, 25);
            this.CboFinezze.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 15, 5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Finezze";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 15, 5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Articolo";
            // 
            // CbCommessa
            // 
            this.CbCommessa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbCommessa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbCommessa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbCommessa.ForeColor = System.Drawing.Color.Black;
            this.CbCommessa.FormattingEnabled = true;
            this.CbCommessa.Items.AddRange(new object[] {
            "<Reset>"});
            this.CbCommessa.Location = new System.Drawing.Point(84, 10);
            this.CbCommessa.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CbCommessa.Name = "CbCommessa";
            this.CbCommessa.Size = new System.Drawing.Size(155, 25);
            this.CbCommessa.TabIndex = 0;
            // 
            // CbArticolo
            // 
            this.CbArticolo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbArticolo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbArticolo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbArticolo.ForeColor = System.Drawing.Color.Black;
            this.CbArticolo.FormattingEnabled = true;
            this.CbArticolo.Items.AddRange(new object[] {
            "<Reset>"});
            this.CbArticolo.Location = new System.Drawing.Point(311, 10);
            this.CbArticolo.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CbArticolo.Name = "CbArticolo";
            this.CbArticolo.Size = new System.Drawing.Size(145, 25);
            this.CbArticolo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 15, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Commessa";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 44);
            this.panel1.TabIndex = 37;
            // 
            // btn_ZoomIn
            // 
            this.btn_ZoomIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ZoomIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ZoomIn.FlatAppearance.BorderSize = 0;
            this.btn_ZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomIn.Image = global::Rammendo.Properties.Resources.zoom_in;
            this.btn_ZoomIn.Location = new System.Drawing.Point(512, 3);
            this.btn_ZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ZoomIn.Name = "btn_ZoomIn";
            this.btn_ZoomIn.Size = new System.Drawing.Size(37, 40);
            this.btn_ZoomIn.TabIndex = 87;
            this.btn_ZoomIn.UseVisualStyleBackColor = false;
            this.btn_ZoomIn.Click += new System.EventHandler(this.btn_ZoomIn_Click);
            // 
            // btn_ZoomOut
            // 
            this.btn_ZoomOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ZoomOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ZoomOut.FlatAppearance.BorderSize = 0;
            this.btn_ZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomOut.Image = global::Rammendo.Properties.Resources.zoom_out;
            this.btn_ZoomOut.Location = new System.Drawing.Point(561, 3);
            this.btn_ZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ZoomOut.Name = "btn_ZoomOut";
            this.btn_ZoomOut.Size = new System.Drawing.Size(37, 40);
            this.btn_ZoomOut.TabIndex = 88;
            this.btn_ZoomOut.UseVisualStyleBackColor = false;
            this.btn_ZoomOut.Click += new System.EventHandler(this.btn_ZoomOut_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Image = global::Rammendo.Properties.Resources.fast_forward;
            this.button8.Location = new System.Drawing.Point(420, 3);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(37, 40);
            this.button8.TabIndex = 85;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::Rammendo.Properties.Resources.arrow_left;
            this.button5.Location = new System.Drawing.Point(323, 3);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 40);
            this.button5.TabIndex = 83;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = global::Rammendo.Properties.Resources.arrow_right;
            this.button7.Location = new System.Drawing.Point(469, 3);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(37, 40);
            this.button7.TabIndex = 86;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::Rammendo.Properties.Resources.fast_rewind;
            this.button6.Location = new System.Drawing.Point(372, 3);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 40);
            this.button6.TabIndex = 84;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Carico Lavoro";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btn_ZoomIn);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btn_ZoomOut);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 44);
            this.panel2.TabIndex = 38;
            // 
            // ProduzioneGantt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 587);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ProduzioneGantt";
            this.Text = "ProduzioneGantt";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCaricoLavoro)).EndInit();
            this.PnToolBar.ResumeLayout(false);
            this.PnToolBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private Controls.CGridView DgvCaricoLavoro;
        private System.Windows.Forms.Panel PnToolBar;
        private System.Windows.Forms.ComboBox CboFinezze;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbCommessa;
        private System.Windows.Forms.ComboBox CbArticolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btn_ZoomIn;
        private System.Windows.Forms.Button btn_ZoomOut;
        private System.Windows.Forms.Button button2;
    }
}