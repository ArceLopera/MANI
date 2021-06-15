using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using AForge.Math;
using AForge.Imaging;
using System.Drawing;
using System.Drawing.Imaging;

namespace MANI
{
    public class ImageProcessingClass
    {
        #region attributes
        private System.Drawing.Image imagen;
        private Bitmap bmpimg;
        String Name;
        public int[] histogram2;
        public int[] histogram;
       
        public int MonitorConfigNumber = 1;

        public double xr, yr, xg, yg, xb, yb, YrMAX, YgMAX, YbMAX, YrMAXC, YgMAXC, YbMAXC, alphaR, alphaB, alphaG;
        //public double determinant, a11, a12, a13, a21, a22, a23, a31, a32, a33;


        public String mat;
        public Matrix M;
        public Complex det;
        public Matrix Minv;
        #endregion

        public void SetMonitorConfiguration(int monCnumber) 
        {
            this.MonitorConfigNumber = monCnumber;
            if (MonitorConfigNumber == 1)//CRT NFRI
            {

                this.xb = 0.151;
                this.xg = 0.277;
                this.xr = 0.617;

                this.yb = 0.075;
                this.yg = 0.615;
                this.yr = 0.344;

                this.YbMAX = 11.369;
                this.YgMAX = 59.465;
                this.YrMAX = 17.105;

                this.YbMAXC = 5.135;
                this.YgMAXC = 26.78;
                this.YrMAXC = 9.498;
            }
            if (MonitorConfigNumber == 5)//CG245w NFRI
            {

                this.xb = 0.1514;
                this.xg = 0.2200;
                this.xr = 0.6706;

                this.yb = 0.0499;
                this.yg = 0.6739;
                this.yr = 0.3096;

                this.YbMAX = 7.4131;
                this.YgMAX = 79.2232;
                this.YrMAX = 34.9726;

               
            }
            if (MonitorConfigNumber == 6)//CG245w OKALAB
            {

                this.xb = 0.1539;
                this.xg = 0.1114;
                this.xr = 0.6475;

                this.yb = 0.0489;
                this.yg = 0.7488;
                this.yr = 0.3090;

                this.YbMAX = 8.667;
                this.YgMAX = 102.6690;
                this.YrMAX = 37.3663;

               
            }
            if (MonitorConfigNumber == 2)//EIZO OKALAB
            {
                this.xb = 0.148;
                this.xg = 0.2215;
                this.xr = 0.6576;

                this.yb = 0.0701;
                this.yg = 0.6752;
                this.yr = 0.3271;

                this.YbMAX = 24.8021;
                this.YgMAX = 175.42;
                this.YrMAX = 85.276;
            }
            if (MonitorConfigNumber == 4)//LCD192vxm OKALAB
            {
                this.xb = 0.1452;
                this.xg = 0.2797;
                this.xr = 0.626;

                this.yb = 0.0669;
                this.yg = 0.6005;
                this.yr = 0.3243;

                this.YbMAX = 14.81;
                this.YgMAX = 87.47;
                this.YrMAX = 25.36;
            }
            //HistogramForm.determinant = ((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb) * ((HistogramForm.xg / HistogramForm.yg) + (HistogramForm.xr / HistogramForm.yr)) - ((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr) * ((HistogramForm.xg / HistogramForm.yg) + (HistogramForm.xb / HistogramForm.yb)) + ((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg) * ((HistogramForm.xb / HistogramForm.yb) - (HistogramForm.xr / HistogramForm.yr));

            //HistogramForm.a11 = (1 / determinant) * (((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb) - (((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg)));
            //HistogramForm.a12 = (-1 / determinant) * (((HistogramForm.xg / HistogramForm.yg) * ((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb)) - ((HistogramForm.xb / HistogramForm.yb) * ((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg)));
            //HistogramForm.a13 = (1 / determinant) * ((HistogramForm.xg / HistogramForm.yg) - (HistogramForm.xb / HistogramForm.yb));

            //HistogramForm.a21 = (-1 / determinant) * (((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb) - (((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
            //HistogramForm.a22 = (1 / determinant) * (((HistogramForm.xr / HistogramForm.yr) * ((1 - HistogramForm.xb - HistogramForm.yb) / HistogramForm.yb)) - ((HistogramForm.xb / HistogramForm.yb) * ((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
            //HistogramForm.a23 = (-1 / determinant) * ((HistogramForm.xr / HistogramForm.yr) - (HistogramForm.xb / HistogramForm.yb));

            //HistogramForm.a31 = (1 / determinant) * (((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg) - (((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
            //HistogramForm.a32 = (-1 / determinant) * (((HistogramForm.xr / HistogramForm.yr) * ((1 - HistogramForm.xg - HistogramForm.yg) / HistogramForm.yg)) - ((HistogramForm.xg / HistogramForm.yg) * ((1 - HistogramForm.xr - HistogramForm.yr) / HistogramForm.yr)));
            //HistogramForm.a33 = (1 / determinant) * ((HistogramForm.xr / HistogramForm.yr) - (HistogramForm.xg / HistogramForm.yg));

            //HistogramForm.alphaB = 2.4;
            //HistogramForm.alphaG = 2.4;
            //HistogramForm.alphaR = 2.4;

            /*
             1.793604651162790  0.450406504065041  2.013333333333330
             1.000000000000000  1.000000000000000  1.000000000000000
             0.113372093023256  0.175609756097561 10.320000000000000
             * 
             * Inverse Matrix
             * 
             *  0.739214681325948 -0.312947011655782 -0.113889394064644
               -0.743749896668595  1.332178019343640  0.016011476674658
                0.004535215342647 -0.019231007687857  0.097877917389987
             */
            this.mat = (this.xr / this.yr).ToString() + "," + (this.xg / this.yg) + "," + (this.xb / this.yb) + ";" + "1,1,1;" + ((1 - this.xr - this.yr) / this.yr) + "," + ((1 - this.xg - this.yg) / this.yg) + "," + ((1 - this.xb - this.yb) / this.yb);
            this.M = new Matrix(mat);
            //this.det = M.Determinant(); // det = 1
            //this.Minv = M.Inverse();

        }

