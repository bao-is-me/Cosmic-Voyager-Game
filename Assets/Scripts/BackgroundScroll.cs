using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float height;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, height);
        transform.position = startPos + Vector3.down * newPos;
    }
}