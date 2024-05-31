using System;
using System.Collections;
using System.Collections.Generic;
using SOs;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
internal struct Wave
{
    public int numBasicEnemies;
    public float speedModifier;
    public float spawnRate;
}

public class WaveSpawnerController : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private GameObject basicEnemy;

    private int currentWaveIx = 0;
    private float spawnTimer = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (currentWaveIx >= waves.Length) return;
        
        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer < 0)
        {
            SpawnBasicEnemy(waves[currentWaveIx]);
            waves[currentWaveIx].numBasicEnemies -= 1;
            Debug.Log($"num enemies {waves[currentWaveIx].numBasicEnemies}");

            if (waves[currentWaveIx].numBasicEnemies == 0)
            {
                currentWaveIx++;
                if (currentWaveIx >= waves.Length) return;
            }

            spawnTimer += 1.0f / waves[currentWaveIx].spawnRate;
        }
    }

    private void SpawnBasicEnemy(Wave wave)
    {
        var cam = Camera.main;
        var start = cam.ScreenToWorldPoint(Vector3.zero);
        var end = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        var heightModifier = Random.Range(start.y, end.y) * 0.9f;
        var enemy = Instantiate(basicEnemy, transform.position + Vector3.up * heightModifier, Quaternion.identity);
        enemy.GetComponent<EnemyController>().AddMoveSpeed(Random.Range(0, wave.speedModifier));
    }
}