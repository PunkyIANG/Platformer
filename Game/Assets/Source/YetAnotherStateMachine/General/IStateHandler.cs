using System;
using System.Collections.Generic;

namespace Source.YetAnotherStateMachine.General
{
    public interface IStateHandler<T> where T : Enum
    {
        T ThisState { get; }
        StateMachine<T> StateMachine { get; }
        bool IsActive { get; }
        void Transition(T state);
        void OnSelect() { }
        void OnFinish() { }
        void ActiveUpdate() { }
        void ActiveFixedUpdate() { }
    }
}