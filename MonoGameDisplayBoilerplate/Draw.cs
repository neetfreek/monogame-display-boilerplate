/************************************************************
* Contain all draw functionality, called by Game1.Draw()    * 
*************************************************************/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameDisplayBoilerplate
{
    public class Draw
    {
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;
        private Textures textures;

        public Draw(Game1 game1)
        {
            graphicsDevice = game1.GraphicsDevice;
            spriteBatch = game1.spriteBatch;
            textures = game1.textures;
        }

        public void TestDraw()
        {
            // Background
            graphicsDevice.Clear(Color.White);

            // Draw sprites to renderTarget
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend,
                SamplerState.PointWrap);

            Texture2D testTriangle = textures.test;

            // Top-left
            spriteBatch.Draw(testTriangle, new Rectangle(0, 0, testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Bottom-left
            spriteBatch.Draw(testTriangle, new Rectangle(0, GlobalVariables.HEIGHT_VIRTUAL - testTriangle.Height,
                testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Top-right
            spriteBatch.Draw(testTriangle, new Rectangle(GlobalVariables.WIDTH_VIRTUAL - testTriangle.Width, 0, testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Bottom-right
            spriteBatch.Draw(testTriangle, new Rectangle(GlobalVariables.WIDTH_VIRTUAL - testTriangle.Width, GlobalVariables.HEIGHT_VIRTUAL - testTriangle.Height, testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Center
            spriteBatch.Draw(testTriangle, new Rectangle((int)((GlobalVariables.WIDTH_VIRTUAL - testTriangle.Width) * 0.5f), (int)((GlobalVariables.HEIGHT_VIRTUAL - testTriangle.Height) * 0.5f), testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Top-center
            spriteBatch.Draw(testTriangle, new Rectangle((int)((GlobalVariables.WIDTH_VIRTUAL - testTriangle.Width) * 0.5f), 0, testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Bottom-center
            spriteBatch.Draw(testTriangle, new Rectangle((int)((GlobalVariables.WIDTH_VIRTUAL - testTriangle.Width) * 0.5f), GlobalVariables.HEIGHT_VIRTUAL - testTriangle.Height, testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Left-center
            spriteBatch.Draw(testTriangle, new Rectangle(0, (int)((GlobalVariables.HEIGHT_VIRTUAL - testTriangle.Height) * 0.5f), testTriangle.Width, testTriangle.Height), Color.Magenta);
            // Right-center
            spriteBatch.Draw(testTriangle, new Rectangle(GlobalVariables.WIDTH_VIRTUAL - testTriangle.Width, (int)((GlobalVariables.HEIGHT_VIRTUAL - testTriangle.Height) * 0.5f), testTriangle.Width, testTriangle.Height), Color.Magenta);

            spriteBatch.End();
        }
    }
}