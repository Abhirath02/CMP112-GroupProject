using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float originalSpeed; // define originalSpeed variable
    private float horizontal;
    private float vertical;
    [SerializeField] private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        transform.Translate(movement * speed * Time.deltaTime);
        // W key
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("IsRunningBack", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsRunningBack", false);
        }
        // A key
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsRunningLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsRunningLeft", false);
        }
        // S key
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsRunningFront", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsRunningFront", false);
        }
        // D key
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("IsRunningRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsRunningRight", false);
        }
    }
    public void SpeedBoost(float multiplier, float duration)
    {
        speed *= multiplier;               // multiplies the original speed
        Invoke("ResetSpeed", duration);       // automatically reset after duration
    }

    void ResetSpeed()
    {
        speed = originalSpeed;            // reset to normal speed
    }
}
