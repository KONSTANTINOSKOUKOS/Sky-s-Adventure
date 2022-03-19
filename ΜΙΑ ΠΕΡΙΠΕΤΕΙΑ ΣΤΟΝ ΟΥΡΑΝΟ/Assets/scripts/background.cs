using UnityEngine;

public class background : MonoBehaviour
{
    public float speed, startx, endx;
    public bool front;
    /*void Start()
    {
        if (front)
            transform.position = new Vector2(endx, transform.position.y);
        else
            transform.position = new Vector2(startx, transform.position.y);
    }*/

    void Start(){
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= endx)
        {
            transform.position = new Vector3(startx, transform.position.y, 10.0f);
        }
    }
}
