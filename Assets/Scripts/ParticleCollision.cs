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
        StartCoroutine(FallAfterDelay());

    }
     IEnumerator FallAfterDelay()
     {
        Debug.Log("Particula pausada");
        yield return new WaitForSeconds(5);
        particle.maxParticles = 0; 
        yield return new WaitForSeconds(2);
        particle.maxParticles = 8; 

     }
}
