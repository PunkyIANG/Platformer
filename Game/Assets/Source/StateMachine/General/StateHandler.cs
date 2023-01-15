using System;
using System.Collections.Generic;

namespace Source.StateMachine.General
{
    public abstract class StateHandler<T> where T : Enum
    {
        private readonly StateContainer<T> _stateContainer;

        private T _correspondingState;
        private readonly HashSet<T> _nextStates;
        
        protected bool IsActive => _correspondingState.Equals(_stateContainer.CurrentState);
        
        public StateHandler(StateContainer<T> stateContainer, T correspondingState, HashSet<T> nextStates)
        {
            _stateContainer = stateContainer;
            _correspondingState = correspondingState;
            _nextStates = nextStates;
        }
        
        /// <summary>
        /// Transition to the specified state. Will only succeed if the given state is a valid next state.
        /// Should be called either inside the same state or by other valid next states.
        /// </summary>
        /// <param name="state">State to transition to</param>
        public void Transition(T state)
        {
            if (_nextStates.Contains(state))
            {
                _stateContainer.CurrentState = state;
                _stateContainer.CurrentStateHandler.OnSelect();
            }
        }
        
        /// <summary>
        /// The main method that handles the logic. Call frequency still discussed.
        /// </summary>
        public abstract void Handle();

        protected void Finish()
        {
            Transition(default);
        }

        protected abstract void OnSelect();
    }
}