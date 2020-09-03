using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlataform : MonoBehaviour 
{    

    [Tooltip("Referencia para o prefab do obstaculo")]
    public GameObject obstaculo;

    private Rigidbody plataform;

     public float fallDelay = 5.0f;
     

     
    // Start is called before the first frame update
    void Start()
    {
        plataform = GetComponent<Rigidbody>();
    }
     void OnCollisionEnter(Collision collidedWithThis)
     {
         if (collidedWithThis.gameObject.name == "Player" && FimTileComportamento.passou == true)
         {
            StartCoroutine(FallAfterDelay());
            ObstaculoComp.passouObstaculo = false;
         }
     }
 
    public IEnumerator FallAfterDelay()
     {
        yield return new WaitForSeconds(fallDelay);
        plataform.isKinematic = false;

        if(plataform != null) {
        Destroy(plataform.transform.gameObject, 1.0f);
        }
    
     }
}
