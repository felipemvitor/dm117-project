using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoComportamento : MonoBehaviour
{

    [Tooltip("Referência para o rigidbody que representa o obstaculo")]
    private Rigidbody obstaculo;

    // Start is called before the first frame update
    void Start()
    {
        obstaculo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<JogadorComportamentoFaseDois>())
        {
            obstaculo.isKinematic = true;
        }
    }
}
