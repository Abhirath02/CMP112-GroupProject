using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private int bulletSpeed;

    public float damage = 25;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        float lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // destroy bullet on collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "walls" || collision.gameObject.name == "maze")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player")
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
