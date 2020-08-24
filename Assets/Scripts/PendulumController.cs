using UnityEngine;

public class PendulumController : MonoBehaviour
{
    [Tooltip("Angulo que o pendulo será iniciado")]
    public float angle = 90f;

    [Tooltip("Velocidade do pendulo")]
    [Range(0f, 5f)]
    public float speed = 2f;

    private Quaternion startAngle;
    private Quaternion endAngle;

    private float startTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        int signal;
        int value = new System.Random().Next(0, 201);
        print(value);

        if (value % 2 == 0)
            signal = 1;
        else
            signal = -1;

        print(signal);
        startAngle = pendulumRotation(signal * angle);
        endAngle = pendulumRotation(-signal * angle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(startAngle, endAngle, (Mathf.Sin(startTime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }

    private Quaternion pendulumRotation(float angle)
    {
        var initialRotation = transform.rotation;
        var angleX = initialRotation.eulerAngles.x + angle;
        var angleY = initialRotation.eulerAngles.y;
        var angleZ = initialRotation.eulerAngles.z;

        if (angleX < 180) angleX -= 360;
        else if (angleX > -180) angleX += 360;

        initialRotation.eulerAngles = new Vector3(angleX, angleY, angleZ);
        return initialRotation;
    }
}
