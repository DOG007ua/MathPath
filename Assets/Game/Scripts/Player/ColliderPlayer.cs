using System;
using Game.Scripts.GateFolder;
using GateFolder;
using UnityEngine;

namespace Player
{
    public class ColliderPlayer : MonoBehaviour
    {
        public event Action<GateData> eventCollisionGate;
        private void OnTriggerEnter(Collider other)
        {
            var gate = other.GetComponent<ColliderSubGate>().SubGate;
            if(gate == null)    return;
        
            eventCollisionGate?.Invoke(gate.Data);
        }
    }
}