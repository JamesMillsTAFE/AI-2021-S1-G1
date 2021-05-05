using UnityEngine;

// Namespaces are like home addresses. Anything under the namespace would live
// in the house. The 'root' namespace should always be the name of your game
// and each module of your game should have it's own sub-namespace; ie: Enemies,
// Towers, UI
namespace Wandering
{
    public class Wanderer : MonoBehaviour
    {
        [SerializeField, Range(.01f, .1f)] private float jitter = .05f;
        [SerializeField, Min(1f)] private float speed = 1;
        [SerializeField] private float smoothing = .1f;

        // The force driving the agent. Updates every frame
        private Vector3 currentForce = Vector3.zero;
        // The speed the smoothed position is travelling
        private Vector3 velocity = Vector3.zero;

        // Update is called once per frame
        void Update()
        {
            // Calculate the actual movement that needs to occur and how fast
            Vector3 movement = (transform.forward + (CalculateForce() * speed)) * Time.deltaTime;
            Vector3 position = Vector3.SmoothDamp(
                transform.position,
                transform.position + movement,
                ref velocity,
                smoothing);

            // Calculate the rotation from where we are looking to the new one
            Quaternion rotation = Quaternion.Slerp(
                transform.localRotation,
                Quaternion.LookRotation(currentForce),
                Time.deltaTime);

            transform.position = position;
            transform.rotation = rotation;
        }

        /// <summary>
        /// Calculates the force the agent should be moving by. Uses jitter to
        /// create the wandering effect.
        /// </summary>
        private Vector3 CalculateForce()
        {
            // First copy the current force and calculate the random offset using jitter
            Vector3 force = currentForce;
            Vector2 offset = new Vector2(Random.Range(-jitter, jitter), Random.Range(-jitter, jitter));

            // Add the offset to the horizontal and vertical axis of the transform
            force += transform.right * offset.x;
            force += transform.up * offset.y;

            // Make sure the force is normalised because it is a direction
            force.Normalize();

            // Update the current force with the calculated one and return it
            currentForce = force;
            return force;
        }
    }
}