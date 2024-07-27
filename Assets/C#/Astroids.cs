using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
    public Transform destroyer;

    Rigidbody2D rb;
    [SerializeField] private float fallSpeed = 1f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Distroyer"){
            Destroy(gameObject);
        }
    }

    private void Update() {
        Vector2 moveDirection = ((Vector2)destroyer.position - (Vector2)transform.position).normalized;

        // Apply the velocity to move the asteroid towards the center
        rb.velocity = moveDirection * fallSpeed;
    }
}
