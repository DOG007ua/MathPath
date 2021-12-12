using ServiceLocatorFolder;
using Spawner;
using UnityEngine;
using UnityEngine.UI;

namespace Gate
{
    public class ControlGate : IControlGate
    {
        private Vector3 pointSpawn;
        private IFactory factory;

        public ControlGate(Vector3 pointSpawn, ServiceLocator locator)
        {
            this.pointSpawn = pointSpawn;
            factory = locator.GetService<IFactory>();
        }


        public void Create()
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}