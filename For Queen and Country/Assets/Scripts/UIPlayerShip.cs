using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerShip : MonoBehaviour {

    public Text shipHealth;
    public Text timer;
    public Text cannonTimer;

    public GameObject playerShip;
    public GameObject playerHealthBar;
    public float timeLeft = 140.0f;
    public bool timerStarted = false;
    private float cannonTimeLeft = 0.0f;
    private bool cannonTimerStarted = false;

    private PlayerShipController playerShipController;

    // Use this for initialization
    void Start () {
        playerShipController = playerShip.GetComponent<PlayerShipController>();
        shipHealth.text = "Ship Health: " + playerShipController.currentShipHealth;
        cannonTimer.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (timerStarted)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                //timer.text = "Time Remaining: " + 0.0;
                timeLeft = 0.0f;
                playerShipController.TimeRanOut();
            }
        }
        timer.text = "Time Remaining: " + timeLeft.ToString("F1");

        if (cannonTimerStarted)
        {
            cannonTimeLeft -= Time.deltaTime;
            cannonTimer.text = cannonTimeLeft.ToString("F2");

            if (cannonTimeLeft <= 0.0f)
            {
                cannonTimer.text = "";
                cannonTimerStarted = false;
            }
        }
        
    }

    public void setHealthBar(float currentHealth, float maxHealth){
        float health = currentHealth / maxHealth;
        playerHealthBar.transform.localScale = new Vector3(Mathf.Clamp(health, 0f, 1f), playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);
        shipHealth.text = "Ship Health: " + currentHealth;
    }

    public void startCannonTimer(float fireRate)
    {
        cannonTimeLeft = fireRate;
        cannonTimerStarted = true;
    }

}
