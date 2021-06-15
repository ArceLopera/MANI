using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.ComplexFilters;



namespace MANI
{
    public partial class MainMani : Form
    {
        private ImageForm imagen;
        private HistogramForm histograma;
        private ImageStatisticsPanel statistics;
        private ImageListForm imagelistForm;
        private bool flagImageList;
        public ImageProcessingClass ipc;
        public bool BoolSquarePatch = false;


        public ArrayList imagenArray;
        public ArrayList histogramArray;

        public LoadingFrame loadFrame;

        public int[] histogram;


        private int arrayIndex;

        private tresDHistogram tresDHisto;
        public double[,] hisResultALL;

        public int MonitorConfigNumber = 1;
        public int patchX = 0,patchY=0;
        
        
        public MainMani()
        {
            InitializeComponent();
            this.MainDockPanel.Parent = this;
            this.imagenArray = new ArrayList();
            this.histogramArray = new ArrayList();
            this.arrayIndex = 0;
            this.imagelistForm = new ImageListForm(this.imagenArray,this.histogramArray);
            this.flagImageList = true;
            this.histogram = new int[100];
            this.ipc = new ImageProcessingClass(MonitorConfigNumber);
        }

        
       
        #region Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ofd_Picture.Multiselect = true;
            if (this.ofd_Picture.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Visible = false;
                    this.loadFrame = new LoadingFrame(this.ofd_Picture.FileNames.Length);
                    this.loadFrame.Show();
                    this.loadFrame.Visible = true;
                    for (int i = 0; i < this.ofd_Picture.FileNames.Length; i++)
                    {
                        imagen = new ImageForm((System.Drawing.Image)new Bitmap(this.ofd_Picture.FileNames[i]), this.ofd_Picture.FileNames[i], this);
                        
                        this.imagenArray.Add(this.imagen);
                        if (this.ofd_Picture.FileNames.Length < 30)
                        {
                            ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                        }
                        
                        //this.histogramToolStripMenuItem_Click(null, null);
                        this.arrayIndex++;
                        this.loadFrame.plus();
                    }
                    this.loadFrame.Close();
                    this.Visible = true;
                
                }
                catch (Exception em)
                {
                    em.Message.ToString();
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
            {  
                try
                {
                    this.imagen.imagen.Save(this.sfd_Picture.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    
                }
                catch (Exception em)
                {
                    em.Message.ToString();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region View
        
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.histograma = new HistogramForm(this.imagen.imagen, this.imagen.TabText.ToString(),this.MonitorConfigNumber);
            if (this.ofd_Picture.FileNames.Length < 30)
            {
                this.histograma.Show(this.MainDockPanel);
            }
            this.histogramArray.Add(this.histograma);
            int len = 200;
            int[,] histogram = new int[imagenArray.Count, len];
            for (int i = 0; i < imagenArray.Count; i++)
            {
                System.Drawing.Image image = ((ImageForm)imagenArray[i]).imagen;
                int[] histograma1 = this.ipc.extractHistogramYxy(image, len, MonitorConfigNumber, 0);
                for (int j = 0; j < len; j++)
                {
                    histogram[i, j] = histograma1[j];
                }
            }
            
           
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.statistics = new ImageStatisticsPanel(this.imagen.imagen, this.imagen.TabText.ToString(),this.ipc);
            this.statistics.Show(this.MainDockPanel);
        }

        #endregion

        #region Eventos
        private void MainDockPanel_ActiveContentChanged(object sender, EventArgs e)
        {
            DockContent doc = (DockContent)this.MainDockPanel.ActiveContent;
            try
            {
                if (doc != null)
                {
                    this.imagen = (ImageForm)doc;
                }
            }
            catch (Exception ee) 
            {
                ee.Message.ToString();
            }
        }
        #endregion

        #region Fourier Transform
        private void fFTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //Bitmap bito = HistogramForm.convertToLfromLab(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen));
                Bitmap bito = (Bitmap)this.imagen.imagen;
                bito = MainMani.CopyToBpp(bito, 8);
                ComplexImage cp = ComplexImage.FromBitmap(bito);
                cp.ForwardFourierTransform();
               
                bito = cp.ToBitmap();
                
                imagen = new ImageForm(bito, this.imagen.TabText + "FFT",this);

                this.imagenArray.Add(this.imagen);
                
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        private void bFTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                bito = MainMani.CopyToBpp(bito, 8);
                ComplexImage cp = ComplexImage.FromBitmap(bito);

                cp.BackwardFourierTransform();

                bito = cp.ToBitmap();
                imagen = new ImageForm(bito, this.imagen.TabText + "BFT",this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern int DeleteDC(IntPtr hdc);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern int BitBlt(IntPtr hdcDst, int xDst, int yDst, int w, int h, IntPtr hdcSrc, int xSrc, int ySrc, int rop);
        static int SRCCOPY = 0x00CC0020;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO bmi, uint Usage, out IntPtr bits, IntPtr hSection, uint dwOffset);
        static uint BI_RGB = 0;
        static uint DIB_RGB_COLORS = 0;
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            public uint biSize;
            public int biWidth, biHeight;
            public short biPlanes, biBitCount;
            public uint biCompression, biSizeImage;
            public int biXPelsPerMeter, biYPelsPerMeter;
            public uint biClrUsed, biClrImportant;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 256)]
            public uint[] cols;
        }

