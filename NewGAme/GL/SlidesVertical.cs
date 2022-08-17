using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NewGAme.GL
{
    class SlidesVertical
    {
        PictureBox pbSlide;
        string direction;
        int speed;
        int upperBoundary;
        int lowerBoundary;
        public  SlidesVertical (PictureBox pbSlide, string direction, int speed, int UpperBoundary, int LowerBoundary)
        {
            this.PbSlide = pbSlide;
            this.Direction = direction;
            this.Speed = speed;
            this.upperBoundary = UpperBoundary;
            this.lowerBoundary = LowerBoundary;
              
        }

        public PictureBox PbSlide { get => pbSlide; set => pbSlide = value; }
        public string Direction { get => direction; set => direction = value; }
        public int Speed { get => speed; set => speed = value; }
        public int UpperBoundary { get => upperBoundary; set => upperBoundary = value; }
        public int LowerBoundary { get => lowerBoundary; set => lowerBoundary = value; }
    }
}
