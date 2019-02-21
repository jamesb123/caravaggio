namespace WebcamDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCaptureImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRemoveAllImages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSources = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picbox90 = new System.Windows.Forms.PictureBox();
            this.picbox180 = new System.Windows.Forms.PictureBox();
            this.picbox270 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxResolution = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCaptureImageRight = new System.Windows.Forms.Button();
            this.btnCaptureImageLeft = new System.Windows.Forms.Button();
            this.lbl_LeftAngle = new System.Windows.Forms.Label();
            this.lbl_RightAngle = new System.Windows.Forms.Label();
            this.pictureBox_Left = new System.Windows.Forms.PictureBox();
            this.pictureBox_Right = new System.Windows.Forms.PictureBox();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.textBox_Doctor = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.textLineWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.ZoomPBbutton = new System.Windows.Forms.Button();
            this.ZoomPBright = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.buttonZoomVideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox180)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox270)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Right)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCaptureImage
            // 
            this.btnCaptureImage.Location = new System.Drawing.Point(12, 140);
            this.btnCaptureImage.Name = "btnCaptureImage";
            this.btnCaptureImage.Size = new System.Drawing.Size(130, 23);
            this.btnCaptureImage.TabIndex = 1;
            this.btnCaptureImage.Text = "Capture Image";
            this.btnCaptureImage.UseVisualStyleBackColor = true;
            this.btnCaptureImage.Visible = false;
            this.btnCaptureImage.Click += new System.EventHandler(this.btnCaptureImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(475, 356);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // btnRemoveAllImages
            // 
            this.btnRemoveAllImages.Location = new System.Drawing.Point(12, 169);
            this.btnRemoveAllImages.Name = "btnRemoveAllImages";
            this.btnRemoveAllImages.Size = new System.Drawing.Size(130, 23);
            this.btnRemoveAllImages.TabIndex = 4;
            this.btnRemoveAllImages.Text = "Remove All Images";
            this.btnRemoveAllImages.UseVisualStyleBackColor = true;
            this.btnRemoveAllImages.Click += new System.EventHandler(this.btnRemoveAllImages_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Webcam Source:";
            // 
            // cbxSources
            // 
            this.cbxSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSources.FormattingEnabled = true;
            this.cbxSources.Location = new System.Drawing.Point(15, 38);
            this.cbxSources.Name = "cbxSources";
            this.cbxSources.Size = new System.Drawing.Size(131, 21);
            this.cbxSources.TabIndex = 13;
            this.cbxSources.SelectedIndexChanged += new System.EventHandler(this.cbxSources_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1225, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 372);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // picbox90
            // 
            this.picbox90.Image = global::WebcamDemo.Properties.Resources._90_normal;
            this.picbox90.Location = new System.Drawing.Point(15, 113);
            this.picbox90.Name = "picbox90";
            this.picbox90.Size = new System.Drawing.Size(24, 21);
            this.picbox90.TabIndex = 24;
            this.picbox90.TabStop = false;
            this.picbox90.Visible = false;
            this.picbox90.Click += new System.EventHandler(this.picbox90_Click);
            this.picbox90.MouseLeave += new System.EventHandler(this.picbox90_MouseLeave);
            this.picbox90.MouseHover += new System.EventHandler(this.picbox90_MouseHover);
            // 
            // picbox180
            // 
            this.picbox180.Image = global::WebcamDemo.Properties.Resources._180_normal;
            this.picbox180.Location = new System.Drawing.Point(62, 113);
            this.picbox180.Name = "picbox180";
            this.picbox180.Size = new System.Drawing.Size(24, 21);
            this.picbox180.TabIndex = 25;
            this.picbox180.TabStop = false;
            this.picbox180.Visible = false;
            this.picbox180.Click += new System.EventHandler(this.picbox180_Click);
            this.picbox180.MouseLeave += new System.EventHandler(this.picbox180_MouseLeave);
            this.picbox180.MouseHover += new System.EventHandler(this.picbox180_MouseHover);
            // 
            // picbox270
            // 
            this.picbox270.Image = global::WebcamDemo.Properties.Resources._270_normal;
            this.picbox270.Location = new System.Drawing.Point(95, 113);
            this.picbox270.Name = "picbox270";
            this.picbox270.Size = new System.Drawing.Size(24, 21);
            this.picbox270.TabIndex = 26;
            this.picbox270.TabStop = false;
            this.picbox270.Visible = false;
            this.picbox270.Click += new System.EventHandler(this.picbox270_Click);
            this.picbox270.MouseLeave += new System.EventHandler(this.picbox270_MouseLeave);
            this.picbox270.MouseHover += new System.EventHandler(this.picbox270_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Resolution:";
            // 
            // cbxResolution
            // 
            this.cbxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Location = new System.Drawing.Point(15, 73);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(131, 21);
            this.cbxResolution.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Rotate:";
            this.label4.Visible = false;
            // 
            // btnCaptureImageRight
            // 
            this.btnCaptureImageRight.Location = new System.Drawing.Point(851, 496);
            this.btnCaptureImageRight.Name = "btnCaptureImageRight";
            this.btnCaptureImageRight.Size = new System.Drawing.Size(102, 23);
            this.btnCaptureImageRight.TabIndex = 35;
            this.btnCaptureImageRight.Text = "Capture Right";
            this.btnCaptureImageRight.UseVisualStyleBackColor = true;
            this.btnCaptureImageRight.Click += new System.EventHandler(this.btnCaptureImageRight_Click);
            // 
            // btnCaptureImageLeft
            // 
            this.btnCaptureImageLeft.Location = new System.Drawing.Point(383, 378);
            this.btnCaptureImageLeft.Name = "btnCaptureImageLeft";
            this.btnCaptureImageLeft.Size = new System.Drawing.Size(102, 23);
            this.btnCaptureImageLeft.TabIndex = 36;
            this.btnCaptureImageLeft.Text = "Capture Left";
            this.btnCaptureImageLeft.UseVisualStyleBackColor = true;
            this.btnCaptureImageLeft.Click += new System.EventHandler(this.btnCaptureImageLeft_Click);
            // 
            // lbl_LeftAngle
            // 
            this.lbl_LeftAngle.AutoSize = true;
            this.lbl_LeftAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LeftAngle.Location = new System.Drawing.Point(17, 394);
            this.lbl_LeftAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LeftAngle.Name = "lbl_LeftAngle";
            this.lbl_LeftAngle.Size = new System.Drawing.Size(97, 20);
            this.lbl_LeftAngle.TabIndex = 39;
            this.lbl_LeftAngle.Text = "Left_Angle";
            // 
            // lbl_RightAngle
            // 
            this.lbl_RightAngle.AutoSize = true;
            this.lbl_RightAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RightAngle.Location = new System.Drawing.Point(14, 424);
            this.lbl_RightAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_RightAngle.Name = "lbl_RightAngle";
            this.lbl_RightAngle.Size = new System.Drawing.Size(123, 20);
            this.lbl_RightAngle.TabIndex = 40;
            this.lbl_RightAngle.Text = "Right Angle    ";
            // 
            // pictureBox_Left
            // 
            this.pictureBox_Left.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Left.Location = new System.Drawing.Point(204, 17);
            this.pictureBox_Left.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Left.Name = "pictureBox_Left";
            this.pictureBox_Left.Size = new System.Drawing.Size(474, 356);
            this.pictureBox_Left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Left.TabIndex = 41;
            this.pictureBox_Left.TabStop = false;
            this.pictureBox_Left.Click += new System.EventHandler(this.pictureBox_Left_Click);
            // 
            // pictureBox_Right
            // 
            this.pictureBox_Right.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Right.Location = new System.Drawing.Point(694, 17);
            this.pictureBox_Right.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Right.Name = "pictureBox_Right";
            this.pictureBox_Right.Size = new System.Drawing.Size(475, 356);
            this.pictureBox_Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Right.TabIndex = 42;
            this.pictureBox_Right.TabStop = false;
            this.pictureBox_Right.Click += new System.EventHandler(this.pictureBox_Right_Click);
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Location = new System.Drawing.Point(266, 498);
            this.textBox_FirstName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.Size = new System.Drawing.Size(211, 20);
            this.textBox_FirstName.TabIndex = 43;
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.Location = new System.Drawing.Point(266, 528);
            this.textBox_LastName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.Size = new System.Drawing.Size(212, 20);
            this.textBox_LastName.TabIndex = 44;
            // 
            // textBox_Doctor
            // 
            this.textBox_Doctor.Location = new System.Drawing.Point(266, 557);
            this.textBox_Doctor.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Doctor.Name = "textBox_Doctor";
            this.textBox_Doctor.Size = new System.Drawing.Size(212, 20);
            this.textBox_Doctor.TabIndex = 45;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(18, 353);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 19);
            this.btnPrint.TabIndex = 46;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(171, 496);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "First Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(171, 526);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Last Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(200, 557);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 49;
            this.label9.Text = "Doctor";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // textLineWidth
            // 
            this.textLineWidth.Location = new System.Drawing.Point(18, 255);
            this.textLineWidth.Name = "textLineWidth";
            this.textLineWidth.Size = new System.Drawing.Size(48, 20);
            this.textLineWidth.TabIndex = 51;
            this.textLineWidth.Text = "1.75";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Line Width 1.1 to 3.1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 22);
            this.button1.TabIndex = 53;
            this.button1.Text = "Set Pen Properties";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "Pick Pen Colour";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // ZoomPBbutton
            // 
            this.ZoomPBbutton.Location = new System.Drawing.Point(15, 478);
            this.ZoomPBbutton.Name = "ZoomPBbutton";
            this.ZoomPBbutton.Size = new System.Drawing.Size(102, 23);
            this.ZoomPBbutton.TabIndex = 55;
            this.ZoomPBbutton.Text = "Zoom Left";
            this.ZoomPBbutton.UseVisualStyleBackColor = true;
            this.ZoomPBbutton.Click += new System.EventHandler(this.ZoomPBbutton_Click);
            // 
            // ZoomPBright
            // 
            this.ZoomPBright.Location = new System.Drawing.Point(12, 520);
            this.ZoomPBright.Name = "ZoomPBright";
            this.ZoomPBright.Size = new System.Drawing.Size(102, 23);
            this.ZoomPBright.TabIndex = 56;
            this.ZoomPBright.Text = "Zoom  Right";
            this.ZoomPBright.UseVisualStyleBackColor = true;
            this.ZoomPBright.Click += new System.EventHandler(this.ZoomPBright_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(4, 568);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 57;
            this.button3.Text = "EXIT PROGRAM";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(266, 585);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(219, 20);
            this.textBoxDate.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(200, 582);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 60;
            this.label6.Text = "Date";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // buttonZoomVideo
            // 
            this.buttonZoomVideo.Location = new System.Drawing.Point(15, 201);
            this.buttonZoomVideo.Name = "buttonZoomVideo";
            this.buttonZoomVideo.Size = new System.Drawing.Size(103, 21);
            this.buttonZoomVideo.TabIndex = 61;
            this.buttonZoomVideo.Text = "Zoom Video";
            this.buttonZoomVideo.UseVisualStyleBackColor = true;
            this.buttonZoomVideo.Click += new System.EventHandler(this.buttonZoomVideo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1727, 614);
            this.Controls.Add(this.buttonZoomVideo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ZoomPBright);
            this.Controls.Add(this.ZoomPBbutton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textLineWidth);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.textBox_Doctor);
            this.Controls.Add(this.textBox_LastName);
            this.Controls.Add(this.textBox_FirstName);
            this.Controls.Add(this.pictureBox_Right);
            this.Controls.Add(this.pictureBox_Left);
            this.Controls.Add(this.lbl_RightAngle);
            this.Controls.Add(this.lbl_LeftAngle);
            this.Controls.Add(this.btnCaptureImageLeft);
            this.Controls.Add(this.btnCaptureImageRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxResolution);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picbox270);
            this.Controls.Add(this.picbox180);
            this.Controls.Add(this.picbox90);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxSources);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveAllImages);
            this.Controls.Add(this.btnCaptureImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox180)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox270)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Right)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCaptureImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRemoveAllImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSources;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picbox90;
        private System.Windows.Forms.PictureBox picbox180;
        private System.Windows.Forms.PictureBox picbox270;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxResolution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCaptureImageRight;
        private System.Windows.Forms.Button btnCaptureImageLeft;
        private System.Windows.Forms.Label lbl_LeftAngle;
        private System.Windows.Forms.Label lbl_RightAngle;
        private System.Windows.Forms.PictureBox pictureBox_Left;
        private System.Windows.Forms.PictureBox pictureBox_Right;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.TextBox textBox_Doctor;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox textLineWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ZoomPBbutton;
        private System.Windows.Forms.Button ZoomPBright;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button buttonZoomVideo;
    }
}