        static uint MAKERGB(int r, int g, int b)
        {
            return ((uint)(b & 255)) | ((uint)((r & 255) << 8)) | ((uint)((g & 255) << 16));
        }
        /// <summary>
        /// Copies a bitmap into a 1bpp/8bpp bitmap of the same dimensions, fast
        /// </summary>
        /// <param name="b">original bitmap</param>
        /// <param name="bpp">1 or 8, target bpp</param>
        /// <returns>a 1bpp copy of the bitmap</returns>
        static System.Drawing.Bitmap CopyToBpp(System.Drawing.Bitmap b, int bpp)
        {
            if (bpp != 1 && bpp != 8) throw new System.ArgumentException("1 or 8", "bpp");

            // Plan: built into Windows GDI is the ability to convert
            // bitmaps from one format to another. Most of the time, this
            // job is actually done by the graphics hardware accelerator card
            // and so is extremely fast. The rest of the time, the job is done by
            // very fast native code.
            // We will call into this GDI functionality from C#. Our plan:
            // (1) Convert our Bitmap into a GDI hbitmap (ie. copy unmanaged->managed)
            // (2) Create a GDI monochrome hbitmap
            // (3) Use GDI "BitBlt" function to copy from hbitmap into monochrome (as above)
            // (4) Convert the monochrone hbitmap into a Bitmap (ie. copy unmanaged->managed)

            int w = b.Width, h = b.Height;
            IntPtr hbm = b.GetHbitmap(); // this is step (1)
            //
            // Step (2): create the monochrome bitmap.
            // "BITMAPINFO" is an interop-struct which we define below.
            // In GDI terms, it's a BITMAPHEADERINFO followed by an array of two RGBQUADs
            BITMAPINFO bmi = new BITMAPINFO();
            bmi.biSize = 40;  // the size of the BITMAPHEADERINFO struct
            bmi.biWidth = w;
            bmi.biHeight = h;
            bmi.biPlanes = 1; // "planes" are confusing. We always use just 1. Read MSDN for more info.
            bmi.biBitCount = (short)bpp; // ie. 1bpp or 8bpp
            bmi.biCompression = BI_RGB; // ie. the pixels in our RGBQUAD table are stored as RGBs, not palette indexes
            bmi.biSizeImage = (uint)(((w + 7) & 0xFFFFFFF8) * h / 8);
            bmi.biXPelsPerMeter = 1000000; // not really important
            bmi.biYPelsPerMeter = 1000000; // not really important
            // Now for the colour table.
            uint ncols = (uint)1 << bpp; // 2 colours for 1bpp; 256 colours for 8bpp
            bmi.biClrUsed = ncols;
            bmi.biClrImportant = ncols;
            bmi.cols = new uint[256]; // The structure always has fixed size 256, even if we end up using fewer colours
            if (bpp == 1) { bmi.cols[0] = MAKERGB(0, 0, 0); bmi.cols[1] = MAKERGB(255, 255, 255); }
            else { for (int i = 0; i < ncols; i++) bmi.cols[i] = MAKERGB(i, i, i); }
            // For 8bpp we've created an palette with just greyscale colours.
            // You can set up any palette you want here. Here are some possibilities:
            // greyscale: for (int i=0; i<256; i++) bmi.cols[i]=MAKERGB(i,i,i);
            // rainbow: bmi.biClrUsed=216; bmi.biClrImportant=216; int[] colv=new int[6]{0,51,102,153,204,255};
            //          for (int i=0; i<216; i++) bmi.cols[i]=MAKERGB(colv[i/36],colv[(i/6)%6],colv[i%6]);
            // optimal: a difficult topic: http://en.wikipedia.org/wiki/Color_quantization
            // 
            // Now create the indexed bitmap "hbm0"
            IntPtr bits0; // not used for our purposes. It returns a pointer to the raw bits that make up the bitmap.
            IntPtr hbm0 = CreateDIBSection(IntPtr.Zero, ref bmi, DIB_RGB_COLORS, out bits0, IntPtr.Zero, 0);
            //
            // Step (3): use GDI's BitBlt function to copy from original hbitmap into monocrhome bitmap
            // GDI programming is kind of confusing... nb. The GDI equivalent of "Graphics" is called a "DC".
            IntPtr sdc = GetDC(IntPtr.Zero);       // First we obtain the DC for the screen
            // Next, create a DC for the original hbitmap
            IntPtr hdc = CreateCompatibleDC(sdc); SelectObject(hdc, hbm);
            // and create a DC for the monochrome hbitmap
            IntPtr hdc0 = CreateCompatibleDC(sdc); SelectObject(hdc0, hbm0);
            // Now we can do the BitBlt:
            BitBlt(hdc0, 0, 0, w, h, hdc, 0, 0, SRCCOPY);
            // Step (4): convert this monochrome hbitmap back into a Bitmap:
            System.Drawing.Bitmap b0 = System.Drawing.Bitmap.FromHbitmap(hbm0);
            //
            // Finally some cleanup.
            DeleteDC(hdc);
            DeleteDC(hdc0);
            ReleaseDC(IntPtr.Zero, sdc);
            DeleteObject(hbm);
            DeleteObject(hbm0);
            //
            return b0;
        }
        private void frequencyFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                int min;
                int max;
                int ancho = 10;
                int numerodebandas = 10;
                double[, ,] stats = new double[8, numerodebandas, this.imagenArray.Count];
                for (int j = 0; j < this.imagenArray.Count; j++)
                {
                    min = 0;
                    max = ancho;
                    for (int i = 0; i < numerodebandas; i++)
                    {
                        Bitmap bito = AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[j]).imagen);
                        //NFRI CRT:total 87.95      R=17.11/87.95=0.19454  G=0.6762  B=0.1293
                        //Grayscale GSfilter = new Grayscale(0.19454, 0.6762, 0.1293);
                        //CG245w NFRI total 121.6089     R=34.9726/121.6089=  0.28758257 G=79.2232/121.6089=0.65145889815630270481847956851842  B=7.4131/121.6089=0.060958531817983716652317387954336

