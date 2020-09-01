using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlataform : MonoBehaviour 
{    

    [Tooltip("Referencia para o prefab do obstaculo")]
    public GameObject obstaculo;

     public float fallDelay = 1.0f;
     
     void OnCollisionEnter(Collision collidedWithThis)
     {
         if (collidedWithThis.gameObject.name == "Player" && ObstaculoComp.passouObstaculo == true)
         {
            StartCoroutine(FallAfterDelay());
            ObstaculoComp.passouObstaculo = false;
         }
     }
 
     IEnumerator FallAfterDelay()
     {
         yield return new WaitForSeconds(fallDelay);
         GetComponent<Rigidbody>().isKinematic = false;
     }
}
