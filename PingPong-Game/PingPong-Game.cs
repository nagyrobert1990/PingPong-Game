using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong_Game
{
    public partial class PingPong : Form
    {
        public PingPong()
        {
            InitializeComponent();
        }

        private void PingPong_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.S:
                    leftMoveDown();
                    break;
                case Keys.W:
                    leftMoveUp();
                    break;
                case Keys.Down:
                    rightMoveDown();
                    break;
                case Keys.Up:
                    rightMoveUp();
                    break;
            }
        }

        private void leftMoveUp()
        {
            if (this.pictureBox1.Location.Y > 0)
            {
                this.pictureBox1.Location = new Point(this.pictureBox1.Location.X, (this.pictureBox1.Location.Y - 20));
            }
        }

        private void leftMoveDown()
        {
            if (this.pictureBox1.Bottom <= this.ClientSize.Height)
            {
                this.pictureBox1.Location = new Point(this.pictureBox1.Location.X, (this.pictureBox1.Location.Y + 20));
            }
        }

        private void rightMoveUp()
        {
            if (this.pictureBox2.Location.Y > 0)
            {
                this.pictureBox2.Location = new Point(this.pictureBox2.Location.X, (this.pictureBox2.Location.Y - 20));
            }
        }

        private void rightMoveDown()
        {
            if (this.pictureBox2.Bottom <= this.ClientSize.Height)
            {
                this.pictureBox2.Location = new Point(this.pictureBox2.Location.X, (this.pictureBox2.Location.Y + 20));
            }
        }

        private void ballMoving()
        {
            
        }
    }
}