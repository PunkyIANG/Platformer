using System;
using System.Collections.Generic;
using System.Linq;
using Source.Utils;
using Source.YetAnotherStateMachine.PlayerSpecific;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.YetAnotherStateMachine.General
{
    public interface ITransition
    {
        void Transition(int state);
    }
    public abstract class StateMachine<T> : MonoBehaviour where T : Enum
    {
        private readonly Dictionary<T, IStateHandler<T>> _stateHandlers = new();
        public T defaultState; // must set this in the inspector because generic enum
        public T currentState; 
        public IStateHandler<T> CurrentStateHandler => _stateHandlers[currentState];

        public virtual void Transition(T state)
        {
            CurrentStateHandler.OnFinish();
            currentState = state;
            CurrentStateHandler.OnSelect();
        }

        private void Awake()
        {
            currentState = defaultState;

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