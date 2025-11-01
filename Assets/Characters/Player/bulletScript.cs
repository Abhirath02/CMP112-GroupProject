using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Vector2 lookDirection;
    private float lookAngle;
    [SerializeField] private GameObject bullet1;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
    }
}
