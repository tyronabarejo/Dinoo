using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinoo
{
    public class Obstacle
    {
        public PictureBox Box { get; private set; }
        private Random rand = new Random();

        public Obstacle(PictureBox box)
        {
            Box = box;
            Reset();
        }

        // Move obstacle and reset when out of bounds
        public void Move(int speed)
        {
            Box.Left -= speed;
            if (Box.Left < -Box.Width)
            {
                Reset(); // Reset when obstacle goes off-screen
            }
        }

        // Reset obstacle's position randomly
        public void Reset()
        {
            Box.Left = rand.Next(600, 800); // Random starting position
            Box.Top = rand.Next(250, 350); // Random height position
        }

        // Add collision detection with Dino
        public bool CollidesWith(PictureBox dino)
        {
            return Box.Bounds.IntersectsWith(dino.Bounds); // Check if the obstacle intersects with the dino
        }
    }
}
