using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StdTurret : MonoBehaviour
{
    
	public Transform target;
	public float range = 15f;

	public string enemyTag = "Enemy";

	void Start()
	{
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float nearestEDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < nearestEDistance)
			{
				nearestEDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && nearestEDistance <= range)
		{
			target = nearestEnemy.transform;
		} else
		{
			target = null;
		}
	
	}


	void Update()
	{
		if (target == null)
		{
			return;
		}
	
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);

	}

}
