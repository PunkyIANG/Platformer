using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandler : MonoBehaviour
{
    [SerializeField]
    private Transform tfToRotate;

    public bool IsLookingRight => _isLookingRight;
    private bool _isLookingRight = true;
    private bool _isWallSliding;
    private bool _wallSlideDir;

    public void Rotate(bool direction) {
        if (direction == _isLookingRight || _isWallSliding) return;

        tfToRotate.Rotate(0f, 180f, 0f);
        _isLookingRight = !_isLookingRight;
    }

    public void Rotate() {
        Rotate(!IsLookingRight);
    }

    public void StartWallSlide(bool direction) {
        _wallSlideDir = !direction;
        Rotate(!direction);
        _isWallSliding = true;
    }

    public void StopWallSlide() {
        _isWallSliding = false;
    }
}
