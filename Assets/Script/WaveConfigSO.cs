using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveConfig", menuName = "WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public Transform GetStartingWaypoint() { return pathPrefab.GetChild(0); }
    public List<Transform> GetWaypoints()
    {
        List<Transform> waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
        
    
    }
    public float GetMoveSpeed() { return moveSpeed; }
    public int GetEnemyCount() { return enemyPrefab.Count; }
    public GameObject GetEnemyPrefab(int index) { return enemyPrefab[index]; }

    public float GetRandomSpawnTime() 
    { 
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance, 
                                        timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

}
