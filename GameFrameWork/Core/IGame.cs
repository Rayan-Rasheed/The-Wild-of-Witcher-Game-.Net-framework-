using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFrameWork.Core
{
    public interface IGame
    {
        void RaisePlayerDieEvent(PictureBox pb);
        void RaisePlayerWallEvent(PictureBox pb);
        void RaisePlayerGroundEvent(PictureBox pb);
        void RaisePlayerEnemyFireCollosion(PictureBox pb);
        void RaisePlayerCoinCollosion(GameObject ob);
        void RaisePlayerFireCollosion(GameObject ob);
        void RaisePlayerEnergyCollosion(GameObject ob);
        void RaisePlayerKeyCollosion(GameObject ob);
        void RaisePlayerDoorCollosion(GameObject ob);


    }
}
