using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxAXVLC;

namespace sfashfa_ui
{
    public partial class GalleryControl : UserControl
    {
        #region 변수들
        int CtrlWidth;
        int CtrlHeight;
        int PicWidth = 96;
        int PicHeight = 128;
        int XLocation = 25;
        int YLocation = 25;

        private string _Directory_Path;
        private string _Directory_Path2;

        int i = 0;  //사진 개수
        #endregion

        #region 초기화
        public GalleryControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 갤러리 사이즈 재설정
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CtrlHeight = this.Height;
            CtrlWidth = this.Width;
        }
        #endregion

        #region 사진, 영상 경로 설정
        public string Directorypath //사진 경로
        {
            get { return _Directory_Path; }
            set
            {
                _Directory_Path = value;
            }
        }
        public string Directorypath2    //영상 경로
        {
            get { return _Directory_Path2; }
            set
            {
                _Directory_Path2 = value;
                CreateGallery();
            }
        }
        #endregion

        #region 갤러리 사진 픽처박스 생성
        private void DrawPictureBox(string _filename, string _displayname)  //픽처박스 갤러리에 사진개수만큼 만들기
        {
            PictureBox Pic1 = new PictureBox();
            Pic1.Location = new System.Drawing.Point(XLocation, YLocation);
            XLocation = XLocation + 20;
            if (XLocation + 2 * PicWidth + 20 <= CtrlWidth)
            {
                XLocation = XLocation + PicWidth;
                //YLocation = YLocation + PicHeight + 20;
            }
            else
            {
                XLocation = 25;
                YLocation = YLocation + PicHeight + 20;
            }
            Pic1.Name = "PictureBox" + i;
            i += 1;
            Pic1.Size = new System.Drawing.Size(PicWidth, PicHeight);
            Pic1.TabIndex = 0;
            Pic1.TabStop = false;
            Pic1.BorderStyle = BorderStyle.Fixed3D;
            Pic1.MouseEnter += Pic1_MouseEnter;
            Pic1.MouseLeave += Pic1_MouseLeave;
            Pic1.Click += Pic1_Click;
            Pic1.Name = _filename;
            this.Controls.Add(Pic1);
            if (Pic1.Name.Contains("Video"))
                Pic1.Image = OverWriteShape(Image.FromFile(@".\image\Video_start.png"), Image.FromFile(_filename), new Size(Image.FromFile(_filename).Width/2, Image.FromFile(_filename).Height/2));
            else
                Pic1.Image = Image.FromFile(_filename);
            Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }
        #endregion

        #region 이미지 합성
        public Image OverWriteShape(Image Shape, Image background, Size Pos)
        {
            Image img = new Bitmap(background);
            PointF ImagePos = new PointF(Pos.Width - (Shape.Width / Shape.HorizontalResolution * img.HorizontalResolution) / 2, Pos.Height - (Shape.Height / Shape.VerticalResolution * img.VerticalResolution) / 2);


            Graphics formGraphics = Graphics.FromImage(img);


            formGraphics.DrawImage(Shape, ImagePos);

            formGraphics.Save();
            formGraphics.Dispose();
            return img;
        }
        #endregion

        #region 클릭 이벤트 루틴
        private void Pic1_Click(object sender, EventArgs e)     //사진 클릭했을때 확대
        {
            PictureBox Pic1 = (PictureBox)sender;
            if (!Pic1.Name.Contains("Video"))
            {
                PictureBox mainPic = new PictureBox();
                mainPic.Location = new Point(0, 0);
                mainPic.Size = this.Size;
                mainPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                mainPic.Image = Pic1.Image;
                this.Controls.Add(mainPic);
                mainPic.BringToFront();
                mainPic.Click += mainPic_Click;
            }
            else
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayer));
                AxAXVLC.AxVLCPlugin2 vlcPlayer = new AxAXVLC.AxVLCPlugin2();
                this.SuspendLayout();
                vlcPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("vlcPlayer.OcxState")));
                vlcPlayer.Enabled = true;
                vlcPlayer.Name = "vlcPlayer";
                vlcPlayer.TabIndex = 0;


                vlcPlayer.Visible = true;
                vlcPlayer.Location = new Point(0, 0);
                vlcPlayer.Size = this.Size;

                this.Controls.Add(vlcPlayer);
                this.ResumeLayout();


                Uri uri = new Uri(Pic1.Name.Replace("jpg", "mp4"));

                vlcPlayer.playlist.add(uri.AbsoluteUri);



                vlcPlayer.BringToFront();
                vlcPlayer.MediaPlayerEndReached += MediaPlayerEndReached;
                vlcPlayer.playlist.play();
            }
        }
        
        private void MediaPlayerEndReached(object sender, EventArgs e)
        {
                AxAXVLC.AxVLCPlugin2 vlcPlayer = (AxAXVLC.AxVLCPlugin2)sender;
                vlcPlayer.MediaPlayerEndReached -= MediaPlayerEndReached;
                vlcPlayer.Visible = false;
                vlcPlayer.Dispose();
        }
        

        private void mainPic_Click(object sender, EventArgs e)      //확대한 사진 클릭했을때 지우기
        {
            if(sender is PictureBox)
            {
                PictureBox mainPic = (PictureBox)sender;
                mainPic.Click -= mainPic_Click;
                mainPic.Dispose();
            }
            else if(sender is AxAXVLC.AxVLCPlugin2)
            {
                AxAXVLC.AxVLCPlugin2 vlcPlayer = (AxAXVLC.AxVLCPlugin2)sender;
                vlcPlayer.Click -= mainPic_Click;
                vlcPlayer.Visible = false;
            }

        }
        #endregion

        #region 갤러리 동적 생성
        private void CreateGallery()    //갤러리 만들기
        {
            i = 0;
            RemoveControls();
            if (Directorypath != null && Directorypath2 != null)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Directorypath);    //사진 경로
                System.IO.DirectoryInfo vi = new System.IO.DirectoryInfo(Directorypath2);   //영상 썸네일 경로

                System.IO.FileInfo[] diar1 = di.GetFiles("*.jpg");  //사진

                System.IO.FileInfo[] viar1 = vi.GetFiles("*.jpg");  //영상 썸네일

                var diarList = new List<System.IO.FileInfo>();
                diarList.AddRange(diar1);
                diarList.AddRange(viar1);

                System.IO.FileInfo dra = null;
                foreach (System.IO.FileInfo dra_loopVariable in diarList)
                {
                    dra = dra_loopVariable;
                    DrawPictureBox(dra.FullName, dra.Name);
                }
                di = null;
                vi = null;
                diarList.Clear();
                diarList = null;
                diar1 = null;
                viar1 = null;
                XLocation = 25;
                YLocation = 25;
            }
        }
        #endregion

        #region 마우스 무브 이벤트
        private void Pic1_MouseEnter(System.Object sender, System.EventArgs e)      //마우스 올렸을때
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            Pic.BorderStyle = BorderStyle.FixedSingle;
        }
        #endregion

        #region 마우스 리브
        private void Pic1_MouseLeave(System.Object sender, System.EventArgs e)      //원래 상태
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            Pic.BorderStyle = BorderStyle.Fixed3D;
        }
        #endregion

        #region 모든 컨트롤(픽처박스) 지우기
        private void RemoveControls()   //모든 픽처박스 지우기(갤러리 초기화)
        {
            Again:
            foreach (Control ctrl in this.Controls)
            {
                if ((ctrl) is PictureBox)
                {
                    this.Controls.Remove(ctrl);
                }
            }
            if (this.Controls.Count > 0)
            {
                goto Again;
            }
        }
        #endregion
    }
}
