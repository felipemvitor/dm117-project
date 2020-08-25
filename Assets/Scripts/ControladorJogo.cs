using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJogo : MonoBehaviour
{

    [Tooltip("Referencia para o TileBasico")]
    public Transform tile;

    [Tooltip("Ponto para se colocar o TileBasicoInicial")]
    public Vector3 pontoInicial = new Vector3(0,0,0);

    [Tooltip("Quantidade de Tiles iniciais")]
    [Range(1,20)]
    public int numSpawnIni;

    /// <summary>
    /// Local para spawn do proximo Tile
    /// </summary>
    private Vector3 proxTilePos;

    /// <summary>
    /// Rotacao do proximo Tile
    /// </summary>
    private Quaternion proxTileRot;
    // Start is called before the first frame update
    void Start()
    {
        //Preparando o ponto inicial
        proxTilePos = pontoInicial;
        proxTileRot = Quaternion.identity;

        for (int i = 0; i < numSpawnIni; i++) {
            SpawnProxTile();
        }
    }

    public void SpawnProxTile(){

        var novoTile = Instantiate(tile, proxTilePos, proxTileRot);
        var newPosition = new Vector3 (15,0,0);
        
        //Detectar qual o local de spawn do prox tile
        var proxTile = novoTile.Find("PontoSpawn");
        proxTilePos = proxTile.position + newPosition;
        proxTileRot = proxTile.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
