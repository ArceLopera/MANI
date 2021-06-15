using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpenGL;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace MANI 
{
	/// <summary>
	/// Example implementation of the BaseGLControl
	/// </summary>
	public class TestGL : BaseGLControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		bool direction = false;

        public int[] histogram;
        public ArrayList HistogramList;
        public int opcion;
        bool ShowAxes = false;


		public TestGL(bool direction)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.direction  = direction;
			this.KeyPress += new KeyPressEventHandler(TestGL_KeyPress);

            this.histogram = new int[256];
            this.opcion = 0;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		long lastMs = 0;
		float angleX = 340.0f;
        float angleY =390.0f;
        float angleZ = 345.0f;
        float posX = -0.8f;
        float posY = 0.2f;
        float posZ = -3.0f;

		/// <summary>
		/// Override OnPaint to draw our gl scene
		/// </summary>
		protected override void OnPaint( System.Windows.Forms.PaintEventArgs e )
		{
			//float rot1 = 0,rot2 = 0;

			if(DC == 0 || RC == 0)
				return;

            if (lastMs == 0)
                lastMs = DateTime.Now.Ticks;
            long currentMs = DateTime.Now.Ticks;
            long milliseconds = (currentMs - lastMs) / 10000;
            lastMs = currentMs;										//Calculate elapsed timer

			WGL.wglMakeCurrent(DC,RC);
            GL.glLineWidth(1.0f);
			GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
			GL.glLoadIdentity();

			GL.glTranslatef (posX, posY,posZ);						// Translate  CAMERA
			GL.glRotatef (angleX, 0.0f, 1.0f, 0.0f);					// Rotate On The X-Axis By angle
            GL.glRotatef(angleY, 1.0f, 0.0f, 0.0f);						// Rotate On The Y-Axis By angle
            GL.glRotatef(angleZ, 0.0f, 0.0f, 1.0f);						// Rotate On The Z-Axis By angle
            if (this.ShowAxes)
            {

                GL.glBegin(GL.GL_LINES);

                // Begin Drawing
                for (int i = 0; i < 10; i++)
                {
                    GL.glColor3f(1.0f, 0.0f, 0.0f);//Red

                    GL.glVertex3d(0.0f, 0.0f, 0.0f + 0.1f * i);
                    GL.glVertex3d(0.0f, 1.0f, 0.0f + 0.1f * i);
                    GL.glVertex3d(0.0f, 0.0f + 0.1f * i, 0.0f);
                    GL.glVertex3d(0.0f, 0.0f + 0.1f * i, 1.0f);
                }
                for (int i = 0; i < 10; i++)
                {
                    GL.glColor3f(0.0f, 1.0f, 0.0f);//Green

                    GL.glVertex3d(0.0f + 0.1f * i, 0.0f, 0.0f);
                    GL.glVertex3d(0.0f + 0.1f * i, 0.0f, 1.0f);
                    GL.glVertex3d(0.0f, 0.0f, 0.0f + 0.1f * i);
                    GL.glVertex3d(1.0f, 0.0f, 0.0f + 0.1f * i);
                }
                for (int i = 0; i < 10; i++)
                {
                    GL.glColor3f(0.0f, 0.0f, 1.0f);//Blue

                    GL.glVertex3d(0.0f, 0.0f + 0.1f * i, 0.0f);
                    GL.glVertex3d(1.0f, 0.0f + 0.1f * i, 0.0f);
                    GL.glVertex3d(0.0f + 0.1f * i, 0.0f, 0.0f);
                    GL.glVertex3d(0.0f + 0.1f * i, 1.0f, 0.0f);



                }
                GL.glEnd();
            }
            int max = 1;
            
            double aux=0;
            bool flag = false;
            AForge.Math.Histogram histogramMean;
            GL.glLineWidth(2.0f);
            for (int j = 0; j < this.HistogramList.Count; j++)
            {
                histogramMean = ((HistogramForm)this.HistogramList[j]).histogramMean;
                if (this.opcion ==1)
                {
                    histogramMean = ((HistogramForm)this.HistogramList[j]).histogramR;
                    flag = true;
                }
                if (this.opcion == 2)
                {
                    histogramMean = ((HistogramForm)this.HistogramList[j]).histogramG;
                    flag = true;
                }
                if (this.opcion == 3)
                {
                    histogramMean = ((HistogramForm)this.HistogramList[j]).histogramB;
                    flag = true;
                }
                //max = 1;
                int hasta = 100;//////////////////////
                if (flag)
                {
                    hasta = 256;
                }
                //for (int i = 0; i < hasta; i++)
                //{
                //    if (max < histogramMean.Values[i])
                //        max = histogramMean.Values[i];
                //}
                max = 262144;
                
                GL.glBegin(GL.GL_LINE_STRIP);
                for (int i =0; i < hasta; i++)
                {
                    
                    aux = Convert.ToDouble(histogramMean.Values[i]) / Convert.ToDouble(max);
                    float aux2 = 0.0f;
                    if (float.TryParse(aux.ToString(),out aux2)) 
                    {
                        if (aux2 > 1.0f)
                        {
                            aux2 = 1.0f;
                            
                        }
                        else 
                        {
                            
                            //GL.glColor3f(0.0f + 0.1f * j, 0.5f + aux2, 0.5f + aux2);//
                            GL.glColor3f(1.0f, 1.0f, 1.0f);
                            if ((aux2 > 0.0f) && (aux2 <1.0)) 
                            {
                                GL.glColor3f(1.0f, 0.0f, 0.0f);//rojo
                                if (aux2 > 0.12)
                                {
                                    GL.glColor3f(0.3f, 0.9f, 0.3f);//verde claro

                                }
                                else
                                {
                                    if (aux2 < 0.01)
                                    {
                                        GL.glColor3f(0.0f, 0.3f, 0.0f);//Verde oscuro
                                    }
                                    else
                                    {
                                        if (aux2 < 0.03)
                                        {
                                            GL.glColor3f(1.0f, 1.0f, 0.0f);//Amarillo
                                        }
                                        else
                                        {
                                            if (aux2 < 0.05)
                                            {
                                                GL.glColor3f(1.0f, 0.0f, 0.0f);//ROJO
                                            }
                                            else
                                            {
                                                if (aux2 < 0.08)
                                                {
                                                    GL.glColor3f(0.0f, 0.0f, 1.0f);//Azul
                                                }
                                                else
                                                {
                                                    GL.glColor3f(1.0f, 1.0f, 1.0f);//Blanco
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        //GL.glColor3f(0.0f + 0.05f * j, 1.0f, 1.0f);//azul marino
                        GL.glColor3f(1.0f, 1.0f, 1.0f);//blanco
                    }
                    
                    GL.glVertex3d((0.00390625) * i, aux, 0.0f + 0.05f * j);
                }
                GL.glEnd();
            }

                

           

			GL.glFlush ();													// Flush The GL Rendering Pipeline
			WGL.wglSwapBuffers(DC);
			//angle += (float)(milliseconds) / 20.0f;	                        //entre mas grande mas lento
		}

		/// <summary>
		/// Handle keys, specifically escape
		/// </summary>
		private void TestGL_KeyPress(object sender, KeyPressEventArgs e)
		{
			
            if (e.KeyChar == (char)120)
            {
                angleX += (float) 0.2f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)100)
            {
                angleX -= (float)0.2f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)99)
            {
                angleY += (float)0.2f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)102)
            {
                angleY -= (float)0.2f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)122)
            {
                angleZ += (float)0.2f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)115)
            {
                angleZ -= (float)0.2f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)50)
            {
                posY -= (float)0.002f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)56)
            {
                posY += (float)0.002f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)52)
            {
                posX -= (float)0.002f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)54)
            {
                posX += (float)0.002f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)43)
            {
                posZ += (float)0.002f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)45)
            {
                posZ -= (float)0.002f;
                this.OnPaint(null);
            }
            if (e.KeyChar == (char)97)
            {
                this.ShowAxes = !this.ShowAxes;
            }
		}
	}
}
