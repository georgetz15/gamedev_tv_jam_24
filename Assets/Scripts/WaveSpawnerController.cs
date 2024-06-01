using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SOs;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

internal enum EnemyType
{
    Basic = 0,
    Medium = 1,
    Hard = 2,
}

[Serializable]
internal struct Wave
{
    public int numBasicEnemies;
    public int numMediumEnemies;
    public int numHardEnemies;
    public float speedModifier;
    public float spawnRate;

    public int numEnemies => numBasicEnemies + numMediumEnemies + numHardEnemies;
}

public class WaveSpawnerController : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject mediumEnemy;
    [SerializeField] private GameObject hardEnemy;

    private int currentWaveIx = 0;
    private float spawnTimer = 0.0f;

    private void FixedUpdate()
    {
        if (currentWaveIx >= waves.Length) return;

        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer < 0)
        {
            var enemyType = SelectEnemyType(waves[currentWaveIx]);
            switch (enemyType)
            {
                case EnemyType.Basic:
                    SpawnEnemy(waves[currentWaveIx], basicEnemy);
                    waves[currentWaveIx].numBasicEnemies -= 1;
                    break;
                case EnemyType.Medium:
                    SpawnEnemy(waves[currentWaveIx], mediumEnemy);
                    waves[currentWaveIx].numMediumEnemies -= 1;
                    break;
                case EnemyType.Hard:
                    SpawnEnemy(waves[currentWaveIx], hardEnemy);
                    waves[currentWaveIx].numHardEnemies -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (waves[currentWaveIx].numEnemies == 0)
            {
                currentWaveIx++;
                if (currentWaveIx >= waves.Length) return;
            }

            spawnTimer += 1.0f / waves[currentWaveIx].spawnRate;
        }
    }

    private static EnemyType SelectEnemyType(Wave wave)
    {
        var numEnemies = new List<int>
        {
            wave.numBasicEnemies,
            wave.numMediumEnemies,
            wave.numHardEnemies
        };

        for (var i = 1; i < numEnemies.Count; ++i)
        {
            numEnemies[i] += numEnemies[i - 1];
        }

        var rand = Random.Range(0, numEnemies[numEnemies.Count - 1]);
        for (var i = 0; i < numEnemies.Count; ++i)
        {
            if (rand <= numEnemies[i])
            {
                return (EnemyType)i;
            }
        }

        throw new IndexOutOfRangeException("Couldn't select enemy type");
    }

    private void SpawnEnemy(Wave wave, GameObject enemyPrefab)
    {
        // Spawn enemy to random height
        var cam = Camera.main;
        var start = cam.ScreenToWorldPoint(Vector3.zero);
        var end = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        var heightModifier = Random.Range(start.y, end.y) * 0.9f;
        var enemy = Instantiate(enemyPrefab, transform.position + Vector3.up * heightModifier, Quaternion.identity);
        enemy.GetComponent<EnemyController>().AddMoveSpeed(Random.Range(0, wave.speedModifier));
    }
}