# MonoGame Display Boilerplate
This solution can be used to get up and running with a 2D project using the MonoGame application framework (a fork of XNA4). It features resolution-independent drawing using letter/pillarboxing.

## Overview
- **Game1.cs** sets up a RenderTarget2D which takes BackBuffer sprites drawn, which are in turn re-sized, positioned with `LetterPillarBox()` in the `spriteBatch.Draw()` call
- **Textures.cs** loads and stores references to texture content (includes only a test texture)
-  **Draw.cs** handles drawing (includes test draws around the screen)
- **GlobalVariables.cs** stores global variables

## To Use
Make all spriteBatch.Draw() calls in `Game1.Draw()`, between `graphics.GraphicsDevice.SetRenderTarget(renderTarget);` and `graphics.GraphicsDevice.SetRenderTarget(null);`
