using UnityEngine;

namespace GateFolder
{
    public interface ICreatorGate
    {
        GameObject Create(float height, params GateData[] dateGates);
    }
}