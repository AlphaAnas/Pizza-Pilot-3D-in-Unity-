using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Rigidbody rb;
    private Vector2 startTouchPosition, endTouchPosition;
    private bool isPressed  = false;
    private float jumpAllowed = false;
    public float jumpForce;
    public float movementSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = 300f;
    }

    private void Update()
    {
        if(Input.TouchCount)
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, distance);
    }
}
