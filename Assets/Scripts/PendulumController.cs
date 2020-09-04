using UnityEngine;

public class PendulumController : MonoBehaviour
{

    [Tooltip("Velocidade do pendulo")]
<<<<<<< HEAD
    [Range(0, 5)]
=======
    [Range(2, 5)]
>>>>>>> origin/fase_one
    public float speed = 2f;

    [Tooltip("Angulo  do pendulo")]
    [Range(0, 360)]
    public float angle = 90;

    [Tooltip("Tempo de inicio do movimento")]
    public float startTime = 0;

    private Quaternion startAngle;
    private Quaternion endAngle;


    public void Create()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        startAngle = pendulumRotation(angle);
        endAngle = pendulumRotation(-angle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(startAngle, endAngle, (Mathf.Sin(startTime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }

    private void ResetTimer()
    {
        startTime = 0;
    }

    private Quaternion pendulumRotation(float angle)
    {
        var initialRotation = transform.rotation;
        var angleX = initialRotation.eulerAngles.x + angle;
        var angleY = initialRotation.eulerAngles.y;
        var angleZ = initialRotation.eulerAngles.z;

        if (angleX > 180) angleX -= 360;
        else if (angleX < -180) angleX += 360;

        initialRotation.eulerAngles = new Vector3(angleX, angleY, angleZ);
        return initialRotation;
    }
}
