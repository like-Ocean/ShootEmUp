using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ShootEmUp
{
    public class GameController
    {
        private GraphicsDeviceManager _graphics;
        public Player Player { get; private set; }
        public EnemyManager EnemyManager { get; private set; }

        public FollowCamera Camera { get; private set; }

        public GameController(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            Player = new Player(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 2), 
                300, 100, 25, _graphics.GraphicsDevice);
            EnemyManager = new EnemyManager();

            Camera = new FollowCamera(Vector2.Zero);
        }

        public void Update(GameTime gameTime)
        {
            Player.Update(gameTime, Camera.Position);
            EnemyManager.Update(gameTime, Player);

            Camera.Follow(new Rectangle((int)Player.Position.X, (int)Player.Position.Y, 40, 40), 
                new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));

            foreach (var enemy in EnemyManager.GetEnemies())
            {
                if (Player.Hitbox.Intersects(enemy.Hitbox))
                {
                    Player.Health -= enemy.Damage;

                }
            }

            var bulletsToRemove = new List<Bullet>();
            foreach (var bullet in Player.Weapon.GetBullets())
            {
                foreach (var enemy in EnemyManager.GetEnemies())
                {
                    if (new Rectangle((int)bullet.Position.X, (int)bullet.Position.Y, 10, 10).Intersects(enemy.Hitbox))
                    {
                        enemy.TakeDamage(bullet.Damage);
                        bulletsToRemove.Add(bullet);
                    }
                }
            }

            foreach (var bullet in bulletsToRemove)
            {
                Player.Weapon.GetBullets().Remove(bullet);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D playerTexture, Texture2D enemyTexture, Texture2D bulletTexture, SpriteFont font)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(playerTexture, new Rectangle((int)(Player.Position.X + Camera.Position.X), (int)(Player.Position.Y + Camera.Position.Y), 40, 40), Color.Pink);

            foreach (var enemy in EnemyManager.GetEnemies())
            {
                spriteBatch.Draw(enemyTexture, new Rectangle((int)(enemy.Position.X + Camera.Position.X), (int)(enemy.Position.Y + Camera.Position.Y), 50, 50), Color.Red);
            }

            string healthText = "Health: " + Player.Health.ToString();
            spriteBatch.DrawString(font, healthText, new Vector2(10, 10), Color.White);

            string ammoText = "Ammo: " + Player.Weapon.AmmoCount.ToString();
            spriteBatch.DrawString(font, ammoText, new Vector2(10, 30), Color.White);

            foreach (var bullet in Player.Weapon.GetBullets())
            {
                spriteBatch.Draw(bulletTexture, new Rectangle((int)(bullet.Position.X + Camera.Position.X), (int)(bullet.Position.Y + Camera.Position.Y), 10, 10), Color.White);
            }

            spriteBatch.End();
        }
    }
}
