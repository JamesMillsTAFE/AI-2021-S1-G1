using UnityEngine;

namespace Steering
{
    public abstract class SteeringBehaviour : ScriptableObject
    {
        /// <summary>
        /// Runs the calculations for the position and rotations of the passed
        /// agent using the force calculated in the <see cref="Calculate(SteeringAgent)"/> function
        /// </summary>
        public void UpdateAgent(SteeringAgent _agent)
        {
            // Calculate the new force and apply it to the agent
            Vector3 force = Calculate(_agent).normalized;
            _agent.UpdateCurrentForce(force);

            // Calculate the rotation using Slerp, the current rotation and the force for the target
            Quaternion rotation = Quaternion.Slerp(
                _agent.Rotation,
                Quaternion.LookRotation(_agent.CurrentForce != Vector3.zero ? _agent.CurrentForce : _agent.Forward),
                Time.deltaTime * 10f);

            // Calculate the position by finding the correct movement then damping the difference
            Vector3 movement = (_agent.Forward + force * _agent.Speed) * Time.deltaTime;
            Vector3 position = Vector3.SmoothDamp(
                _agent.Position,
                movement + _agent.Position,
                ref _agent.velocity,
                _agent.MovementSmoothing);

            // Apply the calculated rotation and position
            _agent.ApplyPosAndRot(position, rotation);
        }

        /// <summary>
        /// The function that the behaviours need to override to calculate
        /// their forces for the agent.
        /// </summary>
        public abstract Vector3 Calculate(SteeringAgent _agent);
    }
}