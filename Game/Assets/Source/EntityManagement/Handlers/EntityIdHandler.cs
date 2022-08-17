using Source.Utils;
using UnityEngine;

namespace Source.EntityManagement.Handlers
{
    public class EntityIdHandler : MonoBehaviour
    {
        public uint Id { get; private set; }
        private void Start()
        {
            Id = IdAssigner.Instance.GetId();
        }
    }
}