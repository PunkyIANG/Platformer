using System;
using UnityEngine;

namespace Source.YetAnotherStateMachine.General
{
    public abstract class StateHandler<T> : MonoBehaviour, IStateHandler<T> where T : Enum
    {
        public abstract T ThisState { get; }
        [EnumMask] [SerializeField] private T nextStates;
        public StateMachine<T> StateMachine { get; private set; }
        public bool IsActive => StateMachine.currentState.Equals(ThisState);

        private void Awake()
        {
            StateMachine = GetComponent<StateMachine<T>>();
        }

        public void Transition(T state)
        {
            if (nextStates.HasFlag(state) && IsActive)
                StateMachine.Transition(state);
        }
        public virtual void OnSelect() { }
        public virtual void OnFinish() { }

        public virtual void ActiveUpdate() { }
        public virtual void ActiveFixedUpdate() { }
    }
}