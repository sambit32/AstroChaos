using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 moveInput;

    private void Update() {
        // transform.Translate(new Vector2(input.move.x, input.move.y) * speed * Time.deltaTime);\
        Move();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Move()
    {
        Vector2 move = new Vector2(moveInput.x, moveInput.y) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
