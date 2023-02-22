using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeSpan : MonoBehaviour
{

    // public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            // hit/explosion?
            // Instantiate(explosion, transform.position, Quaternion.identity);    // explode = death
            Destroy(gameObject);    // destroy the projectile (self)
        }
        // when projectile hits object, destroy projectile (makes sense)
    }
}
