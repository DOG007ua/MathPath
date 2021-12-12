using System;
using GateFolder;

namespace Main.Interface
{
    public class ControllerPoints : IControllerPoint
    {
        private float points;
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
            CalculationPoint(data);
            player.Size = points;
        }
    }
}