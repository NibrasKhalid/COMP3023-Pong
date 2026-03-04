using UnityEngine;

public class AIOpponent : MonoBehaviour
{
    public Rigidbody2D ball;
    public float moveSpeed = 5f;
    public float yAxis = 5f;

    private void FixedUpdate()
    {
         // Target position: same X, ball's Y
        Vector3 target = new Vector3(transform.position.x, ball.position.y, transform.position.z);

        // Smoothly move toward that target
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * 0.02f);

        // Clamp so it stays on screen
        float clampedY = Mathf.Clamp(transform.position.y, -yAxis, yAxis);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
