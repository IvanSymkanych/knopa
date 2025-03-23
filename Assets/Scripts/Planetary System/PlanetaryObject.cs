using UnityEngine;

namespace Planetary_System
{
    public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
    {
        public PlanetModel PlanetModel { get; private set; }
        public Transform Transform => transform;

        private Transform _orbitCenter;
        private float _orbitRadius;
        private float _angle;
        private float _orbitSpeed;

        public void Initialize(PlanetModel planetModel)
        {
            PlanetModel = planetModel;

            _orbitCenter = transform.parent;
            _orbitRadius = Vector3.Distance(transform.position, _orbitCenter.position);
            
            var direction = (transform.position - _orbitCenter.position).normalized;
            _angle = Mathf.Atan2(direction.z, direction.x);
            
            var inverseMass = 1.0 / planetModel.Mass;
            _orbitSpeed = Mathf.Clamp((float)inverseMass, PlanetConstants.MinOrbitSpeed, PlanetConstants.MaxOrbitSpeed);
            
            var scale = Mathf.Clamp((float)planetModel.Mass, PlanetConstants.MinScale, PlanetConstants.MaxScale);
            transform.localScale = Vector3.one * scale;
        }

        public void Move()
        {
            _angle += _orbitSpeed * Time.deltaTime;

            var x = Mathf.Cos(_angle) * _orbitRadius;
            var z = Mathf.Sin(_angle) * _orbitRadius;

            var newPosition = new Vector3(x, 0f, z);
            transform.position = _orbitCenter.position + newPosition;
        }
    }
}