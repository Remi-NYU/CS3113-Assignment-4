using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ControllableMonoBehaviour
{

    public float speed = 3.0f;

    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))).normalized;
        _rigidbody.velocity = direction * speed;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        if (_rigidbody)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PowerUp")) {
            // if player collides with power up, increase its speed
            speed = speed * 1.2f;
        }
    }
}
