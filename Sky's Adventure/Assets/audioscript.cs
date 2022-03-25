using UnityEngine;
public class audioscript : MonoBehaviour
{
    public AudioSource music;
    static audioscript instance = null;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        music.Play();
    }
}
