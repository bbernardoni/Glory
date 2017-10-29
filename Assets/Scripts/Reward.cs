using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour {

	public float powerIncrease;
	public float lengthIncrease;
	public float healthIncrease;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0f, 30f, 0f) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.CompareTag ("Player")) {
			PlayerController pc = coll.gameObject.GetComponent<PlayerController> ();
			pc.changePower (powerIncrease);
			pc.lengthSword (lengthIncrease);
			pc.changeHealthPool (healthIncrease, 0f);
			Destroy (gameObject);
		}
	}
}
