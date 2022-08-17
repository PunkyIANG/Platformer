using System.Collections;
using System.Collections.Generic;
using Source.EntityManagement.Utils;
using UnityEngine;

namespace Source.EntityManagement.Handlers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DynamicAttackable : AttackableHandler
    {
        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public override void Hit(AttackData attackData)
        {
            _rb.AddForce(
                attackData.knockbackDir * attackData.knockbackStrength, 
                ForceMode2D.Impulse
            );
        }
    }
}