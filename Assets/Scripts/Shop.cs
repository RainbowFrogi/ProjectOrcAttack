using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public bool canShop = false;
    [SerializeField] GameObject pressToShopText;
    [SerializeField] GameObject ShopGUI;

    MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameManager.Instance.menuManager;
        pressToShopText.SetActive(false);
        menuManager.CloseAllMenus();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShop && Input.GetKeyDown(KeyCode.E))
        {
            pressToShopText.SetActive(false);
            menuManager.OpenMenu("Shop");
            GameManager.Instance.gameState = gamestate.shopIsOpen;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            canShop = true;
            pressToShopText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            canShop = false;
            pressToShopText.SetActive(false);

            menuManager.CloseAllMenus();

        }
    }
}
