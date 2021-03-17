using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject tiro;
    GameManager gm;
    public AudioClip explosionSFX;


    public void Start(){
        gm = GameManager.GetInstance();

    }
    public void Shoot()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        Instantiate(tiro, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        AudioManager.PlaySFX(explosionSFX);
        gm.pontos +=1;
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
