using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject OVR = null;
    public float damage = 1;
    public float damageInterval = 0.5f;
    public float shotTime = 0;
    private AudioSource aSource;
    public bool isDeal = false;
    void Start()
    {
        OVR = GameObject.Find("OVRPlayerController");
        aSource = gameObject.AddComponent<AudioSource>();
        aSource.clip = Resources.Load<AudioClip>("sounds/" + "damaged");
        aSource.spatialBlend = 1f;
        aSource.loop = true;
        aSource.rolloffMode = AudioRolloffMode.Custom;
        aSource.maxDistance = 1000;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDeal)
        {
            if (!aSource.isPlaying)
                aSource.Play();
            if ((Time.time - shotTime) > damageInterval)
                Deal();
        }
        else
        {
            aSource.Stop();
        }
    }
    public void Deal()
    {
        shotTime = Time.time;
        OVR.GetComponent<playerControlCustom>().HP -= damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == OVR) isDeal = true;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == OVR) isDeal = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == OVR) isDeal = false;
    }

}
