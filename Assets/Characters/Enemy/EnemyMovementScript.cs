using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (animator == null || rb == null)
        {
            Debug.LogError("Missing Animator or Rigidbody2D on " + gameObject.name);
            return;
        }
        Vector2 direction = rb.linearVelocity;
        //moving right
        if (direction.x > 0)
        {
            animator.SetInteger("direction", 2);
            //Debug.Log("moving right");
        }
        //moving left
        else if (direction.x < 0)
        {
            animator.SetInteger("direction", 4);
            //Debug.Log("moving left");
        }
        //moving up
        else if (direction.y > 0)
        {
            animator.SetInteger("direction", 4);
            //Debug.Log("moving up");
        }
        //moving down
        else if (direction.y < 0)
        {
            animator.SetInteger("direction", 1);
            //Debug.Log("moving down");
        }
        else
        {
            //Debug.Log("not moving");
        }
    }
}
