using System;
using Source.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.CombatSystem
{
    public class Hitbox : MonoBehaviour
    {
        [SerializeField]
        private AttackData attackData;
        
        private CombatEntity _combatEntity;
        
        private bool _isCurrentLayerSet;
        private int _currentLayer;

        private void Start()
        {
            _combatEntity = GetComponentInParent<CombatEntity>();
            _currentLayer = gameObject.layer;
        }

        /// <summary>
        /// do whatever prep's necessary when starting a new attack,
        /// such as switching ids
        /// </summary>
        public void StartAttack()
        {
            attackData.attackId = IdAssigner.Instance.GetId();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // filter for non-combat triggers
            if (col.gameObject.layer != _currentLayer)
                return;

            var combatEntity = col.gameObject.GetComponentInParent<CombatEntity>();
            
            // don't hit yourself bro
            if (combatEntity.entityId != _combatEntity.entityId)
            {
                print("I hit something");
                combatEntity.GetHit(attackData);
            }
        }

    }
}