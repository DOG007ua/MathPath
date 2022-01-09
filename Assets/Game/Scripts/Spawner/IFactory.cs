using GateFolder;
using UnityEngine;

namespace Spawner
{
    public interface IFactory
    {
        GameObject CreateGate(params GateData[] dateGates);
        GameObject CreateGate(int amountSubGates);
    }
}