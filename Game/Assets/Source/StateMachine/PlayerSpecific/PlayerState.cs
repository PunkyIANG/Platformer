using System;

namespace Source.StateMachine.PlayerSpecific
{
    public enum PlayerState
    {
        // default state must be zero
        Run = 0,
        Prejump = 1,
        Attack = 2,
        Dash = 3,
    }
}