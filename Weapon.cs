using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    public abstract class Weapon
    {
        public int Damage { get; set; }
        public float FireRate { get; set; }
        public int AmmoCount { get; set; }

        protected Weapon(int damage, float fireRate, int ammoCount)
        {
            Damage = damage;
            FireRate = fireRate;
            AmmoCount = ammoCount;
        }

        public abstract void Fire(GameTime gameTime, Vector2 position, Vector2 direction);
        public abstract void UpdateBullets(GameTime gameTime);
        public abstract List<Bullet> GetBullets();

    }
}
