using UnityEngine;

namespace GateFolder
{
    public interface ICreatorGate
    {
        GameObject Create(params GateData[] dateGates);
    }
}