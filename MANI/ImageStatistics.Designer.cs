namespace MANI
{
    partial class ImageStatisticsPanel
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
            this.ImageStatsGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // ImageStatsGrid
            // 
            this.ImageStatsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageStatsGrid.Location = new System.Drawing.Point(0, 0);
            this.ImageStatsGrid.Name = "ImageStatsGrid";
            this.ImageStatsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.ImageStatsGrid.Size = new System.Drawing.Size(327, 493);
            this.ImageStatsGrid.TabIndex = 0;
            this.ImageStatsGrid.Click += new System.EventHandler(this.ImageStatsGrid_Click);
            // 
            // ImageStatisticsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 493);
            this.Controls.Add(this.ImageStatsGrid);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Name = "ImageStatisticsPanel";
            this.TabText = "ImageStatistics";
            this.Text = "ImageStatistics";
            this.Load += new System.EventHandler(this.ImageStatistics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid ImageStatsGrid;

    }
}