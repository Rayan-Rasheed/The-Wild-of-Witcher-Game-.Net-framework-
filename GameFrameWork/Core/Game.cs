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
    public class Game: FreeFall,IGame
    {
        List<GameObject> gameObjects;
        private List<Collosion> collosions;
        List<GameObject> playerFireList;
        List<GameObject> FireFalling;
        List<GameObject> dragonList;
        List<GameObject> dragonFireList;
        int dragonFireCount = 0;
        private Point majorBoundary;
        private Point fallingBoundary;
        public event EventHandler OnGameObjectAdded;
        public event EventHandler OnPlayerDie;
        public event EventHandler OnPlayerWallCollosion;
        public event EventHandler OnPlayerGroundCollosion;
        public event EventHandler OnPlayerFire;
        public event EventHandler OnPlayerRemoveFire;
        public event EventHandler OnDragonFire;
        public event EventHandler OnPlayerEnemyFireCollosion;
        public event EventHandler OnPlayerCoinCollosion;
        public event EventHandler OnScoreCounter;
        public event EventHandler OnPlayerFireKiCollosion;
        public event EventHandler OnProgressBar;
        public event EventHandler OnProgressBarRemove;
        public event EventHandler OnPlayerEnergyCollosion;
        public event EventHandler OnPlayerKeyCollosion;
        public event EventHandler OnPlayerDoorCollosion;
        public List<Collosion> Collosions { get => collosions; set => collosions = value; }
        public Point MajorBoundary { get => majorBoundary; set => majorBoundary = value; }
        public Point FallingBoundary { get => fallingBoundary; set => fallingBoundary = value; }


        public Game()
        {
            playerFireList = new List<GameObject>();
            gameObjects = new List<GameObject>();
            collosions = new List<Collosion>();
            FireFalling = new List<GameObject>();
            dragonList = new List<GameObject>();
            dragonFireList = new List<GameObject>();
        }
        public void RaisePlayerDieEvent(PictureBox pb)
        {
            OnPlayerDie?.Invoke(pb, EventArgs.Empty);
        }
        public void RaisePlayerEnemyFireCollosion(PictureBox pb)

        {
            
            OnPlayerEnemyFireCollosion?.Invoke(pb, EventArgs.Empty);
        }
        public void RaisePlayerEnergyCollosion(GameObject ob)
        {
            gameObjects.Remove(ob);
            OnPlayerEnergyCollosion?.Invoke(ob.PbGame, EventArgs.Empty);
        }
        public void RaisePlayerKeyCollosion(GameObject ob)
        {
            gameObjects.Remove(ob);
            OnPlayerKeyCollosion?.Invoke(ob.PbGame, EventArgs.Empty);
        }
        public void RaisePlayerDoorCollosion(GameObject ob)
        {
            OnPlayerDoorCollosion?.Invoke(ob.PbGame, EventArgs.Empty);
        }
        public void RaisePlayerWallEvent(PictureBox pb)
        {
            OnPlayerWallCollosion?.Invoke(pb, EventArgs.Empty);

        }
        public void RaisePlayerFireCollosion(GameObject go)
        {
            go.pbar.Value = go.health-88;
            if (go.pbar.Value<15)
            {
                dragonList.Remove(go);
                OnPlayerFireKiCollosion?.Invoke(go.PbGame, EventArgs.Empty);
                OnProgressBarRemove?.Invoke(go.pbar, EventArgs.Empty);
            }

        }public void RaisePlayerCoinCollosion(GameObject go)
        {
            gameObjects.Remove(go);
            OnPlayerCoinCollosion?.Invoke(go.PbGame, EventArgs.Empty);
        }


        public void RaisePlayerGroundEvent(PictureBox pb)
        {
            OnPlayerGroundCollosion?.Invoke(pb, EventArgs.Empty);
        }
        public void keyPressed(Keys keyCode)
        {
            foreach (var go in gameObjects)
            {
                
                if (keyCode == Keys.F)
                {
                    foreach (GameObject Go in gameObjects)
                    {
                        if (Go.Otype == GameObjectType.player)
                        {
                            OnPlayerFire?.Invoke(Go.PbGame, EventArgs.Empty);
                        }
                    }
                }
            }
        }
        public void addGameObject(Image img,GameObjectType Otype,int height,int width,int left,int top,IMovement movement)
        {
            GameObject ob = new GameObject(img, Otype,height, width, top, left, movement);
            if (ob.Otype == GameObjectType.player)
            {
                gameObjects.Add(ob);
            }
            if (ob.Otype == GameObjectType.playerFire)
            {
                playerFireList.Add(ob);
            }
            if (ob.Otype == GameObjectType.FireFalling)
            {
                FireFalling.Add(ob);
            }
            if (ob.Otype == GameObjectType.dragon|| ob.Otype == GameObjectType.wich)
            {
                dragonList.Add(ob);
                if (ob.Otype == GameObjectType.wich)
                {
                    ob.pbar = new ProgressBar();
                    ob.health = 100;
                    ob.pbar.Value = 100;
                    ob.pbar.Height = 10;
                    ob.pbar.Width = 40;
                   ob. pbar.Top = ob.PbGame.Top - ob.pbar.Height;
                    ob.pbar.Left = ob.PbGame.Left+3;
                    OnProgressBar?.Invoke(ob.pbar, EventArgs.Empty);

                }
            }
            if (ob.Otype == GameObjectType.enemyFire)
            {
                dragonFireList.Add(ob);
            }
            OnGameObjectAdded?.Invoke(ob.PbGame, EventArgs.Empty);
        }
        public void addGameObject(PictureBox pbGame, GameObjectType Otype, IMovement movement)
        {
            GameObject ob = new GameObject(pbGame, Otype,movement);
            
            gameObjects.Add(ob);
        }
        public void UpdateGame()
        {
            detectCollosion();
            detectPlayerEnemyFireCollosion();
            detectDragonEnemyFireCollosion();
            detectDragonPlayerCollosion();
            playerFireWichCollosion();
            foreach (var go in gameObjects)
            {
                go.moveGameObject();
                if (go.Otype == GameObjectType.player)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        detectGroundCollosion();
                        go.PbGame = move(go.PbGame);
                       
                    }

                }
                
            }
            foreach (var far in playerFireList)
            {

                far.moveGameObject();
                OnScoreCounter?.Invoke(null, EventArgs.Empty);

            }
            foreach (var fire in FireFalling)
            {
                detectCollosion();
                fire.moveGameObject();
            }
            foreach(var dragon in dragonList)
            {
                dragon.moveGameObject();
                if (dragonFireCount > 150)
                {
                    OnDragonFire?.Invoke(dragon.PbGame, EventArgs.Empty);
                    dragonFireCount = 0;
                }
                if (dragon.Otype == GameObjectType.wich)
                {
                   
                    dragon.pbar.Top = dragon.PbGame.Top - dragon.pbar.Height;
                    dragon.pbar.Left = dragon.PbGame.Left + 3;

                }

            }
            foreach(var dFire in dragonFireList)
            {
                dFire.moveGameObject();

            }
            dragonFireCount++;
            removePlayerFire();
            removeFallingFire();
            removedragon();
            removeDragonFire();

        }
        public void removePlayerFire()
        {
            for(int i=0;i< playerFireList.Count; i++)
            {
                if (playerFireList[i].PbGame.Location.X >= MajorBoundary.X)
                {
                    OnPlayerRemoveFire?.Invoke(playerFireList[i].PbGame, EventArgs.Empty);
                    playerFireList.RemoveAt(i);
                }
            }
        }
        public void removeFallingFire()
        {
            for (int i = 0; i < FireFalling.Count; i++)
            {
                if (FireFalling[i].PbGame.Top+FireFalling[i].PbGame.Height  >= fallingBoundary.Y)
                {
                    OnPlayerRemoveFire?.Invoke(FireFalling[i].PbGame, EventArgs.Empty);
                    FireFalling.RemoveAt(i);
                }
            }
        }
        public void removedragon()
        {
            for (int i = 0; i < dragonList.Count; i++)
            {
                if (dragonList[i].Otype == GameObjectType.wich)
                {
                    if (dragonList[i].PbGame.Left <= 1000)
                    {
                        OnPlayerRemoveFire?.Invoke(dragonList[i].PbGame, EventArgs.Empty);
                        OnProgressBarRemove?.Invoke(dragonList[i].pbar, EventArgs.Empty);
                        dragonList.RemoveAt(i);
                    }

                }
                else
                {
                    if (dragonList[i].PbGame.Left <= 0)
                    {
                        OnPlayerRemoveFire?.Invoke(dragonList[i].PbGame, EventArgs.Empty);
                        dragonList.RemoveAt(i);
                    }
                }
            }
        }
        public void removeDragonFire()
        {
            for (int i = 0; i < dragonFireList.Count; i++)
            {
                if (dragonFireList[i].PbGame.Top >=492)
                {
                    OnPlayerRemoveFire?.Invoke(dragonFireList[i].PbGame, EventArgs.Empty);
                    dragonFireList.RemoveAt(i);
                }
            }
        }
        public void detectCollosion()
        {
            for(int x = 0; x < gameObjects.Count; x++)
            {
                for(int y = 0; y < gameObjects.Count; y++)
                {
                    if (gameObjects[x].PbGame.Bounds.IntersectsWith (gameObjects[y].PbGame.Bounds))
                    {
                        foreach (Collosion c in Collosions)
                        {
                            if(gameObjects[x].Otype==c.G1 && gameObjects[y].Otype == c.G2)
                            {
                                c.Behviour.performAction(this,c.G2,gameObjects[x], gameObjects[y]);
                            }
                        }
                    }
                }
            }
        }
        public void detectPlayerEnemyFireCollosion()
        {
            for (int x = 0; x < gameObjects.Count; x++)
            {
                for (int y = 0; y < FireFalling.Count; y++)
                {
                    if (gameObjects[x].PbGame.Bounds.IntersectsWith(FireFalling[y].PbGame.Bounds))
                    {
                        foreach (Collosion c in Collosions)
                        {
                            if (gameObjects[x].Otype == c.G1 && FireFalling[y].Otype == c.G2)
                            {
                                c.Behviour.performAction(this, c.G2, gameObjects[x], FireFalling[y]);
                            }
                        }
                    }
                }
            }
        }
        public void detectDragonEnemyFireCollosion()
        {
            for (int x = 0; x < gameObjects.Count; x++)
            {
                for (int y = 0; y < dragonFireList.Count; y++)
                {
                    if (gameObjects[x].PbGame.Bounds.IntersectsWith(dragonFireList[y].PbGame.Bounds))
                    {
                        foreach (Collosion c in Collosions)
                        {
                            if (gameObjects[x].Otype == c.G1 && dragonFireList[y].Otype == c.G2)
                            {
                                c.Behviour.performAction(this, c.G2, gameObjects[x], dragonFireList[y]);
                            }
                        }
                    }
                }
            }
        }
        public void detectDragonPlayerCollosion()
        {
            for (int x = 0; x < gameObjects.Count; x++)
            {
                for (int y = 0; y < dragonList.Count; y++)
                {
                    if (gameObjects[x].PbGame.Bounds.IntersectsWith(dragonList[y].PbGame.Bounds))
                    {
                        foreach (Collosion c in Collosions)
                        {
                            if (gameObjects[x].Otype == c.G1 && dragonList[y].Otype == c.G2)
                            {
                                c.Behviour.performAction(this, c.G2, gameObjects[x], dragonList[y]);
                            }
                        }
                    }
                }
            }
        }
        public void detectGroundCollosion()
        {
            for (int x = 0; x < gameObjects.Count; x++)
            {
                if (gameObjects[x].Otype == GameObjectType.player || gameObjects[x].Otype == GameObjectType.ground)
                {
                    for (int y = 0; y < gameObjects.Count; y++)
                    {
                        if (gameObjects[y].Otype == GameObjectType.player || gameObjects[y].Otype == GameObjectType.ground) {

                            if (gameObjects[x].PbGame.Bounds.IntersectsWith(gameObjects[y].PbGame.Bounds))
                            {
                                foreach (Collosion c in Collosions)
                                {
                                    if (gameObjects[x].Otype == c.G1 && gameObjects[y].Otype == c.G2)
                                    {
                                        c.Behviour.performAction(this, c.G2, gameObjects[x], gameObjects[y]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void playerFireWichCollosion()
        {
            for (int x = 0; x < playerFireList.Count; x++)
            {
                  for (int y = 0; y < dragonList.Count; y++)
                    {
                        
                        if (playerFireList[x].PbGame.Bounds.IntersectsWith(dragonList[y].PbGame.Bounds))
                        {

                            foreach (Collosion c in Collosions)
                                {
                                    if (playerFireList[x].Otype == c.G1 && dragonList[y].Otype == c.G2)
                                    {
                                        c.Behviour.performAction(this, c.G2, playerFireList[x], dragonList[y]);
                                    }
                                }
                            
                        }
                    }
                }
            
        }

    }
}
