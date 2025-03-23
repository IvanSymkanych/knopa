using Config;
using Planetary_System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scope
{
    public class MainLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameConfig gameConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameConfig);
            builder.Register<PlanetarySystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IPlanetaryFactory, PlanetaryFactory>(Lifetime.Scoped);
        }
    }
}