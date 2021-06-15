using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI;

using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace MANI
{
    public partial class ImageForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public System.Drawing.Image imagen;
        public String id;
        public int x=0, y = 0;
        public MainMani papa;
        
       
        public ImageForm(System.Drawing.Image imagen, string name, MainMani papa)
        {
            InitializeComponent();
            this.papa = papa;
            this.imagen = imagen;
            Bitmap bito = (Bitmap)imagen;
            //this.TabText = name;
            this.ImagePictureBox.Image = bito;
            string[] splitter  = new string[1];
            splitter[0]="\\";
            string[] aux=name.Split(splitter,StringSplitOptions.RemoveEmptyEntries);
            this.id = aux[aux.Length-1];
            splitter[0] = ".";
            aux = this.id.Split(splitter,StringSplitOptions.RemoveEmptyEntries);
            
             this.id = aux[0];
             this.TabText = this.id;
        }

        private void ImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                this.PositionLabel.Text = " ( " + e.X + " , " + e.Y + " ) ";
                Color pixelColor = ((Bitmap)this.ImagePictureBox.Image).GetPixel(e.X, e.Y);
                this.RGBLabel.Text = "RGB : (" + pixelColor.R + "," + pixelColor.G + "," + pixelColor.B + ")";

                this.x = e.X;
                this.y = e.Y;
                if (this.papa.BoolSquarePatch)
                {
                    this.ImagePictureBox.Invalidate();
                }
               
            }
            catch (Exception em) 
            {
                em.Message.ToString();
            }
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            if (this.imagen != null)
            {
                this.Tamagno.Text = this.imagen.Width + " x " + this.imagen.Height;
            }

            this.zoom.Text = "100 %";
            
            //Rectangle rc = ClientRectangle;

            //float zoom = Math.Min((float)rc.Width / (this.imagen.Width + 2), (float)rc.Height / (this.imagen.Height + 2));
            
            //this.AutoScrollMinSize = new Size((int)(this.imagen.Width * zoom), (int)(this.imagen.Height * zoom));
            try
            {
                this.ImagePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size((int)(this.imagen.Width), (int)(this.imagen.Height));
                
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
           
        }

        private void ImageForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.ImagePictureBox.SizeMode == PictureBoxSizeMode.StretchImage)
                {
                    Rectangle rc = ClientRectangle;

                    float zoom = Math.Min((float)rc.Width / (this.imagen.Width + 2), (float)rc.Height / (this.imagen.Height + 2));

                    this.zoom.Text = (zoom * 100).ToString();

                    this.zoom.Text += " %";
                }
            }
            catch (Exception em)
            {
                em.Message.ToString();
            }
        }

        private void BasicDataStatusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.papa.BoolSquarePatch)
            {
                int largo = 128, ancho = 128;
                //Graphics gg = this.ImagePictureBox.CreateGraphics();
                //PaintEventArgs ee = new PaintEventArgs(gg, new Rectangle(0, 0, this.imagen.Width, this.imagen.Height));
                Pen pen = new Pen(Color.FromArgb(255, 255, 0, 0), 2);
                e.Graphics.DrawLine(pen, this.x, this.y, this.x, this.y + ancho);
                e.Graphics.DrawLine(pen, this.x + largo, this.y + ancho, this.x + largo, this.y);
                e.Graphics.DrawLine(pen, this.x, this.y, this.x + largo, this.y);
                e.Graphics.DrawLine(pen, this.x + largo, this.y + ancho, this.x, this.y + ancho);
                this.papa.patchX=this.x;
                this.papa.patchY=this.y;

             }
        }

       
           

        

       
    }
}
