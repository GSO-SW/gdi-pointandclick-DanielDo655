using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel
            Brush dOG = new SolidBrush(Color.DarkOliveGreen);
            Brush bL = new SolidBrush(Color.Blue);
            Brush gY = new SolidBrush(Color.GreenYellow);
            Brush hp = new SolidBrush(Color.HotPink);

            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(dOG, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;
            bool überlapppung = false;

            Rectangle r = new Rectangle(mausposition.X-20, mausposition.Y-20, 40, 40);

            rectangles.Add(r);// Kurze Variante: rectangles.Add( new Rectangle(...)  );
            
            for (int i = 0;i < rectangles.Count;i++)
            {
                if (rectangles[i].Contains(mausposition))
                {
                    überlapppung = true;
                    break;
                }
            }

            
            Refresh();
        }


        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }

    }
}