using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField]private float speed = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public void OnMove(InputAction.CallbackContext ctx)
    {
        rb.linearVelocity = ctx.ReadValue<Vector2>() * speed;
    }
}
