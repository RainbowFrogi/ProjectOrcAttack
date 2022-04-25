using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerManager : MonoBehaviour
{
    public GameObject[] towers;

    CurrencySystem currencySystem;

    Shop shop;
    private void Start()
    {
        currencySystem = GameManager.Instance.currencySystem;
        shop = GameManager.Instance.shop;

        //errorMessage.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void ActivateTower(int whichTower)
    {
        if(currencySystem.moneyAmount >= 200 && !towers[whichTower].gameObject.activeSelf)
        {
            towers[whichTower].gameObject.SetActive(true);
            currencySystem.moneyAmount -= 200;
        }

        else if (towers[whichTower].gameObject.activeSelf)
        {
            shop.errorMessage.text = "You have already bought this tower";
            StartCoroutine(shop.showErrorText());
        }

        else
        {
            shop.errorMessage.text = "You have insufficient money";
            StartCoroutine(shop.showErrorText());
        }
    }


}
