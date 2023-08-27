using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //public KeyCode moveL;
    //public KeyCode moveR;
    //public KeyCode jump;

    //private Touch touch;

    //public float moveSpeed = 0.01f;


    //public int laneNo = 2; 
    //public string controlLocked = "no";  // a lock - when player is swiped to a place then until he reaches his position-
                                         // -swipe is locked

    public Transform boomObj;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        // GetComponent<Rigidbody>().velocity = new Vector3(0,0, GMscript.forward); //we made a static variable in GM 
        
     
        //if((Input.GetKeyDown(moveL) && (laneNo>-7)&&(controlLocked =="no"))) // it cannot move further left from first lane
        //{
        //    Debug.Log("left");
        //    GMscript.horVelocity = -7f;
        //    StartCoroutine(stopSlide());
        //    laneNo -= 1;
        //    controlLocked = "yes";
        //}
        //if ((Input.GetKeyDown(moveR) && (laneNo<7) && (controlLocked == "no"))) // it cannot move further right from first lane
        //{
        //    Debug.Log("right");
        //    GMscript.horVelocity = 7f;
            
        //    StartCoroutine(stopSlide()); // goto the below named function/ ENUMERATOR
        //    laneNo += 1;
        //    controlLocked = "yes";
        //}

    }
   
    // adding a pit 
    void OnCollisionEnter(Collision other)

    {

        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);  // destroy the player
            GMscript.forward=0;
            GMscript.horVelocity=0;
            GMscript.vertVelocity = 0;
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
     
        if(other.gameObject.name == "gameEndTrig")
        {
            GMscript.gameCompStatus = "Success!";
            SceneManager.LoadScene("levels 3 and 4");
        }
   
        if (other.gameObject.name == "puddle")
        {
            Debug.Log("Add puddle script here");
        }
    }
    //IEnumerator stopSlide()
    //{
    //    Debug.Log("the below function worked");
    //    yield return new WaitForSeconds(0.2f); // w8 for half a second
    //    GMscript.horVelocity = 0f;// stop the horizontal velocity
    //    GMscript.forward = 10f;
    //    controlLocked = "no";
    //}
}
