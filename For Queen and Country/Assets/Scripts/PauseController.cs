using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    public Transform pauseBackground;
    public Transform pauseMenu;
    public Transform storyMenu;
    public Transform dialogMenu;
    public Transform endMenu;

    public Transform playerShip;

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
        if (storyMenu.gameObject.activeInHierarchy == false)
        {
            storyMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            playerShip.GetComponent<PlayerShipController>().enabled = false;
        }
        else
        {
            storyMenu.gameObject.SetActive(false);
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
