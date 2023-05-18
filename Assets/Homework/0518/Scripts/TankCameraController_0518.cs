using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using Cinemachine;

public class TankCameraController_0518 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera povCamera;

    private void OnChangeView(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            povCamera.Priority += 10;
        }
        else
        {
            povCamera.Priority -= 10;
        }
    }

}
