using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

namespace GameLogic
{
    public sealed class ButtonOutline : MonoBehaviour
    {
        [SerializeField] private Outline[] _interactables;

        private const float _xSize = 2.89f;
        private const float _ySize = 2.07f;

        public void OnClick()
        {
            Vector2 size = new(_xSize, _ySize);
            var outline = GetComponent<Outline>();
            SetOutlineSize(outline, size);
            OffOthers(_interactables.Where(i => i != outline));
        }
        private void OffOthers(IEnumerable<Outline> outlines)
        {
            foreach (var outline in outlines)
            {
                SetOutlineSize(outline, new Vector2(0, 0));
            }
        }
        private void SetOutlineSize(Outline outline, Vector2 size)
        {
            outline.effectDistance = size;
        }
    }
}
