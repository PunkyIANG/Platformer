using System;

namespace Source.EntityManagement.StateMachine
{
    public abstract class StateHandler<T> where T : Enum
    {
        private T _correspondingState;
        private T[] _nextStates;
        
        public StateHandler(T correspondingState, params T[] nextStates)
        {
            _correspondingState = correspondingState;
            _nextStates = nextStates;
        }

        public abstract void Handle();
    }
}