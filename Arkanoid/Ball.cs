using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Ball : Panel
    {
        public Ball()
        {
            this.BackColor = Color.AliceBlue;
            this.Size = new Size(50, 50);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle newRectangle = this.ClientRectangle;
            newRectangle.Inflate(-1, -1);
            e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);
            newRectangle.Inflate(1, 1);
            buttonPath.AddEllipse(newRectangle);
            this.Region = new System.Drawing.Region(buttonPath);
            base.OnPaint(e);
        }
    }
}