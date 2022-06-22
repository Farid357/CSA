using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "Enemy Path", menuName = "Path data")]
    public sealed class PathData : ScriptableObject
    {
        public List<Vector2> Points => _points;
        [SerializeField] private List<Vector2> _points = new List<Vector2>();

#if UNITY_EDITOR
        [ContextMenu("Save path")]
        private void SavePoints()
        {
            var enemyPath = FindObjectOfType<EnemyPath>();
            _points = enemyPath.GetPathPoints();
            EditorUtility.SetDirty(this);
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }
        [ContextMenu("Load points")]
        private void LoadPoints()
        {
            var path = new GameObject();
            EnemyPath enemyPath = path.AddComponent<EnemyPath>();
            for (int i = 0; i < _points.Count - 1; i++)
            {
                var point = new GameObject($"Point{i}");
                point.transform.position = _points[i];
                enemyPath.Addpoint(point.transform);
            }
        }
#endif
    }
}
