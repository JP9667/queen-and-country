using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballCollision : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Enemy Ship")
        {
            print("Cannonball hit enemy ship");

            Destroy(other.gameObject);
        }

        if (other.gameObject.transform.tag == "Treasure Ship")
        {
            print("Cannonball hit treasure ship");
            GameObject.FindWithTag("Player Ship").GetComponent<PlayerShipController>().PickupTreasure();
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Enemy Ship")
        {
            print("Cannonball hit enemy ship");
        }

        if (collision.gameObject.transform.tag == "Treasure Ship")
        {
            print("Cannonball hit treasure ship");
            collision.gameObject.GetComponent<WaterBuoyancy.FloatingObject>().sinkShip();
            GameObject.FindWithTag("Player Ship").GetComponent<PlayerShipController>().PickupTreasure();
            //Destroy(collision.gameObject);
        }

    }

}
