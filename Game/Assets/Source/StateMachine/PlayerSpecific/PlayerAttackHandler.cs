using System;
using System.Collections.Generic;
using Source.StateMachine.General;
using UnityEngine;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerAttackHandler : StateHandler<PlayerState>
    {
        private Animator _animator;

        public PlayerAttackHandler(StateContainer<PlayerState> stateContainer, PlayerState correspondingState, HashSet<PlayerState> nextStates) 
            : base(stateContainer, correspondingState, nextStates) { }

        private void Start()
        {
            _animator = _gameObject.GetComponent<Animator>();
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