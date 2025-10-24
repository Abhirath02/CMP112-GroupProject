using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float horizontal;
    private float vertical;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Player_running_back");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetTrigger("Player_idle_back");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKeyUp(KeyCode.A))
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKeyUp(KeyCode.D))
            {

            }
        }
    }
}
