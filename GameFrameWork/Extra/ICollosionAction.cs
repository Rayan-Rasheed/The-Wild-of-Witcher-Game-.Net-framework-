using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Core;

namespace GameFrameWork.Extra
{
    public interface ICollosionAction
    {
        void performAction(IGame game,GameObjectType type, GameObject g1, GameObject g2);
    }
}
