using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCollision : MonoBehaviour {

    private bool isColliding = false;
    private int numCollisions = 0;
    private string cursorName;
    private string collisionTag;

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
        collisionTag = other.gameObject.transform.tag;

        if (cursorName == "Rock Cursor" || cursorName == "Enemy Ship Cursor")
        {
            if (collisionTag == "Rock" || collisionTag == "Enemy Ship")
            {
                print(cursorName + " and entering " + collisionTag);
                isColliding = true;
                numCollisions++;
                rend.material.color = collisionColor;
            }
        }
        else if (cursorName == "Wind Cursor")
        {
            print(cursorName + " on trigger enter " + collisionTag);
            if (collisionTag == "Wind Area")
            {
                print(cursorName + " and entering " + collisionTag);
                isColliding = true;
                numCollisions++;
                rend.material.color = collisionColor;
            }
        }
        else if (cursorName == "Cannon Cursor")
        {
            if (collisionTag != "Water")
            {
                print(cursorName + " and entering " + collisionTag);
                isColliding = true;
                numCollisions++;
                rend.material.color = collisionColor;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collisionTag = other.gameObject.transform.tag;

        if (cursorName == "Rock Cursor" || cursorName == "Enemy Ship Cursor")
        {
            if (collisionTag == "Rock" || collisionTag == "Enemy Ship")
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
            print(cursorName + " on trigger exit " + collisionTag);
            if (collisionTag == "Wind Area")
            {
                print(cursorName + " and exiting" + collisionTag);
                numCollisions--;
                if (numCollisions == 0)
                {
                    isColliding = false;
                    rend.material.color = normalColor;
                }
            }
        }
        else if (cursorName == "Cannon Cursor")
        {
            if (collisionTag != "Water")
            {
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
