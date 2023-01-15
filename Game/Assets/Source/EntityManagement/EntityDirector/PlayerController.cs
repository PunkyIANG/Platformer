using System;
using Source.EntityManagement.Handlers;
using Source.EntityManagement.Utils;
using UnityEngine;

namespace Source.EntityManagement.EntityDirector
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(JumpHandler))]
    [RequireComponent(typeof(DashHandler))]
    [RequireComponent(typeof(RunHandler))]
    [RequireComponent(typeof(EntityIdHandler))]
    public class PlayerController : MonoBehaviour
    {
        [Serializable]
        public struct TransitionStruct
        {
            public bool canHitStun;
            public bool canMeleeAtkHigh;
            public bool canMeleeAtkLow;
            public bool canMeleeAtkOverhead;
            public bool canStartJump;
            public bool canStartWallJump;
        }

        public TransitionStruct transitions;
        
        public float valueCloseToZero;

        [SerializeField]
        private AttackHandler lowAttack;
        [SerializeField]
        private AttackHandler highAttack;
        [SerializeField]
        private AttackHandler overheadAttack;


        public GroundController groundController;
        public GroundController ceilingController;
        public GroundController leftWallController;
        public GroundController rightWallController;
        
        public Rigidbody2D playerRb;

        public Vector2 currentVelocity;

        private JumpHandler _jumpHandler;
        private DashHandler _dashHandler;
        private RunHandler _runHandler;
        
        private void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();

            _jumpHandler = GetComponent<JumpHandler>();
            _dashHandler = GetComponent<DashHandler>();
            _runHandler = GetComponent<RunHandler>();
        }


        private void FixedUpdate()
        {
            var isDashing = _dashHandler.CycleDash();

            if (!isDashing)
            {
                _jumpHandler.CycleJump();
                _runHandler.Handle();
            }
            
            if (currentVelocity.magnitude > valueCloseToZero)
                playerRb.MovePosition(transform.position + (Vector3)currentVelocity * Time.fixedDeltaTime);
        }

        private void OnMeleeAttack() {
            lowAttack.StartAttack();
        }

        private void OnRangedAttack() {
            highAttack.StartAttack();
        }

        private void OnHeavyAttack() {
            overheadAttack.StartAttack();
        }
    }
}