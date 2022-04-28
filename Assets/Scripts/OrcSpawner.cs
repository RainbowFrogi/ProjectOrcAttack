using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HietakissaUtils.Timer;

public class OrcSpawner : MonoBehaviour
{
    public Timer timer;

    public GameObject orc;

    Vector3 spawnPos;

    public int enemySpawnAmount;
    int i;
    

    private void Awake()
    {
        Timer timer = new Timer(3f, gameObject);

        timer.OnCompleted += SpawnEnemies;
    }

    private void SpawnEnemies()
    {
        i = 0;

        
        while(i > enemySpawnAmount)
        {
            spawnPos = GetRandomPos();

            if(spawnPos.x > 200 && spawnPos.z > 200 || spawnPos.x < -200 && spawnPos.z < -200)
            {
                Instantiate(orc, spawnPos, Quaternion.identity);
                i++;
            }
            else if(spawnPos.x > 200 && spawnPos.z < -200 || spawnPos.x < -200 && spawnPos.z > 200)
            {
                Instantiate(orc, spawnPos, Quaternion.identity);
                i++;
            }
            else
            {

            }

        }

        
    }

    Vector3 GetRandomPos()
    {
        float x = Random.Range(-600, 600);
        float y = 0.5f;
        float z = Random.Range(-600, 600);

        Vector3 newPos = new Vector3(x, y, z);

        return newPos;
    }


}
