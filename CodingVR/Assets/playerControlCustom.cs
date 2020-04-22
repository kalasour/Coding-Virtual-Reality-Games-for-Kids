using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlCustom : MonoBehaviour
{
    // Start is called before the first frame update

    public SimpleHealthBar healthBar;
    public float HP = 100;
    public PauseRoom pauseRoom;
    void Start()
    {
        pauseRoom = GameObject.Find("ROOM").GetComponent<PauseRoom>();
    }

    // Update is called once per frame
    public bool isLife()
    {
        return HP > 0;
    }
    void FixedUpdate()
    {
        healthBar.UpdateBar(HP, 100);
        if (!isLife()) {
            pauseRoom.Die();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            if (collision.gameObject.GetComponent<Bullet>().Tag == gameObject.tag) return;
            float damage = 10;
            HP -= damage;
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            if (collision.gameObject.GetComponent<Bullet>().Tag == gameObject.tag) return;
            float damage = 10;
            HP -= damage;


        }
    }
}
