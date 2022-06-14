using System.Collections;
using com.GhostHunter.BaseSystems;
using com.GhostHunter.Settings;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace com.GhostHunter.Factories
{
    public class EnemyFactory : MonoBehaviour
    {
        private const string EnemyPath = "Prefabs/Enemy";
        private const float maxSpawnRange = 2.5f;
    
        private Vector3 _spawnPoint;
        private EnemyConfig _enemyConfig;
        private IEventSystemService _eventSystemService; 
        private Object _enemyPrefab;
        private DiContainer _diContainer;
    
        private int _enemyCounter;

        [Inject]
        public void Construct(DiContainer diContainer, IEventSystemService eventSystemService, EnemyConfig enemyConfig, PathPoints path)
        {
            _diContainer = diContainer;
            _eventSystemService = eventSystemService;
            _enemyConfig = enemyConfig;
            _eventSystemService.AddListener(EventConstants.DESTROY_ENEMY, UpdateCounter);
            _spawnPoint = path.startPosition;
            Load();
        }

        private void Start()
        {
            StartWork();
        }

        private void UpdateCounter(object[] data)
        {
            if (_enemyCounter > 0)
            {
                _enemyCounter--;
            }

            if (_enemyCounter == _enemyConfig.maxNumberOfEnemy - 1)
            {
                StartCoroutine(TryCreateMaxEnemy());
            }
        }

        public void Load()
        {
            _enemyPrefab = Resources.Load(EnemyPath);
        }
    
        private void Create()
        {
            if(!gameObject.scene.isLoaded) return; // not working while loaded or unloaded
            
            var spawnPoint = _spawnPoint;
            spawnPoint.x += Random.Range(maxSpawnRange * -1, maxSpawnRange);
            _diContainer.InstantiatePrefab(_enemyPrefab, spawnPoint, Quaternion.identity, null);
        }

        public void StartWork()
        {
            StartCoroutine(TryCreateMaxEnemy());
        }

        private IEnumerator TryCreateMaxEnemy()
        {
            while (true)
            {
                if (_enemyCounter >= _enemyConfig.maxNumberOfEnemy)
                {
                    yield break;
                }

                Create();
                yield return new WaitForSeconds(0.3f);
                _enemyCounter++;
            }
        }

        private void OnDestroy()
        {
            _eventSystemService.RemoveListener(EventConstants.DESTROY_ENEMY, UpdateCounter);
        }
    }
}
