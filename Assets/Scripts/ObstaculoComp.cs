using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoComp : MonoBehaviour
{
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
    }
}
