﻿using System;
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
    public float movSpeed = 7.0f;

    [Tooltip("Velocidade de corrida do jogador")]
    [Range(5, 15)]
    public float jumpSpeed = 10.0f;

    [Tooltip("Força do salto do jogador")]
    [Range(0, 3)]
    public float jumpForce = 3.0f;

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

        if(transform.position.y <= 4)
        {
            SceneManager.LoadScene("GameOver");
        }

        var xSpeed = Input.GetAxis("Vertical") * movSpeed;
        var zSpeed = Input.GetAxis("Horizontal") * movSpeed;
        //player.transform.Translate(new Vector3(xSpeed, 0, zSpeed* -1));
        player.AddForce(xSpeed, 0, zSpeed * -1);

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

    public void DrawnPlayer()
    {
        player.velocity = new Vector3(player.velocity.x, 0, player.velocity.z);
    }
}
