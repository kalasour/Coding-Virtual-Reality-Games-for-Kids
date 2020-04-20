using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10;
    public TextMeshPro Label;
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        damage = rigid.velocity.magnitude * 3;
        Label.text = "Damage : " + ((int)damage).ToString();
    }
}
