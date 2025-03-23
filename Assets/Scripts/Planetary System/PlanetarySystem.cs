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
        private bool _autoMove;

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

        public void GeneratePlanets()
        {
            foreach (var planet in PlanetaryObjects)
            {
                planet.Dispose();
            }
            
            CreatePlanets();
        }
        
        public void Tick()
        {
        }
        
        private void CreateParent()
        {
            var instance = new GameObject("PlanetarySystem");
            _parent = instance.transform;
        }
        
        private void CreatePlanets()
        {
            const float offsetBetweenPlanets = 2f;
            var currentX = 0f;
            var previousRadius =0f;

            foreach (var type in Enum.GetValues(typeof(PlanetType)).Cast<PlanetType>().OrderBy(_ => UnityEngine.Random.value))
            {
                var config = _gameConfig.PlanetConfigs.FirstOrDefault(c => c.PlanetType == type);

                if (config == null)
                {
                    Debug.LogError($"[Planetary System] Planet type {type} is not configured.");
                    continue;
                }

        
                currentX += previousRadius + offsetBetweenPlanets;
                
                
                var position = new Vector3(currentX, 0, 0);
                var planet = _planetaryFactory.CreateRandomizePlanetaryObject(_parent, position, config);
                PlanetaryObjects.Add(planet);
                
                float currentRadius = planet.Transform.localScale.x / 2f;

                // Оновлюємо currentX для наступної планети (враховуємо свій радіус)
                currentX += currentRadius;

                // Запам'ятовуємо радіус для наступного кроку
                previousRadius = currentRadius;
            }
        }


    }
}