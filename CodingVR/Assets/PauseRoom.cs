using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 lastPlace = Vector3.zero;
    public GameObject Player = null;
    public Transform Center = null;
    public bool isPause = false;
    public GameObject ENVI = null;
    public GameObject LeftCanvas = null;
    public GameObject RightCanvas = null;
    public CharacterController playerController;
    bool canPress = true;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        lastPlace = Player.transform.position;
        ENVI = GameObject.Find("ENVIRO_INTERACTABLE");
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "center")
            {
                Center = transform.GetChild(i).transform;
            }
        }
        LeftCanvas = GameObject.Find("LeftCanvas");
        RightCanvas = GameObject.Find("RightCanvas");
        if (Player != null)
        {
            playerController = Player.GetComponent<CharacterController>();
        }

    }

    // Update is called once per frame
    public void toggle()
    {
        if (!isPause) lastPlace = Player.transform.position;
        else Player.transform.position = lastPlace;
        isPause = !isPause;
    }
    void Update()
    {
        if (Player == null || Center == null) return;
        if (Input.GetKeyDown(KeyCode.Escape) || OVRInput.GetDown(OVRInput.Button.Four))
        {
            toggle();

        }
        if (isPause)
        {
            Pause();
            canPress = false;
        }
        else
        {
            Unpause();
            canPress = false;
        }
    }

    public void Unpause()
    {
        Player.transform.parent = null;

        if (playerController != null)
        {
            playerController.enabled = true;
        }



        ENVI.SetActive(true);
    }
    public void Pause()
    {

        if (playerController != null)
        {
            playerController.enabled = false;
        }
        Player.transform.parent = Center;
        Player.transform.localPosition = Vector3.zero;

        ENVI.SetActive(false);

    }
}
