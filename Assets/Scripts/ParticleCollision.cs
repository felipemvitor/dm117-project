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
            if(Jogador.vidas == 0) {
                MusicaController.musica.Stop();
                SceneManager.LoadScene("GameOver");
             } else {
                MusicaController.musica.Stop();
                ControladorJogo.numTiles = 0;
                Jogador.vidas--;
                SceneManager.LoadScene("TelaInicialFaseDois");
             }
         } 
    }
}
