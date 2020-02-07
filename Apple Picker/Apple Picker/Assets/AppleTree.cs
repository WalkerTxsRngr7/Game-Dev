using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public GameObject flarePrefab;
    //speed of the apple tree moves
    public float speed = 1f;
    //distance where the apple tree turns around
    public float leftAndRightEdge = 10f;
    //chance the tree will change directions
    public float chanceToChangeDirections = 0.1f;
    //rate at which the apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start ()
    {
        //drop apples every second
        Invoke("DropApple", 2f);
        //GameObject flare = Instantiate<GameObject>(flarePrefab);
	}

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
        //GameObject flare = Instantiate<GameObject>(flarePrefab);
        //flare.transform.position = transform.position;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //change direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        } 
	}

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
