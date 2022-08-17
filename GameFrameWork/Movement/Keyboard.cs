using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using EZInput;

namespace GameFrameWork.Movement
{
    
    public class Keyboard:IMovement
    {

        private PictureBox pbPlayer;
        private int playForward = 1;
        private int playBack = 1;
        private int jumpspeed =1;
        private int jumprange = 60;
        private int speed;
        List<Image> leftCollection;
        List<Image> rightCollection;
        public Keyboard(int speed, List<Image> leftCollection,List<Image> rightCollection )
        {
            this.leftCollection = leftCollection;
            this.rightCollection = rightCollection;
            this.speed = speed;
            this.leftCollection = leftCollection;
            this.rightCollection = rightCollection;
        }

        public PictureBox move(PictureBox pb)
        {
            pbPlayer = pb;
            if (true)
            {
                if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    if (pb.Left > 5)
                    {
                        pb.Left -= speed;
                        runLeft();
                    }

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (pb.Left < 1400)
                    {
                        pb.Left += speed;
                        runRight();
                    }
                    
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.Space))
                {
                    if(pb.Top>200)
                    for(int i = jumpspeed; i < jumprange; i +=jumpspeed)
                    {

                        pb.Top -= jumpspeed;
                    }
                    

                }
               
            }
            return pb;
        }
        private void runLeft()
        {
            playForward = 1;
            
            for(int i = playBack; i <= playBack; i++)
            {
                pbPlayer.Image = leftCollection[i];
                if (playBack == 5)
                {
                    pbPlayer.Image = leftCollection[i];
                     playBack = 1;
                }

            }
            playBack++;
           
        }
        private void runRight()
        {
            playBack = 1;

            for (int i = playForward; i <= playForward; i++)
            {
                pbPlayer.Image = rightCollection[i];
                if (playForward == 5)
                {
                    pbPlayer.Image = rightCollection[i];
                    playForward = 1;
                }

            }
            playForward++;
        }
        
    }
}
