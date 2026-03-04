using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 8f;
    public float startX = 0f;
    public float startY = 4f;

    public float xSpeed;
    public Rigidbody2D rbody;
    public GameManager gameManager;
    public ScoreZone ScoreZone;

    private void Awake(){
        rbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        BallMovement();
    }

    private void BallMovement()
    {
        // using random to choose if the ball should launch to the left or right
        bool isRight = UnityEngine.Random.value >= 0.5f;

        // setting xVelocity to -1 for left and 1 for right
        float xVelocity = -1f;
        if (isRight)
        {
            xVelocity = 1f;
        }

        // using random to set the y velocity to a value between -1 and 1
        float yVelocity = UnityEngine.Random.Range(-1, 1);

        // setting the velocity of the ball based on the x and y velocities multiplied by the speed
        rbody.linearVelocity = new Vector2(xVelocity * speed, yVelocity * speed);
    }

    private void ResetBall()
    {
        // sets the position y to a random value between -1 and 1 along y axis
        float posY = UnityEngine.Random.Range(-1, 1);
        // sets the position x to the startX value (center of the screen)
        Vector2 newPosition = new Vector2(startX, posY);
        // updates the ball's position to the new position
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Compares zonetag for collision and retrieves the id of the spicific zone from the gameManager
        if (collision.CompareTag("Zone"))
        {
            ScoreZone zone = collision.GetComponent<ScoreZone>();
            if (zone != null && gameManager != null)
            {
                gameManager.OnScoreZoneBreached(zone.id);
            }
            // Destroy(gameObject);
            ResetBall();
            BallMovement();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            // Check to see if we hit the top or bottom of the paddle
            float offset = transform.position.y - collision.transform.position.y;

            // increaste the x speed a little bit on each hit
            float xSpeed = rbody.linearVelocity.x + speed/2f;

            // update y speed to increase the angle at which it reflects off the paddle (>5f will make it more vertical, <5f will make it more horizontal)
            float newY = offset * 5f;  

            // Set the new velocity based on the calculated x and y speeds
            rbody.linearVelocity = new Vector2(xSpeed, newY);
        }
    }
}
