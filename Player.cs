using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootEmUp;

public class Player
{
    public Vector2 Position { get; set; }
    public float Speed { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public Weapon Weapon { get; set; }


    public Player(Vector2 initialPosition, float speed, int health, int damage, GraphicsDevice graphicsDevice)
    {
        Position = initialPosition;
        Speed = speed;
        Health = health; 
        Damage = damage;

        Weapon = new Pistol(10, 0.5f, 120, graphicsDevice);
    }

    public Rectangle Hitbox
    {
        get { return new Rectangle((int)Position.X, (int)Position.Y, 40, 40); }
    }

    public void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.W))
            Position = new Vector2(Position.X, Position.Y - Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

        if (keyboardState.IsKeyDown(Keys.S))
            Position = new Vector2(Position.X, Position.Y + Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

        if (keyboardState.IsKeyDown(Keys.A))
            Position = new Vector2(Position.X - Speed * (float)gameTime.ElapsedGameTime.TotalSeconds, Position.Y);

        if (keyboardState.IsKeyDown(Keys.D))
            Position = new Vector2(Position.X + Speed * (float)gameTime.ElapsedGameTime.TotalSeconds, Position.Y);

        Weapon.UpdateBullets(gameTime);
        if (keyboardState.IsKeyDown(Keys.Space))
            Weapon.Fire(gameTime, Position, new Vector2(0, -1));
        
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            // Обработка смерти игрока
        }
    }
}
