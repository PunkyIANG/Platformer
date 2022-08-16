using System;
using UnityEngine;

namespace Source.PlayerController.Utils
{
    [Serializable]
    public struct AttackData
    {
        public int damage;
        public Vector2 knockbackDir;
        public float knockbackStrength;
        public float stunTime;
        [NonSerialized]
        public uint AttackId;
    }
}