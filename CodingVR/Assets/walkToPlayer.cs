using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkToPlayer : MonoBehaviour {
    private Transform target;

    public float maximumLookDistance = 30;
    public float maximumAttackDistance = 10;
    public float minimumDistanceFromPlayer = 2;

    public float rotationDamping = 2;

    public float shotInterval = 0.5f;

    private float shotTime = 0;
    public float speed = 3;
    private void Start () {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    void Update () {
        var distance = Vector3.Distance (target.position, transform.position);

        if (distance <= maximumLookDistance) {
            LookAtTarget ();
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards (transform.position, target.position, step);

        }

    }

    void LookAtTarget () {
        var dir = target.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation (dir);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }
}