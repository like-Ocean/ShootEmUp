using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    public class Bullet
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public int Damage { get; set; }

        public Bullet(Vector2 position, Vector2 direction, float speed, int damage)
        {
            Position = position;
            Direction = direction;
            Speed = speed;
            Damage = damage;
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
