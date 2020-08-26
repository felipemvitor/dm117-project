using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumnGenerate : MonoBehaviour
{

    [Tooltip("Referencia para o prefab do pendulo")]
    public GameObject pendulum;

    [Tooltip("Coordenadas do primeiro pendulo em relação ao componente pai")]
    public Vector3 initialPosition = new Vector3(10, 0, 0);

    private Vector3 parentPosition;

    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.position;

        for (int i = 0; i < 15; i++)
        {
            SpawnNextPendulum(i * 10);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnNextPendulum(int offset)
    {
        var position = new Vector3(parentPosition.x + initialPosition.x + offset, parentPosition.y + initialPosition.y, parentPosition.z + initialPosition.z);

        GameObject newPendulum = Instantiate(pendulum, position, Quaternion.identity);
        PendulumController controller = newPendulum.GetComponentInChildren<PendulumController>();

        controller.speed = new System.Random().Next(0, 6);
        controller.startTime = new System.Random().Next(0, 4);
        controller.angle = new System.Random().Next(0, 91);

        newPendulum.transform.parent = this.transform;
    }
}
