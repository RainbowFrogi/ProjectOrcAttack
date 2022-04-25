using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gamestate
{
    gameIsRunning,
    inMainMenu,
    shopIsOpen,
    inRespawnMenu
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public MenuManager menuManager;

    public TowerManager towerManager;

    public CurrencySystem currencySystem;

    public Shop shop;

    public gamestate gameState;

    private void Awake()
    {
        if (Instance != null) Destroy(this.gameObject);
        Instance = this;

        menuManager = GetComponent<MenuManager>();

        Cursor.lockState = CursorLockMode.Locked;
    }
}
