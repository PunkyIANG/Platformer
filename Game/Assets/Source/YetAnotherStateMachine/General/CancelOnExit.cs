using System;
using UnityEngine;

namespace Source.YetAnotherStateMachine.General
{
    // fucking generics
    public class CancelOnExit<T, TEnum> : StateMachineBehaviour where T : StateMachine<TEnum> where TEnum : Enum
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        // public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     
        // }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<T>()?.OnAnimationEnd();
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        // public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //
        // }

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}