﻿using TMPro;
using UnityEngine;

namespace GateFolder
{
    public class SubGate : MonoBehaviour
    {
        public GameObject LeftCilinder;
        public GameObject RightCilinder;
        public GameObject Trigger;
        public TextMeshPro Text;
        public GateData Data;

        public SubGate(GateData data)
        {
            Data = data;
        }
    }
}