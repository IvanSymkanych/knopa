using UnityEngine;

namespace Planetary_System
{
    public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
    {
        public PlanetModel PlanetModel { get; private set; }
        public Transform Transform  => transform;

        public void Initialize(PlanetModel planetModel)
        {
            PlanetModel = planetModel;
            var radiusUnityUnits = (float)(planetModel.Radius * PlanetConstants.RadiusScaleFactor);
            transform.localScale = Vector3.one * (radiusUnityUnits * 2f);
        }

        public void Dispose()
        {
           Destroy(gameObject);
        }
    }
}