        public ImageProcessingClass( int Nmon)
        {
            this.SetMonitorConfiguration(Nmon);

        }
        public unsafe void convertTo8bpp(UnmanagedImage sourceData, UnmanagedImage destinationData)
        {
            // get width and height
            int width = sourceData.Width;
            int height = sourceData.Height;
            PixelFormat srcPixelFormat = sourceData.PixelFormat;

            if (
                (srcPixelFormat == PixelFormat.Format24bppRgb) ||
                (srcPixelFormat == PixelFormat.Format32bppRgb) ||
                (srcPixelFormat == PixelFormat.Format32bppArgb))
            {
                int pixelSize = (srcPixelFormat == PixelFormat.Format24bppRgb) ? 3 : 4;
                int srcOffset = sourceData.Stride - width * pixelSize;
                int dstOffset = destinationData.Stride - width;

                double[] A = new double[3];
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double aux = 0;
                //double max = 0;

                // do the job
                byte* src = (byte*)sourceData.ImageData.ToPointer();
                byte* dst = (byte*)destinationData.ImageData.ToPointer();

                // for each line
                for (int y = 0; y < height; y++)
                {
                    // for each pixel
                    for (int x = 0; x < width; x++, src += pixelSize, dst++)
                    {
                        //convert to Y
                        //LCD192vxm OKALAB
                        RGB[0] = Convert.ToDouble(src[AForge.Imaging.RGB.R]);
                        RGB[1] = Convert.ToDouble(src[AForge.Imaging.RGB.G]);
                        RGB[2] = Convert.ToDouble(src[AForge.Imaging.RGB.B]);
                        XYZ = this.RGB2XYZ(RGB, this.MonitorConfigNumber);
                       
                        //A[0] = (27.746 * RGB[0] * RGB[0] - 3.1627 * RGB[0] + 0.2967);//Yr  max=24.88
                        //A[1] = (102.03 * RGB[1] * RGB[1] - 17.713 * RGB[1] + 1.083);//Yg  max=85.4
                        //A[2] = (18.868 * RGB[2] * RGB[2] - 5.208 * RGB[2] + 0.5785);//Yb  max=14.2385
                        //scale to 0-255
                        //aux=Math.Round((XYZ[1])*(255*2.5/124.5185));
                        //if (aux > max) max = aux;
                        aux = Math.Round(XYZ[1]);
                        *dst = (Byte)(aux);//ymax=124.5185
                        
                    }
                    src += srcOffset;
                    dst += dstOffset;
                }
                
            }
            
        }
        #region RGB_XYZ
        //Conversion from RGB to XYZ
        //Mnum is the configuration number of the monitor
        double[] RGB2XYZ(double[] A, int Mnum)
        {
            double[] B = new double[3];

            //normalization
            A[0] /= 255;
            A[1] /= 255;
            A[2] /= 255;

            if (Mnum == 5)//CG245w NFRI
            {
                A[0] = 34.9726 * A[0] ;//Yr
                A[1] = 79.2232 * A[1];//Yg
                A[2] = 7.4131 * A[2] ;//Yb
            }
            if (Mnum == 1)//CRT NFRI //NFRI CRT:total 87.95      R=17.11/87.95=0.19454  G=0.6762  B=0.1293
            {
                A[0] = 17.922 * A[0] + 0.0967;//Yr
                A[1] = 60.125 * A[1] - 0.1535;//Yg
                A[2] = 10.954 * A[2] + 0.1131;//Yb
            }
            if (Mnum == 6)//CG245w Okalab
            {
                A[0] *= 255;
                A[1] *= 255;
                A[2] *= 255;
                A[0] = 0.00063 * A[0] * A[0] - 0.02821 * A[0] + 0.61778;//Yr
                A[1] = 0.00168 * A[1] * A[1] - 0.07582 * A[1] + 1.36445;//Yg
                A[2] = 0.00015 * A[2] * A[2] - 0.00589 * A[2] + 0.28733;//Yb
            }
            if (Mnum == 2)//EIZO OKALAB Skin experiments
            {  //yr = 88.84429571497870000000 x2 - 2.51729821080698000000 x + 0.12922255942965000000
               //yg = 188.50227217820400000000 x2 - 12.50887180670540000000 x + 0.58304259376291200000 
               //yb = 28.99679603007780000000 x2 - 5.08925504973490000000 x + 0.62406986764850100000 

                A[0] = 88.8442957149787 * A[0] * A[0] - 2.51729821080698 * A[0] + 0.12922255942965;//Yr
                A[1] = 188.502272178204 * A[1] * A[1] - 12.5088718067054 * A[1] + 0.583042593762912;//Yg
                A[2] = 28.9967960300778 * A[2] * A[2] - 5.0892550497349 * A[2] + 0.624069867648501;//Yb
            }
            if (Mnum == 4)//LCD192vxm OKALAB
            {
                A[0] = 27.746 * A[0] * A[0] - 3.1627 * A[0] + 0.2967;//Yr
                A[1] = 102.03 * A[1] * A[1] - 17.713 * A[1] + 1.083;//Yg
                A[2] = 18.868 * A[2] * A[2] - 5.208  * A[2] + 0.5785;//Yb
            }

            B[0] = (this.xr / this.yr) * A[0] + (this.xg / this.yg) * A[1] + (this.xb / this.yb) * A[2];
            B[1] = A[0] + A[1] + A[2];
            B[2] = ((1 - this.xr - this.yr) / this.yr) * A[0] + ((1 - this.xg - this.yg) / this.yg) * A[1] + ((1 - this.xb - this.yb) / this.yb) * A[2];

            return B;
        }
        double[] XYZ2RGB(double[] A, int nMon)
        {
            double[] B = new double[3];


            B[0] = this.Minv[1, 1].Re * A[0] + this.Minv[1, 2].Re * A[1] + this.Minv[1, 3].Re * A[2];//Yr
            B[1] = this.Minv[2, 1].Re * A[0] + this.Minv[2, 2].Re * A[1] + this.Minv[2, 3].Re * A[2];//Yg
            B[2] = this.Minv[3, 1].Re * A[0] + this.Minv[3, 2].Re * A[1] + this.Minv[3, 3].Re * A[2];//Yb
            if (nMon == 1)//CRT NFRI
            {
                B[0] = (B[0] - 0.0967) / 17.922;
                B[1] = (B[1] - 0.1535) / 60.125;
                B[2] = (B[2] - 0.1131) / 10.954;
            }
            if (nMon == 5)//CG245w NFRI
            {
                B[0] = (B[0]) / 34.9726;
                B[1] = (B[1] ) / 79.2232;
                B[2] = (B[2]) / 7.4131;
            }
            if (nMon == 6)//CG245w Okalab
            {
                //A[0] = 0.00063 * A[0] * A[0] - 0.02821 * A[0] + 0.61778;//Yr
                //A[1] = 0.00168 * A[1] * A[1] - 0.07582 * A[1] + 1.36445;//Yg
                //A[2] = 0.00015 * A[2] * A[2] - 0.00589 * A[2] + 0.28733;//Yb
                double a, b, c;
                a = 0.00063;
                b = -0.02821;
                c = 0.61778;
                double discriminnat = b * b - 4 * a * (c - B[0]);
                if (discriminnat < 0)
                {
                    B[0] = (-b + Math.Sqrt(4 * a * (c - B[0]) - b * b)) / (2 * a);//Yb
                    if (B[0] < 0)
                    {
                        B[0] = (-b - Math.Sqrt(4 * a * (c - B[0]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[0] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[0]))) / (2 * a);//Yr
                    if (B[0] < 0)
                    {
                        B[0] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[0]))) / (2 * a);//Yr
                    }
                }
                a = 0.00168;
                b = -0.07582;
                c = 1.36445;
                discriminnat = b * b - 4 * a * (c - B[1]);
                if (discriminnat < 0)
                {
                    B[1] = (-b + Math.Sqrt(4 * a * (c - B[1]) - b * b)) / (2 * a);//Yb
                    if (B[1] < 0)
                    {
                        B[1] = (-b - Math.Sqrt(4 * a * (c - B[1]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[1] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[1]))) / (2 * a);//Yg
                    if (B[1] < 0)
                    {
                        B[1] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[1]))) / (2 * a);//Yg
                    }
                }
                a = 0.00015;
                b = -0.00589;
                c = 0.28733;
                discriminnat = b * b - 4 * a * (c - B[2]);
                if (discriminnat < 0)
                {
                    B[2] = (-b + Math.Sqrt(4 * a * (c - B[2]) - b * b)) / (2 * a);//Yb
                    if (B[2] < 0)
                    {
                        B[2] = (-b - Math.Sqrt(4 * a * (c - B[2]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[2] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[2]))) / (2 * a);//Yb
                    if (B[2] < 0)
                    {
                        B[2] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[2]))) / (2 * a);//Yb
                    }
                }
                B[0] = B[0] / 255;
                B[1] = B[1] / 255;
                B[2] = B[2] / 255;
            }
            if (nMon == 2)//EIZO OKALAB
            {
                //yr = 88.84429571497870000000 x2 - 2.51729821080698000000 x + 0.12922255942965000000
                //yg = 188.50227217820400000000 x2 - 12.50887180670540000000 x + 0.58304259376291200000 
                //yb = 28.99679603007780000000 x2 - 5.08925504973490000000 x + 0.62406986764850100000 
                double a, b, c;
                a = 88.8442957149787;
                b = -2.51729821080698;
                c = 0.12922255942965;
                double discriminnat = b * b - 4 * a * (c - B[0]);
                if (discriminnat < 0)
                {
                    B[0] = (-b + Math.Sqrt(4 * a * (c - B[0]) - b * b)) / (2 * a);//Yb
                    if (B[0] < 0)
                    {
                        B[0] = (-b - Math.Sqrt(4 * a * (c - B[0]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[0] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[0]))) / (2 * a);//Yr
                    if (B[0] < 0)
                    {
                        B[0] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[0]))) / (2 * a);//Yr
                    }
                }
                a = 188.502272178204;
                b = -12.5088718067054;
                c = +0.583042593762912;
                discriminnat = b * b - 4 * a * (c - B[1]);
                if (discriminnat < 0)
                {
                    B[1] = (-b + Math.Sqrt(4 * a * (c - B[1]) - b * b)) / (2 * a);//Yb
                    if (B[1] < 0)
                    {
                        B[1] = (-b - Math.Sqrt(4 * a * (c - B[1]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[1] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[1]))) / (2 * a);//Yg
                    if (B[1] < 0)
                    {
                        B[1] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[1]))) / (2 * a);//Yg
                    }
                }
                a = 28.9967960300778;
                b = -5.0892550497349;
                c = 0.624069867648501;
                discriminnat = b * b - 4 * a * (c - B[2]);
                if (discriminnat < 0)
                {
                    B[2] = (-b + Math.Sqrt(4 * a * (c - B[2]) - b * b)) / (2 * a);//Yb
                    if (B[2] < 0)
                    {
                        B[2] = (-b - Math.Sqrt(4 * a * (c - B[2]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[2] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[2]))) / (2 * a);//Yb
                    if (B[2] < 0)
                    {
                        B[2] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[2]))) / (2 * a);//Yb
                    }
                }
            }
            if (nMon == 4)//LCD192vxm OKALAB
            {
                //A[0] = 27.746 * A[0] * A[0] - 3.1627 * A[0] + 0.2967;//Yr
                //A[1] = 102.03 * A[1] * A[1] - 17.713 * A[1] + 1.083;//Yg
                //A[2] = 18.868 * A[2] * A[2] - 5.208 * A[2] + 0.5785;//Yb
                double a, b, c;
                a = 27.746;
                b = -3.1627;
                c = 0.2967;
                double discriminnat = b * b - 4 * a * (c - B[0]);
                if (discriminnat < 0)
                {
                    B[0] = (-b + Math.Sqrt(4 * a * (c - B[0]) - b * b)) / (2 * a);//Yb
                    if (B[0] < 0)
                    {
                        B[0] = (-b - Math.Sqrt(4 * a * (c - B[0]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[0] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[0]))) / (2 * a);//Yr
                    if (B[0] < 0)
                    {
                        B[0] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[0]))) / (2 * a);//Yr
                    }
                }
                a = 102.03;
                b = -17.713;
                c = 1.083;
                discriminnat = b * b - 4 * a * (c - B[1]);
                if (discriminnat < 0)
                {
                    B[1] = (-b + Math.Sqrt(4 * a * (c - B[1]) - b * b)) / (2 * a);//Yb
                    if (B[1] < 0)
                    {
                        B[1] = (-b - Math.Sqrt(4 * a * (c - B[1]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[1] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[1]))) / (2 * a);//Yg
                    if (B[1] < 0)
                    {
                        B[1] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[1]))) / (2 * a);//Yg
                    }
                }
                a = 18.868;
                b = -5.208;
                c = 0.5785;
                discriminnat = b * b - 4 * a * (c - B[2]);
                if (discriminnat < 0)
                {
                    B[2] = (-b + Math.Sqrt( 4 * a * (c - B[2])-b*b)) / (2 * a);//Yb
                    if (B[2] < 0)
                    {
                        B[2] = (-b - Math.Sqrt(4 * a * (c - B[2]) - b * b)) / (2 * a);//Yb
                    }
                }
                else
                {
                    B[2] = (-b + Math.Sqrt(b * b - 4 * a * (c - B[2]))) / (2 * a);//Yb
                    if (B[2] < 0)
                    {
                        B[2] = (-b - Math.Sqrt(b * b - 4 * a * (c - B[2]))) / (2 * a);//Yb
                    }
                }
            }

            B[0] = B[0] * 255;
            B[1] = B[1] * 255;
            B[2] = B[2] * 255;
            return B;
        }
        #endregion

        static double[] XYZ2Lab(double[] A)
        {
            double[] B = new double[3];
            double epsilon = 216.0 / 24389.0;
            double kay = 24389.0 / 27.0;

            //Standard white E X = Y = Z =1
            double[] StandardWhite = new double[3] { 100.0, 100.0, 100.0};

            B[0] = A[0] /StandardWhite[0];
            B[1] = A[1] /StandardWhite[1];
            B[2] = A[2] /StandardWhite[2];

            double[] C = new double[3];
            
            if(B[0]>epsilon)
            {
                C[0]=Math.Pow(B[0],1.0/3.0);
            }
            else
            {
                C[0] = (kay * B[0] + 16.0) / 116.0;
            }
            if (B[1] > epsilon)
            {
                C[1] = Math.Pow(B[1], 1.0 / 3.0);
            }
            else
            {
                C[1] = (kay * B[1] + 16.0) / 116.0;
            }
            if (B[2] > epsilon)
            {
                C[2] = Math.Pow(B[2], 1.0 / 3.0);
            }
            else
            {
                C[2] = (kay * B[2] + 16.0) / 116.0;
            }
            B[0] = 116 * C[1] - 16;
            B[1] = 500 * (C[0] - C[1]);
            B[2] = 200 * (C[1] - C[2]);

            return B;
        }

        #region XYZ_Yxy
        static double[] XYZ2Yxy(double[] A)
        {
            double[] B = new double[3];


            B[0] = A[1];
            B[1] = A[0] / (A[0] + A[1] + A[2]);
            B[2] = A[1] / (A[0] + A[1] + A[2]);

            return B;
        }
        static double[] Yxy2XYZ(double[] A)
        {
            double[] B = new double[3];

            //Y from 0 to 100
            //x from 0 to 1
            //y from 0 to 1

            B[0] = A[1] * (A[0] / A[2]);
            B[1] = A[0];
            B[2] = (1 - A[1] - A[2]) * (A[0] / A[2]);

            return B;
        }
        #endregion

        #region All_Statistics
        public double[,] all_Lab_Stats(ArrayList imagenArray, int nMon, int channel)
        {
            int len = 4;
            double[,] histogram = new double[imagenArray.Count, len];
            double mean = 0;
            double sd = 0;
            double skew = 0;
            double kurtosis = 0;
            for (int i = 0; i < imagenArray.Count; i++)
            {
                System.Drawing.Image image = ((ImageForm)imagenArray[i]).imagen;
                mean = this.extract_Lab_MEAN(image, nMon, channel);
                sd = this.extract_Lab_SD(image, nMon, channel);
                skew = this.extract_Lab_SKEW(image, nMon, channel);
                kurtosis = this.extract_Lab_KURTOSIS(image, nMon, channel);
                histogram[i, 0] = mean;
                histogram[i, 1] = sd;
                histogram[i, 2] = skew;
                histogram[i, 3] = kurtosis;

            }
            return histogram;
        }
        public double[,] all_Yxy_Stats(ArrayList imagenArray,int nMon,int channel)
        {
            int len = 4;
            double[,] histogram = new double[imagenArray.Count, len];
            double mean = 0;
            double sd = 0;
            double skew = 0;
            double kurtosis = 0;
            for (int i = 0; i < imagenArray.Count; i++)
            {
                System.Drawing.Image image = ((ImageForm)imagenArray[i]).imagen;
                mean = this.extract_Yxy_MEAN(image, nMon, channel);
                sd = this.extract_Yxy_SD(image, nMon, channel);
                skew = this.extract_Yxy_SKEW(image, nMon, channel);
                kurtosis = this.extract_Yxy_KURTOSIS(image, nMon, channel);
                histogram[i, 0] = mean;
                histogram[i, 1] = sd;
                histogram[i, 2] = skew;
                histogram[i, 3] = kurtosis;

            }
            return histogram;
        }
        
        static public double[,] all_HSL_Stats(ArrayList imagenArray,int channel)
        {
            int len = 4;
            double[,] histogram = new double[imagenArray.Count, len];
            double mean = 0;
            double sd = 0;
            double skew = 0;
            double kurtosis = 0;
            for (int i = 0; i < imagenArray.Count; i++)
            {
                System.Drawing.Image image = ((ImageForm)imagenArray[i]).imagen;
                mean = ImageProcessingClass.Stats_HSL_MEAN(image, channel);
                sd = ImageProcessingClass.Stats_HSL_SD(image, channel);
                skew = ImageProcessingClass.Stats_HSL_SKEW(image, channel);
                kurtosis = ImageProcessingClass.Stats_HSL_KURTOSIS(image, channel);
                histogram[i, 0] = mean;
                histogram[i, 1] = sd;
                histogram[i, 2] = skew;
                histogram[i, 3] = kurtosis;

            }
            return histogram;
        }

        public double[,] all_RGB_Stats(ArrayList imagenArray, int nMon, int channel)
        {
            int len = 4;
            double[,] histogram = new double[imagenArray.Count, len];
            double mean = 0;
            double sd = 0;
            double skew = 0;
            double kurtosis = 0;
            for (int i = 0; i < imagenArray.Count; i++)
            {
                System.Drawing.Image image = ((ImageForm)imagenArray[i]).imagen;
                mean = ImageProcessingClass.Stats_RGB_MEAN(image, channel);
                sd = ImageProcessingClass.Stats_RGB_SD(image, channel);
                skew = ImageProcessingClass.Stats_RGB_SKEW(image, channel);
                kurtosis = ImageProcessingClass.Stats_RGB_KURTOSIS(image, channel);
                histogram[i, 0] = mean;
                histogram[i, 1] = sd;
                histogram[i, 2] = skew;
                histogram[i, 3] = kurtosis;

            }
            return histogram;
        }
        #endregion

        #region Histogram Matching
        static public void HistogramMatchingRGB(System.Drawing.Image image, System.Drawing.Image image2, int channel, bool channelMeanConservationFlag)
        {
            int[] histogramaBase = ImageProcessingClass.extractHistogramRGB(image, 254,channel);

            int[] histogramaTarget = ImageProcessingClass.extractHistogramRGB(image2, 254,channel);


            histogramaBase = ImageProcessingClass.cumuladoHistogram(histogramaBase);
            histogramaTarget = ImageProcessingClass.cumuladoHistogram(histogramaTarget);


            Bitmap bmpimg2 = (Bitmap)image;

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
               


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    int mean = 0;
                    int matchValue = 0;



                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                          

                            mean = Convert.ToInt32(RGB[channel]);
                            
                                matchValue = 0;
                                matchValue = ImageProcessingClass.searchIndexHistogram(histogramaTarget, histogramaBase[mean]);
                                RGB[channel] = Convert.ToDouble(matchValue);

                               

                                int[] rgbint = new int[3];
                                for (int h = 0; h < 3; h++)
                                {
                                    rgbint[h] = Convert.ToInt32(RGB[h]);
                                    if (rgbint[h] > 255)
                                    {
                                        rgbint[h] = 255;
                                    }
                                    if (rgbint[h] < 0)
                                    {
                                        rgbint[h] = 0;
                                    }
                                }


                                ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                                ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                                ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;
                            
                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            if (channelMeanConservationFlag)
            {
                //mean channel Conservation
                //TO DO
            }
        }
        int i1, j1;
        //histogram resolution  ej.100
        //nMon Monitor Calibration Number
        //channel: 0-> luminance  1-> x 2-> y
        public void HistogramMatching(System.Drawing.Image imageBase, System.Drawing.Image imageTarget,int HistoResolution, int nMon,int channel,bool channelMeanConservationFlag)
        {
            System.Drawing.Image imageBaseCopy = (System.Drawing.Image)imageBase.Clone();

            int[] histograma1 = this.extractHistogramYxy(imageBase, HistoResolution, nMon, channel);

            int[] histograma2 = this.extractHistogramYxy(imageTarget,HistoResolution, nMon, channel);

            //histograma2 = ImageProcessingClass.translateHistogram(histograma2, ImageProcessingClass.meanHistogram(histograma1));

           
            histograma1 = ImageProcessingClass.cumuladoHistogram(histograma1);
            histograma2 = ImageProcessingClass.cumuladoHistogram(histograma2);


            Bitmap bmpimg2 = (Bitmap)imageBase;

            BitmapData data = new BitmapData();
            int i=0, j=0;
            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];

                int i1, j1;
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    int mean = 0;
                    int matchValue = 0;

                    for ( i = 0; i < data.Height; i++)
                    {
                        for ( j = 0; j < data.Width; j++)
                        {
                            this.i1 = i;
                            this.j1 = j;
                            //if ((this.i1 == 70) && (this.j1 == 2)) 
                            //{ this.i1 = i; }
                            //if (j == 66 || j == 114) 
                            //{
                            //    j = j;
                            //}

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB,nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean = Convert.ToInt32(Yxy[channel]);
                           
                            matchValue = 0;
                            if (mean >= 100) 
                            { 
                                mean = 99; 
                            }
                            matchValue = ImageProcessingClass.searchIndexHistogram(histograma2, histograma1[mean]);
                            Yxy[channel] = Convert.ToDouble(matchValue);

                            XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);

                            RGB = this.XYZ2RGB(XYZ,nMon);
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt32(RGB[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;
                            
                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);

            if (channelMeanConservationFlag)
            {
                //mean channel Conservation
                this.meanT(imageBaseCopy, imageBase, nMon, channel);
            }

        }
        static public int[] cumuladoHistogram(int[] histogram)
        {
            for (int i = 0; i < histogram.Length - 1; i++)
            {
                histogram[i + 1] += histogram[i];
            }
            return histogram;
        }
        static public int searchIndexHistogram(int[] histogram, int data)
        {
            int i = 1;
            for ( i = 1; i < histogram.Length; i++)
            {
                if (histogram[i] > data)
                {
                    return i - 1;
                }
            }
            return i;
        }
        #endregion

        #region Misc
        public System.Drawing.Image llenarHuecos(System.Drawing.Image image,int nMon)
        {
            int[] histograma1 = this.extractHistogramYxy(image, 100,this.MonitorConfigNumber,0);
            int average = ImageProcessingClass.meanHistogram(histograma1);
            
            Bitmap bmpimg2 = (Bitmap)image;

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    int mean = 0;
                    int matchValue = 0;



                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB,nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);


                            mean = Convert.ToInt32(Yxy[0]);
                            if (mean >= 100)
                            {
                                mean = 99;
                            }
                            if (mean <= -1)
                            {
                                mean = 0;
                            }

                            matchValue = 0;
                            if (mean <= 10)
                            {
                                matchValue = average;
                                Yxy[0] = Convert.ToDouble(matchValue);

                                XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);

                                RGB = this.XYZ2RGB(XYZ,nMon);


                                int[] rgbint = new int[3];
                                for (int h = 0; h < 3; h++)
                                {
                                    rgbint[h] = Convert.ToInt32(RGB[h]);
                                    if (rgbint[h] > 255)
                                    {
                                        rgbint[h] = 255;
                                    }
                                    if (rgbint[h] < 0)
                                    {
                                        rgbint[h] = 0;
                                    }
                                }


                                ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                                ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                                ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;
                            }

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return (System.Drawing.Image)bmpimg2;
        }
        static public int differenceSum(int[] h1, int[] h2) 
        {
            int result = 0;
            int[] histogramaMinus = ImageProcessingClass.minusH(h1, h2);
            for (int i = 10; i < histogramaMinus.Length; i++) 
            {
                result+= Math.Abs(histogramaMinus[i]);
            }
            return result;
        }
        static public int[] minusH(int[] h1, int[] h2)
        {
            
            int[] result = new int[h1.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = h1[i] - h2[i];
            }
            return result;
        }
        static public bool yaestametido(int [] a, int n) 
        {
            bool b = false;
            for (int i = 0; i < a.Length; i++) 
            { 
                if((a[i]==n)&&(a[i]>=0))
                {
                    return true;
                }
            }
            return b;
        }
        static public ArrayList randomChoose(int numerosPorMover, int numeroTotal)
        {
            //choose random number
            Random rc=new Random();
            int random = rc.Next(numeroTotal);
            int[] arr_random = new int[numerosPorMover];
            arr_random[0] = random;
            for (int i = 1; i < arr_random.Length; i++)
            {
                arr_random[i] = -1;
            }
            for (int i = 1; i < arr_random.Length; i++) 
            { 
                random = rc.Next(numeroTotal);
                if (!yaestametido(arr_random,random))
                {
                    arr_random[i] = random;
                }
                else 
                {
                    i--;
                }
            }
            //sort the numbers
            ArrayList ran = new ArrayList(numerosPorMover);
            for (int i = 0; i < arr_random.Length; i++)
            {
                ran.Add(arr_random[i]);
            }
            ran.Sort();
            return ran;
        }
        static public int NegativoMasCerca(int uu, int[] histog) 
        {
            int minP = 0;
            int minM = 0;
            for (int i = uu + 1; i < histog.Length; i++)
            {
                if (histog[i] < 0)
                {
                    minP = i - uu;
                    break;
                }
            }
            for (int i = uu-1; i >=0; i--)
            {
                if (histog[i] < 0)
                {
                    minM = uu-i;
                    break;
                }
            }

            if ((minP > minM)&&(minM>0)) 
            {
                return -minM;
            }
            return minP;
        }
        static public int PositivoMasCerca(int uu, int[] histog)
        {
            int minP = 0;
            int minM = 0;
            for (int i = uu + 1; i < histog.Length; i++)
            {
                if (histog[i] > 0)
                {
                    minP = i - uu;
                    break;
                }
            }
            for (int i = uu - 1; i >= 0; i--)
            {
                if (histog[i] > 0)
                {
                    minM = uu - i;
                    break;
                }
            }

            if ((minP > minM) && (minM > 0))
            {
                return -minM;
            }
            return minP;
        }
        static public bool primeroIsPositive(int[] histog) 
        {
            bool result = true;
            for (int i = 0; i < histog.Length; i++)
            {
                if (histog[i] != 0) 
                {
                    if (histog[i] > 0)
                    {
                        return result;
                    }
                    else 
                    {
                        return false;
                    }
                }
            }
            return result;
        }
        static public int[] prudence(int[] histog)
        {
            int aux1 = 0;
            int[] hist0 = new int[histog.Length];
            int[] hist1 = new int[histog.Length];
            for (int i = 0; i < histog.Length; i++) 
            {
                hist0[i] = histog[i];
                hist1[i] = 0;
            }
            for (int i = 0; i < histog.Length; i++)
            {
                    if (hist0[i] > 0) 
                    {
                        aux1=NegativoMasCerca(i, hist0);
                        hist1[i] = aux1;
                        hist0[i + aux1] += hist0[i];
                        hist0[i] = 0;
                    }
                    if (hist0[i] < 0)
                    {
                        aux1 = PositivoMasCerca(i, hist0);
                        hist1[i + aux1] = -aux1;
                        hist0[i] += hist0[i + aux1];
                        hist0[i + aux1] = 0;
                        if (hist0[i] < 0) 
                        {
                            i--;
                        }
                    }
             }
            for (int i = 0; i < histog.Length; i++)
            {
                if (hist1[i] >= 1) 
                {
                    hist1[i] = 1;
                }
                if (hist1[i] <=-1)
                {
                    hist1[i] = -1;
                }

            }
            return hist1;

        }
        static public int distanciaAMover(int uu, int[] histogramaMinus) 
        {
            int result = ImageProcessingClass.NegativoMasCerca(uu, histogramaMinus);
            if (result>0) 
            {
                if (result > 1) 
                {
                    return +1;
                }
                return +1;
            }
            else
            {
                if (result < -1)
                {
                    return -1;
                }
                return -1;
            }

        }
        #endregion

        #region StatisticTransformations
        public System.Drawing.Image meanTranslation(System.Drawing.Image image, double vvalue,int nMon, int channel)
        {
            //double mean1 = this.extract_Yxy_MEAN(image , nMon , channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon , channel);
            double diff = vvalue;// mean2 - mean1;

            Bitmap bmpimg2 = (Bitmap)image.Clone();

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    double mean = 0;
                    double matchValue = 0;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB,nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean = Yxy[channel];
                            
                            matchValue = 0;
                            matchValue = mean + diff;
                            
                            Yxy[channel] = matchValue;
                            XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);
                            RGB = this.XYZ2RGB(XYZ,nMon);
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt16(RGB[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return (System.Drawing.Image)bmpimg2;
        }
        public System.Drawing.Image SDModification(System.Drawing.Image image, double vvalue, int nMon, int channel)
        {
            double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double sd1 = this.extract_Yxy_SD(image, nMon, channel);
            //double sd2 = this.extract_Yxy_SD(image2, nMon, channel);
            double diff = vvalue;//sd1-sd2;

            Bitmap bmpimg2 = (Bitmap)image.Clone();

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    double mean = 0;
                    double matchValue = 0;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean = Yxy[channel];

                            matchValue = 0;
                            double r=mean-mean1;
                            if (r < 0)
                            {
                                matchValue = mean + diff;
                            }
                            else 
                            {
                                matchValue = mean - diff;
                            }

                            Yxy[channel] = matchValue;
                            XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);
                            RGB = this.XYZ2RGB(XYZ, nMon);
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt16(RGB[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return (System.Drawing.Image)bmpimg2;
        }
        public System.Drawing.Image SDModificationA(System.Drawing.Image image, double vvalue, int nMon, int channel)
        {
            double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double sd1 = this.extract_Yxy_SD(image, nMon, channel);
            //double sd2 = this.extract_Yxy_SD(image2, nMon, channel);
            double diff = vvalue;//sd1-sd2;

            Bitmap bmpimg2 = (Bitmap)image.Clone();

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    double mean = 0;
                    double matchValue = 0;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean = Yxy[channel];

                            matchValue = 0;
                            double r = mean - mean1;
                           
                            matchValue = mean1 + r*diff;
                            

                            Yxy[channel] = matchValue;
                            XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);
                            RGB = this.XYZ2RGB(XYZ, nMon);
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt16(RGB[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return (System.Drawing.Image)bmpimg2;
        }
        public System.Drawing.Image SkewModification(System.Drawing.Image image,double vvalue, int nMon, int channel)
        {
            double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon, channel);
            double diff = vvalue;

            Bitmap bmpimg2 = (Bitmap)image.Clone();

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    double mean = 0;
                    double matchValue = 0;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean = Yxy[channel];

                            matchValue = 0;
                            double r = mean - mean1;
                            if (diff > 0)
                            {
                                if (r < 0)
                                {
                                    matchValue = mean1 + r * diff;
                                    
                                }
                                else
                                {
                                    matchValue = mean1 + r * (1 / diff); ;

                                }
                            }
                            else 
                            {
                                if (r >0)
                                {
                                    matchValue = mean1 + r * diff;
                                }
                                else
                                {
                                    matchValue = mean1 + r * (1 / diff);
                                }
                            }
                            

                            Yxy[channel] = matchValue;
                            XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);
                            RGB = this.XYZ2RGB(XYZ, nMon);
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt16(RGB[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return (System.Drawing.Image)bmpimg2;
        }
        public System.Drawing.Image KURTModification(System.Drawing.Image image, double vvalue, int nMon, int channel)
        {
            double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon, channel);
            double sd1 = this.extract_Yxy_SD(image, nMon, channel);
            //double sd2 = this.extract_Yxy_SD(image2, nMon, channel);
            double diff = vvalue;

            Bitmap bmpimg2 = (Bitmap)image.Clone();

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    double mean = 0;
                    double matchValue = 0;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean = Yxy[channel];

                            matchValue = 0;
                            double r = mean - mean1;
                            if (r < 0)
                            {
                                if (r < -sd1)
                                {
                                    matchValue = mean +  diff;
                                }
                                else 
                                {
                                    matchValue = mean -  diff;
                                }
                            }
                            else
                            {
                                if (r < sd1)
                                {
                                    matchValue = mean +  diff;
                                }
                                else
                                {
                                    matchValue = mean -  diff;
                                }
                            }


                            Yxy[channel] = matchValue;
                            XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);
                            RGB = this.XYZ2RGB(XYZ, nMon);
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt16(RGB[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return (System.Drawing.Image)bmpimg2;
        }

        public System.Drawing.Image meanT(System.Drawing.Image image, System.Drawing.Image image2, int nMon, int channel)
        { 
                double mean1 = this.extract_Yxy_MEAN(image , nMon , channel);
                double mean2 = this.extract_Yxy_MEAN(image2, nMon , channel);
                double diff =mean2-mean1;
                double diff2 = 1;
                double meanRes = 0;
                System.Drawing.Image resultImage = null;
                System.Drawing.Image resultImagefinal = null;
                double minDiff = 1;
                int cont = 0;

                while (Math.Abs(diff2) > 0.01)
                {
                    resultImage = this.meanTranslation(image, diff, nMon, channel);
                    meanRes = this.extract_Yxy_MEAN(resultImage, nMon, channel);
                    diff2 = meanRes - mean2;
                    diff = diff - diff2;
                    cont++;
                    if (Math.Abs(minDiff)>Math.Abs(diff2)) 
                    {
                        minDiff = diff2;
                        resultImagefinal = resultImage;
                    }
                    if (cont > 100) 
                    {
                        break;
                    }
                    
                }
                return resultImagefinal;
        }
        public System.Drawing.Image SDM(System.Drawing.Image image, System.Drawing.Image image2, int nMon, int channel)
        {
            //double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon, channel);
            double sd1 = this.extract_Yxy_SD(image, nMon, channel);
            double sd2 = this.extract_Yxy_SD(image2, nMon, channel);
            double diff = sd2 - sd1;
            double diff2 = 10;
            double sdRes = 0;
            System.Drawing.Image resultImage = null;
            System.Drawing.Image resultImagefinal = null;
            double minDiff = 10;
            int cont = 0;

            while (Math.Abs(diff2) > 0.01)
            {
                resultImage = this.SDModification(image, diff, nMon, channel);
                sdRes = this.extract_Yxy_SD(resultImage, nMon, channel);
                diff2 = sdRes - sd2;
                diff = diff + diff2;
                cont++;
                if (Math.Abs(minDiff) > Math.Abs(diff2))
                {
                    minDiff = diff2;
                    resultImagefinal = resultImage;
                }
                if (cont > 100)
                {
                    break;
                }
                if (diff > 100) { break; }


            }
            return resultImagefinal;
        }
        public System.Drawing.Image SDMa(System.Drawing.Image image, System.Drawing.Image image2, int nMon, int channel)
        {
            //double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon, channel);
            double sd1 = this.extract_Yxy_SD(image, nMon, channel);
            double sd2 = this.extract_Yxy_SD(image2, nMon, channel);
            double diff = sd2 - sd1;
            double diff2 = 10;
            double sdRes = sd1;
            System.Drawing.Image resultImage = null;
            System.Drawing.Image resultImagefinal = null;
            double minDiff = 10;
            int cont = 0;
            double rati = 0;

            while (Math.Abs(diff2) > 0.01)
            {
                rati = sd2 / sdRes;
                
                resultImage = this.SDModificationA(image, rati, nMon, channel);
                //resultImage = this.SDModificationA(image, diff, nMon, channel);
                sdRes = this.extract_Yxy_SD(resultImage, nMon, channel);
                diff2 = sdRes - sd2;
                diff = diff + diff2;
                
                cont++;
                
                if (Math.Abs(minDiff) > Math.Abs(diff2))
                {
                    minDiff = diff2;
                    resultImagefinal = resultImage;
                }
                if (cont > 100)
                {
                    break;
                }
                if (diff > 100) { break; }


            }
                return  resultImagefinal;
        }
        public System.Drawing.Image SkewM(System.Drawing.Image image, System.Drawing.Image image2, int nMon, int channel)
        {
            //double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon, channel);
            double sd1 = this.extract_Yxy_SD(image, nMon, channel);
            double sd2 = this.extract_Yxy_SD(image2, nMon, channel);
            double sk1 = this.extract_Yxy_SKEW(image, nMon, channel);
            double sk2 = this.extract_Yxy_SKEW(image2, nMon, channel);
            double sdRes = sd1;
            double skRes = sk1;
            double diff = sd2 - sd1;
            double diff2 = 10;
            
            System.Drawing.Image resultImage = null;
            System.Drawing.Image resultImagefinal = null;
            double minDiff = 10;
            int cont = 0;
            double rati = 0;

            while (Math.Abs(diff2) > 0.01)
            {
                rati = sd2 / sdRes;
                resultImage = this.SkewModification(image, rati, nMon, channel);
                sdRes = this.extract_Yxy_SD(resultImage, nMon, channel);
                skRes = this.extract_Yxy_SKEW(resultImage, nMon, channel);
                diff2 = skRes - sk2;
                //diff = diff + diff2;
                cont++;
                if (Math.Abs(minDiff) > Math.Abs(diff2))
                {
                    minDiff = diff2;
                    resultImagefinal = resultImage;
                }
                if (cont > 100)
                {
                    break;
                }
                if (diff > 100) { break; }


            }
            return resultImagefinal;
        }
        public System.Drawing.Image SkewM1(System.Drawing.Image image, System.Drawing.Image image2, int nMon, int channel)
        {
            //double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon, channel);
            double sk1 = this.extract_Yxy_SKEW(image, nMon, channel);
            double sk2 = this.extract_Yxy_SKEW(image2, nMon, channel);
            double diff = sk2 - sk1;
            double diff2 = 10;
            double skRes = 0;
            System.Drawing.Image resultImage = null;
            System.Drawing.Image resultImagefinal = null;
            double minDiff = 10;
            int cont = 0;

            while (Math.Abs(diff2) > 0.01)
            {
                resultImage = this.SkewModification(image, diff, nMon, channel);
                skRes = this.extract_Yxy_SKEW(resultImage, nMon, channel);
                diff2 = skRes - sk2;
                diff =  diff2;
                cont++;
                if (Math.Abs(minDiff) > Math.Abs(diff2))
                {
                    minDiff = diff2;
                    resultImagefinal = resultImage;
                }
                if (cont > 100)
                {
                    break;
                }
                if (diff > 100) { break; }


            }
                //resultImagefinal = resultImage;
            return resultImagefinal;
        }
        public System.Drawing.Image KurtM(System.Drawing.Image image, System.Drawing.Image image2, int nMon, int channel)
        {
            //double mean1 = this.extract_Yxy_MEAN(image, nMon, channel);
            //double mean2 = this.extract_Yxy_MEAN(image2, nMon, channel);
            double sd1 = this.extract_Yxy_SD(image, nMon, channel);
            double sd2 = this.extract_Yxy_SD(image2, nMon, channel);
            double diff = sd2 - sd1;
            double diff2 = 10;
            double sdRes = 0;
            System.Drawing.Image resultImage = null;
            System.Drawing.Image resultImagefinal = null;
            double minDiff = 10;
            int cont = 0;

            while (Math.Abs(diff2) > 0.01)
            {
                resultImage = this.KURTModification(image, diff, nMon, channel);
                sdRes = this.extract_Yxy_SD(resultImage, nMon, channel);
                diff2 = sdRes - sd2;
                diff = diff + diff2;
                cont++;
                if (Math.Abs(minDiff) > Math.Abs(diff2))
                {
                    minDiff = diff2;
                    resultImagefinal = resultImage;
                }
                if (cont > 100)
                {
                    break;
                }
                if (diff > 100) { break; }


            }
            return resultImagefinal;
        }


        #endregion

        public Bitmap convertToChannelfromYxy(Bitmap bmpimg2, int nMon, int channel)
        {
            BitmapData data = new BitmapData();

            try
            {
                
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];

                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    int mean = 0;

                    double aux = 0;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB,nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);

                            mean = Convert.ToInt32(Yxy[channel]);
                           
                            aux = mean * 255 / 100;//Ymax=100


                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt16(aux);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }

            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return bmpimg2;
        }

        #region FFT
        //image =original   
        //image2=fftfiltered
        public Bitmap BW2ColorFFT(System.Drawing.Image image, System.Drawing.Image image2, int nMon)
        {
            Bitmap bmpimg2 = (Bitmap)image;
            Bitmap bmpimg4 = (Bitmap)image2;
            Bitmap bmpimg3 = AForge.Imaging.Image.Clone(bmpimg4, PixelFormat.Format24bppRgb);
           
            BitmapData data = new BitmapData();
            BitmapData data1 = new BitmapData();

            try
            {
                 
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                data1 = bmpimg3.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg3.Width, bmpimg3.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                
                RGB rgbColor1 = new RGB();
                
                double[] RGB1 = new double[3];
                double[] Lab1 = new double[3];
                RGB rgbColor2 = new RGB();
               
                double[] RGB2 = new double[3];
                double[] Lab2 = new double[3];
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    byte* ptr1 = (byte*)data1.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    int remain1 = data1.Stride - data1.Width * 3;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor1 = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB1[0] = Convert.ToDouble(rgbColor1.Red);
                            RGB1[1] = Convert.ToDouble(rgbColor1.Green);
                            RGB1[2] = Convert.ToDouble(rgbColor1.Blue);
                            Lab1 = this.RGB2XYZ(RGB1,nMon);
                            Lab1 = ImageProcessingClass.XYZ2Yxy(Lab1);

                            rgbColor2 = new RGB(ptr1[2], ptr1[1], ptr1[0]);
                            RGB2[0] = Convert.ToDouble(rgbColor2.Red);
                            RGB2[1] = Convert.ToDouble(rgbColor2.Green);
                            RGB2[2] = Convert.ToDouble(rgbColor2.Blue);
                            Lab2 = this.RGB2XYZ(RGB2, nMon);
                            Lab2 = ImageProcessingClass.XYZ2Yxy(Lab2);
                            Lab2[1] = Lab1[1];//x
                            Lab2[2] = Lab1[2];//y

                            RGB2 = ImageProcessingClass.Yxy2XYZ(Lab2);
                            RGB2 = this.XYZ2RGB(RGB2, nMon);
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt16(RGB2[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }
                            ptr1[2] = Convert.ToByte(Convert.ToInt16(rgbint[0]));
                            ptr1[1] = Convert.ToByte(Convert.ToInt16(rgbint[1]));
                            ptr1[0] = Convert.ToByte(Convert.ToInt16(rgbint[2]));
                            ptr += 3;
                            ptr1 += 3;
                        }

                        ptr += remain;
                        ptr1 += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
                bmpimg3.UnlockBits(data1);
            }
            bmpimg2.UnlockBits(data);
            bmpimg3.UnlockBits(data1);

            return bmpimg3;
        }
        #endregion

        #region ExtractHistogram
        static public int[] extractHistogramHSL(System.Drawing.Image image, int histogramSize, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();
            int[] histograma = new int[histogramSize];
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                HSL hslColor = new HSL();
                RGB rgbColor = new RGB();

                

                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;

                    for (int i = 0; i < histograma.Length; i++)
                        histograma[i] = 0;
                    int mean;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {
                            mean = 0;
                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            AForge.Imaging.HSL.FromRGB(rgbColor, hslColor);
                            if (channel == 0)
                                mean = Convert.ToInt32(hslColor.Hue * histogramSize);
                            if (channel == 1)
                                mean = Convert.ToInt32(hslColor.Saturation * histogramSize);
                            if (channel == 2)
                                mean = Convert.ToInt32(hslColor.Luminance * histogramSize);
                            histograma[mean]++;
                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            return histograma;
        }
       
        static public int[] extractHistogramRGB(System.Drawing.Image image, int histogramSize,int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();
            int[] histograma = new int[histogramSize];
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
              


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;

                    for (int i = 0; i < histograma.Length; i++)
                        histograma[i] = 0;
                    int mean;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {
                            mean = 0;
                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                          

                            mean = Convert.ToInt32(RGB[channel]) ;
                            if (mean >= histogramSize)
                            {
                                mean = histogramSize - 1;
                            }
                            if (mean <= -1)
                            {
                                mean = 0;
                            }
                            histograma[mean]++;
                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            return histograma;
        }
      
        public int[] extractHistogramYxy(System.Drawing.Image image, int histogramSize,int nMon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();
            int[] histograma = new int[histogramSize];
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;

                    for (int i = 0; i < histograma.Length; i++)
                        histograma[i] = 0;
                    int mean;

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {
                            mean = 0;
                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB,nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);

                            mean = Convert.ToInt32(Yxy[channel]) * (histogramSize / 100);
                            if (mean >= histogramSize)
                            {
                                mean = histogramSize - 1;
                            }
                            if (mean <= -1)
                            {
                                mean = 0;
                            }
                            histograma[mean]++;
                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            return histograma;
        }
        #endregion

        #region RGB Statistics
        //channel 0->R   1->G    2->B 
        static public double Stats_RGB_MEAN(System.Drawing.Image image, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();
            double mean = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                           
                            if (channel == 0)
                                mean += rgbColor.Red;
                            if (channel == 1)
                                mean += rgbColor.Green;
                            if (channel == 2)
                                mean += rgbColor.Blue;

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            mean = mean / (data.Height * data.Width);
            return mean;
        }

        static public double Stats_RGB_SD(System.Drawing.Image image, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = Stats_RGB_MEAN(image, channel);
            double sd = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            
                            if (channel == 0)
                                sd += Math.Pow(rgbColor.Red - mean, 2);
                            if (channel == 1)
                                sd += Math.Pow(rgbColor.Green - mean, 2);
                            if (channel == 2)
                                sd += Math.Pow(rgbColor.Blue - mean, 2);


                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            sd = sd / (data.Height * data.Width);
            sd = Math.Sqrt(sd);
            return sd;
        }

        static public double Stats_RGB_SKEW(System.Drawing.Image image, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = Stats_RGB_MEAN(image, channel);
            double sd = Stats_RGB_SD(image, channel); ;
            double skew = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
               
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            
                            if (channel == 0)
                                skew += Math.Pow(rgbColor.Red - mean, 3);
                            if (channel == 1)
                                skew += Math.Pow(rgbColor.Green - mean, 3);
                            if (channel == 2)
                                skew += Math.Pow(rgbColor.Blue - mean, 3);


                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            skew = skew / (data.Height * data.Width);
            skew = skew / Math.Pow(sd, 3);
            return skew;
        }

        static public double Stats_RGB_KURTOSIS(System.Drawing.Image image, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = Stats_RGB_MEAN(image, channel);
            double sd = Stats_RGB_SD(image, channel); ;
            double kurtosis = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
             
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                           
                            if (channel == 0)
                                kurtosis += Math.Pow(rgbColor.Red - mean, 4);
                            if (channel == 1)
                                kurtosis += Math.Pow(rgbColor.Green - mean, 4);
                            if (channel == 2)
                                kurtosis += Math.Pow(rgbColor.Blue - mean, 4);


                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            kurtosis = kurtosis / (data.Height * data.Width);
            kurtosis = kurtosis / Math.Pow(sd, 4);
            return kurtosis - 3;
        }

        #endregion

        #region HSL Statistics
        //channel 0->H   1->S    2->L 
        static public double Stats_HSL_MEAN(System.Drawing.Image image,int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();
            double mean = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                HSL hslColor = new HSL();
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            AForge.Imaging.HSL.FromRGB(rgbColor, hslColor);
                            if(channel==0)
                                mean += hslColor.Hue;
                            if (channel == 1)
                                mean += hslColor.Saturation;
                            if (channel == 2)
                                mean += hslColor.Luminance;

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            mean = mean / (data.Height * data.Width);
            return mean;
        }

        static public double Stats_HSL_SD(System.Drawing.Image image, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = Stats_HSL_MEAN(image, channel);
            double sd = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                HSL hslColor = new HSL();



                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            AForge.Imaging.HSL.FromRGB(rgbColor, hslColor);
                            if (channel == 0)
                                sd += Math.Pow(hslColor.Hue - mean, 2);
                            if (channel == 1)
                                sd += Math.Pow(hslColor.Saturation - mean, 2);
                            if (channel == 2)
                                sd += Math.Pow(hslColor.Luminance - mean, 2);
                           

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            sd = sd / (data.Height * data.Width);
            sd = Math.Sqrt(sd);
            return sd;
        }

        static public double Stats_HSL_SKEW(System.Drawing.Image image, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = Stats_HSL_MEAN(image,channel);
            double sd = Stats_HSL_SD(image, channel); ;
            double skew = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                HSL hslColor = new HSL();


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            AForge.Imaging.HSL.FromRGB(rgbColor, hslColor);
                            if (channel == 0)
                                skew += Math.Pow(hslColor.Hue - mean, 3);
                            if (channel == 1)
                                skew += Math.Pow(hslColor.Saturation - mean, 3);
                            if (channel == 2)
                                skew += Math.Pow(hslColor.Luminance - mean, 3);
                            

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            skew = skew / (data.Height * data.Width);
            skew = skew / Math.Pow(sd, 3);
            return skew;
        }

        static public double Stats_HSL_KURTOSIS(System.Drawing.Image image, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = Stats_HSL_MEAN(image, channel);
            double sd = Stats_HSL_SD(image, channel); ;
            double kurtosis = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                HSL hslColor = new HSL();


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            AForge.Imaging.HSL.FromRGB(rgbColor, hslColor);
                            if (channel == 0)
                                kurtosis += Math.Pow(hslColor.Hue - mean, 4);
                            if (channel == 1)
                                kurtosis += Math.Pow(hslColor.Saturation - mean, 4);
                            if (channel == 2)
                                kurtosis += Math.Pow(hslColor.Luminance - mean, 4);
                            

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            kurtosis = kurtosis / (data.Height * data.Width);
            kurtosis = kurtosis / Math.Pow(sd, 4);
            return kurtosis-3;
        }
       
        #endregion

        #region Yxy Statistics
        //Channel specifies if is 0 Luminance or 1 x or 2 y 
        public double extract_Yxy_MEAN(System.Drawing.Image image,int nmon,int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = 0;
            int numCERO = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];
                
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            if ((RGB[0] == 0) && (RGB[1] == 0) && (RGB[2] == 0))
                            {
                                numCERO++;
                            }
                            else
                            {
                                XYZ = this.RGB2XYZ(RGB, nmon);
                            }
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean += Yxy[channel];

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            mean = mean / (data.Height * data.Width-numCERO);
            return mean;
        }
        public double extract_Yxy_SD(System.Drawing.Image image, int nmon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = extract_Yxy_MEAN(image, nmon, channel);
            double sd = 0;
            int numCERO = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            if ((RGB[0] == 0) && (RGB[1] == 0) && (RGB[2] == 0))
                            {
                                numCERO++;
                            }
                            else
                            {
                                XYZ = this.RGB2XYZ(RGB, nmon);
                            }
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            sd += Math.Pow(Yxy[channel] - mean, 2);

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            sd = sd / (data.Height * data.Width-numCERO);
            sd = Math.Sqrt(sd);
            return sd;
        }
        public double extract_Yxy_SKEW(System.Drawing.Image image, int nmon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = extract_Yxy_MEAN(image,nmon,channel);
            double sd = extract_Yxy_SD(image, nmon, channel);
            double skew = 0;
            int numCERO = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];

                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            if ((RGB[0] == 0) && (RGB[1] == 0) && (RGB[2] == 0))
                            {
                                numCERO++;
                            }
                            else
                            {
                                XYZ = this.RGB2XYZ(RGB, nmon);
                            }
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            skew += Math.Pow(Yxy[channel] - mean, 3);

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            skew = skew / (data.Height * data.Width -numCERO);
            skew = skew / Math.Pow(sd, 3);
            return skew;
        }
        public double extract_Yxy_KURTOSIS(System.Drawing.Image image, int nmon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();
            double mean = extract_Yxy_MEAN(image,nmon,channel);
            double sd = extract_Yxy_SD(image, nmon, channel);
            double kurtosis = 0;
            int numCERO = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];

                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            if ((RGB[0] == 0) && (RGB[1] == 0) && (RGB[2] == 0))
                            {
                                numCERO++;
                            }
                            else
                            {
                                XYZ = this.RGB2XYZ(RGB, nmon);
                            }
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            kurtosis += Math.Pow(Yxy[channel] - mean, 4);

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            kurtosis = kurtosis / (data.Height * data.Width-numCERO);
            kurtosis = kurtosis / Math.Pow(sd, 4);
            return kurtosis-3;
        }

        #endregion

        #region Lab Statistics
        //Channel specifies if is 0 Luminance or 1 a or 2 b 
        public double extract_Lab_MEAN(System.Drawing.Image image, int nmon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Lab = new double[3];

                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);

                            XYZ = this.RGB2XYZ(RGB, nmon);

                            Lab = ImageProcessingClass.XYZ2Lab(XYZ);
                            mean += Lab[channel];

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            mean = mean / (data.Height * data.Width);
            return mean;
        }
        public double extract_Lab_SD(System.Drawing.Image image, int nmon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = extract_Lab_MEAN(image, nmon, channel);
            double sd = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Lab = new double[3];


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nmon);
                            Lab = ImageProcessingClass.XYZ2Lab(XYZ);
                            sd += Math.Pow(Lab[channel] - mean, 2);

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            sd = sd / (data.Height * data.Width);
            sd = Math.Sqrt(sd);
            return sd;
        }
        public double extract_Lab_SKEW(System.Drawing.Image image, int nmon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();

            double mean = extract_Lab_MEAN(image, nmon, channel);
            double sd = extract_Lab_SD(image, nmon, channel);
            double skew = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Lab = new double[3];

                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nmon);
                            Lab = ImageProcessingClass.XYZ2Lab(XYZ);
                            skew += Math.Pow(Lab[channel] - mean, 3);

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            skew = skew / (data.Height * data.Width);
            skew = skew / Math.Pow(sd, 3);
            return skew;
        }
        public double extract_Lab_KURTOSIS(System.Drawing.Image image, int nmon, int channel)
        {
            Bitmap bmpimg = (Bitmap)image;
            BitmapData data = new BitmapData();
            double mean = extract_Lab_MEAN(image, nmon, channel);
            double sd = extract_Lab_SD(image, nmon, channel);
            double kurtosis = 0;
            try
            {
                data = bmpimg.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Lab = new double[3];

                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    int remain = data.Stride - data.Width * 3;


                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nmon);
                            Lab = ImageProcessingClass.XYZ2Lab(XYZ);
                            kurtosis += Math.Pow(Lab[channel] - mean, 4);

                            ptr += 3;
                        }

                        ptr += remain;
                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg.UnlockBits(data);
            }
            bmpimg.UnlockBits(data);
            kurtosis = kurtosis / (data.Height * data.Width);
            kurtosis = kurtosis / Math.Pow(sd, 4);
            return kurtosis - 3;
        }

        #endregion
        
        static public int[] stretchHistogram(int[] histogra, int min, int max)
        {
            int histogramin = ImageProcessingClass.searchMinHistogram(histogra);
            int histogramax = ImageProcessingClass.searchMaxHistogram(histogra);
            int[] histox = new int[histogra.Length];
            int aux;
            for (int i = histogramin; i < histogramax; i++) 
            {
                aux = Convert.ToInt16((min + (max - min) * (i - histogramin) / (histogramax - histogramin)));
                histox[aux] = histogra[i] ;
            }
            
            return histox;
        }
        static public int[] translateHistogram(int[] histogra, int mean)
        {
            int mean2 = ImageProcessingClass.meanHistogram(histogra);
            //int histogramax = HistogramForm.searchMaxHistogram(histogra);
            int[] histox = new int[histogra.Length];

            int aux=Convert.ToInt32(mean-mean2);
            if (aux > 0)
            {
                for (int i = 0; i < histogra.Length - aux; i++)
                {
                    histox[i + aux] = histogra[i];
                }
                for (int i = histogra.Length - aux; i < histogra.Length; i++)
                {
                    histox[i] += histogra[i];
                }
            }
            else 
            {
                for (int i =-aux; i < histogra.Length ; i++)
                {
                    histox[i+aux] = histogra[i];
                }
                for (int i =0; i < -aux; i++)
                {
                    histox[i] += histogra[i];
                }
            }
            return histox;
        }
        static public int meanHistogram(int[] histogra)
        {
            int acc = 0;
            for (int i = 0; i< histogra.Length; i++)
            {
                acc += ((histogra[i]*i));
            }
            double d = acc /262144;
            int mean =Int32.Parse(d.ToString());
            return mean;
        }
        static public int searchMaxHistogram(int[] histogra)
        {
            for (int i = histogra.Length-1; i > 0; i--)
            {
                if (histogra[i] > 0)
                {
                    return i;
                }
            }
            return histogra.Length-1;
        }
        static public int searchMinHistogram(int[] histogra)
        {
            for (int i = 0; i < histogra.Length; i++) 
            {
                if (histogra[i] > 0) 
                {
                    return i;
                }
            }
            return 0;
        }
        static public int[] inverseSkewHistogram(int[] histogra, int mean)
        {
            int[] result = new int[histogra.Length];
            result[mean]=histogra[mean];
            int j=0;
            for (int i = mean-1; i >=0; i--) 
            { 
                j=2*mean-i;
                if(j<histogra.Length)
                {
                    result[j]=histogra[i];
                }

            }
            for (int i = mean + 1; i < histogra.Length; i++)
            {
                int aux=mean-(i - mean);
                if (aux > 0)
                {
                    result[ aux] = histogra[i];
                }

            }
            return result;
        }
        //Inverse Skewness
        public void inverseSkew(System.Drawing.Image image, int nMon, int channel)
        {
            int[] histograma1 = this.extractHistogramYxy(image, 100, nMon, channel);

            int[] histograma2 = this.extractHistogramYxy(image, 100, nMon, channel);

            histograma2 = ImageProcessingClass.inverseSkewHistogram(histograma2, ImageProcessingClass.meanHistogram(histograma1));

            ////histograma acumulado;

            histograma1 = ImageProcessingClass.cumuladoHistogram(histograma1);
            histograma2 = ImageProcessingClass.cumuladoHistogram(histograma2);


            Bitmap bmpimg2 = (Bitmap)image;

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];


                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                    int mean = 0;
                    int matchValue = 0;



                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB,nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);


                            mean = Convert.ToInt32(Yxy[channel]);
                            if (mean >= 100)
                            {
                                mean = 99;
                            }
                            if (mean <= -1)
                            {
                                mean = 0;
                            }

                            matchValue = 0;
                            matchValue = ImageProcessingClass.searchIndexHistogram(histograma2, histograma1[mean]);
                            Yxy[channel] = Convert.ToDouble(matchValue);

                            XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);

                            RGB = this.XYZ2RGB(XYZ,nMon);

                            
                            int[] rgbint = new int[3];
                            for (int h = 0; h < 3; h++)
                            {
                                rgbint[h] = Convert.ToInt32(RGB[h]);
                                if (rgbint[h] > 255)
                                {
                                    rgbint[h] = 255;
                                }
                                if (rgbint[h] < 0)
                                {
                                    rgbint[h] = 0;
                                }
                            }


                            ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                            ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                            ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;

                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);

        }

        public System.Drawing.Image threshold(System.Drawing.Image image, int channel, double thres, int nMon)
        {
            Bitmap bmpimg2 = (Bitmap)image;

            BitmapData data = new BitmapData();

            try
            {
                data = bmpimg2.LockBits(new System.Drawing.Rectangle(0, 0, bmpimg2.Width, bmpimg2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                RGB rgbColor = new RGB();
                double[] RGB = new double[3];
                double[] XYZ = new double[3];
                double[] Yxy = new double[3];
                double mean = 0;
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    byte* ptr2 = (byte*)data.Scan0;
                    int remain = data.Stride - data.Width * 3;
                  

                    for (int i = 0; i < data.Height; i++)
                    {
                        for (int j = 0; j < data.Width; j++)
                        {

                            rgbColor = new RGB(ptr[2], ptr[1], ptr[0]);
                            RGB[0] = Convert.ToDouble(rgbColor.Red);
                            RGB[1] = Convert.ToDouble(rgbColor.Green);
                            RGB[2] = Convert.ToDouble(rgbColor.Blue);
                            XYZ = this.RGB2XYZ(RGB, nMon);
                            Yxy = ImageProcessingClass.XYZ2Yxy(XYZ);
                            mean = Yxy[channel];

                            //Yxy[channel] = matchValue;
                            //XYZ = ImageProcessingClass.Yxy2XYZ(Yxy);
                            //RGB = this.XYZ2RGB(XYZ, nMon);
                            if (mean > thres)
                            {
                                ptr2 =ptr- 3;
                                ptr[2] = ptr2[2];
                                ptr[1] = ptr2[1];
                                ptr[0] = ptr2[0];

                                //int[] rgbint = new int[3];
                                //for (int h = 0; h < 3; h++)
                                //{
                                //    rgbint[h] = Convert.ToInt16(RGB[h]);
                                //    if (rgbint[h] > 255)
                                //    {
                                //        rgbint[h] = 255;
                                //    }
                                //    if (rgbint[h] < 0)
                                //    {
                                //        rgbint[h] = 0;
                                //    }
                                //}


                                //ptr[1] = Convert.ToByte(rgbint[1]);//rgbColor.Green; 
                                //ptr[0] = Convert.ToByte(rgbint[2]);//rgbColor.Blue; 
                                //ptr[2] = Convert.ToByte(rgbint[0]);// rgbColor.Red;
                            }
                           
                            ptr += 3;

                        }

                        ptr += remain;

                    }


                }
            }
            catch (Exception el)
            {
                el.ToString();
                bmpimg2.UnlockBits(data);
            }
            bmpimg2.UnlockBits(data);
            return (System.Drawing.Image)bmpimg2;
           
        }
    }
}
