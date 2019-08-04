using OpenCvSharp;
using sfashfa_ui.customclass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sfashfa_ui
{
    public partial class mainform : Form
    {
        #region 변수들
        const int frameWidth = 640;    // 화면 가로
        const int frameHeight = 480;    // 화면 세로
        VideoCapture capture;
        Mat frame = new Mat();

        /*플래그*/ 
        bool isStart = false;   //동영상
        bool pallete_on = false;    //색깔
        bool gallery_on = false;    //사진첩
        bool isLoad = true;

        int btn_on_off = 2;

        VideoWriter videowriter;
        DirectoryInfo pictureDir = new DirectoryInfo("Picture");
        DirectoryInfo videoDir = new DirectoryInfo("Video");
        int videoWriteMode = 0;     //1:녹화중
        int pictureWriteMode = 0;
        int time = 5;
        
        sfashfa_ui.GalleryForm galleryForm = null;
        #endregion

        #region 초기화
        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            this.Width = constant.SCREEN_WIDTH;
            this.Height = constant.SCREEN_HEIGHT;
            this.Top = constant.SCREEN_LOCATION_Y;
            this.Left = constant.SCREEN_LOCATION_X;

            panel_color.Visible = false;
            panel_color.Enabled = false;

            panel_gallery.Visible = false;
            panel_gallery.Enabled = false;

            if(btn_on_off == 2)
            {
                btn_off();
            }
            opencv_init();
            this.CountDown.Location = new System.Drawing.Point((this.panel_opencv.Width) - (this.CountDown.Width / 2) - 100, (this.panel_opencv.Height / 2) - (this.CountDown.Height / 2));
        }

        private void opencv_init()
        {
            opencv_viewer.Width = constant.OPENCV_WIDTH;
            opencv_viewer.Height = constant.OPENCV_HEIGHT;
            opencv_viewer.Top = constant.OPENCV_LOCATION_Y + 260;
            opencv_viewer.Left = constant.OPENCV_LOCATION_X;

            capture = VideoCapture.FromCamera(CaptureDevice.DShow, 0);
            capture.FrameWidth = frameWidth;
            capture.FrameHeight = frameHeight;
            capture.Open(0);
        }
        #endregion

        #region 스타트(5초간 로고 띄우기)
        private DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                ThisMoment = DateTime.Now;
            }
            panel_start.Visible = false;
            panel_start.Enabled = false;


            panel_opencv.Visible = true;
            panel_opencv.Enabled = true;
            return DateTime.Now;
        }

        private void sfashfa_start()
        {
            isLoad = !isLoad;

            panel_opencv.Visible = false;
            panel_opencv.Enabled = false;

            panel_start.Visible = true;
            panel_start.Enabled = true;

            Delay(1000 * 5);
        }
        #endregion

        #region 갤러리 클릭 이벤트
        private void icon_gallery_Click(object sender, EventArgs e)
        {
            gallery_on = !gallery_on;
            if (gallery_on)
            {
                panel_opencv.Visible = false;
                panel_opencv.Enabled = false;
                icon_photographic.Enabled = false;
                icon_photographic.Visible = false;
                icon_capture.Enabled = false;
                icon_capture.Visible = false;
                
                panel_gallery.Visible = true;
                panel_gallery.Enabled = true;

                icon_gallery.Image = Image.FromFile(Application.StartupPath + @"\image\home.png");

                int location = icon_gallery.Location.X - icon_photographic.Location.X;
                for (int f = 0; f < location; f += 1)
                {
                    icon_gallery.Location = new System.Drawing.Point(icon_gallery.Location.X - 1, icon_gallery.Location.Y);
                }
                galleryForm = new sfashfa_ui.GalleryForm();
                galleryForm.FormBorderStyle = FormBorderStyle.None;
                galleryForm.StartPosition = FormStartPosition.Manual;
                galleryForm.Location = new System.Drawing.Point(0, 0);
                galleryForm.Size = new System.Drawing.Size(1080, 1840);
                galleryForm.TopLevel = false;
                galleryForm.Dock = System.Windows.Forms.DockStyle.Fill;
                panel_gallery.Controls.Add(galleryForm);
                galleryForm.Show();
            }
            else
            {
                if(galleryForm != null)
                {
                    galleryForm.Close();
                    galleryForm = null;
                }
                panel_opencv.Enabled = true;
                panel_opencv.Visible = true;
                icon_photographic.Enabled = true;
                icon_photographic.Visible = true;
                icon_capture.Enabled = true;
                icon_capture.Visible = true;

                panel_gallery.Visible = false;
                panel_gallery.Enabled = false;

                icon_gallery.Image = Image.FromFile(Application.StartupPath + @"\image\004-pictures.png");

                int location = 818;
                for (int i = icon_gallery.Location.X; i < location; i++)
                {
                    icon_gallery.Location = new System.Drawing.Point(i, icon_gallery.Location.Y);
                }
            }
        }
        #endregion

        #region 팔레트 클릭 이벤트
        private void icon_pallete_MouseClick(object sender , MouseEventArgs e)
        {
            btn_on_off++;
            pallete_on = !pallete_on;
            if (pallete_on)
            {
                panel_color.Enabled = true;
                panel_color.Visible = true;
            }
            else
            {
                panel_color.Visible = false;
                panel_color.Enabled = false;
            }
            if(btn_on_off % 2 == 0)
            {
                colormode = 0;
                btn_off();
            }
            else
            {
                btn_on();
            }
        }

        private void btn_off()
        {
            btn_blue.Visible = false;
            btn_black.Visible = false;
            btn_gray.Visible = false;
            btn_orange.Visible = false;
            btn_red.Visible = false;
            btn_yellow.Visible = false;
        }

        private void btn_on()
        {
            btn_blue.Visible = true;
            btn_black.Visible = true;
            btn_gray.Visible = true;
            btn_orange.Visible = true;
            btn_red.Visible = true;
            btn_yellow.Visible = true;
        }
        #endregion

        #region 녹화 버튼 이벤트
        private void icon_photographic_Click(object sender, EventArgs e)
        {
            if (!videoDir.Exists)
                videoDir.Create();
            if(pictureWriteMode == 1)
            {
                MessageBox.Show("촬영중에는 녹화를 할 수 없습니다.");
                return;
            }
            if (!isStart)
            {
                icon_photographic.Image = Image.FromFile(Application.StartupPath + @"\image\256xphotograping.png");
                isStart = !isStart;

                if (frame != null)
                {
                    if (videoWriteMode != 1)
                    {
                        MessageBox.Show("녹화 시작");

                        String filename = videoDir.ToString() + "\\Video_" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".mp4";
                        String sumnail = filename.Replace("mp4", "jpg");
                        frame.SaveImage(sumnail);
                        videowriter = new VideoWriter(filename, "MP4V", 8, frame.Size());
                        videoWriteMode = 1;
                        rec_timer.Enabled = true;

                    }
                }
                else
                {
                    MessageBox.Show("카메라가 연결되어있지 않습니다.");
                }
            }
            else
            {
                icon_photographic.Image = Image.FromFile(Application.StartupPath + @"\image\256xphotographic.png");
                isStart = !isStart;
                if (videoWriteMode == 1)
                {
                    MessageBox.Show("녹화 종료");
                    rec_timer.Enabled = false;
                    videoWriteMode = 0;
                    videowriter.Dispose();
                }
            }
            //icon_photographic.Visible = false;
            //icon_stop.Visible = true;
        }
        #endregion

        #region 촬영 버튼 이벤트
        private void icon_capture_Click(object sender, EventArgs e)
        {
            if (!pictureDir.Exists)
                pictureDir.Create();
            if (isStart)
            {
                MessageBox.Show("녹화중엔 촬영할 수 없습니다.");
                return;
            }
            if (frame != null)
            {
                pictureWriteMode = 1;
                pic_timer.Enabled = true;
            }
            else
            {
                MessageBox.Show("카메라가 연결되어있지 않습니다.");
            }
        }
        #endregion

        #region 타이머
        private void frame_tick_Tick(object sender, EventArgs e)
        {
            if (isLoad)
            {
                sfashfa_start();
            }
            if (capture != null && capture.IsOpened())
            {
                capture.Read(frame);
                frame = Opencv_lib.rotateImage(frame, 90);
                frame = Opencv_lib.findupperbody(frame, colormode);

                opencv_viewer.ImageIpl = frame;
            }
        }

        private void rec_timer_Tick(object sender, EventArgs e)
        {
            if (videoWriteMode == 1)
            {
                videowriter.Write(frame);
            }
        }

        private void pic_timer_Tick(object sender, EventArgs e)
        {
            if (pictureWriteMode == 1 && time == 0)
            {
                pictureWriteMode = 0;
                String filename = pictureDir.ToString() + "\\Picture_" + DateTime.Now.ToString("yyyy-MM-dd_hhmmssfff") + ".jpg";
                frame.SaveImage(filename);
                SoundPlayer sound = new SoundPlayer(@"sound\shuter.WAV");
                sound.Play();
                time = 5;
                CountDown.Enabled = false;
                CountDown.Visible = false;
                pic_timer.Enabled = false;
            }
            else
            {
                opencv_viewer.Controls.Add(CountDown);
                CountDown.BringToFront();
                this.Invoke(new Action(delegate ()
                {
                    pic_timer.Enabled = true;
                    CountDown.Enabled = true;
                    CountDown.Visible = true;
                    CountDown.Text = ""+ time;
                } ));
                
                time -= 1;
            }
        }
        #endregion

        #region 팔레트 색 버튼 이벤트
        int colormode = 0;
        private void btn_red_Click(object sender, EventArgs e)
        {
            colormode = 1;
        }

        private void btn_black_Click(object sender, EventArgs e)
        {
            colormode = 6;
        }

        private void btn_blue_Click(object sender, EventArgs e)
        {
            colormode = 2;
        }

        private void btn_gray_Click(object sender, EventArgs e)
        {
            colormode = 3;
        }

        private void btn_orange_Click(object sender, EventArgs e)
        {
            colormode = 4;
        }

        private void btn_yellow_Click(object sender, EventArgs e)
        {
            colormode = 5;
        }
        #endregion
    }
}
