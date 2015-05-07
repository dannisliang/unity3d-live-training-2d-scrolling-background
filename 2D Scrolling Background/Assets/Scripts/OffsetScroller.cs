using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour
{
    public float scrollSpeed;

    Vector2 _savedOffset;


    // Use this for initialization
    void Start()
    {
        _savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        var y = Mathf.Repeat(Time.time*scrollSpeed, 1);
        var offset = new Vector2(_savedOffset.x, y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        // Reset the offset to the startup value.
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", _savedOffset);
    }
}