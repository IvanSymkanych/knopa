using UnityEngine;

namespace Planetary_System
{
    public interface IPlanetaryObject
    {
        PlanetModel PlanetModel { get; }
        Transform Transform { get; }
        void Move();
    }
}