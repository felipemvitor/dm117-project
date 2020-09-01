using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoComp : MonoBehaviour
{

    public static bool passouObstaculo = false;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<PlayerBehavior>()) {
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
        //if(UnityEngine.Rigidbody.FindObjectOfType<PlayerBehavior>().transform.position.x > transform.position.x) {
         //  Debug.Log("Deu certo");
         //   passouObstaculo = true;
      //  } 
    }
}
