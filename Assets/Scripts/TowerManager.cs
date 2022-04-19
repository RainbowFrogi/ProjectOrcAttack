using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] towers;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    void ActivateTower(int whichTower)
    {
        towers[whichTower].gameObject.SetActive(true);
    }
}
