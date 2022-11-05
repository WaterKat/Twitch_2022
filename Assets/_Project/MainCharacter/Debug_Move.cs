using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WaterKatLLC.MainCharacter.Debugging
{
    public class Debug_Move : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] Rigidbody characterRB;

        [Header("Configuration")]
        [SerializeField] private float speed = 5;

        [Header("Internal")]
        private Vector2 currentInput = Vector2.zero;

        private Quaternion inputRotation = Quaternion.identity;
        private Vector2 rotatedInput { get { return inputRotation * currentInput; } }


        public void SetInput(Vector2 _input)
        {
            currentInput = _input;
        }
        public void SetInputRotation(Quaternion _rotation)
        {
            inputRotation = _rotation;
        }    

        private void Update()
        {
            Vector3 input = rotatedInput; 
            Vector3 inputNormal3D = new Vector3(input.x, 0, input.y);
            Vector3 carryoverVelocity = new Vector3(0, characterRB.velocity.y, 0);

            characterRB.velocity = (inputNormal3D * speed) + carryoverVelocity;
        }
    }
}