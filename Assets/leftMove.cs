using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class leftMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler //used to detect the inputs on UI elements
                                                                              // i.e. button )
{
    public GameObject player;
    bool isPressed = false;
    public float Force;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            player.transform.Translate(Force * Time.deltaTime,0,0); // takes x,y and z to translate the player
        }
    }
}
