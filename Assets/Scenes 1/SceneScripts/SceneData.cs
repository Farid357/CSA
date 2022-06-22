using UnityEditor;
using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "Scene", menuName = "ScenePrefab")]
    public sealed class SceneData : ScriptableObject, ISerializationCallbackReceiver
    {
        public string Name => _sceneName;
#if UNITY_EDITOR

        [SerializeField] private SceneAsset _scene;
#endif
        [SerializeField] private string _sceneName;

        public void OnAfterDeserialize()
        {

        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (_scene != null)
                _sceneName = _scene.name;
#endif
        }
    }
}
