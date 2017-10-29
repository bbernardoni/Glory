using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float damage;
	private bool active = false;

	void OnTriggerEnter(Collider coll){
		if (active && coll.CompareTag("Enemy")) {
			Enemy enemyScript = coll.gameObject.GetComponent<Enemy> ();
			enemyScript.takeDamage (damage);
		}
	}

	public void setActive(bool state){
		active = state;
	}

	public void lengthenSword(float deltaLength) {
		Vector3 scale = gameObject.transform.localScale;
		gameObject.transform.localScale = new Vector3 (scale.x + deltaLength, scale.y, scale.z);
	}
}
