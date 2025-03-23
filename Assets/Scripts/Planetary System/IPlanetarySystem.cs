using System.Collections.Generic;

namespace Planetary_System
{
    public interface IPlanetarySystem
    {
        List<IPlanetaryObject> PlanetaryObjects { get; }
        void GeneratePlanets();
    }
}