﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attakcer : MonoBehaviour {
    private Transform target;
    public GameObject projectile;

    public float maximumLookDistance = 30;
    public float maximumAttackDistance = 10;
    public float minimumDistanceFromPlayer = 2;

    public float rotationDamping = 2;

    public float shotInterval = 0.5f;

    private float shotTime = 0;
    void Start () {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    void Update () {
        var distance = Vector3.Distance (target.position, transform.position);

        if (distance <= maximumLookDistance) {
            LookAtTarget ();

            //Check distance and time
            //if (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval)
            // {
            //     Shoot();
            // }
        }
    }

    public bool canShoot () {
        var distance = Vector3.Distance (target.position, transform.position);
        return (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval);
    }
    void LookAtTarget () {
        var dir = target.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation (dir);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    public void Shoot () {
        //Reset the time when we shoot
        shotTime = Time.time;
        GameObject clone = Instantiate (projectile);
        clone.GetComponent<Bullet> ().speed = 100;
        clone.transform.localScale *= 3;
        Instantiate (clone, transform.position + (target.position - transform.position).normalized, Quaternion.LookRotation (target.position - transform.position));
    }
}