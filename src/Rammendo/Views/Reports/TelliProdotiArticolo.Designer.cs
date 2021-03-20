namespace Rammendo.Views.Reports
{
    partial class TelliProdotiArticolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelliProdotiArticolo));
            this.DgvTelliProdoti = new Rammendo.Controls.CGridView();
            this.PnToolBar = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTelliProdoti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvTelliProdoti.ColumnHeadersHeight = 50;
            this.DgvTelliProdoti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvTelliProdoti.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvTelliProdoti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTelliProdoti.EnableHeadersVisualStyles = false;
            this.DgvTelliProdoti.GridColor = System.Drawing.Color.Gainsboro;
            this.DgvTelliProdoti.Location = new System.Drawing.Point(0, 44);
            this.DgvTelliProdoti.MultiSelect = false;
            this.DgvTelliProdoti.Name = "DgvTelliProdoti";
            this.DgvTelliProdoti.ReadOnly = true;
            this.DgvTelliProdoti.RowHeadersVisible = false;
            this.DgvTelliProdoti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTelliProdoti.Size = new System.Drawing.Size(1178, 406);
            this.DgvTelliProdoti.TabIndex = 12;
            this.DgvTelliProdoti.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTelliProdoti_CellDoubleClick);
            // 
            // PnToolBar
            // 
            this.PnToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnToolBar.Controls.Add(this.rbActive);
            this.PnToolBar.Controls.Add(this.rbAll);
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
            this.PnToolBar.Size = new System.Drawing.Size(1178, 44);
            this.PnToolBar.TabIndex = 13;
            // 
            // rbActive
            // 
            this.rbActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbActive.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(1020, 5);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(67, 30);
            this.rbActive.TabIndex = 1;
            this.rbActive.Text = "Active";
            this.rbActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.CheckedChanged += new System.EventHandler(this.rbActive_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbAll.Location = new System.Drawing.Point(947, 5);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(67, 30);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
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
            this.CboFinezze.SelectedIndexChanged += new System.EventHandler(this.CboFinezze_SelectedIndexChanged);
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
            this.CboStagione.SelectedIndexChanged += new System.EventHandler(this.CboStagione_SelectedIndexChanged);
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
            this.PbLoader.Size = new System.Drawing.Size(1178, 5);
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
            this.CbCommessa.SelectedIndexChanged += new System.EventHandler(this.CbCommessa_SelectedIndexChanged);
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
            this.CbArticolo.SelectedIndexChanged += new System.EventHandler(this.CbArticolo_SelectedIndexChanged);
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
            this.PbError.Location = new System.Drawing.Point(489, 125);
            this.PbError.Name = "PbError";
            this.PbError.Size = new System.Drawing.Size(200, 200);
            this.PbError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbError.TabIndex = 18;
            this.PbError.TabStop = false;
            this.PbError.Visible = false;
            // 
            // TelliProdotiArticolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 450);
            this.Controls.Add(this.PbError);
            this.Controls.Add(this.DgvTelliProdoti);
            this.Controls.Add(this.PnToolBar);
            this.Name = "TelliProdotiArticolo";
            this.Text = "TelliProdotiArticolo";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboFinezze;
        private System.Windows.Forms.ComboBox CboStagione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PbError;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbAll;
    }
}