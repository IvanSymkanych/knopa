using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public List<PlanetConfig> PlanetConfigs {get; private set;}
    }
}