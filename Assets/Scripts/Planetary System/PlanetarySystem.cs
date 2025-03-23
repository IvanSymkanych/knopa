using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using UnityEngine;
using VContainer.Unity;

namespace Planetary_System
{
    public class PlanetarySystem : IPlanetarySystem, ITickable, IStartable
    {
        public List<IPlanetaryObject> PlanetaryObjects { get;  private set; }
   
        private readonly IPlanetaryFactory _planetaryFactory;
        private readonly GameConfig _gameConfig;
        
        private Transform _parent;
        private bool _canMove;
        
        public PlanetarySystem(IPlanetaryFactory planetaryFactory, GameConfig gameConfig)
        {
            _planetaryFactory = planetaryFactory;
            _gameConfig = gameConfig;
            
            PlanetaryObjects = new List<IPlanetaryObject>();
        }

        public void Start()
        {
            CreateParent();
            CreatePlanets();
        }
        
        public void Tick()
        {
            if(!_canMove)
                return;
            
            foreach (var planet in PlanetaryObjects)
            {
                planet.Move();
            }
        }
        
        private void CreateParent()
        {
            var instance = new GameObject("PlanetarySystem");
            _parent = instance.transform;
        }
        
        private void CreatePlanets()
        {
            var index = 1;
            _canMove = false;
            
            foreach (PlanetType type in Enum.GetValues(typeof(PlanetType)))
            {
                var config = _gameConfig.PlanetConfigs.FirstOrDefault(c => c.PlanetType == type);
                
                if (config == null)
                {
                    Debug.LogError($"[Planetary System] Planet type {type} is not configured]");
                    continue;
                }
                
                var position = new Vector3(index * PlanetConstants.OffsetBetweenPlanet, 0, 0);
                var planet = _planetaryFactory.CreateRandomizePlanetaryObject(_parent, position, config);
                PlanetaryObjects.Add(planet);
                index++;
            }
            
            _canMove = true;
        }
    }
}