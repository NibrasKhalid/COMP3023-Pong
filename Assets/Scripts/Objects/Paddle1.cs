using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle1 : MonoBehaviour
{
    
    public float moveSpeed = 5.0f;
    public float yAxis = 5.0f;

    private Vector2 moveInput;
    private Rigidbody2D rBody;

    private void Awake(){
        rBody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        float moveY = moveInput.y * moveSpeed;
        rBody.linearVelocity = new Vector2(0f, moveY);

        float clampedY = Mathf.Clamp(transform.position.y, -yAxis, yAxis);
        transform.position = new Vector2(transform.position.x, clampedY);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }
}
