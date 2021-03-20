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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelliProdotiPersone));
            this.CGridBig = new Rammendo.Controls.CGridView();
            this.PbError = new System.Windows.Forms.PictureBox();
            this.PbLoader = new System.Windows.Forms.ProgressBar();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CGridBig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CGridBig.ColumnHeadersHeight = 50;
            this.CGridBig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CGridBig.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.PbLoader.BackColor = System.Drawing.Color.DarkRed;
            this.PbLoader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PbLoader.Location = new System.Drawing.Point(0, 0);
            this.PbLoader.MarqueeAnimationSpeed = 10;
            this.PbLoader.Name = "PbLoader";
            this.PbLoader.Size = new System.Drawing.Size(998, 5);
            this.PbLoader.Step = 50;
            this.PbLoader.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PbLoader.TabIndex = 19;
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
        private System.Windows.Forms.ProgressBar PbLoader;
    }
}