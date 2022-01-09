using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

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
        
        public GameObject Create(int amountSubGates)
        {
            var dateGates = new GateData[amountSubGates];
            for (var i = 0; i < amountSubGates; i++)
            {
                dateGates[i] = GenerateDataGate();
            }
            return Create(dateGates);
        }

        private GateData GenerateDataGate()
        {
            var type = GenerateType();
            var value = GenerateValue(type);
            return new GateData(type, value);
        }

        private TypeGate GenerateType()
        {
            var amountType = Enum.GetNames(typeof(TypeGate)).Length;
            var value = UnityEngine.Random.Range(0, amountType);
            switch (value)
            {
                case 0:
                    return TypeGate.Summ;
                case 1:
                    return TypeGate.Minus;
                case 2:
                    return TypeGate.Mult;
                case 3:
                    return TypeGate.Division;
                default:
                    return TypeGate.Summ;
            }
        }

        private float GenerateValue(TypeGate type)
        {
            var massSum = new[] {1f, 3f, 5f, 8f, 12f, 15f,20f, 30f, 35f, 40f};
            var massMult = new[] {1f, 1.5f, 2f, 2,5f};
            var massMinus = new[] {1f, 3f, 5f, 8f, 12f, 15f,20f, 30f, 35f, 40f};
            var massDivision = new[] {1f, 1.5f, 2f, 2,5f};

            switch (type)
            {
                case TypeGate.Summ:
                    return massSum[UnityEngine.Random.Range(0, massSum.Length)];
                case TypeGate.Minus:
                    return massMinus[UnityEngine.Random.Range(0, massMinus.Length)];
                case TypeGate.Mult:
                    return massMult[UnityEngine.Random.Range(0, massMult.Length)];
                case TypeGate.Division:
                    return massDivision[UnityEngine.Random.Range(0, massDivision.Length)];
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
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