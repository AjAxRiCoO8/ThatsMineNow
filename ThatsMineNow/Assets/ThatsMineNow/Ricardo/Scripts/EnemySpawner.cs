using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public float delay = 3f;
	public int enemyLimit = 10;
	public GameObject enemyPrefab;

	void Update ()
	{
		SpawnEnemy ();
	}

	public void SpawnEnemy ()
	{

		delay -= Time.deltaTime;

		if (delay <= 0 && GameObject.FindGameObjectsWithTag ("Enemy").Length < enemyLimit) {
			Instantiate (
				enemyPrefab,
				transform.position,
				transform.rotation);
			delay = 2f;
		}
	}

	public void EscalateSpawner (bool escalateUp)
	{
		if (escalateUp) {
			delay /= 2;
		} else {
			delay *= 2;
		}
	}
}
