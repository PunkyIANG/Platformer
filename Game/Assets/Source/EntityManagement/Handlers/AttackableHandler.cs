using Source.EntityManagement.Utils;
using UnityEngine;

namespace Source.EntityManagement.Handlers
{
    [RequireComponent(typeof(EntityIdHandler))]
    public abstract class AttackableHandler : MonoBehaviour
    {
        public abstract void Hit(AttackData attackData);

    }
}