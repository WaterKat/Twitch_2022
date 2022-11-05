using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.Enemies.Debugging
{
    public class Debug_SnailMovement : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] Rigidbody characterRB;

        [Header("Configuration")]
        [SerializeField] private float speed = 1;

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