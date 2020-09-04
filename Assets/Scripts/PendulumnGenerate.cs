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

<<<<<<< HEAD
=======
    private float startTime;

    private float minAngle = 30;
    private float maxAngle = 90;
    private float numberOfPendulums = 15;
    private float angleRatio;
    private float speedRatio;

>>>>>>> origin/fase_one
    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.position;

<<<<<<< HEAD
        for (int i = 0; i < 15; i++)
=======
        startTime = new System.Random().Next(0, 4);

        angleRatio = (maxAngle - minAngle) / (numberOfPendulums - 1);
        speedRatio = 3 / (numberOfPendulums - 1);

        for (int i = 0; i < numberOfPendulums; i++)
>>>>>>> origin/fase_one
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

<<<<<<< HEAD
        controller.speed = new System.Random().Next(0, 6);
        controller.startTime = new System.Random().Next(0, 4);
        controller.angle = new System.Random().Next(0, 91);

        newPendulum.transform.parent = this.transform;
=======
        controller.startTime = this.startTime;
        controller.speed = 3 + (offset / 10) * speedRatio;
        controller.angle = minAngle + (offset / 10) * angleRatio;

        newPendulum.transform.parent = this.transform;

        print("Speed: " + controller.speed + ", angle: " + controller.angle);
>>>>>>> origin/fase_one
    }
}
