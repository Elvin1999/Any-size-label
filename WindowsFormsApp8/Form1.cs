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
        public Label _Label { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        public int Counter { get; set; }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                location2 = e.Location;
                _Width = Math.Abs(location1.X - location2.X);
                _Height = Math.Abs(location1.Y - location2.Y);
                Label label = new Label();
                if (_Width <= 10 && _Height <= 10)
                {
                    label.Size = new Size(10, 10);
                    label.Location = location1;
                    label.Font = new Font("ITALIC", 8);
                }
                else
                {
                    if (location1.Y > location2.Y)
                    {
                        label.Location = location2;
                        label.Size = new Size(_Width, _Height);
                    }
                    else
                    {
                        label.Location = location1;
                        label.Size = new Size(_Width, _Height);
                    }
                    label.DoubleClick += Label_DoubleClick;
                    label.Click += Label_Click;
                    label.Font = new Font("Niagara Solid", _Width / 2);
                }
                label.Text = $"{++Counter}";
                label.AutoSize = false;
                label.ForeColor = Color.White;
                Random r = new Random();
                label.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 150));
                _Label = label;
                this.Controls.Add(label);
            }
        }
        private void Label_Click(object sender, EventArgs e)
        { 
            Label label = new Label();
            label.Size = new Size(80, 40);
            Point point = new Point(0, 0);
            label.Location = point;
            label.BackColor = Color.LightGreen;
            label.Text = $"X {_Label.Location.X} Y {_Label.Location.Y}";
            this.Controls.Add(label);
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
