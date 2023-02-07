using System.Collections.Generic;
using Source.StateMachine.General;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerRunHandler : StateHandler<PlayerState>
    {
        public PlayerRunHandler(StateContainer<PlayerState> stateContainer, PlayerState correspondingState, HashSet<PlayerState> nextStates) : base(stateContainer, correspondingState, nextStates) { }
        
        private Vector2 targetMoveDir;

        public override void OnUpdate()
        {
            _gameObject.transform.Translate(targetMoveDir * (Time.deltaTime * 5));
        }

        public void OnMovement(InputValue value)
        {
            targetMoveDir = value.Get<Vector2>();
        }
    }
}