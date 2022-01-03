using System.Collections;
using System.Collections.Generic;
using ServiceLocatorFolder;
using Spawner;
using UnityEngine;

public class Factory : IFactory
{
    public ISpawnGate SpawnGate { get; set; }
    public ISpawnWall SpawnWall { get; set; }
    public Factory(ServiceLocator locator)
    {
        SpawnGate = locator.GetService<ISpawnGate>();
        SpawnWall = locator.GetService<ISpawnWall>();
    }
}
