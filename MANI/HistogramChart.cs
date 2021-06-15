using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using dotnetCHARTING.WinForms;

namespace MANI
{
    class HistogramChart
    {

        public void CreateChart(ref Chart chart1, SeriesCollection SC)
        {

           

            // set the x axis clustering
            chart1.XAxis.ClusterColumns = true;

            // Set a default transparency
            chart1.DefaultSeries.DefaultElement.Transparency = 20;

            // Set the Default Series Type
            chart1.DefaultSeries.Type = SeriesType.Bar;

            // Set the x axis label
            chart1.XAxis.Label.Text = "X Axis Label";

            // Set the y axis label
            chart1.YAxis.Label.Text = "Y Axis Label";

            // Set the directory where the images will be stored.
            chart1.TempDirectory = "temp";


            // Set he chart size.
            chart1.Width = 600;
            chart1.Height = 350;

            // Add the  data.
            chart1.SeriesCollection.Add(SC);

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        
    }
}
