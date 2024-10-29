using System;
using System.Windows.Forms;

namespace Test_Movement_Game_2D
{
    public partial class Form1 : Form
    {
        bool moveRight, moveLeft;

        bool isJumping = false;
        int jumpSpeed;
        int gravity = 2;
        int speed = 12;
        int groundLevel = 530;
        int gravityAcceleration = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void moveTimerEvent(object sender, EventArgs e)
        {
            if (moveLeft && pictureBox1.Left > 0)
            {
                pictureBox1.Left -= speed;
            }
            if (moveRight && pictureBox1.Right < 902)
            {
                pictureBox1.Left += speed;
            }

            if (!isJumping && pictureBox1.Top + pictureBox1.Height < groundLevel)
            {
                pictureBox1.Top += gravity;
                gravity += gravityAcceleration; 
            }
            else if (isJumping)
            {
                pictureBox1.Top -= jumpSpeed;
                jumpSpeed -= gravityAcceleration;

                if (jumpSpeed <= 0)
                {
                    isJumping = false;
                }
            }
            else
            {
                gravity = 2;
                if (pictureBox1.Top + pictureBox1.Height > groundLevel)
                {
                    pictureBox1.Top = groundLevel - pictureBox1.Height;
                }
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            if (e.KeyCode == Keys.Space && !isJumping && pictureBox1.Top + pictureBox1.Height >= groundLevel)
            {
                isJumping = true;
                jumpSpeed = 15;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }
    }
}
