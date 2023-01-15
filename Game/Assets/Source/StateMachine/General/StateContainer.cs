using System;
using System.Collections.Generic;

namespace Source.StateMachine.General
{
    public abstract class StateContainer<T> where T : Enum
    {
        private readonly Dictionary<T, StateHandler<T>> _stateHandlers;
        public T CurrentState { get; set; }
        public StateHandler<T> CurrentStateHandler => _stateHandlers[CurrentState];

        public StateContainer(Dictionary<T, StateHandler<T>> stateHandlers)
        {
            _stateHandlers = stateHandlers;
            CurrentState = default;
        }

        public StateContainer() {}
    }
}