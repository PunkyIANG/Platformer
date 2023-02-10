using Source.YetAnotherStateMachine.General;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.YetAnotherStateMachine.PlayerSpecific
{
    public class PlayerRunHandler : StateHandler<PlayerState>
    {
        public override PlayerState ThisState => PlayerState.Run;
        private Vector2 _targetMoveDir;

        public override void ActiveUpdate()
        {
            transform.Translate(_targetMoveDir * (Time.deltaTime * 5));
        }
        
        public void OnMovement(InputValue value)
        {
            _targetMoveDir = value.Get<Vector2>();
        }

    }
}