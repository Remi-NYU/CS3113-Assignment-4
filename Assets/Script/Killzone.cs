using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{

    public string tag_to_kill;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tag_to_kill))
        {
            Destroy(other.gameObject);
        }
    }
}
