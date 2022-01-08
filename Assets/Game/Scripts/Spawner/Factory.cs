using System.Collections;
using System.Collections.Generic;
using GateFolder;
using ServiceLocatorFolder;
using Spawner;
using UnityEngine;

public class Factory : IFactory
{
    public ISpawnGate SpawnGate { get; set; }
    public ISpawnWall SpawnWall { get; set; }
    private ICreatorGate creatorGate;
    public Factory(ServiceLocator locator)
    {
        creatorGate = locator.GetService<ICreatorGate>();
    }

    public GameObject CreateGate(params GateData[] dateGates)
    {
        return creatorGate.Create(dateGates);
    }
    
}
