using System;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Source.StateMachine.General
{
    public abstract class StateHandler<T> where T : Enum
    {
        protected StateContainer<T> _stateContainer;
        protected GameObject _gameObject => _stateContainer.gameObject;

        protected T _correspondingState;
        protected HashSet<T> _nextStates;

        protected bool IsActive => _correspondingState.Equals(_stateContainer.CurrentState);

        /// <summary>
        /// Defines the state that this handler is responsible for.
        /// Called by the StateContainer's Init method.
        /// </summary>
        public virtual void Init(StateContainer<T> stateContainer, T correspondingState, HashSet<T> nextStates)
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
                OnDeselect();
                _stateContainer.CurrentState = state;
                _stateContainer.CurrentStateHandler.OnSelect();
            }
        }

        /// <summary>
        /// Called whenever the current state is supposed to end.
        /// For example, whenever an animation ends.
        /// </summary>
        public void Finish()
        {
            Transition(default);
        }

        protected virtual void OnSelect() { }
        
        protected virtual void OnDeselect() { }
        
        /// <summary>
        /// Basically unity's update but only called whenever the respective state is active.
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// Same as OnUpdate but only called once per physics frame.
        /// </summary>
        public virtual void OnFixedUpdate() { }
    }
}