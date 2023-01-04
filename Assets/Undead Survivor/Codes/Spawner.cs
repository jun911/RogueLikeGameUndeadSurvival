using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    float timer;
    int level;

    public void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        level = GameManager.instance.GetLevel();
        timer += Time.deltaTime;

        if (timer > spawnData[level].spawnTime)
        {
            timer = 0f;
            Spwan();
        }
    }

    private void Spwan()
    {
        if(IsMaxSpawnCount())
        { 
            return;
        }

        if(IsMaxSpawnWaveCount()) // not working
        {
            return;
        }

        if(IsMaxEnemySpawnTime())
        {
            return;
        }

        GameObject enemy = GameManager.instance.poolManager.Get(0);
        enemy.transform.position = spawnPoint[UnityEngine.Random.Range(1, spawnPoint.Length)].transform.position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }

    private bool IsMaxSpawnWaveCount()
    {
        //int[] levelSpawnCount = new int[5];

        //Debug.Log("levelSpawnCount[level] : " + levelSpawnCount[level]);

        //if (levelSpawnCount[level] > spawnData[level].maxSpawn)
        //{
        //    return;
        //} 

        return false;
    }

    private bool IsMaxEnemySpawnTime()
    {
        return GameManager.instance.totalPlayTime == GameManager.instance.maxSpawnTime;
    }

    private bool IsMaxSpawnCount()
    {
        return GameManager.instance.poolManager.totalSpawnCount >= GameManager.instance.maxSpawnCount;
    }
}

[Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
    public int maxSpawn;
}