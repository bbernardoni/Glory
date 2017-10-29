using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
	
	public float startAngle;
	public float endAngle;
	public float rotSpeed;
	private bool swinging = false;
	private float zAngle;
	public Sword weapon;

	// Use this for initialization
	void Start () {
		zAngle = transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {

		if (swinging) {
			transform.Rotate (0f, -rotSpeed, 0f);
		}

		if (swinging && transform.localEulerAngles.y <= 360 - endAngle) {
			weapon.setActive (false);
			swinging = false;
		}

		if (!swinging && transform.localEulerAngles.y > startAngle) {
			transform.Rotate (0f, rotSpeed, 0f);
		}

		if (!swinging && transform.eulerAngles.y < startAngle + 90) {
			transform.localEulerAngles = new Vector3 (0f, startAngle, zAngle);
		}
	}

	public void Swing () {
		weapon.setActive (true);
		swinging = true;
		
	}
}
