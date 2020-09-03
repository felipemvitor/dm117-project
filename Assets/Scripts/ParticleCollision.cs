using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ParticleCollision : MonoBehaviour
{
    ParticleSystem particle;
    private void OnParticleCollision(GameObject other) {
        if (other.name.Equals("Player")) SceneManager.LoadScene("GameOver");
    }

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<ParticleSystem>().main.loop == false) {
             if (Time.timeScale < 0.01f)
             {
                 GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
             }
         } else if (GetComponent<ParticleSystem>().main.loop == true) {
             if (Time.timeScale < 0.01f) {
                 GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
             }
             
             if (Time.timeScale > 0.01f){
                 GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
             }
         }

    }
}
