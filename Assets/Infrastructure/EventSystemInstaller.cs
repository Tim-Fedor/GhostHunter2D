using GhostHunter;
using UnityEngine;
using Zenject;

public class EventSystemInstaller : MonoInstaller
{
    public GameObject EventSystemObject;
    public override void InstallBindings()
    {
        IEventSystemController eventSystemController =
            Container.InstantiatePrefabForComponent<IEventSystemController>(EventSystemObject);

        Container.Bind<IEventSystemController>().FromInstance(eventSystemController).AsSingle();
    }
}