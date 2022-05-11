using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    CurrencySystem currencySystem;

    public TextMeshProUGUI moneyText;
    [Header("Values")]
    public int moneyAtStart = 250;
    public int moneyAmount;

    void Awake()
    {
       
    }

    void Start()
    {
        moneyAmount = moneyAtStart;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        moneyText.text = $"Money: {moneyAmount}$";
    }

    public void addMoney(int amount)
    {
        moneyAmount += amount;

        UpdateMoneyText();
    }

    
}
