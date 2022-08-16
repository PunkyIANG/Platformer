using Source.CombatSystem;
using Source.PlayerController.Utils;
using Source.Utils;
using UnityEngine;

namespace Source.PlayerController.Handlers
{
    [RequireComponent(typeof(AnimHandler))]
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private Hitbox[] hitboxes;
        [SerializeField] private AnimIndex animIndex;
        [SerializeField] private AttackData attackData;

        private AnimHandler _animHandler;

        private void Start()
        {
            _animHandler = GetComponent<AnimHandler>();
        }

        public virtual void StartAttack()
        {
            attackData.AttackId = IdAssigner.Instance.GetId();

            foreach (var hitbox in hitboxes) hitbox.SetAttackData(attackData);
            
            _animHandler.StartHighPriorityAnim(animIndex);
        }
    }
}