using System;
using System.Collections;
using System.Collections.Generic;
using GhostHunter;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class EnemyFactory : MonoBehaviour, IEnemyFactory
{
    private const string EnemyPath = "Enemy";
    private const float maxSpawnRange = 2.5f;
    private readonly Vector3 _spawnPoint = new Vector3(0, -6, 0);
    
    private EnemyConfig _enemyConfig;
    private IEventSystemService _eventSystemService; 
    private Object _enemyPrefab;
    private DiContainer _diContainer;
    
    private int _enemyCounter;

    [Inject]
    public void Construct(DiContainer diContainer, IEventSystemService eventSystemService, EnemyConfig enemyConfig)
    {
        _diContainer = diContainer;
        _eventSystemService = eventSystemService;
        _enemyConfig = enemyConfig;
        eventSystemService.AddListener(EventConstants.DESTROY_ENEMY, UpdateCounter);
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

    public void StartWork(Vector3 spawnPoint)
    {
        throw new System.NotImplementedException();
    }

    private void Create()
    {
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
}
