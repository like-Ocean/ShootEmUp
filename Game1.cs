using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace ShootEmUp
{
    public class Game1 : Game
    {
        private SpriteFont _font;
        private SpriteFont _debugFont;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameController _gameController;
        private Texture2D _playerTexture;
        private Texture2D _enemyTexture;
        private Texture2D _bulletTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;

            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _gameController = new GameController(_graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("testFont");
            _debugFont = Content.Load<SpriteFont>("testFont");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerTexture = new Texture2D(GraphicsDevice, 1, 1);
            _playerTexture.SetData(new[] { Color.White });

            _enemyTexture = new Texture2D(GraphicsDevice, 1, 1);
            _enemyTexture.SetData(new[] { Color.Red });

            _bulletTexture = new Texture2D(GraphicsDevice, 1, 1);
            _bulletTexture.SetData(new[] { Color.Black });
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _gameController.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //_gameController.Draw(_spriteBatch, _playerTexture, _enemyTexture, _font);
            _gameController.Draw(_spriteBatch, _playerTexture, _enemyTexture, _bulletTexture, _font);

            base.Draw(gameTime);
        }
    }
}