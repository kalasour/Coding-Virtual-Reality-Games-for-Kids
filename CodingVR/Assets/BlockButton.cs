using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform uiHelperPos;
    public Transform link1, link2;
    public float distance;
    public float allowDistance = 0.15f;
    public bool startOrExit = true;
    void Start()
    {
        uiHelperPos = GameObject.Find("UIHelpers").transform.GetChild(1).transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }
    Vector3 lastMousePosition = Vector3.zero;
    public void OnDrag(PointerEventData eventData)
    {

        if (lastMousePosition == Vector3.zero)
        {
            lastMousePosition = uiHelperPos.position;
        }
        else
        {
            this.ApplyDelta(uiHelperPos.position - lastMousePosition);

            lastMousePosition = uiHelperPos.position;
        }
    }


    public void ApplyDelta(Vector3 delta)
    {

        transform.position += delta;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (distance <= allowDistance)
        {
            if (startOrExit) SceneManager.LoadScene(1);
            else Application.Quit();
        }
    }

    private void Update()
    {
        distance = Vector3.Distance(link1.position, link2.position);

    }
}
