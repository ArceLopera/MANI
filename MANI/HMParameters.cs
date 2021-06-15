using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MANI
{
    public partial class HMParameters : Form
    {
        String imageBaseName;
        String imageTargetName;
        System.Drawing.Image imageBase;
        System.Drawing.Image imageTarget;
        MainMani main;
        public HMParameters(String nBase, String nTarget, System.Drawing.Image imageB, System.Drawing.Image imageT,MainMani m)
        {
            InitializeComponent();
            this.imageBaseName = nBase;
            this.imageTargetName = nTarget;
            this.label3.Text = this.imageTargetName;
            this.label4.Text = this.imageBaseName;
            this.imageBase = imageB;
            this.imageTarget=imageT;
            this.main = m;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked) 
            {
                this.radioButton1.Text = "R";
                this.radioButton2.Text = "G";
                this.radioButton3.Text = "B";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton6.Checked)
            {
                this.radioButton1.Text = "Y";
                this.radioButton2.Text = "x";
                this.radioButton3.Text = "y";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.radioButton6.Checked)
            {
                if (radioButton1.Checked)
                {
                    this.main.ipc.HistogramMatching(this.imageBase, this.imageTarget, 100, this.main.ipc.MonitorConfigNumber, 0, this.checkBox1.Checked);
                }
                if (radioButton2.Checked)
                {
                    this.main.ipc.HistogramMatching(this.imageBase, this.imageTarget, 100, this.main.ipc.MonitorConfigNumber, 1, this.checkBox1.Checked);
                }
                if (radioButton3.Checked)
                {
                    this.main.ipc.HistogramMatching(this.imageBase, this.imageTarget, 100, this.main.ipc.MonitorConfigNumber, 2, this.checkBox1.Checked);
                }
                
            }
            if (this.radioButton4.Checked)
            {
                if (radioButton1.Checked)
                {
                    ImageProcessingClass.HistogramMatchingRGB(this.imageBase, this.imageTarget, 0, this.checkBox1.Checked);
                }
                if (radioButton2.Checked)
                {
                    ImageProcessingClass.HistogramMatchingRGB(this.imageBase, this.imageTarget, 1, this.checkBox1.Checked);
                }
                if (radioButton3.Checked)
                {
                    ImageProcessingClass.HistogramMatchingRGB(this.imageBase, this.imageTarget, 2, this.checkBox1.Checked);
                }
                
            }
            this.main.Refresh();
        }

     

        
    }
}
