using UnityEngine;

namespace Game.Scripts.GateFolder
{
    public interface IControllerGates
    {
        void AddGate(GameObject gate);
        void RemoveGate(GameObject gate);
        void MoveGates();
        void CreateGate();
        
    }
}