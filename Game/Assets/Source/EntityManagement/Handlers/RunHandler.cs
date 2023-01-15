using Source.EntityManagement.Utils;
using Source.EntityManagement.EntityDirector;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Mathf;

namespace Source.EntityManagement.Handlers
{
    [RequireComponent(typeof(MirrorHandler))]
    public class RunHandler : MonoBehaviour
    {
        public bool canRun = true;

        private PlayerController _playerController;
        private GroundController _groundController;
        private GroundController _leftController;
        private GroundController _rightController;
        private MirrorHandler _mirror;

        [SerializeField] private float maxRunningSpeed;
        [SerializeField] private float runAcceleration;
        [SerializeField] private float brakeAcceleration;
        [SerializeField] private float stopAcceleration;
        [SerializeField] private float airBrakeAcceleration;
        [SerializeField] private float airStopAcceleration;

        [SerializeField] private float valueCloseToZero;

        public float TargetMoveDirX { get; private set; }
        
        public void OnMovementX(InputValue value)
        {
            TargetMoveDirX = value.Get<float>();
        }

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _mirror = GetComponent<MirrorHandler>();
            _groundController = _playerController.groundController;
            _leftController = _playerController.leftWallController;
            _rightController = _playerController.rightWallController;
        }

        public void Handle()
        {
            // TODO: replace all of these fucking Mathf function calls with something better
            var runDirection = TargetMoveDirX; // -1, 0, 1

            if (Abs(runDirection) > valueCloseToZero)
                _mirror.Rotate(runDirection > 0);
                
            _playerController.currentVelocity.x += GetAddedVelocity(runDirection);

            float GetAddedVelocity(float runDirection)
            {
                if (Abs(runDirection) < valueCloseToZero || !canRun ||
                    (runDirection > valueCloseToZero && _rightController.IsGrounded) ||
                    (runDirection < -valueCloseToZero && _leftController.IsGrounded))
                {
                    // subtract just enough speed so it stops at 0
                    if (_groundController.IsGrounded)
                        return -Min(Abs(_playerController.currentVelocity.x),
                            Abs(stopAcceleration * Time.fixedDeltaTime)) * Sign(_playerController.currentVelocity.x);
                    else
                        return -Min(Abs(_playerController.currentVelocity.x),
                            Abs(airStopAcceleration * Time.fixedDeltaTime)) * Sign(_playerController.currentVelocity.x);
                }

                if (Abs(_playerController.currentVelocity.x) < valueCloseToZero // if the player is stationary (horizontally)
                    || runDirection * _playerController.currentVelocity.x > 0) // or if he continues to run in the same direction as before
                {
                    // acceleration
                    if (_groundController.IsGrounded)
                    {
                        // brake if current velocity is greater than max
                        if (Abs(_playerController.currentVelocity.x) > maxRunningSpeed)
                        {
                            return Max(-brakeAcceleration * Time.fixedDeltaTime, maxRunningSpeed - Abs(_playerController.currentVelocity.x)) * runDirection;
                        }
                        return Min(runAcceleration * Time.fixedDeltaTime, maxRunningSpeed - Abs(_playerController.currentVelocity.x)) * runDirection;
                    }
                    // conserve velocity
                    return Abs(_playerController.currentVelocity.x) > maxRunningSpeed
                        ? 0f
                        : runAcceleration * Time.fixedDeltaTime * runDirection;

                    // return Min(runAcceleration * Time.fixedDeltaTime, maxRunningSpeed - Abs(currentVelocity.x)) * runDirection;
                }

                // brake on direction change
                // return brakeAcceleration * runDirection * Time.fixedDeltaTime;
                if (_groundController.IsGrounded)
                    return -_playerController.currentVelocity.x + runAcceleration * runDirection * Time.fixedDeltaTime;
                else
                    return airBrakeAcceleration * runDirection * Time.fixedDeltaTime;
            }
        }
    }
}