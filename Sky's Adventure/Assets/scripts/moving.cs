using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed;
    public Transform s, e;
    Vector3 start, end;
    Vector3 target;

    void Start()
    {
        start = s.position;
        end = e.position;
        transform.position = start/*.position*/;
        target = end/*.position*/;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == end/*.position*/)
            target = start/*.position*/;
        else if (transform.position == start/*.position*/)
            target = end/*.position*/;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(transform, true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
