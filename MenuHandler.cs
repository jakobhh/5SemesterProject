using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
private bool togglePauseMenu = false;
public GameObject PauseMenuUI;
public GameObject LoseMenuUI;

void Start() 
{
    PauseMenuUI.SetActive(false);
}
 void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }
void MenuPauseGame() 
{
    if (togglePauseMenu)
    {
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);

    } else {
        Time.timeScale = 1  ;
        PauseMenuUI.SetActive(false);
    }
}
public void TogglePauseMenu()
{
    togglePauseMenu = !togglePauseMenu;
    MenuPauseGame();
}

public void MenuLoseGame()
{
    LoseMenuUI.SetActive(true);
    Time.timeScale = 0;
}

public void BackToMainMenu() 
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
}
}
