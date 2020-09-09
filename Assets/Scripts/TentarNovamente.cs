using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TentarNovamente : MonoBehaviour
{

    public Text vidas;
    // Start is called before the first frame update
    void Start()
    {
        vidas = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Jogador.vidas == 0) {
            vidas.text = "Essa é sua última chance";
        } else {
            vidas.text = "Você possui " + Jogador.vidas + " vida(s).";
        }
    }
}
