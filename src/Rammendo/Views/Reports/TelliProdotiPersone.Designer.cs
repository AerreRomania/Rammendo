﻿namespace Rammendo.Views.Reports
{
    partial class TelliProdotiPersone
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelliProdotiPersone));
            this.CGridBig = new Rammendo.Controls.CGridView();
            this.PnToolBar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CboFinezze = new System.Windows.Forms.ComboBox();
            this.CboStagione = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PbLoader = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.CbCommessa = new System.Windows.Forms.ComboBox();
            this.CbArticolo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PbError = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CGridBig)).BeginInit();
            this.PnToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbError)).BeginInit();
            this.SuspendLayout();
            // 
            // CGridBig
            // 
            this.CGridBig.AllowUserToAddRows = false;
            this.CGridBig.AllowUserToDeleteRows = false;
            this.CGridBig.AllowUserToResizeColumns = false;
            this.CGridBig.AllowUserToResizeRows = false;
            this.CGridBig.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CGridBig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CGridBig.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CGridBig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CGridBig.ColumnHeadersHeight = 50;
            this.CGridBig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CGridBig.DefaultCellStyle = dataGridViewCellStyle4;
            this.CGridBig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGridBig.EnableHeadersVisualStyles = false;
            this.CGridBig.GridColor = System.Drawing.Color.LightGray;
            this.CGridBig.Location = new System.Drawing.Point(0, 44);
            this.CGridBig.MultiSelect = false;
            this.CGridBig.Name = "CGridBig";
            this.CGridBig.ReadOnly = true;
            this.CGridBig.RowHeadersVisible = false;
            this.CGridBig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CGridBig.Size = new System.Drawing.Size(998, 406);
            this.CGridBig.TabIndex = 14;
            this.CGridBig.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.CGridBig_CellPainting);
            this.CGridBig.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CGridBig_Scroll);
            this.CGridBig.Paint += new System.Windows.Forms.PaintEventHandler(this.CGridBig_Paint);
            // 
            // PnToolBar
            // 
            this.PnToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnToolBar.Controls.Add(this.label3);
            this.PnToolBar.Controls.Add(this.CboFinezze);
            this.PnToolBar.Controls.Add(this.CboStagione);
            this.PnToolBar.Controls.Add(this.label4);
            this.PnToolBar.Controls.Add(this.PbLoader);
            this.PnToolBar.Controls.Add(this.label2);
            this.PnToolBar.Controls.Add(this.CbCommessa);
            this.PnToolBar.Controls.Add(this.CbArticolo);
            this.PnToolBar.Controls.Add(this.label1);
            this.PnToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnToolBar.Location = new System.Drawing.Point(0, 0);
            this.PnToolBar.Name = "PnToolBar";
            this.PnToolBar.Size = new System.Drawing.Size(998, 44);
            this.PnToolBar.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 15, 5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Stagione";
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
            this.CboFinezze.Location = new System.Drawing.Point(752, 7);
            this.CboFinezze.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CboFinezze.Name = "CboFinezze";
            this.CboFinezze.Size = new System.Drawing.Size(155, 25);
            this.CboFinezze.TabIndex = 8;
            // 
            // CboStagione
            // 
            this.CboStagione.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboStagione.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboStagione.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboStagione.ForeColor = System.Drawing.Color.Black;
            this.CboStagione.FormattingEnabled = true;
            this.CboStagione.Items.AddRange(new object[] {
            "<Reset>"});
            this.CboStagione.Location = new System.Drawing.Point(534, 7);
            this.CboStagione.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CboStagione.Name = "CboStagione";
            this.CboStagione.Size = new System.Drawing.Size(145, 25);
            this.CboStagione.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(694, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 15, 5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Finezze";
            // 
            // PbLoader
            // 
            this.PbLoader.BackColor = System.Drawing.Color.DarkRed;
            this.PbLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PbLoader.Location = new System.Drawing.Point(0, 39);
            this.PbLoader.MarqueeAnimationSpeed = 10;
            this.PbLoader.Name = "PbLoader";
            this.PbLoader.Size = new System.Drawing.Size(998, 5);
            this.PbLoader.Step = 50;
            this.PbLoader.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PbLoader.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 15);
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
            this.CbCommessa.Location = new System.Drawing.Point(300, 7);
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
            this.CbArticolo.Location = new System.Drawing.Point(67, 7);
            this.CbArticolo.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CbArticolo.Name = "CbArticolo";
            this.CbArticolo.Size = new System.Drawing.Size(145, 25);
            this.CbArticolo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 15, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Commessa";
            // 
            // PbError
            // 
            this.PbError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbError.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PbError.Image = ((System.Drawing.Image)(resources.GetObject("PbError.Image")));
            this.PbError.Location = new System.Drawing.Point(399, 125);
            this.PbError.Name = "PbError";
            this.PbError.Size = new System.Drawing.Size(200, 200);
            this.PbError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbError.TabIndex = 17;
            this.PbError.TabStop = false;
            this.PbError.Visible = false;
            // 
            // TelliProdotiPersone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 450);
            this.Controls.Add(this.PbError);
            this.Controls.Add(this.CGridBig);
            this.Controls.Add(this.PnToolBar);
            this.Name = "TelliProdotiPersone";
            this.Text = "TelliProdotiPersone";
            ((System.ComponentModel.ISupportInitialize)(this.CGridBig)).EndInit();
            this.PnToolBar.ResumeLayout(false);
            this.PnToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CGridView CGridBig;
        private System.Windows.Forms.Panel PnToolBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboFinezze;
        private System.Windows.Forms.ComboBox CboStagione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar PbLoader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbCommessa;
        private System.Windows.Forms.ComboBox CbArticolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbError;
    }
}