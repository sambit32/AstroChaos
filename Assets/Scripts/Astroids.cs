using UnityEngine;

public class Astroids : MonoBehaviour, IDamagable
{
    public Transform destroyer;
    public GameObject expolFX;
    public GameObject[] powerUps;

    public float maxHealth = 50;
    public float damageAmount = 33.33f;
    float currentHealth;

    Rigidbody2D rb;
    [SerializeField] private float fallSpeed = 1f;

    private void Start() {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Distroyer"){
            Destroy(gameObject);
        }

        IDamagable damageAble = other.gameObject.GetComponentInParent<IDamagable>();
        if(damageAble != null && other.gameObject.tag == "Astronaut"){
            damageAble.Damage(damageAmount);
        }

        if(damageAble != null && other.gameObject.tag == "Spaceship"){
            damageAble.Damage(damageAmount);
        }
        GameManger.Instance.score.value += 5;
        Destroy(gameObject);
    }

    private void Update() {
        Vector2 moveDirection = ((Vector2)destroyer.position - (Vector2)transform.position).normalized;

        // Apply the velocity to move the asteroid towards the center
        rb.velocity = moveDirection * fallSpeed;
    }

    public void SpawnPowerUps(){
        Bullets_PowerUp powerUp = Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, Quaternion.identity).GetComponent<Bullets_PowerUp>();
        powerUp.destroyer = destroyer;
    }
}
