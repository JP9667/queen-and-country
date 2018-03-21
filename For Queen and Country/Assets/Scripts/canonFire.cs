using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonFire : MonoBehaviour
{
    public GameObject Cannon;
    public GameObject CannonBall;
    private Transform playerShip;
    public float targetTime = 5.0f;
    private float fireTime;

    public int numCannonBalls = 5;

    private bool firingAtPlayer = false;

    private void Update()
    {
        //if (firingAtPlayer)
        //{
        transform.LookAt(playerShip);
        //}

    }

    /*private void TargetPlayer()
    {
       
    }*/

    private void OnTriggerEnter(Collider other)
    {

        //targetTime -= Time.deltaTime;
        if (other.gameObject.transform.tag == "Player Ship")
        {
            playerShip = other.gameObject.transform;

            firingAtPlayer = true;



            if (numCannonBalls > 0)
            {
                // targetTime = 5.0f; //reset time, it will perpetually run
                GameObject newBullet = GameObject.Instantiate(CannonBall, Cannon.transform.position, Cannon.transform.rotation) as GameObject;
                newBullet.GetComponent<Rigidbody>().velocity = Cannon.transform.forward * 20;
                //newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.right * 1000);
                numCannonBalls -= 1;
                Destroy(newBullet, 1.0f); //gets rid of shot cannons after a second
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        firingAtPlayer = false;
        //playerShip = null;


        numCannonBalls = 5; //reset 
    }
}
