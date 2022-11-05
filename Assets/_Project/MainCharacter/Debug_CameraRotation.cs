using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.MainCharacter.Debugging
{
    public class Debug_CameraRotation : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform cameraContainerTransform;
        [SerializeField] private Transform cameraTransform;

        [Header("Configuration")]
        [SerializeField] private float sensitivity = 0.5f;
        [SerializeField] private Vector2 yRotation_Bounds = new Vector2(-90, 90);

        [Header("Internal")]
        private float xRotation = 0;
        private float yRotation = 0;

        private Vector2 currentInput = Vector2.zero;

        public void SetInput(Vector2 _input)
        {
            currentInput = _input;
        }

        private void Update()
        {
            //Process Input
            xRotation += currentInput.x * sensitivity;
            yRotation += currentInput.y * sensitivity;
            currentInput = Vector2.zero;

            //Apply Bounds
            yRotation = Mathf.Clamp(yRotation, yRotation_Bounds.x, yRotation_Bounds.y);

            //Set Rotation
            cameraContainerTransform.rotation = Quaternion.Euler(-yRotation, xRotation, 0);
        }

        public float CameraYRotation()
        {
            return cameraContainerTransform.rotation.eulerAngles.y;
        }
    }
}