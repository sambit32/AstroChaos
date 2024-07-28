using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 15f;
    private void OnCollisionEnter(Collision other) {
        IDamagable damageAble = other.gameObject.GetComponentInParent<IDamagable>();
        if(damageAble != null && other.gameObject.tag == "Astroid"){
            damageAble.Damage(damageAmount);
        }
        Destroy(gameObject);
    }
}
