using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public sealed class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneNameSaved;

    private readonly LevelNameData _levelName = new LevelNameData();

    private void Start()
    {
        if (!string.IsNullOrEmpty(_sceneNameSaved))
        {
            StartCoroutine(AddScene(_sceneNameSaved));
        }
    }
    public void StartLoad()
    {
        if (!string.IsNullOrEmpty(_levelName.GetName()))
        {
            StartCoroutine(Load(_levelName.GetName()));
        }
    }
    private IEnumerator Load(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            yield return StartCoroutine(Unload());
            yield return StartCoroutine(UnloadResources());
        }
        yield return StartCoroutine(AddScene(sceneName));
    }
    private IEnumerator AddScene(string name)
    {
        AsyncOperation addOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

        while (!addOperation.isDone)
        {
            yield return null;
        }
        _sceneNameSaved = name;

    }
    private IEnumerator Unload()
    {
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(_sceneNameSaved);

        while (!unloadOperation.isDone)
        {
            yield return null;
        }
    }
    private IEnumerator UnloadResources()
    {
        AsyncOperation unloadResourcesOperation = Resources.UnloadUnusedAssets();

        while (!unloadResourcesOperation.isDone)
        {
            yield return null;
        }
    }

}
