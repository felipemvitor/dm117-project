using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoComp : MonoBehaviour
{
    private Rigidbody obstaculo;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<PlayerFaseTwo>()) {
            obstaculo.isKinematic = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        obstaculo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
