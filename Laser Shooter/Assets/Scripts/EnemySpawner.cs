using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfig currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfig GetCurrentWave(){
        return currentWave;
    }
    IEnumerator SpawnEnemies(){
        
        foreach(WaveConfig wave in waveConfigs)
        {
        currentWave = wave;
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
        Instantiate(currentWave.GetEnemyPreFab(i),
         currentWave.GetStartWayPoint().position,
         Quaternion.identity,
         transform);
         yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
