using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<Menu> menus = new List<Menu>();

    public void OpenMenu(string menuType)
    {
        foreach (Menu menu in menus)
        {
            if (menu.menuType == menuType)
            {
                menu.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                menu.gameObject.SetActive(false);
            }
        }
    }

    public void CloseAllMenus()
    {
        foreach (Menu menu in menus)
        {
            menu.gameObject.SetActive(false);

        }
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.Instance.gameState = gamestate.gameIsRunning;
    }

    
}
