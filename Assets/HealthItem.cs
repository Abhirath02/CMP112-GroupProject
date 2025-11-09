using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health player = other.GetComponent<Health>();
            if (player != null)
            {
                player.Heal(healAmount);
            }

            Destroy(gameObject); // remove the prefab after pickup
        }
    }
}
