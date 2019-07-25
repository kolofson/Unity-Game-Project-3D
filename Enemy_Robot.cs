using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Robot : MonoBehaviour {

    Rigidbody enemy_robot;

    // Start is called before the first frame update
    void Start() {
        enemy_robot = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {

    }
}
