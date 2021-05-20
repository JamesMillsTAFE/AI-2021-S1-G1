using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldStateMachines
{
    public enum State
    {
        Wander,
        Target,
        Attack,
        Damage,
        Die
    }

    public class CustomStateMachine : MonoBehaviour
    {
        private Dictionary<State, string> stateCoroutines = new Dictionary<State, string>();

        private Coroutine currentCoroutine;

        // Start is called before the first frame update
        void Start()
        {
            // Specify which states map to which functions
            //stateCoroutines.Add(State.Wander, "WanderState");

            // This loops through until we hit the die state
            for (int i = 0; i <= (int)State.Die; i++)
            {
                // Convert the iterator to a state
                State state = (State)i;
                // Construct the string name
                string functionName = state.ToString() + "State";

                // Add the states to the dictionary
                stateCoroutines.Add(state, functionName);

                Debug.Log(state.ToString() + ", " + functionName);
            }

            SwapState(State.Wander);
        }

        public void SwapState(State _newState)
        {
            // Is there a coroutine already running?
            if (currentCoroutine != null)
            {
                // There is, so stop it and make currentCoroutine null
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
            }

            // Runs the coroutine, Use the function version most of the time.
            // Stores which coroutine we are currently running so we can stop it later
            currentCoroutine = StartCoroutine(stateCoroutines[_newState]);
        }

        private IEnumerator WanderState()
        {
            Debug.Log("This is before the delay!");

            yield return new WaitForSecondsRealtime(1);

            Debug.Log("This is after the delay!");
        }

        private IEnumerator TargetState()
        {
            Debug.Log("This is before the delay!");

            yield return new WaitForSecondsRealtime(1);

            Debug.Log("This is after the delay!");
        }

        private IEnumerator AttackState()
        {
            Debug.Log("This is before the delay!");

            yield return new WaitForSecondsRealtime(1);

            Debug.Log("This is after the delay!");
        }

        private IEnumerator DamageState()
        {
            Debug.Log("This is before the delay!");

            yield return new WaitForSecondsRealtime(1);

            Debug.Log("This is after the delay!");
        }

        private IEnumerator DieState()
        {
            Debug.Log("This is before the delay!");

            yield return new WaitForSecondsRealtime(1);

            Debug.Log("This is after the delay!");
        }
    }
}