using System.Collections.Generic;
using Source.StateMachine.General;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.StateMachine.PlayerSpecific
{
    public class PlayerRunHandler : StateHandler<PlayerState>
    {
        private Vector2 targetMoveDir;
        public override void Handle()
        {
            transform.Translate(targetMoveDir * (Time.deltaTime * 5));
        }

        public void OnMovement(InputValue value)
        {
            targetMoveDir = value.Get<Vector2>();
        }
        
        
        
        
    }
}