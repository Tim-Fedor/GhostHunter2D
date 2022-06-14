using GhostHunter;
using UnityEngine;
using Zenject;

public class EventSystemInstaller : MonoInstaller
{
    [SerializeField] private GameObject EventSystemObject;
    public override void InstallBindings()
    {
        IEventSystemService eventSystemService =
            Container.InstantiatePrefabForComponent<IEventSystemService>(EventSystemObject);

        Container.Bind<IEventSystemService>().FromInstance(eventSystemService).AsSingle().NonLazy();
    }
}