using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ControllableMonoBehaviour
{

    public float speed = 1.0f;
    public GameObject glowPrefab;
    public Transform GlowSpawnPoint; 

    Rigidbody2D _rigidbody;



    void Start()
    {
        GameObject glow = Instantiate(glowPrefab, GlowSpawnPoint.position, Quaternion.identity);

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))).normalized;
        _rigidbody.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            // glow effect + increase speed
            // // if player collides with power up, increase its speed

            // GameObject glow = Instantiate(glowPrefab, GlowSpawnPoint.position, Quaternion.identity);
            StartCoroutine(PowerUp());
            Destroy(other.gameObject);
            
        }
    }

    IEnumerator PowerUp() {
        // GameObject glow = Instantiate(glowPrefab, GlowSpawnPoint.position, Quaternion.identity);
        speed = speed * 2f;
        yield return new WaitForSeconds(5);
        speed = speed / 2f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        if (_rigidbody)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
