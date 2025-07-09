using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed; // Speed of the laser
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
