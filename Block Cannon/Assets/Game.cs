using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [Header("Main game code")]
    //public Text scoreGT;
    public GameObject rockYPrefab;
    public GameObject rockRPrefab;
    public Camera camMain;
    public Camera camCircle;
    public static bool yPrev = true;

    // Use this for initialization
    void Start () {
        camMain.enabled = true;
        camCircle.enabled = false;
        GameObject rockYellow = Instantiate(rockYPrefab);

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("View"))
        {
            camMain.enabled = !camMain.enabled;
            camCircle.enabled = !camCircle.enabled;
        }
	}

    
}
