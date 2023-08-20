using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;
  

    public int laneNo = 2; 
    public float horVelocity = 0f;
    public string controlLocked = "no";  // a lock - when player is swiped to a place then until he reaches his position-
                                         // -swipe is locked

    public Transform boomObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horVelocity,GMscript.vertVelocity, 7); //we made a static variable in GM 
                                                                                                 // script and are able to access it here

        if((Input.GetKeyDown(moveL) && (laneNo>-10)&&(controlLocked =="no"))) // it cannot move further left from first lane
        {
            Debug.Log("left");
            horVelocity = -5f;
            StartCoroutine(stopSlide());
            laneNo -= 1;
            controlLocked = "yes";
        }
        if ((Input.GetKeyDown(moveR) && (laneNo<10) && (controlLocked == "no"))) // it cannot move further right from first lane
        {
            Debug.Log("right");
            horVelocity = 5f;
            StartCoroutine(stopSlide()); // goto the below named function/ ENUMERATOR
            laneNo += 1;
            controlLocked = "yes";
        }
    }

    // adding a pit 
    void OnCollisionEnter(Collision other)

    {

        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);  // destroy the player
            GMscript.zValueAdjustment = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GMscript.gameCompStatus = "Failed";
        }
        // if player collides with coin
        if (other.gameObject.name == "Coin")
        {
            Debug.Log("loaded");
            Destroy(other.gameObject); // destroy the object it collides with
            GMscript.coinTotal += 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "rampbottomTrig")
        {
            GMscript.vertVelocity = 2;
            Debug.Log(GMscript.vertVelocity);
        }
        if (other.gameObject.name == "ramptopTrig")
        {
            GMscript.vertVelocity = 0;
            Debug.Log(GMscript.vertVelocity);
        }
        if(other.gameObject.name == "gameEndTrig")
        {
            GMscript.gameCompStatus = "Success!";
            SceneManager.LoadScene("LevelComplete");
        }
        if (other.gameObject.name == "roadstartTrig")
                {
            GMscript.vertVelocity = 0;

        }
        if (other.gameObject.name=="rampEndTrig")
        {
            GMscript.vertVelocity = -2;
        }
        if (other.gameObject.name == "puddle")
        {
            Debug.Log("Add puddle script here");
        }
    }
    IEnumerator stopSlide()
    {
        Debug.Log("the below function worked");
        yield return new WaitForSeconds(0.25f); // w8 for half a second
        horVelocity = 0f;            // stop the horizontal velocity
        controlLocked = "no";
    }
}
