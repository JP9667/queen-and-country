using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour {

    public Camera overseer;
    public GameObject playerShip;
    public Camera playerShipCamera;
    public Camera mainCamera;

    private bool overseerActive = true;
    private bool playerShipActive = false;


	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;

        overseer.GetComponent<TopDownCamera>().enabled = true;
        playerShip.GetComponent<PlayerShipController>().enabled = false;

        transform.position = overseer.transform.position;
        transform.rotation = overseer.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && overseerActive)
        {
            overseerActive = false;
            playerShipActive = true;
            overseer.enabled = false;

            overseer.GetComponent<TopDownCamera>().enabled = false;
            playerShip.GetComponent<PlayerShipController>().enabled = true;
        }

        if (overseerActive)
        {
            transform.position = overseer.transform.position;
            transform.rotation = overseer.transform.rotation;
        }

        if (playerShipActive)
        {
            transform.position = playerShipCamera.transform.position;
            transform.rotation = playerShipCamera.transform.rotation;
        }

    }
}
