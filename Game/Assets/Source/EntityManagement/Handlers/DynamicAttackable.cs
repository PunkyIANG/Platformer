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
                Vector2.Scale(
                    attackData.knockbackDir * attackData.knockbackStrength,
                    new Vector2(attackData.direction ? 1 : -1, 1)
                ),
                ForceMode2D.Impulse
            );
        }
    }
}