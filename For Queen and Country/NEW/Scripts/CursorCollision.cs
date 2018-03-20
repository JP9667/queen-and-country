using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCollision : MonoBehaviour {

    private bool isColliding = false;
    private int numCollisions = 0;
    private string cursorName;

    public Color collisionColor;
    public Color normalColor;
    public Renderer rend;

    private void Start()
    {
        cursorName = transform.name;
        rend = GetComponent<Renderer>();
        normalColor = rend.material.color;
        collisionColor = rend.material.color;
        collisionColor.r += 50.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(cursorName == "Rock Cursor")
        {
            if (other.gameObject.transform.tag == "Rock")
            {
                isColliding = true;
                numCollisions++;
                rend.material.color = collisionColor;
            }
        }
        else if (cursorName == "Wind Cursor")
        {
            print(cursorName + " on trigger enter " + other.gameObject.transform.tag);
            if (other.gameObject.transform.tag == "Wind Area")
            {
                print(cursorName + " and entering " + other.gameObject.transform.tag);
                isColliding = true;
                numCollisions++;
                rend.material.color = collisionColor;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (cursorName == "Rock Cursor")
        {
            if (other.gameObject.transform.tag == "Rock")
            {
                numCollisions--;
                if (numCollisions == 0)
                {
                    isColliding = false;
                    rend.material.color = normalColor;
                }
            }
        }
        else if(cursorName == "Wind Cursor")
        {
            print(cursorName + " on trigger exit " + other.gameObject.transform.tag);
            if (other.gameObject.transform.tag == "Wind Area")
            {
                print(cursorName + " and exiting" + other.gameObject.transform.tag);
                numCollisions--;
                if (numCollisions == 0)
                {
                    isColliding = false;
                    rend.material.color = normalColor;
                }
            }
        }
    }

    public bool GetCollision()
    {
        return isColliding;
    }

}
