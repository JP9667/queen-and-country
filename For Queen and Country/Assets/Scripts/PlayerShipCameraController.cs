using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCameraController : MonoBehaviour {

    public float mouseSensitivity = 4.0f;
    public float rotationSmoothTime = 8;

    public Vector2 pitchMinMax = new Vector2(-40, 85);

    private Vector3 currentRotation;
    private float yaw;
    private float pitch;

    // Use this for initialization
    //void Start () {
		
	//}
	
	// Update is called once per frame
	void LateUpdate () {

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);

        transform.eulerAngles = currentRotation;
    }
}
