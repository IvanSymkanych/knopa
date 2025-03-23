using System;

namespace Planetary_System
{
    [Serializable]
    public class PlanetModel
    {
        public PlanetType PlanetType { get; set; }
        public double Mass { get; set; }
        public double Radius { get; set; }

        public PlanetModel(PlanetType planetType, double mass, double radius)
        {
            PlanetType = planetType;
            Mass = mass;
            Radius = radius;
        }
    }
}