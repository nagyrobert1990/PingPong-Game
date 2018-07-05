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
        Thread ballThread;

        public PingPong()
        {
            InitializeComponent();
            ballThread = new Thread(new ThreadStart(ballMoving));
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
                    ballThread.Start();
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

            string mdr = "";
            string mdl = "";
            string mur = "";
            string mul = "";

            while (true)
            {
                if (mdl.Equals(null) || mdl.Equals("") || mdr.Equals("movingDownLeft") || mul.Equals("movingDownLeft"))
                {
                    mdl = movingDownLeft(true);
                    mul = movingUpLeft(false);
                }

                if (mdl.Equals("movingUpLeft") || mur.Equals("movingUpLeft"))
                {
                    mdl = movingDownLeft(false);
                    mul = movingUpLeft(true);
                }
            } 
        }
        
        private string movingDownLeft(bool startWhile)
        {
            string result = "";
            while(startWhile)
            {
                this.pictureBox3.Location = new Point((this.pictureBox3.Location.X - 5), (this.pictureBox3.Location.Y + 5));
                if (this.pictureBox3.Location.X <= 0)
                {
                    result = "movingDownRight";
                    startWhile = false;
                }
                if (this.pictureBox3.Location.Y + this.pictureBox3.Height >= this.Height)
                {
                    result = "movingUpLeft";
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
                this.pictureBox3.Location = new Point((this.pictureBox3.Location.X - 5), (this.pictureBox3.Location.Y - 5));
                if (this.pictureBox3.Location.X <= 0)
                {
                    result = "movingUpRight";
                    startWhile = false;
                }
                if (this.pictureBox3.Location.Y <= 0)
                {
                    result = "movingDownLeft";
                    startWhile = false;
                }
                Thread.Sleep(50);
            }
            return result;
        }
    }
}