using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonFire : MonoBehaviour
{
    public GameObject Cannon;
    public GameObject CannonBall;
    public float targetTime = 5.0f;
    public int numCannonBalls = 5;

    void Start()
    {

    }

    // Update is called once per frame

    void Update() //handle cannon movement
    {


    }

    private void OnTriggerEnter(Collider other)
    {

        //targetTime -= Time.deltaTime;
        if (other.gameObject.transform.tag == "Player Ship")
        {
            if (numCannonBalls > 0)
            {
                // targetTime = 5.0f; //reset time, it will perpetually run
                GameObject newBullet = GameObject.Instantiate(CannonBall, Cannon.transform.position, Cannon.transform.rotation) as GameObject;
                newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 10;
                newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.right * 1500);
                numCannonBalls -= 1;
                Destroy(newBullet, 1.0f); //gets rid of shot cannons after a second
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        numCannonBalls = 5; //reset 
    }
}
