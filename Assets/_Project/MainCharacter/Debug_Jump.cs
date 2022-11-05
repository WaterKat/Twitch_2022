using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.MainCharacter.Debugging
{
    public class Debug_Jump : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Rigidbody characterRB;
        [SerializeField] private Debug_GroundCheck groundCheckScript;

        [Header("Configuration")]
        [SerializeField] private float jumpForce = 10;

        [Header("Internal")]
        public bool currentInput;

        public void SetInput(bool _input)
        {
            currentInput = _input;
        }

        private void Update()
        {
            if (currentInput && groundCheckScript.isGrounded())
            {
                characterRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                currentInput = false;
            }
        }
    }
}