using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    //public Text scoreGT;
    public GameObject rockYPrefab;
    public GameObject rockRPrefab;
    public Camera camMain;
    public Camera camCircle;
    public static bool yPrev = false;

    // Use this for initialization
    void Start () {
        camMain.enabled = true;
        camCircle.enabled = false;
        SpawnRock();

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("View"))
        {
            camMain.enabled = !camMain.enabled;
            camCircle.enabled = !camCircle.enabled;
        }
	}

    //Spawn rock to throw, alternating teams
    public void SpawnRock()
    {
        if (yPrev)
        {
            GameObject rockRed = Instantiate<GameObject>(rockRPrefab);
            yPrev = false;
        }
        else
        {
            GameObject rockYellow = Instantiate<GameObject>(rockYPrefab);
            yPrev = true;
        }
        
    }
}
