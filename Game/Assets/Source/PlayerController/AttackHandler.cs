using System;
using Source.CombatSystem;
using UnityEngine;

namespace Source.PlayerController
{
    public class AttackHandler : MonoBehaviour
    {
        private AnimHandler _animHandler;

        [SerializeField]
        private Hitbox lowHitbox;
        [SerializeField]
        private Hitbox highHitbox;
        [SerializeField]
        private Hitbox overheadHitbox;


        private void Start()
        {
            _animHandler = GetComponent<AnimHandler>();
        }
        
        public void OnMeleeAttack()
        {
            lowHitbox.StartAttack();
            _animHandler.StartHighPriorityAnim(AnimClips.MeleeAtkLow);
        }
        
        public void OnRangedAttack()
        {
            highHitbox.StartAttack();
            _animHandler.StartHighPriorityAnim(AnimClips.MeleeAtkHigh);
        }
        
        public void OnHeavyAttack()
        {
            overheadHitbox.StartAttack();
            _animHandler.StartHighPriorityAnim(AnimClips.MeleeAtkOverhead);
        }
    }
}