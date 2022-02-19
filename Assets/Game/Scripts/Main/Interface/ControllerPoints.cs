using System;
using GateFolder;
using UnityEngine;

namespace Main.Interface
{
    public class ControllerPoints : IControllerPoint
    {
        private int lastGateID = -1;
        private float points = 1;
        public float Points 
        {
            get
            {
                return points;
            }
            private set
            {
                points = value;
                if (value < 1) points = 1;
            }
        }
        private ControllerPlayer player;

        public ControllerPoints(ControllerPlayer player)
        {
            this.player = player;
            player.eventCollisionGate += CollisionGate;
        }

        private void CalculationPoint(GateData data)
        {
            switch (data.Type)
            {
                case TypeGate.Summ:
                    Points += data.Value;
                    break;
                case TypeGate.Minus:
                    Points -= data.Value;
                    break;
                case TypeGate.Mult:
                    Points *= data.Value;
                    break;
                case TypeGate.Division:
                    Points /= data.Value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void CollisionGate(GateData data)
        {
            if(!CheckMoveGate(data))    return;
            
            CalculationPoint(data);
            player.UpdatePoints(Points);
            Debug.Log(points);
        }

        private bool CheckMoveGate(GateData data)
        {
            if (data.ID > lastGateID)
            {
                lastGateID = data.ID;
                return true;
            }

            return false;
        }
    }
}