using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerShip : MonoBehaviour {

    public Text shipHealth;
    public Text timer;

    public GameObject playerShip;
    public float timeLeft = 140.0f;
    public bool timerStarted = false;

    private PlayerShipController playerShipController;

    // Use this for initialization
    void Start () {
        playerShipController = playerShip.GetComponent<PlayerShipController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (timerStarted)
        {
            timeLeft -= Time.deltaTime;
        }
        
        timer.text = "Time Remaining: " + timeLeft;

        if(timeLeft == 0.0f)
        {
            playerShipController.TimeRanOut();
        }


        shipHealth.text = "Ship Health: " + playerShipController.shipHealth;
    }
}
