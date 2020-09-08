using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseComp : MonoBehaviour
{
    public static bool paused;

    [SerializeField]
    private GameObject menuPausePanel;

    /// <summary>
    /// Metodo para reiniciar a scene
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Metodo para pausar o jogo
    /// </summary>
    /// <param name="isPaused"></param>
    public void Pause(bool isPaused)
    {
        paused = isPaused;

        Time.timeScale = (paused) ? 0 : 1;

        menuPausePanel.SetActive(paused);

        if (isPaused == false) {
            if (MusicaController.musica != null) {
                MusicaController.musica.Play();
            }
        }
    }


    /// <summary>
    /// Metodo para carregar uma Scene
    /// </summary>
    /// <param name="scene">Nome da scene que sera carregada</param>
    public void CarregaScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Pause(false);
        if (MusicaController.musica != null) {
            MusicaController.musica.Play();
       }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
