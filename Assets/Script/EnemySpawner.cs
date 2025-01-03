using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> WaveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
    public WaveConfigSO CurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do{
            foreach (WaveConfigSO wave in WaveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        }while(isLooping);
        
    }
}
