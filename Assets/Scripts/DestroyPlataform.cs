using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlataform : MonoBehaviour 
{    
    
     public float fallDelay = 1.0f;
     
     void OnCollisionEnter(Collision collidedWithThis)
     {
         if (collidedWithThis.gameObject.name == "Player")
         {
             StartCoroutine(FallAfterDelay());
         }
     }
 
     IEnumerator FallAfterDelay()
     {
         yield return new WaitForSeconds(fallDelay);
         GetComponent<Rigidbody>().isKinematic = false;
     }
}
