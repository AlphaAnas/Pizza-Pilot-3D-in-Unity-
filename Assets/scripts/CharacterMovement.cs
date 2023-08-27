using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SwipeControls3D : MonoBehaviour //used to detect the inputs on UI elements
                                             // i.e. button )
{


    public float swipeThreshold = 40f;
    public float movementSpeed = 80f;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    public bool rotate = false;
    private int laneNo = 0;

    Rigidbody rb;
    public float jumpPower =500f;
    Vector2 startPoint, endPoint;
    bool canJump;
    public float rotationSpeed = 90f;

    private float originalYVelocity;
    private float yourWaitTimeInSeconds = 0.05f;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        jumpPower = 1000f;

    }

    private void Update()

    {
      
        // GetComponent<Rigidbody>().velocity = new Vector3(0, 0, GMscript.forward);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPoint = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPoint = Input.GetTouch(0).position;
        }
        if (endPoint.y > startPoint.y && rb.velocity.y == 0)
        {
            canJump = true;
            startPoint = Vector2.zero;
            endPoint = Vector2.zero;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    touchEndPos = touch.position;
                    DetectSwipe();
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "rotateTrig")
        {
            rotate = true;
        }
    }
    private void RotateCharacter()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    private void DetectSwipe()
    {
        Vector2 swipeDelta = touchEndPos - touchStartPos;

        if (Mathf.Abs(swipeDelta.x) > swipeThreshold)
        {
            if (swipeDelta.x > 0)
            {
                if (rotate)
                {
                    RotateCharacter();
                }
                else
                {
                    // Right swipe
                    if (laneNo < 3)
                    {
                        Debug.Log("Right swipe detected");
                        laneNo += 1;
                        MoveCharacter(Vector3.right * 10);
                    }
                }
            }
            else
            {
                // Left swipe
                if (laneNo > -3)
                {
                    Debug.Log("Left swipe detected");
                    laneNo -= 1;
                    MoveCharacter(Vector3.left * 10);
                }
            }
        }

    }

    private void MoveCharacter(Vector3 direction)
    {
        // Translate the character's position in the given direction

        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movementSpeed * Time.fixedDeltaTime, rb.velocity.y, GMscript.forward);
        if (canJump)
        {
            //StartCoroutine(JumpCoroutine());
            rb.AddForce(Vector3.up * jumpPower);
            canJump = false;

        }


    }
    //private IEnumerator JumpCoroutine()
    //{
    //    // Increase y velocity
    //    rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);

    //    // Wait for a certain time
    //    Debug.Log("yahan tk");
    //    yield return new WaitForSeconds(yourWaitTimeInSeconds);
        

    //    // Restore y velocity to normal
    //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
    //    Debug.Log("yeh xhala");
    //    canJump = false;
    //}
}



