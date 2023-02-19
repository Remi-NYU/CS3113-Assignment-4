using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHitbox : MonoBehaviour
{
    VineEnemyController controller;

    void Start()
    {
        controller = transform.parent.GetComponent<VineEnemyController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            controller.GrabCow(other.gameObject.GetComponent<Cow>());
            return;
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            controller.Hurt();
            return;
        }
    }
}
