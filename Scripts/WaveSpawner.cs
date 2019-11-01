using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;
	public Wave[] waves;
	public Wave[] waves2;

	public Wave[] waves3;

	public Transform spawnPoint1;

	public Transform spawnPoint2;
	public Transform spawnPoint3;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f; //create countdown float that decreases with time

	public int spawnPoints = 1;

	public Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex = 0;

	void Start ()
	{
		EnemiesAlive = 0;
	}
	
	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length && PlayerStats.Lives>0)
		{
			gameManager.WinLevel();
			this.enabled = false; //disables this script
		}

		if (countdown <= 0f) //when the countdown ends spawn a wave
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves; //reset countdown
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;
		if (spawnPoints == 1)
		{
			Wave wave = waves[waveIndex];
			EnemiesAlive = wave.count;

			for (int i = 0; i < wave.count; i++)
			{
				SpawnEnemy(wave.enemy, spawnPoint1);
				yield return new WaitForSeconds(1f / wave.rate);
			}
			waveIndex++;
		}

		if (spawnPoints == 2)
		{
			Wave wave = waves[waveIndex];
			Wave wave2 = waves2[waveIndex];
			EnemiesAlive = wave.count + wave2.count;

			for (int i = 0; i < wave.count; i++)
			{
				SpawnEnemy(wave.enemy, spawnPoint1);
				SpawnEnemy(wave2.enemy, spawnPoint2);
				yield return new WaitForSeconds(1f / wave.rate);
			}
			waveIndex++;
		}

		if (spawnPoints == 3)
		{
			Wave wave = waves[waveIndex];
			Wave wave2 = waves2[waveIndex];
			Wave wave3 = waves3[waveIndex];
			EnemiesAlive = wave.count + wave2.count + wave3.count;

			for (int i = 0; i < wave.count; i++)
			{
				SpawnEnemy(wave.enemy, spawnPoint1);
				SpawnEnemy(wave2.enemy, spawnPoint2);
				SpawnEnemy(wave3.enemy, spawnPoint3);
				yield return new WaitForSeconds(1f / wave.rate);
			}
			waveIndex++;
		}
		
	}

	void SpawnEnemy (GameObject enemy, Transform spawnPoint)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}