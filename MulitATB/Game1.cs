#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace MulitATB
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private SpriteFont font;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D guy, cursor;
        int dpadHeldFrames;
        int curpos;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            dpadHeldFrames = 0;
            curpos = 0;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            guy = Content.Load<Texture2D>("psychic1.png");
            cursor = Content.Load <Texture2D>("cursor");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                if (dpadHeldFrames == 0 || dpadHeldFrames == 5)
                {
                    curpos += 1;
                    dpadHeldFrames = 1;
                }
                else
                {
                    dpadHeldFrames += 1;
                }
            }
            else if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                if (dpadHeldFrames == 0 || dpadHeldFrames == 5)
                {
                    curpos -= 1;
                    dpadHeldFrames = 1;
                }
                else
                {
                    dpadHeldFrames += 1;
                }
            }
            else
            {
                dpadHeldFrames = 0;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(guy, new Rectangle(0, 0, 64, 64), Color.White);
            spriteBatch.Draw(cursor, new Rectangle(0, 10 * curpos, 16, 16), Color.Wheat);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
