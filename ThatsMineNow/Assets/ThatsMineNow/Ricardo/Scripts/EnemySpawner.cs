using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float delay = 3f;
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", delay, delay);
	}

	public void SpawnEnemy() {
		var enemy = (GameObject)Instantiate (
			            enemyPrefab,
			            transform.position,
			            transform.rotation);
	}
}
