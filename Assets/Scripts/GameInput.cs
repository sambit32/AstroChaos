using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;
    private PlayerInputAction playerInputAction;
    private GameDevice activeGameDevice;


    public event EventHandler OnDeviceChanged;

    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        playerInputAction = new PlayerInputAction();

        InputSystem.onActionChange += InputSystem_onActionChange;

        playerInputAction.Astronaut.Enable();
        playerInputAction.Spaceship.Enable();
    }

    private void InputSystem_onActionChange(object arg1, InputActionChange inputActionChange)
    {
        if(inputActionChange == InputActionChange.ActionPerformed && arg1 is InputAction)
        {
            InputAction inputAction = arg1 as InputAction;
            if(inputAction.activeControl.device.displayName == "VirtualMouse")
            {
                //Ignore Virtual Mouse
                return;
            }
            if(inputAction.activeControl.device is Gamepad)
            {
                if(activeGameDevice != GameDevice.Gamepad)
                {
                    ChangeActiveDevice(GameDevice.Gamepad);
                }
            }
            else
            {
                if(activeGameDevice != GameDevice.KeyboardMouse)
                {
                    ChangeActiveDevice(GameDevice.KeyboardMouse);
                }
            }
        }
    }

    public GameDevice GetActiveGameDevice()
    {
        return activeGameDevice;
    }

    private void ChangeActiveDevice(GameDevice activeGameDevice)
    {
        this.activeGameDevice = activeGameDevice;

        Cursor.visible = activeGameDevice == GameDevice.KeyboardMouse;

        OnDeviceChanged?.Invoke(this,EventArgs.Empty);
    }

    public enum GameDevice
    {
        KeyboardMouse,
        Gamepad,
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
