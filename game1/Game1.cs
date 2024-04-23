using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleBrownTexture, tribbleCreamTexture, tribbleGreyTexture, tribbleOrangeTexture;
        Rectangle tribbleBrownRectangle, tribbleCreamRectangle, tribbleGreyRectangle, tribbleOrangeRectangle, window;
        Vector2 greyTribbleSpeed, creamTribbleSpeed,orangeTribbleSpeed,brownTribbleSpeed;

        Color bgColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            bgColor = Color.CornflowerBlue;

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleBrownRectangle = new Rectangle(350,250, 100,100);
            tribbleCreamRectangle = new Rectangle(350,250,100,100);
            tribbleGreyRectangle = new Rectangle(300,100, 100,100);
            tribbleOrangeRectangle = new Rectangle(500,50,100,100);

            greyTribbleSpeed = new Vector2(7,10);
            creamTribbleSpeed = new Vector2(0, 8);
            orangeTribbleSpeed = new Vector2(7, 10);
            brownTribbleSpeed= new Vector2(11, 0);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyRectangle.X += (int)greyTribbleSpeed.X;
            if (tribbleGreyRectangle.Right>window.Width|| tribbleGreyRectangle.X<0)
            {
                greyTribbleSpeed.X *= -1;

            }
            tribbleGreyRectangle.Y += (int)greyTribbleSpeed.Y;
            if (tribbleGreyRectangle.Bottom >= window.Height|| tribbleGreyRectangle.Top <=0)
            {
                greyTribbleSpeed.Y *= -1;
                bgColor = Color.Gray;
            }
            tribbleGreyRectangle.Y += (int)greyTribbleSpeed.Y;
            tribbleBrownRectangle.X += (int)brownTribbleSpeed.X;
            if (tribbleBrownRectangle.Right > window.Width || tribbleBrownRectangle.X < 0)
            {
                tribbleBrownRectangle.X = (0);
                tribbleBrownRectangle.Y = (250);
                
            }
            tribbleCreamRectangle.Y += (int)creamTribbleSpeed.Y;
            if (tribbleCreamRectangle.Bottom >= window.Height || tribbleCreamRectangle.Top <= 0)
            {
                creamTribbleSpeed.Y *= -1;
                bgColor = Color.LightGray;
            }
            tribbleOrangeRectangle.X += (int)orangeTribbleSpeed.X;
            if (tribbleOrangeRectangle.Right > window.Width || tribbleOrangeRectangle.X < 0)
            {
                orangeTribbleSpeed.X *= -1;
            }
            tribbleOrangeRectangle.Y += (int)orangeTribbleSpeed.Y;
            if (tribbleOrangeRectangle.Bottom >= window.Height || tribbleOrangeRectangle.Top <= 0)
            {
                orangeTribbleSpeed.Y *= -1;
                bgColor = Color.Orange;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRectangle, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRectangle, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRectangle, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRectangle, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}