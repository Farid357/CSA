using UnityEngine;

namespace GameLogic
{
    [System.Serializable]
    public class BonusMovement : MonoBehaviour
    {
        public int Chance => _chance;

        [SerializeField, Min(0)] private int _chance;

        private const int Speed = 3;
        private const int _downEndOfScreen = -12;

        private void FixedUpdate()
        {
            transform.Translate(Vector2.down * Speed * Time.fixedDeltaTime);
            TryDestroy();
        }
        private void TryDestroy()
        {
            if (transform.position.y < _downEndOfScreen)
            {
               gameObject.SetActive(false);
            }
        }
    }
}
