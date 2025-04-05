namespace Dinoo
{
    public partial class Form1 : Form
    {
        // Declare necessary game objects
        private Dino player;
        private Obstacle obstacle;
        private Loot slowLoot, ammoLoot;
        private Bullet bullet;
        private SoundManager sound;
        private int ammo = 0;
        private int score = 0;
        private int obstacleSpeed = 10;
        private bool hasSlow = false;
        private int slowTimer = 0;
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new Dino(dino);
            obstacle = new Obstacle(obstacleBox);
            slowLoot = new Loot(slowLootBox, "slow");
            ammoLoot = new Loot(ammoLootBox, "ammo");
            bullet = new Bullet(bulletBox);
            sound = new SoundManager();
            sound.PlayMusic();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Update player jumping
            player.UpdateJump(ClientSize.Height - 50);

            // Move obstacles and loot
            obstacle.Move(obstacleSpeed);
            slowLoot.Move(obstacleSpeed);
            ammoLoot.Move(obstacleSpeed);

            // Update bullet
            bullet.Update(ClientSize.Width);

            // Collision detection
            if (bullet.Hits(obstacle.Box))
            {
                bullet.Stop();
                obstacle.Reset();
                score++;
            }

            if (slowLoot.CollectedBy(dino))
            {
                hasSlow = true;
                slowTimer = 200;
                slowLoot.Box.Visible = false;
                obstacleSpeed = 4;
                sound.Loot.Play();
            }

            if (ammoLoot.CollectedBy(dino))
            {
                ammo += 3;
                ammoLoot.Box.Visible = false;
                lblAmmo.Text = "Ammo: " + ammo;
                sound.Loot.Play();
            }

            if (hasSlow)
            {
                slowTimer--;
                if (slowTimer <= 0)
                {
                    hasSlow = false;
                    obstacleSpeed = 10;
                }
            }

            // Check for collision between Dino and Obstacle
            if (obstacle.CollidesWith(dino))
            {
                gameTimer.Stop();
                sound.GameOver.Play();
                lblScore.Text = "Game Over! Final Score: " + score;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)  // If Space is pressed, jump the Dino
            {
                player.Jump();  // Jump method for the Dino (you can replace this with your own jump logic)
                sound.Jump.Play();  // Play jump sound (if you have it)
            }
            else if (e.KeyCode == Keys.F && !bullet.IsFired)  // If F is pressed and the bullet is not already fired
            {
                bullet.Fire(new Point(dino.Left + dino.Width / 2, dino.Top));  // Fire the bullet from Dino's position
                sound.Shoot.Play();  // Play shooting sound (if you have it)
            }
        }
    }
}
