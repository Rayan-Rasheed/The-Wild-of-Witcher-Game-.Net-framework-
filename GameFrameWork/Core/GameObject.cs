using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameFrameWork.Movement;
using GameFrameWork.Extra;

namespace GameFrameWork.Core
{
    public class GameObject:Health
    {
        
        private PictureBox pbGame;
        private IMovement movement;
        private GameObjectType otype;
        public GameObject(Image img,GameObjectType Otype,int height,int width,int top,int left,IMovement movement)
        {
            PbGame = new PictureBox();
            PbGame.Image = img;
            PbGame.Height = height;
            PbGame.Width = width;
            PbGame.Left = left;
            PbGame.Top = top;
            pbGame.SizeMode = PictureBoxSizeMode.StretchImage;
            PbGame.BackColor = Color.Transparent;
            this.Movement = movement;
            pbGame.BringToFront();
            this.Otype = Otype;
            

        }
        public GameObject(PictureBox pbGame,GameObjectType Otype,IMovement movement)
        {
            this.pbGame = pbGame;
            this.Otype = Otype;
            this.movement=movement;
        }

        public IMovement Movement { get => movement; set => movement = value; }
        internal PictureBox PbGame { get => pbGame; set => pbGame = value; }
        public GameObjectType Otype { get => otype; set => otype = value; }
        public void moveGameObject()
        {
            
            PbGame = Movement.move(PbGame);
            pbGame.BringToFront();
        }
        
    }
}
