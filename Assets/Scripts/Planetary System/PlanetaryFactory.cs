using Config;
using UnityEngine;

namespace Planetary_System
{
    public class PlanetaryFactory : IPlanetaryFactory
    {
        public IPlanetaryObject CreateRandomizePlanetaryObject(Transform parent,Vector3 position, PlanetConfig planetConfig)
        {
            var randomMass = Random.Range(planetConfig.MinMass, planetConfig.MaxMass);
            var randomRadius = Random.Range(planetConfig.MinRadius, planetConfig.MaxRadius);
            double mass = randomMass * PlanetConstants.EarthMassKg;
            double radius= randomRadius * PlanetConstants.EarthRadiusMeters;
            
            var model = new PlanetModel(planetConfig.PlanetType, mass, radius);
            
            var instance = Object.Instantiate(planetConfig.PlanetaryObjectPrefab, position, Quaternion.identity, parent);
            instance.Initialize(model);
            
            return instance;
        }
    }
}