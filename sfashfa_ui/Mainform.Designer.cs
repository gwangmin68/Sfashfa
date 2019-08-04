using System.Drawing;
using System.Windows.Forms;
using sfashfa_ui.customclass;

namespace sfashfa_ui
{
    partial class mainform
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.opencv_viewer = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.icon_pallete = new System.Windows.Forms.PictureBox();
            this.frame_tick = new System.Windows.Forms.Timer(this.components);
            this.Menubar = new System.Windows.Forms.Panel();
            this.CountDown = new System.Windows.Forms.Label();
            this.icon_gallery = new System.Windows.Forms.PictureBox();
            this.icon_capture = new System.Windows.Forms.PictureBox();
            this.icon_photographic = new System.Windows.Forms.PictureBox();
            this.panel_color = new System.Windows.Forms.Panel();
            this.btn_black = new System.Windows.Forms.PictureBox();
            this.btn_gray = new System.Windows.Forms.PictureBox();
            this.btn_orange = new System.Windows.Forms.PictureBox();
            this.btn_red = new System.Windows.Forms.PictureBox();
            this.btn_blue = new System.Windows.Forms.PictureBox();
            this.btn_yellow = new System.Windows.Forms.PictureBox();
            this.logobar = new System.Windows.Forms.Panel();
            this.icon_logo = new System.Windows.Forms.PictureBox();
            this.panel_opencv = new System.Windows.Forms.Panel();
            this.panel_gallery = new System.Windows.Forms.Panel();
            this.panel_start = new System.Windows.Forms.Panel();
            this.icon_startlogo = new System.Windows.Forms.PictureBox();
            this.rec_timer = new System.Windows.Forms.Timer(this.components);
            this.pic_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.opencv_viewer)).BeginInit();
            this.opencv_viewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_pallete)).BeginInit();
            this.Menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_gallery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_capture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_photographic)).BeginInit();
            this.panel_color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_black)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_gray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_orange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_yellow)).BeginInit();
            this.logobar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_logo)).BeginInit();
            this.panel_opencv.SuspendLayout();
            this.panel_start.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_startlogo)).BeginInit();
            this.SuspendLayout();
            // 
            // opencv_viewer
            // 
            this.opencv_viewer.BackColor = System.Drawing.Color.White;
            this.opencv_viewer.Controls.Add(this.icon_pallete);
            this.opencv_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opencv_viewer.Location = new System.Drawing.Point(0, 0);
            this.opencv_viewer.Name = "opencv_viewer";
            this.opencv_viewer.Size = new System.Drawing.Size(1080, 319);
            this.opencv_viewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.opencv_viewer.TabIndex = 0;
            this.opencv_viewer.TabStop = false;
            // 
            // icon_pallete
            // 
            this.icon_pallete.BackColor = System.Drawing.Color.Transparent;
            this.icon_pallete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.icon_pallete.Cursor = System.Windows.Forms.Cursors.Default;
            this.icon_pallete.Image = ((System.Drawing.Image)(resources.GetObject("icon_pallete.Image")));
            this.icon_pallete.Location = new System.Drawing.Point(1060, 1720);
            this.icon_pallete.Name = "icon_pallete";
            this.icon_pallete.Size = new System.Drawing.Size(170, 170);
            this.icon_pallete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_pallete.TabIndex = 2;
            this.icon_pallete.TabStop = false;
            this.icon_pallete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.icon_pallete_MouseClick);
            // 
            // frame_tick
            // 
            this.frame_tick.Enabled = true;
            this.frame_tick.Interval = 50;
            this.frame_tick.Tick += new System.EventHandler(this.frame_tick_Tick);
            // 
            // Menubar
            // 
            this.Menubar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Menubar.BackColor = System.Drawing.Color.LightBlue;
            this.Menubar.Controls.Add(this.CountDown);
            this.Menubar.Controls.Add(this.icon_gallery);
            this.Menubar.Controls.Add(this.icon_capture);
            this.Menubar.Controls.Add(this.icon_photographic);
            this.Menubar.Location = new System.Drawing.Point(0, 0);
            this.Menubar.Name = "Menubar";
            this.Menubar.Size = new System.Drawing.Size(1080, 300);
            this.Menubar.TabIndex = 1;
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.BackColor = System.Drawing.Color.Transparent;
            this.CountDown.Enabled = false;
            this.CountDown.Font = new System.Drawing.Font("굴림", 300F);
            this.CountDown.ForeColor = System.Drawing.Color.White;
            this.CountDown.Location = new System.Drawing.Point(0, 0);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(1597, 500);
            this.CountDown.TabIndex = 0;
            this.CountDown.Text = "label1";
            this.CountDown.Visible = false;
            // 
            // icon_gallery
            // 
            this.icon_gallery.BackColor = System.Drawing.Color.Transparent;
            this.icon_gallery.Image = ((System.Drawing.Image)(resources.GetObject("icon_gallery.Image")));
            this.icon_gallery.Location = new System.Drawing.Point(916, 57);
            this.icon_gallery.Name = "icon_gallery";
            this.icon_gallery.Size = new System.Drawing.Size(192, 192);
            this.icon_gallery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_gallery.TabIndex = 2;
            this.icon_gallery.TabStop = false;
            this.icon_gallery.Click += new System.EventHandler(this.icon_gallery_Click);
            // 
            // icon_capture
            // 
            this.icon_capture.BackColor = System.Drawing.Color.Transparent;
            this.icon_capture.Image = ((System.Drawing.Image)(resources.GetObject("icon_capture.Image")));
            this.icon_capture.Location = new System.Drawing.Point(524, 57);
            this.icon_capture.Name = "icon_capture";
            this.icon_capture.Size = new System.Drawing.Size(192, 192);
            this.icon_capture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_capture.TabIndex = 1;
            this.icon_capture.TabStop = false;
            this.icon_capture.Click += new System.EventHandler(this.icon_capture_Click);
            // 
            // icon_photographic
            // 
            this.icon_photographic.BackColor = System.Drawing.Color.Transparent;
            this.icon_photographic.Image = ((System.Drawing.Image)(resources.GetObject("icon_photographic.Image")));
            this.icon_photographic.Location = new System.Drawing.Point(98, 57);
            this.icon_photographic.Name = "icon_photographic";
            this.icon_photographic.Size = new System.Drawing.Size(192, 192);
            this.icon_photographic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_photographic.TabIndex = 0;
            this.icon_photographic.TabStop = false;
            this.icon_photographic.Click += new System.EventHandler(this.icon_photographic_Click);
            // 
            // panel_color
            // 
            this.panel_color.Controls.Add(this.btn_black);
            this.panel_color.Controls.Add(this.btn_gray);
            this.panel_color.Controls.Add(this.btn_orange);
            this.panel_color.Controls.Add(this.btn_red);
            this.panel_color.Controls.Add(this.btn_blue);
            this.panel_color.Controls.Add(this.btn_yellow);
            this.panel_color.Location = new System.Drawing.Point(10, 10);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(320, 216);
            this.panel_color.TabIndex = 10;
            // 
            // btn_black
            // 
            this.btn_black.BackColor = System.Drawing.Color.Black;
            this.btn_black.Location = new System.Drawing.Point(225, 119);
            this.btn_black.Name = "btn_black";
            this.btn_black.Size = new System.Drawing.Size(80, 80);
            this.btn_black.TabIndex = 5;
            this.btn_black.TabStop = false;
            this.btn_black.Click += new System.EventHandler(this.btn_black_Click);
            // 
            // btn_gray
            // 
            this.btn_gray.BackColor = System.Drawing.Color.Gray;
            this.btn_gray.Location = new System.Drawing.Point(225, 33);
            this.btn_gray.Name = "btn_gray";
            this.btn_gray.Size = new System.Drawing.Size(80, 80);
            this.btn_gray.TabIndex = 7;
            this.btn_gray.TabStop = false;
            this.btn_gray.Click += new System.EventHandler(this.btn_gray_Click);
            // 
            // btn_orange
            // 
            this.btn_orange.BackColor = System.Drawing.Color.Orange;
            this.btn_orange.Location = new System.Drawing.Point(124, 119);
            this.btn_orange.Name = "btn_orange";
            this.btn_orange.Size = new System.Drawing.Size(80, 80);
            this.btn_orange.TabIndex = 8;
            this.btn_orange.TabStop = false;
            this.btn_orange.Click += new System.EventHandler(this.btn_orange_Click);
            // 
            // btn_red
            // 
            this.btn_red.BackColor = System.Drawing.Color.Red;
            this.btn_red.Location = new System.Drawing.Point(21, 33);
            this.btn_red.Name = "btn_red";
            this.btn_red.Size = new System.Drawing.Size(80, 80);
            this.btn_red.TabIndex = 3;
            this.btn_red.TabStop = false;
            this.btn_red.Click += new System.EventHandler(this.btn_red_Click);
            // 
            // btn_blue
            // 
            this.btn_blue.BackColor = System.Drawing.Color.Blue;
            this.btn_blue.Location = new System.Drawing.Point(21, 119);
            this.btn_blue.Name = "btn_blue";
            this.btn_blue.Size = new System.Drawing.Size(80, 80);
            this.btn_blue.TabIndex = 4;
            this.btn_blue.TabStop = false;
            this.btn_blue.Click += new System.EventHandler(this.btn_blue_Click);
            // 
            // btn_yellow
            // 
            this.btn_yellow.BackColor = System.Drawing.Color.Yellow;
            this.btn_yellow.Location = new System.Drawing.Point(124, 33);
            this.btn_yellow.Name = "btn_yellow";
            this.btn_yellow.Size = new System.Drawing.Size(80, 80);
            this.btn_yellow.TabIndex = 6;
            this.btn_yellow.TabStop = false;
            this.btn_yellow.Click += new System.EventHandler(this.btn_yellow_Click);
            // 
            // logobar
            // 
            this.logobar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logobar.BackColor = System.Drawing.Color.LightBlue;
            this.logobar.Controls.Add(this.icon_logo);
            this.logobar.Controls.Add(this.panel_color);
            this.logobar.Location = new System.Drawing.Point(0, 2140);
            this.logobar.Name = "logobar";
            this.logobar.Size = new System.Drawing.Size(1080, 260);
            this.logobar.TabIndex = 2;
            // 
            // icon_logo
            // 
            this.icon_logo.BackColor = System.Drawing.Color.Transparent;
            this.icon_logo.Image = ((System.Drawing.Image)(resources.GetObject("icon_logo.Image")));
            this.icon_logo.Location = new System.Drawing.Point(500, 5);
            this.icon_logo.Name = "icon_logo";
            this.icon_logo.Size = new System.Drawing.Size(280, 280);
            this.icon_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_logo.TabIndex = 9;
            this.icon_logo.TabStop = false;
            // 
            // panel_opencv
            // 
            this.panel_opencv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_opencv.AutoSize = true;
            this.panel_opencv.Controls.Add(this.opencv_viewer);
            this.panel_opencv.Location = new System.Drawing.Point(0, 110);
            this.panel_opencv.Name = "panel_opencv";
            this.panel_opencv.Size = new System.Drawing.Size(1080, 319);
            this.panel_opencv.TabIndex = 3;
            // 
            // panel_gallery
            // 
            this.panel_gallery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_gallery.BackColor = System.Drawing.Color.White;
            this.panel_gallery.Location = new System.Drawing.Point(0, 300);
            this.panel_gallery.Name = "panel_gallery";
            this.panel_gallery.Size = new System.Drawing.Size(1080, 1840);
            this.panel_gallery.TabIndex = 4;
            // 
            // panel_start
            // 
            this.panel_start.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_start.BackColor = System.Drawing.Color.LightBlue;
            this.panel_start.Controls.Add(this.icon_startlogo);
            this.panel_start.Location = new System.Drawing.Point(0, 0);
            this.panel_start.Name = "panel_start";
            this.panel_start.Size = new System.Drawing.Size(1080, 247);
            this.panel_start.TabIndex = 5;
            // 
            // icon_startlogo
            // 
            this.icon_startlogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icon_startlogo.BackColor = System.Drawing.Color.Transparent;
            this.icon_startlogo.Image = ((System.Drawing.Image)(resources.GetObject("icon_startlogo.Image")));
            this.icon_startlogo.InitialImage = null;
            this.icon_startlogo.Location = new System.Drawing.Point(100, 90);
            this.icon_startlogo.Name = "icon_startlogo";
            this.icon_startlogo.Size = new System.Drawing.Size(800, 600);
            this.icon_startlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_startlogo.TabIndex = 6;
            this.icon_startlogo.TabStop = false;
            // 
            // rec_timer
            // 
            this.rec_timer.Interval = 50;
            this.rec_timer.Tick += new System.EventHandler(this.rec_timer_Tick);
            // 
            // pic_timer
            // 
            this.pic_timer.Interval = 1000;
            this.pic_timer.Tick += new System.EventHandler(this.pic_timer_Tick);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1080, 500);
            this.Controls.Add(this.panel_start);
            this.Controls.Add(this.Menubar);
            this.Controls.Add(this.logobar);
            this.Controls.Add(this.panel_opencv);
            this.Controls.Add(this.panel_gallery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainform";
            this.Text = "mirrordisplay";
            this.Load += new System.EventHandler(this.mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.opencv_viewer)).EndInit();
            this.opencv_viewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_pallete)).EndInit();
            this.Menubar.ResumeLayout(false);
            this.Menubar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_gallery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_capture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_photographic)).EndInit();
            this.panel_color.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_black)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_gray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_orange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_yellow)).EndInit();
            this.logobar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_logo)).EndInit();
            this.panel_opencv.ResumeLayout(false);
            this.panel_start.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_startlogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl opencv_viewer;
        private System.Windows.Forms.Timer frame_tick;
        private System.Windows.Forms.Panel Menubar;
        private System.Windows.Forms.PictureBox icon_photographic;
        private System.Windows.Forms.PictureBox icon_gallery;
        private System.Windows.Forms.PictureBox icon_capture;
        public System.Windows.Forms.PictureBox icon_pallete;
        private System.Windows.Forms.Panel logobar;
        private System.Windows.Forms.PictureBox btn_red;
        private System.Windows.Forms.PictureBox btn_blue;
        private System.Windows.Forms.PictureBox btn_black;
        private System.Windows.Forms.PictureBox btn_yellow;
        private System.Windows.Forms.PictureBox btn_gray;
        private System.Windows.Forms.PictureBox btn_orange;
        private System.Windows.Forms.PictureBox icon_logo;
        private Panel panel_color;
        private Panel panel_opencv;
        private Panel panel_gallery;
        private Panel panel_start;
        private PictureBox icon_startlogo;
        private Timer rec_timer;
        private Timer pic_timer;
        private Label CountDown;
    }
}