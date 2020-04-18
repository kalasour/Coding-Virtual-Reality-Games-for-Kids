using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 3;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
