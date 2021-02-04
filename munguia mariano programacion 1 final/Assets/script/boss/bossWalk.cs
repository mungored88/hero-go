using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWalk : StateMachineBehaviour
{
    public float speed;
    public float attackRange;
    Transform Player;
    Rigidbody2D rb;
    boss boss;
    

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Player = GameObject.Find("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
       boss = animator.GetComponent<boss>();
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss.LookAtPlayer();

        Vector2 target = new Vector2(Player.position.x, rb.position.y);
        Vector2 newPos= Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if(Vector2.Distance(Player.position,rb.position)<= attackRange)
        {
            animator.SetTrigger("Attack");
        }
   }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}
