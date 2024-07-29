using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject expolFX;
    public float damageAmount = 15f;
    Rigidbody2D rb;

    public float speed = 10f;
    private Vector2 moveDirection;

    private void Start()
    {
        StartCoroutine(Delete());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damageAble = collision.gameObject.GetComponentInParent<IDamagable>();
        if (damageAble != null && collision.gameObject.tag == "Astroid")
        {
            Astroids astroids = collision.gameObject.GetComponent<Astroids>();
            astroids.SpawnPowerUps();
            damageAble.Damage(damageAmount);
            GameObject explo = Instantiate(expolFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipRefsSO.explosion, Camera.main.transform.position, 1);
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

    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
