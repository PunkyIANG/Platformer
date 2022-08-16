using Source.CombatSystem;
using Source.PlayerController.Utils;
using Source.Utils;
using UnityEngine;

namespace Source.PlayerController.Handlers
{
    /// <summary>
    /// obsolete, use AttackHandler instead
    /// </summary>
    public class PlayerAttackHandler : MonoBehaviour
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
            lowHitbox.SetId(IdAssigner.Instance.GetId());
            _animHandler.StartHighPriorityAnim(AnimClips.MeleeAtkLow);
        }
        
        public void OnRangedAttack()
        {
            highHitbox.SetId(IdAssigner.Instance.GetId());
            _animHandler.StartHighPriorityAnim(AnimClips.MeleeAtkHigh);
        }
        
        public void OnHeavyAttack()
        {
            overheadHitbox.SetId(IdAssigner.Instance.GetId());
            _animHandler.StartHighPriorityAnim(AnimClips.MeleeAtkOverhead);
        }
    }
}