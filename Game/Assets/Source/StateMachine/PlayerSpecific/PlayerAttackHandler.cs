using System;
using Source.StateMachine.General;
using UnityEngine;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerAttackHandler : StateHandler<PlayerState>
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        protected override void OnSelect()
        {
            _animator.Play("Attack");
        }

        public void OnMeleeAttack()
        {
            _stateContainer.CurrentStateHandler.Transition(_correspondingState);
        }
    }
}