using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;

	public float startHealth = 100;
	private float health;

	public int worth = 50;

	public GameObject deathEffect;

	[Header("Duplicate Ability")]
	public bool duplicate = false;
	public GameObject duplicateEnemies;

	[Header("Reborn Ability")]
	public bool reborn = false;
	public GameObject rebornEnemy;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;

	void Start()
	{
		health = startHealth;
		speed = startSpeed;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		healthBar.fillAmount = health/startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow(float pct)
	{
		speed = startSpeed*(1f - pct);
	}

	void Die()
	{
		isDead = true;

		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--; 

		Destroy(gameObject);
		
		if (reborn == true)
		{
			WaveSpawner.EnemiesAlive++;
			GameObject reborns = (GameObject)Instantiate(rebornEnemy, transform.position, Quaternion.identity);
			reborn = false;
		}

		if (duplicate == true)
		{
			WaveSpawner.EnemiesAlive = WaveSpawner.EnemiesAlive + 2;
			GameObject copy1 = (GameObject)Instantiate(duplicateEnemies, transform.position, Quaternion.identity);
			GameObject copy2 = (GameObject)Instantiate(duplicateEnemies, transform.position, Quaternion.identity);
			duplicate = false;
		}
	}
}