using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player Ship")
        {
            if (other.gameObject.GetComponent<PlayerShipController>().hasKey)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
