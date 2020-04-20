using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakeSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource aSource;
    public string sound = "";
    public float volume = 1f;
    public float maxDistance = 100;
    public bool loop = false;
    void Start()
    {
        if (sound != "")
        {
            aSource = gameObject.AddComponent<AudioSource>();
            aSource.clip = Resources.Load<AudioClip>("sounds/" + sound);
            aSource.spatialBlend = 1f;
            aSource.loop = loop;
            aSource.volume = volume;
            aSource.rolloffMode = AudioRolloffMode.Custom;
            aSource.maxDistance = maxDistance;
            aSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
