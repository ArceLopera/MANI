using System;
using System.Windows.Forms;
using System.Drawing;
using OpenGL;
using WeifenLuo.WinFormsUI;

using AForge.Math;
using AForge.Imaging;

namespace MANI 
{
	/// <summary>
	/// Example form to contain the example implementation of BaseGLControl
	/// </summary>
    class tresDHistogram : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public TestGL glControl = new TestGL(true);		//Example implementation
        private Timer updateTimer = new Timer();	//Refresh  timer

		static Form _this = null;
		/// <summary>
		/// Singleton for accessing our application
		/// </summary>
		public static Form App
		{
			get
			{
				if(_this == null)
					_this = new tresDHistogram();
				return _this;
			}
		}

		public tresDHistogram()
		{
			InitializeComponent();
			glControl.Location = new Point(0,0);	//Position control at 0
			glControl.Dock = DockStyle.Fill;		//Dock to fill form
			glControl.Visible = true;

			
			this.Load += new EventHandler(MainForm_Load);	//Add load handler to create timer
			this.Closing += new System.ComponentModel.CancelEventHandler(MainForm_Closing);
			this.Controls.Add(glControl);
		}
		void InitializeComponent() {
            this.SuspendLayout();
            // 
            // tresDHistogram
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "tresDHistogram";
            this.TabText = "3D Histogram";
            this.Text = "3D Histogram";
            this.Load += new System.EventHandler(this.tresDHistogram_Load);
            this.ResumeLayout(false);

		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(updateTimer != null)		//Close refresh timer
				{
					updateTimer.Stop();
					updateTimer.Dispose();
					updateTimer = null;
				}
			}
			base.Dispose( disposing );
		}
		
		/// <summary>
		/// When the form loads create a refresh timer
		/// </summary>
		private void MainForm_Load(object sender, EventArgs e)
		{
			updateTimer.Interval = 10;
			updateTimer.Tick += new EventHandler(updateTimer_Tick);
			updateTimer.Start();
		}

		/// <summary>
		/// When the timer fires, refresh control
		/// </summary>
		private void updateTimer_Tick(object sender, EventArgs e)
		{
			glControl.Invalidate();
		}

		/// <summary>
		/// When the form closes, close the refresh timer
		/// </summary>
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(updateTimer != null)
			{
				updateTimer.Stop();
				updateTimer.Dispose();
				updateTimer = null;
			}
		}

        private void tresDHistogram_Load(object sender, EventArgs e)
        {

        }

		//[STAThread]
        //public static void Main(string[] args)
        //{
        //    DialogResult res = MessageBox.Show(null,"Would You Like To Run In Fullscreen Mode?",
        //        "Start Fullscreen?",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
        //    MainForm form = (MainForm)MainForm.App;
        //    if(res == DialogResult.Yes)
        //    {
        //        form.FormBorderStyle = FormBorderStyle.None;
        //        form.Location = new Point(0,0);
        //        form.Size = Screen.PrimaryScreen.Bounds.Size;
        //    }
        //    Application.Run(form);
        //}

        
	}			
}
