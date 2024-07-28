using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

public class VirtualMouseUI : MonoBehaviour
{
    private VirtualMouseInput virtualMouseInput;
    // Start is called before the first frame update
    void Awake()
    {
        virtualMouseInput = GetComponent<VirtualMouseInput>();
    }

    private void Start()
    {
        GameInput.Instance.OnDeviceChanged += GameInput_OnDeviceChanged;
    }

    private void GameInput_OnDeviceChanged(object sender, System.EventArgs e)
    {
        UpdateVisibility();
    }

    private void UpdateVisibility()
    {
        if(GameInput.Instance.GetActiveGameDevice() == GameInput.GameDevice.Gamepad) 
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 virtualMousePosition = virtualMouseInput.virtualMouse.position.value;
        virtualMousePosition.x = Mathf.Clamp(virtualMousePosition.x,0f,Screen.width);
        virtualMousePosition.y = Mathf.Clamp(virtualMousePosition.y, 0f, Screen.height);
        InputState.Change(virtualMouseInput.virtualMouse.position, virtualMousePosition);

    }
}
