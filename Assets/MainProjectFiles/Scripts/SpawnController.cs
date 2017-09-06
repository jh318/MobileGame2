using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public EnemyController enemyPrefab;
	public float spawnRadius;
	public float spawnTime;

	private List<EnemyController> enemyPool = new List<EnemyController>();

	void Start(){
		StartCoroutine ("SpawnCoroutine");
	}

	void OnEnabled(){
		StartCoroutine ("SpawnCoroutine");
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, spawnRadius);
	}

	IEnumerator SpawnCoroutine(){
		while (enabled) {
			EnemyController e = SpawnEnemy ();
			e.transform.position = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;
			yield return new WaitForSeconds (spawnTime);
		}
	}

	EnemyController SpawnEnemy(){
		EnemyController enemy = null;

		for (int i = 0; i < enemyPool.Count; i++) {
			EnemyController e = enemyPool [i];
			if (!e.gameObject.activeSelf) {
				enemy = e;
				break;
			}
		}
		if (enemy == null) {
			enemy = Instantiate (enemyPrefab) as EnemyController;
			enemyPool.Add (enemy);
		}
		
		enemy.gameObject.SetActive (true);
		return enemy;
	}
}

