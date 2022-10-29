using System.DirectoryServices;

namespace Homework5b
{
    public partial class Form1 : Form
    {
        public Bitmap bmap;
        public Graphics g;
        Rectangle r;

        bool drag = false;
        bool resizing = false;

        int x_mouse, y_mouse, x_down, y_down;
        int r_width, r_height;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmap);

            r = new Rectangle(20, 20, 400, 300);

            g.DrawRectangle(Pens.Red, r);
            pictureBox1.Image = bmap;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            resizing = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int delta_x = e.X - x_mouse;
            int delta_y = e.Y - y_mouse;

            if (drag) {
                r.X = x_down + delta_x;
                r.Y = y_down + delta_y;
                redraw();
            } else if (resizing)
            {
                r.Width = r_width + delta_x;
                r.Height = r_height + delta_y;
                redraw();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                y_mouse = e.Y;
                x_mouse = e.X;

                y_down = r.Y;
                x_down = r.X;

                r_width = r.Width;
                r_height = r.Height;

                if (e.Button == MouseButtons.Left)
                {
                    drag = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    resizing = true;
                }
            }
        }

        private void redraw()
        {
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Red, r);
            pictureBox1.Image = bmap;
        }
    }
}