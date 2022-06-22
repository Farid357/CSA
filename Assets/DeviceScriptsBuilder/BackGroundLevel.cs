using UnityEngine;
using System.Collections.Generic;
using System;

public sealed class BackGroundLevel : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;

    private float _offesetY;

    private void Start()
    {
        if (_sprites.Count > 0)
        {
            SetImagiesPosition();
        }
        else
        {
            throw new InvalidOperationException("Sprites count 0 or < 0! ");
        }
    }

    private void SetImagiesPosition()
    {
        transform.position = new Vector2(transform.position.x, Screen.safeArea.yMin);

        for (int i = 0; i < _sprites.Count - 1; i++)
        {
            UnityEngine.GameObject image = new UnityEngine.GameObject("Image", typeof(SpriteRenderer));
            image.GetComponent<SpriteRenderer>().sprite = _sprites[i];
            image.transform.SetParent(transform);
            image.transform.position = new Vector2(transform.position.x, transform.position.y + _offesetY);
            _offesetY += _sprites[i].bounds.size.y;
        }
    }
}
