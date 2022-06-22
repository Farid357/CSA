using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public sealed class SceneLoaderByIndex : MonoBehaviour, ILoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private ScreenFade _screen;
        [SerializeField] private SceneData _loaderScene;
        private ILoader[] _loaders;

        private void Start()
        {
            _loaders = new ILoader[]
            {
                new StandartLoader(),
                new FadeLoader(_screen),
                new LoaderWithScreen(_loaderScene)
            };
        }

        public void Load(int sceneIndex)
        {
            var modeIndex = (int) _mode;
            _loaders[modeIndex].Load(sceneIndex);
        }
    }
    public enum SceneLoadMode
    {
        Simple,
        Fade,
        WithLoadScreen
    }
    public interface ILoader
    {
        public void Load(int sceneIndex);
    }
}
