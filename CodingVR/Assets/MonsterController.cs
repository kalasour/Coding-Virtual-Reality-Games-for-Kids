using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp = 100;
    public Animation_controller Anim;
    public TextMeshPro HP;
    void Start()
    {
        Anim = gameObject.GetComponent<Animation_controller>();

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
            HP.SetText((int)hp + " HP");
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
            if (collision.gameObject.GetComponent<Bullet>().Tag == gameObject.tag) return;
            float damage = 10;
            hp -= damage;
            Anim.DamageAni();
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "sword" && Anim.isCanAttack())
        {
            float damage = collision.gameObject.GetComponent<Sword>().damage;
            hp -= damage;
            Anim.DamageAni();
        }
        else if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            if (collision.gameObject.GetComponent<Bullet>().Tag == gameObject.tag) return;
            float damage = 10;
            hp -= damage;
            Anim.DamageAni();
        }
    }
}
