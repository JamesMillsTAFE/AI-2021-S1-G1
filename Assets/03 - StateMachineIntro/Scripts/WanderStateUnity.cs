using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderStateUnity : StateMachineBehaviour
{
    // Like the start function of MonoBehaviour except it runs only the first frame update is called
    // in this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
    {
        base.OnStateEnter(_animator, _stateInfo, _layerIndex);
    }

    // Similar to MonoBehaviour Update method, runs once per update frame
    // EXCEPT the first and last frame that it is in the state for
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
    {
        base.OnStateUpdate(_animator, _stateInfo, _layerIndex);
    }

    // Like the start function of MonoBehaviour except it runs only the last frame update is called
    // in this state
    public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
    {
        base.OnStateExit(_animator, _stateInfo, _layerIndex);

        // Transition to new state
        _animator.SetTrigger("BeginTarget");
    }
}
