using UnityEngine;
using System.Collections;

public class StripScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    Vector3 startPosition;
    Vector2 _savedOffset;

    void Start()
    {
        _savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
        startPosition = transform.position;
    }

    void Update()
    {
        var newPosition = Mathf.Repeat(Time.time*scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.back*newPosition;

        var x = Mathf.Repeat(Time.time*scrollSpeed, tileSizeZ*4) / tileSizeZ;
        x = Mathf.Floor(x) / 4;

        var offset = new Vector2(x, _savedOffset.y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    void OnDisable()
    {
        // Reset the offset to the startup value.
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", _savedOffset);
    }
}