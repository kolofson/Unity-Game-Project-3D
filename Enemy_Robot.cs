using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Robot : MonoBehaviour {

    Rigidbody enemy_robot;
    Animator animator;
    private GameObject player;

    void Start() {
        animator = this.gameObject.GetComponent<Animator>();
        enemy_robot = this.gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate() {
        //sight radius of player - eye sight of enemy - 
        if ((player.transform.position - this.transform.position).sqrMagnitude < 9 * 9) {
            //follow player rotation
            transform.LookAt(player.transform);
            //set animation triggers
            animator.SetTrigger("enemy_detected");
            animator.ResetTrigger("intiate_patrol");
        } else {
            //set animation triggers
            animator.ResetTrigger("enemy_detected");
            animator.SetTrigger("intiate_patrol");
            Patrol();
        }   
    }

    void OnCollisionEnter(Collision collision) {
        char collisionName = collision.gameObject.name[0];

        if (collisionName == 'W' || collisionName == 'C') {
            //turn right
            transform.Rotate(0, 90, 0);
        }
    }

    //functions
    void Patrol() {
        //move enemy
        enemy_robot.MovePosition(transform.position + transform.forward * Time.deltaTime);
    }
}
