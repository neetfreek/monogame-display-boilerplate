/********************************************
* Contain all references to texture assets  * 
*********************************************/

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameDisplayBoilerplate
{
    public class Textures
    {
        public Texture2D test;

        public void LoadContent(ContentManager contentManager)
        {
            test = contentManager.Load<Texture2D>("button");
        }
    }
}