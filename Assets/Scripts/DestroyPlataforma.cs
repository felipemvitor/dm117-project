using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlataforma : MonoBehaviour
{
    [Tooltip("Referência para o rigidbody que representa a plataforma")]
    private Rigidbody plataform;

    public float fallDelay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        plataform = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.gameObject.name == "Jogador" && ControladorJogo.numTiles < 6)
        {
            StartCoroutine(FallAfterDelay());
        }

    }

    public IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        plataform.isKinematic = false;

        if (plataform != null)
        {
            Destroy(plataform.transform.gameObject, 3.0f);
        }
    }
}
