using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehavior : MonoBehaviour
{
    [Tooltip("Referência para o rigidbody que representa o jogador")]
    private Rigidbody player;

    [Tooltip("Velocidade de corrida do jogador")]
    [Range(1, 10)]
    public float movSpeed = 5.0f;

    [Tooltip("Velocidade de corrida do jogador")]
    [Range(5, 15)]
    public float jumpSpeed = 10.0f;

    [Tooltip("Força do salto do jogador")]
    [Range(0, 3)]
<<<<<<< HEAD
    public float jumpForce = 4.0f;
=======
    public float jumpForce = 3.0f;
>>>>>>> origin/fase_one

    private Vector3 jump;

    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuPauseComp.paused) return;

<<<<<<< HEAD
         if(transform.position.y <= 6)
=======
        if(transform.position.y <= 6)
>>>>>>> origin/fase_one
        {
            SceneManager.LoadScene("GameOver");
        }

<<<<<<< HEAD
        var xSpeed = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        player.transform.Translate(new Vector3(xSpeed, 0, 0));
=======
        var xSpeed = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;
        var zSpeed = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        player.transform.Translate(new Vector3(xSpeed, 0, zSpeed* -1));
>>>>>>> origin/fase_one

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jumping)
            {
                player.AddForce(jump * jumpForce, ForceMode.Impulse);
                jumping = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Platform")) jumping = false;
    }
}