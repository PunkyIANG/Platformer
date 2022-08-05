using System;
using UnityEngine;

namespace Source.CombatSystem
{
    /// <summary>
    /// most likely redundant as Hitbox takes care of all the stuff by itself
    /// </summary>
    public class Hurtbox : MonoBehaviour
    {
        public CombatEntity CombatEntity
        {
            get;
            private set;
        }
        
        private void Start()
        {
            CombatEntity = GetComponentInParent<CombatEntity>();
        }

        // private bool _isCurrentLayerSet;
        // public int CurrentLayer => _isCurrentLayerSet ? _currentLayer : GetCurrentLayer();
        // private int _currentLayer;
        

        // private int GetCurrentLayer()
        // {
        //     _currentLayer = gameObject.layer;
        //     _isCurrentLayerSet = true;
        //
        //     return _currentLayer;
        // }



        // private void OnTriggerEnter2D(Collider2D col)
        // {
        //     if (col.gameObject.layer == CurrentLayer)
        //     {
        //         Debug.Log($"player got hit {col.gameObject.layer} {CurrentLayer} {gameObject.name}");
        //     }
        // }

    }
}