namespace GateFolder
{
    public class GateData
    {
        public readonly TypeGate Type;
        public readonly float Value;

        public GateData(TypeGate type, float value)
        {
            Type = type;
            Value = value;
        }
    }

    public enum TypeGate
    {
        Summ,
        Minus,
        Mult,
        Division
    }
}