using System.Collections.Generic;
using UnityEngine;

namespace Source.PlayerController
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class GroundController : MonoBehaviour
    {
        public bool IsGrounded => _currentColliders.Count != 0;
        private readonly HashSet<Collider2D> _currentColliders = new HashSet<Collider2D>();

        private void OnTriggerEnter2D(Collider2D col)
        {
            _currentColliders.Add(col);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            _currentColliders.Remove(col);
        }
    }
}
