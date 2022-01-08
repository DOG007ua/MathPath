using UnityEngine;

namespace GateFolder
{
    [CreateAssetMenu(fileName = "GateParams", menuName = "GateParams", order = 0)]
    public class GateParams : ScriptableObject
    {
        public GameObject PrefabGate;
        public GameObject PrefabSubGate;
        public float Height;
    }
}