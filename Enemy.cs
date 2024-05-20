using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    public abstract class Enemy
    {
        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }
        public int Damage { get; set; }

        public double _attackTimer = 1;
        private const double _attackInterval = 1.0;

        protected Enemy(Vector2 initialPosition, int health, float speed, int damage)
        {
            Position = initialPosition;
            Health = health;
            Speed = speed;
            Damage = damage;
        }

        public Rectangle Hitbox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, 50, 50); }
        }

        public virtual void Update(GameTime gameTime, Player player)
        {
            _attackTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (Hitbox.Intersects(player.Hitbox))
            {
                if (_attackTimer >= _attackInterval)
                {
                    Attack(player);
                    _attackTimer = 0;
                }
            }
            else
            {
                _attackTimer = 0; 
            }
        }
        private void Attack(Player player)
        {
            if (Hitbox.Intersects(player.Hitbox))
                player.TakeDamage(Damage);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                
            }
        }
    }
    
}
