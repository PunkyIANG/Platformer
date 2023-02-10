using System;
using Source.YetAnotherStateMachine.General;

namespace Source.YetAnotherStateMachine.PlayerSpecific
{
    public class PlayerCancelOnExit : CancelOnExit<StateMachine<PlayerState>, PlayerState> { }
}