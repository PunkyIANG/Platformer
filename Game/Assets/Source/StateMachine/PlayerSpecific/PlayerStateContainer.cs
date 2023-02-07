using System;
using System.Collections.Generic;
using System.Linq;
using Source.StateMachine.General;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerStateContainer : StateContainer<PlayerState>
    {
        private readonly Dictionary<PlayerState, HashSet<PlayerState>> _allNextStates = new()
        {
            { PlayerState.Run, new(Enum.GetValues(typeof(PlayerState)).Cast<PlayerState>()) },
            { PlayerState.Attack, new HashSet<PlayerState>() },
        };

        private void Awake()
        {
            //TODO: init with constructors instead
            var stateHandlers = new Dictionary<PlayerState, StateHandler<PlayerState>>
            {
                { PlayerState.Run, new PlayerRunHandler(this, PlayerState.Run, new() { PlayerState.Attack }) },
                { PlayerState.Attack, new PlayerAttackHandler(this, PlayerState.Attack, new()) },
            };
            
            Init(stateHandlers);

            // foreach (var (state, handler) in stateHandlers)
            // {
            //     handler.
            // }
        }

        public void OnAnimationEnd()
        {
            CurrentStateHandler.Finish();
        }
    }
}