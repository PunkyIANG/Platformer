using System.Collections.Generic;
using UnityEngine;

namespace Source.EntityManagement.Utils
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ColliderDetector : MonoBehaviour
    {
        public bool IsColliding => _currentColliders.Count != 0;
        private readonly HashSet<Collider2D> _currentColliders = new HashSet<Collider2D>();
        private int _currentLayer;

        private void Start()
        {
            _currentLayer = gameObject.layer;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer != _currentLayer)
                return;
            
            _currentColliders.Add(col);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.layer != _currentLayer)
                return;

            _currentColliders.Remove(col);
        }
    }
}
