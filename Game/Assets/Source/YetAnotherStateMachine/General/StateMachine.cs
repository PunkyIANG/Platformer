using System;
using System.Collections.Generic;
using System.Linq;
using Source.Utils;
using Source.YetAnotherStateMachine.PlayerSpecific;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.YetAnotherStateMachine.General
{
    public abstract class StateMachine<T> : MonoBehaviour where T : Enum
    {
        private readonly Dictionary<T, IStateHandler<T>> _stateHandlers = new();
        public T defaultState;
        public T CurrentState; // must set this in the inspector because generic enum
        public IStateHandler<T> CurrentStateHandler => _stateHandlers[CurrentState];

        public virtual void Transition(T state)
        {
            CurrentStateHandler.OnFinish();
            CurrentState = state;
            CurrentStateHandler.OnSelect();
        }

        private void Awake()
        {
            CurrentState = defaultState;

            var componentStateHandlers = GetComponents<IStateHandler<T>>();
            foreach (var componentStateHandler in componentStateHandlers)
            {
                if (_stateHandlers.ContainsKey(componentStateHandler.ThisState))
                {
                    Debug.LogError($"State {componentStateHandler.ThisState} already exists in the state machine. Maybe you forgot to set a new handler's value?");
                    continue;
                }
                
                _stateHandlers.Add(componentStateHandler.ThisState, componentStateHandler);
            }
        }

        public void OnAnimationEnd() => Transition(defaultState);

        private void Update() => CurrentStateHandler.ActiveUpdate();

        private void FixedUpdate() => CurrentStateHandler.ActiveFixedUpdate();
    }
}