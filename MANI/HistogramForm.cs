using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using WeifenLuo.WinFormsUI;

using AForge.Math;
using AForge.Imaging;

using dotnetCHARTING.WinForms;
using System.Drawing.Drawing2D;
using CSML;


namespace MANI
{
    public partial class HistogramForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private System.Drawing.Image imagen;
        public int[] histogram2;
        public int[] histogram;
        private Bitmap bmpimg;
        private HistogramChart mychart;
        SeriesCollection SC;
        public int MonitorConfigNumber = 1;

        public double xr, yr, xg, yg, xb, yb, YrMAX, YgMAX, YbMAX, YrMAXC, YgMAXC, YbMAXC, alphaR, alphaB, alphaG;
        public double determinant, a11, a12, a13, a21, a22, a23, a31, a32, a33;


        public AForge.Math.Histogram histogramMean;
        public AForge.Math.Histogram histogramR;
        public AForge.Math.Histogram histogramG;
        public AForge.Math.Histogram histogramB;

        public String mat;
        public Matrix M;
        public Complex det;
        public Matrix Minv;

        //public void SetMonitorConfiguration(int monCnumber) 
        //{
        //    this.MonitorConfigNumber = monCnumber;
        //    if (MonitorConfigNumber == 1)//CRT NFRI
        //    {

        //        this.xb = 0.151;
        //        this.xg = 0.277;
        //        this.xr = 0.617;

        //        this.yb = 0.075;
        //        this.yg = 0.615;
        //        this.yr = 0.344;

        //        this.YbMAX = 11.369;
        //        this.YgMAX = 59.465;
        //        this.YrMAX = 17.105;

        //        this.YbMAXC = 5.135;
        //        this.YgMAXC = 26.78;
        //        this.YrMAXC = 9.498;
        //    }

        //    //HistogramForm.determinant = ((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb) * ((HistogramForm.xg / HistogramForm.yg) + (HistogramForm.xr / HistogramForm.yr)) - ((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr) * ((HistogramForm.xg / HistogramForm.yg) + (HistogramForm.xb / HistogramForm.yb)) + ((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg) * ((HistogramForm.xb / HistogramForm.yb) - (HistogramForm.xr / HistogramForm.yr));

        //    //HistogramForm.a11 = (1 / determinant) * (((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb) - (((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg)));
        //    //HistogramForm.a12 = (-1 / determinant) * (((HistogramForm.xg / HistogramForm.yg) * ((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb)) - ((HistogramForm.xb / HistogramForm.yb) * ((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg)));
        //    //HistogramForm.a13 = (1 / determinant) * ((HistogramForm.xg / HistogramForm.yg) - (HistogramForm.xb / HistogramForm.yb));

        //    //HistogramForm.a21 = (-1 / determinant) * (((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb) - (((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
        //    //HistogramForm.a22 = (1 / determinant) * (((HistogramForm.xr / HistogramForm.yr) * ((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb)) - ((HistogramForm.xb / HistogramForm.yb) * ((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
        //    //HistogramForm.a23 = (-1 / determinant) * ((HistogramForm.xr / HistogramForm.yr) - (HistogramForm.xb / HistogramForm.yb));

        //    //HistogramForm.a31 = (1 / determinant) * (((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg) - (((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
        //    //HistogramForm.a32 = (-1 / determinant) * (((HistogramForm.xr / HistogramForm.yr) * ((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg)) - ((HistogramForm.xg / HistogramForm.yg) * ((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
        //    //HistogramForm.a33 = (1 / determinant) * ((HistogramForm.xr / HistogramForm.yr) - (HistogramForm.xg / HistogramForm.yg));

        //    //HistogramForm.alphaB = 2.4;
        //    //HistogramForm.alphaG = 2.4;
        //    //HistogramForm.alphaR = 2.4;

        //    /*
        //     1.793604651162790  0.450406504065041  2.013333333333330
        //     1.000000000000000  1.000000000000000  1.000000000000000
        //     0.113372093023256  0.175609756097561 10.320000000000000
        //     * 
        //     * Inverse Matrix
        //     * 
        //     *  0.739214681325948 -0.312947011655782 -0.113889394064644
        //       -0.743749896668595  1.332178019343640  0.016011476674658
        //        0.004535215342647 -0.019231007687857  0.097877917389987
        //     */
        //    this.mat = (this.xr / this.yr).ToString() + "," + (this.xg / this.yg) + "," + (this.xb / this.yb) + ";" + "1,1,1;" + ((1 - this.xr - this.yr) / this.yr) + "," + ((1 - this.xg - this.yg) / this.yg) + "," + ((1 - this.xb - this.yb) / this.yb);
        //    this.M = new Matrix(mat);
        //    this.det = M.Determinant(); // det = 1
        //    this.Minv = M.Inverse();

