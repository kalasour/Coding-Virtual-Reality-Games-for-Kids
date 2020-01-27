using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlCustom : MonoBehaviour
{
    // Start is called before the first frame update

    public SimpleHealthBar healthBar;
    void Start()
    {

    }

    // Update is called once per frame
    public bool isLife() {
        return healthBar.GetCurrentFraction > 0;
    }
    void FixedUpdate()
    {
    }
}
