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
    public float maxShipHealth = 100.0f;
    public float currentShipHealth = 0f;

    private Rigidbody rb;

    private float movementFactor;
    private float steerFactor;
    private float currentSpeed = 0.0f;
    private float nextFire;
    private float fireRate = 1.0f;

    public GameObject cannonball;
    public GameObject[] portCannons = new GameObject[3];
    private GameObject[] portCannonballs = new GameObject[3];
    public GameObject[] starBoardCannons = new GameObject[3];
    private GameObject[] starBoardCannonballs = new GameObject[3];
    public GameObject rearCannon;
    private GameObject rearCannonball;
    public GameObject treasureChest;
    public GameObject pauseController;
    private PauseController pauseControllerScript;
    public GameObject playerUI;
    private UIPlayerShip playerUIScript;
    public GameObject soundObject;
    private AudioSource quieterAudioSource;

    float angle = 0.0f;
    float tiltSpeed = 30.0f;

    public float lineAngle = 10.0f;
    public Vector3 sidePosition;

    private AudioSource audioSource;
    public AudioClip cannonFireSound;
    public AudioClip bellRingSound;
    public AudioClip itemPickUp;
    public AudioClip keyPickUp;
    public AudioClip shipHit;
    public AudioClip cheer;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        quieterAudioSource = soundObject.GetComponent<AudioSource>();
        currentShipHealth = maxShipHealth;
        pauseControllerScript = pauseController.GetComponent<PauseController>();
        playerUIScript = playerUI.GetComponent<UIPlayerShip>();
        pauseControllerScript.PauseStartingScreen();
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
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                playerUIScript.startCannonTimer(fireRate);
                for (int i = 0; i < 3; i++)
                {
                    //Vector3 cannonExit = new Vector3(portCannons[i].transform.position.x, portCannons[i].transform.position.y, portCannons[i].transform.position.z - 0.1f);
                    portCannonballs[i] = Instantiate(cannonball, portCannons[i].transform.position, portCannons[i].transform.rotation);
                    portCannonballs[i].tag = "Player Cannonball";
                    portCannonballs[i].GetComponent<Rigidbody>().velocity = portCannonballs[i].transform.forward * cannonballSpeed;
                    Destroy(portCannonballs[i], 1.0f);
                }
                audioSource.PlayOneShot(cannonFireSound);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                playerUIScript.startCannonTimer(fireRate);
                for (int i = 0; i < 3; i++)
                {
                    starBoardCannonballs[i] = Instantiate(cannonball, starBoardCannons[i].transform.position, starBoardCannons[i].transform.rotation);
                    starBoardCannonballs[i].tag = "Player Cannonball";
                    starBoardCannonballs[i].GetComponent<Rigidbody>().velocity = starBoardCannonballs[i].transform.forward * cannonballSpeed;
                    Destroy(starBoardCannonballs[i], 1.0f);
                }
                audioSource.PlayOneShot(cannonFireSound);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                playerUIScript.startCannonTimer(fireRate);

                rearCannonball = Instantiate(cannonball, rearCannon.transform.position, rearCannon.transform.rotation);
                rearCannonball.tag = "Player Cannonball";
                rearCannonball.GetComponent<Rigidbody>().velocity = rearCannonball.transform.forward * cannonballSpeed;
                Destroy(rearCannonball, 1.0f);
                audioSource.PlayOneShot(cannonFireSound);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Cannon Ball")
        {
            Destroy(collision.gameObject);

            currentShipHealth -= 5;
            playerUIScript.setHealthBar(currentShipHealth, maxShipHealth);

            if (currentShipHealth <= 0)
            {
                pauseControllerScript.EndGameMenu(false);
            }

            quieterAudioSource.PlayOneShot(shipHit);
        }

        if (collision.gameObject.transform.tag == "Item Pickup")
        {
            Destroy(collision.gameObject);

            currentShipHealth += 1.5f;
            if (currentShipHealth >= 100)
            {
                currentShipHealth = 100;
            }

            playerUIScript.setHealthBar(currentShipHealth, maxShipHealth);
            playerUIScript.timeLeft += 1.2f;

            if(collision.transform.name == "Enemy Ship Pickup(Key)")
            {
                quieterAudioSource.PlayOneShot(keyPickUp);
                hasKey = true;
            }
            else
            {
                audioSource.PlayOneShot(itemPickUp);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Dock")
        {
            print("You win!");
            pauseControllerScript.EndGameMenu(true);
        }
    }

    public void PickupTreasure()
    {
        //audioSource.PlayOneShot(cheer);
        treasureChest.SetActive(true);
    }

    public void TimeRanOut()
    {
        pauseControllerScript.EndGameMenu(false);
    }

    public void ringBell()
    {
        audioSource.PlayOneShot(bellRingSound);
    }

}
