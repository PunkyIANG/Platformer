using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.StateMachine.General
{
    public abstract class StateHandler<T> : MonoBehaviour where T : Enum
    {
        protected StateContainer<T> _stateContainer;

        protected T _correspondingState;
        private HashSet<T> _nextStates;

        protected bool IsActive => _correspondingState.Equals(_stateContainer.CurrentState);

        /// <summary>
        /// Defines the state that this handler is responsible for.
        /// Called by the StateContainer's Init method.
        /// </summary>
        public void Init(StateContainer<T> stateContainer, T correspondingState, HashSet<T> nextStates)
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
        public virtual void Handle() { }

        public void Finish()
        {
            Transition(default);
        }

        protected virtual void OnSelect() { }
    }
}