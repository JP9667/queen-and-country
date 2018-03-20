using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballCollision : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Enemy Ship")
        {
            print("Cannonball hit enemy ship");
        }
    }
}
