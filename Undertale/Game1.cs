using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Undertale.Scripts;
using Undertale.Scripts.Backend;
using Undertale.Scripts.Scenes;

namespace Undertale
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        

        Texture2D texture;
        private SceneManager sceneManager;

        public Input input;

        

        private RenderTarget2D _nativeRenderTarget;
        private RenderTarget2D _nativeUIRenderTarget;

        private int internalResolutionW = 320;
        private int internalResolutionH = 240;

        private int windowW = 640;
        private int windowH = 480;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            

            sceneManager = new SceneManager();
            input = new Input();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            //Changing the Game's Resolution
            _graphics.PreferredBackBufferWidth = windowW;
            _graphics.PreferredBackBufferHeight = windowH;
            _nativeRenderTarget = new RenderTarget2D(_graphics.GraphicsDevice, internalResolutionW, internalResolutionH);

            _nativeUIRenderTarget = new RenderTarget2D(_graphics.GraphicsDevice, internalResolutionW, internalResolutionH);

            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sceneManager.InitializePersistentScenes(Content);
            sceneManager.playerObjects.Load();

            sceneManager.AddScene(new TiledScene(Content));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            sceneManager.GetCurrentScene().Update(gameTime);
            sceneManager.playerObjects.Update(gameTime);

            input.UpdateInputs();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
            

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            GraphicsDevice.Clear(Color.Black);

            sceneManager.GetCurrentScene().Draw(_spriteBatch);
            sceneManager.playerObjects.Draw(_spriteBatch);

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(_nativeUIRenderTarget);

            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Transparent);

            sceneManager.GetCurrentScene().DrawUI(_spriteBatch);

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_nativeRenderTarget, new Rectangle(0, 0, windowW, windowH), Color.White);
            _spriteBatch.Draw(_nativeUIRenderTarget, new Rectangle(0, 0, windowW, windowH), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}