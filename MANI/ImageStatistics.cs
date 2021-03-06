using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace MANI
{
    public partial class ImageStatisticsPanel : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public System.Drawing.Image image;
        public ImageProcessingClass ipc;
        public ImageStatisticsPanel(System.Drawing.Image imagen, String name,ImageProcessingClass ipc)
        {
            InitializeComponent();
            this.TabText = name;
            this.image = imagen;
            this.ipc = ipc;
        }

        private void ImageStatistics_Load(object sender, EventArgs e)
        {
            this.ImageStatsGrid.SelectedObject=new ColorImageStatisticsDescription((Bitmap)image,ipc);
            this.ImageStatsGrid.ExpandAllGridItems();
        }

        private void ImageStatsGrid_Click(object sender, EventArgs e)
        {

        }

       
    }
    internal class ColorImageStatisticsDescription
    {
        private AForge.Imaging.ImageStatistics statRGB;
        private ImageStatisticsHSL statHSL;
        private ImageStatisticsYCbCr statYCbCr;
        public System.Drawing.Image image;
        public ImageProcessingClass ipc;

        // General with black ------------------------------------
        // Total pixels count
        [Category("0: General")]
        public int PixelsCount
        {
            get { return statRGB.PixelsCount; }
        }
        // Pixels without black
        [Category("0: General")]
        public int PixelsWithoutBlack
        {
            get { return statRGB.PixelsCountWithoutBlack; }
        }
        // Pixels without black percentage
        [Category("0: General")]
        public double PixelsWithoutBlackPercentage
        {
            get
            {
                double numm = (double.Parse(statRGB.PixelsCountWithoutBlack.ToString()) / double.Parse(statRGB.PixelsCount.ToString()));
                return 100*numm;
            }
        }
        [Category("1: Luminance")]
        public double MeanL
        {
            get { return this.ipc.extract_Yxy_MEAN(image, ipc.MonitorConfigNumber, 0); }
        }
        [Category("1: Luminance")]
        public double StandardDeviationL
        {
            get { return this.ipc.extract_Yxy_SD(image, ipc.MonitorConfigNumber, 0); }
        }
        [Category("1: Luminance")]
        public double SkewnessL
        {
            get { return this.ipc.extract_Yxy_SKEW(image, ipc.MonitorConfigNumber, 0); }
        }
        [Category("1: Luminance")]
        public double KurtosisL
        {
            get { return this.ipc.extract_Yxy_KURTOSIS(image, ipc.MonitorConfigNumber, 0); }
        }
        [Category("1: x")]
        public double Meanx
        {
            get { return this.ipc.extract_Yxy_MEAN(image, ipc.MonitorConfigNumber, 1); }
        }
        [Category("1: x")]
        public double StandardDeviationx
        {
            get { return this.ipc.extract_Yxy_SD(image, ipc.MonitorConfigNumber, 1); }
        }
        [Category("1: x")]
        public double Skewnessx
        {
            get { return this.ipc.extract_Yxy_SKEW(image, ipc.MonitorConfigNumber, 1); }
        }
        [Category("1: x")]
        public double Kurtosisx
        {
            get { return this.ipc.extract_Yxy_KURTOSIS(image, ipc.MonitorConfigNumber, 1); }
        }
        [Category("1: y")]
        public double Meany
        {
            get { return this.ipc.extract_Yxy_MEAN(image, ipc.MonitorConfigNumber, 2); }
        }
        [Category("1: y")]
        public double StandardDeviationy
        {
            get { return this.ipc.extract_Yxy_SD(image, ipc.MonitorConfigNumber, 2); }
        }
        [Category("1: y")]
        public double Skewnessy
        {
            get { return this.ipc.extract_Yxy_SKEW(image, ipc.MonitorConfigNumber,2); }
        }
        [Category("1: y")]
        public double Kurtosisy
        {
            get { return this.ipc.extract_Yxy_KURTOSIS(image, ipc.MonitorConfigNumber, 2); }
        }

#region RGBHSLYCbCr
        /*
        // Red with black ------------------------------------
        // RedMin		
        [Category("1: Red with black")]
        public int RedMin
        {
            get { return statRGB.Red.Min; }
        }
        // RedMax
        [Category("1: Red with black")]
        public int RedMax
        {
            get { return statRGB.Red.Max; }
        }
        // RedMean
        [Category("1: Red with black")]
        public double RedMean
        {
            get { return statRGB.Red.Mean; }
        }
        // RedStdDev
        [Category("1: Red with black")]
        public double RedStdDev
        {
            get { return statRGB.Red.StdDev; }
        }
        // RedMean
        [Category("1: Red with black")]
        public int RedMedian
        {
            get { return statRGB.Red.Median; }
        }

        // Green with black ------------------------------------
        // GreenMin		
        [Category("2: Green with black")]
        public int GreenMin
        {
            get { return statRGB.Green.Min; }
        }
        // GreenMax
        [Category("2: Green with black")]
        public int GreenMax
        {
            get { return statRGB.Green.Max; }
        }
        // GreenMean
        [Category("2: Green with black")]
        public double GreenMean
        {
            get { return statRGB.Green.Mean; }
        }
        // GreenStdDev
        [Category("2: Green with black")]
        public double GreenStdDev
        {
            get { return statRGB.Green.StdDev; }
        }
        // GreenMean
        [Category("2: Green with black")]
        public int GreenMedian
        {
            get { return statRGB.Green.Median; }
        }

        // Blue with black ------------------------------------
        // BlueMin		
        [Category("3: Blue with black")]
        public int BlueMin
        {
            get { return statRGB.Blue.Min; }
        }
        // BlueMax
        [Category("3: Blue with black")]
        public int BlueMax
        {
            get { return statRGB.Blue.Max; }
        }
        // BlueMean
        [Category("3: Blue with black")]
        public double BlueMean
        {
            get { return statRGB.Blue.Mean; }
        }
        // BlueStdDev
        [Category("3: Blue with black")]
        public double BlueStdDev
        {
            get { return statRGB.Blue.StdDev; }
        }
        // BlueMean
        [Category("3: Blue with black")]
        public int BlueMedian
        {
            get { return statRGB.Blue.Median; }
        }


        // Red without black ------------------------------------
        // RedMinWB		
        [Category("4: Red without black")]
        public int RedMinWB
        {
            get { return statRGB.RedWithoutBlack.Min; }
        }
        // RedMaxWB
        [Category("4: Red without black")]
        public int RedMaxWB
        {
            get { return statRGB.RedWithoutBlack.Max; }
        }
        // RedMeanWB
        [Category("4: Red without black")]
        public double RedMeanWB
        {
            get { return statRGB.RedWithoutBlack.Mean; }
        }
        // RedStdDevWB
        [Category("4: Red without black")]
        public double RedStdDevWB
        {
            get { return statRGB.RedWithoutBlack.StdDev; }
        }
        // RedMeanWB
        [Category("4: Red without black")]
        public int RedMedianWB
        {
            get { return statRGB.RedWithoutBlack.Median; }
        }

        // Green without black ------------------------------------
        // GreenMinWB	
        [Category("5: Green without black")]
        public int GreenMinWB
        {
            get { return statRGB.GreenWithoutBlack.Min; }
        }
        // GreenMaxWB
        [Category("5: Green without black")]
        public int GreenMaxWB
        {
            get { return statRGB.GreenWithoutBlack.Max; }
        }
        // GreenMeanWB
        [Category("5: Green without black")]
        public double GreenMeanWB
        {
            get { return statRGB.GreenWithoutBlack.Mean; }
        }
        // GreenStdDevWB
        [Category("5: Green without black")]
        public double GreenStdDevWB
        {
            get { return statRGB.GreenWithoutBlack.StdDev; }
        }
        // GreenMeanWB
        [Category("5: Green without black")]
        public int GreenMedianWB
        {
            get { return statRGB.GreenWithoutBlack.Median; }
        }

        // Blue without black ------------------------------------
        // BlueMinWB	
        [Category("6: Blue without black")]
        public int BlueMinWB
        {
            get { return statRGB.BlueWithoutBlack.Min; }
        }
        // BlueMaxWB
        [Category("6: Blue without black")]
        public int BlueMaxWB
        {
            get { return statRGB.BlueWithoutBlack.Max; }
        }
        // BlueMeanWB
        [Category("6: Blue without black")]
        public double BlueMeanWB
        {
            get { return statRGB.BlueWithoutBlack.Mean; }
        }
        // BlueStdDevWB
        [Category("6: Blue without black")]
        public double BlueStdDevWB
        {
            get { return statRGB.BlueWithoutBlack.StdDev; }
        }
        // BlueMeanWB
        [Category("6: Blue without black")]
        public int BlueMedianWB
        {
            get { return statRGB.BlueWithoutBlack.Median; }
        }

        // Saturation with black ------------------------------------
        // SaturationMin		
        [Category("7: Saturation with black")]
        public double SaturationMin
        {
            get { return statHSL.Saturation.Min; }
        }
        // SaturationMax
        [Category("7: Saturation with black")]
        public double SaturationMax
        {
            get { return statHSL.Saturation.Max; }
        }
        // SaturationMean
        [Category("7: Saturation with black")]
        public double SaturationMean
        {
            get { return statHSL.Saturation.Mean; }
        }
        // SaturationStdDev
        [Category("7: Saturation with black")]
        public double SaturationStdDev
        {
            get { return statHSL.Saturation.StdDev; }
        }
        // SaturationMean
        [Category("7: Saturation with black")]
        public double SaturationMedian
        {
            get { return statHSL.Saturation.Median; }
        }

        // Luminance with black ------------------------------------
        // LuminanceMin		
        [Category("8: Luminance with black")]
        public double LuminanceMin
        {
            get { return statHSL.Luminance.Min; }
        }
        // LuminanceMax
        [Category("8: Luminance with black")]
        public double LuminanceMax
        {
            get { return statHSL.Luminance.Max; }
        }
        // LuminanceMean
        [Category("8: Luminance with black")]
        public double LuminanceMean
        {
            get { return statHSL.Luminance.Mean; }
        }
        // LuminanceStdDev
        [Category("8: Luminance with black")]
        public double LuminanceStdDev
        {
            get { return statHSL.Luminance.StdDev; }
        }
        // LuminanceMean
        [Category("8: Luminance with black")]
        public double LuminanceMedian
        {
            get { return statHSL.Luminance.Median; }
        }


        // Saturation without black ------------------------------------
        // SaturationMinWB
        [Category("9: Saturation without black")]
        public double SaturationMinWB
        {
            get { return statHSL.SaturationWithoutBlack.Min; }
        }
        // SaturationMaxWB
        [Category("9: Saturation without black")]
        public double SaturationMaxWB
        {
            get { return statHSL.SaturationWithoutBlack.Max; }
        }
        // SaturationMeanWB
        [Category("9: Saturation without black")]
        public double SaturationMeanWB
        {
            get { return statHSL.SaturationWithoutBlack.Mean; }
        }
        // SaturationStdDevWB
        [Category("9: Saturation without black")]
        public double SaturationStdDevWB
        {
            get { return statHSL.SaturationWithoutBlack.StdDev; }
        }
        // SaturationMeanWB
        [Category("9: Saturation without black")]
        public double SaturationMedianWB
        {
            get { return statHSL.SaturationWithoutBlack.Median; }
        }

        // Luminance without black ------------------------------------
        // LuminanceMinWB
        [Category("A: Luminance without black")]
        public double LuminanceMinWB
        {
            get { return statHSL.LuminanceWithoutBlack.Min; }
        }
        // LuminanceMaxWB
        [Category("A: Luminance without black")]
        public double LuminanceMaxWB
        {
            get { return statHSL.LuminanceWithoutBlack.Max; }
        }
        // LuminanceMeanWB
        [Category("A: Luminance without black")]
        public double LuminanceMeanWB
        {
            get { return statHSL.LuminanceWithoutBlack.Mean; }
        }
        // LuminanceStdDevWB
        [Category("A: Luminance without black")]
        public double LuminanceStdDevWB
        {
            get { return statHSL.LuminanceWithoutBlack.StdDev; }
        }
        // LuminanceMeanWB
        [Category("A: Luminance without black")]
        public double LuminanceMedianWB
        {
            get { return statHSL.LuminanceWithoutBlack.Median; }
        }

        // Y with black ------------------------------------
        // YMin		
        [Category("B: Y with black")]
        public double YMin
        {
            get { return statYCbCr.Y.Min; }
        }
        // YMax
        [Category("B: Y with black")]
        public double YMax
        {
            get { return statYCbCr.Y.Max; }
        }
        // YMean
        [Category("B: Y with black")]
        public double YMean
        {
            get { return statYCbCr.Y.Mean; }
        }
        // YStdDev
        [Category("B: Y with black")]
        public double YStdDev
        {
            get { return statYCbCr.Y.StdDev; }
        }
        // YMean
        [Category("B: Y with black")]
        public double YMedian
        {
            get { return statYCbCr.Y.Median; }
        }

        // Cb with black ------------------------------------
        // CbMin		
        [Category("C: Cb with black")]
        public double CbMin
        {
            get { return statYCbCr.Cb.Min; }
        }
        // CbMax
        [Category("C: Cb with black")]
        public double CbMax
        {
            get { return statYCbCr.Cb.Max; }
        }
        // CbMean
        [Category("C: Cb with black")]
        public double CbMean
        {
            get { return statYCbCr.Cb.Mean; }
        }
        // CbStdDev
        [Category("C: Cb with black")]
        public double CbStdDev
        {
            get { return statYCbCr.Cb.StdDev; }
        }
        // CbMean
        [Category("C: Cb with black")]
        public double CbMedian
        {
            get { return statYCbCr.Cb.Median; }
        }

        // Cr with black ------------------------------------
        // CrMin		
        [Category("D: Cr with black")]
        public double CrMin
        {
            get { return statYCbCr.Cr.Min; }
        }
        // CrMax
        [Category("D: Cr with black")]
        public double CrMax
        {
            get { return statYCbCr.Cr.Max; }
        }
        // CrMean
        [Category("D: Cr with black")]
        public double CrMean
        {
            get { return statYCbCr.Cr.Mean; }
        }
        // CrStdDev
        [Category("D: Cr with black")]
        public double CrStdDev
        {
            get { return statYCbCr.Cr.StdDev; }
        }
        // CrMean
        [Category("D: Cr with black")]
        public double CrMedian
        {
            get { return statYCbCr.Cr.Median; }
        }

        // Y without black ------------------------------------
        // YMinWB
        [Category("E: Y without black")]
        public double YMinWB
        {
            get { return statYCbCr.YWithoutBlack.Min; }
        }
        // YMaxWB
        [Category("E: Y without black")]
        public double YMaxWB
        {
            get { return statYCbCr.YWithoutBlack.Max; }
        }
        // YMeanWB
        [Category("E: Y without black")]
        public double YMeanWB
        {
            get { return statYCbCr.YWithoutBlack.Mean; }
        }
        // YStdDevWB
        [Category("E: Y without black")]
        public double YStdDevWB
        {
            get { return statYCbCr.YWithoutBlack.StdDev; }
        }
        // YMeanWB
        [Category("E: Y without black")]
        public double YMedianWB
        {
            get { return statYCbCr.YWithoutBlack.Median; }
        }

        // Cb without black ------------------------------------
        // CbMinWB
        [Category("F: Cb without black")]
        public double CbMinWB
        {
            get { return statYCbCr.CbWithoutBlack.Min; }
        }
        // CbMaxWB
        [Category("F: Cb without black")]
        public double CbMaxWB
        {
            get { return statYCbCr.CbWithoutBlack.Max; }
        }
        // CbMeanWB
        [Category("F: Cb without black")]
        public double CbMeanWB
        {
            get { return statYCbCr.CbWithoutBlack.Mean; }
        }
        // CbStdDevWB
        [Category("F: Cb without black")]
        public double CbStdDevWB
        {
            get { return statYCbCr.CbWithoutBlack.StdDev; }
        }
        // CbMeanWB
        [Category("F: Cb without black")]
        public double CbMedianWB
        {
            get { return statYCbCr.CbWithoutBlack.Median; }
        }

        // Cr without black ------------------------------------
        // CrMinWB
        [Category("G: Cr without black")]
        public double CrMinWB
        {
            get { return statYCbCr.CrWithoutBlack.Min; }
        }
        // CrMaxWB
        [Category("G: Cr without black")]
        public double CrMaxWB
        {
            get { return statYCbCr.CrWithoutBlack.Max; }
        }
        // CrMeanWB
        [Category("G: Cr without black")]
        public double CrMeanWB
        {
            get { return statYCbCr.CrWithoutBlack.Mean; }
        }
        // CrStdDevWB
        [Category("G: Cr without black")]
        public double CrStdDevWB
        {
            get { return statYCbCr.CrWithoutBlack.StdDev; }
        }
        // CrMeanWB
        [Category("G: Cr without black")]
        public double CrMedianWB
        {
            get { return statYCbCr.CrWithoutBlack.Median; }
        }
        */
#endregion

        // Constructor
        public ColorImageStatisticsDescription(Bitmap image,ImageProcessingClass ipc)
        {
            this.image = image;
            this.ipc = ipc;
            // get image dimension
            int width = image.Width;
            int height = image.Height;

            // lock it
            BitmapData imgData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            // gather statistics
            statRGB = new AForge.Imaging.ImageStatistics(imgData);
            statHSL = new ImageStatisticsHSL(imgData);
            statYCbCr = new ImageStatisticsYCbCr(imgData);

        

            // unlock image
            image.UnlockBits(imgData);
        }
    }
}
