using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameDisplayBoilerplate
{
    public class Game1 : Game
    {
        public SpriteBatch spriteBatch;
        public Textures textures;

        private GraphicsDeviceManager graphics;
        private RenderTarget2D renderTarget;
        private Draw draw;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                // Set BackBuffer size to virtual / development size; re-scaled, projected, onto RenderTarget
                PreferredBackBufferWidth = GlobalVariables.WIDTH_VIRTUAL,
                PreferredBackBufferHeight = GlobalVariables.HEIGHT_VIRTUAL,
                IsFullScreen = true
            };

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            PresentationParameters presentationParameters = graphics.GraphicsDevice.PresentationParameters;
            // Takes BackBuffer sprites drawn, re-sized by LetterPillarBox(), for drawing in SpriteBatch
            renderTarget = new RenderTarget2D(graphics.GraphicsDevice, GlobalVariables.WIDTH_VIRTUAL, GlobalVariables.HEIGHT_VIRTUAL, false,
                SurfaceFormat.Color, DepthFormat.None, presentationParameters.MultiSampleCount,
                RenderTargetUsage.DiscardContents);
            textures = new Textures();

            GlobalVariables.WidthActual = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            GlobalVariables.HeightActual = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            draw = new Draw(this);

            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            textures.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Set draw to renderTarget
            graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            // Call draw methods
            draw.TestDraw();
            // Stop draw to renderTarget
            graphics.GraphicsDevice.SetRenderTarget(null);



            // Draw renderTarget to screen at position, size of LetterPillarBox()
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend,
                SamplerState.PointWrap);
            spriteBatch.Draw(renderTarget, LetterPillarBox(), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Return position, size, set colour, to draw renderTarget for letter/pillarboxing
        private Rectangle LetterPillarBox()
        {
            // Background colour i.e. letter/pillarbox 
            graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 1f, 0);

            Rectangle destinationDraw;

            // If actual width larger relative to height compared to virtual, letterbox
            if (GlobalVariables.AspectActual <= GlobalVariables.AspectVirtual)
            {
                int heightScreen = (int)(GlobalVariables.WidthActual / GlobalVariables.AspectVirtual);
                int widthPillarBox = (int)((GlobalVariables.HeightActual - heightScreen) * 0.5f);

                return destinationDraw = new Rectangle(0, widthPillarBox, GlobalVariables.WidthActual, heightScreen);
            }
            //If actual width smaller relative to height compared to virtual, pillarbox
            else
            {
                int widthScreen = (int)(GlobalVariables.HeightActual * GlobalVariables.AspectVirtual);
                int widthBar = (int)((GlobalVariables.WidthActual - widthScreen) * 0.5f);

                return destinationDraw = new Rectangle(widthBar, 0, widthScreen, GlobalVariables.HeightActual);
            }
        }
    }
}