using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float maxHealth;
    private float currentHealth;
    public Slider healthBar;

    public float knockbackForce = 5f;
    private bool isStunned = false;
    private Rigidbody2D rb;

    public GameOverScreen gameOverScreen;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // prevent overheal

        if (healthBar != null)
            healthBar.value = currentHealth;
    }

    [System.Obsolete]
    public void TakeDamage(float amount, Vector2 hitDirection)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;
        // Apply knockback if Rigidbody exists
        if (rb != null)
        {
            rb.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);
            StartCoroutine(StopMovementTemporarily(0.3f));
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    [System.Obsolete]
    IEnumerator StopMovementTemporarily(float duration)
    {
        if (rb != null)
        {
            isStunned = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;  // temporarily ignore physics
            yield return new WaitForSeconds(duration);
            rb.isKinematic = false;
            isStunned = false;
        }
    }

    void Die()
    {
        Debug.Log("Player Died!"); // already shows
        if (gameOverScreen != null)
        {
           
            gameOverScreen.TriggerGameOver();
        }

        Destroy(gameObject);
    }
}