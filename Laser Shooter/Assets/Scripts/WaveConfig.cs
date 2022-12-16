using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
   [SerializeField] List<GameObject>  enemyPreFabs;
   [SerializeField] Transform pathPrefab;
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] float timeBetweenSpawn = 1f;
   [SerializeField] float spawnTimeVariance = 0f;
   [SerializeField] float minSpawnTime = 0.2f;




    public int GetEnemyCount(){
        return enemyPreFabs.Count;
    }

    public GameObject GetEnemyPreFab(int index){
        return enemyPreFabs[index];
    }
    public Transform GetStartWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
   public float GetMoveSpeed(){
    return moveSpeed;
   }

    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(timeBetweenSpawn - spawnTimeVariance,
                                        timeBetweenSpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime,float.MaxValue);
    }

}
