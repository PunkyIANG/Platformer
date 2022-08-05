using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.CombatSystem
{
    [Serializable]
    public struct AttackData
    {
        public int damage;
        public Vector2 knockbackDir;
        public float knockbackStrength;
        public float stunTime;
        public uint attackId;
    }
}