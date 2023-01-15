using Source.EntityManagement.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using Source.EntityManagement.EntityDirector;

namespace Source.EntityManagement.Handlers
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(JumpHandler))]
    [RequireComponent(typeof(DashHandler))]
    [RequireComponent(typeof(Animator))]
    public class AnimHandler : MonoBehaviour
    {
        public float valueCloseToZero = 0.01f;
        // public Transform tfToRotate;
        
        private PlayerController _playerController;
        private ColliderDetector _groundDetector;
        private JumpHandler _jumpHandler;
        private DashHandler _dashHandler;
        private Animator _animator;

        // public bool IsLookingRight { get; private set; } = true;
        private int _currentLowPriorityAnim;
        
        public float TargetMoveDirX { get; private set; }
        
        public void OnMovementX(InputValue value)
        {
            TargetMoveDirX = value.Get<float>();

            // ResetRotation();
        }

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _groundDetector = GetComponentInChildren<GroundDetector>();
            _jumpHandler = GetComponent<JumpHandler>();
            _dashHandler = GetComponent<DashHandler>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // low priority stuff
            // don't mind the absolute ton of ifs in a performance critical context
            // this is quite literally a decision tree written as code
            if (_dashHandler.IsDashing) {
                StartLowPriorityAnim(AnimIndex.Dash);
                return;
            }

            if (_groundDetector.IsColliding)
            {
                if (Mathf.Abs(TargetMoveDirX) > valueCloseToZero) 
                    StartLowPriorityAnim(AnimIndex.Run);
                else
                    StartLowPriorityAnim(AnimIndex.Idle);
            }
            else
            {
                if (_jumpHandler.IsWallSliding)
                {
                    StartLowPriorityAnim(AnimIndex.WallSlide);
                }
                else
                {
                    if (_playerController.currentVelocity.y > valueCloseToZero)
                        StartLowPriorityAnim(AnimIndex.Jumping);
                    else
                        StartLowPriorityAnim(AnimIndex.Falling);
                }
            }
        }

        /// <param name="anim">Anim clip hash from the static AnimClips class</param>
        public void StartLowPriorityAnim(int anim)
        {
            if (_currentLowPriorityAnim == anim) return;
            _animator.Play(anim);
            _currentLowPriorityAnim = anim;
        }
        
        public void StartLowPriorityAnim(AnimIndex index)
        {
            StartLowPriorityAnim(AnimValues.Get(index));
        }

        
        /// <summary>
        /// Does exactly what the function name says.
        /// Do check in advance if the animation can really execute, 
        /// using PlayerController's TransitionStruct
        /// </summary>
        public void StartHighPriorityAnim(int anim)
        {
            _animator.Play(anim);
        }
        
        public void StartHighPriorityAnim(AnimIndex index)
        {
            _animator.Play(AnimValues.Get(index));
        }
    }

    // make triple sure that the AnimIndex corresponds exactly to AnimValues
    public enum AnimIndex
    {
        Idle,
        Run,
        HitStun,
        MeleeAtkHigh,
        MeleeAtkLow,
        MeleeAtkOverhead,
        StartJump,
        StartWallJump,
        Jumping,
        WallJumping,
        WallSlide,
        Falling,
        Dash,
    }

    public static class AnimValues
    {
        private static readonly int[] Hashes = 
        {
            Animator.StringToHash("Player_Idle"),
            Animator.StringToHash("Player_Run"),
            Animator.StringToHash("Player_HitStun"),
            Animator.StringToHash("Player_MeleeAtkHigh"),
            Animator.StringToHash("Player_MeleeAtkLow"),
            Animator.StringToHash("Player_MeleeAtkOverhead"),
            Animator.StringToHash("Player_StartJump"),
            Animator.StringToHash("Player_StartWallJump"),
            Animator.StringToHash("Player_Jumping"),
            Animator.StringToHash("Player_WallJumping"),
            Animator.StringToHash("Player_WallSlide"),
            Animator.StringToHash("Player_Falling"),
            Animator.StringToHash("Player_Dash"),
        };

        public static int Get(AnimIndex index) => Hashes[(int) index];
    }
}