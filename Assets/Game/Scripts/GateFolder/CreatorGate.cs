using UnityEngine;

namespace GateFolder
{
    public class CreatorGate : ICreatorGate
    {
        private GateParams data;
        private CreatorSubGate creatorSubGate;
        
        public CreatorGate(GateParams data)
        {
            this.data = data;
        }
        
        public GameObject Create(float height, params GateData[] dateGates)
        {
            var gate = CreateMainGate(height);

            return gate;
        }

        private GameObject CreateMainGate(float height)
        {
            var gate = Object.Instantiate(data.PrefabGate);
            var gateComponent = gate.GetComponent<Gate>();
            gateComponent.LeftCilinder.transform.position = new Vector3(
                -height / 2.0f,
                gateComponent.LeftCilinder.transform.position.y,
                gateComponent.LeftCilinder.transform.position.z);
            
            gateComponent.RightCilinder.transform.position = new Vector3(
                height / 2.0f,
                gateComponent.RightCilinder.transform.position.y,
                gateComponent.RightCilinder.transform.position.z);
            
            return gate;
        }
        
        //Реализ
        private GameObject CreateSubGate(GateData gateData, float height, bool first, bool last)
        {
            return creatorSubGate.CreateSubGate(gateData, height, first, last);
        }
    }
}