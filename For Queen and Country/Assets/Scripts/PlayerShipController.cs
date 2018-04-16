using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    public float speed = 0.01f;
    public float maxSpeed = 0.05f;
    public float acceleration = 1.0f;
    public float steerSpeed = 0.5f;
    public float movementThreshold;
    public float cannonballSpeed = 20.0f;
    public bool hasKey = false;
    public float shipHealth = 100.0f;

    //public bool inWindZone = false;
    private Rigidbody rb;

    private float movementFactor;
    private float steerFactor;
    private float currentSpeed = 0.0f;

    public GameObject cannonball;
    public GameObject[] portCannons = new GameObject[3];
    private GameObject[] portCannonballs = new GameObject[3];
    public GameObject[] starBoardCannons = new GameObject[3];
    private GameObject[] starBoardCannonballs = new GameObject[3];
    public GameObject rearCannon;
    private GameObject rearCannonball;
    public GameObject treasureChest;
    public GameObject pauseController;

    float angle = 0.0f;
    float tiltSpeed = 30.0f;

    public float lineAngle = 10.0f;
    public Vector3 sidePosition;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        var line = transform.position + transform.right;
        var rotatedLine = Quaternion.AngleAxis(lineAngle, transform.forward) * line;
        //Debug.DrawLine(transform.position, rotatedLine, Color.blue);
        //sidePosition = rotatedLine;

        //Debug.DrawLine(transform.position, transform.position + transform.right * 2, Color.red);
        sidePosition = transform.position + transform.right * 2;


        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        movementFactor = Mathf.Lerp(movementFactor, vAxis, Time.deltaTime / movementThreshold);
        rb.AddForce(-(transform.up * movementFactor * 4.5f));

        steerFactor = Mathf.Lerp(steerFactor, hAxis, Time.deltaTime / movementThreshold);
        transform.Rotate(0.0f, 0.0f, steerFactor * steerSpeed);

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            for(int i = 0; i < 3; i++)
            {
                //Vector3 cannonExit = new Vector3(portCannons[i].transform.position.x, portCannons[i].transform.position.y, portCannons[i].transform.position.z - 0.1f);
                portCannonballs[i] = Instantiate(cannonball, portCannons[i].transform.position, portCannons[i].transform.rotation);
                portCannonballs[i].tag = "Player Cannonball";
                portCannonballs[i].GetComponent<Rigidbody>().velocity = portCannonballs[i].transform.forward * cannonballSpeed;
                Destroy(portCannonballs[i], 1.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < 3; i++)
            {
                starBoardCannonballs[i] = Instantiate(cannonball, starBoardCannons[i].transform.position, starBoardCannons[i].transform.rotation);
                starBoardCannonballs[i].tag = "Player Cannonball";
                starBoardCannonballs[i].GetComponent<Rigidbody>().velocity = starBoardCannonballs[i].transform.forward * cannonballSpeed;
                Destroy(starBoardCannonballs[i], 1.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            rearCannonball = Instantiate(cannonball, rearCannon.transform.position, rearCannon.transform.rotation);
            rearCannonball.tag = "Player Cannonball";
            rearCannonball.GetComponent<Rigidbody>().velocity = rearCannonball.transform.forward * cannonballSpeed;
            Destroy(rearCannonball, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.transform.tag == "Cannon Ball")
        {
            Destroy(collision.gameObject);
            shipHealth -= 5;

            if(shipHealth <= 0)
            {
                pauseController.GetComponent<PauseController>().EndGameMenu(false);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Dock")
        {
            print("You win!");
            pauseController.GetComponent<PauseController>().EndGameMenu(true);
        }
    }

    public void HasTreasure()
    {
        treasureChest.SetActive(true);
    }

    public void TimeRanOut()
    {
        pauseController.GetComponent<PauseController>().EndGameMenu(false);
    }

}
