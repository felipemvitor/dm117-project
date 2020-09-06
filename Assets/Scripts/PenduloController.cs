using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenduloController : MonoBehaviour
{
    [Tooltip("Velocidade do pendulo")]
    [Range(2, 5)]
    public float velocidade = 2f;

    [Tooltip("Angulo  do pendulo")]
    [Range(0, 360)]
    public float angulo = 90;

    private Quaternion startAngle;
    private Quaternion endAngle;

    private float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        startAngle = CalcularRotacaoPendulo(angulo);
        endAngle = CalcularRotacaoPendulo(-angulo);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculo da nova posicao do pendulo.
        // Com o valor calculado eh feita a interpolacao entre o ponto anterior e o calculado.
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(startAngle, endAngle, (Mathf.Sin(startTime * velocidade + Mathf.PI / 2) + 1.0f) / 2.0f);
    }

    /// <summary>
    /// Calcula a posição inicial do pendulo
    /// </summary>
    /// <param name="angulo">Angulo entre o que o prefab selecionado ira rotacionar</param>
    /// <returns></returns>
    private Quaternion CalcularRotacaoPendulo(float angulo)
    {
        var initialRotation = transform.rotation;
        var angleX = initialRotation.eulerAngles.x + angulo;
        var angleY = initialRotation.eulerAngles.y;
        var angleZ = initialRotation.eulerAngles.z;

        if (angleX > 180) angleX -= 360;
        else if (angleX < -180) angleX += 360;

        initialRotation.eulerAngles = new Vector3(angleX, angleY, angleZ);
        return initialRotation;
    }
}
