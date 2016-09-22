using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SpawnEnemy ();
	}

	public void SpawnEnemy() {
		var enemy = (GameObject)Instantiate (
			            enemyPrefab,
			            transform.position,
			            transform.rotation);
	}
}
