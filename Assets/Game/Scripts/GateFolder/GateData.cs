namespace GateFolder
{
    public class GateData
    {
        public readonly TypeGate Type;
        public readonly float Value;
        public readonly int ID;

        public GateData(TypeGate type, float value, int id)
        {
            Type = type;
            Value = value;
            ID = id;
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