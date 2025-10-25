using UnityEngine;

public class speedItem : MonoBehaviour
{
    public float speedMultiplier;
    public float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.SpeedBoost(speedMultiplier, duration);
            }

            Destroy(gameObject); // remove the prefab after pickup
        }
    }
}
