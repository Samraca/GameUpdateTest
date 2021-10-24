using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BackgroundTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        bool ShowMainMenu;
        MainMenu menu;
        
        Scrolling b1;
        Scrolling b2;
        Player Player1;
        Enemy Enemy1;
        Platform Platform1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Player1 = new Player(new Rectangle(new Point(0, 0), new Point(100,100)), 100, this, "Idle");
            Enemy1 = new Enemy(new Rectangle(new Point(100,100 ), new Point(100, 100)), 100, this, "IdleE");
            ShowMainMenu = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            menu = new MainMenu(Content.Load<Texture2D>("cyberpunk-street"), new Rectangle(new Point(100,300), new Point(608,192)));
            b1 = new Scrolling(Content.Load<Texture2D>("Background"), new Rectangle(0,0,1799,892));
            b2 = new Scrolling(Content.Load<Texture2D>("Background2"), new Rectangle(1799, 0, 1799, 892));
            Platform1 = new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(0,680,300,100));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ShowMainMenu = false;
            }
            if (b1.rectangle.X + b1.texture.Width <= 0)
            {
                b1.rectangle.X = b2.rectangle.X + b2.texture.Width;
            }
            if (b2.rectangle.X + b2.texture.Width <= 0)
            {
                b2.rectangle.X = b1.rectangle.X + b1.texture.Width;
            }
            b1.Update();
            b2.Update();
            Player1.Update();
            Enemy1.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            _spriteBatch.Begin();
            if (ShowMainMenu)
            {
                menu.Draw(_spriteBatch);
            }
            else
            {
            b1.Draw(_spriteBatch);
            b2.Draw(_spriteBatch);
            Platform1.Draw(_spriteBatch);
            Player1.Draw(_spriteBatch);
            Enemy1.Draw(_spriteBatch);
            }
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
