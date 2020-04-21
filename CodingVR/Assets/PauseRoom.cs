using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform lastPlace = null;
    public GameObject Player = null;
    public Transform Center = null;
    public bool isPause = false;
    public GameObject ENVI = null;
    public GameObject LeftCanvas = null;
    public GameObject RightCanvas = null;
    bool canPress = true;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        lastPlace = Player.transform;
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


    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null || Center == null) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
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
        Player.transform.position = lastPlace.position;
        ENVI.SetActive(true);
    }
    public void Pause()
    {
        lastPlace = Player.transform;
        Player.transform.parent = Center;
        Player.transform.localPosition = Vector3.zero;
        ENVI.SetActive(false);

    }
}
