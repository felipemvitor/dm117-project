using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlataform : MonoBehaviour 
{ 

    private Rigidbody plataform;
        private Rigidbody obstaculo;


     public float fallDelay = 5.0f;

     
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
         if (collidedWithThis.gameObject.name == "Player" && ObstaculoComp.passouObstaculo == true) {
            StartCoroutine(FallAfterDelay());
         }

     }
 
    public IEnumerator FallAfterDelay()
     {
        yield return new WaitForSeconds(fallDelay);
        plataform.isKinematic = false;
         yield return new WaitForSeconds(fallDelay);
        obstaculo.isKinematic = false;

        if (plataform != null) {
          Destroy(plataform.transform.gameObject, 1.0f);
        }
     }
}
