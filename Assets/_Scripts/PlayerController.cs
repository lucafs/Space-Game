using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;
    GameManager gm;
    // private int gm.vidas;

    public GameObject tiro;
    public GameObject tiro2;

    public Transform arma;
    public Transform arma2;
    public float shotDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;
    private float _lastShootTimestamp2 = 0.0f;


    private void Start(){
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }
    public void Shoot()
    {
        if(Time.time - _lastShootTimestamp < shotDelay){return;}
        _lastShootTimestamp =Time.time;
        Instantiate(tiro, arma.position , Quaternion.identity);

    }
    public void Shoot2()
    {
        if(Time.time - _lastShootTimestamp2 < shotDelay){return;}
        _lastShootTimestamp2 =Time.time;
        Instantiate(tiro2, arma2.position , Quaternion.identity);

    }

    public void TakeDamage()
    {
        gm.vidas --;
        if(gm.vidas<=0){Die();}
    }

    public void Die()
    {
        Destroy(gameObject);
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }

    void FixedUpdate()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if(yInput != 0 || xInput !=0){
            animator.SetBool("Movement", true);
        }
        else{
            animator.SetBool("Movement", false);

        }
        if(Input.GetAxisRaw("Jump") != 0){
            Shoot();
        }
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot2();
        }
    }    

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("inimigos")){
            Destroy(other.gameObject);
            TakeDamage();
        }

    }

    
}
