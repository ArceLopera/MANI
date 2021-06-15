namespace MANI
{
    partial class ImageForm
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
            this.components = new System.ComponentModel.Container();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.BasicDataStatusStrip = new System.Windows.Forms.StatusStrip();
            this.zoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tamagno = new System.Windows.Forms.ToolStripStatusLabel();
            this.PositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RGBLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HSLdata = new System.Windows.Forms.ToolStripStatusLabel();
            this.YCbCr = new System.Windows.Forms.ToolStripStatusLabel();
            this.ImageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.BasicDataStatusStrip.SuspendLayout();
            this.ImageContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePictureBox.Location = new System.Drawing.Point(0, 0);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(587, 392);
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            this.ImagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImagePictureBox_Paint);
            this.ImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImagePictureBox_MouseMove);
            // 
            // BasicDataStatusStrip
            // 
            this.BasicDataStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom,
            this.Tamagno,
            this.PositionLabel,
            this.RGBLabel,
            this.HSLdata,
            this.YCbCr});
            this.BasicDataStatusStrip.Location = new System.Drawing.Point(0, 369);
            this.BasicDataStatusStrip.Name = "BasicDataStatusStrip";
            this.BasicDataStatusStrip.Size = new System.Drawing.Size(587, 23);
            this.BasicDataStatusStrip.TabIndex = 1;
            this.BasicDataStatusStrip.Text = "statusStrip1";
            this.BasicDataStatusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BasicDataStatusStrip_ItemClicked);
            // 
            // zoom
            // 
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(34, 18);
            this.zoom.Text = "10%";
            // 
            // Tamagno
            // 
            this.Tamagno.Name = "Tamagno";
            this.Tamagno.Size = new System.Drawing.Size(30, 18);
            this.Tamagno.Text = "size";
            // 
            // PositionLabel
            // 
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(24, 18);
            this.PositionLabel.Text = "XY";
            // 
            // RGBLabel
            // 
            this.RGBLabel.Name = "RGBLabel";
            this.RGBLabel.Size = new System.Drawing.Size(33, 18);
            this.RGBLabel.Text = "RGB";
            // 
            // HSLdata
            // 
            this.HSLdata.Name = "HSLdata";
            this.HSLdata.Size = new System.Drawing.Size(32, 18);
            this.HSLdata.Text = "HSL";
            // 
            // YCbCr
            // 
            this.YCbCr.Name = "YCbCr";
            this.YCbCr.Size = new System.Drawing.Size(44, 18);
            this.YCbCr.Text = "YCbCr";
            // 
            // ImageContextMenu
            // 
            this.ImageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.ImageContextMenu.Name = "ImageContextMenu";
            this.ImageContextMenu.Size = new System.Drawing.Size(138, 48);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(587, 392);
            this.Controls.Add(this.BasicDataStatusStrip);
            this.Controls.Add(this.ImagePictureBox);
            this.Name = "ImageForm";
            this.TabText = "ImageForm";
            this.Text = "ImageForm";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.Resize += new System.EventHandler(this.ImageForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.BasicDataStatusStrip.ResumeLayout(false);
            this.BasicDataStatusStrip.PerformLayout();
            this.ImageContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip BasicDataStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel RGBLabel;
        private System.Windows.Forms.ToolStripStatusLabel PositionLabel;
        private System.Windows.Forms.ContextMenuStrip ImageContextMenu;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        public System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.ToolStripStatusLabel zoom;
        private System.Windows.Forms.ToolStripStatusLabel Tamagno;
        private System.Windows.Forms.ToolStripStatusLabel HSLdata;
        private System.Windows.Forms.ToolStripStatusLabel YCbCr;
    }
}