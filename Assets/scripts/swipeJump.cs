using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJumpWithoutController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower;
    Vector2 startPoint, endPoint;
    bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpPower = 300f;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpPower);
            canJump = false;
        }


    }
}


