using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour {

    private Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = new Vector3(0.0f, 0.5f*Mathf.Sin(8*Time.time), 0.0f);
        transform.position = startPos + delta;
	}
}
