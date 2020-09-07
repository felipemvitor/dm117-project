using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoComp : MonoBehaviour
{
    public static bool passouObstaculo;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<PlayerFaseTwo>()) {
            //Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if(UnityEngine.Rigidbody.FindObjectOfType<PlayerFaseTwo>().transform.position.x > ControladorJogo.novoObs.position.x) {
    //      //  Debug.Log("Deu certo");
           passouObstaculo = true;
        }
    }
}
