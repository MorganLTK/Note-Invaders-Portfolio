
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        Character player = new Character();

        Bitmap graphicBits = new Bitmap(typeof(Form1), "notesArt.png");

        List<Ammo> projectiles = new List<Ammo>();
        List<Enemy> enemies = new List<Enemy>();

        int totalNotes = 100;
        
        int ScreenWidth = 500;
        int ScreenHeight = 400;
        int fireRate = 200;

        bool spacePressed;
        Random rnd = new Random();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            playBackgroundMusic();
            
            this.Height = ScreenHeight + 75;
            this.Width = ScreenWidth + 50;
                       
            player.Location = new Point(ScreenWidth / 2, ScreenHeight);
            player.Size = new Size(32, 32);
            player.Lives = 3;
            player.Speed = 3;                     
            // start the game timer
            GameTimer.Enabled = true;
            timer1.Enabled = true;
            ProjectileTimer.Interval = fireRate;
            ProjectileTimer.Enabled = true;
        }                       

        private void createEnemy()
        {
            if(enemies.Count < totalNotes)
            {
                Enemy enemy = new Enemy(rnd.Next(0, 4));
                enemy.Location = new Point(rnd.Next(0, ScreenWidth), rnd.Next(0,4) * 32);
                enemy.Size = new Size(32, 32);
                enemy.MoveRight = true;
                

                enemies.Add(enemy);
            }
        }
        private void MoveNotes()
        {
            foreach(Enemy e in enemies)
            {
                if(e.MoveRight)
                {
                    //uses speed of each note to move
                    e.Location = new Point(e.Location.X + e.Speed, e.Location.Y);
                    //if note reaches edge, move it down and change direction
                    if (e.Location.X >= ScreenWidth)
                    {                                                
                         e.MoveRight = false;
                         e.Location = new Point(e.Location.X, e.Location.Y + e.Size.Height);                                          
                    }
                }           
                if(e.MoveRight == false)
                {
                    e.Location = new Point(e.Location.X - e.Speed, e.Location.Y);
                    if (e.Location.X <= 0)
                    {                        
                         e.MoveRight = true;
                         e.Location = new Point(e.Location.X, e.Location.Y + e.Size.Height);                        
                    }
                }
                if(e.Location.Y >  ScreenHeight) 
                {
                    e.Location = new Point(0, 0);
                }
            }                     
        }

        private void MoveShip(int m)
        {            
            if (m < 0 && player.Location.X > 0)
            {
                player.Location = new Point(player.Location.X + m, player.Location.Y);
            }
            else if (m > 0 && player.Location.X < ScreenWidth)
            {
                player.Location = new Point(player.Location.X + m, player.Location.Y);
            }
        }

        private void MoveAmmo()
        {
            foreach (Ammo a in projectiles)
            {
                Point tempPoint = new Point(a.Location.X, a.Location.Y - a.Speed);
                a.Location = tempPoint;
            }
        }
         
        
        private void CheckNoteCollision()
        {
            // look to see if a note has hit the player
            foreach(Enemy a in enemies)
            {      
                if(player.Location.Y > a.Location.Y && player.Location.Y < (a.Location.Y + a.Size.Height)) 
                { 
                    if(player.Location.X > a.Location.X && player.Location.X < (a.Location.X + a.Size.Width))
                    {
                        player.Lives--; 
                    }
                }
            }                                             
        }

        private void CheckAmmoCollision()
        {
            for(int e = 0; e < enemies.Count; e++)
            {
                for(int i = 0; i < projectiles.Count; i++)
                {
                    Point tempPoint = new Point(projectiles[i].Location.X + projectiles[i].Size.Width/2, projectiles[i].Location.Y + projectiles[i].Size.Height/2);
                    if (tempPoint.Y > enemies[e].Location.Y && tempPoint.Y < (enemies[e].Location.Y + enemies[e].Size.Height))
                    {
                        if (tempPoint.X > enemies[e].Location.X && tempPoint.X < (enemies[e].Location.X + enemies[e].Size.Width))
                        {
                            projectiles.Remove(projectiles[i]);
                            enemies[e].Health--;
                        }
                    }
                }
                if (enemies[e].Health <= 0)
                {
                    enemies.Remove(enemies[e]);
                }
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle srcRect = new Rectangle();
            Rectangle destRect = new Rectangle();     
            int imageIndex;
            //paint lines
            for (int i = 0; i < ScreenHeight/10; i++)
            {
                e.Graphics.DrawLine(Pens.Black, 0, (i * 32) - 8, ClientRectangle.Right, (i * 32) - 8);
            }
            for (int i = 0; i < ScreenWidth / 4; i++)
            {
                e.Graphics.DrawLine(Pens.Black, ((ScreenWidth + 50) / 4) * i, 0, ((ScreenWidth + 50) / 4) * i, ClientRectangle.Right);
            }

            imageIndex = 5;
            srcRect = new Rectangle(imageIndex * 32, 0, 32, 32);
            destRect = new Rectangle(player.Location.X, player.Location.Y, player.Size.Width, player.Size.Height);
            e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
            foreach (Enemy a in enemies)
            {
                imageIndex = 0;
                if(a.Type > 1 && a.Health < 2)
                {
                    imageIndex = 1;
                }
                srcRect = new Rectangle(a.Type * 32, imageIndex * 32, 32, 32);
                destRect = new Rectangle(a.Location.X, a.Location.Y, a.Size.Width, a.Size.Height);
                e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
            }
            foreach (Ammo a in projectiles)
            {
                imageIndex = 4;
                srcRect = new Rectangle(imageIndex * 32, 0, 32, 32);
                destRect = new Rectangle(a.Location.X, a.Location.Y, a.Size.Width, a.Size.Height);
                e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveNotes();
            if (player.MoveRight)
            {
                MoveShip(player.Speed);
            }
            if (player.MoveLeft)
            {
                MoveShip(-1 * player.Speed);
            }
            MoveAmmo();

            CheckNoteCollision();
            CheckAmmoCollision();

            

            Invalidate();
            if (player.Lives == 2)
            {
                Heart1.Visible= false;
            }
            if (player.Lives == 1)
            {
                Heart2.Visible = false;
            }
            if (player.Lives == 0)
            {
                Heart3.Visible = false;
                Console.WriteLine("You Lose");
            }    
        }

        private void shoot()
        {
            Ammo ammo = new Ammo();

            Point tempPoint = new Point(player.Location.X, player.Location.Y - 1);
            ammo.Location = tempPoint;
            ammo.Size = new Size(20, 20);
            ammo.Speed = 5;
            projectiles.Add(ammo);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    {
                        player.MoveLeft = true;
                        player.MoveRight = false;
                        break;
                    }

                case Keys.Right:
                    {
                        player.MoveRight = true;
                        player.MoveLeft = false;
                        break;
                    }
                case Keys.Space:
                    {
                        spacePressed = true;
                        break;
                    }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        player.MoveLeft = false;
                        
                        break;
                    }

                case Keys.Right:
                    {
                        player.MoveRight = false;
                       
                        break;
                    }
                case Keys.Space:
                    {
                        spacePressed = false;
                        break;
                    }
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void playBackgroundMusic()
        {
            //SoundPlayer simpleSound = new SoundPlayer(SpaceInvaders.Properties.Resources.backmusic1);            
            //simpleSound.Play();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            createEnemy();
        }

        private void ProjectileTimer_Tick(object sender, EventArgs e)
        {
            if (spacePressed) 
            {
                shoot();
            }
        }
    }
}
