using com.GhostHunter.BaseSystems;
using UnityEngine;
using Zenject;

namespace com.GhostHunter.Infrastructure
{
    public class EventSystemInstaller : MonoInstaller
    {
        [SerializeField] private GameObject EventSystemObject;
        public override void InstallBindings()
        {
            Container.Bind<IEventSystemService>().FromComponentInNewPrefab(EventSystemObject).AsSingle().NonLazy();
        }
    }
}