using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinoo
{
    public class Bullet
    {
        public PictureBox Box { get; private set; }
        public bool IsFired { get; set; } = false;
        public int Speed { get; set; } = 15;

        public Bullet(PictureBox box)
        {
            Box = box;
            Box.Visible = false;
        }

        // Fire bullet
        public void Fire(Point start)
        {
            IsFired = true;
            Box.Left = start.X;
            Box.Top = start.Y;
            Box.Visible = true;
        }

        // Update bullet position and stop if it goes off-screen
        public void Update(int screenWidth)
        {
            if (IsFired)
            {
                Box.Left += Speed;

                if (Box.Left > screenWidth)
                {
                    IsFired = false;
                    Box.Visible = false;
                }
            }
        }

        // Check if bullet hits target
        public bool Hits(PictureBox target)
        {
            return IsFired && Box.Bounds.IntersectsWith(target.Bounds);
        }

        // Stop the bullet
        public void Stop()
        {
            IsFired = false;
            Box.Visible = false;
        }
    }
}