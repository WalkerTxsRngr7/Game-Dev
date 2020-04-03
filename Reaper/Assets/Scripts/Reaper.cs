using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody scythe;

    public bool thrown = false;
    public float throwForce = 10f;
    public Transform throwPoint;
    public Camera cam;
    Vector3 mousePos;
    private bool m_FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && thrown == false)    //throw scythe
        {
            Throw();
        }
        else if (Input.GetButtonDown("Fire2") && thrown == true)    //teleport to scythe
        {
            rb.transform.position = scythe.transform.position;
            thrown = false;
        }
        else if (thrown == false)   //hold scythe
        {
            scythe.transform.position = throwPoint.position;
            scythe.transform.rotation = rb.rotation;
        }

        
    }

    void FixedUpdate()
    {
        //change direction of Reaper depending on mouse position
        if (mousePos.x < rb.position.x && m_FacingRight != false) //facing left
        {
            Flip();
        }
        else if (mousePos.x >= rb.position.x && m_FacingRight != true) //facing right
        {
            Flip();
        }

        Vector2 lookDir = mousePos - rb.position;

        //change angle of throwpoint for scythe
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        throwPoint.transform.rotation = Quaternion.Euler(0,0,angle);
    }

    //flip Reaper to face right or left
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //throw the scythe
    void Throw()
    {
        //GameObject scythe = Instantiate(scythePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = scythe.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.right * throwForce, ForceMode.Impulse);
        thrown = true;
    }
}
