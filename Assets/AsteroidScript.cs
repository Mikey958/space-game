using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float minSpeed, maxSpeed; // Speed of the asteroid
    public float minSize, maxSize; // Size range for the asteroid
    public GameObject asteroidExplosion; // Prefab for explosion effect
    public GameObject shipExplosion; // Prefab for ship explosion effect

    float size; // Size of the asteroid

    void Start()
    {
        size = Random.Range(minSize, maxSize);
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed; // Random rotation speed 
        float speed = Random.Range(minSpeed, maxSpeed); // Random speed between min and max
        Asteroid.linearVelocity = new Vector3(0, 0, -speed);

        transform.localScale *= size; // Set the size of the asteroid
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundry")
        {
            return; // Ignore collisions with the game boundary
        }

        Destroy(other.gameObject); // Destroy the laser
        Destroy(gameObject); // Destroy the asteroid

        GameObject explosion = Instantiate(asteroidExplosion, transform.position, Quaternion.identity); // Create explosion effect for asteroid
        explosion.transform.localScale *= size; // Scale the explosion effect to match the asteroid size
        if (other.tag == "Player")
        {
            Instantiate(shipExplosion, other.transform.position, Quaternion.identity); // Create explosion effect for ship
            GameControllerScript.instance.GameOver(); // Trigger game over
        }
        if (other.tag == "Laser")
        {   
            GameControllerScript.instance.increaseScore(10); // Increase the score by 1
        }
    }
}
