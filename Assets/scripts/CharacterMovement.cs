using UnityEngine;

public class SwipeControls3D : MonoBehaviour
{
    public float swipeThreshold = 40f;
    public float movementSpeed = 100f;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    public float jumpForce = 8f; // Adjust the jump force as needed
    public float gravity = -20f;
    private Vector3 velocity;

   

    private void Start()
    {
      
    }

    private void Update()
    {
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

    private void DetectSwipe()
    {
        Vector2 swipeDelta = touchEndPos - touchStartPos;

        if (Mathf.Abs(swipeDelta.x) > swipeThreshold)
        {
            if (swipeDelta.x > 0)
            {
                // Right swipe
                Debug.Log("Right swipe detected");
                MoveCharacter(Vector3.right*15);
            }
            else
            {
                // Left swipe
                Debug.Log("Left swipe detected");
                MoveCharacter(Vector3.left*15);
            }
        }

        if (Mathf.Abs(swipeDelta.y) > swipeThreshold)
        {
            if (swipeDelta.y > 0)
            {
                // Up swipe
                Debug.Log("Up swipe detected");
                Jump();
            }

        }
    }

    private void MoveCharacter(Vector3 direction)
    {
        // Translate the character's position in the given direction
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        // jump controls
    }

 
}
