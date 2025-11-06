using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    lastPosition = transform.position;
}

void Update()
{
    Vector2 currentPosition = transform.position;
    Vector2 direction = currentPosition - lastPosition;

    // small movement damping if needed
    float threshold = 0f;

    if (direction.magnitude > threshold)
    {
        // play animation based on dominant axis
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // right
            if (direction.x > 0) animator.SetInteger("direction", 2);
            // left
            else animator.SetInteger("direction", 4);
        }
        else
        {
            // up
            if (direction.y > 0) animator.SetInteger("direction", 3);
            // down
            else animator.SetInteger("direction", 1);
        }
    }
    lastPosition = currentPosition;
}
}
