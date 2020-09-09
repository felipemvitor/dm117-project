using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorComportamentoFaseDois : MonoBehaviour
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

        if (transform.position.y <= 4)
        {
            MusicaController.musica.Stop();

            if (Jogador.vidas == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                Jogador.vidas--;
                SceneManager.LoadScene("TentarNovamenteFaseDois");
            }
        }

        if (!naAgua)
        {
            RaycastHit hit;
            //Projeta um vetor "imaginario" para corrigir problema de objetos ao utilizar o translate.
            if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(1, 0, 0)), out hit))
            {
                //Movimenta o jogador
                var xSpeed = Input.GetAxis("Horizontal") * velocidadeMovimento * Time.deltaTime;
                jogador.transform.Translate(new Vector3(xSpeed, 0, 0));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!saltando)
                {
                    jogador.AddForce(salto * forcaSalto, ForceMode.Impulse);
                    saltando = true;
                }
            }
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
