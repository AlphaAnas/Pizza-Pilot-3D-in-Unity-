using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rightMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler //used to detect the inputs on UI elements
                                                                               // i.e. button )
{
    public GameObject player;
    bool isPressed = false;
    public float Force;

    public void OnPointerDown(PointerEventData eventData) //when button is pressed
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)//when button is released
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            player.transform.Translate(Force * Time.deltaTime, 0, 0); // takes x,y and z to translate the player
        }
    }
}
