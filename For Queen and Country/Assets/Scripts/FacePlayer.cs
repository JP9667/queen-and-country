using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {
    public Transform player;
    Quaternion originalTransform; //location + rotation
	// Use this for initialization
	void Start () {
      //  originalTransform = transform.rotation; //object, manipulate w/ cam rotation
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 faceDirection = new Vector3(player.position.x, player.position.y - 270, 90);
        transform.LookAt(faceDirection, Vector3.up);
        //Vector3 dirFromMeToTarget = (player.position - transform.position); // we get the angle has to be rotated
        //dirFromMeToTarget.x = 90.0f;
        //Quaternion lookRotation = Quaternion.LookRotation(dirFromMeToTarget);
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5); // we rotate the rotationAngle 
        //transform.rotation = player.rotation * originalTransform;
    }
}
