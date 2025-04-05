using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinoo
{
    public class Loot
    {
        public PictureBox Box { get; private set; }
        private Random rand = new Random();
        public string Type { get; set; }

        public Loot(PictureBox box, string type)
        {
            Box = box;
            Type = type;
            Reset();
        }

        // Move loot item across the screen
        public void Move(int speed)
        {
            Box.Left -= speed;
            if (Box.Left < -Box.Width)
            {
                Reset(); // Reset position when it moves off-screen
            }
        }

        // Reset loot's position randomly
        public void Reset()
        {
            Box.Left = rand.Next(600, 800); // Random starting position
            Box.Top = rand.Next(250, 350); // Random height position
            Box.Visible = true;
        }

        // Check if loot is collected by player
        public bool CollectedBy(PictureBox player)
        {
            return Box.Bounds.IntersectsWith(player.Bounds);
        }
    }
}