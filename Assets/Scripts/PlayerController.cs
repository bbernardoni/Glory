using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveForce;
	public float maxSpeed;
	public float mouseSensitivity;
	public CameraController camControl;
	public AttackScript weapon;
	public float maxHP;
	public float iTime;

	private float currentHP;
	private float lastHitTime;
	private Rigidbody rb;
	private Renderer rend;
	private Color color;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		currentHP = maxHP;
		lastHitTime = 0f;

		rend = gameObject.transform.GetChild(1).GetComponent<Renderer>();
		color = Color.blue;
		rend.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {

		//movement stuff

		//records player inputs
		float sideways = Input.GetAxis ("Horizontal");
		float forward = Input.GetAxis ("Vertical");

		float rotY = Input.GetAxis ("Mouse X");
		float rotX = Input.GetAxis ("Mouse Y");

		//rotates the player and camera
		gameObject.transform.Rotate (0f, rotY * mouseSensitivity, 0f);
		camControl.rotateCamera (rotX);

		//moves the player
		Vector3 forceVector = new Vector3 (sideways * moveForce, 0f, forward * moveForce);
		rb.AddRelativeForce (forceVector);

		//these cap the player's max speed in the x and z directions
		if (Mathf.Abs(rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector3(maxSpeed * Mathf.Sign(rb.velocity.x), 0f, rb.velocity.z);

		if (Mathf.Abs (rb.velocity.z) > maxSpeed)
			rb.velocity = new Vector3(rb.velocity.x, 0f, maxSpeed * Mathf.Sign (rb.velocity.z));

		//attack stuff

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			weapon.Swing ();
		}

		if (currentHP < 0f) {
			print ("you dead kid, stop playing");
		}

	}

	public void changeHealthPool(float deltaHP, float angleOfAttack){
		if(Time.time - lastHitTime > iTime) {
			lastHitTime = Time.time;
			currentHP += deltaHP;
			Vector3 knockBack = new Vector3(300.0f, 100.0f, 0.0f);
			rb.AddForce(Quaternion.Euler(0, angleOfAttack, 0) * knockBack);
		}

		if (currentHP > maxHP) {
			currentHP = maxHP;
		}
	}

	public void changePower(float deltaPower){
		Sword sword = gameObject.GetComponentInChildren<Sword> ();
		sword.damage += deltaPower;
	}

	public void lengthSword(float deltaLength) {
		Sword sword = gameObject.GetComponentInChildren<Sword> ();
		sword.lengthenSword (deltaLength);
	}

	public void destroyedEnemy()
	{
		if(color.r < 0.99f)
		{
			color.r += 0.1f;
			color.b -= 0.1f;
		}
		rend.material.color = color;
	}
}
