using System;

namespace Source.YetAnotherStateMachine.PlayerSpecific
{
    [Flags]
    public enum PlayerState
    {
        Run      = 1 << 0,
        Attack   = 1 << 1,
        Prejump  = 1 << 2,
        Dash     = 1 << 3,
        Hurt     = 1 << 4,
    }
}