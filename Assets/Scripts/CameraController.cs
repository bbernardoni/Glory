using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float mouseSensitivity;

	private Vector3 offset; //stores the offset distance between the player and camera
	public float maxRot;
	public float minRot;



	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

	public void rotateCamera(float rotX){
		gameObject.transform.Rotate (-rotX * mouseSensitivity, 0f, 0f);

		if (gameObject.transform.rotation.eulerAngles.x > maxRot && gameObject.transform.rotation.eulerAngles.x < 180)
			gameObject.transform.eulerAngles = new Vector3 (maxRot, gameObject.transform.eulerAngles.y, 0f);

		if (gameObject.transform.rotation.eulerAngles.x < minRot + 360 && gameObject.transform.rotation.eulerAngles.x > 180)
			gameObject.transform.eulerAngles = new Vector3 (minRot, gameObject.transform.eulerAngles.y, 0f);
		
	}
}
