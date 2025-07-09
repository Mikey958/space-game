using UnityEngine;

public class ScrollerScript : MonoBehaviour
{
    public float speed; // Speed of the scrolling
    Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Repeat(speed * Time.time, 200);
        startPosition.z = -offset;
        transform.position = startPosition;
    }
}
