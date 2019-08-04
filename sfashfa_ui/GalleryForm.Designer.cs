namespace sfashfa_ui
{
    partial class GalleryForm
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
            this.galleryControl1 = new sfashfa_ui.GalleryControl();
            this.SuspendLayout();
            // 
            // galleryControl1
            // 
            this.galleryControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.galleryControl1.AutoScroll = true;
            this.galleryControl1.BackColor = System.Drawing.Color.White;
            this.galleryControl1.Directorypath = null;
            this.galleryControl1.Directorypath2 = null;
            this.galleryControl1.Location = new System.Drawing.Point(0, 0);
            this.galleryControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.galleryControl1.Name = "galleryControl1";
            this.galleryControl1.Size = new System.Drawing.Size(916, 564);
            this.galleryControl1.TabIndex = 0;
            this.galleryControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.galleryControl1_MouseUp);
            // 
            // GalleryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(914, 562);
            this.ControlBox = false;
            this.Controls.Add(this.galleryControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GalleryForm";
            this.Text = "GalleryForm";
            this.Load += new System.EventHandler(this.GalleryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private GalleryControl galleryControl1;
    }
}