        //}
        
        public HistogramForm(System.Drawing.Image imagen, String name,int Nmon)
        {
            InitializeComponent();
            
            this.imagen = imagen;
            this.bmpimg = (Bitmap)imagen;
            //this.llenandoControl();
            this.TabText = name;
            
           
        }

        //private void llenandoControl() 
        //{
        //    try
        //    {
        //        this.SC = new SeriesCollection();
        //        Series s = new Series();
                

        //        this.calcHisto(0);

        //        s = new Series();
        //        s.Name = "RED ";
        //        for (int b = 0; b < this.histogram.Length; b++)
        //        {
        //            Element e = new Element();
        //            e.Name = b.ToString();
        //            e.YValue = this.histogram[b];
        //            s.Elements.Add(e);
        //        }
        //        SC.Add(s);


               

        //        this.calcHisto(1);

        //        s = new Series();
        //        s.Name = "GREEN ";
        //        for (int b = 0; b < this.histogram.Length; b++)
        //        {
        //            Element e = new Element();
        //            e.Name = b.ToString();
        //            e.YValue = this.histogram[b];
        //            s.Elements.Add(e);
        //        }
        //        SC.Add(s);

        //        this.calcHisto(2);

        //        s = new Series();
        //        s.Name = "BLUE ";
        //        for (int b = 0; b < this.histogram.Length; b++)
        //        {
        //            Element e = new Element();
        //            e.Name = b.ToString();
        //            e.YValue = this.histogram[b];
        //            s.Elements.Add(e);
        //        }
        //        SC.Add(s);

        //        this.calcHistobis(3);

                
        //        s.Name = "Mean ";
        //        for (int b = 0; b < this.histogram.Length; b++)
        //        {
        //            Element e = new Element();
        //            e.Name = b.ToString();
        //            e.YValue = this.histogram[b];
        //            s.Elements.Add(e);
        //        }
        //        SC.Add(s);

        //        this.mychart = new HistogramChart();





        //        // Set Different Colors for our Series
        //        SC[2].DefaultElement.Color = Color.FromArgb(49, 255, 49);//green
        //        SC[0].DefaultElement.Color = Color.FromArgb(255, 255, 0);//amarillo
        //        SC[3].DefaultElement.Color = Color.FromArgb(255, 99, 49);//red
        //        SC[1].DefaultElement.Color = Color.FromArgb(0, 156, 255);//blue



        //        //this.mychart.CreateChart(ref this.HistogramaMax, SC);



        //    }
        //    catch (Exception emm)
        //    {
        //        emm.Message.ToString();
        //    }
        //}
        
        //0 mean; 1 red;2 green;3 blue
        //public void calcHisto(int ind)
        //{
        //    BitmapData data=new BitmapData();
        //    try
        //    {
        //       data = this.bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, this.bmpimg.Width, this.bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

        //        HSL hslColor = new HSL();
        //        RGB rgbColor = new RGB();

        //        double[] RGB = new double[3];
        //        double[] Lab = new double[3];

        //        unsafe
        //        {
        //            byte* ptr = (byte*)data.Scan0;

        //            int remain = data.Stride - data.Width * 3;

        //            this.histogram2 = new int[100];///////////////////////////////////
        //            this.histogram = new int[256];
        //            for (int i = 0; i < histogram.Length; i++)
        //                histogram[i] = 0;

        //            for (int i = 0; i < data.Height; i++)
        //            {
        //                for (int j = 0; j < data.Width; j++)
        //                {
        //                    int mean = 0;
        //                    if (ind == 3)
        //                    {
        //                        rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
        //                        //AForge.Imaging.ColorConverter.RGB2HSL(rgbColor,hslColor);
        //                        //mean = Convert.ToInt32(hslColor.Luminance*100);
        //                        //histogram2[mean]++;
        //                        RGB[0] = Convert.ToDouble(rgbColor.Red);
        //                        RGB[1] = Convert.ToDouble(rgbColor.Green);
        //                        RGB[2] = Convert.ToDouble(rgbColor.Blue);
        //                        try
        //                        {
        //                            Lab = HistogramForm.RGB2Lab(RGB);

        //                            mean = Convert.ToInt32(Lab[0]);
        //                            if (mean >= 100)
        //                            {
        //                                mean = 99;
        //                            }
        //                            if (mean <= -1)
        //                            {
        //                                mean = 0;
        //                            }
        //                        }
        //                        catch (Exception em)
        //                        {
        //                            em.ToString();
        //                            mean = 0;
        //                        }

