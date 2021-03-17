using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehavior : SteerableBehaviour
{
    Vector3 direction;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("inimigos")) return;

        IDamageable damageable = other.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if(!(damageable is null)){
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }
    private void Start(){

    }
    private void Update(){
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer  - transform.position).normalized;
        Thrust(direction.x,direction.y);
    }
    private void OnBecameInvisible(){
        gameObject.SetActive(false);
    }

}
