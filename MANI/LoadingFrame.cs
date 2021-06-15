using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MANI
{
    public partial class LoadingFrame : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public LoadingFrame(int size)
        {
            InitializeComponent();
            this.progressBarLoading.Maximum=size;
        }

       public void plus()
       {
           this.progressBarLoading.Increment(1);
           this.Refresh();
           if(this.progressBarLoading.Value<10)this.labelLoading.Text = "LOADING "+this.progressBarLoading.Value+" of "+this.progressBarLoading.Maximum;
           else this.labelLoading.Text = "PLEASE WAIT " + this.progressBarLoading.Value + " of " + this.progressBarLoading.Maximum;
       }
    }
}
