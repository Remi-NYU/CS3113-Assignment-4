using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineProjMove : MonoBehaviour
{

    // public GameObject explosion;


    // IF VINE HITS SOMETHING (COLLIDES), COME BACK DOWN
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            // Instantiate(explosion, transform.position, Quaternion.identity);    // explode = death
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 
            (GameObject.Find("Player").GetComponent<PlantPlayerShoot>().vineSpeed)*-1));
            // gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.forward * 10000f * Time.deltaTime);
            // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, (vineSpeed * -1)));
        }
    }

    void Update() {
        if (transform.position.y >= 0f) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 
            (GameObject.Find("Player").GetComponent<PlantPlayerShoot>().vineSpeed)*-1));
            // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, (vineSpeed * -1)));
        }

    }
}
