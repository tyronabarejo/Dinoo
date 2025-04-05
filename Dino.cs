using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinoo
{
    public class Dino
    {
        public PictureBox DinoBox { get; private set; }
        public int JumpSpeed { get; set; }
        public int Force { get; set; } = 12;
        public bool Jumping { get; set; } = false;

        public Dino(PictureBox dinoBox)
        {
            DinoBox = dinoBox;
        }

        // Update Dino's movement and handle jumping
        public void UpdateJump(int groundLevel)
        {
            if (Jumping && Force > 0)
            {
                JumpSpeed = -12;
                Force--;
            }
            else
            {
                JumpSpeed = 12;
            }

            DinoBox.Top += JumpSpeed;

            if (DinoBox.Top + DinoBox.Height >= groundLevel)
            {
                DinoBox.Top = groundLevel - DinoBox.Height;
                Jumping = false;
                JumpSpeed = 0;
                Force = 12; // Reset Force
            }
        }

        // Start a jump
        public void Jump()
        {
            if (!Jumping)
            {
                Jumping = true;
                Force = 12;
            }
        }
    }
}