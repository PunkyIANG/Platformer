using Source.YetAnotherStateMachine.General;
using UnityEngine;

namespace Source.YetAnotherStateMachine.PlayerSpecific
{
    public class PlayerAttackHandler : StateHandler<PlayerState>
    {
        private Animator _animator;
        public override PlayerState ThisState => PlayerState.Attack;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public override void OnSelect()
        {
            _animator.Play("Attack");
        }

        public void OnMeleeAttack()
        {
            StateMachine.CurrentStateHandler.Transition(ThisState);
        }

    }
}