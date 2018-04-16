using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockCollision : MonoBehaviour {

    public bool playerShipHasDocked = false;
    public GameObject pauseController;
    public GameObject playerShipUI;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player Ship" && !playerShipHasDocked)
        {
            playerShipHasDocked = true;
            pauseController.GetComponent<PauseController>().PauseDialogMenu();
            playerShipUI.GetComponent<UIPlayerShip>().timerStarted = true;

        }
    }


}
