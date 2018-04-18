using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    public Transform pauseBackground;
    public Transform pauseMenu;
    public Transform openingScreen;
    public Transform controlsAndObjectivesScreen;
    public Transform dialogMenu;
    public Transform endMenu;
    public Transform creditsScreen;

    public Transform playerShip;
    public GameObject playerShipUI;

    public Text endText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }

    public void Pause()
    {
        if (pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            pauseBackground.gameObject.SetActive(true);
            Time.timeScale = 0;
            playerShip.GetComponent<PlayerShipController>().enabled = false;
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            pauseBackground.gameObject.SetActive(false);
            Time.timeScale = 1;
            playerShip.GetComponent<PlayerShipController>().enabled = true;
        }
    }

    public void PauseStartingScreen()
    {
        if (openingScreen.gameObject.activeInHierarchy == false)
        {
            openingScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            playerShip.GetComponent<PlayerShipController>().enabled = false;
        }
        else
        {
            openingScreen.gameObject.SetActive(false);
            controlsAndObjectivesScreen.gameObject.SetActive(true);
        }
    }

    public void ClosingCreditsScreen()
    {
        if (creditsScreen.gameObject.activeInHierarchy == false)
        {
            creditsScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            playerShip.GetComponent<PlayerShipController>().enabled = false;
        }
    }

    public void ControlsAndObjectivesScreen()
    {
        if(controlsAndObjectivesScreen.gameObject.activeInHierarchy == true)
        {
            controlsAndObjectivesScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
            playerShip.GetComponent<PlayerShipController>().enabled = true;
        }
    }

    public void PauseDialogMenu()
    {
        if (dialogMenu.gameObject.activeInHierarchy == false)
        {
            dialogMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            playerShip.GetComponent<PlayerShipController>().enabled = false;
        }
        else
        {
            dialogMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
            playerShip.GetComponent<PlayerShipController>().enabled = true;
            playerShip.GetComponent<PlayerShipController>().ringBell();
            playerShipUI.GetComponent<UIPlayerShip>().timerStarted = true;
        }
    }

    public void EndGameMenu(bool wonGame)
    {
        endMenu.gameObject.SetActive(true);
        pauseBackground.gameObject.SetActive(true);
        Time.timeScale = 0;
        playerShip.GetComponent<PlayerShipController>().enabled = false;

        if (wonGame)
        {
            endText.text = "You won!";
        }
        else
        {
            endText.text = "You Lost!";
        }
    }


    public void Restart()
    {
        pauseMenu.gameObject.SetActive(false);
        pauseBackground.gameObject.SetActive(false);
        Time.timeScale = 1;
        //playerShip.GetComponent<PlayerShipController>().enabled = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
