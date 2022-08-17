using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameFrameWork.Movement
{
    public class Vertical:IMovement
    {
        private int speed;
        private Point Boundary;
        private string direction;
        public Vertical(int speed, Point Boundary, string direction)
        {
            this.speed = speed;
            this.Boundary = Boundary;
            this.direction = direction;
        }

        public PictureBox move(PictureBox pb)
        {

            if (pb.Top <= 200)
            {
                direction = "down";
            }
            else if (pb.Top + pb.Height >= Boundary.Y)
            {
                direction = "up";
            }
            if (direction == "down")
            {
                pb.Top += speed;

            }
            else if (direction == "up")
            {
                pb.Top -= speed;
            }
            return pb;

        }
    }
}
