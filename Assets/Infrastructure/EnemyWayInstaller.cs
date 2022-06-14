using GhostHunter;
using UnityEngine;
using Zenject;

public class EnemyWayInstaller : MonoInstaller
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _finishPoint;
    public override void InstallBindings()
    {
        var enemyWay = new PathPoints(_startPoint.position, _finishPoint.position);
        Container.Bind<PathPoints>().FromInstance(enemyWay).AsSingle();
    }
    
}