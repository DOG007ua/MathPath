using GateFolder;
using UnityEngine;

namespace Spawner
{
    public interface IFactory
    {
        ISpawnGate SpawnGate { get; set; }
        ISpawnWall SpawnWall { get; set; }
        GameObject CreateGate(params GateData[] dateGates);
    }
}