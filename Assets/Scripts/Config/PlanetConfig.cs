using System;
using Planetary_System;
using UnityEngine;

namespace Config
{
    [Serializable]
    public record PlanetConfig
    {
        public PlanetType PlanetType;
        public PlanetaryObject PlanetaryObjectPrefab;
        [Tooltip("Earth Units")] public float MinMass;
        [Tooltip("Earth Units")] public float MaxMass;
        [Tooltip("Earth Units")] public float MinRadius;
        [Tooltip("Earth Units")]  public float MaxRadius;
    }
}