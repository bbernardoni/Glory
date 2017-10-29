using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float maxHP;

	private GameController gc;
	private PlayerController pc;
	private float currentHP;
	private Transform target;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		currentHP = maxHP;
		rb = gameObject.GetComponent<Rigidbody> ();
	}

    // Update is called once per frame
    void Update () {
		if (currentHP <= 0)
        {
            pc.destroyedEnemy();
			gc.enemyEliminated();
            Destroy (gameObject);
		}

        target = GameObject.FindGameObjectWithTag("Player").transform;

        var delta = target.position - transform.position;
		var angle = Mathf.Atan2(delta.z, delta.x) * Mathf.Rad2Deg;
		var rotation = Quaternion.Euler(0, -(angle - 90), 0);
		transform.rotation = rotation;

        var spearTipDelta = target.position - gameObject.transform.GetChild(1).position;
		if(spearTipDelta.magnitude < 1.5f) {
			gc.reportHitTaken ();
            pc.changeHealthPool(-10.0f, -angle);
		} else if (rb.velocity.z < 30) {
            rb.AddRelativeForce(0.0f, 0.0f, 13.0f);
        }

	}

	public void takeDamage(float damage){
		currentHP -= damage;
		rb.AddRelativeForce (0f, 300f, -300f);
	}
}
