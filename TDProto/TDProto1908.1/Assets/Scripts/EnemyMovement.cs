﻿using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
	public float speed = 30f;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		target = Waypoints.points[0];
	}

	// dir normalized so the only thing that controls speed is the public float speed
	// deltaTime accounting for framerats variation
	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

	}

	void GetNextWaypoint()
	{
		if (wavepointIndex>= Waypoints.points.Length - 1)
		{
			Destroy(gameObject);
			return;
		}
		wavepointIndex++;
		target= Waypoints.points[wavepointIndex];
	}
}
