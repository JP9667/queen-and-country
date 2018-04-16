using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCannonColliders : MonoBehaviour {

    public bool portCannons;
    public bool starboardCannons;
    public bool frontCannon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player Ship")
        {
            if (portCannons)
            {
                transform.GetComponentInParent<EnemyShipController>().FirePortCannons();
                //transform.GetComponentInParent<EnemyShipController>().portCannonsInRange = true;
            }
            else if(starboardCannons)
            {
                transform.GetComponentInParent<EnemyShipController>().FireStarboardCannons();
                //transform.GetComponentInParent<EnemyShipController>().starboardCannonsInRange = true;
            }
            if (frontCannon)
            {
                transform.GetComponentInParent<EnemyShipController>().FireFrontCannon();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player Ship")
        {
            if (portCannons)
            {
                //transform.GetComponentInParent<EnemyShipController>().FirePortCannons();
                //transform.GetComponentInParent<EnemyShipController>().portCannonsInRange = false;
            }
            else if (starboardCannons)
            {
                //transform.GetComponentInParent<EnemyShipController>().FireStarboardCannons();
                //transform.GetComponentInParent<EnemyShipController>().starboardCannonsInRange = false;
            }

        }
    }

}
