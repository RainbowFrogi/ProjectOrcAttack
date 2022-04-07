using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuType;

    void Awake()
    {
        GameManager.Instance.menuManager.menus.Add(this);
        gameObject.SetActive(false);
    }
    void Start()
    {

    }

}
