using System;

namespace Source.EntityManagement.StateMachine
{
    [Flags]
    public enum State
    {
        Idle = 1,
        Run = 2,
        Prejump = 4,
        Attack = 8,
        Dash = 16,
    }
}