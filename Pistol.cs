using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    public class Pistol : Weapon
    {
        private double _lastFireTime;
        private List<Bullet> _bullets;
        private GraphicsDevice _graphicsDevice;

        public Pistol(int damage, float fireRate, int ammoCount, GraphicsDevice graphicsDevice) : base(damage, fireRate, ammoCount)
        {
            _lastFireTime = 0;
            _bullets = new List<Bullet>();
            _graphicsDevice = graphicsDevice;
        }

        public override void Fire(GameTime gameTime, Vector2 position, Vector2 direction)
        {
            if (gameTime.TotalGameTime.TotalSeconds - _lastFireTime >= FireRate && AmmoCount > 0)
            {
                _bullets.Add(new Bullet(position, direction, 500f, Damage));
                _lastFireTime = gameTime.TotalGameTime.TotalSeconds;
                AmmoCount--;
            }
        }

        public override void UpdateBullets(GameTime gameTime)
        {
            for (int i = _bullets.Count - 1; i >= 0; i--)
            {
                var bullet = _bullets[i];
                bullet.Update(gameTime);
            }
        }

        public override List<Bullet> GetBullets()
        {
            return _bullets;
        }
    }
}
