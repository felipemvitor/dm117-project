using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscinaController : MonoBehaviour
{
    [Tooltip("Audios tocados quando o jogador perder")]
    public AudioSource[] audios;

    // Start is called before the first frame update
    void Start()
    {
         audios = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Identifica se o jogador caiu na piscina para tocar o audio recomecar o jogo 
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>())
        {
            PlayerBehavior player = collider.gameObject.GetComponent<PlayerBehavior>();
            foreach(AudioSource audio in audios){
                audio.Play();
            }

            player.Desacelerar();
        }
    }
}
