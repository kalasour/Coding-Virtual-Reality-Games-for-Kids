using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeContent : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isCurrent = false;
    CanvasGroup canvasGroup;
    void Start()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null) gameObject.AddComponent<CanvasGroup>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrent)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Hide()
    {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
