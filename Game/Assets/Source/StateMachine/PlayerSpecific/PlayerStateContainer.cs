using System;
using System.Collections.Generic;
using Source.StateMachine.General;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerStateContainer : StateContainer<PlayerState>
    {
        private void Awake()
        {
            Init(new Dictionary<PlayerState, StateHandler<PlayerState>>
            {
                { PlayerState.Run, gameObject.GetComponent<PlayerRunHandler>() },
                { PlayerState.Attack, gameObject.GetComponent<PlayerAttackHandler>()}
            });
        }

        private void Update()
        {
            CurrentStateHandler.OnUpdate();
        }

        public void OnAnimationEnd()
        {
            CurrentStateHandler.Finish();
        }
    }
}