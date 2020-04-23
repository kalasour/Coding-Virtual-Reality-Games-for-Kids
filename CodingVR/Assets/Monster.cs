using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public Animation_Test Anim;
    public TextMeshPro HP;
    public float hp = 100;
    void Start()
    {
        Anim = gameObject.GetComponent<Animation_Test>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0 && !Anim.isDeath)
        {
            HP.SetText("");
            Anim.DeathAni();
        }
        else if (hp > 0)
        {
            HP.SetText((int)hp + "%");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "sword" && Anim.isCanAttack())
        {
            float damage = collision.gameObject.GetComponent<Sword>().damage;
            hp -= damage;
            Anim.DamageAni();
        }
        else if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            float damage = collision.gameObject.GetComponent<Sword>().damage;
            hp -= damage;
            Anim.DamageAni();
        }
    }
}
