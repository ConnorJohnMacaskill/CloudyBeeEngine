using CloudyBeeEngine;
using CloudyBeeEngine.Addons;
using CloudyBeeEngine.Cache;
using CloudyBeeEngine.EntitySystem;
using CloudyBeeEngine.Factories;
using CloudyBeeEngine.Logging;
using CloudyBeeEngine.LUA.Interfaces;
using CloudyBeeEngine.Scenes;
using CloudyBeeEngine.Template;
using CloudyBeeEngine.Utility;
using CloudyBeeEngine.WorldSpace;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TurretArena.Scenes;

namespace TurretArena
{
    public class TurretGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private SceneManager sceneManager;
        private World world;
        public object WorldInterface { get; private set; }

        private Camera camera;
        //DEBUG

        public TurretGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;

            Logger.Instance.Log("Starting game...");
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Logger.Instance.Log("Initializing...");

            CloudyBee2.Initialise(GraphicsDevice, Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(800, 800);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Logger.Instance.Log("Loading content...");

            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            world = new World();
            Scene[] scenes = { new GameScene("DebugWorld", world) };

            sceneManager = new SceneManager(scenes);
            sceneManager.ChangeScene("DebugWorld");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Input.Instance.UpdateFirstValues();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Input.Instance.LeftDown())
            {
                Entity entity = EntityFactory.GetEntity(EntityTemplateCache.GetItem("Square"));


                world.AddEntity(entity, Input.Instance.MousePosition(Camera.Instance.Transform()));
                //worldInterface.CreateEntity("SentryTurret", Input.Instance.MousePosition(Camera.Instance.Transform()).X, Input.Instance.MousePosition(Camera.Instance.Transform()).Y);
            }

            sceneManager.Update();

            Input.Instance.UpdateLastValues();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix: camera.Transform());

            sceneManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}