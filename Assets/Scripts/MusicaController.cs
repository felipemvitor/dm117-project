using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{

     [Tooltip("Musica de background do jogo")]
    public static AudioSource musica;

    public static MusicaController musicaControle = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        musica = GetComponent<AudioSource>(); 
        musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(MenuPauseComp.paused == true) {
            musica.Stop();
        } 
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
