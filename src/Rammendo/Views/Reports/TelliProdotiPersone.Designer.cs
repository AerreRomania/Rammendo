namespace Rammendo.Views.Reports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelliProdotiPersone));
            this.CGridBig = new Rammendo.Controls.CGridView();
            this.PbError = new System.Windows.Forms.PictureBox();
            this.PbLoader = new CircularProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.CGridBig)).BeginInit();
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CGridBig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.CGridBig.ColumnHeadersHeight = 50;
            this.CGridBig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CGridBig.DefaultCellStyle = dataGridViewCellStyle18;
            this.CGridBig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGridBig.EnableHeadersVisualStyles = false;
            this.CGridBig.GridColor = System.Drawing.Color.LightGray;
            this.CGridBig.Location = new System.Drawing.Point(0, 0);
            this.CGridBig.MultiSelect = false;
            this.CGridBig.Name = "CGridBig";
            this.CGridBig.ReadOnly = true;
            this.CGridBig.RowHeadersVisible = false;
            this.CGridBig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CGridBig.Size = new System.Drawing.Size(998, 450);
            this.CGridBig.TabIndex = 14;
            this.CGridBig.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.CGridBig_CellPainting);
            this.CGridBig.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CGridBig_Scroll);
            this.CGridBig.Paint += new System.Windows.Forms.PaintEventHandler(this.CGridBig_Paint);
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
            this.PbLoader.Location = new System.Drawing.Point(424, 150);
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
            // TelliProdotiPersone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 450);
            this.Controls.Add(this.PbLoader);
            this.Controls.Add(this.PbError);
            this.Controls.Add(this.CGridBig);
            this.Name = "TelliProdotiPersone";
            this.Text = "TelliProdotiPersone";
            ((System.ComponentModel.ISupportInitialize)(this.CGridBig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CGridView CGridBig;
        private System.Windows.Forms.PictureBox PbError;
        private CircularProgressBar.CircularProgressBar PbLoader;
    }
}