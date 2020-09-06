using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimJogoComportamento : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Metodo para carregar uma Scene
    /// </summary>
    /// <param name="scene">Nome da scene que sera carregada</param>
    public void RestartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
