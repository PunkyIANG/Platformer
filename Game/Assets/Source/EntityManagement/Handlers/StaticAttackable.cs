using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Source.EntityManagement.Utils;

namespace Source.EntityManagement.Handlers
{
    public class StaticAttackable : AttackableHandler
    {
        [SerializeField]
        private uint hp = 3; 
        public override void Hit(AttackData _attackData) {
            if (--hp <= 0) 
                Destroy(gameObject);            
        }
    }
}