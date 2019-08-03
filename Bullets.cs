using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {
    
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    private bool shoot = true;
    private GameObject player;
    private GameObject enemy;

    void Start() {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Robot");
    }

    // Update is called once per frame
    void Update() {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 9 * 9) {
            transform.LookAt(player.transform);
            if (shoot) {
                Fire();
                StartCoroutine(reload());
            }
        }
    }

    //functions
    void Fire() {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        //rotation of bullets
        Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);

        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        //ignore collision between bullets and box collider from enemy that shoots bullets
        Physics.IgnoreCollision(Temporary_RigidBody.GetComponent<Collider>(), enemy.GetComponent<Collider>());

        //send bullet to player
        Temporary_RigidBody.AddForce(transform.forward * 2500);
        Destroy(Temporary_Bullet_Handler, 1.0f);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "player") {
            Destroy(this.gameObject);
        }
    }

    IEnumerator reload() {
        shoot = false;
        yield return new WaitForSeconds(1);
        shoot = true;
    }
}