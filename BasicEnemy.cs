using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    public class BasicEnemy : Enemy
    {
        public BasicEnemy(Vector2 initialPosition, int health, float speed, int damage) : base(initialPosition, health, speed, damage)
        {
        }

        public override void Update(GameTime gameTime, Player player)
        {
            var direction = Vector2.Normalize(player.Position - Position);
            Position += direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            // добавить проверку, на то, что в след клетке нет второго такгого же челикса
        }
    }   
}
