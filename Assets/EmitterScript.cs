using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject[] Asteroids;
    public float minDelay, maxDelay;

    float nextLaunchTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
        {
            return;
         }
        if (Time.time > nextLaunchTime)
        {
            float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);

            int randomIndex = Random.Range(0, Asteroids.Length);
            GameObject Asteroid = Asteroids[randomIndex];

            Instantiate(Asteroid, new Vector3(positionX, 0, transform.position.z), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
