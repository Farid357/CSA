using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class StandartLoader : ILoader
    {
        public void Load(int sceneIndex)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}
