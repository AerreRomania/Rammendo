namespace Rammendo.Views.Reports
{
    partial class CommessaDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommessaDetails));
            this.DgvTelliProdoti = new Rammendo.Controls.CGridView();
            this.PbError = new System.Windows.Forms.PictureBox();
            this.pnTitlebar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.PbLoader = new CircularProgressBar.CircularProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTelliProdoti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbError)).BeginInit();
            this.pnTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTelliProdoti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvTelliProdoti.ColumnHeadersHeight = 50;
            this.DgvTelliProdoti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvTelliProdoti.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvTelliProdoti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTelliProdoti.EnableHeadersVisualStyles = false;
            this.DgvTelliProdoti.GridColor = System.Drawing.Color.Gainsboro;
            this.DgvTelliProdoti.Location = new System.Drawing.Point(0, 82);
            this.DgvTelliProdoti.Margin = new System.Windows.Forms.Padding(2);
            this.DgvTelliProdoti.MultiSelect = false;
            this.DgvTelliProdoti.Name = "DgvTelliProdoti";
            this.DgvTelliProdoti.ReadOnly = true;
            this.DgvTelliProdoti.RowHeadersVisible = false;
            this.DgvTelliProdoti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTelliProdoti.Size = new System.Drawing.Size(1340, 507);
            this.DgvTelliProdoti.TabIndex = 12;
            this.DgvTelliProdoti.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTelliProdoti_CellDoubleClick);
            // 
            // PbError
            // 
            this.PbError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbError.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PbError.Image = ((System.Drawing.Image)(resources.GetObject("PbError.Image")));
            this.PbError.Location = new System.Drawing.Point(606, 230);
            this.PbError.Name = "PbError";
            this.PbError.Size = new System.Drawing.Size(128, 128);
            this.PbError.TabIndex = 14;
            this.PbError.TabStop = false;
            this.PbError.Visible = false;
            // 
            // pnTitlebar
            // 
            this.pnTitlebar.BackColor = System.Drawing.Color.Black;
            this.pnTitlebar.Controls.Add(this.label4);
            this.pnTitlebar.Controls.Add(this.pictureBox3);
            this.pnTitlebar.Controls.Add(this.btnClose);
            this.pnTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitlebar.Location = new System.Drawing.Point(0, 0);
            this.pnTitlebar.Name = "pnTitlebar";
            this.pnTitlebar.Size = new System.Drawing.Size(1340, 50);
            this.pnTitlebar.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(126, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Commessa details";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(1, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(119, 49);
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1290, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 21;
            this.btnClose.Tag = "1";
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // PbLoader
            // 
            this.PbLoader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbLoader.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.QuadraticEaseIn;
            this.PbLoader.AnimationSpeed = 1;
            this.PbLoader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PbLoader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PbLoader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PbLoader.InnerColor = System.Drawing.Color.Transparent;
            this.PbLoader.InnerMargin = 2;
            this.PbLoader.InnerWidth = -1;
            this.PbLoader.Location = new System.Drawing.Point(595, 219);
            this.PbLoader.MarqueeAnimationSpeed = 2000;
            this.PbLoader.Name = "PbLoader";
            this.PbLoader.OuterColor = System.Drawing.Color.LightGray;
            this.PbLoader.OuterMargin = -25;
            this.PbLoader.OuterWidth = 10;
            this.PbLoader.ProgressColor = System.Drawing.Color.DarkSlateGray;
            this.PbLoader.ProgressWidth = 25;
            this.PbLoader.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PbLoader.Size = new System.Drawing.Size(150, 150);
            this.PbLoader.StartAngle = 150;
            this.PbLoader.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PbLoader.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PbLoader.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.PbLoader.SubscriptText = "";
            this.PbLoader.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PbLoader.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.PbLoader.SuperscriptText = "";
            this.PbLoader.TabIndex = 26;
            this.PbLoader.Text = "Caricamento";
            this.PbLoader.TextMargin = new System.Windows.Forms.Padding(0);
            this.PbLoader.Value = 50;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1340, 32);
            this.panel1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected to program";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Already programmed";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightCyan;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Location = new System.Drawing.Point(222, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(14, 14);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Khaki;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(86, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 14);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Legend";
            // 
            // CommessaDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 589);
            this.Controls.Add(this.PbLoader);
            this.Controls.Add(this.PbError);
            this.Controls.Add(this.DgvTelliProdoti);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnTitlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1340, 589);
            this.Name = "CommessaDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommessaDetails";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTelliProdoti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbError)).EndInit();
            this.pnTitlebar.ResumeLayout(false);
            this.pnTitlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CGridView DgvTelliProdoti;
        private System.Windows.Forms.PictureBox PbError;
        private System.Windows.Forms.Panel pnTitlebar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnClose;
        private CircularProgressBar.CircularProgressBar PbLoader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}