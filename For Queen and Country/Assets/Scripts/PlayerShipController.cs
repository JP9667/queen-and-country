using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    public float speed = 5f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-vAxis, 0, hAxis) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.left * 2 - rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Rock")
        {
            print("You lose!");
        }

        if (collision.gameObject.transform.tag == "Dock")
        {
            print("You win!");
        }
    }

}
