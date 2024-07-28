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
}
