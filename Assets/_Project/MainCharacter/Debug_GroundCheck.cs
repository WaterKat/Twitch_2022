using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.MainCharacter.Debugging
{
    public class Debug_GroundCheck : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform characterTransform;
 
        [Header("Configuration")]
        [SerializeField] private float capsuleRadius = 0.5f;
        [SerializeField] private float offset = 0.1f;
        public bool isGrounded()
        {
            float sphereRadius = capsuleRadius * 0.9f;
            Vector3 spherePosition = characterTransform.position + (characterTransform.up * (sphereRadius - 0.1f));
            LayerMask playerLayerMask = LayerMask.GetMask("Player");
            bool groundedCheck = Physics.CheckSphere(spherePosition, sphereRadius, ~playerLayerMask);
            return groundedCheck;
        }
    }
}
