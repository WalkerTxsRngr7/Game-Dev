using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scythe : MonoBehaviour
{
    public int enemiesLeft = 4;
    public float timer = 0.0f;
    public Text textBox;
    public bool timerActive = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            textBox.text = timer.ToString("F2");
        }
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        //find out what hit the scythe hit
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Enemy")
        {
            Destroy(collidedWith);
            enemiesLeft--;
            if (enemiesLeft <= 0)
            {
                timerActive = false;
            }
        }
    }
}
