using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameFrameWork.Movement
{
    public class Firing:IMovement
    {
        private int speed;
        private Point Boundary;
        private string direction;
        private List<Image> explosionList;
        int shuffle = 1;


        public Firing(int speed, Point Boundary, string direction)
        {
            this.speed = speed;
            this.Boundary = Boundary;
            this.direction = direction;
        }

        public List<Image> ExplosionList { get => explosionList; set => explosionList = value; }

        public PictureBox move(PictureBox pb)
        {
           
            if (direction == "right")
            {
                pb.Left += speed;
            }
            else if (direction == "left")
            {
                pb.Left -= speed;
            }
            else if (direction == "up")
            {
                pb.Top -= speed;
            }
            else if (direction == "down")
            {
                pb.Top += speed;
            }
            else if(direction== "diagonally")
            {
                shuffle++;
                pb.Top += 7;
                pb.Left -= 7;
               for(int i = shuffle; i <= shuffle; i++)
                {
                    pb.Image = ExplosionList[i];
                    if (i == 6)
                    {
                        shuffle = 0;
                    }

                }



            }
            

            return pb;
        }
    }
}
