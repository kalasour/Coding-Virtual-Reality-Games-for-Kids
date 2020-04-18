using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Test : MonoBehaviour
{

    public const string IDLE = "Anim_Idle";
    public const string RUN = "Anim_Run";
    public const string ATTACK = "Anim_Attack";
    public const string DAMAGE = "Anim_Damage";
    public const string DEATH = "Anim_Death";
    private string currentAnim = "";
    public bool isDeath = false;
    public bool isAttack = false;
    attakcer att;
    Animation anim;
    public GameObject dropItem;

    void Start()
    {
        currentAnim = IDLE;
        anim = GetComponent<Animation>();
        att = GetComponent<attakcer>();

    }

    private void Update()
    {
        if (att.canShoot() && isCanAttack() && !isAttack)
        {
            isAttack = true;
            AttackAni();
        }
        if (!anim.isPlaying)
        {
            if (isDeath)
            {
                Object.Destroy(gameObject, 0.5f);
                dropItem.SetActive(true);
            }
            else if (isAttack)
            {
                att.Shoot();
                isAttack = false;
            }
            else
            {
                currentAnim = IDLE;
                anim.Play(IDLE);
            }
        }
    }

    public void IdleAni()
    {
        currentAnim = IDLE;
        anim.CrossFade(IDLE);
    }

    public bool isCanAttack()
    {
        return currentAnim == IDLE || currentAnim == ATTACK || currentAnim == RUN;
    }

    public void RunAni()
    {
        currentAnim = RUN;
        anim.CrossFade(RUN);
    }

    public void AttackAni()
    {
        currentAnim = ATTACK;
        anim.CrossFade(ATTACK);
    }

    public void DamageAni()
    {
        currentAnim = DAMAGE;
        anim.CrossFade(DAMAGE);

    }

    public void DeathAni()
    {
        currentAnim = DEATH;
        isDeath = true;
        anim.CrossFade(DEATH);
    }

}
