using System.Collections.Generic;
using Source.StateMachine.General;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerStateContainer : StateContainer<PlayerState>
    {
        public PlayerStateContainer(Dictionary<PlayerState, StateHandler<PlayerState>> stateHandlers) : base(stateHandlers)
        {
        }
    }
}