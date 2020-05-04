using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public GameObject PowerUpPrefab;
    private GameObject Player;
    private const float RandRange = 9;
    public int WaveNumber = 1;
    private int EnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = FindObjectsOfType<Enemy>().Length;
        if (EnemyCount == 0)
        {
            SpawnEnemyWave(WaveNumber);
            WaveNumber++;
            Instantiate(PowerUpPrefab, GenSpawnPos(), PowerUpPrefab.transform.rotation);
        }
    }


    private Vector3 GenSpawnPos()
    {
        float SpawnX = Random.Range(-RandRange, RandRange);
        float SpawnZ = Random.Range(-RandRange, RandRange);
        Vector3 pos = new Vector3(SpawnX, 0, SpawnZ);

        return pos;
    } 

    private void SpawnEnemyWave(int NumEnemy)
    {
        for (int en = 0; en < NumEnemy; en++)
        {
            Instantiate(EnemyPrefab, GenSpawnPos(), EnemyPrefab.transform.rotation);
        }
        
    }


}
