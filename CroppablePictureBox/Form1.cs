using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

// ===============================
// AUTHOR : Peter Nagy # github.com/petusa # peter.x.nagy@gmail.com
// CREATE DATE : 18 March 2018
// PURPOSE : minimal sample app for CroppablePictureBox component
// SPECIAL NOTES : licensed under MIT License
// CREDITS : sample image from pixabay.com
// Change History : 
//  Initial version - 18 March 2018
// ===============================
namespace CroppablePictureBox
{
    public partial class Form1 : Form
    {
        private Image originalImage;

        public Form1()
        {
            InitializeComponent();
            this.originalImage = this.croppablePictureBox1.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.croppablePictureBox1.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap croppedImage = this.croppablePictureBox1.GetCroppedBitmap();
            if (croppedImage == null) return;
            
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.croppablePictureBox1.Image = croppedImage;
                this.croppablePictureBox1.Refresh();
                dialog.AddExtension = true;
                croppedImage.Save(dialog.FileName + ".jpeg", ImageFormat.Jpeg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.croppablePictureBox1.Image.Dispose();
            this.croppablePictureBox1.Image = this.originalImage;
        }

    }
}