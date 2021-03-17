using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtaque : State
{
    SteerableBehaviour steerable;
    IShooter shooter;
    public float shootDelay = 1.0f;
    public float _lastShootTimestamp = 0.0f;

    public override void Awake(){
        base.Awake();
        Transition Patrulha = new Transition();
        Patrulha.condition = new ConditionDistLT(transform,
           GameObject.FindWithTag("Player").transform,
           2.0f);
        Patrulha.target = GetComponent<StatePatrulha>();
        transitions.Add(Patrulha);

        steerable = GetComponent<SteerableBehaviour>();
        
        shooter = steerable as IShooter;
        if(shooter == null){
            throw new MissingComponentException("G.O não tem Ishooter");
        }
    }
    public override void Update()
   {
       if (Time.time - _lastShootTimestamp < shootDelay) return;
       _lastShootTimestamp = Time.time;
       shooter.Shoot();
   }
}