        //                        histogram2[mean]++;

        //                    }
        //                    else
        //                    {
        //                        mean = ptr[ind];
        //                        histogram[mean]++;
        //                    }

        //                    ptr += 3;
        //                }

        //                ptr += remain;
        //            }
        //            if (ind == 3)
        //            {
        //                this.histogramMean = new Histogram(this.histogram2);
        //                drawHistogram(histogram2, this.pictureBox1, ind);

        //            }
        //            //if (ind == 0)
        //            //{
        //            //    this.histogramB = new Histogram(this.histogram);
        //            //    drawHistogram(histogram, this.pictureBox2, ind);
        //            //}
        //            //if (ind == 1)
        //            //{
        //            //    this.histogramG = new Histogram(this.histogram);
        //            //    drawHistogram(histogram, this.pictureBox3, ind);
        //            //}
        //            //if (ind == 2)
        //            //{
        //            //    this.histogramR = new Histogram(this.histogram);
        //            //    drawHistogram(histogram, this.pictureBox4, ind);
        //            //}

        //        }

        //    }
        //    catch (Exception el) 
        //    {
        //        el.ToString();
        //        this.bmpimg.UnlockBits(data);
        //    }
        //    this.bmpimg.UnlockBits(data);
        //}

        //public void calcHistobis(int ind)
        //{
        //    BitmapData data = new BitmapData();
        //    try
        //    {
        //        data = this.bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, this.bmpimg.Width, this.bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

        //        HSL hslColor = new HSL();
        //        RGB rgbColor = new RGB();

        //        double[] RGB = new double[3];
        //        double[] XYZ = new double[3];

        //        unsafe
        //        {
        //            byte* ptr = (byte*)data.Scan0;

        //            int remain = data.Stride - data.Width * 3;

        //            this.histogram2 = new int[100];///////////////////////////////////
        //            this.histogram = new int[256];
        //            for (int i = 0; i < histogram.Length; i++)
        //                histogram[i] = 0;

        //            for (int i = 0; i < data.Height; i++)
        //            {
        //                for (int j = 0; j < data.Width; j++)
        //                {
        //                    int mean = 0;
        //                    if (ind == 3)
        //                    {
        //                        rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                                
        //                        RGB[0] = Convert.ToDouble(rgbColor.Red);
        //                        RGB[1] = Convert.ToDouble(rgbColor.Green);
        //                        RGB[2] = Convert.ToDouble(rgbColor.Blue);
        //                        try
        //                        {
        //                            XYZ = HistogramForm.RGB2XYZR(RGB);

        //                            mean = Convert.ToInt32(XYZ[1]);
        //                            if (mean >= 100)
        //                            {
        //                                mean = 99;
        //                            }
        //                            if (mean <= -1)
        //                            {
        //                                mean = 0;
        //                            }
        //                        }
        //                        catch (Exception em)
        //                        {
        //                            em.ToString();
        //                            mean = 0;
        //                        }

        //                        histogram2[mean]++;

        //                    }
        //                    else
        //                    {
        //                        mean = ptr[ind];
        //                        histogram[mean]++;
        //                    }

        //                    ptr += 3;
        //                }

        //                ptr += remain;
        //            }
        //            if (ind == 3)
        //            {
        //                this.histogramMean = new Histogram(this.histogram2);
        //                drawHistogram(histogram2, this.pictureBox1, ind);

        //            }
        //            //if (ind == 0)
        //            //{
        //            //    this.histogramB = new Histogram(this.histogram);
        //            //    drawHistogram(histogram, this.pictureBox2, ind);
        //            //}
        //            //if (ind == 1)
        //            //{
        //            //    this.histogramG = new Histogram(this.histogram);
        //            //    drawHistogram(histogram, this.pictureBox3, ind);
        //            //}
        //            //if (ind == 2)
        //            //{
        //            //    this.histogramR = new Histogram(this.histogram);
        //            //    drawHistogram(histogram, this.pictureBox4, ind);
        //            //}

        //        }

        //    }
        //    catch (Exception el)
        //    {
        //        el.ToString();
        //        this.bmpimg.UnlockBits(data);
        //    }
        //    this.bmpimg.UnlockBits(data);
        //}

        public void LinearNormalization1a300(double[] histogram,double minimum,double maximum) 
        {
            double max = 0.0;
            for (int i = 0; i < histogram.Length; i++)
            {

                if (max < histogram[i])
                    max = histogram[i];

            }
            for (int i = 0; i < histogram.Length; i++)
            {

                histogram[i] = histogram[i]*maximum/max;

            }
        }

