using System;
using System.Collections.Generic;

namespace Source.StateMachine.General
{
    public class DynamicStateHandler<T> : StateHandler<T> where T : Enum
    {
        private HashSet<T> _stableStates;
        private HashSet<T> _dynamicStates;

        public DynamicStateHandler(StateContainer<T> stateContainer, T correspondingState, HashSet<T> stableStates,
            HashSet<T> dynamicStates) : base(stateContainer, correspondingState, stableStates)
        {
            _stableStates = new HashSet<T>(stableStates);
            _dynamicStates = new HashSet<T>(dynamicStates);
        }
        
        protected override void OnSelect()
        {
            // resets the next states
            _nextStates.IntersectWith(_stableStates);
        }

        protected void IncludeDynamicStates()
        {
            // includes the dynamic states to the next states
            _nextStates.UnionWith(_dynamicStates);
        }
    }
}