using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collectItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public TextMeshPro TMP;
    void Start()
    {
        TMP = transform.GetChild(0).GetComponent<TextMeshPro>();
        if (TMP != null && target != null) TMP.SetText(target.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (target != null)
            {
                target.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