        public void drawHistogram(double[] histogram, PictureBox picBox,int indi)
        {

            Bitmap bmp = new Bitmap(histogram.Length + 10, 310);
            picBox.Image = bmp;
            picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BitmapData data = new BitmapData();
            try
            {
                data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    int remain = data.Stride - data.Width * 3;
                    byte* ptr = (byte*)data.Scan0;

                    for (int i = 0; i < data.Height; i++)
                    {

                        for (int j = 0; j < data.Width; j++)
                        {
                            //Color rgb del Fondo
                            ptr[0] = ptr[1] = ptr[2] = 150;
                            ptr += 3;
                        }
                        ptr += remain;

                    }

                    double max = 0.0;
                    for (int i = 0; i < histogram.Length; i++)
                    {

                        if (max < histogram[i])
                            max = histogram[i];

                    }

                    for (int i = 0; i < histogram.Length; i++)
                    {
                        ptr = (byte*)data.Scan0;
                        ptr += data.Stride * (305) + (i + 5) * 3;

                        int length = (int)(1.0 * histogram[i] * 300 / max);

                        for (int j = 0; j < length; j++)
                        {
                            //Color de las barras
                            if (indi == 3)
                            {
                                ptr[2] = ptr[1] = 255;
                                ptr[0] = 0;
                                ptr -= data.Stride;
                            }
                            else
                            {
                                ptr[0] = ptr[1] = ptr[2] = 0;
                                ptr[indi] = 180;
                                ptr -= data.Stride;
                            }
                        }

                    }

                }

            }
            catch (Exception el)
            {
                el.ToString();
                bmp.UnlockBits(data);
            }
            bmp.UnlockBits(data);
        }

        public void drawHistogram(int[] histogram, PictureBox picBox, int indi)
        {


            this.histogram = histogram;

            Bitmap bmp = new Bitmap(histogram.Length + 10, 310);
            picBox.Image = bmp;
            picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BitmapData data = new BitmapData();
            try
            {
                data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    int remain = data.Stride - data.Width * 3;
                    byte* ptr = (byte*)data.Scan0;

                    for (int i = 0; i < data.Height; i++)
                    {

                        for (int j = 0; j < data.Width; j++)
                        {
                            //Color rgb del Fondo
                            ptr[0] = ptr[1] = ptr[2] = 150;
                            ptr += 3;
                        }
                        ptr += remain;





                    }
                    double max = bmp.Height * bmp.Width;
                    //double max = 0.0;
                    //for (int i = 0; i < histogram.Length; i++)
                    //{

                    //    if (max < histogram[i])
                    //        max = histogram[i];

                    //}

                    for (int i = 0; i < histogram.Length; i++)
                    {
                        ptr = (byte*)data.Scan0;
                        ptr += data.Stride * (305) + (i + 5) * 3;

                        int length = (int)(1.0 * histogram[i] * 300 / max);

                        for (int j = 0; j < length; j++)
                        {
                            //Color de las barras
                            if (indi == 3)
                            {
                                ptr[2] = ptr[1] = 255;
                                ptr[0] = 0;
                                ptr -= data.Stride;
                            }
                            else
                            {
                                ptr[0] = ptr[1] = ptr[2] = 0;
                                ptr[indi] = 180;
                                ptr -= data.Stride;
                            }
                        }

                    }

                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmp.UnlockBits(data);
            }
            bmp.UnlockBits(data);


            
        }

        private void PicBHistogram_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.pictureBox1.Image != null)
            {
                //this.pictureBox1.Refresh();
                this.e1 = e;
                //this.PicBHistogram_Paint(sender, null);
                
            }
        }
        MouseEventArgs e1;
        private void PicBHistogram_Paint(object sender, PaintEventArgs e)
        {
            if (e1 != null)
            {

                Graphics graphic = this.pictureBox1.CreateGraphics();
                graphic.DrawLine(new Pen(Color.Black), 0, e1.Y, this.pictureBox1.Width, e1.Y);
                graphic.DrawLine(new Pen(Color.Black), e1.X, 0, e1.X, this.pictureBox1.Height);
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //this.pictureBox1.Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics graphic = this.pictureBox1.CreateGraphics();
            int heigh = Int32.Parse((this.pictureBox1.Width / 10).ToString());
            for (int i = 0; i < this.pictureBox1.Width; i ++)
            {
                graphic.DrawLine(new Pen(Color.Black), 0, i * heigh, this.pictureBox1.Width, i * heigh);
            }
            int width=Int32.Parse((this.pictureBox1.Width/10).ToString());
            for (int i = 0; i < this.pictureBox1.Height; i++)
            {
                graphic.DrawLine(new Pen(Color.Black), i * width, 0, i * width, this.pictureBox1.Height);
            }
        }

       
    }
}
