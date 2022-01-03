namespace Spawner
{
    public interface IFactory
    {
        ISpawnGate SpawnGate { get; set; }
        ISpawnWall SpawnWall { get; set; }
    }
}