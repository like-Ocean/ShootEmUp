using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace ShootEmUp
{

    public class EnemyManager
    {
        private List<Enemy> _enemies;
        Random Coordinate = new Random();

        public EnemyManager()
        {
            _enemies = new List<Enemy>();
        }

        public void Update(GameTime gameTime, Player player)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Update(gameTime, player);
            }

            for (int i = 0; i < _enemies.Count; i++)
            {
                for (int j = i + 1; j < _enemies.Count; j++)
                {
                    if (_enemies[i].Hitbox.Intersects(_enemies[j].Hitbox))
                    {
                        
                        Vector2 direction = _enemies[j].Position - _enemies[i].Position;
                        direction.Normalize();

                        _enemies[i].Position -= direction * 10;
                        _enemies[j].Position += direction * 10;
                    }
                }
            }

            _enemies.RemoveAll(e => e.Health <= 0);

            if (_enemies.Count < 5)
            {
                int respawn = Coordinate.Next(0, 1000);
                var position = new Vector2(respawn, respawn);

                _enemies.Add(new BasicEnemy(position, 50, 140, 5));
            }
        }

        public List<Enemy> GetEnemies()
        {
            return _enemies;
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }
    }
    
}
