namespace Rammendo.Views.Reports
{
    partial class TelliProdoti
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvTelliProdoti = new Rammendo.Controls.CGridView();
            this.PnToolBar = new System.Windows.Forms.Panel();
            this.PbLoader = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.CbCommessa = new System.Windows.Forms.ComboBox();
            this.CbArticolo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PbError = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTelliProdoti)).BeginInit();
            this.PnToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbError)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvTelliProdoti
            // 
            this.DgvTelliProdoti.AllowUserToAddRows = false;
            this.DgvTelliProdoti.AllowUserToDeleteRows = false;
            this.DgvTelliProdoti.AllowUserToResizeColumns = false;
            this.DgvTelliProdoti.AllowUserToResizeRows = false;
            this.DgvTelliProdoti.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DgvTelliProdoti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvTelliProdoti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTelliProdoti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvTelliProdoti.ColumnHeadersHeight = 32;
            this.DgvTelliProdoti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvTelliProdoti.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvTelliProdoti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTelliProdoti.EnableHeadersVisualStyles = false;
            this.DgvTelliProdoti.GridColor = System.Drawing.Color.Gainsboro;
            this.DgvTelliProdoti.Location = new System.Drawing.Point(0, 44);
            this.DgvTelliProdoti.MultiSelect = false;
            this.DgvTelliProdoti.Name = "DgvTelliProdoti";
            this.DgvTelliProdoti.ReadOnly = true;
            this.DgvTelliProdoti.RowHeadersVisible = false;
            this.DgvTelliProdoti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTelliProdoti.Size = new System.Drawing.Size(569, 349);
            this.DgvTelliProdoti.TabIndex = 1;
            // 
            // PnToolBar
            // 
            this.PnToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnToolBar.Controls.Add(this.PbLoader);
            this.PnToolBar.Controls.Add(this.label2);
            this.PnToolBar.Controls.Add(this.CbCommessa);
            this.PnToolBar.Controls.Add(this.CbArticolo);
            this.PnToolBar.Controls.Add(this.label1);
            this.PnToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnToolBar.Location = new System.Drawing.Point(0, 0);
            this.PnToolBar.Name = "PnToolBar";
            this.PnToolBar.Size = new System.Drawing.Size(569, 44);
            this.PnToolBar.TabIndex = 8;
            // 
            // PbLoader
            // 
            this.PbLoader.BackColor = System.Drawing.Color.DarkRed;
            this.PbLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PbLoader.Location = new System.Drawing.Point(0, 39);
            this.PbLoader.MarqueeAnimationSpeed = 10;
            this.PbLoader.Name = "PbLoader";
            this.PbLoader.Size = new System.Drawing.Size(569, 5);
            this.PbLoader.Step = 50;
            this.PbLoader.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PbLoader.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 15, 5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Articolo";
            // 
            // CbCommessa
            // 
            this.CbCommessa.FormattingEnabled = true;
            this.CbCommessa.Items.AddRange(new object[] {
            "<Reset>"});
            this.CbCommessa.Location = new System.Drawing.Point(325, 8);
            this.CbCommessa.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CbCommessa.Name = "CbCommessa";
            this.CbCommessa.Size = new System.Drawing.Size(155, 21);
            this.CbCommessa.TabIndex = 0;
            this.CbCommessa.SelectedIndexChanged += new System.EventHandler(this.CbCommessa_SelectedIndexChanged);
            // 
            // CbArticolo
            // 
            this.CbArticolo.FormattingEnabled = true;
            this.CbArticolo.Items.AddRange(new object[] {
            "<Reset>"});
            this.CbArticolo.Location = new System.Drawing.Point(78, 8);
            this.CbArticolo.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CbArticolo.Name = "CbArticolo";
            this.CbArticolo.Size = new System.Drawing.Size(145, 21);
            this.CbArticolo.TabIndex = 1;
            this.CbArticolo.SelectedIndexChanged += new System.EventHandler(this.CbArticolo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 13);
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
            this.PbError.Image = global::Rammendo.Properties.Resources.error;
            this.PbError.Location = new System.Drawing.Point(220, 132);
            this.PbError.Name = "PbError";
            this.PbError.Size = new System.Drawing.Size(128, 128);
            this.PbError.TabIndex = 11;
            this.PbError.TabStop = false;
            this.PbError.Visible = false;
            // 
            // TelliProdoti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(569, 393);
            this.Controls.Add(this.PbError);
            this.Controls.Add(this.DgvTelliProdoti);
            this.Controls.Add(this.PnToolBar);
            this.Name = "TelliProdoti";
            this.Text = "TelliProdoti";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTelliProdoti)).EndInit();
            this.PnToolBar.ResumeLayout(false);
            this.PnToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CGridView DgvTelliProdoti;
        private System.Windows.Forms.Panel PnToolBar;
        private System.Windows.Forms.ProgressBar PbLoader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbCommessa;
        private System.Windows.Forms.ComboBox CbArticolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbError;
    }
}