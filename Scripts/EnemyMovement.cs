using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
	private int wavepointIndex = 0;

    private Enemy enemy;

	void Start ()
	{
        enemy = GetComponent<Enemy>();
		target = Waypoints.points[0]; //start at zeroth waypoint (Start)
	}

    void Update ()
	{
		Vector3 dir = target.position - transform.position; //Point from current position to target position
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f) //Checks if the distance between the waypoints and the enemy is less than 0.4
		{
			GetNextWaypoint(); //if it is, then poisition of next waypoint is obtained
		}

        enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint() //Gets position of next waypoint
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return; //ensures that gameObject is destroyed before changing frame
		}
		wavepointIndex++; //updates waypoint index
		target = Waypoints.points[wavepointIndex]; //makes new target the position of the new waypoint index 
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
