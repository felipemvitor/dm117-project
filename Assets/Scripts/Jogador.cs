using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    public static int vidas = 3;
 
  public int getVidas()
 {
     return vidas;
 }
 
 public void setX(int vida)
 {
     vidas = vida;
 }
}
