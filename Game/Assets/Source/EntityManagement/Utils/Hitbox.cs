using Source.CombatSystem;
using Source.PlayerController.Handlers;
using UnityEngine;

namespace Source.PlayerController.Utils
{
    [RequireComponent(typeof(Collider2D))]
    public class Hitbox : MonoBehaviour
    {
        private EntityIdHandler _entityIdHandler;
        
        private AttackData _attackData;
        private bool _isCurrentLayerSet;
        private int _currentLayer;

        private void Start()
        {
            _entityIdHandler = GetComponentInParent<EntityIdHandler>();
            _currentLayer = gameObject.layer;
        }

        /// <summary>
        /// do whatever prep's necessary when starting a new attack,
        /// such as switching ids
        /// </summary>
        public void SetId(uint id)
        {
            _attackData.AttackId = id;
        }

        public void SetAttackData(AttackData attackData)
        {
            _attackData = attackData;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // filter for non-combat triggers
            if (col.gameObject.layer != _currentLayer)
                return;


            var attackableId = col.gameObject.GetComponentInParent<EntityIdHandler>().Id;
            
            // don't hit yourself bro
            if (attackableId != _entityIdHandler.Id)
            {
                var attackable = col.gameObject.GetComponentInParent<AttackableHandler>();

                print("I hit something");
                attackable.Hit(_attackData);
            }
        }

    }
}