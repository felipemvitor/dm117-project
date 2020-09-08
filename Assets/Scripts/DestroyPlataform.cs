using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlataform : MonoBehaviour 
{ 


    [Tooltip("Referência para o rigidbody que representa a plataforma")]
    private Rigidbody plataform;

    
    [Tooltip("Referência para o rigidbody que representa o obstaculo")]
    private Rigidbody obstaculo;

     public float fallDelay = 5.0f;

     public static bool destroy = false;

     
    // Start is called before the first frame update
    void Start()
    {
        plataform = GetComponent<Rigidbody>();
        obstaculo = GetComponent<Rigidbody>();
    }

    void Update() {

    }

     void OnCollisionEnter(Collision collidedWithThis)
     {
         if (collidedWithThis.gameObject.name == "Player") {
            StartCoroutine(FallAfterDelay());
            destroy = true;
         }

     }
 
    public IEnumerator FallAfterDelay()
     {
        yield return new WaitForSeconds(fallDelay);
        plataform.isKinematic = false;
        yield return new WaitForSeconds(fallDelay);
        obstaculo.isKinematic = false;

        if (plataform != null) {
          Destroy(plataform.transform.gameObject, 0.5f);
        }
     }
}
