using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;
  

    public int laneNo = 2; 
    public float horVelocity = 0f;
    public string controlLocked = "no";  // a lock - when player is swiped to a place then until he reaches his position-
                                         // -swipe is locked
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("chal gya");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horVelocity, 0, 4);

        if((Input.GetKeyDown(moveL) && (laneNo>1)&&(controlLocked =="no"))) // it cannot move further left from first lane
        {
            Debug.Log("left");
            horVelocity = -2f;
            StartCoroutine(stopSlide());
            laneNo -= 1;
            controlLocked = "yes";
        }
        if ((Input.GetKeyDown(moveR) && (laneNo<3) && (controlLocked == "no"))) // it cannot move further right from first lane
        {
            Debug.Log("right");
            horVelocity = 2f;
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
            Destroy(gameObject);
        }
    }
    IEnumerator stopSlide()
    {
        Debug.Log("the below function worked");
        yield return new WaitForSeconds(0.35f); // w8 for half a second
        horVelocity = 0f;            // stop the horizontal velocity
        controlLocked = "no";
    }
}
