using UnityEngine;
using System.Collections.Generic;
using System;

namespace GameLogic
{
    public class EnemyPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> _pathPoints = new List<Transform>();

        private void Awake()
        {
            if (_pathPoints == null)
                throw new NullReferenceException("Path points is null!");
        }
        public void Addpoint(Transform point)
        {
            _pathPoints.Add(point);
        }
        public List<Vector2> GetPathPoints()
        {
            var points = new List<Vector2>();

            foreach (var point in _pathPoints)
            {
                points.Add(point.position);

            }
            return points;
        }
    }
}
