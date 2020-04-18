using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newToggle : MonoBehaviour {
    // Start is called before the first frame update
    public CanvasGroup canvasGroup;

    private AudioSource aSource;
    public bool ActivePanel = false;
    void Start () {
        // Panel=GameObject.FindWithTag ("Panel");
        aSource=gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        if (OVRInput.GetDown(OVRInput.Button.Start)) {
            TaskOnClick();
        }
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            RunCode();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            GameObject[] found = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject i in found)
            {
                if (i.GetComponent<Boolean>() != null)
                {
                    Boolean boo = i.GetComponent<Boolean>();
                    if (boo.ID == "isB")
                    {
                        boo.value = true;
                    }
                }
            }
        }
        if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            GameObject[] found = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject i in found)
            {
                if (i.GetComponent<Boolean>() != null)
                {
                    Boolean boo = i.GetComponent<Boolean>();
                    if (boo.ID == "isB")
                    {
                        boo.value = false;
                    }
                }
            }
        }
        canvasGroup.blocksRaycasts = ActivePanel;
        if (ActivePanel && canvasGroup.alpha <= 1f) {
            canvasGroup.alpha += 0.1f;
        }
        if (!ActivePanel && canvasGroup.alpha >= 0) {
            canvasGroup.alpha -= 0.1f;
        }

    }

    public void RunCode()
    {
        Block[] allChildren = GameObject.FindWithTag("CodeContent").transform.GetComponentsInChildren<Block>();
        // Code.GetComponent<BeepBlock>().Run();
        // Debug.Log(Code);
        foreach (Block child in allChildren)
        {
            // Debug.Log (child.gameObject);
            if (child.isStartBlock) child.Run();
        }
    }

    public void TaskOnClick () {
        //Output this to console when Button1 or Button3 is clicked
       // aSource.clip=GameObject.Find("SoundBox").GetComponent<SoundBox>().Command;
		//if (!aSource.isPlaying) {
		//	aSource.Play ();
		//}

        ActivePanel = !ActivePanel;

        // Debug.Log (GameObject.FindWithTag ("Canvas").GetComponent<CanvasScripts> ().ActivePanel);
    }
}