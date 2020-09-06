using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenduloGenerator : MonoBehaviour
{

    [Tooltip("Referencia para o prefab do pendulo")]
    public GameObject pendulo;

    [Tooltip("Coordenadas do primeiro pendulo em relação ao componente pai")]
    public Vector3 posicaoInicial = new Vector3(-20, 0, 0);

    private Vector3 parentPosition;

    private float startTime = 0;
    private float minAngle = 45;
    private float maxAngle = 90;
    private float numberOfPendulums = 15;
    private float angleRatio;
    private float speedRatio;

    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.position;

        //Calcula a razao entre a faixa de angulos e velocidades pela quantidade de pendulos
        // Dessa forma eh possivel calcular uma diferenca de angulo e velocidade entre os pendulos seguinto a razao calculada
        angleRatio = (maxAngle - minAngle) / (numberOfPendulums - 1);
        speedRatio = 3 / (numberOfPendulums - 1);

        for (int i = 0; i < numberOfPendulums; i++)
        {
            //SpawnProximoPendulo(i * 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Cria o proximo pendulo 
    /// </summary>
    /// <param name="offset">Distancia entre o pendulo calculado e o anterior</param>
    private void SpawnProximoPendulo(int offset)
    {
        var position = new Vector3(parentPosition.x + posicaoInicial.x + offset, parentPosition.y + posicaoInicial.y, parentPosition.z + posicaoInicial.z);

        GameObject newPendulum = Instantiate(pendulo, position, Quaternion.identity);
        PenduloController controller = newPendulum.GetComponentInChildren<PenduloController>();

        controller.velocidade = 3 + (offset / 10) * speedRatio;
        controller.angulo = minAngle + (offset / 10) * angleRatio;

        newPendulum.transform.parent = this.transform;

        print("Speed: " + controller.velocidade + ", angle: " + controller.angulo);
    }
}
