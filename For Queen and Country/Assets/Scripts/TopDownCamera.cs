using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {

    public float panSpeed = 10f;
    public bool onSurface = false;
    private int currentObject = 0;

    public Transform rock;
    public Transform windArea;
    public Transform enemyShip;
    public Transform cannon;
    //public GameObject rockCursor;

    public GameObject[] cursorArray = new GameObject[4];
    public GameObject cursor;

    RaycastHit hit;

    private void Start()
    {
        cursorArray[1].SetActive(false);
        cursorArray[2].SetActive(false);
        cursorArray[3].SetActive(false);
        cursor = cursorArray[0];
        var raycast = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raycast, out hit, 20f))
        {
            cursor.transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.W))
        {
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            panSpeed *= 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            panSpeed /= 3;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cursor.SetActive(false);
            cursor = cursorArray[0];
            cursor.SetActive(true);
            currentObject = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cursor.SetActive(false);
            cursor = cursorArray[1];
            cursor.SetActive(true);
            currentObject = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cursor.SetActive(false);
            cursor = cursorArray[2];
            cursor.SetActive(true);
            currentObject = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cursor.SetActive(false);
            cursor = cursorArray[3];
            cursor.SetActive(true);
            currentObject = 3;
        }


        var raycast = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raycast, out hit, 20f))
        {
            onSurface = true;
            cursor.transform.position = hit.point;
        }
        else
        {
            onSurface = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onSurface)
        {
            if(cursor.GetComponent<CursorCollision>().GetCollision() == false)
            {
                print("Hit space and raycast hit");
                PlaceObjectType();
            }
        }


    }

    private void PlaceObjectType()
    {
        switch (currentObject)
        {
            case 0:
                Instantiate(rock, hit.point, Quaternion.identity);
                break;
            case 1:
                Instantiate(windArea, hit.point, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyShip, hit.point, Quaternion.identity);
                break;
            case 3:
                Instantiate(cannon, hit.point, Quaternion.identity);
                break;
            default:
                break;
        }

    }



}
