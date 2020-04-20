using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attakcer : MonoBehaviour
{
    public Transform target = null;
    public float speed = 0;
    public Transform spawnPoint = null;
    public GameObject projectile;

    public float maximumLookDistance = 30;
    public float maximumAttackDistance = 10;
    public float minimumDistanceFromPlayer = 2;

    public float rotationDamping = 2;

    public float shotInterval = 0.5f;
    public float distance = 0;
    public float shotTime = 0;
    void Start()
    {
        if (target == null) target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (target == null) return;
        distance = Vector3.Distance(target.position, transform.position);

        if (distance <= maximumLookDistance)
        {
            LookAtTarget();
            if (canShoot()) Shoot();
            //Check distance and time
            //if (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval)
            // {
            //     Shoot();
            // }
        }
    }

    public bool canShoot()
    {
        distance = Vector3.Distance(target.position, transform.position);
        return (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval);
    }
    void LookAtTarget()
    {
        var dir = target.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    public void Shoot()
    {
        //Reset the time when we shoot
        shotTime = Time.time;
        GameObject clone = Instantiate(projectile, (spawnPoint == null) ? (transform.position + (target.position - transform.position).normalized) : spawnPoint.position, Quaternion.LookRotation(target.position - transform.position));
        clone.GetComponent<Bullet>().enabled = true;
        clone.transform.parent = GameObject.Find("ENVIRO_INTERACTABLE").transform;
        if (speed != 0) clone.GetComponent<Bullet>().speed = speed;
        clone.transform.localScale *= 3;

    }
}