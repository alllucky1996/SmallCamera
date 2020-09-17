using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCam
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        public Form1()
        {
            InitializeComponent();
            _capture = new VideoCapture();
            _capture.ImageGrabbed += ProcessFrame;
            _capture.Start();
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                // var _frame = _capture.QueryFrame();
                var _frame = new Mat();
                _capture.Retrieve(_frame, 0);
                if (_frame != null)
                {
                    var dtF = _frame.ToImage<Bgr, byte>().ToBitmap();
                    picCam.Image = dtF;
                }

            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            _capture.Stop();
            this.Close();
            Application.Exit();
        }
    }
}
