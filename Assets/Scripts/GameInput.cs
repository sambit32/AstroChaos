using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;
    private PlayerInputAction playerInputAction;

    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        playerInputAction = new PlayerInputAction();
        playerInputAction.Astronaut.Enable();
        playerInputAction.Spaceship.Enable();
    }

    private void OnDestroy()
    {
        playerInputAction.Dispose();
    }
    public Vector2 GetMovementVectorNormalised()
    {
        Vector2 inputVector = playerInputAction.Astronaut.Move.ReadValue<Vector2>();
        return inputVector.normalized;
    }

    public Vector2 GetSpaceshipMovementVectorNormalised()
    {
        Vector2 inputVector = playerInputAction.Spaceship.Move.ReadValue<Vector2>();
        return inputVector.normalized;
    }


    public float GetSpaceshipRotation()
    {
        return playerInputAction.Spaceship.Rotate.ReadValue<float>();
    }


}
