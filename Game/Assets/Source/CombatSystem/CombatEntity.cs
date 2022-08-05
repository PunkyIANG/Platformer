using System;
using Source.Utils;
using UnityEngine;

namespace Source.CombatSystem
{
    public class CombatEntity : MonoBehaviour
    {
        public uint entityId;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            entityId = IdAssigner.Instance.GetId();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void GetHit(AttackData attackData)
        {
            print("got hit");
            _rigidbody2D.AddForce(attackData.knockbackDir * attackData.knockbackStrength, ForceMode2D.Impulse);
        }
    }
}