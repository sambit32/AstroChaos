using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Spaceship : MonoBehaviour, IDamagable
{
    //private Animator animator;
    private GameInput gameInput;
    private Rigidbody2D rb;
    

    public float speed = 100f;
    public float rotSpeed = 180f;
    void Start()
    {
        gameInput = GameInput.Instance;
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleRotation()
    {
        float rotationInput = gameInput.GetSpaceshipRotation();
        float rotationAmount = rotationInput * rotSpeed * Time.deltaTime;
        rb.rotation -= rotationAmount;
    }

    private void HandleMovement()
    {
        Vector2 movedir = gameInput.GetSpaceshipMovementVectorNormalised();
        Vector2 velocity = transform.up * movedir.y * speed * Time.deltaTime;
        rb.velocity = velocity;
    }

    public void Damage(float damageAmount)
    {
        Astronaut.currentHealth -= damageAmount;
    }
}
