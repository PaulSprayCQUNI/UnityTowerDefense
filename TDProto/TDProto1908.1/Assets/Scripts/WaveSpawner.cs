using UnityEngine;
using System.Collections;

// use instatiate to spawn 
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
	public Transform spawnPoint;

	public float waveInterval = 5f;
	private float countdown = 2f;

	private int waveIndex = 0;

	void Update()
	{
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = waveInterval;
		}

		countdown -= Time.deltaTime;
	}
	
	IEnumerator SpawnWave()
	{
	Debug.Log("Wave Incoming");
	for (int i= 0; i < waveIndex; i++) 
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}	

		waveIndex++;
	}
	
	void SpawnEnemy()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
	

}
