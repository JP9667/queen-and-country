using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballCollision : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Enemy Ship")
        {
            print("Cannonball hit enemy ship");
            if (other.gameObject.GetComponent<EnemyShipController>().hasKey)
            {
                GameObject.FindWithTag("Player Ship").GetComponent<PlayerShipController>().hasKey = true;
            }

            Destroy(other.gameObject);
        }

        if (other.gameObject.transform.tag == "Treasure Ship")
        {
            print("Cannonball hit treasure ship");
            GameObject.FindWithTag("Player Ship").GetComponent<PlayerShipController>().HasTreasure();
            Destroy(other.gameObject);
        }

    }
}
