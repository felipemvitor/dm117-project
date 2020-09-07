using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{

    public static MusicaController musicaControle = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (musicaControle != null)
        {
            Destroy(gameObject);
        }
        else
        {
            musicaControle = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
