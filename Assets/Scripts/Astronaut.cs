using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    private Animator animator;
    private GameInput gameInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float speed = 5f;
    public Transform VirtualMouse;
    void Start()
    {
        gameInput = GameInput.Instance;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        Debug.Log($"Mouse Position : {Input.mousePosition}");
    }


    private void HandleMovement()
    {
        Vector2 movedir = gameInput.GetMovementVectorNormalised();
        Debug.Log(movedir);
        if(movedir.x >0)
        {
            Flip(false);
        }
        else if(movedir.x <0)
        {
            Flip(true);
        }
        rb.velocity = new Vector2(movedir.x * speed * Time.deltaTime, movedir.y * speed * Time.deltaTime);
    }

    private void Flip(bool value)
    {
        spriteRenderer.flipX = value;
    }
}
