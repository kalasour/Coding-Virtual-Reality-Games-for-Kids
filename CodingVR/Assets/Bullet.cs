using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target = null;

    public float speed = 3;

    private void Start()
    {

        if (target == null) target = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 5f);
    }
    void FixedUpdate()
    {
        if (target == null) return;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Monster"))
            Destroy(gameObject);
    }
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Monster"))
            Destroy(gameObject);
    }
}
