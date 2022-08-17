using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Core;

namespace GameFrameWork.Extra
{
    public class PlayerFireCollosion:ICollosionAction
    {
        public void performAction(IGame game, GameObjectType type, GameObject source1, GameObject source2)
        {
            GameObject playerFire;
            GameObject other;
            if (source1.Otype == GameObjectType.playerFire)
            {
                playerFire = source1;
                other = source2;


            }
            else
            {
                playerFire = source2;
                other = source1;
            }
            
             game.RaisePlayerFireCollosion(other);
            




        }
    }
}
