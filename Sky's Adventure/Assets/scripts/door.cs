using System.Collections;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
        popup.SetActive(false); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            popup.SetActive(true);
    }

    IEnumerator popupp()
    {
        yield return new WaitForSeconds(.2f);
        popup.SetActive(true);
    }
}
