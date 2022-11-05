using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace WaterKatLLC.MainCharacter.Debugging
{
    public class Debug_InputRef : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private InputActionReference moveIAR;
        [SerializeField] private Debug_Move movementScript;
        [Space(10)]
        [SerializeField] private InputActionReference cameraIAR;
        [SerializeField] private Debug_CameraRotation cameraScript;
        [Space(10)]
        [SerializeField] private InputActionReference jumpIAR;
        [SerializeField] private Debug_Jump jumpScript;

        private void Awake()
        {
            moveIAR.action.performed += Moved;
            moveIAR.action.canceled += Moved;
            moveIAR.action.Enable();

            cameraIAR.action.performed += CameraTurned;
            cameraIAR.action.Enable();

            jumpIAR.action.performed += Jumped;
            jumpIAR.action.canceled += Jumped;
            jumpIAR.action.Enable();
        }

        private void Jumped(InputAction.CallbackContext obj)
        {
            jumpScript.SetInput(obj.ReadValue<float>() > 0.5f);
        }

        private void CameraTurned(InputAction.CallbackContext obj)
        {
            cameraScript.SetInput(obj.ReadValue<Vector2>());
        }

        private void Moved(InputAction.CallbackContext obj)
        {
            movementScript.SetInput( obj.ReadValue<Vector2>() );
        }

        private void Update()
        {
            movementScript.SetInputRotation(Quaternion.Euler(0, 0, -cameraScript.CameraYRotation()));
        }

    }
}