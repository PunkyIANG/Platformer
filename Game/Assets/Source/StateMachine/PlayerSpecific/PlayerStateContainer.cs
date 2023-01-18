using System;
using System.Collections.Generic;
using Source.StateMachine.General;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerStateContainer : StateContainer<PlayerState>
    {
        private readonly Dictionary<PlayerState, HashSet<PlayerState>> _allNextStates =
            new Dictionary<PlayerState, HashSet<PlayerState>>
            {
                // {PlayerState.Run, new HashSet<PlayerState>(Enum.GetValues(typeof(PlayerState)))}
            };

        private void Awake()
        {
            //TODO: init with constructors instead
            Init(new Dictionary<PlayerState, StateHandler<PlayerState>>
            {
                { PlayerState.Run, gameObject.GetComponent<PlayerRunHandler>() },
                { PlayerState.Attack, gameObject.GetComponent<PlayerAttackHandler>() },
            });
        }

        public void OnAnimationEnd()
        {
            CurrentStateHandler.Finish();
        }
    }
}