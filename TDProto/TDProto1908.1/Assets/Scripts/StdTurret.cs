using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StdTurret : MonoBehaviour
{
    
	private Transform target;
	
	[Header("Attributes")]
	public float range = 15f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;

	[Header("Unity Setup Fields")]
	private string enemyTag = "Enemy";
	public Transform partToRotate;
	public float trackSpeed =10f;

	public GameObject bulletPrefab;
	public Transform firePoint;



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
		return;
		//target lock and trackSpeed
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * trackSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (fireCountdown <= 0f)
		{
			ShootBullet();
			fireCountdown  = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	void ShootBullet ()
	{
        //instatiate a GameObject of bullet class in StdTurret by casting

		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.TargetSeek(target);
        
        Debug.Log("Bullet Shot");
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);

	}

}
