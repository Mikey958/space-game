using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject MainLaserShot;
    public GameObject BasicLaserShot;
    public Transform[] MainLaserGuns;
    public Transform[] BasicLaserGuns;
    public float shotDelay;
    public float basicShotDelay;

    public float speed;
    public float tilt;
    Rigidbody Ship;
    public float xMin, xMax, zMin, zMax;

    float nextShotTime;
    float nextBasicShotTime;

    void Start()
    {
        Ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
        {
            return;
        }


        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Ship.linearVelocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float restrictedX = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float restrictedZ = Mathf.Clamp(Ship.position.z, zMin, zMax);
        Ship.position = new Vector3(restrictedX, 0, restrictedZ);

        Ship.rotation = Quaternion.Euler(Ship.linearVelocity.z * tilt, 0, -Ship.linearVelocity.x * tilt);


        
        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            foreach (Transform gun in MainLaserGuns)
            {
                Instantiate(MainLaserShot, gun.position, Quaternion.identity);
            }
            nextShotTime = Time.time + shotDelay;
        }

        if (Time.time > nextBasicShotTime && Input.GetButton("Fire2")) 
        {
            foreach (Transform gun in BasicLaserGuns)
            {
                Instantiate(BasicLaserShot, gun.position, Quaternion.identity);
            }
            nextBasicShotTime = Time.time + basicShotDelay;
        }
    
    
    }
}
