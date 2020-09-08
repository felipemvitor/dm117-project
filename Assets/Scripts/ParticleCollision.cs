using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleCollision : MonoBehaviour
{

    [Tooltip("Referência para a particula")]
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name == "Jogador") {
            if(JogadorComportamentoFaseDois.life == 0) {
                MusicaController.musica.Stop();
                SceneManager.LoadScene("GameOver");
             } else {
                 ControladorJogo.numTiles = 0;
                JogadorComportamentoFaseDois.life--;
                SceneManager.LoadScene("TelaInicialFaseDois");
             }
         } 
    }
}
