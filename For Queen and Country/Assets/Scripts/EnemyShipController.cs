using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Camera mainCamera;

    public bool isPursuingShip = false;
    public bool hasKey = false;

    private GameObject playerShip;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (transform.name == "Enemy Ship(Key)")
        {
            hasKey = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }*/

        if (isPursuingShip)
        {
            navMeshAgent.SetDestination(playerShip.transform.position);

            //Vector3.Distance(transform.position, playerShip.transform.position)


            /*Vector3 toPlayer = playerShip.transform.position - transform.position;
            if ( < 3)//playerShip.transform.position - transform.position
            {
                Vector3 targetPosition = toPlayer.normalized * -3f;
                navMeshAgent.destination = targetPosition;
                navMeshAgent.Resume();
            }*/
        }



    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player Ship")
        {
            playerShip = other.gameObject;
            isPursuingShip = true;
        }
    }*/

    public void PursuePlayerShip(GameObject playerShip)
    {
        this.playerShip = playerShip;
        isPursuingShip = true;
    }


}
