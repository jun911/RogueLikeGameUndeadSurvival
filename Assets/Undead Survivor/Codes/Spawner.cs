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
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);

        if (timer > spawnData[level].spawnTime)
        {
            timer = 0f;
            Spwan();
        }
    }

    private void Spwan()
    {
        int spawnCount = GameManager.instance.poolManager.GetCount(level);
        if(spawnCount == spawnData[level].maxSpawn)
        {
            return;
        }

        GameObject enemy = GameManager.instance.poolManager.Get(0);
        enemy.transform.position = spawnPoint[UnityEngine.Random.Range(1, spawnPoint.Length)].transform.position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
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