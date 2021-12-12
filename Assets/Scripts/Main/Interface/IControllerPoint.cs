using GateFolder;

namespace Main
{
    public interface IControllerPoint
    {
        float Points { get; }
        void CollisionGate(GateData data);
    }
}