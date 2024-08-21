using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;



namespace Zombie_Shooter
{
    internal class Bullet
    {
        public string direction;
        public int bulleft,bultop;

        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();
        private int formlength,formwidth;
        public void makebullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulleft;
            bullet.Top = bultop;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;

            formlength = form.ClientSize.Height;
            formwidth = form.ClientSize.Width;

            bulletTimer.Tick += new EventHandler(bulletTimerEvent);
            bulletTimer.Start();

            
        }

        private void bulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }

            if (direction == "right")
            {
                bullet.Left += speed;
            }

            if (direction == "up")
            {
                bullet.Top -= speed;
            }

            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bullet.Left < 10 || bullet.Left > formwidth || bullet.Top < 10 || bullet.Top > formlength)
            { //860 ,600
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }

    }
}
