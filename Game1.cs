using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;


namespace BackgroundTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        bool ShowMainMenu;
        MainMenu menu;
        Song S1;
        SpriteFont menuFont;
        Texture2D logo;
        
        Scrolling b1;
        Scrolling b2;
        Player Player1;
        Enemy Enemy1;
        Enemy Enemy2;
        Enemy Enemy3;
        Level level;

        List<Platform> platforms = new List<Platform>();
        
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Player1 = new Player(new Rectangle(new Point(0, 0), new Point(100,100)), 100, this, "Idle");
            Enemy1 = new Enemy(new Rectangle(300,425,100,100),100,this,"IdleE");
            Enemy2 = new Enemy(new Rectangle(600, 325, 100, 100), 100, this, "IdleE");
            Enemy3 = new Enemy(new Rectangle(900, 175, 100, 100), 100, this, "IdleE");
            ShowMainMenu = true;
            level = new Level();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            menu = new MainMenu(Content.Load<Texture2D>("MenuScreen"), new Rectangle(new Point(0,0), new Point(1520,768)));
            logo = Content.Load<Texture2D>("AOR");
            menuFont = Content.Load<SpriteFont>("menuFont");
            S1 = Content.Load<Song>("industrial");
            b1 = new Scrolling(Content.Load<Texture2D>("background"), new Rectangle(0,0,1920,1080));
            b2 = new Scrolling(Content.Load<Texture2D>("background2"), new Rectangle(1920, 0, 1920, 1080));
            platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(0, 600, 200 ,75)));
            platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(300, 500, 200, 75)));
            platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(600, 400, 200, 75)));
            platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(900, 250, 200, 75)));



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                ShowMainMenu = false;
                MediaPlayer.Play(S1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                ShowMainMenu = true;
                Player1.restartPosition();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                level.setLevel(2);
                MediaPlayer.Stop();
            }
            if (level.getLevel()==2)
            {
                platforms.Clear();
                Player1.restartPosition();
                platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(0, 450, 200, 75)));
                platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(300, 600, 200, 75)));
                platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(750, 500, 200, 75)));
                platforms.Add(new Platform(Content.Load<Texture2D>("Pad5"), new Rectangle(1150, 300, 200, 75)));
                Enemy1.rectangle = new Rectangle(300,525,100,100);
                Enemy2.rectangle = new Rectangle(750,425,100,100);
                Enemy3.rectangle = new Rectangle(1150,225,100,100);
                level.setLevel(3);
            }
            if (ShowMainMenu==false)
            {
                b1.Update();
                b2.Update();
                Player1.Update();
                if (level.getLevel()==1)
                {
                    Enemy1.Update(300,450);
                    Enemy2.Update(600,750);
                    Enemy3.Update(900,1050);
                }
                if (level.getLevel()==3)
                {
                    Enemy1.Update(300, 450);
                    Enemy2.Update(750, 900);
                    Enemy3.Update(1150, 1300);
                }
                if (b1.rectangle.X + b1.texture.Width <= 0)
                {
                    b1.rectangle.X = b2.rectangle.X + b2.texture.Width;
                }
                if (b2.rectangle.X + b2.texture.Width <= 0)
                {
                    b2.rectangle.X = b1.rectangle.X + b1.texture.Width;
                }
            }
            foreach (Platform platform in platforms)
            {
                Player1.IsOnTop(platform.rectangle);
                
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            _spriteBatch.Begin();
            if (ShowMainMenu)
            {
                menu.Draw(_spriteBatch);
                _spriteBatch.Draw(logo, new Rectangle(300,25,750,750), Color.White);
                _spriteBatch.DrawString(menuFont, "Press Enter to start", new Vector2(250,650), Color.White);
            }
            else
            {
                b1.Draw(_spriteBatch);
                b2.Draw(_spriteBatch);
                foreach (Platform Platform in platforms)
                {
                    Platform.Draw(_spriteBatch);
                }
                Player1.Draw(_spriteBatch);
                Enemy1.Draw(_spriteBatch);
                Enemy2.Draw(_spriteBatch);
                Enemy3.Draw(_spriteBatch);
                
            }
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}


