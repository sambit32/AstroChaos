using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInput player1Input;
    public PlayerInput player2Input;
    void Start()
    {
        var keyboard = InputSystem.GetDevice<Keyboard>();

        player1Input.SwitchCurrentControlScheme(keyboard);
        player2Input.SwitchCurrentControlScheme(keyboard);
    }
}