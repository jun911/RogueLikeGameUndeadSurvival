using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //Log
    LogManager logManager;

    // prefabs
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    public int totalSpawnCount;

    private void Awake()
    {
        logManager = new LogManager();

        pools = new List<GameObject>[prefabs.Length];

        logManager.WriteLine($"Create pools count : {prefabs.Length}");
        
        for (int index = 0; index < prefabs.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public int GetCount(int index)
    {
        return pools[index].Count;
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        try
        {
            foreach (GameObject item in pools[index])
            {
                // 활성화가 되지 않았을 경우
                if (!item.activeSelf)
                {
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }

            if (select == null)
            {
                select = Instantiate(prefabs[index], transform);
                pools[index].Add(select);
            }
        }
        catch (Exception ex)
        {
            logManager.WriteLine($"PoolManager.Get.ERROR, Index:{index}, error:{ex.Message}");
        }

        totalSpawnCount = GetCount(index);

        return select;
    }
}
