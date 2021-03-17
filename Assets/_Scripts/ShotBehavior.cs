using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : SteerableBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")) return;

        IDamageable damageable = other.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if(!(damageable is null)){
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }
    private void Update(){
        
        Thrust(1,0);
    }

}
