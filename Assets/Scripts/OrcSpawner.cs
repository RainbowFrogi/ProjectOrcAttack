using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HietakissaUtils.Timer;
using TMPro;

public class OrcSpawner : MonoBehaviour
{
    public Timer enemySpawnTimer;
    public Timer roundChangeTimer;

    public GameObject orc;

    Vector3 spawnPos;

    public int enemySpawnAmount;
    public float timeInterval;
    int i;

    private void Awake()
    {
        Timer enemySpawnTimer = new Timer(timeInterval, gameObject);
        Timer roundChangeTimer = new Timer(120f, gameObject);

        enemySpawnTimer.OnCompleted += SpawnEnemies;
        roundChangeTimer.OnCompleted += ChangeRound;
    }

    private void ChangeRound()
    {
        if(timeInterval > 4f)
        {
            timeInterval -= 0.5f;
            enemySpawnTimer.SetCompletionTime(timeInterval);
            enemySpawnAmount += 2;
        }
    }

    private void SpawnEnemies()
    {
        i = 0;

        while(i <= enemySpawnAmount)
        {
            spawnPos = GetRandomPos();

            if(spawnPos.x > 300 || spawnPos.z > 300 || spawnPos.x < -300 || spawnPos.z < -300)
            {
                Instantiate(orc, spawnPos, Quaternion.identity);
                i++;
            }
        }
    }

    Vector3 GetRandomPos()
    {
        print("Got SpawnPos");

        float x = Random.Range(-600, 600);
        float y = 0.5f;
        float z = Random.Range(-600, 600);

        Vector3 newPos = new Vector3(x, y, z);

        return newPos;
    }


}
