using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager poolManager;
    public Player player;

    public float maxSpawnTime = 2 * 10f;
    public float waveTickTime = 10f;
    public int maxSpawnCount = 0;
    public int maxLevel = 4;
    public float totalSpawnCount;
    public float totalPlayTime;

    [SerializeField] 
    private int level;
    
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        totalPlayTime += Time.deltaTime;

        if(totalPlayTime > maxSpawnTime)
        {
            totalPlayTime = maxSpawnTime;
        }

        totalSpawnCount = poolManager.totalSpawnCount;
    }

    public int GetLevel()
    {
        level = Mathf.FloorToInt(totalPlayTime / waveTickTime);

        return level >= maxLevel ? maxLevel : level;
    }
}
