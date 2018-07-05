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
        bool starter;
        public PingPong()
        {
            InitializeComponent();
            starter = false;
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
                case Keys.Space:
                    if (starter == true)
                    {
                        starter = false;
                    }
                    else
                    {
                        starter = true;
                    }
                    ballMoving(starter);
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

        private void ballMoving(bool whileBool)
        {
            string mdl = movingDownLeft(true);
            if (mdl == "movingUpRight")
            {

            }
        }

        private string movingDownRight(bool startWhile)
        {
            string result = "";
            while(startWhile)
            {
                this.pictureBox3.Location = new Point((this.pictureBox3.Location.X - 5), (this.pictureBox3.Location.Y + 5));
                if (this.pictureBox3.Location.X <= 0)
                {
                    result = "movingDownLeft";
                    startWhile = false;
                }
                if (this.pictureBox3.Location.Y + this.pictureBox3.Height >= this.Height)
                {
                    result = "movingUpRight";
                    startWhile = false;
                }
                Thread.Sleep(50);
            }
            return result;
        }

        private string movingUpLeft(bool startWhile)
        {
            string result = "";
            while (startWhile)
            {
                this.pictureBox3.Location = new Point((this.pictureBox3.Location.X - 5), (this.pictureBox3.Location.Y + 5));
                if (this.pictureBox3.Location.X <= 0)
                {
                    result = "movingDownRight";
                    break;
                }
                if (this.pictureBox3.Location.Y + this.pictureBox3.Height >= this.Height)
                {
                    result = "movingUpLeft";
                    break;
                }
                Thread.Sleep(50);
            }
            return result;
        }
    }
}