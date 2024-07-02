using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemiesWaves()
    {
        do{
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
        
        for(int i = 0;i < currentWave.GetEnemyCount();i++)
        {
        Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetStartingWaypoint().position,
        quaternion.identity,
        transform);
        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        }
        }while(isLooping);
    }          
}