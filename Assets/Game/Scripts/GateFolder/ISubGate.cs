namespace GateFolder
{
    public interface ISubGate
    {
        void Construct(float height);
        void ActiveLeftLine(bool isActive);
        void ActiveRightLine(bool isActive);
    }
}