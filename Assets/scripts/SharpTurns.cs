using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    public float turnAngle = 90f;

    private bool isTurning;
    private Quaternion targetRotation;

    private void Update()
    {
        // Check for swipe input
        if (Input.GetMouseButtonDown(0))
        {
            float swipeDirection = Input.mousePosition.x < Screen.width / 2 ? -1f : 1f;
            targetRotation = transform.rotation * Quaternion.Euler(0f, swipeDirection * turnAngle, 0f);
            isTurning = true;
        }

        // Rotate the player towards the target rotation
        if (isTurning)
        {
            float step = turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

            // Check if the player has finished turning
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isTurning = false;
            }
        }

        // Move the player forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
