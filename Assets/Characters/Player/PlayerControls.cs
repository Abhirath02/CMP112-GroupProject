using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float originalSpeed; // define originalSpeed variable
    private float horizontal;
    private float vertical;
    [SerializeField] private Animator animator;
    private bool isOverLapping = false;
    private bool gunEquiped = false;
    [SerializeField] private float fireRate;
    [SerializeField] private float dashCooldown;
    private float nextDashTime = 0f;
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashDuration;
    private float nextFireTime = 0f;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private float bulletSpeed;

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
        if (Input.GetKey(KeyCode.W) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsRunningBack", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsRunningBack", false);
        }
        // S key
        if (Input.GetKey(KeyCode.S) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsRunningFront", true);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsRunningFront", false);
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
        // D key
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.W)))
        {
            animator.SetBool("IsRunningRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsRunningRight", false);
        }

        // dash mechanic
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextDashTime)
        {
            nextDashTime = Time.time + dashCooldown;
            StartCoroutine(Dash());
        }

        // shooting mechanic
        if (gunEquiped == true && (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)))
        {
            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;
                Vector2 direction = (mousePos - transform.position).normalized;
                GameObject newBullet = Instantiate(bulletObject, transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
            }
        }

        //destroy other object when overlapping and key pressed
        if (isOverLapping == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(GameObject.FindWithTag("gun1"));
            gunEquiped = true;
        }
    }

     //check if player overlaping gun
    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("gun1"))
        {
            isOverLapping = true;
        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.CompareTag("gun1"))
        {
            isOverLapping = false;
        }
    }
    
    public void SpeedBoost(float multiplier, float duration)
    {
        StopAllCoroutines();              // cancel any existing boost
        StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        speed = originalSpeed * multiplier;  // boosts speed
        yield return new WaitForSeconds(duration);  // wait till the boost effect ends
        speed = originalSpeed;                 // reset speed to original
    }

    public IEnumerator Dash()
    {
        Vector2 dashDirection = new Vector2(horizontal, vertical).normalized;
        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            transform.Translate(dashDirection * (dashDistance / dashDuration) * Time.deltaTime, Space.World);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    internal void Healing(float healAmount)
    {
        throw new NotImplementedException();
    }
}