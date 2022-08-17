using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameFrameWork.Movement
{
    public class FreeFall:IMovement

    {
        public PictureBox move(PictureBox pb)
        {

                pb.Top += 1;
            
            return pb;

        }
        
    }
}
