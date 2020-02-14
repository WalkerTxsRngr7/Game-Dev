using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    public GameObject rockYPrefab;
    public GameObject rockRPrefab;
    public GameObject pointer;
    //public bool yPrev = true;
    public bool rockSpawned = false;
    public Rigidbody rb;
    public bool thrown = false;
    //default speed of the rock
    public float speed = 1f;
    public float aimSpeed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float throwForce = 20f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        float actualSpeed = rb.velocity.magnitude;

        if (!thrown)
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            float rotation = Input.GetAxis("Rotate") * rotationSpeed;
            float translation = Input.GetAxis("Horizontal") * aimSpeed;
            float power = Input.GetAxis("Vertical") * 5f;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            power *= Time.deltaTime;

            // Rotate around our y-axis
            transform.Rotate(0, 0, rotation);

            // Move translation along the object's z-axis
            transform.Translate(translation, 0, 0);

            // Change power
            throwForce += power;


            if (Input.GetButtonDown("Fire1"))
            {
                thrown = true;
                Throw();
                
            }
        }
        else if (actualSpeed < 0.01 && !rockSpawned) // or falls off
        {
            //rb.velocity = new Vector3(0, 0, 0);
            //Or
            //rb.constraints = RigidbodyConstraints.FreezeAll;
            SpawnRock();
            rockSpawned = true;
        }

        
    }

    void Throw()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * throwForce, ForceMode.Impulse);
        pointer.active = false;
    }

    //Spawn rock to throw, alternating teams
    public void SpawnRock()
    {
        if (Game.yPrev)
        {
            GameObject rockRed = Instantiate(rockRPrefab);
            Game.yPrev = false;
        }
        else
        {
            GameObject rockYellow = Instantiate(rockYPrefab);
            Game.yPrev = true;
        }

    }
}
