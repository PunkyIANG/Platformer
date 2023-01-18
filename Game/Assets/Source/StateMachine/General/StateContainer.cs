using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.StateMachine.General
{
    [RequireComponent(typeof(StateContainer<>))]
    public abstract class StateContainer<T> : MonoBehaviour where T : Enum
    {
        private Dictionary<T, StateHandler<T>> _stateHandlers;
        public T CurrentState { get; set; }
        public StateHandler<T> CurrentStateHandler => _stateHandlers[CurrentState];

        /// <summary>
        /// Defines the states that this state container can handle.
        /// Call this method in the Awake method of the derived class.
        /// </summary>
        protected void Init(Dictionary<T, StateHandler<T>> stateHandlers)
        {
            _stateHandlers = stateHandlers;
            CurrentState = default;

            var allStates = new HashSet<T>();

            #warning this thing doesn't properly initialize next states
            foreach (var stateHandler in stateHandlers)
            {
                allStates.Add(stateHandler.Key);
                stateHandler.Value.Init(this, stateHandler.Key, allStates);
            }
        }

        
        /// <summary>
        /// Do not override.
        /// </summary>
        private void Update() => CurrentStateHandler.OnUpdate();

        /// <summary>
        /// Do not override.
        /// </summary>
        private void FixedUpdate() => CurrentStateHandler.OnFixedUpdate();
    }
}