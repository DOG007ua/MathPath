using System;

namespace Player
{
    public class CalculationSizePlayer : ICalculationSize
    {
        public float GetSize(float points)
        {
            var coef = 0.03f;
            return (float)Math.Sqrt((coef * points) / Math.PI);
        }
    }
}