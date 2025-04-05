using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Dinoo
{
    public class SoundManager
  
    {
        public SoundPlayer Jump { get; private set; }
        public SoundPlayer Shoot { get; private set; }
        public SoundPlayer Loot { get; private set; }
        public SoundPlayer GameOver { get; private set; }
        public SoundPlayer Music { get; private set; }

        public SoundManager()
        {
            Jump = new SoundPlayer("jump.wav");
            Shoot = new SoundPlayer("shoot.wav");
            Loot = new SoundPlayer("loot.wav");
            GameOver = new SoundPlayer("gameover.wav");
            Music = new SoundPlayer("bgm.wav");
        }

        public void PlayMusic() => Music.PlayLooping(); // Play background music
        public void StopMusic() => Music.Stop(); // Stop background music
    }
}
