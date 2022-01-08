using UnityEngine;

namespace GateFolder
{
    public class CreatorGate : ICreatorGate
    {
        private GateParams data;
        private CreatorSubGate creatorSubGate;
        private readonly float height;
        
        public CreatorGate(GateParams data)
        {
            this.data = data;
            height = data.Height;
            creatorSubGate = new CreatorSubGate(data);
        }
        
        public GameObject Create(params GateData[] dateGates)
        {
            var gate = CreateMainGate(height);
            CreateSubGates(gate, height, dateGates);
            return gate;
        }

        private GameObject CreateMainGate(float height)
        {
            var gate = Object.Instantiate(data.PrefabGate);
            var gateComponent = gate.GetComponent<Gate>();
            gateComponent.LeftCilinder.transform.localPosition = new Vector3(
                -height / 2.0f,
                gateComponent.LeftCilinder.transform.position.y,
                gateComponent.LeftCilinder.transform.position.z);
            
            gateComponent.RightCilinder.transform.localPosition = new Vector3(
                height / 2.0f,
                gateComponent.RightCilinder.transform.position.y,
                gateComponent.RightCilinder.transform.position.z);
            
            return gate;
        }

        private void CreateSubGates(GameObject gate, float height, params GateData[] dateGates)
        {
            var amountSubGates = dateGates.Length;
            var indent = height / (amountSubGates * 2.0f);
            var sizeSubGate = height / amountSubGates;

            for (int i = 0; i < amountSubGates; i++)
            {
                var first = i == 0;
                var last = i == (amountSubGates - 1);
                var subGate = CreateSubGate(dateGates[i], sizeSubGate, first, last);
                var position = -height / 2.0f + indent + sizeSubGate * i;
                SetterSubGateInGate(gate, subGate, position);
            }
        }

        private void SetterSubGateInGate(GameObject gate, GameObject subGate, float position)
        {
            subGate.transform.parent = gate.transform;
            subGate.transform.rotation = Quaternion.Euler(Vector3.zero);
            
            subGate.transform.localPosition = new Vector3(position, 0, 0);
        }

        private GameObject CreateSubGate(GateData gateData, float height, bool first, bool last)
        {
            return creatorSubGate.CreateSubGate(gateData, height, first, last);
        }
    }
}