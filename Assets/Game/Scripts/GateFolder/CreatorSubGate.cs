using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GateFolder
{
    public class CreatorSubGate
    {
        private GateParams data;
        public CreatorSubGate(GateParams data)
        {
            this.data = data;
        }
        
        public GameObject CreateSubGate(GateData gateData, float height, bool first, bool last)
        {
            var subGate = Object.Instantiate(data.PrefabSubGate);
            var subGateComponent = subGate.GetComponent<SubGate>();
            SetterCilinders(subGateComponent, height, first, last);
            SetterTrigger(subGateComponent, height);
            SetterText(subGateComponent, gateData);
            return subGate;
        }

        private void SetterCilinders(SubGate subGateComponent, float height, bool first, bool last)
        {
            subGateComponent.LeftCilinder.transform.position = new Vector3(
                -height / 2.0f,
                subGateComponent.LeftCilinder.transform.position.y,
                subGateComponent.LeftCilinder.transform.position.z);
            
            subGateComponent.RightCilinder.transform.position = new Vector3(
                height / 2.0f,
                subGateComponent.RightCilinder.transform.position.y,
                subGateComponent.RightCilinder.transform.position.z);
            
            if(first)   subGateComponent.LeftCilinder.SetActive(false);
            if(last)   subGateComponent.RightCilinder.SetActive(false);
        }
        
        private void SetterTrigger(SubGate subGateComponent, float height)
        {
            subGateComponent.Trigger.transform.localScale = new Vector3(
                height / 2.0f,
                subGateComponent.Trigger.transform.localScale.y,
                subGateComponent.Trigger.transform.localScale.z);
        }
        
        private void SetterText(SubGate subGateComponent, GateData gateData)
        {
            var value = gateData.Value;
            var subValue = "";
            switch (gateData.Type)
            {
                case TypeGate.Summ:
                    subValue = "+";
                    break;
                case TypeGate.Minus:
                    subValue = "-";
                    break;
                case TypeGate.Mult:
                    subValue = "*";
                    break;
                case TypeGate.Division:
                    subValue = "/";
                    break;
                default:
                    subValue = "";
                    break;
            }

            var text = subValue + value;
            subGateComponent.Text.text = text;
        }
    }
}