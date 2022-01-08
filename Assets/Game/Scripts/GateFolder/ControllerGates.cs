﻿using System.Collections.Generic;
using System.Linq;
using GateFolder;
using ServiceLocatorFolder;
using Spawner;
using UnityEngine;

namespace Game.Scripts.GateFolder
{
    public class ControllerGates : MonoBehaviour, IControllerGates
    {
        public List<GameObject> Gates;
        public float Speed = 1f;
        public GameObject positionSpawn;
        public GameObject positionDelete;
        private float secondToSpawn;
        private float timeSpawn = 2;
        private IFactory factory;


        public void Initialize(ServiceLocator locator)
        {
            factory = locator.GetService<IFactory>();
        }
    
        void Start()
        {
            Gates = new List<GameObject>();
            secondToSpawn = timeSpawn;
        }

        public void AddGate(GameObject gate)
        {
            Gates.Add(gate);
        }

        public void RemoveGate(GameObject gate)
        {
            Gates.Remove(gate);
            Destroy(gate);
        }

        public void MoveGates()
        {
            foreach (var gate in Gates)
            {
                gate.transform.position -= transform.forward * (Speed * Time.deltaTime);
            }
        }

        private bool IsNeedCreateGate()
        {
            secondToSpawn -= Time.deltaTime;
            return secondToSpawn <= 0;
        }

        public void CreateGate()
        {
            secondToSpawn = timeSpawn;
            
            var gate = factory.CreateGate(new GateData(TypeGate.Summ, 10), new GateData(TypeGate.Mult, 2));
            gate.transform.parent = this.transform;
            gate.transform.position = positionSpawn.transform.position;
            
            AddGate(gate);
        }

        // Update is called once per frame
        void Update()
        {
            MoveGates();
            UnsuitableGate();
            if (IsNeedCreateGate()) CreateGate();
        }

        private void UnsuitableGate()
        {
            foreach (var gate in Gates.Where(NeedDeleteGate))
            {
                RemoveGate(gate);
            }
        }
    

        private bool NeedDeleteGate(GameObject gate)
        {
            var distanceDeletePosition = Vector3.Distance(gate.transform.position, positionDelete.transform.position);
            return distanceDeletePosition < 1;
        }
    }
}