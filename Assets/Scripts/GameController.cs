using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject enemy;
    //public GameObject eliteEnemy;
    public GameObject reward;
    public GameObject audience;
    public int enemyCount;
	public int enemyCountIncrease;
	public float waveWaitTime;
	public float enemySpawnWaitTime;
	public Transform[] enemySpawns;
    public Transform[] rewardSpawns;

    private int enemiesRemaining;
	private int hitsTaken;

    // Use this for initialization
    void Start () {
		StartCoroutine (spawnWaves ());
        for(int row = 0; row<4; row++)
            for(float ang = 0.0f; ang<Mathf.PI*2.0; ang += Mathf.PI/8)
                Instantiate(audience, new Vector3((29.7f+2.0f*row)*Mathf.Cos(ang+Mathf.PI/5*row), 9.9f+2.0f*row, (29.7f+2.0f*row)*Mathf.Sin(ang+Mathf.PI/5*row)+2.0f), Quaternion.Euler(0.0f, 90-(ang+Mathf.PI/5*row)*Mathf.Rad2Deg, 0.0f));
    }
	
	// Update is called once per frame
	void Update () {

	}

	Transform randomSpawnPoint(Transform[] spawns) {
		return spawns[(int)Random.Range (0, spawns.Length)];
	}

	IEnumerator spawnWaves() {
		while (true) {

			enemiesRemaining = enemyCount;

			//spawns grunts
			for(int i = 0; i < enemyCount; i++) {
				Transform enemySpawn = randomSpawnPoint (enemySpawns);
				Instantiate (enemy, enemySpawn.position, enemySpawn.rotation);
				yield return new WaitForSeconds (enemySpawnWaitTime);
			}

			//spawns elites, one spawns for every ten grunts
//			for (int i = 0; i < (enemyCount / 10); i++) {
//				Transform enemySpawn = randomSpawnPoint (enemySpawns);
//				Instantiate (eliteEnemy, enemySpawn.position, enemySpawn.rotation);
//				yield return new WaitForSeconds (enemySpawnWaitTime);
//			}
				
			yield return new WaitUntil (() => (enemiesRemaining == 0));

			if (hitsTaken == 0) {
				spawnRewards ();
			}
			hitsTaken = 0;

			enemyCount += enemyCountIncrease;
			yield return new WaitForSeconds (waveWaitTime);

		}
	}

	void spawnRewards () {
		Transform rewardSpawn = randomSpawnPoint (rewardSpawns);
		Instantiate (reward, rewardSpawn.position, rewardSpawn.rotation);
	}

	//called by enemies before they delete themselves
	public void enemyEliminated() {
		enemiesRemaining--;
	}

	public void reportHitTaken() {
		hitsTaken++;
	}
}
