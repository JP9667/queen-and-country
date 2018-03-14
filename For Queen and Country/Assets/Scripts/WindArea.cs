using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

    private Rigidbody rb;
    private bool playerInArea = false;
	
	// Update is called once per frame
	void Update () {
        if (playerInArea)
        {
            rb.AddRelativeForce(Vector3.back * 1.5f - rb.velocity);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player Ship")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            playerInArea = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player Ship")
        {
            playerInArea = false;
        }
    }

}
