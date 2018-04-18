using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Camera mainCamera;
    public bool isPursuingShip = false;
    public bool hasKey = false;
    public float cannonballSpeed = 13.0f;
    public float fireRate = 2.0f;
    public float cannonRange = 20.0f;

    public GameObject cannonball;
    public GameObject frontCannon;
    private GameObject newCannonball;
    public GameObject[] portCannons = new GameObject[2];
    private GameObject[] portCannonballs = new GameObject[2];
    public GameObject[] starBoardCannons = new GameObject[2];
    private GameObject[] starBoardCannonballs = new GameObject[2];

    private GameObject playerShip;
    private Vector3 playerShipLeft;
    private Vector3 playerShipRight;
    private float playerShipLeftDist;
    private float playerShipRightDist;
    private float nextFire;
    private float yCoordinate;
    private bool hasBeenHit = false;

    RaycastHit hit;

    public GameObject itemPickup;
    private GameObject newItemPickup;

    private AudioSource audioSource;
    public AudioClip cannonFireSound;
    public AudioClip itemWaterSplash;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (transform.name == "Enemy Ship(Key)")
        {
            hasKey = true;
        }

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //print("Enemy ship at " + transform.position);
        //print("starBoardCannons[0] at " + starBoardCannons[0].transform.position);
        yCoordinate = starBoardCannons[0].transform.position.y;

        if (isPursuingShip)
        {
            playerShipRight = playerShip.transform.position + playerShip.transform.right * 2;
            playerShipLeft = playerShip.transform.position + -(playerShip.transform.right * 2);

            playerShipRightDist = Vector3.Distance(transform.position, playerShipRight);
            playerShipLeftDist = Vector3.Distance(transform.position, playerShipLeft);

            if(playerShipRightDist < playerShipLeftDist)
            {
                navMeshAgent.SetDestination(playerShipRight);
                Debug.DrawLine(transform.position, playerShipRight, Color.red);
            }
            else
            {
                navMeshAgent.SetDestination(playerShipLeft);
                Debug.DrawLine(transform.position, playerShipLeft, Color.red);
            }
        }

    }

    public void PursuePlayerShip(GameObject playerShip)
    {
        this.playerShip = playerShip;
        isPursuingShip = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Player Cannonball")
        {
            if (!hasBeenHit)
            {
                hasBeenHit = true;
                Vector3 firingCanonPos = new Vector3(transform.position.x, yCoordinate, transform.position.z);
                newItemPickup = Instantiate(itemPickup, firingCanonPos, transform.rotation);
                newItemPickup.GetComponent<AudioSource>().PlayOneShot(itemWaterSplash);
                if(transform.name == "Enemy Ship(Key)")
                {
                    newItemPickup.transform.name = "Enemy Ship Pickup(Key)";
                }
                Destroy(transform.gameObject);
            }
        }

    }

    public void FirePortCannons()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < 2; i++)
            {
                Vector3 firingCanonPos = new Vector3(portCannons[i].transform.position.x, yCoordinate, portCannons[i].transform.position.z);
                portCannonballs[i] = Instantiate(cannonball, firingCanonPos, portCannons[i].transform.rotation);
                portCannonballs[i].GetComponent<Rigidbody>().velocity = portCannonballs[i].transform.forward * cannonballSpeed;
                Destroy(portCannonballs[i], 0.5f);
            }
            audioSource.PlayOneShot(cannonFireSound);
        }
    }

    public void FireStarboardCannons()
    {
        //print("Firing cannonball from starBoardCannons[0] at " + starBoardCannons[0].transform.position + " y pos: " + starBoardCannons[0].transform.position.y);
        //print("this.starBoardCannons[0] at " + this.starBoardCannons[0].transform.position);
        if(Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < 2; i++)
            {
                Vector3 firingCanonPos = new Vector3(starBoardCannons[i].transform.position.x, yCoordinate, starBoardCannons[i].transform.position.z);
                starBoardCannonballs[i] = Instantiate(cannonball, firingCanonPos, starBoardCannons[i].transform.rotation);
                starBoardCannonballs[i].GetComponent<Rigidbody>().velocity = starBoardCannonballs[i].transform.forward * cannonballSpeed;
                Destroy(starBoardCannonballs[i], 0.5f);
            }
            audioSource.PlayOneShot(cannonFireSound);
        }
    }

    public void FireFrontCannon()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            
            Vector3 firingCanonPos = new Vector3(frontCannon.transform.position.x, yCoordinate, frontCannon.transform.position.z);
            newCannonball = Instantiate(cannonball, firingCanonPos, frontCannon.transform.rotation);
            newCannonball.GetComponent<Rigidbody>().velocity = frontCannon.transform.forward * cannonballSpeed;
            Destroy(newCannonball, 0.5f);
            audioSource.PlayOneShot(cannonFireSound);
        }
    }

}
