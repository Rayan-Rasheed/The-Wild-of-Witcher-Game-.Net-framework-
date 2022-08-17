using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Core;


namespace GameFrameWork.Extra
{
    public class PlayerCollosion:ICollosionAction
    {
        public void performAction(IGame game,GameObjectType type,GameObject source1, GameObject source2)
        {
            GameObject player;
            GameObject other;
            if (source1.Otype == GameObjectType.player)
            {
                player = source1;
                other = source2;


            }
            else
            {
                player = source2;
                other = source1;
            }
            game.RaisePlayerDieEvent(player.PbGame);
            if (GameObjectType.walls == type)
            {

                game.RaisePlayerWallEvent(player.PbGame);
            }
            if (GameObjectType.ground == type|| GameObjectType.slapMoving ==type)
            {
                game.RaisePlayerGroundEvent(player.PbGame);
            }
            if (GameObjectType.FireFalling == type|| GameObjectType.enemyFire == type|| GameObjectType.dragon == type|| GameObjectType.wich == type)
            {
                player.PbGame.Top = 490;
                player.PbGame.Left = 21;

                game.RaisePlayerEnemyFireCollosion(player.PbGame);
            }
            if (GameObjectType.coin == type)
            {
                
                game.RaisePlayerCoinCollosion(other);
            }
            if (GameObjectType.energy == type)
            {

                game.RaisePlayerEnergyCollosion(other);
            }
            if (GameObjectType.key == type)
            {

                game.RaisePlayerKeyCollosion(other);
            }
            if (GameObjectType.door == type)
            {

                game.RaisePlayerDoorCollosion(other);
            }




        }
    }
}
