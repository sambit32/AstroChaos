using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    //private Animator animator;
    private GameInput gameInput;
    private Rigidbody2D rb;
    

    public float speed = 100f;
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
    }

    private void HandleMovement()
    {
        Vector2 movedir = gameInput.GetSpaceshipMovementVectorNormalised();
        Debug.Log(movedir);
        rb.velocity = new Vector2(movedir.x * speed * Time.deltaTime, movedir.y * speed * Time.deltaTime);
    }
}
