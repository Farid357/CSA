using UnityEngine;

[RequireComponent(typeof(Camera))]
public sealed class WidthCamera : MonoBehaviour
{
    private const float Width = 1080f;
    private const float HalfSizeInPixel = 200f;
    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = Width * Screen.height / Screen.width / HalfSizeInPixel;
    }
    
}
