using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Tag = "Monster";
    public Transform target = null;
    public bool noTarget = false;
    public float speed = 3;

    private void Start()
    {

        if (target == null) target = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 5f);
    }
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (noTarget) transform.Translate(transform.forward * step, Space.World);
        else transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(Tag))
            Destroy(gameObject);
    }
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(Tag))
            Destroy(gameObject);
    }
}
