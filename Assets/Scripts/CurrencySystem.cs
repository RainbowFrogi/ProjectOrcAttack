using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{

    

    [Header("Values")]
    [HideInInspector] public int moneyAtStart = 50;
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
        
    }
}
