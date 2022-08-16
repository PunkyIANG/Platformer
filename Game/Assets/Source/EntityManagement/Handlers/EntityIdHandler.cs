using Source.Utils;
using UnityEngine;

namespace Source.PlayerController.Handlers
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