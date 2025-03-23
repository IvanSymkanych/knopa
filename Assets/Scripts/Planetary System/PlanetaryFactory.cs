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
            var model = new PlanetModel(planetConfig.PlanetType, randomMass, randomRadius);
            
            var instance = Object.Instantiate(planetConfig.PlanetaryObjectPrefab, position, Quaternion.identity, parent);
            instance.Initialize(model);
            
            return instance;
        }
    }
}