using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

/// <summary>
/// Notes:
/// PictureBox SizeMode property is set to 'ZOOM', but here is a description of the other modes:
/// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.picturebox.sizemode?view=netframework-4.7.2
/// By default, in NORMAL mode, the Image is positioned in the upper-left corner of the PictureBox, and any part of the image that is too big for the PictureBox is clipped.
/// Using the STRETCHIMAGE value causes the image to stretch or shrink to fit the PictureBox.
/// Using the ZOOM value causes the image to be stretched or shrunk to fit the PictureBox; however, the aspect ratio in the original is maintained.
/// Using the AUTOSIZE value causes the control to resize to always fit the image.Using the CenterImage value causes the image to be centered in the client area.
/// 
/// 
/// 
/// </summary>
namespace WebcamDemo
{

    public partial class Form1 : Form
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
        public float ZoomRight_X ;
        public float ZoomRight_Y ;
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
        

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            m_CameraManager = new CameraManager(m_StrProductKey);
            m_ImageCore = new ImageCore();
            //JWB not used 
            //dsViewer1.Bind(m_ImageCore);
            this.Load += new EventHandler(Form1_Load);

            //The stuff Matt added to the example, uses picture boxes instead of dynamsoft controls
            InitializeLeftRight();
            m_pb1_width = pictureBox1.Width;
            m_pb1_height = pictureBox1.Height;
            m_pb1_loc = pictureBox1.Location;
            save_rpbl = pictureBox_Right.Location;
            save_lpbl = pictureBox_Left.Location;

            textBoxDate.Text = DateTime.Now.ToString("yyyy/MM/dd  HH:mm");
            ZoomRight_X = 1080F / m_pb1_width;
            ZoomRight_Y = 810F / m_pb1_height;
            ZoomLeft_X = 1080F / m_pb1_width;
            ZoomLeft_Y = 810F / m_pb1_height;


