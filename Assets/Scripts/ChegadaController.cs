using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChegadaController : MonoBehaviour
{

    [Tooltip("Som de aplauso para finalizar jogo")]
    public AudioSource aplauso;

    // Start is called before the first frame update
    void Start()
    {
        aplauso = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>())
        {
            aplauso.Play();
        }
    }
}
