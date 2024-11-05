using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestScript : MonoBehaviour, SeeThroughObjects
{
    MeshRenderer render;
    float invisibleAlpha;
    public float InvisibleTime = 1;
    bool isInVisible = false;
    

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
        
    }

    public void TurnInvisible()
    {
        invisibleAlpha = InvisibleTime;
        isInVisible = true;
        render.enabled = false;
    }

    private void Update()
    {
        if (isInVisible)
        {
            invisibleAlpha -= Time.deltaTime;
            if (invisibleAlpha < 0 )
            {
                render.enabled = true;
                isInVisible = false;
            }
        }
    }
}
