using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJogo : MonoBehaviour
{

    [Tooltip("Referencia para o TileBasico")]
    public Transform tile;

    [Tooltip("Referencia para o Obstaculo")]
    public Transform obstaculo;

    [Tooltip("Referencia para o novo obstaculo")]
    public static Transform novoObs;

    [Tooltip("Ponto para se colocar o TileBasicoInicial")]
    public Vector3 pontoInicial = new Vector3(0,0,0);

    [Tooltip("Quantidade de Tiles iniciais")]
    [Range(1,8)]
    public int numSpawnIni;

    [Tooltip("Quantidade de Tiles sem obstaculos")]
    [Range(1,4)]
    public int numTileSemObs = 2;

    [Tooltip("Quantidade total de Tiles")]
    [Range(1,8)]
    public static int numTiles = 0;

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
            SpawnProxTile(i >= numTileSemObs);
        }
    }

    public void SpawnProxTile(bool spawnObstaculos = true){
        if(numTiles < 8) {
            
        var novoTile = Instantiate(tile, proxTilePos, proxTileRot);
        var newPosition = new Vector3 (20,0,0);
        
        //Detectar qual o local de spawn do prox tile
        var proxTile = novoTile.Find("PontoSpawn");
        proxTilePos = proxTile.position + newPosition;
        proxTileRot = proxTile.rotation;

        //Verifica se já podemos criar Tiles com obstaculos
        if (!spawnObstaculos)
            return;

        //Devemos buscar todos os locais possíveis
        var pontosObstaculos = new List<GameObject>();

        foreach (Transform filho in novoTile)
        {
            //Vamos verificar se possui a TAG
            if (filho.CompareTag("ObsSpawn"))
            {
                Debug.Log("Adicionou na lista");
                //Adiciona na lista como potência ponto de spawn de obstaculo
                pontosObstaculos.Add(filho.gameObject);

            }
        }

        if (pontosObstaculos.Count > 0)
        {
            Debug.Log(pontosObstaculos.Count);
            //Vamos pegar um ponto aleatório
            var pontoSpawn = pontosObstaculos[Random.Range(0, pontosObstaculos.Count)];

            //Vamos guardar a posição desse ponto de spawn
            var obsSpawnPos = pontoSpawn.transform.position;

            //Criar um novo obstaculo
            novoObs = Instantiate(obstaculo, obsSpawnPos, Quaternion.identity);

            //Faz esse obstaculo ser filho de TileBasico
            novoObs.SetParent(pontoSpawn.transform);
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
