using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerBehavior : MonoBehaviour
{
    [Tooltip("Referência para o rigidbody que representa o jogador")]
    private Rigidbody player;

    [Tooltip("Velocidade de corrida do jogador")]
    [Range(1,10)]
    public float movSpeed = 5.0f;

    [Tooltip("Velocidade de corrida do jogador")]
    [Range(5, 15)]
    public float jumpSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var xSpeed = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        var ySpeed = Input.GetAxis("Vertical") * jumpSpeed * Time.deltaTime;


        player.transform.Translate(new Vector3(xSpeed, ySpeed, 0));
    }
}
