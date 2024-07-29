using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_PowerUp : MonoBehaviour
{
    public Transform destroyer;
    Rigidbody2D rb;

    [SerializeField] private float fallSpeed = 1f;

    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Vector2 moveDirection = ((Vector2)destroyer.position - (Vector2)transform.position).normalized;

        // Apply the velocity to move the asteroid towards the center
        rb.velocity = moveDirection * fallSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Distroyer" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Spaceship")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Distroyer"){
            Destroy(gameObject);
        }
    }
}
