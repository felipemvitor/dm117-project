using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{

    [Tooltip("Som do jogador caindo na água")]
    public AudioSource splashSound;

    // Start is called before the first frame update
    void Start()
    {
        splashSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>())
        {
            PlayerBehavior player = collider.gameObject.GetComponent<PlayerBehavior>();
            splashSound.Play();

            player.DrawnPlayer();
        }
    }
}
