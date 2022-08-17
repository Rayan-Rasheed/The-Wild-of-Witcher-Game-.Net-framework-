using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameFrameWork.Core;
using GameFrameWork.Movement;
using GameFrameWork.Extra;
using NewGAme.Properties;

namespace NewGAme
{
    public partial class Level2 : Form
    {
        Game game;
        int playerSpeed;
        int firingSpeed;
        List<Image> leftCollection;
        List<Image> rightCollection;
        List<Image> explosionList;
        int fallingEnemyCount;
        int wichCounter = 0;
        bool doorState = false;
        bool keyState = false;
        int lives = 3;
        List<PictureBox> dragonFireList = new List<PictureBox>();
        Random rand = new Random();
        int Score = 0;
        int coin = 0;
        int health = 90;
        int generateDragon = 0;
        int healthDeductOnFire;

        public Level2()
        {
            InitializeComponent();
        }

        private void Level2_Load(object sender, EventArgs e)
        {
            game = new Game();
            game.OnGameObjectAdded += OnGameObjectAdded_game;
            game.OnPlayerDie += OnPlayerDie_game;
            game.OnPlayerWallCollosion += OnPlayerWallCollosion_game;
            game.OnPlayerGroundCollosion += OnPlayerGroundCollosion_game;
            game.OnPlayerFire += OnPlayerFire_game;
            game.OnPlayerRemoveFire += OnPlayerRemoveFire_game;
            game.OnDragonFire += OnDragonFire_game;
            game.OnPlayerEnemyFireCollosion += OnPlayerEnemyFireCollosion_game;
            game.OnPlayerCoinCollosion += OnPlayerCoinCollosion_game;
            game.OnScoreCounter += OnScoreCounter_game;
            game.OnPlayerFireKiCollosion += OnPlayerFireKiCollosion_game;
            game.OnProgressBar += OnProgressBar_game;
            game.OnProgressBarRemove += OnProgressBarRemove_game;
            game.OnPlayerEnergyCollosion += OnPlayerEnergyCollosion_game;
            game.OnPlayerDoorCollosion += OnPlayerDoorCollosion_game;
            game.OnPlayerKeyCollosion += OnPlayerKeyCollosion_game;

            leftCollection = new List<Image>();
            rightCollection = new List<Image>();
            leftCollection.Add(Resources.back1);
            leftCollection.Add(Resources.back2);
            leftCollection.Add(Resources.back3);
            leftCollection.Add(Resources.back4);
            leftCollection.Add(Resources.back5);
            leftCollection.Add(Resources.back6);
            leftCollection.Add(Resources.back7);
            leftCollection.Add(Resources.back8);
            rightCollection.Add(Resources.forward1);
            rightCollection.Add(Resources.forward2);
            rightCollection.Add(Resources.forward3);
            rightCollection.Add(Resources.forward4);
            rightCollection.Add(Resources.forward5);
            rightCollection.Add(Resources.forward6);
            rightCollection.Add(Resources.forward7);
            rightCollection.Add(Resources.forward8);
            explosionList = new List<Image>();
            explosionList.Add(Resources.Explosion_2);
            explosionList.Add(Resources.Explosion_4);
            explosionList.Add(Resources.Explosion_5);
            explosionList.Add(Resources.Explosion_6);
            explosionList.Add(Resources.Explosion_7);
            explosionList.Add(Resources.Explosion_9);
            explosionList.Add(Resources.Explosion_10);


            //Initializing componen
            playerSpeed = 7;
            firingSpeed = 20;
            //********************************************
            game.FallingBoundary = new Point(360, 400);
            fallingEnemyCount = 0;
            healthDeductOnFire = 86;
            //00000000000000000000000000000000000000


            createPlayer();

        }
        public void createPlayer()
        {
            Point boundary = new Point(this.Height, 1080);
            Point majorBoudary = new Point(this.Width, this.Width);
            game.MajorBoundary = majorBoudary;
            game.addGameObject(Properties.Resources.forward1, GameObjectType.player, 50, 65, 21, 490, new Keyboard(playerSpeed, leftCollection, rightCollection));

            foreach (Control pb in this.Controls)
            {
                if (pb is PictureBox && (string)pb.Tag == "wall")
                {
                    game.addGameObject((PictureBox)pb, GameObjectType.walls, new Static());


                }
                else if (pb is PictureBox && (string)pb.Tag == "ground")
                {
                    game.addGameObject((PictureBox)pb, GameObjectType.ground, new Static());

                }
                else if (pb is PictureBox && (string)pb.Tag == "coin")
                {
                    game.addGameObject((PictureBox)pb, GameObjectType.coin, new Static());

                }
                else if (pb is PictureBox && (string)pb.Tag == "slapMoving")
                {
                    game.addGameObject((PictureBox)pb, GameObjectType.ground, new Vertical(6, new Point(1180, 595), "up"));

                }
                else if (pb is PictureBox && (string)pb.Tag == "energy")
                {
                    game.addGameObject((PictureBox)pb, GameObjectType.energy, new Static());

                }
                else if (pb is PictureBox && (string)pb.Tag == "key")
                {
                    game.addGameObject((PictureBox)pb, GameObjectType.key, new Static());

                }
                else if (pb is PictureBox && (string)pb.Tag == "door")
                {
                    game.addGameObject((PictureBox)pb, GameObjectType.door, new Static());

                }

            }

            Collosion c = new Collosion(GameObjectType.player, GameObjectType.walls, new PlayerCollosion());
            Collosion c1 = new Collosion(GameObjectType.player, GameObjectType.ground, new PlayerCollosion());
            Collosion c2 = new Collosion(GameObjectType.player, GameObjectType.FireFalling, new PlayerCollosion());
            Collosion c3 = new Collosion(GameObjectType.player, GameObjectType.enemyFire, new PlayerCollosion());
            Collosion c4 = new Collosion(GameObjectType.player, GameObjectType.coin, new PlayerCollosion());
            Collosion c5 = new Collosion(GameObjectType.player, GameObjectType.dragon, new PlayerCollosion());
            Collosion c6 = new Collosion(GameObjectType.player, GameObjectType.slapMoving, new PlayerCollosion());
            Collosion c7 = new Collosion(GameObjectType.player, GameObjectType.wich, new PlayerCollosion());
            Collosion c8 = new Collosion(GameObjectType.playerFire, GameObjectType.wich, new PlayerFireCollosion());
            Collosion c9 = new Collosion(GameObjectType.player, GameObjectType.energy, new PlayerCollosion());
            Collosion c10 = new Collosion(GameObjectType.player, GameObjectType.key, new PlayerCollosion());
            Collosion c11 = new Collosion(GameObjectType.player, GameObjectType.door, new PlayerCollosion());

            game.Collosions.Add(c);
            game.Collosions.Add(c1);
            game.Collosions.Add(c2);
            game.Collosions.Add(c3);
            game.Collosions.Add(c4);
            game.Collosions.Add(c5);
            game.Collosions.Add(c6);
            game.Collosions.Add(c7);
            game.Collosions.Add(c8);
            game.Collosions.Add(c9);
            game.Collosions.Add(c10);
            game.Collosions.Add(c11);









        }
        private void createDragon(int left, int top)
        {
            PictureBox pbDragon = new PictureBox();
            pbDragon.BackColor = Color.Transparent;
            pbDragon.Left = left;
            pbDragon.Top = top;
            Image img = Properties.Resources.bird;
            pbDragon.Image = img;
            pbDragon.Height = 78;
            pbDragon.Width = 108;
            pbDragon.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pbDragon);
            pbDragon.BringToFront();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            lblLives.Text = lives.ToString();
            if (lives > 0)
            {
                if (pBarHealth.Value < 15)
                {
                    pBarHealth.Value = 100;
                    lives--;
                }
            }
            else
            {
                this.Close();
                StartingGame frm = new StartingGame();
                frm.Show();

            }
            //FreelyMove();
            game.UpdateGame();
            Point Boundary = new Point(360, 402);
            if (fallingEnemyCount == 90)
            {
                int x = rand.Next(0, 360);
                game.addGameObject(Resources.Prop_1, GameObjectType.FireFalling, 30, 30, x, 0, new Firing(firingSpeed, Boundary, "down"));

            }
            else if (fallingEnemyCount == 100)
            {
                int x = rand.Next(0, 360);
                game.addGameObject(Resources.Icon1, GameObjectType.FireFalling, 30, 30, x, 0, new Firing(firingSpeed, Boundary, "down"));
                fallingEnemyCount = 0;

            }
            fallingEnemyCount++;
            if (generateDragon > 200)
            {
                game.addGameObject(Resources.bird, GameObjectType.dragon, 70, 60, rand.Next(1200, 1800), rand.Next(130, 170), new Horizontol(10, new Point(-1, 1800), "left"));
                //createDragon(rand.Next(1200, 2200), rand.Next(100, 170));
                generateDragon = 0;
            }
            generateDragon++;
            if (wichCounter > 100)
            {
                game.addGameObject(Properties.Resources.Chelun_battle, GameObjectType.wich, 50, 60, 1400, 600, new Horizontol(3, new Point(1000, 1400), "left"));
                wichCounter = 0;
            }

