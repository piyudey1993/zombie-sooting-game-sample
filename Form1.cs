namespace Zombie_Shooter
{
    public partial class Form1 : Form
    {

        bool goleft, goright,goup,godown,over_label ;
        string facing = "up";
        int playerhealth = 100;
        int playerspeed = 10;
        int zombiespeed = 3;
        int ammo = 10;
        int score = 0;

        Random rnd = new Random();
        List<PictureBox> zombielist = new List<PictureBox>();




        public Form1()
        {
            InitializeComponent();
            restartGame();
        
            }
        void keymove()
        {
            if (goleft == true && player.Left > 0)
            {
                player.Left -= playerspeed;
            }

            if (goright == true && (player.Left + player.Width) < this.ClientSize.Width)
            {
                player.Left += playerspeed;
            }

            if (goup == true && player.Top > 45)
            {
                player.Top -= playerspeed;
            }

            if (godown == true && (player.Top + player.Height) < this.ClientSize.Height)
            {
                player.Top += playerspeed;
            }

        }

        private void collect_Ammo()
        {
            foreach(var x in this. Controls )
            {
                if(x is PictureBox && (string)x.Tag == "ammo")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }
            }
           
        }

        private void zombie_attack()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "zombie")
                {

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerhealth -= 1;
                    }


                        if (x.Left > player.Left)
                    {
                        x.Left -= zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }

                    if (x.Left < player.Left)
                    {
                        x.Left += zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }

                    if (x.Top > player.Top)
                    {
                        x.Top -= zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }

                    if (x.Top < player.Top)
                    {
                        x.Top += zombiespeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }
                }

                foreach(Control j in this.Controls)
                        {
                    if(j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string )x.Tag =="zombie")
                    {
                        if(x.Bounds.IntersectsWith(j.Bounds))
                            {
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();

                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();

                            zombielist.Remove(((PictureBox)x));
                            makeZombies();
                        }
                    }    

                }
            }
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if(playerhealth > 1)
            {
                health_bar.Value = playerhealth;
            }
            else
            {
                over_label = true;
                player.Image = Properties.Resources.dead;
                Game_timer.Stop();
            }

            ammo_txt.Text= "AMMO : " + ammo;
            score_txt.Text = "KIlls: " + score;

            keymove();
            collect_Ammo();
            zombie_attack();

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }

           
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
               
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
              
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = false;
               
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
               
            }

            if (e.KeyCode == Keys.Space && ammo > 0 && over_label == false)
            {
                ammo--;
                shootbullets(facing);

                if(ammo<1)
                {
                    Dropammo();
                }
            }
        }

        private void shootbullets(string direction)
        {
            Bullet bullet_object = new Bullet();
            bullet_object.direction = direction;
            bullet_object.bulleft = player.Left + (player.Width / 2);
            bullet_object.bultop = player.Top + (player.Height / 2);
            bullet_object.makebullet(this);

        }

        private void makeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = rnd.Next(0, this.ClientSize.Width-zombie.Width);
            zombie.Top = rnd.Next(0, this.ClientSize.Height - zombie.Height);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombielist.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();



        }

        private void Dropammo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Tag = "ammo";
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.Left = rnd.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = rnd.Next(10, this.ClientSize.Height - ammo.Height);
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            //adding in form
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();

        }

        private void restartGame()
        {
            player.Image = Properties.Resources.up;
            foreach(PictureBox i in zombielist)
            {
                this.Controls.Remove(i);
            }

            zombielist.Clear();

            for(int i=0;i<3;i++)
            {
                makeZombies();
            }

            goup = false;
            goleft = false;
            goright = false;
            godown = false;

            playerhealth = 100;
            score = 0;
            ammo = 10;


        }
    }
}
