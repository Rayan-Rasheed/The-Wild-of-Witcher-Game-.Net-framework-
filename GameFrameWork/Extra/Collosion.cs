using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Extra
{
    public class Collosion
    {
        private GameObjectType g1;
        private GameObjectType g2;
        private ICollosionAction behaviour;
        public Collosion(GameObjectType g1,GameObjectType g2,ICollosionAction action)
        {
            this.g1 = g1;
            this.g2 = g2;
            this.behaviour = action;
        }
        public GameObjectType G1 { get => g1; set => g1 = value; }
        public GameObjectType G2 { get => g2; set => g2 = value; }
        public ICollosionAction Behviour { get => behaviour; set => behaviour = value; }
    }
}