            //attemps to control the dynamstoft controls, picturebox was just way more straightforward
            //Init_Unused();
        } //end form1

        // pick a line width 
        private void button1_Click(object sender, EventArgs e)
        {
            pw = Convert.ToDouble(textLineWidth.Text);
            pen.Width = (float)(pw);

        }
        // pick a color
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog1.Color;
                pen.Color = colorDialog1.Color;
            }

        }
        /// <summary>
        /// Adds events and objects for drawing lines on the right and left pictureboxes
        /// </summary>
        public void InitializeLeftRight()
        {
            // pictureBox_Right.Width = m_picureBox_Width;
            // pictureBox_Right.Height = m_pictureBox_Height;
            // pictureBox_Left.Width = m_picureBox_Width;
            // pictureBox_Left.Height = m_pictureBox_Height;
            
            ZoomFactor = 980.0F / (float)pictureBox_Right.Width;

            m_LeftImage = new ImageCore();
            m_RightImage = new ImageCore();
            //dsViewerLeft.Bind(m_LeftImage);
            // dsViewerRight.Bind(m_RightImage);

            Line line_Left = null;
            var lines_Left = new List<Line>();

            Line line_Right = null;
            var lines_Right = new List<Line>();


            //left box
            pictureBox_Left.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    line_Left.End = e.Location;
                    pictureBox_Left.Invalidate();
                }
            };
            pictureBox_Left.MouseDown += (s, e) =>
            {
                if (lines_Left.Count == 2)
                {
                    lines_Left = new List<Line>(); //reset the lines
                }
                if (e.Button == MouseButtons.Left)
                    line_Left = new Line { Start = e.Location, End = e.Location };
                Debug.WriteLine(line_Left);

            };

            pictureBox_Left.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    lines_Left.Add(line_Left);

                if (lines_Left.Count == 2)
                {
                    //Double Angle = Math.Atan2(y2 - y1, x2 - x1) - Math.Atan2(y4 - y3, x4 - x3);
                    //Double Angle = Math.Atan2(lines[0].End.Y - lines[0].Start.Y, lines[0].End.X - lines[0].Start.X) - Math.Atan2(lines[1].End.Y - lines[1].Start.Y, lines[1].End.X - lines[1].Start.X);
                    //Double deltaY = Math.Abs((lines_Left[0].End.Y - lines_Left[0].Start.Y)); //could simplify the angle to a positive integer

                    Double A1 = Math.Atan2(lines_Left[0].End.Y - lines_Left[0].Start.Y, lines_Left[0].End.X - lines_Left[0].Start.X);
                    Double A2 = Math.Atan2(lines_Left[1].End.Y - lines_Left[1].Start.Y, lines_Left[1].End.X - lines_Left[1].Start.X);
                    A1 = A1 * 180 / Math.PI;
                    A2 = A2 * 180 / Math.PI;

                    Double angle = A1 - A2;
                    angle = Math.Round(angle, 1);
                    angle = Math.Abs(angle);
                    //Double Angle_deg = Angle * 180 / Math.PI;
                    if (angle > 90)
                    {
                        angle = 180 - angle;
                    }
                    lbl_LeftAngle.Text = "Left Angle = " + angle.ToString();

                    // lines_Left = new List<Line>();//reset the lines = this erased lines before printing - now done on mouse down
                    //line_Left = null;
                }
            };

            // *************************
            // Left Picture Box paint
            // ****************************
            pictureBox_Left.Paint += (s, e) =>
            {
                if (ZoomFlagL == false)
                {
                    if (line_Left != null)
                    {
                        e.Graphics.DrawLine(pen, line_Left.Start.X / ZoomLeft_X, line_Left.Start.Y / ZoomLeft_Y, line_Left.End.X / ZoomLeft_X, line_Left.End.Y / ZoomLeft_Y);
                    }
                    foreach (var l in lines_Left)
                    {
                        e.Graphics.DrawLine(pen, l.Start.X / ZoomLeft_X, l.Start.Y / ZoomLeft_Y, l.End.X / ZoomLeft_X, l.End.Y / ZoomLeft_Y);
                    }
                }
                else
                {
                    if (line_Left != null)
                        e.Graphics.DrawLine(pen, line_Left.Start, line_Left.End);
                    foreach (var l in lines_Left)
                    {
                        e.Graphics.DrawLine(pen, l.Start, l.End);
                        // Debug.WriteLine("lines " + l.Start.X);
                    }
                }


                /* original unscaled version
                if (line_Left != null)
                    e.Graphics.DrawLine(pen, line_Left.Start, line_Left.End);

                foreach (var l in lines_Left)
                    e.Graphics.DrawLine(pen, l.Start, l.End);
            */

            };

            //right box
            pictureBox_Right.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    line_Right.End = e.Location;
                    pictureBox_Right.Invalidate();
                }
            };
            pictureBox_Right.MouseDown += (s, e) =>
            {
                if (lines_Right.Count == 2)
                {
                    lines_Right = new List<Line>(); //reset the lines
                }

                if (e.Button == MouseButtons.Left)
                    line_Right = new Line { Start = e.Location, End = e.Location };
            };

            pictureBox_Right.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    lines_Right.Add(line_Right);

                if (lines_Right.Count == 2)
                {
                    //Double Angle = Math.Atan2(y2 - y1, x2 - x1) - Math.Atan2(y4 - y3, x4 - x3);
                    //Double Angle = Math.Atan2(lines[0].End.Y - lines[0].Start.Y, lines[0].End.X - lines[0].Start.X) - Math.Atan2(lines[1].End.Y - lines[1].Start.Y, lines[1].End.X - lines[1].Start.X);
                    Double A1 = Math.Atan2(lines_Right[0].End.Y - lines_Right[0].Start.Y, lines_Right[0].End.X - lines_Right[0].Start.X);
                    Double A2 = Math.Atan2(lines_Right[1].End.Y - lines_Right[1].Start.Y, lines_Right[1].End.X - lines_Right[1].Start.X);
                    A1 = A1 * 180 / Math.PI;
                    A2 = A2 * 180 / Math.PI;

                    Double angle = A1 - A2;
                    angle = Math.Round(angle, 1);
                    angle = Math.Abs(angle);
                    //Double Angle_deg = Angle * 180 / Math.PI;
                    if (angle > 90)
                    {
                        angle = 180 - angle;
                    }
                    lbl_RightAngle.Text = "Right Angle = " + angle.ToString();

                    // lines_Right = new List<Line>(); //reset the lines 
                    //line_Right = null;
                }

            };
            // ****************
            // PAINT RIGHT PB
            // *****************
            pictureBox_Right.Paint += (s, e) =>
            {
                //pen object at top of form code, set to red and width 5 currently
                if (ZoomFlagR == false)
                {
                     // ZoomFactor = 3.0F;
                    // e.Graphics.TranslateTransform(0.0F, 0.0F);
                    if (line_Right != null)
                    {
                        e.Graphics.DrawLine(pen, line_Right.Start.X / ZoomRight_X, line_Right.Start.Y / ZoomRight_Y, line_Right.End.X / ZoomRight_X,  line_Right.End.Y / ZoomRight_Y);
                    }
                    foreach (var l in lines_Right)
                    {
                        e.Graphics.DrawLine(pen, l.Start.X / ZoomRight_X, l.Start.Y / ZoomRight_Y, l.End.X / ZoomRight_X, l.End.Y / ZoomRight_Y);
                    }
                }
                else
                {
                    if (line_Right != null)
                        e.Graphics.DrawLine(pen, line_Right.Start, line_Right.End);
                    foreach (var l in lines_Right)
                    {
                        e.Graphics.DrawLine(pen, l.Start, l.End);
                        // Debug.WriteLine("lines " + l.Start.X);
                    }
                }
            };

        }
            // *************************************************************      
            // ZOOM LEFT Picture box
            // *****************************
            private void ZoomPBbutton_Click(object sender, EventArgs e)
            {
                
                //if already zoomed - unzoom
                if (ZoomFlagL == true)  //make small
                {
                    pictureBox_Left.Height = m_pb1_height;
                    pictureBox_Left.Width = m_pb1_width;
                    pictureBox_Left.Location = save_lpbl;
                    pictureBox_Left.SendToBack();
                    pictureBox_Right.Invalidate();
                }
                else // make large
                {
                    //pictureBox_Left.SizeMode  times 3
                    pictureBox_Left.Width = 1080;
                    pictureBox_Left.Height = 810;
                    pictureBox_Left.Location = new Point(200, 10);
                    pictureBox_Left.BringToFront(); //puts it on top
                    pictureBox_Right.Invalidate();
            }

                if (ZoomFlagL == true)
                    ZoomFlagL = false;
                else
                    ZoomFlagL = true;
            }

        

        // **********************
        // ZOOM RIGHT picture box
        // **********************
        private void ZoomPBright_Click(object sender, EventArgs e)
        {
            
            //if already zoomed - unzoom
            if (ZoomFlagR == true)  //make small
            {
                pictureBox_Right.Height = m_pb1_height;
                pictureBox_Right.Width = m_pb1_width;
                pictureBox_Right.Location = save_rpbl;
                pictureBox_Right.SendToBack();
                pictureBox_Right.Invalidate();
            }
            else //make large
            {
                //pictureBox_Right.SizeMode - times 3
                pictureBox_Right.Width = 1080;
                pictureBox_Right.Height = 810;
                pictureBox_Right.Location = new Point(200, 10);
                pictureBox_Right.BringToFront(); //puts it on top]
                pictureBox_Right.Invalidate();
            }
            if (ZoomFlagR == true)
            {
                ZoomFlagR = false;
            }
            else
            {
                ZoomFlagR = true;
            }
        }

        private void Zoom_Paint(object sender, PaintEventArgs e)
        {
            Matrix matrix = new Matrix();
            matrix.Translate(50f, 0f);
            // matrix.Rotate(45);

            Rectangle r = new Rectangle(0, 0, 50, 50);
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(r);
            gp.Transform(matrix);
            button1.Region = new Region(gp);
            e.Graphics.DrawPath(Pens.Black, gp);
            gp.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("Escape key pressed");
                // ZoomPBright_Click.PerformClick();            }
            }
        }
        // ****************************************************
        // ZOOM video picture box
        // **********************
        private void buttonZoomVideo_Click(object sender, EventArgs e)
        {
            if (ZoomFlagV == true)
            {
                ZoomFlagV = false;
            }
            else
            {
                ZoomFlagV = true;
            }
            //if already zoomed - then unzoom
            if (ZoomFlagV == true)
            {
                pictureBox1.Width = m_pb1_width;
                pictureBox1.Height = m_pb1_height;
                pictureBox1.Location = m_pb1_loc;
                panel1.Width = 394;
                panel1.Height = 363;
                panel1.Location = new Point(241, 25);

                panel1.SendToBack();
                panel1.Invalidate();
            }
            else
            {
                //panel1.SizeMode - times 2.2
                pictureBox1.Width = 1232;
                pictureBox1.Height = 924;
                pictureBox1.Location = new Point(116, 11);
                panel1.Width = 1200;
                panel1.Height = 900;
                panel1.Location = new Point(115, 10);
                panel1.BringToFront(); //puts it on top
            }

        }


        void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                m_iDesignWidth = this.Width;

                if (m_CameraManager.GetCameraNames() != null)
                {
                    foreach (string temp in m_CameraManager.GetCameraNames())
                    {
                        cbxSources.Items.Add(temp);
                    }

                    cbxSources.SelectedIndexChanged += cbxSources_SelectedIndexChanged;
                    if (cbxSources.Items.Count > 0)
                        cbxSources.SelectedIndex = 0;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnRemoveAllImages_Click(object sender, EventArgs e)
        {
            m_ImageCore.ImageBuffer.RemoveAllImages();

            //matt
            m_LeftImage.ImageBuffer.RemoveAllImages();
            m_RightImage.ImageBuffer.RemoveAllImages();


        }
        private void btnCaptureImage_Click(object sender, EventArgs e)
        {
            if (m_CurrentCamera != null)
            {
                Bitmap tempBmp = m_CurrentCamera.GrabImage();
                m_ImageCore.IO.LoadImage(tempBmp);
            }
        }

        //matt copy of the capture image button, for the left and right image
        private void btnCaptureImageLeft_Click(object sender, EventArgs e)
        {
            if (m_CurrentCamera != null)
            {
                Bitmap tempBmp = m_CurrentCamera.GrabImage();
                m_LeftImage.IO.LoadImage(tempBmp);
                //pictureBox_Left.BackgroundImage = tempBmp;
                pictureBox_Left.Image = tempBmp;

            }
        }
        private void btnCaptureImageRight_Click(object sender, EventArgs e)
        {
            if (m_CurrentCamera != null)
            {
                Bitmap tempBmp = m_CurrentCamera.GrabImage();
                m_RightImage.IO.LoadImage(tempBmp);
                //pictureBox_Right.BackgroundImage = tempBmp;
                pictureBox_Right.Image = tempBmp;

            }
        }


        //stuff in the example code
        private void cbxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CurrentCamera != null)
            {
                m_CurrentCamera.OnFrameCaptrue -= m_CurrentCamera_OnFrameCaptrue;
                m_CurrentCamera.Close();
            }
            if (m_CameraManager != null)
            {
                m_CurrentCamera = m_CameraManager.SelectCamera((short)cbxSources.SelectedIndex);
                m_CurrentCamera.Open();

                m_CurrentCamera.OnFrameCaptrue += m_CurrentCamera_OnFrameCaptrue;
                ResizePictureBox();
            }
            if (m_CurrentCamera != null)
            {
                cbxResolution.Items.Clear();
                foreach (CamResolution camR in m_CurrentCamera.SupportedResolutions)
                {
                    cbxResolution.Items.Add(camR.ToString());
                }
                cbxResolution.SelectedIndexChanged += cbxResolution_SelectedIndexChanged;
                if (cbxResolution.Items.Count > 0)
                    cbxResolution.SelectedIndex = 0;
                ResizePictureBox();
            }

        }
        private void cbxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxResolution.Text != null)
            {
                string[] strWXH = cbxResolution.Text.Split(new char[] { ' ' });
                if (strWXH.Length == 3)
                {
                    try
                    {
                        m_CurrentCamera.CurrentResolution = new CamResolution(int.Parse(strWXH[0]), int.Parse(strWXH[2]));
                    }
                    catch { }
                }
                m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_0);
                ResizePictureBox();
            }
        }
        // this crashes when you click it - unhandled exception line 408
        //
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //           Point tempPoint = new Point(e.X,e.Y);
            //            float tempWidth = pictureBox1.Width;
            //            float tempHeight = pictureBox1.Height;
            //
            //            float imageWidth = m_CurrentCamera.CurrentResolution.Width;
            //            float imageHeight = m_CurrentCamera.CurrentResolution.Height;
            //            float zoomX = imageWidth / tempWidth;
            //            float zoomY = imageHeight / tempHeight;
            //            Point tempFocusPoint = new Point((int)(e.X * imageWidth),(int)(e.Y*imageHeight));
            //            Rectangle tempRect = new Rectangle(tempFocusPoint,new Size(50,50));
            //            m_CurrentCamera.FocusOnArea(tempRect);
        }

        private void ResizePictureBox()
        {
            if (m_CurrentCamera != null)
            {
                CamResolution camResolution = m_CurrentCamera.CurrentResolution;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    {
                        int iVideoWidth = iControlWidth;
                        int iVideoHeight = iControlWidth * camResolution.Height / camResolution.Width;
                        int iContentHeight = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom;
                        if (iVideoHeight < iContentHeight)
                        {
                            pictureBox1.Location = new Point(0, (iContentHeight - iVideoHeight) / 2);
                            pictureBox1.Size = new Size(iVideoWidth, iVideoHeight);
                        }
                        else
                        {
                            pictureBox1.Location = new Point(0, 0);
                            pictureBox1.Size = new Size(pictureBox1.Width, pictureBox1.Height);
                        }
                    }
                }
            }
        }
        private void RotatePictureBox()
        {
            if (m_CurrentCamera != null)
            {
                CamResolution camResolution = m_CurrentCamera.CurrentResolution;
                if (camResolution != null && camResolution.Width > 0 && camResolution.Height > 0)
                {
                    if (camResolution.Width / camResolution.Height > iControlWidth / iControlHeight)
                    {
                        int iVideoHeight = iControlHeight;
                        int iVideoWidth = iControlHeight * camResolution.Height / camResolution.Width;
                        int iContentWidth = panel1.Width - panel1.Margin.Left - panel1.Margin.Right - panel1.Padding.Left - panel1.Padding.Right;
                        pictureBox1.Location = new Point((iContentWidth - iVideoWidth) / 2, 0);
                        pictureBox1.Size = new Size(iVideoWidth, iVideoHeight);
                    }
                    else
                    {
                        int iVideoWidth = iControlWidth;
                        int iVideoHeight = iControlWidth * camResolution.Width / camResolution.Height;
                        int iContentHeight = panel1.Height - panel1.Margin.Top - panel1.Margin.Bottom - panel1.Padding.Top - panel1.Padding.Bottom;
                        pictureBox1.Location = new Point(0, (iContentHeight - iVideoHeight) / 2);
                        pictureBox1.Size = new Size(iVideoWidth, iVideoHeight);
                    }
                }
            }
        }
        private void SetPicture(Image img)
        {
            Bitmap temp = ((Bitmap)(img)).Clone(new Rectangle(0, 0, img.Width, img.Height), img.PixelFormat);
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.BeginInvoke(new MethodInvoker(
                delegate ()
                {
                    pictureBox1.Image = temp;
                }));
            }
            else
            {
                pictureBox1.Image = temp;
            }

        }
        private void picbox90_Click(object sender, EventArgs e)
        {
            m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_90);
            RotatePictureBox();
        }
        private void picbox180_Click(object sender, EventArgs e)
        {
            m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_180);
            ResizePictureBox();
        }
        private void picbox270_Click(object sender, EventArgs e)
        {
            m_CurrentCamera.RotateVideo(Dynamsoft.UVC.Enums.EnumVideoRotateType.Rotate_270);
            RotatePictureBox();
        }
        void m_CurrentCamera_OnFrameCaptrue(Bitmap bitmap)
        {
            SetPicture(bitmap);
        }
        private void picbox90_MouseHover(object sender, EventArgs e)
        {
            picbox90.Image = global::WebcamDemo.Properties.Resources._90_hover;
        }
        private void picbox90_MouseLeave(object sender, EventArgs e)
        {
            picbox90.Image = global::WebcamDemo.Properties.Resources._90_normal;
        }
        private void picbox180_MouseHover(object sender, EventArgs e)
        {
            picbox180.Image = global::WebcamDemo.Properties.Resources._180_hover;
        }
        private void picbox180_MouseLeave(object sender, EventArgs e)
        {
            picbox180.Image = global::WebcamDemo.Properties.Resources._180_normal;
        }
        private void picbox270_MouseHover(object sender, EventArgs e)
        {
            picbox270.Image = global::WebcamDemo.Properties.Resources._270_hover;
        }
        private void picbox270_MouseLeave(object sender, EventArgs e)
        {
            picbox270.Image = global::WebcamDemo.Properties.Resources._270_normal;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btn_ClearLinesLeft_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintImage);
            
            //set to A4 size page
            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;
            pd.DefaultPageSettings.PaperSize = ps;
            pd.DefaultPageSettings.Landscape = true;

            // PrintDialog printdlg = new PrintDialog();
            // PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            // preview the assigned document or you can create a different previewButton for it
            // printPrvDlg.Document = pd;
            // printdlg.Document = pd;
            // printPrvDlg.ShowDialog(); // this shows the preview and then show the Printer Dlg below


            //if (printdlg.ShowDialog() == DialogResult.OK)
            //{
                pd.Print();
            //}

            // pd.Print();
        }

        void PrintImage(object o, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = this.Width ;
            int height = this.Height;
            
            // height = height / 2;
            // int x = this.Top;
            // int y = this.Left;
            
            /* Debug.Write("x,y,width,height");
            Debug.WriteLine(top);
            Debug.WriteLine(left);
            Debug.WriteLine(width);
            Debug.WriteLine(height);
            */

            Rectangle bounds = new Rectangle(x, y, width, height);

            Bitmap img = new Bitmap(width, height);
            // img = GetFormImageWithoutBorders(Form frm);
            Bitmap ResizeImg = new Bitmap(width, height);
            double scale;
            scale = 1.0;
            DrawToBitmap(img, bounds);
            ResizeImg = new Bitmap(img, (int)(width * scale), (int)(height * scale));
            Point p = new Point(0,0);
            e.Graphics.DrawImage(ResizeImg, p);


        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Left_Click(object sender, EventArgs e)
        {
           // this.pictureBox_Left.Size = new Size(1000, 800);
        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }
             
        // Return the form's image without its borders and decorations.
        private Bitmap GetFormImageWithoutBorders(Form frm)
        {
            // Get the form's whole image.
            using (Bitmap whole_form = GetControlImage(frm))
            {
                // See how far the form's upper left corner is
                // from the upper left corner of its client area.
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                // Copy the client area into a new Bitmap.
                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(whole_form, 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                }
                return bm;
            }
        }
        // Return a Bitmap holding an image of the control.
        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm,
                new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_Right_Click(object sender, EventArgs e)
        {

        }
    }
}
