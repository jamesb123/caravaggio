using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.UVC;
using Dynamsoft.Core;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing.Imaging;

using Dynamsoft.Common;
using Dynamsoft.Core.Enums;
using System.Drawing.Drawing2D;

namespace WebcamDemo
{
    public partial class Form2 : Form
    {
        private int m_iDesignWidth = 755;
        private int iControlWidth = 705;
        private int iControlHeight = 529;
        // jwb
        // public int m_picureBox_Width = 475;  //was 560
        // public int m_pictureBox_Height = 456; // was 420 originally
        public float ZoomFactor;
        public bool ZoomFlagL = false;
        public bool ZoomFlagR = false;
        public bool ZoomFlagV = false;

        private CameraManager m_CameraManager = null;
        private ImageCore m_ImageCore = null;
        private string m_StrProductKey = "f0068NQAAAMeaSwhqrllOtEhBY5fUvFCrax16yX9NUFDETkhm5A34ttDFM2kgTG9akPzyhOAkbggPoInw6DP5wjXGDaD9OuE=";
        private Camera m_CurrentCamera = null;
        public int m_pb1_width;
        public int m_pb1_height;
        public Point m_pb1_loc;
        public float ZoomRight_X;
        public float ZoomRight_Y;
        public float ZoomLeft_X;
        public float ZoomLeft_Y;
        static List<Line> save_right = new List<Line>();
        public Point save_rpbl = new Point(0, 0);
        public Point save_lpbl = new Point(0, 0);


        class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }
        }

        //matt added to example
        private ImageCore m_LeftImage = null;
        private ImageCore m_RightImage = null;
        private double pw = 1.75;
        private Pen pen = new Pen(Color.Green, (float)(1.75));



        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
