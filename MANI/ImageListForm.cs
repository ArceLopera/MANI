using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MANI
{
    public partial class ImageListForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private ArrayList imagenArray;
        private ArrayList histogramArray;

        public ImageListForm( ArrayList imagenArray,  ArrayList histogramArray)
        {
            InitializeComponent();
            this.imagenArray = imagenArray;
            this.histogramArray = histogramArray;
        }

        private void ImageListForm_Load(object sender, EventArgs e)
        {
            string[] row;
            for (int i = 0; i < this.imagenArray.Count; i++) 
            {
                row = new string[] { i.ToString(), ((ImageForm)this.imagenArray[i]).TabText };
                this.dgvFiles.Rows.Add(row);
            }
        }
    }
}
