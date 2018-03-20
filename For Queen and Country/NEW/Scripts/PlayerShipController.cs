using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    public float speed = 0.075f;
    public float steerSpeed = 0.75f;
    public float movementThreshold;
    public float cannonballSpeed = 20.0f;

    //public bool inWindZone = false;
    //private Rigidbody rb;

    private float movementFactor;
    private float steerFactor;

    public GameObject cannonball;
    public GameObject[] portCannons = new GameObject[3];
    private GameObject[] portCannonballs = new GameObject[3];
    public GameObject[] starBoardCannons = new GameObject[3];
    private GameObject[] starBoardCannonballs = new GameObject[3];

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        /*float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if(vAxis < 0)
        {
            vAxis *= 0.15f;
        }

        Vector3 movement = new Vector3(-vAxis, 0, hAxis) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);*/

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        movementFactor = Mathf.Lerp(movementFactor, vAxis, Time.deltaTime / movementThreshold);

        transform.Translate(-(movementFactor) * speed, 0.0f, 0.0f);

        steerFactor = Mathf.Lerp(steerFactor, hAxis * vAxis, Time.deltaTime / movementThreshold);

        transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            for(int i = 0; i < 3; i++)
            {
                //Vector3 cannonExit = new Vector3(portCannons[i].transform.position.x, portCannons[i].transform.position.y, portCannons[i].transform.position.z - 0.1f);
                portCannonballs[i] = Instantiate(cannonball, portCannons[i].transform.position, portCannons[i].transform.rotation);
                portCannonballs[i].GetComponent<Rigidbody>().velocity = portCannonballs[i].transform.forward * cannonballSpeed;
                Destroy(portCannonballs[i], 1.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < 3; i++)
            {
                starBoardCannonballs[i] = Instantiate(cannonball, starBoardCannons[i].transform.position, starBoardCannons[i].transform.rotation);
                starBoardCannonballs[i].GetComponent<Rigidbody>().velocity = starBoardCannonballs[i].transform.forward * cannonballSpeed;
                Destroy(starBoardCannonballs[i], 1.0f);
            }
        }
    }

    /*private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.left * 2 - rb.velocity);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Rock")
        {
            print("You lose!");
        }

        if (collision.gameObject.transform.tag == "Dock")
        {
            print("You win!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
