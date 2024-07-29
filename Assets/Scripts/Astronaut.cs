using System;
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
    public GameObject bulletPrefab;
    public Transform bulletSpawner;

    private int maxLife = 3;
    private int life;


    public event EventHandler<OnDeathEventArgs> OnDeathAction;
    public class OnDeathEventArgs : EventArgs
    {
        public int life;
    }

    void Start()
    {
        gameInput = GameInput.Instance;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        life = maxLife;

        gameInput.OnShootAction += GameInput_OnShootAction;
    }

    private void GameInput_OnShootAction(object sender, EventArgs e)
    {
        Shoot();
    }

    private void Update() {
     if(currentHealth<=0){
        Die();
        //Destroy(gameObject);
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

        Vector3 cursorWorldPosition;
        if (gameInput.GetActiveGameDevice() == GameInput.GameDevice.Gamepad)
        {
            cursorWorldPosition = Camera.main.ScreenToWorldPoint(VirtualMouse.position);
            cursorWorldPosition.z = 0;
        }
        else
        {
            cursorWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorWorldPosition.z = 0;
        } 
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

    void Shoot()
    {
        Vector3 cursorWorldPosition;
        if (gameInput.GetActiveGameDevice() == GameInput.GameDevice.Gamepad)
        {
            cursorWorldPosition = Camera.main.ScreenToWorldPoint(VirtualMouse.position);
            cursorWorldPosition.z = 0;
        }
        else
        {
            cursorWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorWorldPosition.z = 0;
        }

        // Instantiate the bullet at the bullet spawner's position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);

        // Get the direction from the bullet spawner to the cursor
        Vector3 direction = cursorWorldPosition - bulletSpawner.position;
        direction.z = 0; // Ensure the direction is only in the 2D plane

        // Set the bullet's move direction
        bullet.GetComponent<Bullet>().SetMoveDirection(direction);
    }

    public void Die()
    {
        OnDeathAction?.Invoke(this, new OnDeathEventArgs
        {
            life = life - 1
        });

        if (life == 1)
        {
            GameManger.Instance.StopGame();
            return;
        }
        currentHealth = maxHealth;
        life--;
    }
}
