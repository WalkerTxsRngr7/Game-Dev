using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scythe : MonoBehaviour
{
    public int enemiesLeft = 0;
    public Text timerBox;
    public Text endTimerBox;
    private bool timerActive = true;

    private float timer = 0.0f;

    public bool TimerActive { get => timerActive;}


    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        endTimerBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            timerBox.text = timer.ToString("F2");
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
                timerBox.enabled = false;
                endTimerBox.enabled = true;
                endTimerBox.text = timer.ToString("F2") + " seconds";
            }
        }
    }
}
