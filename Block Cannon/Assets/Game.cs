using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public Text scoreGT;
    public GameObject rockYellowPrefab;
    public GameObject rockRedPrefab;
    //default speed of the rock
    public float speed = 1f;


    // Use this for initialization
    void Start () {
        GameObject rockYellow = Instantiate<GameObject>(rockYellowPrefab);
        
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
