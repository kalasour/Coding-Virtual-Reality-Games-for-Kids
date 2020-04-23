using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codable : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isUp = false;
    public bool isJump = false;
    public bool isForward = false;
    public bool isTurned = false;
    public bool isOpen = false;
    private bool turning = false;
    private bool canTurn = true;
    public Rigidbody rb = null;
    public float jumpForce = 2.0f;
    int count = 0;
    public GameObject ray = null;
    public GameObject bat = null;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ray = (GameObject)Resources.Load("CFX3Rays", typeof(GameObject));
        if (ray != null && gameObject.GetComponent<ID>().Id != "self")
        {
            Transform clonned = Instantiate(ray, transform).transform;
            clonned.localPosition = Vector3.zero;
            ray = clonned.gameObject;
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOpen)
        {
            GameObject Door = null;
            GameObject[] controllers = GameObject.FindGameObjectsWithTag("GameController");
            for (int i = 0; i < controllers.Length; i++)
            {
                ID id = controllers[i].GetComponent<ID>();
                if (id != null)
                {
                    if (id.Id == "door")
                    {
                        Door = controllers[i];
                    }
                }
            }
            if (Door != null&&!Door.GetComponent<SceneControllerScript>().doorFlag) Door.GetComponent<SceneControllerScript>().doorToggle = true;
            if (bat != null) bat.SetActive(true);
            isOpen = false;
        }
        if (isForward)
        {
            transform.Translate(transform.forward * 0.1f, Space.World);

            isForward = false;
        }

        if (isUp)
        {
            transform.Translate(transform.up*0.1f, Space.World);

            isUp = false;
        }
        if (isJump)
        {
            if (this.GetComponent<OVRPlayerController>() != null)
                this.GetComponent<OVRPlayerController>().Jump();
            else if (rb != null)
            {

                rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce);
                //rb.velocity = new Vector3(0.0f, 2.0f, 0.0f) * jumpForce;
            }

            isJump = false;
        }
        if (isTurned && canTurn)
        {
            canTurn = false;
            turning = true;
            count = 0;
            isTurned = false;
        }
        if (!canTurn) { isTurned = false; }
        if (turning)
        {
            transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y + 1, 0);
            count++;
            if (count == 90)
            {
                turning = false;
                canTurn = true;
            }
        }


    }

    public void Turn()
    {
        isTurned = true;
    }
    public void Forward()
    {
        isForward = true;
    }

    public void Up()
    {
        isUp = true;
    }
    public void Jump()
    {
        isJump = true;
    }
    public void DoorOpen()
    {
        isOpen = true;
    }
}
