using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiniGame2020
{
    public class MiniGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int _sirkaOkna = 800;
        private int _vyskaOkna = 600;

        private Ctverecek _ctverecek;

        private Ctverecek2 _ctverecek2;

        private Color _backgroundcolor = Color.White;

        private int _px = (800 - 50) / 2;

        private int _py = (600 - 50) / 2;

        private int c, x, m;
        private int v = 1;



        public MiniGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MiniGame";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = _sirkaOkna;
            _graphics.PreferredBackBufferHeight = _vyskaOkna;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _ctverecek = new Ctverecek(
                50, 5,
                new Vector2(_px, _py),
                new SmeroveOvladani(Keys.Left, Keys.Right, Keys.Up, Keys.Down),
                new Rectangle(0, 0, _sirkaOkna, _vyskaOkna),
                Color.Black, GraphicsDevice
            ); ;

            _ctverecek2 = new Ctverecek2(
                50, 5,
                new Vector2((_sirkaOkna - 50) / 2 - 25, (_vyskaOkna - 50) / 2),
                new OvladaniDucha(Keys.Left, Keys.Right, Keys.Up, Keys.Down),
                new Rectangle(0, 0, _sirkaOkna, _vyskaOkna),
                Color.Gray, GraphicsDevice
            );


        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavesnice = Keyboard.GetState();

            if (klavesnice.IsKeyDown(Keys.Escape))
                Exit();


            _ctverecek.Aktualizovat(klavesnice);
            _ctverecek2.Aktualizovat(klavesnice);

            base.Update(gameTime);

            c = v * _py;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundcolor);

            _spriteBatch.Begin();
            _ctverecek2.Vykreslit(_spriteBatch);
            _ctverecek.Vykreslit(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
