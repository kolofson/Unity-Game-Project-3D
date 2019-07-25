using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    //jump data
    private bool grounded = false;
    private float t = 0.0f;
    private bool moving = false;
    //reg setup data
    public float speed = 1.0f / 2;
    Rigidbody character;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        character = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update() {

        if (Input.GetKeyDown("escape")) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void FixedUpdate() {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            character.velocity = new Vector3(0, 7, 0);
            moving = true;
            grounded = false;
        }

        if (moving) {
            // when the cube has moved over 1 second report it's position
            t = t + Time.deltaTime;
            if (t > 1.0f) {
                t = 0.0f;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        grounded = true;
    }
}