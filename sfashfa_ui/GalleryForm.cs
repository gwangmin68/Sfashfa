using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sfashfa_ui
{
    public partial class GalleryForm : Form
    {
        #region 사진, 영상 경로 설정 및 초기화
        public GalleryForm()
        {
            InitializeComponent();
        }
        private void GalleryForm_Load(object sender, EventArgs e)
        {
            galleryControl1.Directorypath = @".\Picture";
            galleryControl1.Directorypath2 = @".\Video";
        }
        #endregion

        #region 갤러리 마우스 이벤트(재배열)
        private void galleryControl1_MouseUp(object sender, MouseEventArgs e)   //마우스 단추를 놓을때 발생하는 이벤트
        {
            galleryControl1.Directorypath = @".\Picture";
            galleryControl1.Directorypath2 = @".\Video";
        }
        #endregion
    }
}
