using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
    //Fields set in Unity Inspector
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    //fields set dynamically
    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    private Rigidbody projectileRigidbody;
	void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }
	void OnMouseEnter () {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
	}
	
	// Update is called once per frame
	void OnMouseExit () {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
	}

    private void OnMouseDown()
    {
        //the player has pressed the mouse button while over slingshot
        aimingMode = true;
        //instantiate a projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        //start it at the launchpoint
        projectile.transform.position = launchPos;
        //set it to isKinematic for now
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        //if slingshot is not in aimingmode, don't run this code
        if (!aimingMode) return;

        //get the mouse position in 2d screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
        //limit mouseDelta to the radius of the slingshot sphere collider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            //the mouse has been released
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
        }
    }
}
