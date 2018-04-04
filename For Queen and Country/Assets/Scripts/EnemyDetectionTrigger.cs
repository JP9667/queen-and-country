using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player Ship")
        {
            transform.GetComponentInParent<EnemyShipController>().PursuePlayerShip(other.gameObject);
        }
    }
}
