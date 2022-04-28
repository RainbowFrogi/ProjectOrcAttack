using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HietakissaUtils.Timer;

public class OrcSpawner : MonoBehaviour
{
    public Timer enemySpawnTimer;
    public Timer roundChangeTimer;

    public GameObject orc;
    [SerializeField] GameObject roundChangeScreen;

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
        GameManager.Instance.menuManager.OpenMenu("RoundChangeMenu");
    }

    private void SpawnEnemies()
    {
        i = 0;

        while(i <= enemySpawnAmount)
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
        print("Got SpawnPos");

        float x = Random.Range(-600, 600);
        float y = 0.5f;
        float z = Random.Range(-600, 600);

        Vector3 newPos = new Vector3(x, y, z);

        return newPos;
    }


}
