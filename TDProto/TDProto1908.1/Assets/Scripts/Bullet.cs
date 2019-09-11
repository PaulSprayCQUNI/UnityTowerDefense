using UnityEngine;

public class Bullet : MonoBehaviour
{ 
//transfer info of target of turret to bullet

    private Transform target;

    public float bulletSpeed = 50f;
    public GameObject bulletImpactEffect;
    public void TargetSeek(Transform _target)
    {

        target = _target; 
    }
 // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        // the length of the dir vector indicates the distance
        // to the target and needs to be compared to the movement required for this frame in the Update()
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Debug.Log("Our weapons are supremely effective against them Captain!");
        Destroy(effectInstance, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
