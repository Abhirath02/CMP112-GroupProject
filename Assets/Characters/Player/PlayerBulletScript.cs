using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Vector2 lookDirection;
    private float lookAngle;
    [SerializeField] private GameObject bullet1;

    public float damage = 50;

    // rotate the bullet to direction of mouse once when fired
    void Start()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
    }

    // destroy bullet on collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "walls" || collision.gameObject.name == "maze")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
            Health target = collision.gameObject.GetComponent<Health>();
            if (target != null)
            {
              
                
                target.TakeDamage(damage);
            }
        }
    }
}