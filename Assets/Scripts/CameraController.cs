using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Tooltip("Referência do jogador que será acompanhado pela câmera")]
    public Transform alvo;

    [Tooltip("Posição da câmera em relação ao alvo")]
    private Vector3 offset = new Vector3(-10, 4, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alvo != null)
        {
            transform.position = alvo.position + offset;
            transform.LookAt(alvo);
        }
    }
}