                        Grayscale GSfilter = new Grayscale(0.28758257, 0.651458898, 0.060958532);
                        Bitmap grayImage = GSfilter.Apply(bito);
                        //Bitmap grayImage = Grayscale.CommonAlgorithms.Y.Apply(bito);
                        //Bitmap grayImage = new Bitmap(bito.Width,bito.Height,PixelFormat.Format8bppIndexed);
                        //this.ipc.convertTo8bpp(UnmanagedImage.FromManagedImage(bito), UnmanagedImage.FromManagedImage(grayImage));
                        //Bitmap bito = this.ipc.convertToChannelfromYxy(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen),this.MonitorConfigNumber,0);
                        //Bitmap b2 = bito;// MainMani.CopyToBpp(bito, 8);
                        ComplexImage cp = ComplexImage.FromBitmap(grayImage);

                        cp.ForwardFourierTransform();
                        ////bandpass filtering
                        FrequencyFilter filter = new FrequencyFilter(new IntRange(min, max));
                        stats[0, i, j] = filter.ApplyMeanMagnitude(cp);
                        stats[1, i, j] = filter.ApplySDMagnitude(cp, stats[0, i, j]);
                        stats[2, i, j] = filter.ApplySkewMagnitude(cp, stats[0, i, j], stats[1, i, j]);
                        stats[3, i, j] = filter.ApplyKurtMagnitude(cp, stats[0, i, j], stats[1, i, j]);
                        stats[4, i, j] = filter.ApplyMeanPhase(cp);
                        stats[5, i, j] = filter.ApplysdPhase(cp, stats[4, i, j]);
                        stats[6, i, j] = filter.ApplyskewPhase(cp, stats[4, i, j], stats[5, i, j]);
                        stats[7, i, j] = filter.ApplykurtPhase(cp, stats[4, i, j], stats[5, i, j]);
                        min += ancho;
                        max += ancho;
                    }
                }
                TextWriter tw = new StreamWriter("resultsFFT.csv");

                for (int i = 0; i < this.imagenArray.Count; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int k = 0; k < numerodebandas; k++)
                        {
                            tw.Write(stats[j, k, i] + ",");
                        }
                    }
                    tw.WriteLine(",");
                }
                tw.Flush();
                tw.Close();
                ////cp.FrequencyFilterInverse(new AForge.IntRange(min, max), 0);

                //cp.BackwardFourierTransform();

                //grayImage = cp.ToBitmap();
                
                ////bito = cp.ToBitmapPHASE();
                ////bito = this.ipc.BW2ColorFFT(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen), (System.Drawing.Image)bito,this.MonitorConfigNumber);
                //imagen = new ImageForm(grayImage, this.imagen.TabText + "FF" + min + "-" + max);

                //this.imagenArray.Add(this.imagen);

                //((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                //this.arrayIndex++;
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        #endregion

        #region Edge Detectors
        private void homogenityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.HomogenityEdgeDetector();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "HomogenityEdgeDetector", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void differenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.DifferenceEdgeDetector();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "DifferenceEdgeDetector",this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.SobelEdgeDetector();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "SobelEdgeDetector", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.CannyEdgeDetector();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "CannyEdgeDetector",this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }
        #endregion

        #region Color Filters
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.GrayscaleY();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "GrayscaleY", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void grayscaleToRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.GrayscaleToRGB();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "GrayscaleToRGB",this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.Sepia();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Sepia", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void invertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.Invert();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Invert",this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.RotateChannels();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "RotateChannels", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }
        #endregion

       

        
        private void fitScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.imagen.ImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                this.imagen.AutoScrollMinSize = new Size(0,0);
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tresDHisto = new tresDHistogram();
            try
            {
                this.tresDHisto.TabText = "3D Histogram Mean";
                this.tresDHisto.glControl.HistogramList = this.histogramArray;
                this.tresDHisto.Show(this.MainDockPanel);
            }
            catch (Exception em)
            {
                em.Message.ToString();

            }
        }

        private void redChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tresDHisto = new tresDHistogram();
            try
            {
                this.tresDHisto.glControl.HistogramList = this.histogramArray;
                this.tresDHisto.glControl.opcion = 1;
                this.tresDHisto.TabText = "3D Histogram Red";
                this.tresDHisto.Show(this.MainDockPanel);
            }
            catch (Exception em)
            {
                em.Message.ToString();

            }
        }

        private void greenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tresDHisto = new tresDHistogram();
            try
            {
                this.tresDHisto.glControl.HistogramList = this.histogramArray;
                this.tresDHisto.TabText = "3D Histogram Green";
                this.tresDHisto.glControl.opcion = 2;
                this.tresDHisto.Show(this.MainDockPanel);
            }
            catch (Exception em)
            {
                em.Message.ToString();

            }
        }

        private void blueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tresDHisto = new tresDHistogram();
            try
            {
                this.tresDHisto.glControl.HistogramList = this.histogramArray;
                this.tresDHisto.TabText = "3D Histogram Blue";
                this.tresDHisto.glControl.opcion = 3;
                this.tresDHisto.Show(this.MainDockPanel);
            }
            catch (Exception em)
            {
                em.Message.ToString();

            }
        }

        

       

        private void imageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.flagImageList)
            {
                this.imagelistForm.Show(this.MainDockPanel);
                this.flagImageList = false;
            }
            else
            {
                this.imagelistForm = new ImageListForm(this.imagenArray, this.histogramArray);
                this.imagelistForm.Show(this.MainDockPanel);
                this.flagImageList = true;
            }
        }

        private void picToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)((ImageForm)this.imagenArray[0]).imagen;
                Bitmap bito2;




                    bito2 = (Bitmap)this.imagen.imagen;
                    AForge.Imaging.Image.FormatImage(ref bito);
                    IFilter filter = new AForge.Imaging.Filters.Morph(bito2);

                    bito = filter.Apply(bito);


                    imagen = new ImageForm(bito, this.imagen.TabText + "Morph0.5", this);

                    this.imagenArray.Add(this.imagen);
                    ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                    this.arrayIndex++;
                
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

       

        private void differenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.Difference((Bitmap)((ImageForm)this.imagenArray[0]).imagen);

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Difference", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.Edges();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Edges",this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void laplacianPyramideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                Bitmap bitoO = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.GaussianBlur(10.25);

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Gaussianblur", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;

                AForge.Imaging.Image.FormatImage(ref bito);
                filter = new AForge.Imaging.Filters.Difference(bitoO);

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Difference", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

       
        
       
        private void histogramMatchingMeanLuminanceConservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Histogram Matching + Mean Luminance Conservation
            this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen,100,this.MonitorConfigNumber,0,true);
            this.Refresh();
        }

        private void allHMMLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 1; i < this.imagenArray.Count; i++)
                    {
                        this.imagen.imagen = ((ImageForm)this.imagenArray[i]).imagen;
                        this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, 100, this.MonitorConfigNumber, 0, true);
                        this.imagen.imagen.Save(this.sfd_Picture.FileName +((ImageForm)this.imagenArray[i]).id + "to" + ((ImageForm)this.imagenArray[0]).id + ".bmp");

                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
            this.Refresh();
        }

        private void MainMani_Load(object sender, EventArgs e)
        {

        }

        private void frequencyFilterPlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            
            {
                int min = 10;
                int max = 20;
                Bitmap bito = AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen);
                
                //NFRI CRT:total 87.95      R=17.11/87.95=0.19454  G=0.6762  B=0.1293
                Grayscale GSfilter = new Grayscale(0.19454, 0.6762, 0.1293);
                Bitmap grayImage = GSfilter.Apply(bito);
                        //Bitmap grayImage = new Bitmap(bito.Width,bito.Height,PixelFormat.Format8bppIndexed);
                        //this.ipc.convertTo8bpp(UnmanagedImage.FromManagedImage(bito), UnmanagedImage.FromManagedImage(grayImage));
                        //Bitmap bito = this.ipc.convertToChannelfromYxy(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen),this.MonitorConfigNumber,0);
                        //Bitmap b2 = bito;// MainMani.CopyToBpp(bito, 8);
                        ComplexImage cp = ComplexImage.FromBitmap(grayImage);

                        cp.ForwardFourierTransform();
                        ////bandpass filtering
                        FrequencyFilter filter = new FrequencyFilter(new IntRange(min, max));
                        filter.ApplyInverse(cp);
                       

                cp.BackwardFourierTransform();

                grayImage = cp.ToBitmap();

                ////bito = cp.ToBitmapPHASE();
                ////bito = this.ipc.BW2ColorFFT(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen), (System.Drawing.Image)bito,this.MonitorConfigNumber);
                imagen = new ImageForm(grayImage, this.imagen.TabText + "FF" + min + "-" + max, this);

                this.imagenArray.Add(this.imagen);

                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;

            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.Sharpen();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Sharpen", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void sharpenEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.Sharpen();

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Sharpen ", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void substractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.imagen.imagen;
                AForge.Imaging.Image.FormatImage(ref bito);
                IFilter filter = new AForge.Imaging.Filters.Subtract((Bitmap)((ImageForm)this.imagenArray[0]).imagen);

                bito = filter.Apply(bito);
                imagen = new ImageForm(bito, this.imagen.TabText + "Subtract ", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void fFTMatchingoneToFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bito=null;
            try
            {
                //Bitmap origin = HistogramForm.convertToLfromLab(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen));
                //Bitmap target = HistogramForm.convertToLfromLab(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[0]).imagen));

                //ComplexImage cpOrigin = ComplexImage.FromBitmap(origin);
                //ComplexImage cpTarget = ComplexImage.FromBitmap(target);

                //cpOrigin.ForwardFourierTransform();
                //cpTarget.ForwardFourierTransform();
                

                ////double[] hisTarget = cpTarget.HistogramFreqVSLum2(5);
                ////double[] hisResult = cpOrigin.HistogramFreqVSLum(5);
                ////cpOrigin.matchingFFT(hisTarget,hisResult, 5,0.0011);
                //cpOrigin.matchingFFT(cpTarget.data, 0.004);

                ////hisResult = cpOrigin.HistogramFreqVSLum(5);
                //cpOrigin.BackwardFourierTransform();

                //bito = cpOrigin.ToBitmap();

                //bito = HistogramForm.BW2ColorFFT(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen), (System.Drawing.Image)bito);

                //this.imagen = new ImageForm(bito, this.imagen.TabText + "FF2MATCHING");

                //this.imagenArray.Add(this.imagen);

                //((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                //this.arrayIndex++;
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        private void meanLuminanceTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //only translation
            this.ipc.meanT(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen,this.MonitorConfigNumber,0);
            this.Refresh();
        }

        private void histogramFreqVSLumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Bitmap target;
                //ComplexImage cpTarget;
                //double[] hisResult;
                
                //this.hisResultALL = new double[this.imagenArray.Count, 512];
                //for (int i = 0; i < this.imagenArray.Count; i++)
                //{
                //    //target = HistogramForm.convertToLfromLab(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[i]).imagen));
                //    target = this.ipc.convertToChannelfromYxy(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[i]).imagen),MonitorConfigNumber,0);
                //    cpTarget = ComplexImage.FromBitmap(target);
                //    cpTarget.ForwardFourierTransform();
                //    hisResult = cpTarget.HistogramFreqVSLum(5);
                //    for (int j = 0; j < hisResult.Length; j++)
                //    {
                //        hisResultALL[i, j] = hisResult[j];
                //    }
                //}
                //this.grabarResult();
                
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        public void grabarResult() 
        {
            TextWriter tw = new StreamWriter("results.csv");

            for (int i = 0; i < this.imagenArray.Count; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    tw.Write(hisResultALL[i, j]+",");
                }
                tw.WriteLine(",");
            }

           
            tw.Close();
        }

        private void bandPassMatchingoneToFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                //Bitmap target;
                //ComplexImage cpTarget;
                //double[] hisResult;

                //this.hisResultALL = new double[this.imagenArray.Count, 512];
                //for (int i = 0; i < this.imagenArray.Count; i++)
                //{
                //    //target = HistogramForm.convertToLfromLab(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[i]).imagen));
                //    target = this.ipc.convertToChannelfromYxy(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[i]).imagen), MonitorConfigNumber, 0);
                //    cpTarget = ComplexImage.FromBitmap(target);
                //    cpTarget.ForwardFourierTransform();
                //    hisResult = cpTarget.HistogramFreqVSLum(1);
                //    for (int j = 0; j < hisResult.Length; j++)
                //    {
                //        hisResultALL[i, j] = hisResult[j];
                //    }
                //}


            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }


            try
            {
                if (hisResultALL != null)
                {

                    //int min =0;
                    //int prin = min;
                    //int max = min+1;

                    //Bitmap bito = this.histograma.convertToChannelfromXYZ(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[i]).imagen), MonitorConfigNumber, 1);
                    //ComplexImage cp = ComplexImage.FromBitmap(bito);
                    //cp.ForwardFourierTransform();
                    ////lowpass filtering
                    //for (int i = 0; i <362;i++ )//73
                    //{
                    //    double propor=hisResultALL[0,i]/hisResultALL[1,i];
                    //    cp.FrequencyFilterInverse(new AForge.IntRange(min, max), propor);
                    //    min += 1;
                    //    max += 1;
                    //}
                    //cp.BackwardFourierTransform();

                    //bito = cp.ToBitmap();
                    ////bito = cp.ToBitmapPHASE();
                    //bito = HistogramForm.BW2ColorFFT(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen), (System.Drawing.Image)bito);
                    //imagen = new ImageForm(bito, this.imagen.TabText + "BF" + prin + "-" + max);

                    //this.imagenArray.Add(this.imagen);

                    //((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                    //this.arrayIndex++;
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }

            //only translation
            this.ipc.meanT(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen,MonitorConfigNumber,0);
            this.Refresh();
        }

        private void hMMLCFIRSTTOALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        

       

        private void inverseSkewnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ipc.inverseSkew(this.imagen.imagen,MonitorConfigNumber,0);
            this.Refresh();
            
        }

     

        private void grayscaleYAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        System.Drawing.Image BASE = (System.Drawing.Image)((ImageForm)this.imagenArray[i]).imagen.Clone();
                        Bitmap bito = (Bitmap)BASE;
                        AForge.Imaging.Image.FormatImage(ref bito);
                        //OKALABCG245
                        IFilter filter = new AForge.Imaging.Filters.Grayscale(0.256256378, 0.680114433926427, 0.0636291885349086);

                        bito = filter.Apply(bito);
                        
                        AForge.Imaging.Image.FormatImage(ref bito);
                        filter = new AForge.Imaging.Filters.GrayscaleToRGB();

                        bito = filter.Apply(bito);

                        BASE = (System.Drawing.Image)bito;

                        BASE.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + ".bmp");
                        
                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void meanLuminanceTranslationALLTOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Image TARGET = (System.Drawing.Image)((ImageForm)this.imagenArray[0]).imagen.Clone();

                    for (int i = 1; i < this.imagenArray.Count; i++)
                    {
                        System.Drawing.Image BASE = (System.Drawing.Image)((ImageForm)this.imagenArray[i]).imagen.Clone();

                        BASE = this.ipc.meanT(BASE, TARGET,MonitorConfigNumber,0);
                        BASE.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + ".bmp");
                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

     

        private void luminanceStatisticsValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] allhiY = this.ipc.all_Yxy_Stats(this.imagenArray,MonitorConfigNumber , 0);
            double[,] allhix = this.ipc.all_Yxy_Stats(this.imagenArray, MonitorConfigNumber, 1);
            double[,] allhiy = this.ipc.all_Yxy_Stats(this.imagenArray, MonitorConfigNumber, 2);
            
            
        }

      

        private void hSVStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] allhi_s = ImageProcessingClass.all_HSL_Stats(this.imagenArray,1);
            double[,] allhi_h = ImageProcessingClass.all_HSL_Stats(this.imagenArray,0);
            double[,] allhi_l = ImageProcessingClass.all_HSL_Stats(this.imagenArray,2);
        }

        private void histogramFreqVsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Bitmap target;
                //ComplexImage cpTarget;
                //double[] hisResult;

                //this.hisResultALL = new double[this.imagenArray.Count, 512];
                //for (int i = 0; i < this.imagenArray.Count; i++)
                //{
                //    //target = HistogramForm.convertToLfromLab(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[i]).imagen));
                //    target = this.ipc.convertToChannelfromYxy(AForge.Imaging.Image.Clone((Bitmap)((ImageForm)this.imagenArray[i]).imagen),MonitorConfigNumber,1);
                //    cpTarget = ComplexImage.FromBitmap(target);
                //    cpTarget.ForwardFourierTransform();
                //    hisResult = cpTarget.HistogramFreqVSLum(5);
                //    for (int j = 0; j < hisResult.Length; j++)
                //    {
                //        hisResultALL[i, j] = hisResult[j];
                //    }
                //}
                //this.grabarResult();

            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        private void hMMxCONETOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Histogram Matching + Mean x Conservation
            this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen,100,this.MonitorConfigNumber,1,true);
            this.Refresh();
       
        }

        private void hMMyCONETOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Histogram Matching + Mean y Conservation
            this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, 100, this.MonitorConfigNumber, 2,true);
            this.Refresh();
       
        
        }

        private void hMMallCALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 1; i < this.imagenArray.Count; i++)
                    {
                        this.imagen.imagen = ((ImageForm)this.imagenArray[i]).imagen;
                        this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, 100, this.MonitorConfigNumber, 2,true);
                        this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, 100, this.MonitorConfigNumber, 1, true);
                        this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, 100, this.MonitorConfigNumber, 0, true);
                        this.imagen.imagen.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + "to" + ((ImageForm)this.imagenArray[0]).id + ".bmp");

                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
            this.Refresh();
        }

        private void hMMLyCALLTOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 1; i < this.imagenArray.Count; i++)
                    {
                        this.imagen.imagen = ((ImageForm)this.imagenArray[i]).imagen;
                        this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, 100, this.MonitorConfigNumber, 2, true);
                        this.ipc.HistogramMatching(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, 100, this.MonitorConfigNumber, 0, true);
                        this.imagen.imagen.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + "to" + ((ImageForm)this.imagenArray[0]).id + ".bmp");

                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
            this.Refresh();
        }
        
        private void yxyStatisticsDellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    double[,] allhiY = this.ipc.all_Yxy_Stats(this.imagenArray, MonitorConfigNumber, 0);
                    double[,] allhisx = this.ipc.all_Yxy_Stats(this.imagenArray, MonitorConfigNumber, 1);
                    double[,] allhisy = this.ipc.all_Yxy_Stats(this.imagenArray, MonitorConfigNumber, 2);

                    TextWriter tw = new StreamWriter(this.sfd_Picture.FileName + "resultsLuminance.csv");

                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            tw.Write(allhiY[i, j] + ",");
                        }
                        tw.WriteLine(",");
                    }
                    tw.Flush();
                    tw.Close();


                    tw = new StreamWriter(this.sfd_Picture.FileName + "resultsx.csv");

                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            tw.Write(allhisx[i, j] + ",");
                        }
                        tw.WriteLine(",");
                    }
                    tw.Flush();
                    tw.Close();
                    tw = new StreamWriter(this.sfd_Picture.FileName + "resultsy.csv");

                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            tw.Write(allhisy[i, j] + ",");
                        }
                        tw.WriteLine(",");
                    }
                    tw.Flush();
                    tw.Close();
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
           
        }

        private void gaussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                   
                        Bitmap bito = (Bitmap)this.imagen.imagen;
                        AForge.Imaging.Image.FormatImage(ref bito);
                        IFilter filter = new AForge.Imaging.Filters.GaussianBlur(4,11);
                        bito = filter.Apply(bito);
                        imagen = new ImageForm(bito, this.imagen.TabText + "Blur", this);

                        this.imagenArray.Add(this.imagen);
                        ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                        this.arrayIndex++;
                        
                       
                    
                
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
          
        }

        private void cRTNFRIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cRTNFRIToolStripMenuItem.Checked = true;
            this.dELLOKALABToolStripMenuItem.Checked = false;
            this.nECOKALABToolStripMenuItem.Checked = false;
            this.lCDToolStripMenuItem.Checked = false;
            this.cG245wOKALABToolStripMenuItem.Checked = false;
            this.cG245wNFRIToolStripMenuItem.Checked = false;
            this.MonitorConfigNumber = 1;
            
            this.ipc.SetMonitorConfiguration(this.MonitorConfigNumber);
           
        }
        private void cG245wNFRIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cRTNFRIToolStripMenuItem.Checked = false;
            this.cG245wOKALABToolStripMenuItem.Checked = false;
            this.cG245wNFRIToolStripMenuItem.Checked = true;
            this.dELLOKALABToolStripMenuItem.Checked = false;
            this.nECOKALABToolStripMenuItem.Checked = false;
            this.lCDToolStripMenuItem.Checked = false;
            this.MonitorConfigNumber = 5;

            this.ipc.SetMonitorConfiguration(this.MonitorConfigNumber);
        }
        private void cG245wOKALABToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cRTNFRIToolStripMenuItem.Checked = false;
            this.cG245wOKALABToolStripMenuItem.Checked = true;
            this.cG245wNFRIToolStripMenuItem.Checked = false;
            this.dELLOKALABToolStripMenuItem.Checked =false;
            this.nECOKALABToolStripMenuItem.Checked = false;
            this.lCDToolStripMenuItem.Checked = false;
            this.MonitorConfigNumber = 6;

            this.ipc.SetMonitorConfiguration(this.MonitorConfigNumber);
        }
        private void dELLOKALABToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cRTNFRIToolStripMenuItem.Checked = false;
            this.dELLOKALABToolStripMenuItem.Checked = true;
            this.nECOKALABToolStripMenuItem.Checked = false;
            this.lCDToolStripMenuItem.Checked = false;
            this.cG245wOKALABToolStripMenuItem.Checked = false;
            this.cG245wNFRIToolStripMenuItem.Checked = false;
            this.MonitorConfigNumber = 2;
            this.ipc.SetMonitorConfiguration(this.MonitorConfigNumber);
            
        }

        private void nECOKALABToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cRTNFRIToolStripMenuItem.Checked = false;
            this.dELLOKALABToolStripMenuItem.Checked = false;
            this.nECOKALABToolStripMenuItem.Checked = true;
            this.lCDToolStripMenuItem.Checked = false;
            this.cG245wOKALABToolStripMenuItem.Checked = false;
            this.cG245wNFRIToolStripMenuItem.Checked = false;
            this.MonitorConfigNumber = 3;
            this.ipc.SetMonitorConfiguration(this.MonitorConfigNumber);
           
        }
        private void lCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cRTNFRIToolStripMenuItem.Checked = false;
            this.dELLOKALABToolStripMenuItem.Checked = false;
            this.nECOKALABToolStripMenuItem.Checked = false;
            this.lCDToolStripMenuItem.Checked = true;
            this.cG245wOKALABToolStripMenuItem.Checked = false;
            this.cG245wNFRIToolStripMenuItem.Checked = false;
            this.MonitorConfigNumber = 4;
            this.ipc.SetMonitorConfiguration(this.MonitorConfigNumber);
        }

        private void channelTranslationONETOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //only translation
            try
            {
                Bitmap bito = (Bitmap)this.ipc.meanT(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, this.MonitorConfigNumber, 0);
                imagen = new ImageForm(bito, this.imagen.TabText + "MeanTranslation", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void channelTranslationALLTOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Image TARGET = (System.Drawing.Image)((ImageForm)this.imagenArray[0]).imagen.Clone();

                    for (int i = 1; i < this.imagenArray.Count; i++)
                    {
                        System.Drawing.Image BASE = (System.Drawing.Image)((ImageForm)this.imagenArray[i]).imagen.Clone();

                        BASE = this.ipc.meanT(BASE, TARGET, MonitorConfigNumber, 0);
                        BASE.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + ".bmp");
                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void histogramMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.imagenArray.Count >= 2)
            {
                HMParameters hmp = new HMParameters(this.imagen.TabText, ((ImageForm)this.imagenArray[0]).TabText, this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, this);
                hmp.ShowDialog();
            }
            else 
            {
                MessageBox.Show("First Open Image Files");
            }
        }

        private void inverseSkewnessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ipc.inverseSkew(this.imagen.imagen, MonitorConfigNumber, 0);
            this.Refresh();
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
             IFilter filter = new AForge.Imaging.Filters.Opening();
             Bitmap bito = (Bitmap)this.imagen.imagen;
             AForge.Imaging.Image.FormatImage(ref bito);
             filter.Apply(bito);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new AForge.Imaging.Filters.Closing();
            Bitmap bito = (Bitmap)this.imagen.imagen;
            AForge.Imaging.Image.FormatImage(ref bito);
            filter.Apply(bito);
        }

        private void whiteTopHatWTHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create filter
            AForge.Imaging.Filters.TopHat filter = new TopHat();
            Bitmap bito = (Bitmap)this.imagen.imagen;
            AForge.Imaging.Image.FormatImage(ref bito);
            // apply the filter
            filter.Apply(bito);


        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagen.imagen=this.ipc.threshold(this.imagen.imagen, 0, 36, this.MonitorConfigNumber);
            this.Refresh();
        }

        private void sDMoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.ipc.SDM(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, this.MonitorConfigNumber, 0);
                imagen = new ImageForm(bito, this.imagen.TabText + "SDModification", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
            
        }

        private void skewModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            try
            {
                Bitmap bito = (Bitmap)this.ipc.SkewM(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, this.MonitorConfigNumber, 0);
                imagen = new ImageForm(bito, this.imagen.TabText + "SkewModification", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void kurtosisModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                Bitmap bito = (Bitmap)this.ipc.KurtM(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, this.MonitorConfigNumber, 0);
                imagen = new ImageForm(bito, this.imagen.TabText + "KurtModificationSDTarget", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void skewModificationONETOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.ipc.SkewM1(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, this.MonitorConfigNumber, 0);
                imagen = new ImageForm(bito, this.imagen.TabText + "SkewModification1", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void removalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void additionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)((ImageForm)this.imagenArray[0]).imagen;
               
                Bitmap bito3=new Bitmap(bito.Width, bito.Height, PixelFormat.Format32bppRgb);
                Graphics g = Graphics.FromImage(bito3);
                g.DrawImage(bito, new Point(0, 0));
                g.Dispose();

                Bitmap bito2;
                bito2 = (Bitmap)this.imagen.imagen;
                
               
                IFilter filter = new AForge.Imaging.Filters.Add(bito2);

               
                bito3 = filter.Apply(bito3);


                imagen = new ImageForm(bito3, this.imagen.TabText + "Add", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;

            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void contrastModificationSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bito = (Bitmap)this.ipc.SDMa(this.imagen.imagen, ((ImageForm)this.imagenArray[0]).imagen, this.MonitorConfigNumber, 0);
                imagen = new ImageForm(bito, this.imagen.TabText + "ContrastSDModification", this);

                this.imagenArray.Add(this.imagen);
                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void bayerMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frequencyFilterBandPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int min = 10;
                int max = 20;
                Bitmap bito = AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen);

                //NFRI CRT:total 87.95      R=17.11/87.95=0.19454  G=0.6762  B=0.1293
                Grayscale GSfilter = new Grayscale(0.19454, 0.6762, 0.1293);
                Bitmap grayImage = GSfilter.Apply(bito);
                ComplexImage cp = ComplexImage.FromBitmap(grayImage);

                cp.ForwardFourierTransform();
                ////bandpass filtering
                FrequencyFilter filter = new FrequencyFilter(new IntRange(min, max));
                filter.Apply(cp);


                cp.BackwardFourierTransform();

                grayImage = cp.ToBitmap();

                ////bito = cp.ToBitmapPHASE();
                ////bito = this.ipc.BW2ColorFFT(AForge.Imaging.Image.Clone((Bitmap)this.imagen.imagen), (System.Drawing.Image)bito,this.MonitorConfigNumber);
                imagen = new ImageForm(grayImage, this.imagen.TabText + "FF" + min + "-" + max, this);

                this.imagenArray.Add(this.imagen);

                ((ImageForm)this.imagenArray[arrayIndex]).Show(this.MainDockPanel);
                this.arrayIndex++;

            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        private void rGBStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] allhiR = this.ipc.all_RGB_Stats(this.imagenArray, MonitorConfigNumber, 0);
            double[,] allhiG = this.ipc.all_RGB_Stats(this.imagenArray, MonitorConfigNumber, 1);
            double[,] allhiB = this.ipc.all_RGB_Stats(this.imagenArray, MonitorConfigNumber, 2);

            TextWriter tw = new StreamWriter("resultsR.csv");

            for (int i = 0; i < this.imagenArray.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tw.Write(allhiR[i, j] + ",");
                }
                tw.WriteLine(",");
            }
            tw.Flush();
            tw.Close();


            tw = new StreamWriter("resultsG.csv");

            for (int i = 0; i < this.imagenArray.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tw.Write(allhiG[i, j] + ",");
                }
                tw.WriteLine(",");
            }
            tw.Flush();
            tw.Close();
            tw = new StreamWriter("resultsB.csv");

            for (int i = 0; i < this.imagenArray.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tw.Write(allhiB[i, j] + ",");
                }
                tw.WriteLine(",");
            }
            tw.Flush();
            tw.Close();
        }

        private void contrastModificationSDALLTOFIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Image TARGET = (System.Drawing.Image)((ImageForm)this.imagenArray[0]).imagen.Clone();

                    for (int i = 1; i < this.imagenArray.Count; i++)
                    {
                        System.Drawing.Image BASE = (System.Drawing.Image)((ImageForm)this.imagenArray[i]).imagen.Clone();

                        BASE = this.ipc.SDMa(BASE, TARGET, MonitorConfigNumber, 0);
                        BASE.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + ".bmp");
                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }

            
        }

        private void skewModificationALLTOFIRSTSkewTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Image TARGET = (System.Drawing.Image)((ImageForm)this.imagenArray[0]).imagen.Clone();

                    for (int i = 1; i < this.imagenArray.Count; i++)
                    {
                        System.Drawing.Image BASE = (System.Drawing.Image)((ImageForm)this.imagenArray[i]).imagen.Clone();

                        BASE = this.ipc.SkewM1(BASE, TARGET, MonitorConfigNumber, 0);
                        BASE.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + ".bmp");
                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void labStToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    double[,] allhiY = this.ipc.all_Lab_Stats(this.imagenArray, MonitorConfigNumber, 0);
                    double[,] allhisx = this.ipc.all_Lab_Stats(this.imagenArray, MonitorConfigNumber, 1);
                    double[,] allhisy = this.ipc.all_Lab_Stats(this.imagenArray, MonitorConfigNumber, 2);

                    TextWriter tw = new StreamWriter(this.sfd_Picture.FileName + "resultsL.csv");

                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            tw.Write(allhiY[i, j] + ",");
                        }
                        tw.WriteLine(",");
                    }
                    tw.Flush();
                    tw.Close();


                    tw = new StreamWriter(this.sfd_Picture.FileName + "resultsa.csv");

                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            tw.Write(allhisx[i, j] + ",");
                        }
                        tw.WriteLine(",");
                    }
                    tw.Flush();
                    tw.Close();
                    tw = new StreamWriter(this.sfd_Picture.FileName + "resultsb.csv");

                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            tw.Write(allhisy[i, j] + ",");
                        }
                        tw.WriteLine(",");
                    }
                    tw.Flush();
                    tw.Close();
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }
        private static System.Drawing.Image cropImage(System.Drawing.Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (System.Drawing.Image)(bmpCrop);
        }

        private void cropPatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int xcorrection =0;
            int ycorrection =0;
            int sizepatch = 128;
            if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    for (int i = 0; i < this.ofd_Picture.FileNames.Length; i++)
                    {
                        imagen = new ImageForm((System.Drawing.Image)new Bitmap(this.ofd_Picture.FileNames[i]), this.ofd_Picture.FileNames[i], this);

                        System.Drawing.Image aux = MainMani.cropImage(this.imagen.imagen, new Rectangle(this.patchX - xcorrection, this.patchY - ycorrection, sizepatch, sizepatch));

                        aux.Save(this.ofd_Picture.FileNames[i] + "Patch.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                        this.patchX += xcorrection;
                        this.patchY += ycorrection;
                    }

                }
                catch (Exception em)
                {
                    em.Message.ToString();
                }
            }
        }

        private void squarePatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(this.BoolSquarePatch==false)
            {
                this.squarePatchToolStripMenuItem.Checked=true;
                this.BoolSquarePatch = true; 
            }
            else
            {
                this.squarePatchToolStripMenuItem.Checked=false;
                this.BoolSquarePatch = false; 
            }
        }

        private void differenceAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.sfd_Picture.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < this.imagenArray.Count; i++)
                    {
                        Bitmap bito = (Bitmap)((ImageForm)this.imagenArray[i]).imagen;
                        AForge.Imaging.Image.FormatImage(ref bito);
                        IFilter filter = new AForge.Imaging.Filters.Difference((Bitmap)((ImageForm)this.imagenArray[i+1]).imagen);

                        bito = filter.Apply(bito);
                       
                       bito.Save(this.sfd_Picture.FileName + ((ImageForm)this.imagenArray[i]).id + ".bmp");
                       i++;
                    }
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        

      

       

       

       

        

        

        

        

    }
}
