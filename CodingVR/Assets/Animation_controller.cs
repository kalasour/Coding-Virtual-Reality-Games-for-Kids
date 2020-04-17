using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_controller : MonoBehaviour {

    public string IDLE = "idle";
    public string RUN = "panic";
    public string ATTACK = "attack_1";
    public string DAMAGE = "get_hit_front";
    public string DEATH = "die";
    private string currentAnim = "";
    public bool isDeath = false;

    Animation anim;

    void Start () {
        currentAnim = IDLE;
        anim = GetComponent<Animation> ();

    }

    private void Update () {
        if (!anim.isPlaying) {
            if (isDeath) {
                Object.Destroy (gameObject, 0.5f);
            } else {
                currentAnim = IDLE;
                anim.Play (IDLE);
            }
        }
    }

    public void IdleAni () {
        currentAnim = IDLE;
        anim.CrossFade (IDLE);
    }

    public bool isCanAttack () {
        return currentAnim == IDLE || currentAnim == ATTACK || currentAnim == RUN;
    }

    public void RunAni () {
        currentAnim = RUN;
        anim.CrossFade (RUN);
    }

    public void AttackAni () {
        currentAnim = ATTACK;
        anim.CrossFade (ATTACK);
    }

    public void DamageAni () {
        currentAnim = DAMAGE;
        anim.CrossFade (DAMAGE);

    }

    public void DeathAni () {
        currentAnim = DEATH;
        anim.CrossFade (DEATH);
        isDeath = true;
    }

}