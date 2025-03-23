using Config;
using UnityEngine;

namespace Planetary_System
{
    public interface IPlanetaryFactory
    {
        IPlanetaryObject CreateRandomizePlanetaryObject(Transform parent, Vector3 position, PlanetConfig planetConfig);
    }
}