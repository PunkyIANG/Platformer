using Source.YetAnotherStateMachine.General;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.Serialization;

namespace Source.YetAnotherStateMachine.PlayerSpecific
{
    public class PlayerAttackHandler : StateHandler<PlayerState>
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        public override PlayerState ThisState => PlayerState.Attack;
        private Vector2 _targetMoveDir;
        [SerializeField] private float range = 2f;
        [SerializeField] private float duration = 0.5f;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public override void OnSelect()
        {
            // _animator.Play("Attack");
            transform.DOMove(transform.position + (Vector3)(_targetMoveDir * range), duration);
            _spriteRenderer.transform.DORotate(
                _spriteRenderer.transform.rotation.eulerAngles
                + Vector3.forward * 90,
                duration
            );
            _spriteRenderer.color = new Color(1f, 0.6f, 0.6f);
            _spriteRenderer.DOColor(Color.white, duration);
            DOVirtual.DelayedCall(duration, () => StateMachine.Transition(PlayerState.Run));
        }

        public void OnMeleeAttack()
        {
            StateMachine.CurrentStateHandler.Transition(ThisState);
        }

        public void OnMovement(InputValue value)
        {
            var moveDir = value.Get<Vector2>();
            if (moveDir.magnitude > 0.1f)
                _targetMoveDir = value.Get<Vector2>();
        }
    }
}