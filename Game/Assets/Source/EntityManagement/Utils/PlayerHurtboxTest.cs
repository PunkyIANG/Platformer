using UnityEngine;

namespace Source.CombatSystem
{
    public class PlayerHurtboxTest : MonoBehaviour
    {
        private bool isCurrentLayerSet = false;
        public int CurrentLayer => isCurrentLayerSet ? _currentLayer : GetCurrentLayer();
        private int _currentLayer;
        private int GetCurrentLayer()
        {
            _currentLayer = gameObject.layer;
        
            return _currentLayer;
        }
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == CurrentLayer)
            {
                Debug.Log($"player got hit {col.gameObject.layer} {CurrentLayer} {gameObject.name}");
            }
        }
    }
}
