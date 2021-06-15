namespace MANI
{
    partial class MainMani
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
            (new AboutMANI()).ShowDialog();
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
            this.ofd_Picture = new System.Windows.Forms.OpenFileDialog();
            this.MainDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRTNFRIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELLOKALABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nECOKALABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cG245wNFRIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cG245wOKALABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.cropPatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramFreqVSLumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramFreqVsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luminanceStatisticsValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yxyStatisticsDellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSVStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labStToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squarePatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.higlightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statsTransformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelTranslationONETOFIRSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelTranslationALLTOFIRSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastModificationSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastModificationSDALLTOFIRSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skewModificationONETOFIRSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skewModificationALLTOFIRSTSkewTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kurtosisModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bFTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyFilterPlusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyFilterBandPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTMatchingoneToFirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandPassMatchingoneToFirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleYAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToGrayscaleYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.substractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mathMorphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hitAndMissToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilatationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteTopHatWTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackTopHatBTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ditheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bayerMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burkesErrorDiffusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floydSteinbergErrorDiffusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderedDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sierraErrorDiffusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stevensonAndArceErrorDiffusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stuckiErrorDiffusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenEXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homogenityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianPyramideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfd_Picture = new System.Windows.Forms.SaveFileDialog();
            this.differenceAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainDockPanel
            // 
            this.MainDockPanel.ActiveAutoHideContent = null;
            this.MainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.MainDockPanel.Location = new System.Drawing.Point(0, 0);
            this.MainDockPanel.Name = "MainDockPanel";
            this.MainDockPanel.RightToLeftLayout = true;
            this.MainDockPanel.Size = new System.Drawing.Size(259, 244);
            this.MainDockPanel.TabIndex = 1;
            this.MainDockPanel.ActiveContentChanged += new System.EventHandler(this.MainDockPanel_ActiveContentChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 114);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.monitorCalibrationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // monitorCalibrationToolStripMenuItem
            // 
            this.monitorCalibrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cRTNFRIToolStripMenuItem,
            this.dELLOKALABToolStripMenuItem,
            this.nECOKALABToolStripMenuItem,
            this.lCDToolStripMenuItem,
            this.cG245wNFRIToolStripMenuItem,
            this.cG245wOKALABToolStripMenuItem});
            this.monitorCalibrationToolStripMenuItem.Name = "monitorCalibrationToolStripMenuItem";
            this.monitorCalibrationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.monitorCalibrationToolStripMenuItem.Text = "MonitorCalibration";
            // 
            // cRTNFRIToolStripMenuItem
            // 
            this.cRTNFRIToolStripMenuItem.Checked = true;
            this.cRTNFRIToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cRTNFRIToolStripMenuItem.Name = "cRTNFRIToolStripMenuItem";
            this.cRTNFRIToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.cRTNFRIToolStripMenuItem.Text = "CRT(NFRI)";
            this.cRTNFRIToolStripMenuItem.Click += new System.EventHandler(this.cRTNFRIToolStripMenuItem_Click);
            // 
            // dELLOKALABToolStripMenuItem
            // 
            this.dELLOKALABToolStripMenuItem.Name = "dELLOKALABToolStripMenuItem";
            this.dELLOKALABToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.dELLOKALABToolStripMenuItem.Text = "EIZO(OKALAB)Skin Exp";
            this.dELLOKALABToolStripMenuItem.Click += new System.EventHandler(this.dELLOKALABToolStripMenuItem_Click);
            // 
            // nECOKALABToolStripMenuItem
            // 
            this.nECOKALABToolStripMenuItem.Name = "nECOKALABToolStripMenuItem";
            this.nECOKALABToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.nECOKALABToolStripMenuItem.Text = "NEC(OKALAB)";
            this.nECOKALABToolStripMenuItem.Click += new System.EventHandler(this.nECOKALABToolStripMenuItem_Click);
            // 
            // lCDToolStripMenuItem
            // 
            this.lCDToolStripMenuItem.Name = "lCDToolStripMenuItem";
            this.lCDToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.lCDToolStripMenuItem.Text = "LCD192vxm(OKALAB)";
            this.lCDToolStripMenuItem.Click += new System.EventHandler(this.lCDToolStripMenuItem_Click);
            // 
            // cG245wNFRIToolStripMenuItem
            // 
            this.cG245wNFRIToolStripMenuItem.Name = "cG245wNFRIToolStripMenuItem";
            this.cG245wNFRIToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.cG245wNFRIToolStripMenuItem.Text = "CG245w(NFRI)";
            this.cG245wNFRIToolStripMenuItem.Click += new System.EventHandler(this.cG245wNFRIToolStripMenuItem_Click);
            // 
            // cG245wOKALABToolStripMenuItem
            // 
            this.cG245wOKALABToolStripMenuItem.Name = "cG245wOKALABToolStripMenuItem";
            this.cG245wOKALABToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.cG245wOKALABToolStripMenuItem.Text = "CG245w(OKALAB)";
            this.cG245wOKALABToolStripMenuItem.Click += new System.EventHandler(this.cG245wOKALABToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.cropPatchesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fitScreenToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripTextBox1});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // fitScreenToolStripMenuItem
            // 
            this.fitScreenToolStripMenuItem.Name = "fitScreenToolStripMenuItem";
            this.fitScreenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fitScreenToolStripMenuItem.Text = "Fit Screen";
            this.fitScreenToolStripMenuItem.Click += new System.EventHandler(this.fitScreenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // cropPatchesToolStripMenuItem
            // 
            this.cropPatchesToolStripMenuItem.Name = "cropPatchesToolStripMenuItem";
            this.cropPatchesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cropPatchesToolStripMenuItem.Text = "Crop patches";
            this.cropPatchesToolStripMenuItem.Click += new System.EventHandler(this.cropPatchesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.dHistogramToolStripMenuItem,
            this.imageListToolStripMenuItem,
            this.histogramFreqVSLumToolStripMenuItem,
            this.histogramFreqVsxToolStripMenuItem,
            this.luminanceStatisticsValuesToolStripMenuItem,
            this.yxyStatisticsDellToolStripMenuItem,
            this.hSVStatisticsToolStripMenuItem,
            this.rGBStatisticsToolStripMenuItem,
            this.labStToolStripMenuItem,
            this.squarePatchToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // dHistogramToolStripMenuItem
            // 
            this.dHistogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItem,
            this.redChannelToolStripMenuItem,
            this.greenChannelToolStripMenuItem,
            this.blueChannelToolStripMenuItem});
            this.dHistogramToolStripMenuItem.Name = "dHistogramToolStripMenuItem";
            this.dHistogramToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.dHistogramToolStripMenuItem.Text = "3D Histogram";
            // 
            // mToolStripMenuItem
            // 
            this.mToolStripMenuItem.Name = "mToolStripMenuItem";
            this.mToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.mToolStripMenuItem.Text = "Mean";
            this.mToolStripMenuItem.Click += new System.EventHandler(this.mToolStripMenuItem_Click);
            // 
            // redChannelToolStripMenuItem
            // 
            this.redChannelToolStripMenuItem.Name = "redChannelToolStripMenuItem";
            this.redChannelToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.redChannelToolStripMenuItem.Text = "Red Channel";
            this.redChannelToolStripMenuItem.Click += new System.EventHandler(this.redChannelToolStripMenuItem_Click);
            // 
            // greenChannelToolStripMenuItem
            // 
            this.greenChannelToolStripMenuItem.Name = "greenChannelToolStripMenuItem";
            this.greenChannelToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.greenChannelToolStripMenuItem.Text = "Green Channel";
            this.greenChannelToolStripMenuItem.Click += new System.EventHandler(this.greenChannelToolStripMenuItem_Click);
            // 
            // blueChannelToolStripMenuItem
            // 
            this.blueChannelToolStripMenuItem.Name = "blueChannelToolStripMenuItem";
            this.blueChannelToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.blueChannelToolStripMenuItem.Text = "Blue Channel";
            this.blueChannelToolStripMenuItem.Click += new System.EventHandler(this.blueChannelToolStripMenuItem_Click);
            // 
            // imageListToolStripMenuItem
            // 
            this.imageListToolStripMenuItem.Name = "imageListToolStripMenuItem";
            this.imageListToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.imageListToolStripMenuItem.Text = "Image List";
            this.imageListToolStripMenuItem.Click += new System.EventHandler(this.imageListToolStripMenuItem_Click);
            // 
            // histogramFreqVSLumToolStripMenuItem
            // 
            this.histogramFreqVSLumToolStripMenuItem.Name = "histogramFreqVSLumToolStripMenuItem";
            this.histogramFreqVSLumToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.histogramFreqVSLumToolStripMenuItem.Text = "HistogramFreqVSLum";
            this.histogramFreqVSLumToolStripMenuItem.Click += new System.EventHandler(this.histogramFreqVSLumToolStripMenuItem_Click);
            // 
            // histogramFreqVsxToolStripMenuItem
            // 
            this.histogramFreqVsxToolStripMenuItem.Name = "histogramFreqVsxToolStripMenuItem";
            this.histogramFreqVsxToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.histogramFreqVsxToolStripMenuItem.Text = "HistogramFreqVsx";
            this.histogramFreqVsxToolStripMenuItem.Click += new System.EventHandler(this.histogramFreqVsxToolStripMenuItem_Click);
            // 
            // luminanceStatisticsValuesToolStripMenuItem
            // 
            this.luminanceStatisticsValuesToolStripMenuItem.Name = "luminanceStatisticsValuesToolStripMenuItem";
            this.luminanceStatisticsValuesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.luminanceStatisticsValuesToolStripMenuItem.Text = "Yxy Statistics";
            this.luminanceStatisticsValuesToolStripMenuItem.Click += new System.EventHandler(this.luminanceStatisticsValuesToolStripMenuItem_Click);
            // 
            // yxyStatisticsDellToolStripMenuItem
            // 
            this.yxyStatisticsDellToolStripMenuItem.Name = "yxyStatisticsDellToolStripMenuItem";
            this.yxyStatisticsDellToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.yxyStatisticsDellToolStripMenuItem.Text = "Yxy Statistics to File";
            this.yxyStatisticsDellToolStripMenuItem.Click += new System.EventHandler(this.yxyStatisticsDellToolStripMenuItem_Click);
            // 
            // hSVStatisticsToolStripMenuItem
            // 
            this.hSVStatisticsToolStripMenuItem.Name = "hSVStatisticsToolStripMenuItem";
            this.hSVStatisticsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.hSVStatisticsToolStripMenuItem.Text = "HSL Statistics";
            this.hSVStatisticsToolStripMenuItem.Click += new System.EventHandler(this.hSVStatisticsToolStripMenuItem_Click);
            // 
            // rGBStatisticsToolStripMenuItem
            // 
            this.rGBStatisticsToolStripMenuItem.Name = "rGBStatisticsToolStripMenuItem";
            this.rGBStatisticsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.rGBStatisticsToolStripMenuItem.Text = "RGB Statistics to File";
            this.rGBStatisticsToolStripMenuItem.Click += new System.EventHandler(this.rGBStatisticsToolStripMenuItem_Click);
            // 
            // labStToolStripMenuItem
            // 
            this.labStToolStripMenuItem.Name = "labStToolStripMenuItem";
            this.labStToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.labStToolStripMenuItem.Text = "Lab Statistics to File";
            this.labStToolStripMenuItem.Click += new System.EventHandler(this.labStToolStripMenuItem_Click);
            // 
            // squarePatchToolStripMenuItem
            // 
            this.squarePatchToolStripMenuItem.Name = "squarePatchToolStripMenuItem";
            this.squarePatchToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.squarePatchToolStripMenuItem.Text = "Square Patch";
            this.squarePatchToolStripMenuItem.Click += new System.EventHandler(this.squarePatchToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.higlightsToolStripMenuItem,
            this.specialToolStripMenuItem,
            this.fFTToolStripMenuItem,
            this.colorFiltersToolStripMenuItem,
            this.mixToolStripMenuItem,
            this.mathMorphToolStripMenuItem,
            this.ditheringToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.edgeDetectorToolStripMenuItem,
            this.blurToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // higlightsToolStripMenuItem
            // 
            this.higlightsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removalToolStripMenuItem,
            this.additionToolStripMenuItem,
            this.detectionToolStripMenuItem});
            this.higlightsToolStripMenuItem.Name = "higlightsToolStripMenuItem";
            this.higlightsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.higlightsToolStripMenuItem.Text = "Highlights";
            // 
            // removalToolStripMenuItem
            // 
            this.removalToolStripMenuItem.Name = "removalToolStripMenuItem";
            this.removalToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.removalToolStripMenuItem.Text = "Removal";
            this.removalToolStripMenuItem.Click += new System.EventHandler(this.removalToolStripMenuItem_Click);
            // 
            // additionToolStripMenuItem
            // 
            this.additionToolStripMenuItem.Name = "additionToolStripMenuItem";
            this.additionToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.additionToolStripMenuItem.Text = "Addition";
            this.additionToolStripMenuItem.Click += new System.EventHandler(this.additionToolStripMenuItem_Click);
            // 
            // detectionToolStripMenuItem
            // 
            this.detectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdToolStripMenuItem});
            this.detectionToolStripMenuItem.Name = "detectionToolStripMenuItem";
            this.detectionToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.detectionToolStripMenuItem.Text = "Detection";
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.thresholdToolStripMenuItem.Text = "Threshold";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // specialToolStripMenuItem
            // 
            this.specialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramMatchingToolStripMenuItem,
            this.statsTransformationsToolStripMenuItem});
            this.specialToolStripMenuItem.Name = "specialToolStripMenuItem";
            this.specialToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.specialToolStripMenuItem.Text = "Special";
            // 
            // histogramMatchingToolStripMenuItem
            // 
            this.histogramMatchingToolStripMenuItem.Name = "histogramMatchingToolStripMenuItem";
            this.histogramMatchingToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.histogramMatchingToolStripMenuItem.Text = "Histogram Matching";
            this.histogramMatchingToolStripMenuItem.Click += new System.EventHandler(this.histogramMatchingToolStripMenuItem_Click);
            // 
            // statsTransformationsToolStripMenuItem
            // 
            this.statsTransformationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelTranslationONETOFIRSTToolStripMenuItem,
            this.channelTranslationALLTOFIRSTToolStripMenuItem,
            this.contrastModificationSDToolStripMenuItem,
            this.contrastModificationSDALLTOFIRSTToolStripMenuItem,
            this.skewModificationONETOFIRSTToolStripMenuItem,
            this.skewModificationALLTOFIRSTSkewTargetToolStripMenuItem,
            this.kurtosisModificationToolStripMenuItem});
            this.statsTransformationsToolStripMenuItem.Name = "statsTransformationsToolStripMenuItem";
            this.statsTransformationsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.statsTransformationsToolStripMenuItem.Text = "Stats Transformations";
            // 
            // channelTranslationONETOFIRSTToolStripMenuItem
            // 
            this.channelTranslationONETOFIRSTToolStripMenuItem.Name = "channelTranslationONETOFIRSTToolStripMenuItem";
            this.channelTranslationONETOFIRSTToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.channelTranslationONETOFIRSTToolStripMenuItem.Text = "Channel Translation(ONE TO FIRST)";
            this.channelTranslationONETOFIRSTToolStripMenuItem.Click += new System.EventHandler(this.channelTranslationONETOFIRSTToolStripMenuItem_Click);
            // 
            // channelTranslationALLTOFIRSTToolStripMenuItem
            // 
            this.channelTranslationALLTOFIRSTToolStripMenuItem.Name = "channelTranslationALLTOFIRSTToolStripMenuItem";
            this.channelTranslationALLTOFIRSTToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.channelTranslationALLTOFIRSTToolStripMenuItem.Text = "Channel Translation(ALL TO FIRST)";
            this.channelTranslationALLTOFIRSTToolStripMenuItem.Click += new System.EventHandler(this.channelTranslationALLTOFIRSTToolStripMenuItem_Click);
            // 
            // contrastModificationSDToolStripMenuItem
            // 
            this.contrastModificationSDToolStripMenuItem.Name = "contrastModificationSDToolStripMenuItem";
            this.contrastModificationSDToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.contrastModificationSDToolStripMenuItem.Text = "Contrast Modification(SD ONE TO FIRST)";
            this.contrastModificationSDToolStripMenuItem.Click += new System.EventHandler(this.contrastModificationSDToolStripMenuItem_Click);
            // 
            // contrastModificationSDALLTOFIRSTToolStripMenuItem
            // 
            this.contrastModificationSDALLTOFIRSTToolStripMenuItem.Name = "contrastModificationSDALLTOFIRSTToolStripMenuItem";
            this.contrastModificationSDALLTOFIRSTToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.contrastModificationSDALLTOFIRSTToolStripMenuItem.Text = "Contrast Modification (SD ALL TO FIRST)";
            this.contrastModificationSDALLTOFIRSTToolStripMenuItem.Click += new System.EventHandler(this.contrastModificationSDALLTOFIRSTToolStripMenuItem_Click);
            // 
            // skewModificationONETOFIRSTToolStripMenuItem
            // 
            this.skewModificationONETOFIRSTToolStripMenuItem.Name = "skewModificationONETOFIRSTToolStripMenuItem";
            this.skewModificationONETOFIRSTToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.skewModificationONETOFIRSTToolStripMenuItem.Text = "Skew Modification(ONE TO FIRST)Skew Target";
            this.skewModificationONETOFIRSTToolStripMenuItem.Click += new System.EventHandler(this.skewModificationONETOFIRSTToolStripMenuItem_Click);
            // 
            // skewModificationALLTOFIRSTSkewTargetToolStripMenuItem
            // 
            this.skewModificationALLTOFIRSTSkewTargetToolStripMenuItem.Name = "skewModificationALLTOFIRSTSkewTargetToolStripMenuItem";
            this.skewModificationALLTOFIRSTSkewTargetToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.skewModificationALLTOFIRSTSkewTargetToolStripMenuItem.Text = "Skew Modification(ALL TO FIRST)Skew Target";
            this.skewModificationALLTOFIRSTSkewTargetToolStripMenuItem.Click += new System.EventHandler(this.skewModificationALLTOFIRSTSkewTargetToolStripMenuItem_Click);
            // 
            // kurtosisModificationToolStripMenuItem
            // 
            this.kurtosisModificationToolStripMenuItem.Name = "kurtosisModificationToolStripMenuItem";
            this.kurtosisModificationToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.kurtosisModificationToolStripMenuItem.Text = "Kurtosis Modification(ONE TO FIRST)SD Target";
            this.kurtosisModificationToolStripMenuItem.Click += new System.EventHandler(this.kurtosisModificationToolStripMenuItem_Click);
            // 
            // fFTToolStripMenuItem
            // 
            this.fFTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fFTToolStripMenuItem1,
            this.bFTToolStripMenuItem1,
            this.frequencyFilterToolStripMenuItem,
            this.frequencyFilterPlusToolStripMenuItem,
            this.frequencyFilterBandPassToolStripMenuItem,
            this.fFTMatchingoneToFirstToolStripMenuItem,
            this.bandPassMatchingoneToFirstToolStripMenuItem});
            this.fFTToolStripMenuItem.Name = "fFTToolStripMenuItem";
            this.fFTToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.fFTToolStripMenuItem.Text = "Fourier Transform";
            // 
            // fFTToolStripMenuItem1
            // 
            this.fFTToolStripMenuItem1.Name = "fFTToolStripMenuItem1";
            this.fFTToolStripMenuItem1.Size = new System.Drawing.Size(267, 22);
            this.fFTToolStripMenuItem1.Text = "Forward FT";
            this.fFTToolStripMenuItem1.Click += new System.EventHandler(this.fFTToolStripMenuItem1_Click);
            // 
            // bFTToolStripMenuItem1
            // 
            this.bFTToolStripMenuItem1.Name = "bFTToolStripMenuItem1";
            this.bFTToolStripMenuItem1.Size = new System.Drawing.Size(267, 22);
            this.bFTToolStripMenuItem1.Text = "Backward FT";
            this.bFTToolStripMenuItem1.Click += new System.EventHandler(this.bFTToolStripMenuItem1_Click);
            // 
            // frequencyFilterToolStripMenuItem
            // 
            this.frequencyFilterToolStripMenuItem.Name = "frequencyFilterToolStripMenuItem";
            this.frequencyFilterToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.frequencyFilterToolStripMenuItem.Text = "Frequency FilterStatistics";
            this.frequencyFilterToolStripMenuItem.Click += new System.EventHandler(this.frequencyFilterToolStripMenuItem_Click);
            // 
            // frequencyFilterPlusToolStripMenuItem
            // 
            this.frequencyFilterPlusToolStripMenuItem.Name = "frequencyFilterPlusToolStripMenuItem";
            this.frequencyFilterPlusToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.frequencyFilterPlusToolStripMenuItem.Text = "Frequency Filter BandElimination";
            this.frequencyFilterPlusToolStripMenuItem.Click += new System.EventHandler(this.frequencyFilterPlusToolStripMenuItem_Click);
            // 
            // frequencyFilterBandPassToolStripMenuItem
            // 
            this.frequencyFilterBandPassToolStripMenuItem.Name = "frequencyFilterBandPassToolStripMenuItem";
            this.frequencyFilterBandPassToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.frequencyFilterBandPassToolStripMenuItem.Text = "Frequency Filter BandPass";
            this.frequencyFilterBandPassToolStripMenuItem.Click += new System.EventHandler(this.frequencyFilterBandPassToolStripMenuItem_Click);
            // 
            // fFTMatchingoneToFirstToolStripMenuItem
            // 
            this.fFTMatchingoneToFirstToolStripMenuItem.Name = "fFTMatchingoneToFirstToolStripMenuItem";
            this.fFTMatchingoneToFirstToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.fFTMatchingoneToFirstToolStripMenuItem.Text = "FFT matching(one to first)";
            this.fFTMatchingoneToFirstToolStripMenuItem.Click += new System.EventHandler(this.fFTMatchingoneToFirstToolStripMenuItem_Click);
            // 
            // bandPassMatchingoneToFirstToolStripMenuItem
            // 
            this.bandPassMatchingoneToFirstToolStripMenuItem.Name = "bandPassMatchingoneToFirstToolStripMenuItem";
            this.bandPassMatchingoneToFirstToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.bandPassMatchingoneToFirstToolStripMenuItem.Text = "BandPassMatching(one to first)";
            this.bandPassMatchingoneToFirstToolStripMenuItem.Click += new System.EventHandler(this.bandPassMatchingoneToFirstToolStripMenuItem_Click);
            // 
            // colorFiltersToolStripMenuItem
            // 
            this.colorFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleYAllToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.grayscaleToRGBToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.invertToolStripMenuItem1,
            this.rotateToolStripMenuItem,
            this.rGBToGrayscaleYToolStripMenuItem});
            this.colorFiltersToolStripMenuItem.Name = "colorFiltersToolStripMenuItem";
            this.colorFiltersToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.colorFiltersToolStripMenuItem.Text = "Color Filters";
            // 
            // grayscaleYAllToolStripMenuItem
            // 
            this.grayscaleYAllToolStripMenuItem.Name = "grayscaleYAllToolStripMenuItem";
            this.grayscaleYAllToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.grayscaleYAllToolStripMenuItem.Text = "GrayscaleY(All)";
            this.grayscaleYAllToolStripMenuItem.Click += new System.EventHandler(this.grayscaleYAllToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.grayscaleToolStripMenuItem.Text = "GrayscaleY";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // grayscaleToRGBToolStripMenuItem
            // 
            this.grayscaleToRGBToolStripMenuItem.Name = "grayscaleToRGBToolStripMenuItem";
            this.grayscaleToRGBToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.grayscaleToRGBToolStripMenuItem.Text = "Grayscale to RGB";
            this.grayscaleToRGBToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToRGBToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem1
            // 
            this.invertToolStripMenuItem1.Name = "invertToolStripMenuItem1";
            this.invertToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.invertToolStripMenuItem1.Text = "Invert";
            this.invertToolStripMenuItem1.Click += new System.EventHandler(this.invertToolStripMenuItem1_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // rGBToGrayscaleYToolStripMenuItem
            // 
            this.rGBToGrayscaleYToolStripMenuItem.Name = "rGBToGrayscaleYToolStripMenuItem";
            this.rGBToGrayscaleYToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.rGBToGrayscaleYToolStripMenuItem.Text = "RGB to Grayscale Y";
            // 
            // mixToolStripMenuItem
            // 
            this.mixToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.picToolStripMenuItem,
            this.differenceToolStripMenuItem1,
            this.substractToolStripMenuItem,
            this.addToolStripMenuItem,
            this.differenceAllToolStripMenuItem});
            this.mixToolStripMenuItem.Name = "mixToolStripMenuItem";
            this.mixToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.mixToolStripMenuItem.Text = "Two Image Filter";
            // 
            // picToolStripMenuItem
            // 
            this.picToolStripMenuItem.Name = "picToolStripMenuItem";
            this.picToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.picToolStripMenuItem.Text = "Morph";
            this.picToolStripMenuItem.Click += new System.EventHandler(this.picToolStripMenuItem_Click);
            // 
            // differenceToolStripMenuItem1
            // 
            this.differenceToolStripMenuItem1.Name = "differenceToolStripMenuItem1";
            this.differenceToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.differenceToolStripMenuItem1.Text = "Difference";
            this.differenceToolStripMenuItem1.Click += new System.EventHandler(this.differenceToolStripMenuItem1_Click);
            // 
            // substractToolStripMenuItem
            // 
            this.substractToolStripMenuItem.Name = "substractToolStripMenuItem";
            this.substractToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.substractToolStripMenuItem.Text = "Substract";
            this.substractToolStripMenuItem.Click += new System.EventHandler(this.substractToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // mathMorphToolStripMenuItem
            // 
            this.mathMorphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hitAndMissToolStripMenuItem,
            this.openingToolStripMenuItem,
            this.closingToolStripMenuItem,
            this.dilatationToolStripMenuItem,
            this.erosionToolStripMenuItem,
            this.whiteTopHatWTHToolStripMenuItem,
            this.blackTopHatBTHToolStripMenuItem});
            this.mathMorphToolStripMenuItem.Name = "mathMorphToolStripMenuItem";
            this.mathMorphToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.mathMorphToolStripMenuItem.Text = "Math Morph";
            // 
            // hitAndMissToolStripMenuItem
            // 
            this.hitAndMissToolStripMenuItem.Name = "hitAndMissToolStripMenuItem";
            this.hitAndMissToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.hitAndMissToolStripMenuItem.Text = "Hit and Miss";
            // 
            // openingToolStripMenuItem
            // 
            this.openingToolStripMenuItem.Name = "openingToolStripMenuItem";
            this.openingToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openingToolStripMenuItem.Text = "Opening";
            this.openingToolStripMenuItem.Click += new System.EventHandler(this.openingToolStripMenuItem_Click);
            // 
            // closingToolStripMenuItem
            // 
            this.closingToolStripMenuItem.Name = "closingToolStripMenuItem";
            this.closingToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.closingToolStripMenuItem.Text = "Closing";
            this.closingToolStripMenuItem.Click += new System.EventHandler(this.closingToolStripMenuItem_Click);
            // 
            // dilatationToolStripMenuItem
            // 
            this.dilatationToolStripMenuItem.Name = "dilatationToolStripMenuItem";
            this.dilatationToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.dilatationToolStripMenuItem.Text = "Dilatation";
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.erosionToolStripMenuItem.Text = "Erosion";
            // 
            // whiteTopHatWTHToolStripMenuItem
            // 
            this.whiteTopHatWTHToolStripMenuItem.Name = "whiteTopHatWTHToolStripMenuItem";
            this.whiteTopHatWTHToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.whiteTopHatWTHToolStripMenuItem.Text = "White Top-Hat (WTH)";
            this.whiteTopHatWTHToolStripMenuItem.Click += new System.EventHandler(this.whiteTopHatWTHToolStripMenuItem_Click);
            // 
            // blackTopHatBTHToolStripMenuItem
            // 
            this.blackTopHatBTHToolStripMenuItem.Name = "blackTopHatBTHToolStripMenuItem";
            this.blackTopHatBTHToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.blackTopHatBTHToolStripMenuItem.Text = "Black Top-Hat (BTH)";
            // 
            // ditheringToolStripMenuItem
            // 
            this.ditheringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bayerMatrixToolStripMenuItem,
            this.burkesErrorDiffusionToolStripMenuItem,
            this.floydSteinbergErrorDiffusionToolStripMenuItem,
            this.jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem,
            this.orderedDitheringToolStripMenuItem,
            this.sierraErrorDiffusionToolStripMenuItem,
            this.stevensonAndArceErrorDiffusionToolStripMenuItem,
            this.stuckiErrorDiffusionToolStripMenuItem});
            this.ditheringToolStripMenuItem.Name = "ditheringToolStripMenuItem";
            this.ditheringToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ditheringToolStripMenuItem.Text = "Dithering";
            // 
            // bayerMatrixToolStripMenuItem
            // 
            this.bayerMatrixToolStripMenuItem.Name = "bayerMatrixToolStripMenuItem";
            this.bayerMatrixToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.bayerMatrixToolStripMenuItem.Text = "Bayer matrix ";
            this.bayerMatrixToolStripMenuItem.Click += new System.EventHandler(this.bayerMatrixToolStripMenuItem_Click);
            // 
            // burkesErrorDiffusionToolStripMenuItem
            // 
            this.burkesErrorDiffusionToolStripMenuItem.Name = "burkesErrorDiffusionToolStripMenuItem";
            this.burkesErrorDiffusionToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.burkesErrorDiffusionToolStripMenuItem.Text = "Burkes error diffusion ";
            // 
            // floydSteinbergErrorDiffusionToolStripMenuItem
            // 
            this.floydSteinbergErrorDiffusionToolStripMenuItem.Name = "floydSteinbergErrorDiffusionToolStripMenuItem";
            this.floydSteinbergErrorDiffusionToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.floydSteinbergErrorDiffusionToolStripMenuItem.Text = "Floyd-Steinberg error diffusion ";
            // 
            // jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem
            // 
            this.jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem.Name = "jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem";
            this.jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem.Text = "Jarvis, Judice and Ninke error diffusion ";
            // 
            // orderedDitheringToolStripMenuItem
            // 
            this.orderedDitheringToolStripMenuItem.Name = "orderedDitheringToolStripMenuItem";
            this.orderedDitheringToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.orderedDitheringToolStripMenuItem.Text = "OrderedDithering";
            // 
            // sierraErrorDiffusionToolStripMenuItem
            // 
            this.sierraErrorDiffusionToolStripMenuItem.Name = "sierraErrorDiffusionToolStripMenuItem";
            this.sierraErrorDiffusionToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.sierraErrorDiffusionToolStripMenuItem.Text = "Sierra error diffusion ";
            // 
            // stevensonAndArceErrorDiffusionToolStripMenuItem
            // 
            this.stevensonAndArceErrorDiffusionToolStripMenuItem.Name = "stevensonAndArceErrorDiffusionToolStripMenuItem";
            this.stevensonAndArceErrorDiffusionToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.stevensonAndArceErrorDiffusionToolStripMenuItem.Text = "Stevenson and Arce error diffusion ";
            // 
            // stuckiErrorDiffusionToolStripMenuItem
            // 
            this.stuckiErrorDiffusionToolStripMenuItem.Name = "stuckiErrorDiffusionToolStripMenuItem";
            this.stuckiErrorDiffusionToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.stuckiErrorDiffusionToolStripMenuItem.Text = "Stucki error diffusion ";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sharpenToolStripMenuItem,
            this.sharpenEXToolStripMenuItem});
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sharpenToolStripMenuItem.Text = "Sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // sharpenEXToolStripMenuItem
            // 
            this.sharpenEXToolStripMenuItem.Name = "sharpenEXToolStripMenuItem";
            this.sharpenEXToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sharpenEXToolStripMenuItem.Text = "SharpenEX";
            this.sharpenEXToolStripMenuItem.Click += new System.EventHandler(this.sharpenEXToolStripMenuItem_Click);
            // 
            // edgeDetectorToolStripMenuItem
            // 
            this.edgeDetectorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homogenityToolStripMenuItem,
            this.differenceToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.cannyToolStripMenuItem,
            this.edgesToolStripMenuItem,
            this.laplacianPyramideToolStripMenuItem});
            this.edgeDetectorToolStripMenuItem.Name = "edgeDetectorToolStripMenuItem";
            this.edgeDetectorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.edgeDetectorToolStripMenuItem.Text = "Edge Detector";
            // 
            // homogenityToolStripMenuItem
            // 
            this.homogenityToolStripMenuItem.Name = "homogenityToolStripMenuItem";
            this.homogenityToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.homogenityToolStripMenuItem.Text = "Homogenity";
            this.homogenityToolStripMenuItem.Click += new System.EventHandler(this.homogenityToolStripMenuItem_Click);
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.differenceToolStripMenuItem.Text = "Difference";
            this.differenceToolStripMenuItem.Click += new System.EventHandler(this.differenceToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cannyToolStripMenuItem.Text = "Canny";
            this.cannyToolStripMenuItem.Click += new System.EventHandler(this.cannyToolStripMenuItem_Click);
            // 
            // edgesToolStripMenuItem
            // 
            this.edgesToolStripMenuItem.Name = "edgesToolStripMenuItem";
            this.edgesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.edgesToolStripMenuItem.Text = "Edges";
            this.edgesToolStripMenuItem.Click += new System.EventHandler(this.edgesToolStripMenuItem_Click);
            // 
            // laplacianPyramideToolStripMenuItem
            // 
            this.laplacianPyramideToolStripMenuItem.Name = "laplacianPyramideToolStripMenuItem";
            this.laplacianPyramideToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.laplacianPyramideToolStripMenuItem.Text = "Laplacian Pyramide";
            this.laplacianPyramideToolStripMenuItem.Click += new System.EventHandler(this.laplacianPyramideToolStripMenuItem_Click);
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gaussToolStripMenuItem});
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            // 
            // gaussToolStripMenuItem
            // 
            this.gaussToolStripMenuItem.Name = "gaussToolStripMenuItem";
            this.gaussToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.gaussToolStripMenuItem.Text = "Gauss";
            this.gaussToolStripMenuItem.Click += new System.EventHandler(this.gaussToolStripMenuItem_Click);
            // 
            // differenceAllToolStripMenuItem
            // 
            this.differenceAllToolStripMenuItem.Name = "differenceAllToolStripMenuItem";
            this.differenceAllToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.differenceAllToolStripMenuItem.Text = "Difference(All)";
            this.differenceAllToolStripMenuItem.Click += new System.EventHandler(this.differenceAllToolStripMenuItem_Click);
            // 
            // MainMani
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(259, 244);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.MainDockPanel);
            this.Name = "MainMani";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMani_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd_Picture;
        private WeifenLuo.WinFormsUI.Docking.DockPanel MainDockPanel;
        //private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bFTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homogenityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequencyFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd_Picture;
        private System.Windows.Forms.ToolStripMenuItem fitScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem dHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem picToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mathMorphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hitAndMissToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilatationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ditheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bayerMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burkesErrorDiffusionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floydSteinbergErrorDiffusionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisJudiceAndNinkeErrorDiffusionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderedDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sierraErrorDiffusionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stevensonAndArceErrorDiffusionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stuckiErrorDiffusionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianPyramideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequencyFilterPlusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenEXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem substractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTMatchingoneToFirstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramFreqVSLumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bandPassMatchingoneToFirstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleYAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luminanceStatisticsValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSVStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramFreqVsxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yxyStatisticsDellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorCalibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRTNFRIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dELLOKALABToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nECOKALABToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem higlightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statsTransformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelTranslationONETOFIRSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelTranslationALLTOFIRSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteTopHatWTHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackTopHatBTHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kurtosisModificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skewModificationONETOFIRSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastModificationSDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToGrayscaleYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequencyFilterBandPassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastModificationSDALLTOFIRSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skewModificationALLTOFIRSTSkewTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cG245wNFRIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cG245wOKALABToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labStToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cropPatchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squarePatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceAllToolStripMenuItem;
    }
}

