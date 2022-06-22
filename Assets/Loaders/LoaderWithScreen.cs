using UnityEngine.SceneManagement;
using UnityEngine;

namespace GameLogic
{
    public sealed class LoaderWithScreen : ILoader
    {
        private SceneData _loaderScene;
        private int _sceneIndex;
        private AsyncOperation _loadScreen;

        public LoaderWithScreen(SceneData loaderScene)
        {
            _loaderScene = loaderScene;
        }

        public void Load(int sceneIndex)
        {
            _loadScreen = SceneManager.LoadSceneAsync(_loaderScene.Name, LoadSceneMode.Additive);
            _sceneIndex = sceneIndex;
            _loadScreen.completed += LoadNext;
        }

        private void LoadNext(AsyncOperation operation)
        {
            SceneManager.LoadSceneAsync(_sceneIndex);
            _loadScreen.completed -= LoadNext;
        }
    }
}
