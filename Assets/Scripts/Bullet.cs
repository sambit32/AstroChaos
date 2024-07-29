using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject expolFX;
    public float damageAmount = 15f;
    Rigidbody2D rb;

    public float speed = 10f;
    private Vector2 moveDirection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damageAble = collision.gameObject.GetComponentInParent<IDamagable>();
        if (damageAble != null && collision.gameObject.tag == "Astroid")
        {
            damageAble.Damage(damageAmount);
            GameObject explo = Instantiate(expolFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    /*private void OnCollisionEnter(Collision other) {
        IDamagable damageAble = other.gameObject.GetComponentInParent<IDamagable>();
        if(damageAble != null && other.gameObject.tag == "Astroid"){
            damageAble.Damage(damageAmount);
        }
        Destroy(gameObject);
    }*/
    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction.normalized * speed;
    }

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);
    }
}
