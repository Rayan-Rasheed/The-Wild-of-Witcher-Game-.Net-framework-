using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameFrameWork.Movement
{
    public class Horizontol:IMovement
    {
        private int speed;
        private Point Boundary;
        private string direction;
        public Horizontol (int speed,Point Boundary,string direction)
        {
            this.speed = speed;
            this.Boundary = Boundary;
            this.direction = direction;
        }

        public PictureBox move(PictureBox pb)
        {
            if (pb.Left <= Boundary.X)
            {
                direction = "right";
            }
            else if (pb.Left+pb.Width >= Boundary.Y)
            {
                direction = "left";
            }
            if (direction == "right")
            {
                pb.Left += speed;
                
            }
            else if (direction == "left")
            {
                pb.Left -= speed;
            }
            return pb;

        }
    }
}
