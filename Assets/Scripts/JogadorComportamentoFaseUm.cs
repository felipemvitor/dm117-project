using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class JogadorComportamentoFaseUm : MonoBehaviour
{
    [Tooltip("Referência para o rigidbody que representa o jogador")]
    private Rigidbody jogador;

    [Tooltip("Velocidade de corrida do jogador")]
    [Range(1, 10)]
    public float velocidadeMovimento = 5.0f;

    [Tooltip("Velocidade de corrida do jogador")]
    [Range(5, 15)]
    public float velocidadeSalto = 10.0f;

    [Tooltip("Força impulso do salto do jogador")]
    [Range(0, 3)]
    public float forcaSalto = 3.0f;

    /// <summary>
    /// Vetor que representa o salto.
    /// </summary>
    private Vector3 salto;

    /// <summary>
    /// Valor que indica se o jogador esta saltando ou se esta sob a plataforma
    /// </summary>
    private bool saltando = false;

    /// <summary>
    /// Valor que indica se o jogador caiu na agua
    /// </summary>
    private bool naAgua = false;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GetComponent<Rigidbody>();
        salto = new Vector3(0.0f, forcaSalto, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuPauseComp.paused) return;

        if (transform.position.y <= 4) {
            if(MusicaController.musica != null) {
                MusicaController.musica.Stop();
            }

            if (Jogador.vidas == 0) {
                SceneManager.LoadScene("GameOver");
            } else {
                Jogador.vidas--;
                SceneManager.LoadScene("TentarNovamenteFaseUm");
            }
        } 


        if (!naAgua)
        {
            //Verifica se a tecla de espaço foi pressionada (tecla de salto)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // O jogador somente pula se estiver na plataforma.
                // Isso evita que o jogador dê múltiplos pulos e saia voando
                if (!saltando)
                {
                    // Adiciona um impulso que faz o jogador saltar
                    jogador.AddForce(salto * forcaSalto, ForceMode.Impulse);
                    saltando = true;
                }
            }
            else if (!saltando)
            {
                //Movimenta o jogador para a frente somente quando não esta pulado
                // Evita que o impulso do salto aumente a velocidade do jogador
                var velocidadeX = Input.GetAxis("Vertical") * velocidadeMovimento;
                var velocidadeZ = Input.GetAxis("Horizontal") * velocidadeMovimento;

                jogador.AddForce(velocidadeX, 0, velocidadeZ * -1);
            }

            //Movimenta o jogador
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Caso o jogador tenha colidido com a plataforma significa que ele nao esta mais saltando
        if (collision.gameObject.name.Equals("Plataforma")) saltando = false;
    }

    /// <summary>
    /// Zera a velocidade do jogador quando colide com a agua
    /// </summary>
    public void Desacelerar()
    {
        jogador.velocity = new Vector3(jogador.velocity.x, 0, jogador.velocity.z);
        naAgua = true;
    }
}
