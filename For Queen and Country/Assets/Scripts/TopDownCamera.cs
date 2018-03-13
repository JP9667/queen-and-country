using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {

    public float panSpeed = 10f;
    public bool onSurface = false;

    public Transform rock;
    public GameObject rockCursor;

    RaycastHit hit;

    private void Start()
    {
        var raycast = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raycast, out hit, 20f))
        {
            rockCursor.transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            //print("Entered W");
            //transform.position.z += panSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * panSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * panSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * panSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed, Space.Self);
        }


        var raycast = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raycast, out hit, 20f))
        {
            onSurface = true;
            rockCursor.transform.position = hit.point;
        }
        else
        {
            onSurface = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onSurface)
        {
            print("Hit space and raycast hit");
            Instantiate(rock, hit.point, Quaternion.identity);

            /* GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
             cube.AddComponent<Rigidbody>();
             cube.GetComponent<Rigidbody>().useGravity = false;
             cube.GetComponent<Rigidbody>().isKinematic = true;
             cube.transform.position = hit.point;*/
        }


    }
}