            wichCounter++;
            // MoveSlideVertically();

        }
        private void OnGameObjectAdded_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Controls.Add(pb);
        }
        private void OnPlayerDie_game(object sender, EventArgs e)
        {

        }
        private void OnPlayerWallCollosion_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Left -= 10;
        }
        private void OnPlayerGroundCollosion_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Top -= 2;
        }
        private void OnPlayerFire_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Point Boundary = new Point(this.Width, this.Height);
            game.addGameObject(Resources.arrow2, GameObjectType.playerFire, 10, 50, (pb.Left + pb.Width), pb.Top + (pb.Height / 2), new Firing(firingSpeed, Boundary, "right"));

        }
        private void OnPlayerEnergyCollosion_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Controls.Remove(pb);
            pBarHealth.Value = 100;

        }
        private void OnPlayerRemoveFire_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Controls.Remove(pb);

        }
        private void OnDragonFire_game(object sender, EventArgs e)
        {
            PictureBox dragon = (PictureBox)sender;
            Point Boundary = new Point(0, 2000);
            Firing fire = new Firing(firingSpeed, Boundary, "diagonally");
            game.addGameObject(Resources.Explosion_1, GameObjectType.enemyFire, 30, 30, (dragon.Left - dragon.Width), dragon.Top + (dragon.Height - 40), fire);
            fire.ExplosionList = explosionList;

        }
        private void OnPlayerEnemyFireCollosion_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (pBarHealth.Value > 15)
            {
                pBarHealth.Value = health - healthDeductOnFire;
            }
            else
            {
                pb.Image = Resources.d1;
                for (int i = 0; i < 70; i++)
                {
                    if (i == 24)
                    {
                        pBarHealth.Value = 0;
                        pb.Image = Resources.d2;
                    }
                }
            }
        }
        private void OnProgressBar_game(object sender, EventArgs e)
        {
            ProgressBar pbar = (ProgressBar)sender;
            Controls.Add(pbar);
        }
        private void OnScoreCounter_game(object sender, EventArgs e)
        {
            Score++;
            lblScores.Text = Score.ToString();
        }
        private void OnPlayerCoinCollosion_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            coin++;
            Controls.Remove(pb);
            lblCoinDisp.Text = coin.ToString();
        }

        private void OnPlayerFireKiCollosion_game(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Controls.Remove(pb);

        }

        private void OnPlayerDoorCollosion_game(object sender, EventArgs e)
        {
            if (keyState == true)
            {
                PictureBox pb = (PictureBox)sender;
                Controls.Remove(pb);
                doorState = true;
                this.Close();
                winner n = new winner();
                n.Show();

            }

        }

        private void OnProgressBarRemove_game(object sender, EventArgs e)
        {
            ProgressBar pbar = (ProgressBar)sender;
            Controls.Remove(pbar);
        }

        private void OnPlayerKeyCollosion_game(object sender, EventArgs e)
        {
            keyState = true;
            PictureBox pb = (PictureBox)sender;
            Controls.Remove(pb);
        }

        private void Level2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void Level2_KeyDown(object sender, KeyEventArgs e)
        {
            game.keyPressed(e.KeyCode);

        }
    }
}
