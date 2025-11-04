using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject enemy;
    private GameObject playerObject;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2 && CheckLineOfSight()==true)
        {
            timer = 0;
            shoot();
        }
    }

    //check if the line to playerObject is without obstacles
    bool CheckLineOfSight()
    {
        // Cast a line from enemy to playerObject
        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null) enemyCollider.enabled = false; // temporarily disable
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerObject.transform.position);
        if (enemyCollider != null) enemyCollider.enabled = true; // re-enable
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            return true;
        }
        return false;
    }

    void shoot()
    {
        Instantiate(bullet, enemy.transform.position, Quaternion.identity);
    }
}
