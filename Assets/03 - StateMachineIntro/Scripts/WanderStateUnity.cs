using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderStateUnity : StateMachineBehaviour
{
    // Like the start function of MonoBehaviour except it runs only the first frame update is called
    // in this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // Similar to MonoBehaviour Update method, runs once per update frame
    // EXCEPT the first and last frame that it is in the state for
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }

    // Like the start function of MonoBehaviour except it runs only the last frame update is called
    // in this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        // Transition to new state
        animator.SetTrigger("BeginTarget");
    }
}
