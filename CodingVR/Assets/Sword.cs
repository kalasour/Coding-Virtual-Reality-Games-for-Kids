using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10;
    public TextMeshPro Label;
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         damage = rigidbody.velocity.magnitude*10;
        Label.text = "Damage : " + ((int)damage).ToString();
    }
}
