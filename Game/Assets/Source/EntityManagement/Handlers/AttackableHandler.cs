using Source.CombatSystem;
using Source.PlayerController.Utils;
using UnityEngine;

namespace Source.PlayerController.Handlers
{
    public abstract class AttackableHandler : MonoBehaviour
    {
        public abstract void Hit(AttackData attackData);

    }
}