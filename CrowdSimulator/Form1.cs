using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CrowdSimulator
{
    public partial class Form1 : Form
    {
        private readonly Bitmap image;
        
        private readonly Crowd crowd;

        public Form1()
        {
            InitializeComponent();

            this.image = new Bitmap(field.Width, field.Height, PixelFormat.Format32bppArgb);

            this.crowd = new Crowd(image);

            this.crowd.Init(200, 5);

            this.ticker.Start();
        }

        private void Update(object Sender, EventArgs E)
        {
            this.crowd.Update();

            this.field.Image = image;
        }
    }
}
