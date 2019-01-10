using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Point location1 { get; set; }
        public Point location2 { get; set; }
        public int _Width { get; set; }
        public int _Height { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                location2 = e.Location;
                _Width = Math.Abs(location1.X - location2.X);
                _Height = Math.Abs(location1.Y - location2.Y);
                Control label = new Label();
                if (_Width < 10 && _Height < 10)
                {
                    label.Size = new Size(10, 10);
                }
                else
                {
                    label.Size = new Size(_Height, _Width);
                }
                Random r = new Random();
                label.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
                if (location1.Y > location2.Y)
                {
                    label.Location = location2;
                }
                else
                {
                    label.Location = location1;
                }
                label.DoubleClick += Label_DoubleClick;
                this.Controls.Add(label);
            }
        }

        private void Label_DoubleClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.Dispose();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            location1 = e.Location;
        }
    }
}
