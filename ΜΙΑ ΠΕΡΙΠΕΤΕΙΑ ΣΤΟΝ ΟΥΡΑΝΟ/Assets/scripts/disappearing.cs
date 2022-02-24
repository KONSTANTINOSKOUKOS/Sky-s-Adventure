using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearing : MonoBehaviour
{
    public float timebtw;
    float timer;

    public BoxCollider2D col;
    public SpriteRenderer sp;

    void Start()
    {
        col.enabled = true;
        sp.enabled = true;
    }

    void Update()
    {
        if (timer <= 0)
        {
            if (!col.enabled && !sp.enabled)//dis active
            {
                col.enabled = true;
                sp.enabled = true;
            }
            else if (col.enabled && sp.enabled) {//app active
                col.enabled = false;
                sp.enabled = false;
            }
            timer = timebtw;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
