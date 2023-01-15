using System;

namespace Source.StateMachine.PlayerSpecific
{
    [Flags]
    public enum PlayerState
    {
        // default state must be zero
        Run = 0,
        Prejump = 1,
        Attack = 2,
        Dash = 4,
    }
}