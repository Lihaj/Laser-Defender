using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config",fileName ="New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject>  enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed1 =7f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVriance =0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public int GetEnemyCount(){
        return enemyPrefab.Count;
    }

    public GameObject GetEnemyPrefab(int index){
        return enemyPrefab[index];
    }
    public Transform GetStartingWaypoint(){
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints(){
        List<Transform> waypoints=new List<Transform>();
        foreach(Transform child in pathPrefab){
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMoveSpeed1(){
        return moveSpeed1;
    }

    public float GetRandomSpawnTime(){
         float spawnTime= Random.Range(timeBetweenEnemySpawns-spawnTimeVriance,
                                        timeBetweenEnemySpawns+spawnTimeVriance);
        return Mathf.Clamp(spawnTime,minimumSpawnTime,float.MaxValue);
    }
}
