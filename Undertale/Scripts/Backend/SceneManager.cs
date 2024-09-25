
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


namespace Undertale.Scripts.Backend
{
    public class SceneManager
    {
        public static SceneManager instance;
        
        
        
        private readonly List<IScene> sceneStack;
        private IScene BattleScene;


        public PersistentScene playerObjects { get; private set; }

        public void InitializePersistentScenes(ContentManager content)
        {
            playerObjects = new PersistentScene();
        }

        public void SetBattleScene(IScene target)
        {
            this.BattleScene = target;
        }

        public SceneManager()
        {
            instance = this;
            sceneStack = new List<IScene>();
        }

        public void AddScene(IScene scene)
        {
            scene.Load();

            sceneStack.Add(scene);
        }

        public void RemoveScene()
        {
            sceneStack.RemoveAt(0);
        }

        public IScene GetCurrentScene()
        {
            return sceneStack[0];
        }
    }
}
