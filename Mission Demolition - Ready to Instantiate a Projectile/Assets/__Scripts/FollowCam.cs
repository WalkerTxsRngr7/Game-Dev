using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;       //static point of interest
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;                  //the desired z pos of the camera

    // Start is called before the first frame update
    void Awake()
    {
        camZ = this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (POI == null) return;

        //get the position of the poi
        Vector3 destination = POI.transform.position;
        //limit the x & y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //interpolate from the currenct camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //force destination.z to be camz to keep the camera far enough away
        destination.z = camZ;
        //set the camera to the destination
        transform.position = destination;
        //set the orthographic size of the camera to keep ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }
}
