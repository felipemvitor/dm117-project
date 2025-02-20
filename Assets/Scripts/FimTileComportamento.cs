﻿using UnityEngine;

public class FimTileComportamento : MonoBehaviour
{
    [Tooltip("Tempo esperado antes de destruir o TileBasico")]
    public float tempoDestruir = 4.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        //Verifica se o player passou pelo fim do TileBasico
        if (other.GetComponent<JogadorComportamentoFaseDois>())
        {
            ControladorJogo.numTiles++;
            GameObject.FindObjectOfType<ControladorJogo>().SpawnProxTile();
        }
    }
}
