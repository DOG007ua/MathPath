using System;
using GateFolder;

namespace Main
{
    public interface IControllerPoint
    {
        event Action<float> eventAddPoints;
        float Points { get; }
        void CollisionGate(GateData data);
    }
}