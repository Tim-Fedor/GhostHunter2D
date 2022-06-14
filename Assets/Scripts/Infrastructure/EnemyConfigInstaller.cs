using com.GhostHunter.Settings;
using UnityEngine;
using Zenject;

namespace com.GhostHunter.Infrastructure
{
    [CreateAssetMenu(fileName = "EnemyConfigInstaller", menuName = "Installers/EnemyConfigInstaller")]
    public class EnemyConfigInstaller : ScriptableObjectInstaller<EnemyConfigInstaller>
    {
        public EnemyConfig enemyConfig; 
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyConfig>().FromInstance(enemyConfig).AsSingle().NonLazy();
        }
    }
}