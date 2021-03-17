using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFimDoJogo : MonoBehaviour
{
    public Text message;
    public GameObject inimigo;
    public GameObject nave;
    Vector2 whereToSpawn;

    GameManager gm;

    public void Voltar()
    {
        gm.vidas = 5;
        gm.pontos = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("inimigos");
        foreach(GameObject enemy in enemies)
        GameObject.Destroy(enemy);


        whereToSpawn = new Vector2(0 , 0);
        Instantiate(nave,whereToSpawn,Quaternion.identity);
        gm.ChangeState(GameManager.GameState.GAME);
    }   
   private void OnEnable()
   {
       gm = GameManager.GetInstance();
       message.text = "Your score was: " + gm.pontos;
   }
}