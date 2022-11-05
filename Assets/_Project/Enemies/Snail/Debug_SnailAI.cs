using UnityEngine;

namespace WaterKatLLC.Enemies.Debugging
{
    public class Debug_SnailAI : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform characterTransform;
        [SerializeField] private Debug_SnailMovement snailMovementScript;

        [SerializeField] private Transform meatChunk;

        private Transform ClosestEdibleTransform()
        {
            return meatChunk;
        }

        private void Update()
        {
            Transform targetTransform = ClosestEdibleTransform();
            Debug.Log(targetTransform.position);
            Vector3 relativePosition = targetTransform.position - characterTransform.position;
            Vector2 desiredInput = new Vector2(relativePosition.x, relativePosition.z);
            snailMovementScript.SetInput(desiredInput.normalized);
        }
    }
}