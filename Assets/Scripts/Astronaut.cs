using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour, IDamagable
{
    public float roationSpeed;
    private Animator animator;
    private GameInput gameInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float maxHealth = 100f;
    public float speed = 5f;
    public static float currentHealth;
    public RectTransform VirtualMouse;
    public GameObject bulletPrefab;
    public Transform bulletSpawner;

    void Start()
    {
        gameInput = GameInput.Instance;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }
    private void Update() {
     if(currentHealth<=0){
        Destroy(gameObject);
     }   
    }
    private void FixedUpdate() {
        HandleMovement();
        AimRoation();
        Debug.Log($"Mouse Position : {Input.mousePosition}");
    }
    private void HandleMovement()
    {
        Vector2 movedir = gameInput.GetMovementVectorNormalised();
        Debug.Log(movedir);
        // if(movedir.x >0)
        // {
        //     Flip(false);
        // }
        // else if(movedir.x <0)
        // {
        //     Flip(true);
        // }
        rb.velocity = new Vector2(movedir.x * speed * Time.deltaTime, movedir.y * speed * Time.deltaTime);
    }
    private void Flip(bool value)
    {
        spriteRenderer.flipX = value;
    }
    private void AimRoation(){

        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(VirtualMouse.position);
        cursorWorldPosition.z = 0; 
        Vector3 direction = cursorWorldPosition - transform.position;
        direction.z = 0; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,roationSpeed * Time.deltaTime);    
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

    void Shoot()
    {
        // Convert the cursor position from screen space to world space
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(VirtualMouse.position);
        cursorWorldPosition.z = 0; // Ensure the position is only in the 2D plane

        // Instantiate the bullet at the bullet spawner's position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);

        // Get the direction from the bullet spawner to the cursor
        Vector3 direction = cursorWorldPosition - bulletSpawner.position;
        direction.z = 0; // Ensure the direction is only in the 2D plane

        // Set the bullet's move direction
        bullet.GetComponent<Bullet>().SetMoveDirection(direction);
    }
}
