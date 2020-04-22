using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORB : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject forceField = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        if (forceField != null)
            Destroy(forceField);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>() != null)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
            Destroy(gameObject);
    }
}
