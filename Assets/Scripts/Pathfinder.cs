using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int wayponitIndex = 0;

    void Awake()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[wayponitIndex].position;
    }
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (wayponitIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[wayponitIndex].position;
            float delta = waveConfig.GetMoveSpeed1() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wayponitIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
