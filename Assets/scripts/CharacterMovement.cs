using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // this is used to save values of Enum as below

public enum SIDE {Left, Mid, Right }    // we made a new data type like int and its values are in braces
                                        // and can be called like SIDE value = SIDE.Left;
public class CharacterMovement : MonoBehaviour
{
    public SIDE CurrSide = SIDE.Mid; // default value of player is middle
    float newXPos = 0f;
    public bool swipeLeft= false;
    public bool swipeRight= false;
    public float XValue;
    private CharacterController m_char;

    // Start is called before the first frame update
    void Start()
    {   
        m_char = GetComponent<CharacterController>();   //used to move the character
        transform.position = Vector3.zero;  // initial pos to (0,0,0)
    }

    // Update is called once per frame
    void Update()
    {
        swipeLeft= Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if(swipeLeft)
        {
            if(CurrSide == SIDE.Mid)
            {
                newXPos = -XValue;
            }
            else if(CurrSide == SIDE.Right)
            {
                newXPos = 0;
            }
        }
        else if (swipeRight)
        {
            if (CurrSide == SIDE.Mid)
            {
                newXPos = XValue;
            }
            else if (CurrSide == SIDE.Left)
            {
                newXPos = 0;
            }
        }
        m_char.Move((newXPos - transform.position.x) * Vector3.right);

    }  
}
