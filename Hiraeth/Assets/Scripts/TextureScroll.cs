using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    // Scroll main texture based on time
    // From Unity API

    public float scrollSpeed = 0.5f;
    public Vector2 scrollDirection = Vector2.zero;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offsetX = Time.time * scrollSpeed * scrollDirection.x;
        float offsetY = Time.time * scrollSpeed * scrollDirection.y;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}